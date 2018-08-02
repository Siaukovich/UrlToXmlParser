namespace UrlToXml
{
    using System;
    using System.Threading;

    using UrlToXml.Interfaces;

    /// <summary>
    /// The logger service.
    /// </summary>
    public class LoggerService : ILoggerService
    {
        /// <summary>
        /// Lazy logger.
        /// </summary>
        private static readonly Lazy<LoggerService> LazyLoggerService =
            new Lazy<LoggerService>(LazyThreadSafetyMode.PublicationOnly);

        /// <summary>
        /// Singleton instance.
        /// </summary>
        public static LoggerService Instance => LazyLoggerService.Value;

        /// <summary>
        /// Gets or sets service's logger.
        /// </summary>
        public ILogger Logger { get; set; } = NLogLogger.Instance;

        /// <summary>
        /// Logs information message.
        /// </summary>
        /// <param name="msg">
        /// Message that will be logged.
        /// </param>
        public void Info(string msg)
        {
            this.ThrowForNullLogger();
            this.ThrowForNull(msg, nameof(msg));

            this.Logger.Info(msg);
        }

        /// <summary>
        /// Logs warning message.
        /// </summary>
        /// <param name="msg">
        /// Message that will be logged.
        /// </param>
        public void Warning(string msg)
        {
            this.ThrowForNullLogger();
            this.ThrowForNull(msg, nameof(msg));

            this.Logger.Warning(msg);
        }

        /// <summary>
        /// Logs warning message.
        /// </summary>
        /// <param name="ex">
        /// Exception that needs to be logged.
        /// </param>
        /// <param name="msg">
        /// Message that will be logged.
        /// </param>
        public void Warning(Exception ex, string msg)
        {
            this.ThrowForNullLogger();
            this.ThrowForNull(msg, nameof(msg));
            this.ThrowForNull(ex, nameof(ex));

            this.Logger.Warning(ex, msg);
        }

        /// <summary>
        /// Logs error message.
        /// </summary>
        /// <param name="ex">
        /// Exception that needs to be logged.
        /// </param>
        /// <param name="msg">
        /// Message that will be logged.
        /// </param>
        public void Error(Exception ex, string msg)
        {
            this.ThrowForNull(msg, nameof(msg));
            this.ThrowForNull(ex, nameof(ex));
            this.ThrowForNullLogger();

            this.Logger.Warning(msg);
        }

        /// <summary>
        /// Throws if passed object is null.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        /// <param name="objName">
        /// Obj name.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if passed object is null
        /// </exception>
        private void ThrowForNull(object obj, string objName)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(objName);
            }
        }

        /// <summary>
        /// Throw if service's logger is null.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Thrown if service's logger is null.
        /// </exception>
        private void ThrowForNullLogger()
        {
            if (this.Logger == null)
            {
                throw new InvalidOperationException("Logger is null.");
            }
        }
    }
}