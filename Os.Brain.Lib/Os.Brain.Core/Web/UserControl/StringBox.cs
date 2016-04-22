//-----------------------------------------------------------------------
// <copyright file="StringBox.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2013/12/21</datetime>
// <discription>Asp.Net 字符串文本框控件</discription>
//-----------------------------------------------------------------------
namespace Os.Brain.UserControl
{
    using System;
    using System.Collections.Specialized;
    using System.Text;
    using System.Web.UI;

    /// <summary>
    /// 字符串文本框 控件
    /// </summary>
    [ToolboxData("<{0}:StringBox runat=server />")]
    public class StringBox : TextBox
    {
        #region Public Override
        /// <summary>
        /// 控件 呈现
        /// </summary>
        /// <param name="writer">writer 输出流</param>
        public override void RenderControl(HtmlTextWriter writer)
        {
            ////添加属性onkeydown
            writer.AddAttribute("onkeydown", "return Key.InStr(event)");
            ////呈现继承自TextBox的基控件
            base.RenderControl(writer);
        }
        #endregion
    }
}
