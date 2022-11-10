using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2Homework1
{
    public static class Actions
    {
        public static Result Start()
        {
            string message = "Start method: Start()";
            Logger.LoggerInstance.AddToLogs(LogTypes.Info, message);
            return new Result(true, message);
        }

        public static Result SkipLogic()
        {
            string message = "Skipped logic in method: SkipLogic()";
            Logger.LoggerInstance.AddToLogs(LogTypes.Warning, message);
            return new Result(true, message);
        }

        public static Result BrokeLogic()
        {
            string message = "I broke a logic.";
            return new Result(false, message);
        }
    }
}
