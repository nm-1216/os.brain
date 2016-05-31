

namespace Os.Brain.Core.Logger
{
    using System;
    using System.IO;
    using Microsoft.AspNet.Hosting;
    using Microsoft.Extensions.Logging;

    public class TextLoggerProvider : ILoggerProvider
    {
        public LogLevel LogLevel;
        private IHostingEnvironment _env;


        public TextLoggerProvider(LogLevel logLevel, IHostingEnvironment env)
        {
            this.LogLevel = logLevel;
            this._env = env;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new TextLogger(categoryName, this.LogLevel, _env);
        }

        public void Dispose()
        {
        }

        public class TextLogger : ILogger
        {
            private string _name;
            private LogLevel _level;
            private IHostingEnvironment _env;

            private string _path = string.Empty;

            public TextLogger(string name, LogLevel logLevel, IHostingEnvironment env)
            {
                this._name = name;
                this._level = logLevel;
                this._env = env;

                if (_env.IsEnvironment("Development"))
                    _path = _env.WebRootPath + @"\TextLogger.txt";
                else
                    _path = Directory.GetParent(_env.WebRootPath).FullName + @"\logs\TextLogger.txt";

            }

            public IDisposable BeginScopeImpl(object state)
            {
                return null;
            }

            public bool IsEnabled(LogLevel logLevel)
            {
                return ((int)logLevel >= (int)this._level);
            }

            public void Log(LogLevel logLevel, int eventId, object state, Exception exception, Func<object, Exception, string> formatter)
            {   
                File.AppendAllText(_path, formatter(state, exception));
                Console.WriteLine(formatter(state, exception));
            }
        }
    }
}
