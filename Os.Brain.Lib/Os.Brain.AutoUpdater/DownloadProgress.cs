using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.IO;

namespace Os.Brain.Utility
{
    public partial class DownloadProgress : Form
    {
        private bool isFinished = false;
        private List<DownloadFileInfo> downloadFileList = null;
        private ManualResetEvent evtDownload = null;
        private ManualResetEvent evtPerDonwload = null;
        private WebClient clientDownload = null;

        public static Progress FileProgress = new Progress(400, 24);
        public static Progress TotalProgress = new Progress(400, 24);

        public DownloadProgress(List<DownloadFileInfo> downloadFileList)
        {
            InitializeComponent();
            this.downloadFileList = downloadFileList;
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isFinished && DialogResult.No == MessageBox.Show("当前正在更新，是否取消？", "自动升级", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                e.Cancel = true;
                return;
            }
            else
            {
                if (clientDownload != null)
                    clientDownload.CancelAsync();

                evtDownload.Set();
                evtPerDonwload.Set();
            }
        }

        private void OnFormLoad(object sender, EventArgs e)
        {
            FileProgress.Draw("", 0, 100);
            TotalProgress.Draw("下载总进度 ", 0, 10);
            imgFile.Image = FileProgress.Image;
            imtTotal.Image = TotalProgress.Image;
            evtDownload = new ManualResetEvent(true);
            evtDownload.Reset();
            Thread t = new Thread(new ThreadStart(ProcDownload));
            t.Name = "download";
            t.Start();
        }
        int mUpateCount = 0;
        int mCurrentCount = 0;
        long fileReciveCount = 0;
        private void ProcDownload()
        {
            evtPerDonwload = new ManualResetEvent(false);
            mCurrentCount = 0;
            mUpateCount = this.downloadFileList.Count;
            TotalProgress.Draw(string.Format("更新文件总进度 {0}/{1}", mCurrentCount, mUpateCount), mCurrentCount, mUpateCount);

            while (!evtDownload.WaitOne(0, false))
            {
                if (this.downloadFileList.Count == 0)
                    break;

                DownloadFileInfo file = this.downloadFileList[0];
                fileReciveCount = 0;
                FileProgress.Draw(file.FileName, fileReciveCount, file.Size);
                //Debug.WriteLine(String.Format("Start Download:{0}", file.FileName));

                //下载
                clientDownload = new WebClient();

                clientDownload.DownloadProgressChanged += new DownloadProgressChangedEventHandler(OnDownloadProgressChanged);
                clientDownload.DownloadFileCompleted += new AsyncCompletedEventHandler(OnDownloadFileCompleted);

                evtPerDonwload.Reset();
                string tmpfilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, file.FileFullName + ".tmp");
                FileInfo fileInfo = new FileInfo(tmpfilePath);
                if (!fileInfo.Directory.Exists)
                    fileInfo.Directory.Create();

                clientDownload.DownloadFileAsync(new Uri(file.DownloadUrl), tmpfilePath, file);
                //等待下载完成
                evtPerDonwload.WaitOne();

                clientDownload.Dispose();
                clientDownload = null;

                //移除已下载的文件
                this.downloadFileList.Remove(file);
            }

            //Debug.WriteLine("All Downloaded");

            if (this.downloadFileList.Count == 0)
                Exit(true);
            else
                Exit(false);

            evtDownload.Set();
        }

        void OnDownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            DownloadFileInfo file = e.UserState as DownloadFileInfo;
            //nDownloadedTotal += file.Size;
            mCurrentCount++;
            TotalProgress.Draw(string.Format("下载总进度 {0}/{1}", mCurrentCount, mUpateCount), mCurrentCount, mUpateCount);

            //Debug.WriteLine(String.Format("Finish Download:{0}", file.FileName));
            //替换现有文件
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, file.FileFullName);
            if (File.Exists(filePath))
            {
                if (File.Exists(filePath + ".old"))
                    File.Delete(filePath + ".old");

                File.Move(filePath, filePath + ".old");
            }

            File.Move(filePath + ".tmp", filePath);
            //继续下载其它文件
            evtPerDonwload.Set();
        }

        void OnDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            DownloadFileInfo file = e.UserState as DownloadFileInfo;
            fileReciveCount += e.BytesReceived;
            FileProgress.Draw(file.FileName, fileReciveCount, file.Size);
        }

        delegate void ExitCallBack(bool success);
        private void Exit(bool success)
        {
            if (this.InvokeRequired)
            {
                ExitCallBack cb = new ExitCallBack(Exit);
                this.Invoke(cb, new object[] { success });
            }
            else
            {
                this.isFinished = success;
                this.DialogResult = success ? DialogResult.OK : DialogResult.Cancel;
                this.Close();
            }
        }

        private void OnCancel(object sender, EventArgs e)
        {
            evtDownload.Set();
            evtPerDonwload.Set();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lock (FileProgress)
            {
                imgFile.Refresh();
            }
            lock (TotalProgress)
            {
                imtTotal.Refresh();
            }
        }
    }
}