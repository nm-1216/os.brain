//-----------------------------------------------------------------------
// <copyright file="TextBox.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2013/12/21</datetime>
// <discription>Asp.Net 文本框控件</discription>
//-----------------------------------------------------------------------

namespace Os.Brain.UserControl
{
    using System;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    /// <summary>
    /// 文本框 基类
    /// </summary>
    public class TextBox : Control, IPostBackDataHandler
    {
        /// <summary>
        /// 控件 文本
        /// </summary>
        private string text = string.Empty;

        /// <summary>
        /// 事件 在更改文本属性后激发
        /// </summary>
        [Description("在更改文本属性后激发。")]
        public event EventHandler TextChanged;

        /// <summary>
        /// Gets or sets 属性 控件的宽度
        /// </summary>
        [Description("控件的宽度。")]
        [Category("Layout")]
        public virtual Unit Width { get; set; }

        /// <summary>
        /// Gets or sets 属性 控件的高度
        /// </summary>
        [Description("控件的高度。")]
        [Category("Layout")]
        public virtual Unit Height { get; set; }

        /// <summary>
        /// Gets or sets 属性 应用于该控件的 CSS 类名
        /// </summary>
        [Description("应用于该控件的 CSS 类名。")]
        [Category("Appearance")]
        public virtual string CssClass { get; set; }

        /// <summary>
        /// Gets or sets 属性 文本值
        /// </summary>
        [Bindable(true)]
        [Description("文本值。")]
        [Category("Appearance")]
        public virtual string Text
        {
            get { return this.text; }
            set { this.text = value; }
        }

        /// <summary>
        /// Gets or sets 属性 可输入的最大字符数
        /// </summary>
        [Description("可输入的最大字符数。")]
        [Category("Behavior")]
        public virtual int MaxLength { get; set; }

        /// <summary>
        /// LoadPostData 加载事件回发
        /// </summary>
        /// <param name="postDataKey">postDataKey 建</param>
        /// <param name="postCollection">postCollection 序列</param>
        /// <returns>返回 是否成功</returns>
        public virtual bool LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            string presentValue = this.Text;
            string postedValue = postCollection[postDataKey];

            if (presentValue == null || !presentValue.Equals(postedValue))
            {
                this.Text = postedValue;
                return true;
            }

            return false;
        }

        /// <summary>
        /// 事件 RaisePostDataChangedEvent
        /// </summary>
        public virtual void RaisePostDataChangedEvent()
        {
            this.OnTextChanged(EventArgs.Empty);
        }

        /// <summary>
        /// 事件 文本修改事件
        /// </summary>
        /// <param name="e">事件 参数</param>
        protected virtual void OnTextChanged(EventArgs e)
        {
            if (this.TextChanged != null)
            {
                this.TextChanged(this, e);
            }
        }

        /// <summary>
        /// 呈现 用户控件
        /// </summary>
        /// <param name="output">output 输出流</param>
        protected override void Render(HtmlTextWriter output)
        {
            ////添加ID属性
            output.AddAttribute(HtmlTextWriterAttribute.Id, this.UniqueID);
            ////添加Name属性
            output.AddAttribute(HtmlTextWriterAttribute.Name, this.UniqueID);
            ////添加Type属性
            output.AddAttribute(HtmlTextWriterAttribute.Type, "text");
            ////添加Value属性
            if (!string.IsNullOrEmpty(this.Text))
            {
                output.AddAttribute(HtmlTextWriterAttribute.Value, this.Text);
            }
            ////添加MaxLength属性
            if (this.MaxLength > 0)
            {
                output.AddAttribute(HtmlTextWriterAttribute.Maxlength, this.MaxLength.ToString());
            }
            ////添加Class属性
            if (!string.IsNullOrEmpty(this.CssClass))
            {
                output.AddAttribute(HtmlTextWriterAttribute.Class, this.CssClass);
            }

            ////添加Style属性 子项Width
            if (!this.Width.IsEmpty)
            {
                output.AddStyleAttribute(HtmlTextWriterStyle.Width, this.Width.Value.ToString() + "px");
            }
            ////添加Style属性 子项Height
            if (!this.Height.IsEmpty)
            {
                output.AddStyleAttribute(HtmlTextWriterStyle.Height, this.Height.Value.ToString() + "px");
            }

            ////添加HTML标签
            output.RenderBeginTag(HtmlTextWriterTag.Input);
            output.RenderEndTag();
        }
    }
}
