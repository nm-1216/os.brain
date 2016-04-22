//-----------------------------------------------------------------------
// <copyright file="MsgBox.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2013/12/21</datetime>
// <discription>MsgBox 脚本弹框</discription>
//-----------------------------------------------------------------------

namespace Os.Brain.Web
{
    using System.Text.RegularExpressions;
    using System.Web.UI;

    /// <summary>
    /// MsgBox 脚本弹框
    /// </summary>
    public class MsgBox
    {
        /// <summary>
        /// 打印 提示信息
        /// </summary>
        /// <param name="page">目标 页面</param>
        /// <param name="msg">待 显示信息</param>
        public static void Alert(Page page, string msg)
        {
            Alert(page, msg, string.Empty);
        }

        /// <summary>
        /// 打印 提示信息
        /// </summary>
        /// <param name="page">目标 页面</param>
        /// <param name="msg">待 显示信息</param>
        /// <param name="defer">显示时间 页面加载后</param>
        public static void Alert(Page page, string msg, string defer)
        {
            page.ClientScript.RegisterClientScriptBlock(page.GetType(), "msg", "<script type=\"text/javascript\" " + defer + ">alert('" + MsgStr(msg) + "')</script>", false);
        }

        /// <summary>
        /// 函数 提示信息并跳转
        /// </summary>
        /// <param name="page">参数 页面指针对象</param>
        /// <param name="msg">参数 提示内容</param>
        /// <param name="url">参数 跳转页面</param>
        public static void AlertAndRedirect(Page page, string msg, string url)
        {
            AlertAndRedirect(page, msg, url, string.Empty);
        }

        /// <summary>
        /// 函数 提示信息并跳转
        /// </summary>
        /// <param name="page">参数 页面指针对象</param>
        /// <param name="msg">参数 提示内容</param>
        /// <param name="url">参数 跳转页面</param>
        /// <param name="defer">参数 脚本响应时段</param>
        public static void AlertAndRedirect(Page page, string msg, string url, string defer)
        {
            AlertAndRedirect(page, msg, url, "top", defer);
        }

        /// <summary>
        /// 函数 提示信息并跳转
        /// </summary>
        /// <param name="page">参数 页面指针对象</param>
        /// <param name="msg">参数 提示内容</param>
        /// <param name="url">参数 跳转页面</param>
        /// <param name="target">参数 页面</param>
        /// <param name="defer">参数 脚本响应时段</param>
        public static void AlertAndRedirect(Page page, string msg, string url, string target, string defer)
        {
            page.ClientScript.RegisterClientScriptBlock(page.GetType(), "msg", "<script type=\"text/javascript\" " + defer + ">alert('" + MsgStr(msg) + "');" + target + ".location.href=\"" + url + "\"</script>", false);
        }

        /// <summary>
        /// MsgStr 格式转换     
        /// </summary>
        /// <param name="str">str 待转换字符串</param>
        /// <returns>返回 转换结构</returns>
        private static string MsgStr(string str)
        {
            return Regex.Replace(Regex.Replace(str, "'", "\\'"), "\"", "\\\"");
        }
    }
}
