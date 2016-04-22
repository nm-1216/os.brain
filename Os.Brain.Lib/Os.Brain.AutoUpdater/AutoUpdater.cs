using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;
using System.Net;

namespace Os.Brain.Utility
{
    public class AutoUpdater
    {
        const string FILENAME = "update.config";
        public Config config = null;
        private bool bNeedRestart = false;

        public AutoUpdater()
        {
            config = Config.LoadConfig(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FILENAME));
        }
        /// <summary>
        /// 检查新版本
        /// </summary>
        /// <exception cref="System.Net.WebException">无法找到指定资源</exception>
        /// <exception cref="System.NotSupportException">升级地址配置错误</exception>
        /// <exception cref="System.Xml.XmlException">下载的升级文件有错误</exception>
        /// <exception cref="System.ArgumentException">下载的升级文件有错误</exception>
        /// <exception cref="System.Excpetion">未知错误</exception>
        /// <returns></returns>
        public void Update(string updateInfo)
        {
            if (!config.Enabled)
                return;
            /*
             * 请求Web服务器，得到当前最新版本的文件列表，格式同本地的FileList.xml。
             * 与本地的FileList.xml比较，找到不同版本的文件
             * 生成一个更新文件列表，开始DownloadProgress
             * <UpdateFile>
             *  <File path="" url="" lastver="" size=""></File>
             * </UpdateFile>
             * path为相对于应用程序根目录的相对目录位置，包括文件名
             */

            Dictionary<string, RemoteFile> listRemotFile = ParseRemoteXml(updateInfo);

            List<DownloadFileInfo> downloadList = new List<DownloadFileInfo>();

            //某些文件不再需要了，删除
            List<LocalFile> preDeleteFile = new List<LocalFile>();

            foreach (LocalFile file in config.UpdateFileList)
            {
                if (listRemotFile.ContainsKey(file.Path))
                {
                    RemoteFile rf = listRemotFile[file.Path];
                    if (rf.LastVer != file.LastVer)
                    {
                        downloadList.Add(new DownloadFileInfo(rf.Url, file.Path, rf.LastVer, rf.Size));
                        file.LastVer = rf.LastVer;
                        file.Size = rf.Size;

                        if (rf.NeedRestart)
                            bNeedRestart = true;
                    }

                    listRemotFile.Remove(file.Path);
                }
                else
                {
                    preDeleteFile.Add(file);
                }
            }

            foreach (RemoteFile file in listRemotFile.Values)
            {
                downloadList.Add(new DownloadFileInfo(file.Url, file.Path, file.LastVer, file.Size));
                config.UpdateFileList.Add(new LocalFile(file.Path, file.LastVer, file.Size));

                if (file.NeedRestart)
                    bNeedRestart = true;
            }

            if (downloadList.Count > 0)
            {
                DownloadConfirm dc = new DownloadConfirm(downloadList);
                dc.TopMost = true;
                if (this.OnShow != null)
                    this.OnShow();

                if (DialogResult.OK == dc.ShowDialog())
                {
                    foreach (LocalFile file in preDeleteFile)
                    {
                        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, file.Path);
                        if (File.Exists(filePath))
                            File.Delete(filePath);

                        config.UpdateFileList.Remove(file);
                    }

                    StartDownload(downloadList);
                }
            }
        }

        private void StartDownload(List<DownloadFileInfo> downloadList)
        {
            DownloadProgress dp = new DownloadProgress(downloadList);
            dp.TopMost = true;
            if (dp.ShowDialog() == DialogResult.OK)
            {
                //更新成功
                config.SaveConfig(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FILENAME));

                if (bNeedRestart)
                {
                    //MessageBox.Show("程序需要重新启动才能应用更新，请点击确定重新启动程序。", "自动更新", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show("程序更新成功，请手动打开软件。", "自动更新", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Process.Start(Application.ExecutablePath);
                    Environment.Exit(0);
                }
            }
        }

        private Dictionary<string,RemoteFile> ParseRemoteXml(string xml)
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml(xml);

            Dictionary<string, RemoteFile> list = new Dictionary<string, RemoteFile>();
            foreach (XmlNode node in document.DocumentElement.ChildNodes)
            {
                list.Add(node.Attributes["path"].Value, new RemoteFile(node));
            }

            return list;
        }
        public event ShowHandler OnShow;
    }

    public class RemoteFile
    {
        private string path = "";
        private string url = "";
        private string lastver = "";
        private int size = 0;
        private bool needRestart = false;

        public string Path { get { return path; } }
        public string Url { get { return url; } }
        public string LastVer { get { return lastver; } }
        public int Size { get { return size; } }
        public bool NeedRestart { get { return needRestart; } }

        public RemoteFile(XmlNode node)
        {
            this.path = node.Attributes["path"].Value;
            this.url = node.Attributes["url"].Value;
            this.lastver = node.Attributes["lastver"].Value;
            this.size = Convert.ToInt32(node.Attributes["size"].Value);
            this.needRestart = Convert.ToBoolean(node.Attributes["needRestart"].Value);
        }
    }

    public class LocalFile
    {
        private string path = "";
        private string lastver = "";
        private int size = 0;

        [XmlAttribute("path")]
        public string Path { get { return path; } set { path = value; } }
        [XmlAttribute("lastver")]
        public string LastVer { get { return lastver; } set { lastver = value; } }
        [XmlAttribute("size")]
        public int Size { get { return size; } set { size = value; } }

        public LocalFile(string path, string ver, int size)
        {
            this.path = path;
            this.lastver = ver;
            this.size = size;
        }

        public LocalFile()
        {
        }

    }


    public delegate void ShowHandler();

    public class DownloadFileInfo
    {
        string downloadUrl = "";
        string fileName = "";
        string lastver = "";
        int size = 0;

        /// <summary>
        /// 要从哪里下载文件
        /// </summary>
        public string DownloadUrl { get { return downloadUrl; } }
        /// <summary>
        /// 下载完成后要放到哪里去
        /// </summary>
        public string FileFullName { get { return fileName; } }
        public string FileName { get { return Path.GetFileName(FileFullName); } }
        public string LastVer { get { return lastver; } set { lastver = value; } }
        public int Size { get { return size; } }

        public DownloadFileInfo(string url, string name, string ver, int size)
        {
            this.downloadUrl = url;
            this.fileName = name;
            this.lastver = ver;
            this.size = size;
        }
    }

    /// <summary>
    /// 测试使用
    /// </summary>
    public class Test
    {
        public static void Start()
        {
            AutoUpdater au = new AutoUpdater();
            string strXml = string.Empty;
            try
            {
                WebClient client = new WebClient();
                StreamReader sr = new StreamReader(client.OpenRead(au.config.ServerUrl));
                strXml = sr.ReadToEnd();
                sr.Close();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

            try
            {
                au.Update(strXml);
            }
            catch (WebException exp)
            {
                MessageBox.Show(String.Format("无法找到指定资源\n\n{0}", exp.Message), "自动升级", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (XmlException exp)
            {
                MessageBox.Show(String.Format("下载的升级文件有错误\n\n{0}", exp.Message), "自动升级", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NotSupportedException exp)
            {
                MessageBox.Show(String.Format("升级地址配置错误\n\n{0}", exp.Message), "自动升级", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException exp)
            {
                MessageBox.Show(String.Format("下载的升级文件有错误\n\n{0}", exp.Message), "自动升级", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exp)
            {
                MessageBox.Show(String.Format("升级过程中发生错误\n\n{0}", exp.Message), "自动升级", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    
    }
}
