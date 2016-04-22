using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Web.Compilation;
using System.Web.UI;

using log4net;
using log4net.Core;
using log4net.Repository;
using log4net.Util;

namespace Os.Brain.Instrumentation
{
    public sealed class AppLogger : LoggerWrapperImpl
    {
        #region Private Fields

        //追踪
        internal static Level LevelTrace;

        //调试
        internal static Level LevelDebug;

        //消息
        internal static Level LevelInfo;

        //警告
        internal static Level LevelWarn;

        //错误
        internal static Level LevelError;

        //致命错误
        internal static Level LevelFatal;

        #endregion

        #region app sepcific bits




        private readonly Type _appExceptionType = BuildManager.GetType("DotNetNuke.Services.Exceptions.Exceptions", false);
        private readonly Type _stackBoundary = typeof(AppLogger);

        private AppLogger(ILogger logger)
            : base(logger)
        {
            StackFrame[] stack = new StackTrace().GetFrames();

            if (stack != null)
            {
                int frameDepth = 0;
                Type methodType = stack[frameDepth].GetMethod().ReflectedType;
                while (methodType == _appExceptionType || methodType == typeof(AppLogger) || methodType == typeof(AppLog) || methodType == typeof(Control))
                {
                    frameDepth++;
                    methodType = stack[frameDepth].GetMethod().ReflectedType;
                }

                _stackBoundary = new StackTrace().GetFrame(frameDepth - 1).GetMethod().DeclaringType;
            }
            else
            {
                _stackBoundary = typeof(AppLogger);
            }

            ReloadLevels(logger.Repository);
        }

        /// <summary>
        ///   Virtual method called when the configuration of the repository changes
        /// </summary>
        /// <param name = "repository">the repository holding the levels</param>
        /// <remarks>
        ///   <para>
        ///     Virtual method called when the configuration of the repository changes
        ///   </para>
        /// </remarks>
        private static void ReloadLevels(ILoggerRepository repository)
        {
            LevelMap levelMap = repository.LevelMap;

            LevelTrace = levelMap.LookupWithDefault(Level.Trace);
            LevelDebug = levelMap.LookupWithDefault(Level.Debug);
            LevelInfo = levelMap.LookupWithDefault(Level.Info);
            LevelWarn = levelMap.LookupWithDefault(Level.Warn);
            LevelError = levelMap.LookupWithDefault(Level.Error);
            LevelFatal = levelMap.LookupWithDefault(Level.Fatal);
        }

        public static AppLogger GetClassLogger(Type type)
        {
            return new AppLogger(LogManager.GetLogger(Assembly.GetCallingAssembly(), type).Logger);
        }

        public static AppLogger GetLogger(string name)
        {
            return new AppLogger(LogManager.GetLogger(name).Logger);
        }

        public static void SetContextProperty(string key, string value)
        {
            ThreadContext.Properties[key] = value;
        }

        public static string GetContextProperty(string key)
        {
            return ThreadContext.Properties[key].ToString();
        }

        #endregion


        #region 调试

        /// <summary>
        ///   Logs a message object with the <c>DEBUG</c> level.
        /// </summary>
        /// <param name = "message">The message object to log.</param>
        /// <remarks>
        ///   <para>
        ///     This method first checks if this logger is <c>DEBUG</c>
        ///     enabled by comparing the level of this logger with the 
        ///     <c>DEBUG</c> level. If this logger is
        ///     <c>DEBUG</c> enabled, then it converts the message object
        ///     (passed as parameter) to a string by invoking the appropriate
        ///     <see cref = "log4net.ObjectRenderer.IObjectRenderer" />. It then 
        ///     proceeds to call all the registered appenders in this logger 
        ///     and also higher in the hierarchy depending on the value of the 
        ///     additivity flag.
        ///   </para>
        ///   <para>
        ///     <b>WARNING</b> Note that passing an <see cref = "Exception" /> 
        ///     to this method will print the name of the <see cref = "Exception" /> 
        ///     but no stack trace. To print a stack trace use the 
        ///     <see cref = "Error(object,Exception)" /> form instead.
        ///   </para>
        /// </remarks>
        public void Debug(object message)
        {
            Logger.Log(_stackBoundary, LevelDebug, message, null);
        }

