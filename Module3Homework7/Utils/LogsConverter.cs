using System.Text;

namespace Module3Homework7.Utils
{
    public static class LogsConverter
    {
        public static string ConvertLogs(string[] logs)
        {
            StringBuilder stringBuilder = new ();
            for(int i = 0; i < logs.Length; i++)
            {
                stringBuilder.AppendLine(logs[i]);
            }
            return stringBuilder.ToString();
        }
    }
}
