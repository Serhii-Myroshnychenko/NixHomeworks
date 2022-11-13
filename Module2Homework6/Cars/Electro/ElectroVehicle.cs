using Module2Homework6.Cars.Base;
using Module2Homework6.Cars.EngineContracts;

namespace Module2Homework6.Cars.Electro
{
    public class ElectroVehicle : Vehicle, IElectroEngine
    {
        public ElectroVehicle(
            string name,
            double price,
            int year,
            Color color,
            int horsepower,
            double consumption)
            : base(name, price, year, color, horsepower, consumption)
        {
            Name = name;
            Price = price;
            Year = year;
            Color = color;
            Horsepower = horsepower;
            BatteryLevel = 90;
            Consumption = consumption;
        }

        protected int BatteryLevel { get; set; }
        public void ChangeBattery() => Console.WriteLine("Battery changed");
        public void ChargeBattery() => BatteryLevel = 100;
        public int GetBatteryCharge() => BatteryLevel;
        public override void GetCarInformation()
        {
            base.GetCarInformation();
            Console.WriteLine("BatteryLevel: " + BatteryLevel);
        }
    }
}
