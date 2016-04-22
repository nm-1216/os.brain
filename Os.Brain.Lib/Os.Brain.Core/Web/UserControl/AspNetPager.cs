//-----------------------------------------------------------------------
// <copyright file="AspNetPager.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2013/12/21</datetime>
// <discription>Asp.Net 分页控件</discription>
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
    /// Asp.Net 分页控件
    /// </summary>
    public class AspNetPager : Control, IPostBackDataHandler, IPostBackEventHandler, INamingContainer
    {
        #region Fields

        #region Private Fields
        /// <summary>
        /// 跳转文本 框
        /// </summary>
        private TextBox txtInput;

        #endregion

        #region Public Fields

        #endregion

        #endregion

        /// <summary>
        /// Initializes a new instance of the AspNetPager class.
        /// </summary>
        public AspNetPager()
        {
            this.txtInput = new TextBox();

            if (HttpContext.Current != null)
            {
                string str = HttpContext.Current.Request.QueryString["page"];
                if (!string.IsNullOrEmpty(str))
                {
                    this.CurrPage = Convert.ToInt32(str);
                }
            }
        }

        /// <summary>
        /// 分页 事件
        /// </summary>
        public event EventHandler PageIndexChange;

        /// <summary>
        /// custom 自定义
        /// </summary>
        public enum custom : int
        {
            /// <summary>
            /// 不定义 0
            /// </summary>
            Never = 0,

            /// <summary>
            /// 左边 1
            /// </summary>
            Left = 1,

            /// <summary>
            /// 右边 2
            /// </summary>
            Right = 2
        }

        #region Properties

        #region Public Properties

        /// <summary>
        /// Gets or sets the TemplateUrl of the customer 分页模板Url 主要用在伪静态
        /// </summary>
        public string TemplateUrl
        {
            get { return this.ViewState["TemplateUrl"] == null ? string.Empty : (string)this.ViewState["TemplateUrl"]; }
            set { this.ViewState["TemplateUrl"] = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the item is IsPostModel.数据回传方式，是否是POST模式
        /// </summary>
        public bool IsPostModel
        {
            get { return this.ViewState["IsPostModel"] == null ? false : (bool)this.ViewState["IsPostModel"]; }
            set { this.ViewState["IsPostModel"] = value; }
        }

        /// <summary>
        /// Gets or sets the CurrPage of the customer. 
        /// </summary>
        public int CurrPage
        {
            get
            {
                object obj = this.ViewState["CurrPage"];
                return obj == null ? 1 : (int)obj;
            }

            set
            {
                this.ViewState["CurrPage"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the PageSize of the customer. 
        /// </summary>
        public int PageSize
        {
            get
            {
                object obj = this.ViewState["PageSize"];
                return obj == null ? 20 : (int)obj;
            }

            set
            {
                this.ViewState["PageSize"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the RecordCount of the customer. 
        /// </summary>
        public int RecordCount
        {
            get
            {
                object obj = this.ViewState["RecordCount"];
                return obj == null ? 0 : (int)obj;
            }

            set
            {
                this.ViewState["RecordCount"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the MoveStep of the customer. Move Step
        /// </summary>
        public int MoveStep
        {
            get
            {
                object obj = this.ViewState["MoveStep"];
                return obj == null ? 10 : (int)obj;
            }

            set
            {
                this.ViewState["MoveStep"] = value;
            }
        }

        #endregion

        #region Private Properties
        /// <summary>
        /// Gets the PageCount of the customer. 
        /// </summary>
        private int PageCount
        {
            get
            {
                int num = this.RecordCount / this.PageSize;
                return this.RecordCount % this.PageSize == 0 ? num : num + 1;
            }
        }

        /// <summary>
        /// Gets the Pre of the customer. 
        /// </summary>
        private int Pre
        {
            get
            {
                return this.CurrPage <= 1 ? 1 : this.CurrPage - 1;
            }
        }

        /// <summary>
        /// Gets the Next of the customer. 
        /// </summary>
        private int Next
        {
            get
            {
                return this.CurrPage >= this.PageCount ? this.PageCount : this.CurrPage + 1;
            }
        }

        /// <summary>
        /// Gets the StartAndEnd of the customer. 
        /// </summary>
        private int[] StartAndEnd
        {
            get
            {
                int start = 1, end = 1;

                if (this.RecordCount <= 1)
                {
                    start = 1;
                    end = 1;
                }
                else if (this.RecordCount <= this.MoveStep)
                {
                    start = 1;
                    end = this.RecordCount;
                }
                else
                {
                    if (this.CurrPage > this.MoveStep / 2)
                    {
                        if (this.MoveStep % 2 == 0)
                        {
                            start = this.CurrPage - (this.MoveStep / 2) + 1;
                            end = this.MoveStep % 2 == 0 ? (this.CurrPage + (this.MoveStep / 2)) : (this.CurrPage + (this.MoveStep / 2) - 1);
                            if (end > this.RecordCount)
                            {
                                start -= end - this.RecordCount;
                                end = this.RecordCount;
                            }
                        }
                        else
                        {
                            start = this.CurrPage - (this.MoveStep / 2);
                            end = this.CurrPage + (this.MoveStep / 2);
                            if (end > this.RecordCount)
                            {
                                start -= end - this.RecordCount;
                                end = this.RecordCount;
                            }
                        }
                    }
                    else
                    {
                        start = 1;
                        end = this.MoveStep;
                    }
                }

                return new int[] { start, end > this.PageCount ? this.PageCount : end };
            }
        }

        /// <summary>
        /// Gets the JumpJs of the customer. 
        /// </summary>
        private string JumpJs
        {
            get
            {
                if (this.IsPostModel)
                {
                    return string.Empty;
                }

                StringBuilder sb = new StringBuilder();
                sb.Append("\n\n<!-- AspNetPager  Start  -->\n\n");
                sb.Append("<script type=\"text/javascript\">\n\n");
                sb.Append("\tfunction AspNetPager(page){\n");
                sb.Append("\t\tlocation.href='" + this.url + "'.replace('{0}',document.getElementById(page).value)\n");
                sb.Append("\t}\n\n");
                sb.Append("</script>");
                sb.Append("\n\n<!-- AspNetPager  End  -->\n\n");

                return sb.ToString();
            }
        }

        /// <summary>
        /// Gets the url of the customer. 模板 url
        /// </summary>
        private string url
        {
            get
            {
                string url = this.TemplateUrl;
                if (this.TemplateUrl == string.Empty)
                {
                    url = HttpUtility.UrlDecode(System.Web.HttpContext.Current.Request.Url.PathAndQuery);
                    Regex reg = new Regex(@"(\?|&){0,1}page=[^&]*", RegexOptions.IgnoreCase);
                    url = reg.Replace(url, string.Empty);

                    if (url.IndexOf("?") >= 0)
                    {
                        url += "&page={0}";
                    }
                    else
                    {
                        url += "?page={0}";
                    }
                }

                return url;
            }
        }

        /// <summary>
        /// Gets the msg of the customer.msg 提示信息
        /// </summary>
        private string msg
        {
            get
            {
                return "\t<span class=\"msg\">共 <b>" + this.RecordCount.ToString() + "</b> 条 <b>" + this.PageCount + "</b> 页</span>\n";
            }
        }

        /// <summary>
        /// Gets the nav of the customer.nav 页码数
        /// </summary>
        private string nav
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("\t<span class=\"nav\">\n");
                if (this.IsPostModel)
                {
                    if (this.CurrPage <= 1)
                    {
                        sb.Append("\t\t<a class=\"arr disabled\">首页</a>\n");
                        sb.Append("\t\t<a class=\"arr disabled\">上一页</a>\n");
                    }
                    else
                    {
                        sb.Append("\t\t<a href=\"javascript:" + this.Page.ClientScript.GetPostBackEventReference(this, "1") + "\">首页</a>\n");
                        sb.Append("\t\t<a href=\"javascript:" + this.Page.ClientScript.GetPostBackEventReference(this, this.Pre.ToString()) + "\">上一页</a>\n");
                    }

                    sb.Append(this.num);

                    if (this.CurrPage >= this.PageCount)
                    {
                        sb.Append("\t\t<a class=\"arr disabled\">下一页</a>\n");
                        sb.Append("\t\t<a class=\"arr disabled\">末页</a>\n");
                    }
                    else
                    {
                        sb.Append("\t\t<a href=\"javascript:" + Page.ClientScript.GetPostBackEventReference(this, this.Next.ToString()) + "\">下一页</a>\n");
                        sb.Append("\t\t<a href=\"javascript:" + Page.ClientScript.GetPostBackEventReference(this, this.PageCount.ToString()) + "\">末页</a>\n");
                    }
                }
                else
                {
                    if (this.CurrPage < 2)
                    {
                        sb.Append("\t\t<a class=\"arr disabled\">首页</a>\n");
                        sb.Append("\t\t<a class=\"arr disabled\">上一页</a>\n");
                    }
                    else
                    {
                        sb.Append("\t\t<a class=\"arr\" href=\"" + string.Format(this.url, "1") + "\">首页</a>\n");
                        sb.Append("\t\t<a class=\"arr\" href=\"" + string.Format(this.url, this.Pre.ToString()) + "\">上一页</a>\n");
                    }

                    sb.Append(this.num);

                    if (this.CurrPage >= this.PageCount)
                    {
                        sb.Append("\t\t<a class=\"arr disabled\">下一页</a>\n");
                        sb.Append("\t\t<a class=\"arr disabled\">末页</a>\n");
                    }
                    else
                    {
                        sb.Append("\t\t<a class=\"arr\" href=\"" + string.Format(this.url, this.Next.ToString()) + "\">下一页</a>\n");
                        sb.Append("\t\t<a class=\"arr\" href=\"" + string.Format(this.url, this.PageCount.ToString()) + "\">末页</a>\n");
                    }
                }

                sb.Append("\t</span>");
                return sb.ToString();
            }
        }

        /// <summary>
        /// Gets the num of the customer.num 数字
        /// </summary>
        private string num
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                if (this.IsPostModel)
                {
                    for (int i = this.StartAndEnd[0]; i <= this.StartAndEnd[1]; i++)
                    {
                        if (i != this.CurrPage)
                        {
                            sb.Append("\t\t<a class=\"num\" href=\"javascript:" + Page.ClientScript.GetPostBackEventReference(this, i.ToString()) + "\">" + i.ToString() + "</a>\n");
                        }
                        else
                        {
                            sb.Append("\t\t<a class=\"Cur\">" + i.ToString() + "</a>\n");
                        }
                    }
                }
                else
                {
                    for (int i = this.StartAndEnd[0]; i <= this.StartAndEnd[1]; i++)
                    {
                        if (i != this.CurrPage)
                        {
                            sb.Append("\t\t<a class=\"num\" href=\"" + string.Format(this.url, i.ToString()) + "\">" + i.ToString() + "</a>\n");
                        }
                        else
                        {
                            sb.Append("\t\t<a class=\"Cur\">" + i.ToString() + "</a>\n");
                        }
                    }
                }

                return sb.ToString();
            }
        }

        #endregion

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Load Post Data
        /// </summary>
        /// <param name="postDataKey">post Data Key</param>
        /// <param name="values">values 值</param>
        /// <returns>returns 返回false</returns>
        public bool LoadPostData(string postDataKey, NameValueCollection values)
        {
            return false;
        }

        /// <summary>
        /// Raise PostData Changed Event
        /// </summary>
        public void RaisePostDataChangedEvent()
        {
        }

        /// <summary>
        /// Raise PostBack Event
        /// </summary>
        /// <param name="eventArgument">event Argument</param>
        public void RaisePostBackEvent(string eventArgument)
        {
            if (eventArgument == "jump")
            {
                try
                {
                    this.CurrPage = Convert.ToInt32(this.txtInput.Text);
                }
                catch
                {
                    this.CurrPage = 1;
                }

                if (this.CurrPage > this.PageCount)
                {
                    this.CurrPage = this.PageCount;
                }

                if (this.CurrPage <= 0)
                {
                    this.CurrPage = 1;
                }
            }
            else
            {
                this.CurrPage = Convert.ToInt32(eventArgument);
            }

            this.OnPageIndexChange(EventArgs.Empty);
        }

        #endregion

        #region protected Methods

        /// <summary>
        /// Jump 跳转函数
        /// </summary>
        /// <param name="writer">writer 流</param>
        protected void Jump(HtmlTextWriter writer)
        {
            writer.Write("<span class=\"jump\">");
            this.txtInput.Text = this.CurrPage.ToString();
            this.txtInput.RenderControl(writer);
            if (this.IsPostModel)
            {
                writer.Write("<a href=\"javascript:" + Page.ClientScript.GetPostBackEventReference(this, "jump") + "\">跳转</a>");
            }
            else
            {
                writer.Write("<a href=\"javascript:AspNetPager('" + this.txtInput.UniqueID + "')\">跳转</a>");
            }

            writer.Write("</span>");
        }

        /// <summary>
        /// Render 呈现控件
        /// </summary>
        /// <param name="writer">writer 字符流</param>
        protected override void Render(HtmlTextWriter writer)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("\n\n<!-- 分页 开始 -->\n\n");
            sb.Append("<div class=\"PList\">\n");

            sb.Append(this.msg);

            sb.Append(this.nav);

            writer.Write(sb.ToString());

            this.Jump(writer);

            sb.Remove(0, sb.Length);
            sb.Append("\n</div>\n");

            sb.Append("\n<!-- 分页 结束 -->\n\n");

            writer.Write(sb.ToString());
        }

        /// <summary>
        /// On Pre Render
        /// </summary>
        /// <param name="e">Event Args</param>
        protected override void OnPreRender(EventArgs e)
        {
            if (null != Page.Header)
            {
                LiteralControl aspnetpager_js = new LiteralControl(this.JumpJs);
                aspnetpager_js.ID = "AspNetPager_Js";

                if (Page.Header.FindControl("AspNetPager_Js") == null)
                {
                    Page.Header.Controls.Add(aspnetpager_js);
                }
            }
        }

        /// <summary>
        /// Create Child Controls
        /// </summary>
        protected override void CreateChildControls()
        {
            Controls.Clear();
            this.txtInput.ID = this.ClientID + "_txt";
            Controls.Add(this.txtInput);
        }

        /// <summary>
        /// On Page Index Change
        /// </summary>
        /// <param name="e">Event Args</param>
        protected void OnPageIndexChange(System.EventArgs e)
        {
            if (this.PageIndexChange != null)
            {
                this.PageIndexChange(this, e);
            }
        }
        
        #endregion

        #region Private Methods
        #endregion

        #endregion
    }
}