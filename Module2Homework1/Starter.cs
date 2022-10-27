using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2Homework1
{
    public static class Starter
    {
        private static Random _random = new Random();
        public static void Run()
        {
            for (int i = 0; i < 100; i++)
            {
                var result = ExecuteRandomMethod();

                if (result.Status == false)
                {
                    Logger.LoggerInstance.AddToLogs(LogTypes.Error, "Action failed by a reason." + result.Message);
                }
            }

            Logger.LoggerInstance.GetLogs();
            Logger.LoggerInstance.WriteLogsToFile();
        }

        private static Result ExecuteRandomMethod()
        {
            int currentNumberOfFunction = _random.Next(1, 4);
            switch (currentNumberOfFunction)
            {
                case 1:
                    return Actions.Start();
                case 2:
                    return Actions.SkipLogic();
                default:
                    return Actions.BrokeLogic();
            }
        }
    }
}
