namespace DZ_12
{
    using System;

    /// <summary>
    /// This is class for writing to log.
    /// </summary>
    public class Logsys
    {
        private static Logsys instance = null;

        private string[] log = new string[0];

        private Logsys()
        {
        }

        /// <summary>
        /// Gets singleton.
        /// </summary>
        public static Logsys Logger
        {
            get
            {
                if (instance == null)
                {
                    instance = new Logsys();
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets or sets this logger.
        /// </summary>
        public string[] Log { get => this.log; set => this.log = value; }

        /// <summary>
        /// This is for adding new element of logger.
        /// </summary>
        /// <param name="severity">LoggerEnum severity.</param>
        /// <param name="text">string text.</param>
        /// <param name="needTrace">bool needTrace.</param>
        public void AddEvent(LoggerEnum severity, string text, bool needTrace)
        {
            DateTime timeNow = DateTime.Now;
            int size = this.Log.Length;
            Array.Resize(ref this.log, size + 1);
            if (needTrace)
            {
                this.Log[size] = $"{{{timeNow.ToString("T")}}}:{{{severity.ToString()}}}:{{{text}}}\n{Environment.StackTrace}";
            }
            else
            {
                this.Log[size] = $"{{{timeNow.ToString("T")}}}:{{{severity.ToString()}}}:{{{text}}})";
            }
        }

        /// <summary>
        /// This is for adding new element of logger.
        /// </summary>
        /// <param name="severity">LoggerEnum severity.</param>
        /// <param name="text">string text.</param>
        public void AddEvent(LoggerEnum severity, string text)
        {
            DateTime timeNow = DateTime.Now;
            int size = this.Log.Length;
            Array.Resize(ref this.log, size + 1);
            this.Log[size] = $"{{{timeNow.ToString("T")}}}:{{{severity.ToString()}}}:{{{text}}})";
        }

        /// <summary>
        /// This is for showing logger info.
        /// </summary>
        public void ShowLog()
        {
            foreach (string logRecord in this.Log)
            {
                Console.WriteLine(logRecord);
            }

            Console.WriteLine($"Count records in log {this.Log.Length.ToString()}");
            Console.ReadKey();
        }
    }
}
