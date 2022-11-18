using System.Text;

namespace Module2Homework5.Utils
{
    public static class Converter
    {
        public static string ConvertLogsToText(string[] logs)
        {
            StringBuilder stringBuilder = new ();
            for (int i = 0; i < logs.Length; i++)
            {
                stringBuilder.AppendLine(logs[i]);
            }

            return stringBuilder.ToString();
        }
    }
}
