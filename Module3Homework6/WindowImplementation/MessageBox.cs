using Module3Homework6.Base.Enums;
using Module3Homework6.Utils;

namespace Module3Homework6.WindowImplementation
{
    public class MessageBox
    {
        public MessageBox()
        {
            ProcessCompleted += ConfirmOperation;
        }

        public delegate void Notify(State state);
        public event Notify ProcessCompleted;

        public async Task Open()
        {
            await Task.Run(async () =>
            {
                Console.WriteLine("Window is open");
                await Task.Delay(3000);
                Console.WriteLine("User has closed the window");
                ProcessCompleted?.Invoke(StateGenerator.GenerateState());
            });
        }

        public static void ConfirmOperation(State state)
        {
            switch (state)
            {
                case State.Ok:
                    Console.WriteLine("Ok");
                    break;
                case State.Cancel:
                    Console.WriteLine("Cancel");
                    break;
                default:
                    break;
            }
        }
    }
}
