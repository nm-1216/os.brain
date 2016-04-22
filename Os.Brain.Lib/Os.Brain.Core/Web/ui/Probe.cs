//-----------------------------------------------------------------------
// <copyright file="Probe.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2013/12/21</datetime>
// <discription>探针</discription>
//-----------------------------------------------------------------------

namespace Os.Brain.Web.Ui
{
    using System.Runtime.InteropServices;
    using System.Text;

    public class Probe
    {
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern void GetWindowsDirectory(StringBuilder WinDir, int count);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern void GetSystemDirectory(StringBuilder SysDir, int count);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern void GetSystemInfo(ref CPU_INFO cpuinfo);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern void GlobalMemoryStatus(ref MEMORY_INFO meminfo);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern void GetSystemTime(ref SYSTEMTIME_INFO stinfo);

        [StructLayout(LayoutKind.Sequential)]
        public struct CPU_INFO
        {
            public uint dwOemId;
            /// <summary>
            /// 指定页面的大小和页面保护和委托的颗粒
            /// </summary>
            public uint dwPageSize;
            /// <summary>
            /// 指向应用程序和动态链接库(DLL)可以访问的最低内存地址
            /// </summary>
            public uint lpMinimumApplicationAddress;
            /// <summary>
            /// 指向应用程序和动态链接库(DLL)可以访问的最高内存地址。
            /// </summary>
            public uint lpMaximumApplicationAddress;
            /// <summary>
            /// 指定一个用来代表这个系统中装配了的中央处理器的掩码。二进制0位是处理器0；31位是处理器31。
            /// </summary>
            public uint dwActiveProcessorMask;
            /// <summary>
            /// 指定系统中的处理器的数目。
            /// </summary>
            public uint dwNumberOfProcessors;
            /// <summary>
            /// 指定系统中中央处理器的类型。
            /// </summary>
            public uint dwProcessorType;
            /// <summary>
            /// 指定已经被分配的虚拟内存空间的粒度
            /// </summary>
            public uint dwAllocationGranularity;
            /// <summary>
            /// Windows 95: 不使用这个成员。Windows NT: 指定系统体系结构依赖的处理器级别。
            /// </summary>
            public uint dwProcessorLevel;
            /// <summary>
            /// Windows 95: 不使用这个成员。Windows NT: 指定系统体系结构依赖的处理器修订版本号。下表显示了对于每一种处理器体系，处理器的修订版本号是如何构成的。
            /// </summary>
            public uint dwProcessorRevision;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MEMORY_INFO
        {
            public uint dwLength;
            public uint dwMemoryLoad;
            public uint dwTotalPhys;
            public uint dwAvailPhys;
            public uint dwTotalPageFile;
            public uint dwAvailPageFile;
            public uint dwTotalVirtual;
            public uint dwAvailVirtual;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SYSTEMTIME_INFO
        {
            public ushort wYear;
            public ushort wMonth;
            public ushort wDayOfWeek;
            public ushort wDay;
            public ushort wHour;
            public ushort wMinute;
            public ushort wSecond;
            public ushort wMilliseconds;
        }

        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    string[] strArray;
        //    int minor;

        //    #region 服务器基本信息

        //    #region 服务器计算机名
        //    this._lit = this.Page.FindControl("ServerName") as Literal;
        //    if (this._lit != null)
        //        this._lit.Text = this.Server.MachineName;
        //    #endregion

        //    #region 服务器IP地址
        //    this._lit = this.Page.FindControl("ServerIP") as Literal;
        //    if (this._lit != null)
        //        this._lit.Text = this.Request.ServerVariables["LOCAl_ADDR"];
        //    #endregion

        //    #region 服务器域名
        //    this._lit = this.Page.FindControl("ServerDomain") as Literal;
        //    if (this._lit != null)
        //        this._lit.Text = this.Request.ServerVariables["Server_Name"];
        //    #endregion

        //    #region 服务器端口
        //    this._lit = this.Page.FindControl("ServerPort") as Literal;
        //    if (this._lit != null)
        //        this._lit.Text = this.Request.ServerVariables["Server_Port"];
        //    #endregion

        //    #region 服务器IIS版本
        //    this._lit = this.Page.FindControl("ServerIIS") as Literal;
        //    if (this._lit != null)
        //        this._lit.Text = this.Request.ServerVariables["Server_SoftWare"];
        //    #endregion

        //    #region 执行文件绝对路径
        //    this._lit = this.Page.FindControl("ServerFilePath") as Literal;
        //    if (this._lit != null)
        //        this._lit.Text = this.Request.PhysicalPath;
        //    #endregion

        //    #region 站点虚拟目录绝对路径
        //    this._lit = this.Page.FindControl("ServerPhyAppPath") as Literal;
        //    if (this._lit != null)
        //        this._lit.Text = this.Request.PhysicalApplicationPath;
        //    #endregion

        //    #region 站点虚拟目录名称
        //    this._lit = this.Page.FindControl("ServerAppPath") as Literal;
        //    if (this._lit != null)
        //        this._lit.Text = this.Request.ApplicationPath;
        //    #endregion

        //    #region 服务器操作系统
        //    this._lit = this.Page.FindControl("ServerOS") as Literal;
        //    if (this._lit != null)
        //    {
        //        switch (Environment.OSVersion.Platform)
        //        {
        //            case PlatformID.Win32S:
        //                this._lit.Text = "Win32S";
        //                break;

        //            case PlatformID.Win32Windows:
        //                switch (Environment.OSVersion.Version.Minor)
        //                {
        //                    case 0:
        //                        this._lit.Text = "Microsoft Windows 95";
        //                        break;

        //                    case 10:
        //                        this._lit.Text = (Environment.OSVersion.Version.Revision.ToString() == "2222A") ? "Microsoft Windows 98 Second Edition" : "Windows 98";
        //                        break;

        //                    case 90:
        //                        this._lit.Text = "Microsoft Windows Me";
        //                        break;
        //                }
        //                break;

        //            case PlatformID.Win32NT:
        //                switch (Environment.OSVersion.Version.Major)
        //                {
        //                    case 3:
        //                        this._lit.Text = "Microsoft Windows NT 3.51";
        //                        break;

        //                    case 4:
        //                        this._lit.Text = "Microsoft Windows NT 4.0";
        //                        break;

        //                    case 5:
        //                        switch (Environment.OSVersion.Version.Minor)
        //                        {
        //                            case 0:
        //                                this._lit.Text = "Microsoft Windows 2000";
        //                                break;

        //                            case 1:
        //                                this._lit.Text = "Microsoft Windows XP";
        //                                break;

        //                            case 2:
        //                                this._lit.Text = "Microsoft Windows 2003";
        //                                break;
        //                        }
        //                        break;
        //                }
        //                this._lit.Text = "Microsoft Windows NT";
        //                break;

        //            case PlatformID.WinCE:
        //                this._lit.Text = "Microsoft Windows CE";
        //                break;
        //        }
        //    }

        //    #endregion

        //    #region 服务器操作系统安装目录
        //    this._lit = this.Page.FindControl("ServerRoot") as Literal;
        //    if (this._lit != null)
        //    {
        //        this._lit.Text = Environment.ExpandEnvironmentVariables("%SystemRoot%");
        //    }
        //    #endregion

        //    #region 服务器应用程序安装目录
        //    this._lit = this.Page.FindControl("ServerProgramRoot") as Literal;
        //    if (this._lit != null)
        //        this._lit.Text = Environment.ExpandEnvironmentVariables("%ProgramFiles%");
        //    #endregion

        //    #region .NET Framework语言种类
        //    this._lit = this.Page.FindControl("ServerDotNetLang") as Literal;
        //    if (this._lit != null)
        //        this._lit.Text = CultureInfo.InstalledUICulture.EnglishName;
        //    #endregion

        //    #region .NET Framework 版本
        //    this._lit = this.Page.FindControl("ServerDotNetVer") as Literal;
        //    if (this._lit != null)
        //    {
        //        object[] objArray = new object[] { Environment.Version.Major, ".", Environment.Version.Minor, ".", Environment.Version.Build, ".", Environment.Version.Revision };
        //        this._lit.Text = string.Concat(objArray);
        //    }
        //    #endregion

        //    #region 服务器当前时间
        //    this._lit = this.Page.FindControl("ServerNowDate") as Literal;
        //    if (this._lit != null)
        //        this._lit.Text = DateTime.Now.ToString();
        //    #endregion

        //    #region 服务器上次启动到现在已运行
        //    this._lit = this.Page.FindControl("ServerLastStartToNow") as Literal;
        //    TimeSpan span2 = new TimeSpan(Environment.TickCount * 0x2710L);
        //    if (this._lit != null)
        //    {
        //        strArray = new string[8];
        //        strArray[0] = ((int)span2.TotalDays).ToString();
        //        strArray[1] = " 天 ";
        //        strArray[2] = span2.Hours.ToString();
        //        strArray[3] = " 小时 ";
        //        strArray[4] = span2.Minutes.ToString();
        //        strArray[5] = " 分 ";
        //        strArray[6] = span2.Seconds.ToString();
        //        strArray[7] = " 秒";
        //        this._lit.Text = string.Concat(strArray);
        //    }
        //    #endregion

        //    #endregion

        //    #region 服务器相关硬件信息

        //    #region 计算物理内存
        //    MEMORY_INFO meminfo = new MEMORY_INFO();
        //    GlobalMemoryStatus(ref meminfo);
        //    #endregion

        //    #region 计算CPU信息
        //    CPU_INFO cpuinfo = new CPU_INFO();
        //    GetSystemInfo(ref cpuinfo);
        //    #endregion

        //    #region 物理内存空间
        //    this._lit = this.Page.FindControl("ServerMemSize") as Literal;
        //    if (this._lit != null)
        //        this._lit.Text = ((int)(meminfo.dwTotalPhys / 0x100000)).ToString();
        //    #endregion

        //    #region 可用物理内存空间
        //    this._lit = this.Page.FindControl("ServerMemFreeSize") as Literal;
        //    if (this._lit != null)
        //        this._lit.Text = ((int)(meminfo.dwAvailPhys / 0x100000)).ToString();
        //    #endregion

        //    #region 正使用的内存空间
        //    this._lit = this.Page.FindControl("ServerMemUseSize") as Literal;
        //    if (this._lit != null)
        //        this._lit.Text = meminfo.dwMemoryLoad.ToString();
        //    #endregion

        //    #region 交换文件大小
        //    this._lit = this.Page.FindControl("ServerExFileSize") as Literal;
        //    if (this._lit != null)
        //        this._lit.Text = ((int)(meminfo.dwTotalPageFile / 0x100000)).ToString();
        //    #endregion

        //    #region 交换文件可用大小
        //    this._lit = this.Page.FindControl("ServerExFileFreeSize") as Literal;
        //    if (this._lit != null)
        //        this._lit.Text = ((int)(meminfo.dwAvailPageFile / 0x100000)).ToString();
        //    #endregion

        //    #region 总虚拟内存
        //    this._lit = this.Page.FindControl("ServerExMemSize") as Literal;
        //    if (this._lit != null)
        //        this._lit.Text = ((int)(meminfo.dwTotalVirtual / 0x100000)).ToString();
        //    #endregion

        //    #region 剩余虚拟内存
        //    this._lit = this.Page.FindControl("ServerExMemFreeSize") as Literal;
        //    if (this._lit != null)
        //        this._lit.Text = ((int)(meminfo.dwAvailVirtual / 0x100000)).ToString();
        //    #endregion

        //    #region 逻辑驱动器
        //    this._lit = this.Page.FindControl("ServerLogicalDriver") as Literal;
        //    if (this._lit != null)
        //    {
        //        try
        //        {
        //            this._lit.Text = string.Join("， ", Directory.GetLogicalDrives()).Replace(Path.DirectorySeparatorChar, ' ');
        //        }
        //        catch
        //        {
        //            this._lit.Text = string.Empty;
        //        }
        //    }
        //    #endregion

        //    #region CPU 总数
        //    this._lit = this.Page.FindControl("ServerCpuCount") as Literal;
        //    if (this._lit != null)
        //        this._lit.Text = cpuinfo.dwNumberOfProcessors.ToString();
        //    #endregion

        //    #region CPU 详细信息
        //    if (this.Request.Form["ServerCpuCheck"] == "ShowMore")
        //    {
        //        this._lit = this.Page.FindControl("ServerCpuCheckIt") as Literal;
        //        if (this._lit != null)
        //        {
        //            this._lit.Visible = false;
        //        }
        //        try
        //        {
        //            ManagementObjectCollection instances = new ManagementClass("Win32_Processor").GetInstances();
        //            DataTable table = new DataTable();
        //            DataColumn column = new DataColumn();
        //            column.DataType = Type.GetType("System.Int32");
        //            column.ColumnName = "CpuNum";
        //            column.AutoIncrement = true;
        //            column.AutoIncrementSeed = 1L;
        //            column.AutoIncrementStep = 1L;
        //            table.Columns.Add(column);
        //            column = new DataColumn();
        //            column.DataType = Type.GetType("System.String");
        //            column.ColumnName = "ProcessorID";
        //            table.Columns.Add(column);
        //            column = new DataColumn();
        //            column.DataType = Type.GetType("System.String");
        //            column.ColumnName = "Description";
        //            table.Columns.Add(column);
        //            column = new DataColumn();
        //            column.DataType = Type.GetType("System.String");
        //            column.ColumnName = "CurrentClockSpeed";
        //            table.Columns.Add(column);
        //            column = new DataColumn();
        //            column.DataType = Type.GetType("System.String");
        //            column.ColumnName = "MaxClockSpeed";
        //            table.Columns.Add(column);
        //            column = new DataColumn();
        //            column.DataType = Type.GetType("System.String");
        //            column.ColumnName = "L2CacheSize";
        //            table.Columns.Add(column);
        //            column = new DataColumn();
        //            column.DataType = Type.GetType("System.String");
        //            column.ColumnName = "L2CacheSpeed";
        //            table.Columns.Add(column);
        //            foreach (ManagementObject obj2 in instances)
        //            {
        //                DataRow row = table.NewRow();
        //                row["ProcessorID"] = obj2["ProcessorID"];
        //                row["Description"] = obj2["Description"];
        //                row["CurrentClockSpeed"] = obj2["CurrentClockSpeed"];
        //                row["MaxClockSpeed"] = obj2["MaxClockSpeed"];
        //                row["L2CacheSize"] = obj2["L2CacheSize"];
        //                row["L2CacheSpeed"] = obj2["L2CacheSpeed"];
        //                table.Rows.Add(row);
        //            }
        //            Repeater repeater = this.Page.FindControl("ServerCpuInfo") as Repeater;
        //            if (repeater != null)
        //            {
        //                repeater.DataSource = table;
        //                repeater.DataBind();
        //            }
        //        }
        //        catch
        //        {
        //        }
        //    }
        //    #endregion

        //    #endregion

        //    #region 服务器COM组件安装检测

        //    #region 数据库访问组件(Adodb.Recordset)
        //    this._lit = this.Page.FindControl("ServerComAdodb") as Literal;
        //    if (this._lit != null)
        //        this._lit.Text = this.ServerComCheck("AdoDb.Recordset") ? "已安装" : "未安装";
        //    #endregion

        //    #region JRO数据库压缩组件(JRO.JetEngine)
        //    this._lit = this.Page.FindControl("ServerComJro") as Literal;
        //    if (this._lit != null)
        //        this._lit.Text = this.ServerComCheck("JRO.JetEngine") ? "已安装" : "未安装";
        //    #endregion

        //    #region FSO文件操作组件(Scripting.FileSystemObject)
        //    this._lit = this.Page.FindControl("ServerComFso") as Literal;
        //    if (this._lit != null)
        //        this._lit.Text = this.ServerComCheck("Scripting.FileSystemObject") ? "已安装" : "未安装";
        //    #endregion

        //    #region CDONTS邮件发送组件(CDONTS.NewMail)
        //    this._lit = this.Page.FindControl("ServerComCdonts") as Literal;
        //    if (this._lit != null)
        //        this._lit.Text = this.ServerComCheck("CDONTS.NewMail") ? "已安装" : "未安装";
        //    #endregion

        //    #region JMail邮件组件(Jmail.Message)
        //    this._lit = this.Page.FindControl("ServerComJMail") as Literal;
        //    if (this._lit != null)
        //        this._lit.Text = this.ServerComCheck("Jmail.Message") ? "已安装" : "未安装";
        //    #endregion

        //    #region Persits文件上传组件(Persits.Upload.1)
        //    this._lit = this.Page.FindControl("ServerComPersitsUp") as Literal;
        //    if (this._lit != null)
        //        this._lit.Text = this.ServerComCheck("Persits.Upload.1") ? "已安装" : "未安装";
        //    #endregion

        //    #region SoftArtisans文件上传组件(SoftArtisans.FileUp)
        //    this._lit = this.Page.FindControl("ServerComSAUp") as Literal;
        //    if (this._lit != null)
        //        this._lit.Text = this.ServerComCheck("SoftArtisans.FileUp") ? "已安装" : "未安装";
        //    #endregion

        //    #region Dundas文件上传组件(Dundas.Upload)
        //    this._lit = this.Page.FindControl("ServerComDundasUp") as Literal;
        //    if (this._lit != null)
        //        this._lit.Text = this.ServerComCheck("Dundas.Upload") ? "已安装" : "未安装";
        //    #endregion

        //    #endregion

        //    this.pageStartTime = DateTime.Now.TimeOfDay;
        //    this.sProgID = this.Request.Form["ComProgID"];
        //    if ((this.sProgID != null) && (this.sProgID != string.Empty))
        //    {
        //        this._lit = this.Page.FindControl("ServerComCheckRslt") as Literal;
        //        if (this._lit != null)
        //        {
        //            this._lit.Visible = true;
        //            this._lit.Text = this.ServerComCheck(this.sProgID) ? "恭喜，服务器已安装该组件！" : "很遗憾，服务器上未安装该组件！";
        //        }
        //    }
        //    this.sCheckUrl = this.Request.Form["ServerNetWorkCheck"];
        //    if ((this.sCheckUrl != null) && (this.sCheckUrl != string.Empty))
        //    {
        //        this._lit = this.Page.FindControl("ServerNetWorkCheck") as Literal;
        //        if (this._lit != null)
        //        {
        //            TimeSpan timeOfDay = DateTime.Now.TimeOfDay;
        //            int httpData = this.GetHttpData(this.sCheckUrl);
        //            this._lit.Visible = true;
        //            if (httpData > 0)
        //            {
        //                strArray = new string[5];
        //                strArray[0] = "网页大小：";
        //                minor = httpData / 0x3e8;
        //                strArray[1] = minor.ToString();
        //                strArray[2] = " KB，平均网速：";
        //                strArray[3] = Math.Round((double)(((double)httpData) / DateTime.Now.TimeOfDay.Subtract(timeOfDay).TotalMilliseconds)).ToString();
        //                strArray[4] = " KB/秒";
        //                this._lit.Text = string.Concat(strArray);
        //            }
        //            else
        //            {
        //                this._lit.Text = "输入的网址不正确或者抓取数据超时！";
        //            }
        //        }
        //    }
        //    int iCount = CInt32(this.Request.Form["IntCalCheck"], 0) * 0x2710;
        //    if (iCount > 0)
        //    {
        //        this._lit = this.Page.FindControl("ServerIntCalCheck") as Literal;
        //        if (this._lit != null)
        //        {
        //            this._lit.Visible = true;
        //            this._lit.Text = this.ServerIntCheck(iCount).ToString() + " 毫秒";
        //        }
        //    }
        //    iCount = CInt32(this.Request.Form["DblCalCheck"], 0) * 0x2710;
        //    if (iCount > 0)
        //    {
        //        this._lit = this.Page.FindControl("ServerDblCalCheck") as Literal;
        //        if (this._lit != null)
        //        {
        //            this._lit.Visible = true;
        //            this._lit.Text = this.ServerDblCheck(iCount).ToString() + " 毫秒";
        //        }
        //    }
        //    this.pageProcessTime = DateTime.Now.TimeOfDay.Subtract(this.pageStartTime).TotalMilliseconds;
        //}
    }
}
