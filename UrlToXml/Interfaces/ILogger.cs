namespace UrlToXml.Interfaces
{
    using System;

    /// <summary>
    /// Interface that every logger class must implement.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Logs information message.
        /// </summary>
        /// <param name="msg">
        /// Message that will be logged.
        /// </param>
        void Info(string msg);

        /// <summary>
        /// Logs warning message.
        /// </summary>
        /// <param name="msg">
        /// Message that will be logged.
        /// </param>
        void Warning(string msg);

        /// <summary>
        /// Logs warning message.
        /// </summary>
        /// <param name="ex">
        /// Exception that needs to be logged.
        /// </param>
        /// <param name="msg">
        /// Message that will be logged.
        /// </param>
        void Warning(Exception ex, string msg);

        /// <summary>
        /// Logs error message.
        /// </summary>
        /// <param name="ex">
        /// Exception that needs to be logged.
        /// </param>
        /// <param name="msg">
        /// Message that will be logged.
        /// </param>
        void Error(Exception ex, string msg);
    }
}