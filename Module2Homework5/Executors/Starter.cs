using Module2Homework5.Base;
using Module2Homework5.Exceptions;

namespace Module2Homework5.Executors
{
    public static class Starter
    {
        private static readonly Random _random = new ();
        public static void Run()
        {
            for (int i = 0; i < 100; i++)
            {
                try
                {
                    var result = ExecuteRandomMethod();
                }
                catch (BusinessException ex)
                {
                    Logger.LoggerInstance.AddToLogs(LogTypes.Warning, "Action got this custom Exception: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Logger.LoggerInstance.AddToLogs(LogTypes.Error, "Action failed by reason: " + ex.Message);
                }
            }

            Logger.LoggerInstance.WriteLogsToFile();
            Logger.LoggerInstance.GetLogs();
            Console.WriteLine(Environment.NewLine + "To get the following log file, restart the program ");
        }

        private static bool ExecuteRandomMethod()
        {
            int currentNumberOfFunction = _random.Next(1, 4);
            return currentNumberOfFunction switch
            {
                1 => Events.Actions.Start(),
                2 => Events.Actions.SkipLogic(),
                _ => Events.Actions.BrokeLogic(),
            };
        }
    }
}