        /// <summary>
        ///   Logs a formatted message string with the <c>DEBUG</c> level.
        /// </summary>
        /// <param name = "format">A String containing zero or more format items</param>
        /// <param name = "args">An Object array containing zero or more objects to format</param>
        /// <remarks>
        ///   <para>
        ///     The message is formatted using the <see cref = "String.Format(IFormatProvider, string, object[])" /> method. See
        ///     <c>String.Format</c> for details of the syntax of the format string and the behavior
        ///     of the formatting.
        ///   </para>
        ///   <para>
        ///     The string is formatted using the <see cref = "CultureInfo.InvariantCulture" />
        ///     format provider. To specify a localized provider use the
        ///     <see cref = "DebugFormat(IFormatProvider,string,object[])" /> method.
        ///   </para>
        ///   <para>
        ///     This method does not take an <see cref = "Exception" /> object to include in the
        ///     log event. To pass an <see cref = "Exception" /> use one of the <see cref = "Debug(object)" />
        ///     methods instead.
        ///   </para>
        /// </remarks>
        public void DebugFormat(string format, params object[] args)
        {
            Logger.Log(_stackBoundary, LevelDebug, new SystemStringFormat(CultureInfo.InvariantCulture, format, args), null);
        }

        /// <summary>
        ///   Logs a formatted message string with the <c>DEBUG</c> level.
        /// </summary>
        /// <param name = "provider">An <see cref = "IFormatProvider" /> that supplies culture-specific formatting information</param>
        /// <param name = "format">A String containing zero or more format items</param>
        /// <param name = "args">An Object array containing zero or more objects to format</param>
        /// <remarks>
        ///   <para>
        ///     The message is formatted using the <see cref = "String.Format(IFormatProvider, string, object[])" /> method. See
        ///     <c>String.Format</c> for details of the syntax of the format string and the behavior
        ///     of the formatting.
        ///   </para>
        ///   <para>
        ///     This method does not take an <see cref = "Exception" /> object to include in the
        ///     log event. To pass an <see cref = "Exception" /> use one of the <see cref = "Debug(object)" />
        ///     methods instead.
        ///   </para>
        /// </remarks>
        public void DebugFormat(IFormatProvider provider, string format, params object[] args)
        {
            Logger.Log(_stackBoundary, LevelDebug, new SystemStringFormat(provider, format, args), null);
        }

        #endregion

        #region 消息

        /// <summary>
        ///   Logs a message object with the <c>INFO</c> level.
        /// </summary>
        /// <param name = "message">The message object to log.</param>
        /// <remarks>
        ///   <para>
        ///     This method first checks if this logger is <c>INFO</c>
        ///     enabled by comparing the level of this logger with the 
        ///     <c>INFO</c> level. If this logger is
        ///     <c>INFO</c> enabled, then it converts the message object
        ///     (passed as parameter) to a string by invoking the appropriate
        ///     <see cref = "log4net.ObjectRenderer.IObjectRenderer" />. It then 
        ///     proceeds to call all the registered appenders in this logger 
        ///     and also higher in the hierarchy depending on the value of 
        ///     the additivity flag.
        ///   </para>
        ///   <para>
        ///     <b>WARNING</b> Note that passing an <see cref = "Exception" /> 
        ///     to this method will print the name of the <see cref = "Exception" /> 
        ///     but no stack trace. To print a stack trace use the 
        ///     <see cref = "Error(object,Exception)" /> form instead.
        ///   </para>
        /// </remarks>
        public void Info(object message)
        {
            Logger.Log(_stackBoundary, LevelInfo, message, null);
        }

