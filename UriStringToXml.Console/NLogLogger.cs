namespace UriStringToXml.Console
{
    using System;

    using Logger.Base;

    /// <summary>
    /// Logger that uses NLog internally.
    /// </summary>
    public class NLogLogger : ILogger
    {
        /// <summary>
        /// NLog logger.
        /// </summary>
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Logs information message.
        /// </summary>
        /// <param name="msg">
        /// Message that will be logged.
        /// </param>
        public void Info(string msg) => Logger.Info(msg);

        /// <summary>
        /// Logs warning message.
        /// </summary>
        /// <param name="msg">
        /// Message that will be logged.
        /// </param>
        public void Warning(string msg) => Logger.Warn(msg);
        
        /// <summary>
        /// Logs warning message.
        /// </summary>
        /// <param name="ex">
        /// Exception that needs to be logged.
        /// </param>
        /// <param name="msg">
        /// Message that will be logged.
        /// </param>
        public void Warning(Exception ex, string msg) => Logger.Warn(ex, msg);

        /// <summary>
        /// Logs error message.
        /// </summary>
        /// <param name="ex">
        /// Exception that needs to be logged.
        /// </param>
        /// <param name="msg">
        /// Message that will be logged.
        /// </param>
        public void Error(Exception ex, string msg) => Logger.Error(ex, msg);
    }
}