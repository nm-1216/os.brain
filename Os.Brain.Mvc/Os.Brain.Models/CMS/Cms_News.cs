//-----------------------------------------------------------------------
// <copyright file="Cms_News.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2014/12/04 22:13:59</datetime>
// <discription>
// </discription>
//-----------------------------------------------------------------------

namespace Os.Brain.Models.CMS
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Cms_News 实体类
    /// </summary>
    public partial class Cms_News
    {
        /// <summary>
        /// news_id 新闻编号  年+自动编号 组成 （主键）
        /// </summary>        
        private Int32 _news_id;

        /// <summary>
        /// news_title 新闻标题
        /// </summary>        
        private String _news_title;

        /// <summary>
        /// news_ico 前缀图标
        /// </summary>        
        private String _news_ico;

        /// <summary>
        /// news_color 标题颜色
        /// </summary>        
        private String _news_color;

        /// <summary>
        /// news_subtitle 新闻副标题
        /// </summary>        
        private String _news_subtitle;

        /// <summary>
        /// news_summary 新闻摘要
        /// </summary>        
        
        private String _news_summary;

        /// <summary>
        /// news_author 新闻作者
        /// </summary>        
        private String _news_author;

        /// <summary>
        /// news_keywords 新闻关键字
        /// </summary>        
        private String _news_keywords;

        /// <summary>
        /// news_from 来源
        /// </summary>        
        private String _news_from;

        /// <summary>
        /// news_adduser 新闻添加人
        /// </summary>        
        private String _news_adduser;

        /// <summary>
        /// news_adddate 新闻添加时间
        /// </summary>        
        private DateTime? _news_adddate = DateTime.Now;

        /// <summary>
        /// news_edituser 新闻修改人
        /// </summary>        
        private String _news_edituser;

        /// <summary>
        /// news_editdate 新闻编辑时间
        /// </summary>        
        private DateTime? _news_editdate = DateTime.Now;

        /// <summary>
        /// news_link 新闻转载链接（链接非空【跳链接】 空【左连 新闻内容表】）
        /// </summary>        
        private String _news_link;

        /// <summary>
        /// news_img 新闻图片地址
        /// </summary>        
        private String _news_img;

        /// <summary>
        /// news_hits 新闻点击次数
        /// </summary>        
        private Int32? _news_hits = 0;

        /// <summary>
        /// news_ip 新闻添加或修改IP地址地址 IPv4(16位) IPv6(40位)
        /// </summary>        
        private String _news_ip;

        /// <summary>
        /// news_catalog 新闻分类
        /// </summary>        
        private Int32? _news_catalog;

        /// <summary>
        /// news_property 新闻属性
        /// </summary>        
        private String _news_property;

        /// <summary>
        /// news_isdel 逻辑删除（1 删除真，0 删除假）
        /// </summary>        
        private Boolean? _news_isdel = false;

        /// <summary>
        /// news_isauth 未审:0,一审:1,二审:2,终审:100
        /// </summary>        
        private Int32? _news_isauth;

        /// <summary>
        /// news_text 内容
        /// </summary>        
        private String _news_text;

        /// <summary>
        /// news_field1 备用一
        /// </summary>        
        private String _news_field1;

        /// <summary>
        /// news_field2 备用二
        /// </summary>        
        private String _news_field2;

        /// <summary>
        /// news_field3 备用三
        /// </summary>        
        private String _news_field3;

        /// <summary>
        /// news_field4 备用四
        /// </summary>        
        private String _news_field4;

        /// <summary>
        /// news_field5 备用五
        /// </summary>        
        private String _news_field5;

        /// <summary>
        /// news_field6 备用六
        /// </summary>        
        private String _news_field6;

        /// <summary>
        /// news_field7 备用七
        /// </summary>        
        private String _news_field7;

        /// <summary>
        /// news_field8 备用八
        /// </summary>        
        private String _news_field8;

        /// <summary>
        /// news_field9 备用九
        /// </summary>        
        private String _news_field9;

        /// <summary>
        /// news_field10 备用十
        /// </summary>        
        private String _news_field10;

        /// <summary>
        /// Gets or sets News_ID 新闻编号  年+自动编号 组成 （主键）
        /// </summary>
        [Key]
        public Int32 News_ID
        {
            get { return this._news_id; }
            set { this._news_id = value; }
        }

        /// <summary>
        /// Gets or sets News_Title 新闻标题
        /// </summary>
        public String News_Title
        {
            get { return this._news_title; }
            set { this._news_title = value; }
        }

        /// <summary>
        /// Gets or sets News_Ico 前缀图标
        /// </summary>
        public String News_Ico
        {
            get { return this._news_ico; }
            set { this._news_ico = value; }
        }

        /// <summary>
        /// Gets or sets News_Color 标题颜色
        /// </summary>
        public String News_Color
        {
            get { return this._news_color; }
            set { this._news_color = value; }
        }

        /// <summary>
        /// Gets or sets News_Subtitle 新闻副标题
        /// </summary>
        public String News_Subtitle
        {
            get { return this._news_subtitle; }
            set { this._news_subtitle = value; }
        }

        /// <summary>
        /// Gets or sets News_Summary 新闻摘要
        /// </summary>
        [DataType(DataType.MultilineText)]
        public String News_Summary
        {
            get { return this._news_summary; }
            set { this._news_summary = value; }
        }

        /// <summary>
        /// Gets or sets News_Author 新闻作者
        /// </summary>
        public String News_Author
        {
            get { return this._news_author; }
            set { this._news_author = value; }
        }

        /// <summary>
        /// Gets or sets News_Keywords 新闻关键字
        /// </summary>
        public String News_Keywords
        {
            get { return this._news_keywords; }
            set { this._news_keywords = value; }
        }

        /// <summary>
        /// Gets or sets News_From 来源
        /// </summary>
        public String News_From
        {
            get { return this._news_from; }
            set { this._news_from = value; }
        }

        /// <summary>
        /// Gets or sets News_AddUser 新闻添加人
        /// </summary>
        public String News_AddUser
        {
            get { return this._news_adduser; }
            set { this._news_adduser = value; }
        }

        /// <summary>
        /// Gets or sets News_AddDate 新闻添加时间
        /// </summary>
        public DateTime? News_AddDate
        {
            get { return this._news_adddate; }
            set { this._news_adddate = value; }
        }

        /// <summary>
        /// Gets or sets News_EditUser 新闻修改人
        /// </summary>
        public String News_EditUser
        {
            get { return this._news_edituser; }
            set { this._news_edituser = value; }
        }

        /// <summary>
        /// Gets or sets News_EditDate 新闻编辑时间
        /// </summary>
        public DateTime? News_EditDate
        {
            get { return this._news_editdate; }
            set { this._news_editdate = value; }
        }

        /// <summary>
        /// Gets or sets News_Link 新闻转载链接（链接非空【跳链接】 空【左连 新闻内容表】）
        /// </summary>
        public String News_Link
        {
            get { return this._news_link; }
            set { this._news_link = value; }
        }

        /// <summary>
        /// Gets or sets News_Img 新闻图片地址
        /// </summary>
        public String News_Img
        {
            get { return this._news_img; }
            set { this._news_img = value; }
        }

        /// <summary>
        /// Gets or sets News_Hits 新闻点击次数
        /// </summary>
        public Int32? News_Hits
        {
            get { return this._news_hits; }
            set { this._news_hits = value; }
        }

        /// <summary>
        /// Gets or sets News_IP 新闻添加或修改IP地址地址 IPv4(16位) IPv6(40位)
        /// </summary>
        public String News_IP
        {
            get { return this._news_ip; }
            set { this._news_ip = value; }
        }

        /// <summary>
        /// Gets or sets News_Catalog 新闻分类
        /// </summary>
        public Int32? News_Catalog
        {
            get { return this._news_catalog; }
            set { this._news_catalog = value; }
        }

        /// <summary>
        /// Gets or sets News_Property 新闻属性
        /// </summary>
        public String News_Property
        {
            get { return this._news_property; }
            set { this._news_property = value; }
        }

        /// <summary>
        /// Gets or sets News_isDel 逻辑删除（1 删除真，0 删除假）
        /// </summary>
        public Boolean? News_isDel
        {
            get { return this._news_isdel; }
            set { this._news_isdel = value; }
        }

        /// <summary>
        /// Gets or sets News_isAuth 未审:0,一审:1,二审:2,终审:100
        /// </summary>
        public Int32? News_isAuth
        {
            get { return this._news_isauth; }
            set { this._news_isauth = value; }
        }

        /// <summary>
        /// Gets or sets News_Text 内容
        /// </summary>
        public String News_Text
        {
            get { return this._news_text; }
            set { this._news_text = value; }
        }

        /// <summary>
        /// Gets or sets News_Field1 备用一
        /// </summary>
        public String News_Field1
        {
            get { return this._news_field1; }
            set { this._news_field1 = value; }
        }

        /// <summary>
        /// Gets or sets News_Field2 备用二
        /// </summary>
        public String News_Field2
        {
            get { return this._news_field2; }
            set { this._news_field2 = value; }
        }

        /// <summary>
        /// Gets or sets News_Field3 备用三
        /// </summary>
        public String News_Field3
        {
            get { return this._news_field3; }
            set { this._news_field3 = value; }
        }

        /// <summary>
        /// Gets or sets News_Field4 备用四
        /// </summary>
        public String News_Field4
        {
            get { return this._news_field4; }
            set { this._news_field4 = value; }
        }

        /// <summary>
        /// Gets or sets News_Field5 备用五
        /// </summary>
        public String News_Field5
        {
            get { return this._news_field5; }
            set { this._news_field5 = value; }
        }

        /// <summary>
        /// Gets or sets News_Field6 备用六
        /// </summary>
        public String News_Field6
        {
            get { return this._news_field6; }
            set { this._news_field6 = value; }
        }

        /// <summary>
        /// Gets or sets News_Field7 备用七
        /// </summary>
        public String News_Field7
        {
            get { return this._news_field7; }
            set { this._news_field7 = value; }
        }

        /// <summary>
        /// Gets or sets News_Field8 备用八
        /// </summary>
        public String News_Field8
        {
            get { return this._news_field8; }
            set { this._news_field8 = value; }
        }

        /// <summary>
        /// Gets or sets News_Field9 备用九
        /// </summary>
        public String News_Field9
        {
            get { return this._news_field9; }
            set { this._news_field9 = value; }
        }

        /// <summary>
        /// Gets or sets News_Field10 备用十
        /// </summary>
        public String News_Field10
        {
            get { return this._news_field10; }
            set { this._news_field10 = value; }
        }
    }
}

