using Module2Homework5.Base;
using Module2Homework5.Exceptions;

namespace Module2Homework5
{
    public static class Starter
    {
        private static Random _random = new Random();
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
                    Logger.LoggerInstance.WriteLogToFile(LogTypes.Warning, "Action got this custom Exception: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Logger.LoggerInstance.WriteLogToFile(LogTypes.Error, "Action failed by reason: " + ex.Message);
                }
            }
        }

        private static bool ExecuteRandomMethod()
        {
            int currentNumberOfFunction = _random.Next(1, 4);
            switch (currentNumberOfFunction)
            {
                case 1:
                    return Events.Actions.Start();
                case 2:
                    return Events.Actions.SkipLogic();
                default:
                    return Events.Actions.BrokeLogic();
            }
        }
    }
}
