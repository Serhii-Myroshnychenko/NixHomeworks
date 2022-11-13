using Module2Homework6.Cars.Base;
using Module2Homework6.Cars.EngineContracts;

namespace Module2Homework6.Cars.Hybrid
{
    public class HybridVehicle : Vehicle, ICombustionEngine, IElectroEngine
    {
        public HybridVehicle(
            string name,
            double price,
            int year,
            Color color,
            int horsepower,
            double consumption,
            TypeOfFuel typeOfFuel,
            double engineVolume)
            : base(name, price, year, color, horsepower, consumption)
        {
            Name = name;
            Price = price;
            Year = year;
            Color = color;
            Horsepower = horsepower;
            FuelLevel = 90;
            BatteryLevel = 50;
            Consumption = consumption;
            TypeOfFuel = typeOfFuel;
            EngineVolume = engineVolume;
        }

        public TypeOfFuel TypeOfFuel { get; init; }
        public double EngineVolume { get; init; }
        protected int FuelLevel { get; set; }
        protected int BatteryLevel { get; set; }
        public virtual void ChangeBattery() => Console.WriteLine("Battery changed.");
        public virtual void ChangeFuelFilter() => Console.WriteLine("Fuel filter changed");
        public virtual void ChangeOilFilter() => Console.WriteLine("Oil filter changed");
        public virtual int GetFuelLevel() => FuelLevel;
        public virtual int GetBatteryCharge() => BatteryLevel;
        public virtual void ChargeBattery() => BatteryLevel = 100;
        public virtual void FillUpCar()
        {
            FuelLevel = 100;
            Console.WriteLine($"{TypeOfFuel} filled");
        }

        public override void GetCarInformation()
        {
            base.GetCarInformation();
            Console.WriteLine("FuelLevel: " + FuelLevel);
            Console.WriteLine("BatteryLevel: " + BatteryLevel);
            Console.WriteLine("TypeOfFuel: " + TypeOfFuel);
            Console.WriteLine("EngineVolume: " + EngineVolume);
        }
    }
}
