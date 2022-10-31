using System.Text;
using Module2Homework2.Items.Base;

namespace Module2Homework2.Items
{
    public class Phone : Product
    {
        public Phone(Guid id, string name, int count, string screenDiagonal, string displayType, string camera, string processor, string batteryCapacity, int memory, decimal price, Color color)
            : base(name, count, id)
        {
            ScreenDiagonal = screenDiagonal;
            DisplayType = displayType;
            Camera = camera;
            Processor = processor;
            BatteryCapacity = batteryCapacity;
            Memory = memory;
            Price = price;
            Color = color;
        }

        public string ScreenDiagonal { get; set; } = string.Empty;
        public string DisplayType { get; set; } = string.Empty;
        public string Camera { get; set; } = string.Empty;
        public string Processor { get; set; } = string.Empty;
        public string BatteryCapacity { get; set; } = string.Empty;
        public int Memory { get; set; }
        public decimal Price { get; set; }
        public Color Color { get; set; }
        public override void PrintDescription()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Назва: " + Name);
            stringBuilder.AppendLine("Диагональ єкрану: " + ScreenDiagonal);
            stringBuilder.AppendLine("Тип дисплею: " + DisplayType);
            stringBuilder.AppendLine("Камера: " + Camera);
            stringBuilder.AppendLine("Процесор: " + Processor);
            stringBuilder.AppendLine("Вмiст батареї: " + BatteryCapacity);
            stringBuilder.AppendLine("Пам'ять(Gb): " + Memory);
            stringBuilder.AppendLine("Цiна($): " + Price);
            stringBuilder.AppendLine("Колiр: " + Color);

            Console.WriteLine(stringBuilder.ToString());
        }

        public override string ToString()
        {
            System.Text.StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(Id.ToString() + ",");
            stringBuilder.Append(Name + ",");
            stringBuilder.Append(Count + ",");
            stringBuilder.Append(ScreenDiagonal + ",");
            stringBuilder.Append(DisplayType + ",");
            stringBuilder.Append(Camera + ",");
            stringBuilder.Append(Processor + ",");
            stringBuilder.Append(BatteryCapacity + ",");
            stringBuilder.Append(Memory.ToString() + ",");
            stringBuilder.Append(Price.ToString() + ",");
            stringBuilder.Append(Color.ToString());

            return stringBuilder.ToString();
        }
    }
}
