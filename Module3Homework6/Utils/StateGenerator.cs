using Module3Homework6.Base.Enums;

namespace Module3Homework6.Utils
{
    public static class StateGenerator
    {
        private static readonly Random _random;
        static StateGenerator()
        {
            _random = new Random();
        }

        public static State GenerateState()
        {
            return (State)_random.Next(Enum.GetNames(typeof(State)).Length);
        }
    }
}