        /// <summary>
        ///   Logs a formatted message string with the <c>INFO</c> level.
        /// </summary>
        /// <param name = "format">A String containing zero or more format items</param>
        /// <param name = "args">An Object array containing zero or more objects to format</param>
        /// <remarks>
        ///   <para>
        ///     The message is formatted using the <see cref = "String.Format(IFormatProvider, string, object[])" /> method. See
        ///     <c>String.Format</c> for details of the syntax of the format string and the behavior
        ///     of the formatting.
        ///   </para>
        ///   <para>
        ///     The string is formatted using the <see cref = "CultureInfo.InvariantCulture" />
        ///     format provider. To specify a localized provider use the
        ///     <see cref = "InfoFormat(IFormatProvider,string,object[])" /> method.
        ///   </para>
        ///   <para>
        ///     This method does not take an <see cref = "Exception" /> object to include in the
        ///     log event. To pass an <see cref = "Exception" /> use one of the <see cref = "Info(object)" />
        ///     methods instead.
        ///   </para>
        /// </remarks>
        public void InfoFormat(string format, params object[] args)
        {
            Logger.Log(_stackBoundary, LevelInfo, new SystemStringFormat(CultureInfo.InvariantCulture, format, args), null);
        }

        /// <summary>
        ///   Logs a formatted message string with the <c>INFO</c> level.
        /// </summary>
        /// <param name = "provider">An <see cref = "IFormatProvider" /> that supplies culture-specific formatting information</param>
        /// <param name = "format">A String containing zero or more format items</param>
        /// <param name = "args">An Object array containing zero or more objects to format</param>
        /// <remarks>
        ///   <para>
        ///     The message is formatted using the <see cref = "String.Format(IFormatProvider, string, object[])" /> method. See
        ///     <c>String.Format</c> for details of the syntax of the format string and the behavior
        ///     of the formatting.
        ///   </para>
        ///   <para>
        ///     This method does not take an <see cref = "Exception" /> object to include in the
        ///     log event. To pass an <see cref = "Exception" /> use one of the <see cref = "Info(object)" />
        ///     methods instead.
        ///   </para>
        /// </remarks>
        public void InfoFormat(IFormatProvider provider, string format, params object[] args)
        {
            Logger.Log(_stackBoundary, LevelInfo, new SystemStringFormat(provider, format, args), null);
        }

        #endregion

        #region 垃圾不知道

        internal void TraceFormat(string format, params object[] args)
        {
            Logger.Log(_stackBoundary, LevelTrace, new SystemStringFormat(CultureInfo.InvariantCulture, format, args), null);
        }

        internal void Trace(string message)
        {
            Logger.Log(_stackBoundary, LevelTrace, message, null);
        }

        internal void TraceFormat(IFormatProvider provider, string format, params object[] args)
        {
            Logger.Log(_stackBoundary, LevelTrace, new SystemStringFormat(provider, format, args), null);
        }

        #endregion

        #region 警告

        /// <summary>
        ///   Logs a message object with the <c>WARN</c> level.
        /// </summary>
        /// <param name = "message">the message object to log</param>
        /// <remarks>
        ///   <para>
        ///     This method first checks if this logger is <c>WARN</c>
        ///     enabled by comparing the level of this logger with the 
        ///     <c>WARN</c> level. If this logger is
        ///     <c>WARN</c> enabled, then it converts the message object
        ///     (passed as parameter) to a string by invoking the appropriate
        ///     <see cref = "log4net.ObjectRenderer.IObjectRenderer" />. It then 
        ///     proceeds to call all the registered appenders in this logger and 
        ///     also higher in the hierarchy depending on the value of the 
        ///     additivity flag.
        ///   </para>
        ///   <para>
        ///     <b>WARNING</b> Note that passing an <see cref = "Exception" /> to this
        ///     method will print the name of the <see cref = "Exception" /> but no
        ///     stack trace. To print a stack trace use the 
        ///     <see cref = "Warn(object,Exception)" /> form instead.
        ///   </para>
        /// </remarks>
        public void Warn(object message)
        {
            Logger.Log(_stackBoundary, LevelWarn, message, null);
        }

