using System;
using System.Diagnostics;
using System.IO;
using System.Web.Compilation;

using log4net.Config;

namespace Os.Brain.Instrumentation
{
    public static class AppLog
    {
        private const string ConfigFile = "Os.Brain.log4net.config";
        private static bool _configured;
        private static readonly object ConfigLock = new object();

        private static StackFrame CallingFrame
        {
            get
            {
                StackFrame frame = null;
                var stack = new StackTrace().GetFrames();

                int frameDepth = 0;
                if (stack != null)
                {
                    var reflectedType = stack[frameDepth].GetMethod().ReflectedType;
                    while (reflectedType == BuildManager.GetType("DotNetNuke.Services.Exceptions.Exceptions", false) ||
                           reflectedType == typeof(AppLogger) || reflectedType == typeof(AppLog))
                    {
                        frameDepth++;
                        reflectedType = stack[frameDepth].GetMethod().ReflectedType;
                    }
                    frame = stack[frameDepth];
                }
                return frame;
            }
        }

        private static Type CallingType
        {
            get
            {
                return CallingFrame.GetMethod().DeclaringType;
            }
        }

        private static void EnsureConfig()
        {
            if (!_configured)
            {
                lock (ConfigLock)
                {
                    if (!_configured)
                    {
                        var configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConfigFile);
                        var originalPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config\\" + ConfigFile);
                        if (!File.Exists(configPath) && File.Exists(originalPath))
                        {
                            File.Copy(originalPath, configPath);
                        }

                        if (File.Exists(configPath))
                        {
                            XmlConfigurator.ConfigureAndWatch(new FileInfo(configPath));
                        }
                        _configured = true;
                    }

                }
            }
        }

        public static void SetupThreadContext()
        {
            
        }

        /// <summary>
        ///   Standard method to use on method entry
        /// </summary>
        public static void MethodEntry()
        {
            EnsureConfig();

            var log = AppLogger.GetClassLogger(CallingType);

            if (log.Logger.IsEnabledFor(AppLogger.LevelTrace))
            {
                SetupThreadContext();
                log.TraceFormat("Entering Method [{0}]", CallingFrame.GetMethod().Name);
            }
        }

        /// <summary>
        ///   Standard method to use on method exit
        /// </summary>
        public static void MethodExit(object returnObject)
        {
            EnsureConfig();

            var log = AppLogger.GetClassLogger(CallingType);
            if (log.Logger.IsEnabledFor(AppLogger.LevelTrace))
            {
                if (returnObject == null)
                {
                    returnObject = "NULL";
                }

                SetupThreadContext();
                log.TraceFormat("Method [{0}] Returned [{1}]", CallingFrame.GetMethod().Name, returnObject);
            }
        }

        /// <summary>
        ///   Standard method to use on method exit
        /// </summary>
        public static void MethodExit()
        {
            EnsureConfig();

            var log = AppLogger.GetClassLogger(CallingType);
            if (log.Logger.IsEnabledFor(AppLogger.LevelTrace))
            {

                SetupThreadContext();
                log.TraceFormat("Method [{0}] Returned", CallingFrame.GetMethod().Name);
            }
        }

        #region Trace

        public static void Trace(string message)
        {
            EnsureConfig();

            var log = AppLogger.GetClassLogger(CallingType);
            if (log.Logger.IsEnabledFor(AppLogger.LevelTrace))
            {
                SetupThreadContext();
                log.Trace(message);
            }
        }

        public static void Trace(string format, params object[] args)
        {
            EnsureConfig();

            var log = AppLogger.GetClassLogger(CallingType);
            if (log.Logger.IsEnabledFor(AppLogger.LevelTrace))
            {

                SetupThreadContext();
                log.TraceFormat(format, args);
            }
        }

        public static void Trace(IFormatProvider provider, string format, params object[] args)
        {
            EnsureConfig();

            var log = AppLogger.GetClassLogger(CallingType);
            if (log.Logger.IsEnabledFor(AppLogger.LevelTrace))
            {

                SetupThreadContext();
                log.TraceFormat(provider, format, args);
            }
        }

        #endregion

        #region Debug

        public static void Debug(object message)
        {
            EnsureConfig();

            var log = AppLogger.GetClassLogger(CallingType);
            if (log.Logger.IsEnabledFor(AppLogger.LevelDebug))
            {
                SetupThreadContext();
                log.Debug(message);
            }
        }

        public static void Debug(string format, params object[] args)
        {
            EnsureConfig();

            var log = AppLogger.GetClassLogger(CallingType);
            if (log.Logger.IsEnabledFor(AppLogger.LevelDebug))
            {
                SetupThreadContext();
                log.DebugFormat(format, args);
            }
        }

        public static void Debug(IFormatProvider provider, string format, params object[] args)
        {
            EnsureConfig();

            var log = AppLogger.GetClassLogger(CallingType);
            if (log.Logger.IsEnabledFor(AppLogger.LevelDebug))
            {
                SetupThreadContext();
                log.DebugFormat(provider, format, args);
            }
        }

