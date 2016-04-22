//-----------------------------------------------------------------------
// <copyright file="IPFilterModule.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2012/02/25</datetime>
// <discription>授权管理</discription>
//-----------------------------------------------------------------------


namespace Os.Brain.HttpModules
{
    using System;
    using System.Web;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO.Compression;
    using System.Text;
    using System.Web.Security;
    using System.Management;
    using Os.Brain.Common;


    public class LicenseModule : IHttpModule
    {

        #region 处理器

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="app"></param>
        public void Init(HttpApplication app)
        {
            // 安全模块
            app.AcquireRequestState += new EventHandler(app_AuthMethod);
        }

        /// <summary>
        /// 设置方法属性权限检测数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void app_AuthMethod(object sender, EventArgs e)
        {
            //判断是否在manager目录里,并且文件名为aspx
            if (GetScriptNameExt.ToLower() == "aspx")
            {
                Common common = new Common();
                if (!common.check(string.Empty))
                {
                    throw new ArgumentNullException("未知异常，请联系管理员");
                }
            }
        }

        #endregion

        /// <summary>
        /// 释放
        /// </summary>
        public void Dispose()
        {

        }

        private string GetScriptName
        {
            get
            {
                return HttpContext.Current.Request.ServerVariables["SCRIPT_NAME"].ToString();
            }
        }

        private string GetScriptNameExt
        {
            get
            {
                return GetScriptName.Substring(GetScriptName.LastIndexOf(".") + 1);
            }
        }

        public class Common
        {
            private string GetSerialNumber()
            {
                string temp = string.Empty;
                //ManagementClass mc = new ManagementClass("Win32_PhysicalMedia");

                ManagementClass mc = new ManagementClass("Win32_DiskDrive");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    temp += mo.Properties["SerialNumber"].Value.ToString();
                }

                mc = null;
                moc = null;

                return temp.Trim();
            }

            private string GetEncodeValue(string date)
            {
                return Encrypts.MD5.Encode(GetSerialNumber(), Digit.L16) + Encrypts.AES.Encrypt(date);
            }

            public bool check(string date)
            {

                try
                {
                    date = System.Configuration.ConfigurationManager.AppSettings["Statistics"].ToString();

                    string item1 = date.Substring(0, 16);
                    string item2 = date.Substring(16);

                    if (Encrypts.MD5.Encode(GetSerialNumber(), Digit.L16) != item1)
                    {
                        return false;
                    }

                    if (DateTime.Compare(DateTime.Parse(Encrypts.AES.Decrypt(item2)), DateTime.Now) < 0)
                    {
                        return false;
                    }

                    return true;
                }
                catch
                {
                    return false;
                }
            }

        }
    }


}