        /// <summary>
        ///   Logs a message object with the <c>WARN</c> level
        /// </summary>
        /// <param name = "message">The message object to log.</param>
        /// <param name = "exception">The exception to log, including its stack trace.</param>
        /// <remarks>
        ///   <para>
        ///     Logs a message object with the <c>WARN</c> level including
        ///     the stack trace of the <see cref = "Exception" /> <paramref name = "exception" /> 
        ///     passed as a parameter.
        ///   </para>
        ///   <para>
        ///     See the <see cref = "Warn(object)" /> form for more detailed information.
        ///   </para>
        /// </remarks>
        /// <seealso cref = "Warn(object)" />
        public void Warn(object message, Exception exception)
        {
            Logger.Log(_stackBoundary, LevelWarn, message, exception);
        }

        /// <summary>
        ///   Logs a formatted message string with the <c>WARN</c> level.
        /// </summary>
        /// <param name = "format">A String containing zero or more format items</param>
        /// <param name = "args">An Object array containing zero or more objects to format</param>
        /// <remarks>
        ///   <para>
        ///     The message is formatted using the <see cref = "String.Format(IFormatProvider, string, object[])" /> method. See
        ///     <c>String.Format</c> for details of the syntax of the format string and the behavior
        ///     of the formatting.
        ///   </para>
        ///   <para>
        ///     The string is formatted using the <see cref = "CultureInfo.InvariantCulture" />
        ///     format provider. To specify a localized provider use the
        ///     <see cref = "WarnFormat(IFormatProvider,string,object[])" /> method.
        ///   </para>
        ///   <para>
        ///     This method does not take an <see cref = "Exception" /> object to include in the
        ///     log event. To pass an <see cref = "Exception" /> use one of the <see cref = "Warn(object)" />
        ///     methods instead.
        ///   </para>
        /// </remarks>
        public void WarnFormat(string format, params object[] args)
        {
            Logger.Log(_stackBoundary, LevelWarn, new SystemStringFormat(CultureInfo.InvariantCulture, format, args), null);
        }

        /// <summary>
        ///   Logs a formatted message string with the <c>WARN</c> level.
        /// </summary>
        /// <param name = "provider">An <see cref = "IFormatProvider" /> that supplies culture-specific formatting information</param>
        /// <param name = "format">A String containing zero or more format items</param>
        /// <param name = "args">An Object array containing zero or more objects to format</param>
        /// <remarks>
        ///   <para>
        ///     The message is formatted using the <see cref = "String.Format(IFormatProvider, string, object[])" /> method. See
        ///     <c>String.Format</c> for details of the syntax of the format string and the behavior
        ///     of the formatting.
        ///   </para>
        ///   <para>
        ///     This method does not take an <see cref = "Exception" /> object to include in the
        ///     log event. To pass an <see cref = "Exception" /> use one of the <see cref = "Warn(object)" />
        ///     methods instead.
        ///   </para>
        /// </remarks>
        public void WarnFormat(IFormatProvider provider, string format, params object[] args)
        {
            Logger.Log(_stackBoundary, LevelWarn, new SystemStringFormat(provider, format, args), null);
        }

        #endregion

        #region 错误

        /// <summary>
        ///   Logs a message object with the <c>ERROR</c> level.
        /// </summary>
        /// <param name = "message">The message object to log.</param>
        /// <remarks>
        ///   <para>
        ///     This method first checks if this logger is <c>ERROR</c>
        ///     enabled by comparing the level of this logger with the 
        ///     <c>ERROR</c> level. If this logger is
        ///     <c>ERROR</c> enabled, then it converts the message object
        ///     (passed as parameter) to a string by invoking the appropriate
        ///     <see cref = "log4net.ObjectRenderer.IObjectRenderer" />. It then 
        ///     proceeds to call all the registered appenders in this logger and 
        ///     also higher in the hierarchy depending on the value of the 
        ///     additivity flag.
        ///   </para>
        ///   <para>
        ///     <b>WARNING</b> Note that passing an <see cref = "Exception" /> to this
        ///     method will print the name of the <see cref = "Exception" /> but no
        ///     stack trace. To print a stack trace use the 
        ///     <see cref = "Error(object,Exception)" /> form instead.
        ///   </para>
        /// </remarks>
        public void Error(object message)
        {
            Logger.Log(_stackBoundary, LevelError, message, null);
        }

