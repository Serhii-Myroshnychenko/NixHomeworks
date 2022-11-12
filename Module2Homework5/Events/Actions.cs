using Module2Homework5.Base;
using Module2Homework5.Exceptions;

namespace Module2Homework5.Events
{
    public static class Actions
    {
        public static bool Start()
        {
            Logger.LoggerInstance.WriteLogToFile(LogTypes.Info, "Start method: Start()");
            return true;
        }

        public static bool SkipLogic() => throw new BusinessException("Skipped logic in method: SkipLogic()");

        public static bool BrokeLogic() => throw new Exception("I broke a logic.");
    }
}