        #endregion

        #region Info

        public static void Info(object message)
        {
            EnsureConfig();
            var log = AppLogger.GetClassLogger(CallingType);
            if (log.Logger.IsEnabledFor(AppLogger.LevelInfo))
            {
                SetupThreadContext();
                log.Info(message);
            }
        }

        public static void Info(IFormatProvider provider, string format, params object[] args)
        {
            EnsureConfig();
            var log = AppLogger.GetClassLogger(CallingType);
            if (log.Logger.IsEnabledFor(AppLogger.LevelInfo))
            {
                SetupThreadContext();
                log.InfoFormat(provider, format, args);
            }
        }

        public static void Info(string format, params object[] args)
        {
            EnsureConfig();
            var log = AppLogger.GetClassLogger(CallingType);
            if (log.Logger.IsEnabledFor(AppLogger.LevelInfo))
            {
                SetupThreadContext();
                log.InfoFormat(format, args);
            }
        }

        #endregion

        #region Warn

        public static void Warn(string message, Exception exception)
        {
            EnsureConfig();
            var log = AppLogger.GetClassLogger(CallingType);
            if (log.Logger.IsEnabledFor(AppLogger.LevelWarn))
            {
                SetupThreadContext();
                log.Warn(message, exception);
            }
        }

        public static void Warn(object message)
        {
            EnsureConfig();
            var log = AppLogger.GetClassLogger(CallingType);
            if (log.Logger.IsEnabledFor(AppLogger.LevelWarn))
            {
                SetupThreadContext();
                log.Warn(message);
            }
        }

        public static void Warn(IFormatProvider provider, string format, params object[] args)
        {
            EnsureConfig();
            var log = AppLogger.GetClassLogger(CallingType);
            if (log.Logger.IsEnabledFor(AppLogger.LevelWarn))
            {
                SetupThreadContext();
                log.WarnFormat(provider, format, args);
            }
        }


        public static void Warn(string format, params object[] args)
        {
            EnsureConfig();
            var log = AppLogger.GetClassLogger(CallingType);
            if (log.Logger.IsEnabledFor(AppLogger.LevelWarn))
            {
                SetupThreadContext();
                log.WarnFormat(format, args);
            }
        }

        #endregion

        #region Error

        public static void Error(string message, Exception exception)
        {
            EnsureConfig();

            var log = AppLogger.GetClassLogger(CallingType);
            if (log.Logger.IsEnabledFor(AppLogger.LevelError))
            {
                SetupThreadContext();
                log.Error(message, exception);
            }
        }

        public static void Error(object message)
        {
            EnsureConfig();
            var log = AppLogger.GetClassLogger(CallingType);
            if (log.Logger.IsEnabledFor(AppLogger.LevelError))
            {
                SetupThreadContext();
                log.Error(message);
            }
        }

        public static void Error(Exception exception)
        {
            EnsureConfig();
            var log = AppLogger.GetClassLogger(CallingType);
            if (log.Logger.IsEnabledFor(AppLogger.LevelError))
            {
                SetupThreadContext();
                log.Error(exception.Message, exception);
            }
        }

        public static void Error(IFormatProvider provider, string format, params object[] args)
        {
            EnsureConfig();
            var log = AppLogger.GetClassLogger(CallingType);
            if (log.Logger.IsEnabledFor(AppLogger.LevelError))
            {
                SetupThreadContext();
                log.ErrorFormat(provider, format, args);
            }
        }

        public static void Error(string format, params object[] args)
        {
            EnsureConfig();
            var log = AppLogger.GetClassLogger(CallingType);
            if (log.Logger.IsEnabledFor(AppLogger.LevelError))
            {
                SetupThreadContext();
                log.ErrorFormat(format, args);
            }
        }

        #endregion

        #region Fatal

        public static void Fatal(string message, Exception exception)
        {
            EnsureConfig();
            var log = AppLogger.GetClassLogger(CallingType);
            if (log.Logger.IsEnabledFor(AppLogger.LevelFatal))
            {
                SetupThreadContext();
                log.Fatal(message, exception);
            }
        }

        public static void Fatal(object message)
        {
            EnsureConfig();
            var log = AppLogger.GetClassLogger(CallingType);
            if (log.Logger.IsEnabledFor(AppLogger.LevelFatal))
            {
                SetupThreadContext();
                log.Fatal(message);
            }
        }

        public static void Fatal(IFormatProvider provider, string format, params object[] args)
        {
            EnsureConfig();
            var log = AppLogger.GetClassLogger(CallingType);
            if (log.Logger.IsEnabledFor(AppLogger.LevelFatal))
            {
                SetupThreadContext();
                log.FatalFormat(provider, format, args);
            }
        }

        public static void Fatal(string format, params object[] args)
        {
            EnsureConfig();
            var log = AppLogger.GetClassLogger(CallingType);
            if (log.Logger.IsEnabledFor(AppLogger.LevelFatal))
            {
                SetupThreadContext();
                log.FatalFormat(format, args);
            }
        }

        #endregion
    }
}
