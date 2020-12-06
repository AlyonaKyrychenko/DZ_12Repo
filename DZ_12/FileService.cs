namespace DZ_12
{
    using System;
    using System.IO;

    /// <summary>
    /// This is for working with files.
    /// </summary>
    public class FileService
    {
        private static FileService instance = null;

        private FileService()
        {
        }

        /// <summary>
        /// Gets singleton.
        /// </summary>
        public static FileService SingleFileService
        {
            get
            {
                if (Instance == null)
                {
                    Instance = new FileService();
                }

                return Instance;
            }
        }

        /// <summary>
        /// Gets or sets Instance.
        /// </summary>
        public static FileService Instance { get => instance; set => instance = value; }

        /// <summary>
        /// This is for saving data to file.
        /// </summary>
        /// <param name="fileContent">string[] fileContent.</param>
        public void SaveDataToFile(string[] fileContent)
        {
            string dirPath = LocationConstants.DirPath;

            DirectoryInfo dirInfo = new DirectoryInfo(dirPath);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            this.FileGarbageCollector(dirPath);

            string writePath = $"{dirPath}\\{DateTime.Now.ToString("hh.mm.ss.dd.MM.yyyy")}.txt";

            FileInfo fileInfo = new FileInfo(writePath);
            if (!fileInfo.Exists)
            {
                try
                {
                    using StreamWriter str = new StreamWriter(writePath, false, System.Text.Encoding.Default);
                    foreach (string content in fileContent)
                    {
                        str.WriteLine(content);
                    }

                    str.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        /// <summary>
        /// This is for removing files.
        /// </summary>
        /// <param name="fileNameWithFullPath">string fileNameWithFullPath.</param>
        public void RemoveFile(string fileNameWithFullPath)
        {
            File.Delete(fileNameWithFullPath);
        }

        private void FileGarbageCollector(string dirPath)
        {
            int maxAgeOfFiles = LocationConstants.MaxAgeOfFilesValue;
            int maxCountOfFiles = LocationConstants.MaxCountOfFilesValue;

            DirectoryInfo dirInfo = new DirectoryInfo(dirPath);
            FileInfo[] dirContent = dirInfo.GetFiles("*.txt*");
            int countOfFiles = dirContent.Length;

            while (dirContent.Length > maxCountOfFiles)
            {
                this.RemoveFile(dirContent[dirContent.Length - 1].FullName);
                Array.Resize(ref dirContent, dirContent.Length - 1);
            }

            string fileName = string.Empty;
            DateTime fileData;
            int yy, mm, dd, hh, min, ss, fileAge;
            foreach (FileInfo file in dirContent)
            {
                fileName = file.Name;
                yy = Convert.ToInt32(fileName.Substring(15, 4));
                mm = Convert.ToInt32(fileName.Substring(12, 2));
                dd = Convert.ToInt32(fileName.Substring(9, 2));
                hh = Convert.ToInt32(fileName.Substring(0, 2));
                min = Convert.ToInt32(fileName.Substring(3, 2));
                ss = Convert.ToInt32(fileName.Substring(6, 2));

                fileData = new DateTime(yy, mm, dd, hh, min, ss);
                TimeSpan interval = DateTime.Now - fileData;
                fileAge = interval.Days;

                if (fileAge > maxAgeOfFiles)
                {
                    this.RemoveFile(file.FullName);
                }
            }
        }
    }
}
