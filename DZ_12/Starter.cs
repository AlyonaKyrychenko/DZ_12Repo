namespace DZ_12
{
    using System;

    /// <summary>
    /// This class is for starting program.
    /// </summary>
    public class Starter
    {
        /// <summary>
        /// This method is for starting programm.
        /// </summary>
        public void Run()
        {
            Console.Clear();
            Actions action = new Actions();
            Random rnd = new Random();

            for (int i = 0; i < 100; i++)
            {
                int act = rnd.Next(1, 4);

                switch (act)
                {
                    case 1:
                        action.GenerateInfo();
                        break;

                    case 2:
                        try
                        {
                            action.GenerateWarning();
                            break;
                        }
                        catch (BusinessException e)
                        {
                             if (e.Message == "Skipped logic in method: BusinessException")
                            {
                                Logsys.Logger.AddEvent(LoggerEnum.Warning, $"Action got this custom Exception : BusinessException", true);
                            }
                        }
                        catch (Exception e)
                        {
                            if (e.Message == "Skipped logic in method: BusinessException")
                            {
                                Logsys.Logger.AddEvent(LoggerEnum.Warning, "Exception! Action failed by reason: BusinessException", true);
                            }
                        }

                        break;

                    case 3:
                        try
                        {
                            action.GenerateError();
                            break;
                        }
                        catch (Exception e)
                        {
                            if (e.Message == "I broke a toilet")
                            {
                                Logsys.Logger.AddEvent(LoggerEnum.Error, "Action failed by reason:", true);
                            }
                        }

                        break;
                }
            }

            Logsys.Logger.ShowLog();
            FileService.SingleFileService.SaveDataToFile(Logsys.Logger.Log);
        }
    }
}