        /// <summary>
        ///   Logs a message object with the <c>ERROR</c> level
        /// </summary>
        /// <param name = "message">The message object to log.</param>
        /// <param name = "exception">The exception to log, including its stack trace.</param>
        /// <remarks>
        ///   <para>
        ///     Logs a message object with the <c>ERROR</c> level including
        ///     the stack trace of the <see cref = "Exception" /> <paramref name = "exception" /> 
        ///     passed as a parameter.
        ///   </para>
        ///   <para>
        ///     See the <see cref = "Error(object)" /> form for more detailed information.
        ///   </para>
        /// </remarks>
        /// <seealso cref = "Error(object)" />
        public void Error(object message, Exception exception)
        {
            Logger.Log(_stackBoundary, LevelError, message, exception);
        }

        /// <summary>
        ///   Logs a formatted message string with the <c>ERROR</c> level.
        /// </summary>
        /// <param name = "format">A String containing zero or more format items</param>
        /// <param name = "args">An Object array containing zero or more objects to format</param>
        /// <remarks>
        ///   <para>
        ///     The message is formatted using the <see cref = "String.Format(IFormatProvider, string, object[])" /> method. See
        ///     <c>String.Format</c> for details of the syntax of the format string and the behavior
        ///     of the formatting.
        ///   </para>
        ///   <para>
        ///     The string is formatted using the <see cref = "CultureInfo.InvariantCulture" />
        ///     format provider. To specify a localized provider use the
        ///     <see cref = "ErrorFormat(IFormatProvider,string,object[])" /> method.
        ///   </para>
        ///   <para>
        ///     This method does not take an <see cref = "Exception" /> object to include in the
        ///     log event. To pass an <see cref = "Exception" /> use one of the <see cref = "Error(object)" />
        ///     methods instead.
        ///   </para>
        /// </remarks>
        public void ErrorFormat(string format, params object[] args)
        {
            Logger.Log(_stackBoundary, LevelError, new SystemStringFormat(CultureInfo.InvariantCulture, format, args), null);
        }

        /// <summary>
        ///   Logs a formatted message string with the <c>ERROR</c> level.
        /// </summary>
        /// <param name = "provider">An <see cref = "IFormatProvider" /> that supplies culture-specific formatting information</param>
        /// <param name = "format">A String containing zero or more format items</param>
        /// <param name = "args">An Object array containing zero or more objects to format</param>
        /// <remarks>
        ///   <para>
        ///     The message is formatted using the <see cref = "String.Format(IFormatProvider, string, object[])" /> method. See
        ///     <c>String.Format</c> for details of the syntax of the format string and the behavior
        ///     of the formatting.
        ///   </para>
        ///   <para>
        ///     This method does not take an <see cref = "Exception" /> object to include in the
        ///     log event. To pass an <see cref = "Exception" /> use one of the <see cref = "Error(object)" />
        ///     methods instead.
        ///   </para>
        /// </remarks>
        public void ErrorFormat(IFormatProvider provider, string format, params object[] args)
        {
            Logger.Log(_stackBoundary, LevelError, new SystemStringFormat(provider, format, args), null);
        }

        #endregion

        #region 致命错误

