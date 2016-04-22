//-----------------------------------------------------------------------
// <copyright file="NumberBox.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2013/12/21</datetime>
// <discription>Asp.Net 数字文本框控件</discription>
//-----------------------------------------------------------------------

namespace Os.Brain.UserControl
{
    using System;
    using System.Collections.Specialized;
    using System.Text;
    using System.Web.UI;

    /// <summary>
    /// 数字文本框 控件
    /// </summary>
    [ToolboxData("<{0}:NumberBox runat=server />")]
    public class NumberBox : TextBox
    {
        #region Public Property
        /// <summary>
        /// integer only 只能是整数
        /// </summary>
        private bool integeronly = false;

        /// <summary>
        /// Gets or sets a value indicating whether the item is IntegerOnly.
        /// </summary>
        public bool IntegerOnly
        {
            get { return this.integeronly; }
            set { this.integeronly = value; }
        }
        #endregion

        #region Public Override
        /// <summary>
        /// 控件 呈现
        /// </summary>
        /// <param name="writer">writer 输出流</param>
        public override void RenderControl(HtmlTextWriter writer)
        {
            ////添加属性onkeydown
            writer.AddAttribute("onkeydown", "return Key.InNum(event," + this.IntegerOnly.ToString().ToLower() + ")");
            ////呈现继承自TextBox的基控件
            base.RenderControl(writer);
        }
        #endregion
    }
}
