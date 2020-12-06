namespace DZ_12
{
    using System;

    /// <summary>
    /// This is for custom exception.
    /// </summary>
    public class BusinessException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessException"/> class.
        /// </summary>
        /// <param name="loggerEnum">(LoggerEnum loggerEnum.</param>
        /// <param name="message">string message.</param>
        public BusinessException(LoggerEnum loggerEnum, string message)
            : base(message)
        {
        }
    }
}
