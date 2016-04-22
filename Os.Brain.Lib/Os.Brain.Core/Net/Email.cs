//-----------------------------------------------------------------------
// <copyright file="Email.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2012/02/25</datetime>
// <discription>STMP(Simple Mail Transfer Protocol)</discription>
//-----------------------------------------------------------------------

namespace Os.Brain.Net
{
    using System;
    using System.ComponentModel;
    using System.Configuration;
    using System.IO;
    using System.Net;
    using System.Net.Mail;
    using System.Web;
    using System.Xml;

    /// <summary>
    /// Email 无用类
    /// </summary>
    public class Email
    { 
    }

    #region MailSender
    /// <summary>
    /// 邮件发送 提供程序
    /// </summary>
    public class MailSender
    {
        /// <summary>
        /// smtp 客户端
        /// </summary>
        private SmtpClient _sc = null;

        /// <summary>
        /// 发送程序 发送者
        /// </summary>
        private string _from = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="MailSender"/> class.
        /// </summary>
        public MailSender()
        {
            this._sc = new SmtpClient(SmtpConfig.Smtp, SmtpConfig.Port);
            this._sc.EnableSsl = SmtpConfig.EnableSsl;
            this._sc.Credentials = new NetworkCredential(SmtpConfig.Username, SmtpConfig.Password);
            this._sc.SendCompleted += new SendCompletedEventHandler(this.SendMailCompleted);
            this._from = SmtpConfig.Username;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MailSender"/> class.
        /// </summary>
        /// <param name="mailUser">账号 用户</param>
        /// <param name="mailPwd">账号 密码</param>
        public MailSender(string mailUser, string mailPwd)
        {
            this._sc = new SmtpClient();
            string _smtp = mailUser.Substring(mailUser.IndexOf("@") + 1).ToLower();
            if (_smtp == "gmail.com")
            {
                ////Gmail 使用 465 和 587 端口
                this._sc.Port = 587;
                this._sc.EnableSsl = true;
            }
            else
            {
                this._sc.Port = 25;
                this._sc.EnableSsl = false;
            }

            this._sc.Credentials = new NetworkCredential(mailUser, mailPwd);
            this._sc.Host = "smtp." + _smtp;
            this._sc.SendCompleted += new SendCompletedEventHandler(this.SendMailCompleted);
            this._from = mailUser;
        }

        #region Sender

        /// <summary>
        /// 异步发送 邮件
        /// </summary>
        /// <param name="mmsg">邮件 体</param>
        public void SendAsync(MailMessage mmsg)
        {
            try
            {
                if (mmsg.From == null)
                {
                    mmsg.From = new MailAddress(this._from);
                }

                this._sc.SendAsync(mmsg, mmsg);
            }
            catch (SmtpException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 发送 邮件
        /// </summary>
        /// <param name="mmsg">邮件 体</param>
        public void Send(MailMessage mmsg)
        {
            try
            {
                if (mmsg.From == null)
                {
                    mmsg.From = new MailAddress(this._from);
                }

                this._sc.Send(mmsg);
            }
            catch (SmtpException ex)
            {
                throw ex;
            }
        }

        #endregion

        #region SendMailCompleted
        /// <summary>
        /// Send Mail Completed
        /// </summary>
        /// <param name="sender">sender 发送对象</param>
        /// <param name="e">Event Args</param>
        protected void SendMailCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (!Directory.Exists(System.Web.HttpContext.Current.Server.MapPath("~/ErrorLog/")))
            {
                Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath("~/ErrorLog/"));
            }

            FileInfo myfile = new FileInfo(System.Web.HttpContext.Current.Server.MapPath("~/ErrorLog/Smtp.txt"));
            string _to = string.Empty;
            MailMessage mailMsg = (MailMessage)e.UserState;
            for (int i = 0; i < mailMsg.To.Count; i++)
            {
                _to += mailMsg.To[i].Address;
            }

            string date = DateTime.Now.ToString("yyyy-MM-dd");
            if (e.Cancelled)
            {
            }

            if (e.Error != null)
            {
                if (!myfile.Exists)
                {
                    using (StreamWriter sw = myfile.CreateText()) 
                    {
                        sw.WriteLine(date + "\t" + mailMsg.From + " 发给： " + _to + "\t" + mailMsg.Subject + "\t" + "发送失败,错误：" + e.Error.ToString()); 
                    }
                }
                else
                {
                    using (StreamWriter sw = myfile.AppendText()) 
                    {
                        sw.WriteLine("\r\n" + date + "\t" + mailMsg.From + " 发给： " + _to + "\t" + mailMsg.Subject + "\t" + "发送失败,错误：" + e.Error.ToString()); 
                    }
                }
            }
            else
            {
            }
        }

        #endregion
    }
    #endregion

    #region smtp

    /// <summary>
    /// 简单 邮件传输协议
    /// </summary>
    internal class SmtpConfig
    {
        #region 私有成员
        /// <summary>
        /// 账号 密码
        /// </summary>
        private static string _password;

        /// <summary>
        /// smtp 服务器地址
        /// </summary>
        private static string _smtp;

        /// <summary>
        /// 账号 用户
        /// </summary>
        private static string _username;

        /// <summary>
        /// smtp 服务器端口
        /// </summary>
        private static int _port;

        /// <summary>
        /// 是否 加密
        /// </summary>
        private static bool _enablessl;
        #endregion

        #region 方法

        /// <summary>
        /// Initializes static members of the SmtpConfig class.
        /// </summary>
        static SmtpConfig()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(ConfigFile);
            _smtp = doc.DocumentElement.SelectSingleNode("Smtp").InnerText;
            _port = Convert.ToInt32(doc.DocumentElement.SelectSingleNode("Port").InnerText);
            _username = doc.DocumentElement.SelectSingleNode("Username").InnerText;
            _password = doc.DocumentElement.SelectSingleNode("Password").InnerText;
            _enablessl = Convert.ToBoolean(doc.DocumentElement.SelectSingleNode("EnableSsl").InnerText);
        }

        #endregion

        #region 属性

        /// <summary>
        /// Gets Smtp 服务器
        /// </summary>
        public static string Smtp
        {
            get { return _smtp; }
        }

        /// <summary>
        /// Gets 用户名
        /// </summary>
        public static string Username
        {
            get { return _username; }
        }

        /// <summary>
        /// Gets 用户密码
        /// </summary>
        public static string Password
        {
            get { return _password; }
        }

        /// <summary>
        /// Gets 服务器端口
        /// </summary>
        public static int Port
        {
            get { return _port; }
        }

        /// <summary>
        /// Gets a value indicating whether the item is EnableSsl.数据 加密
        /// </summary>
        public static bool EnableSsl
        {
            get { return _enablessl; }
        }

        /// <summary>
        /// Gets ConfigFile 获取配置文件
        /// </summary>
        private static string ConfigFile
        {
            get
            {
                string configPath = ConfigurationManager.AppSettings["SmtpConfigPath"];
                if (string.IsNullOrEmpty(configPath))
                {
                    configPath = Os.Brain.Common.Utils.MapPath("~/Config/SmtpConfig.config");
                }
                else
                {
                    if (!Path.IsPathRooted(configPath))
                    {
                        configPath = Os.Brain.Common.Utils.MapPath(Path.Combine(configPath, "SmtpConfig.config"));
                    }
                    else
                    {
                        configPath = Path.Combine(configPath, "SmtpConfig.config");
                    }
                }

                return configPath;
            }
        }

        #endregion
    }
    #endregion
}
