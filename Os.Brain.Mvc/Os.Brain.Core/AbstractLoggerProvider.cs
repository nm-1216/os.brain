

using System;
using Microsoft.Extensions.Logging;

namespace Os.Brain.Core
{
    public class AbstractLoggerProvider : ILoggerProvider
    {
        private LogLevel LogLevel;

        public AbstractLoggerProvider(LogLevel logLevel)
        {
            this.LogLevel = logLevel;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new CustomLogger(categoryName, LogLevel);
            //throw new NotImplementedException();
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }


    public class CustomLogger : ILogger
    {
        //名字
        public string Name { get; set; }
        public LogLevel LogLevel { get; set; }

        public CustomLogger(string name, LogLevel logLevel)
        {
            Name = name;
            LogLevel = logLevel;
        }

        public IDisposable BeginScope(object state)
        {
            //释放资源 如数据库
            return null;
        }

        //检查日志级别
        public bool IsEnabled(LogLevel logLevel)
        {

            //return true;
            return ((int)logLevel >= (int)this.LogLevel);
        }
        
        public void Log(LogLevel logLevel, int eventId, object state, Exception exception, Func<object, Exception, string> formatter)
        {
            var message = formatter(state, exception);
            //File.AppendAllText("D:\\222.txt", message);
        }

        public IDisposable BeginScopeImpl(object state)
        {
            return null;
            //throw new NotImplementedException();
        }
    }
}
