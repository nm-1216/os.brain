//-----------------------------------------------------------------------
// <copyright file="AuthCode.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2013/12/21</datetime>
// <discription>Asp.Net 验证码控件</discription>
//-----------------------------------------------------------------------

namespace Os.Brain.UserControl
{
    using System;
    using System.Collections;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Web;
    using System.Web.UI;

    /// <summary>
    /// 验证码 控件
    /// </summary>
    public class AuthCode : Control
    {
        /// <summary>
        /// Gets or sets 属性 应用于该控件的 CSS 类名
        /// </summary>
        [Description("应用于该控件的 CSS 类名。")]
        [Category("Appearance")]
        public virtual string CssClass { get; set; }

        /// <summary>
        /// Gets the value of the customer. 
        /// </summary>
        public string value
        {
            get { return HttpContext.Current.Session[this.SessionName].ToString(); }
        }

        /// <summary>
        /// Gets or sets 属性 应用于该控件的保存 Session 的名称
        /// </summary>
        [Description("应用于该控件的保存 Session 的名称。")]
        [Category("Appearance")]
        public virtual string SessionName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the item is IsEncrypt.属性 是否启用MD5加密 Session。
        /// </summary>
        [Description("是否启用MD5加密 Session。")]
        [Category("Appearance")]
        public virtual bool IsEncrypt { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the item is IsIgnoreCase.属性 是否出分大小写
        /// </summary>
        [Description("是否出分大小写 True 出分，fale 不出分")]
        [Category("Appearance")]
        public virtual bool IsIgnoreCase { get; set; }

        /// <summary>
        /// Gets or sets 属性 验证码字符集长度
        /// </summary>
        [Description("验证码字符集长度")]
        [Category("Appearance")]
        public virtual int Length { get; set; }

        /// <summary>
        /// 呈现 控件
        /// </summary>
        /// <param name="output">output 输出流</param>
        protected override void Render(HtmlTextWriter output)
        {
            ////添加ID属性
            output.AddAttribute(HtmlTextWriterAttribute.Id, this.UniqueID);
            ////添加Name属性
            output.AddAttribute(HtmlTextWriterAttribute.Name, this.UniqueID);
            ////添加Type属性
            ////output.AddAttribute(HtmlTextWriterAttribute.Type, "img");

            //////添加Value属性
            ////if (!string.IsNullOrEmpty(this.Text))
            ////    output.AddAttribute(HtmlTextWriterAttribute.Value, this.Text);
            //////添加MaxLength属性
            ////if (this.MaxLength > 0)
            ////    output.AddAttribute(HtmlTextWriterAttribute.Maxlength, this.MaxLength.ToString());
            ////添加Class属性
            if (!string.IsNullOrEmpty(this.CssClass))
            {
                output.AddAttribute(HtmlTextWriterAttribute.Class, this.CssClass);
            }

            output.AddAttribute("onclick", "this.src='vcode.hwx?random='+Math.random()");
            output.AddAttribute("alt", "点击刷新");

            output.RenderBeginTag(HtmlTextWriterTag.Img);
            output.RenderEndTag();
        }
    }
}
