//-----------------------------------------------------------------------
// <copyright file="Calendar.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2013/12/21</datetime>
// <discription>Asp.Net 日历控件</discription>
//-----------------------------------------------------------------------

namespace Os.Brain.UserControl
{
    using System;
    using System.Collections.Specialized;
    using System.Text;
    using System.Web.UI;

    /// <summary>
    /// 日历 控件
    /// </summary>
    [ToolboxData("<{0}:Calendar runat=server />")]
    public class Calendar : TextBox
    {
        #region Public Property
        /// <summary>
        /// Gets or sets a value indicating whether the item is ReadOnly.标志位 设置日历控件是否是只读
        /// </summary>
        public virtual bool ReadOnly
        {
            get;
            set;
        }
        #endregion

        #region Public override

        /// <summary>
        /// 呈现 控件
        /// </summary>
        /// <param name="writer">writer 输出流</param>
        public override void RenderControl(HtmlTextWriter writer)
        {
            ////赋值属性MaxLeng
            this.MaxLength = 10;

            ////添加ReadOnly属性
            if (this.ReadOnly)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.ReadOnly, this.ReadOnly.ToString());
            }

            ////添加Style属性 子项Cursor
            writer.AddStyleAttribute(HtmlTextWriterStyle.Cursor, "pointer");

            ////添加Onclick属性
            writer.AddAttribute(HtmlTextWriterAttribute.Onclick, "calendar.setHook(this)");

            ////呈现继承自TextBox的基控件
            base.RenderControl(writer);
        }

        #endregion
    }
}
