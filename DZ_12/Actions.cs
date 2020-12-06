namespace DZ_12
{
    using System;

    /// <summary>
    /// This is class for actions.
    /// </summary>
    public class Actions
    {
        /// <summary>
        /// This is for generate info.
        /// </summary>
        public void GenerateInfo()
        {
            Logsys.Logger.AddEvent(LoggerEnum.Info, "Start method: nameof(GenerateInfo)");
        }

        /// <summary>
        /// This is for generate warning.
        /// </summary>
        public void GenerateWarning()
        {
            throw new BusinessException(LoggerEnum.Warning, "Skipped logic in method: BusinessException");
        }

        /// <summary>
        /// This is for generate error.
        /// </summary>
        public void GenerateError()
        {
            throw new Exception("I broke a toilet");
        }
    }
}
