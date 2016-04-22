namespace Os.Brain.Utility
{
    partial class DownloadProgress
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelCurrentItem = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.imgFile = new System.Windows.Forms.PictureBox();
            this.imtTotal = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.imgFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imtTotal)).BeginInit();
            this.SuspendLayout();
            // 
            // labelCurrentItem
            // 
            this.labelCurrentItem.AutoSize = true;
            this.labelCurrentItem.Location = new System.Drawing.Point(84, 13);
            this.labelCurrentItem.Name = "labelCurrentItem";
            this.labelCurrentItem.Size = new System.Drawing.Size(0, 12);
            this.labelCurrentItem.TabIndex = 0;
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(337, 94);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "取消";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.OnCancel);
            // 
            // imgFile
            // 
            this.imgFile.Location = new System.Drawing.Point(12, 13);
            this.imgFile.Name = "imgFile";
            this.imgFile.Size = new System.Drawing.Size(400, 24);
            this.imgFile.TabIndex = 3;
            this.imgFile.TabStop = false;
            // 
            // imtTotal
            // 
            this.imtTotal.Location = new System.Drawing.Point(12, 54);
            this.imtTotal.Name = "imtTotal";
            this.imtTotal.Size = new System.Drawing.Size(400, 24);
            this.imtTotal.TabIndex = 4;
            this.imtTotal.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // DownloadProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 132);
            this.ControlBox = false;
            this.Controls.Add(this.imtTotal);
            this.Controls.Add(this.imgFile);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.labelCurrentItem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DownloadProgress";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "下载进度";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.Load += new System.EventHandler(this.OnFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this.imgFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imtTotal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCurrentItem;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.PictureBox imgFile;
        private System.Windows.Forms.PictureBox imtTotal;
        private System.Windows.Forms.Timer timer1;
    }
}