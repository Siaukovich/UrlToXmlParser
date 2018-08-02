namespace UrlToXml
{
    using System;
    using System.Threading;

    using UrlToXml.Interfaces;

    /// <summary>
    /// Logger that uses NLog internally.
    /// </summary>
    public class NLogLogger : ILogger
    {
        /// <summary>
        /// The lazy logger for singleton behavior.
        /// </summary>
        private static readonly Lazy<NLogLogger> LazyLogger =
            new Lazy<NLogLogger>(LazyThreadSafetyMode.PublicationOnly);

        /// <summary>
        /// NLog logger.
        /// </summary>
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Prevents a default instance of the <see cref="NLogLogger"/> class from being created.
        /// </summary>
        private NLogLogger()
        {
        }

        /// <summary>
        /// Singleton instance of NLogLogger.
        /// </summary>
        public static NLogLogger Instance => LazyLogger.Value;

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