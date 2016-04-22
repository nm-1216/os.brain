//-----------------------------------------------------------------------
// <copyright file="Debug.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2013/12/21</datetime>
// <discription>
//      Conditional： 
//          根据预处理标识符执行方法。Conditional 属性是 ConditionalAttribute 的别名，可应用于方法或属性类。
//
//      Conditional 属性经常与 DEBUG 标识符一起使用以启用调试版本的跟踪和日志记录功能（在发行版本中没有这两种功能）。
// </discription>
//-----------------------------------------------------------------------

namespace Os.Brain.Common
{
    using System;
    using System.Web;
    
    /// <summary>
    /// 日志 操作类
    /// </summary>
    public class Debug
    {
        /// <summary>
        /// 写日志 锁对象
        /// </summary>
        private static object obj = new object();

        /// <summary>
        /// 写 日志
        /// </summary>
        /// <param name="log">日志 消息体</param>
        [System.Diagnostics.Conditional("DEBUG")]
        public static void WriteLog(string log)
        {
            WriteLog("~/debug.txt", log);
        }

        /// <summary>
        /// 写 日志
        /// </summary>
        /// <param name="path">日志 路径</param>
        /// <param name="log">日志 消息体</param>
        [System.Diagnostics.Conditional("DEBUG")]
        public static void WriteLog(string path, string log)
        {
            lock (obj)
            {
                System.IO.File.AppendAllText(Utils.MapPath(path), string.Format("{0}  {1}\r\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), log),System.Text.Encoding.Default);
            }
        }

        /// <summary>
        /// 日志 执行时间
        /// </summary>
        public class TimedLog : IDisposable
        {
            /// <summary>
            /// 日志 消息体
            /// </summary>
            private string message;

            /// <summary>
            /// 类 开始时间
            /// </summary>
            private long starTicks;

            /// <summary>
            /// Initializes a new instance of the <see cref="TimedLog"/> class.
            /// </summary>
            /// <param name="msg">msg 消息体</param>
            public TimedLog(string msg)
            {
                this.message = msg;
                this.starTicks = DateTime.Now.Ticks;
            }

            /// <summary>
            /// 撤销 资源
            /// </summary>
            void IDisposable.Dispose()
            {
                WriteLog(this.message + TimeSpan.FromTicks(DateTime.Now.Ticks - this.starTicks).TotalSeconds.ToString());
            }
        }
    }
}