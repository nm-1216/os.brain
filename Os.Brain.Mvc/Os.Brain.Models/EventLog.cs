namespace Os.Brain.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class EventLog
    {
        /// <summary>
        /// moduleid 模块主键
        /// </summary>        
        private Int32 _logid;

        /// <summary>
        /// createdate 创建时间
        /// </summary>        
        private DateTime _date = DateTime.Now;

        /// <summary>
        /// thread 线程
        /// </summary>
        private string _thread = string.Empty;

        /// <summary>
        /// level 级别
        /// </summary>
        private string _level = string.Empty;

        /// <summary>
        /// logger 提供者
        /// </summary>
        private string _logger = string.Empty;

        /// <summary>
        /// message 信息
        /// </summary>
        private string _message = string.Empty;

        /// <summary>
        /// exception 异常
        /// </summary>
        private string _exception = string.Empty;

        /// <summary>
        /// Gets or sets LogID 模块主键
        /// </summary>
        [Key]
        public Int32 LogID
        {
            get { return this._logid; }
            set { this._logid = value; }
        }

        /// <summary>
        /// Gets or sets Date 创建时间
        /// </summary>
        public DateTime Date
        {
            get { return this._date; }
            set { this._date = value; }
        }

        /// <summary>
        /// Gets or sets Father 父亲节点
        /// </summary>
        [MaxLength(128)]
        public string Thread
        {
            get { return this._thread; }
            set { this._thread = value; }
        }

        /// <summary>
        /// Gets or sets Layer 层集关系
        /// </summary>
        [MaxLength(128)]
        public String Level
        {
            get { return this._level; }
            set { this._level = value; }
        }

        /// <summary>
        /// Gets or sets Code 模块编号
        /// </summary>
        [MaxLength(512)]
        public String Logger
        {
            get { return this._logger; }
            set { this._logger = value; }
        }

        /// <summary>
        /// Gets or sets Ico 图标
        /// </summary>
        [MaxLength(4000)]
        public String Message
        {
            get { return this._message; }
            set { this._message = value; }
        }

        /// <summary>
        /// Gets or sets Exception 异常
        /// </summary>
        [MaxLength(4000)]
        public string Exception
        {
            get { return this._exception; }
            set { this._exception = value; }
        }
    }

}