        /// <summary>
        ///   Logs a message object with the <c>FATAL</c> level.
        /// </summary>
        /// <param name = "message">The message object to log.</param>
        /// <remarks>
        ///   <para>
        ///     This method first checks if this logger is <c>FATAL</c>
        ///     enabled by comparing the level of this logger with the 
        ///     <c>FATAL</c> level. If this logger is
        ///     <c>FATAL</c> enabled, then it converts the message object
        ///     (passed as parameter) to a string by invoking the appropriate
        ///     <see cref = "log4net.ObjectRenderer.IObjectRenderer" />. It then 
        ///     proceeds to call all the registered appenders in this logger and 
        ///     also higher in the hierarchy depending on the value of the 
        ///     additivity flag.
        ///   </para>
        ///   <para>
        ///     <b>WARNING</b> Note that passing an <see cref = "Exception" /> to this
        ///     method will print the name of the <see cref = "Exception" /> but no
        ///     stack trace. To print a stack trace use the 
        ///     <see cref = "Fatal(object,Exception)" /> form instead.
        ///   </para>
        /// </remarks>
        public void Fatal(object message)
        {
            Logger.Log(_stackBoundary, LevelFatal, message, null);
        }

        /// <summary>
        ///   Logs a message object with the <c>FATAL</c> level
        /// </summary>
        /// <param name = "message">The message object to log.</param>
        /// <param name = "exception">The exception to log, including its stack trace.</param>
        /// <remarks>
        ///   <para>
        ///     Logs a message object with the <c>FATAL</c> level including
        ///     the stack trace of the <see cref = "Exception" /> <paramref name = "exception" /> 
        ///     passed as a parameter.
        ///   </para>
        ///   <para>
        ///     See the <see cref = "Fatal(object)" /> form for more detailed information.
        ///   </para>
        /// </remarks>
        /// <seealso cref = "Fatal(object)" />
        public void Fatal(object message, Exception exception)
        {
            Logger.Log(_stackBoundary, LevelFatal, message, exception);
        }

        /// <summary>
        ///   Logs a formatted message string with the <c>FATAL</c> level.
        /// </summary>
        /// <param name = "format">A String containing zero or more format items</param>
        /// <param name = "args">An Object array containing zero or more objects to format</param>
        /// <remarks>
        ///   <para>
        ///     The message is formatted using the <see cref = "String.Format(IFormatProvider, string, object[])" /> method. See
        ///     <c>String.Format</c> for details of the syntax of the format string and the behavior
        ///     of the formatting.
        ///   </para>
        ///   <para>
        ///     The string is formatted using the <see cref = "CultureInfo.InvariantCulture" />
        ///     format provider. To specify a localized provider use the
        ///     <see cref = "FatalFormat(IFormatProvider,string,object[])" /> method.
        ///   </para>
        ///   <para>
        ///     This method does not take an <see cref = "Exception" /> object to include in the
        ///     log event. To pass an <see cref = "Exception" /> use one of the <see cref = "Fatal(object)" />
        ///     methods instead.
        ///   </para>
        /// </remarks>
        public void FatalFormat(string format, params object[] args)
        {
            Logger.Log(_stackBoundary, LevelFatal, new SystemStringFormat(CultureInfo.InvariantCulture, format, args), null);
        }

        /// <summary>
        ///   Logs a formatted message string with the <c>FATAL</c> level.
        /// </summary>
        /// <param name = "provider">An <see cref = "IFormatProvider" /> that supplies culture-specific formatting information</param>
        /// <param name = "format">A String containing zero or more format items</param>
        /// <param name = "args">An Object array containing zero or more objects to format</param>
        /// <remarks>
        ///   <para>
        ///     The message is formatted using the <see cref = "String.Format(IFormatProvider, string, object[])" /> method. See
        ///     <c>String.Format</c> for details of the syntax of the format string and the behavior
        ///     of the formatting.
        ///   </para>
        ///   <para>
        ///     This method does not take an <see cref = "Exception" /> object to include in the
        ///     log event. To pass an <see cref = "Exception" /> use one of the <see cref = "Fatal(object)" />
        ///     methods instead.
        ///   </para>
        /// </remarks>
        public void FatalFormat(IFormatProvider provider, string format, params object[] args)
        {
            Logger.Log(_stackBoundary, LevelFatal, new SystemStringFormat(provider, format, args), null);
        }

        #endregion
    }
}