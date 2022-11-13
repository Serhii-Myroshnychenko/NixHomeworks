using System.Text;
namespace Module2Homework6.Cars.Base
{
    public abstract class Vehicle
    {
        public Vehicle(
            string name,
            double price,
            int year,
            Color color,
            int horsepower,
            double consumption)
        {
            Name = name;
            Id = Guid.NewGuid();
            Price = price;
            Year = year;
            Color = color;
            Horsepower = horsepower;
            Consumption = consumption;
        }

        public Guid Id { get; init; }
        public string Name { get; init; }
        public double Price { get; init; }
        public int Year { get; init; }
        public Color Color { get; init; }
        public int Horsepower { get; init; }
        public double Consumption { get; init; }
        public virtual void GetCarInformation()
        {
            StringBuilder info = new ();
            info.AppendLine("Name: " + Name);
            info.AppendLine("Price($): " + Price);
            info.AppendLine("Year: " + Year);
            info.AppendLine("Color: " + Color);
            info.AppendLine("Horesepower: " + Horsepower);
            info.AppendLine("Consumption: " + Consumption);
            Console.Write(info.ToString());
        }
    }
}
