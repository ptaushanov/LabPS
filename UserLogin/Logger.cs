using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UserLogin
{
    static internal class Logger
    {
        static private List<string> currentSessionActivities = new List<string>();
        private const string logFilePath = "log.txt";

        static public void LogActivity(string activity)
        {
            string activityLine = DateTime.Now + ";"
            + LoginValidation.currentUserUsername + ";"
            + LoginValidation.currentUserRole + ";"
            + activity + Environment.NewLine;

            currentSessionActivities.Add(activityLine);

            if (File.Exists(logFilePath))
            {
                File.AppendAllText(logFilePath, activityLine);
            }
        }

        static public void GetCurrentSessionActivities()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (string activityLine in currentSessionActivities)
            {
                stringBuilder.Append(activityLine);
            }
            Console.WriteLine(stringBuilder.ToString());
        }

        static public void ShowLogFileActivities()
        {
            StreamReader reader = new StreamReader(logFilePath);
            StringBuilder stringBuilder = new StringBuilder();

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                stringBuilder.AppendLine(line);
            }

            Console.WriteLine(stringBuilder.ToString());
            reader.Close();
        }

        public delegate void Callback(string removedLine);
        static public void RemoveOldLogs(DateTime beforeDateTime, Callback OnLogRemoved)
        {
            StreamReader reader = new StreamReader(logFilePath);
            StringBuilder builder = new StringBuilder();

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] parts = line.Split(new char[] { ';' });
                string logDateTimeString = parts[0];

                DateTime logDateTime = DateTime.Parse(logDateTimeString);

                if (logDateTime < beforeDateTime)
                {
                    OnLogRemoved?.Invoke(line);
                    continue;
                }
                builder.AppendLine(line);
            }

            reader.Close();

            StreamWriter writer = new StreamWriter(logFilePath);
            writer.Write(builder.ToString());
            writer.Close();
        }
    }
}
