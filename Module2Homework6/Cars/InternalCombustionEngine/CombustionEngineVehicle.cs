using Module2Homework6.Cars.Base;
using Module2Homework6.Cars.EngineContracts;

namespace Module2Homework6.Cars.InternalCombustionEngine
{
    public class CombustionEngineVehicle : Vehicle, ICombustionEngine
    {
        public CombustionEngineVehicle(
            string name,
            double price,
            int year,
            Color color,
            int horsepower,
            bool isTurbocharged,
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
            IsTurbocharged = isTurbocharged;
            FuelLevel = 90;
            TypeOfFuel = typeOfFuel;
            Consumption = consumption;
            EngineVolume = engineVolume;
        }

        public TypeOfFuel TypeOfFuel { get; init; }
        public double EngineVolume { get; init; }
        protected bool IsTurbocharged { get; init; }
        protected int FuelLevel { get; set; }
        public virtual void ChangeFuelFilter() => Console.WriteLine("The fuel filter changed");
        public virtual void ChangeOilFilter() => Console.WriteLine("The oil filter changed");
        public virtual int GetFuelLevel() => FuelLevel;
        public virtual void FillUpCar()
        {
            FuelLevel = 100;
            Console.WriteLine($"{TypeOfFuel} filled");
        }

        public override void GetCarInformation()
        {
            base.GetCarInformation();
            Console.WriteLine("IsTurbocharged: " + IsTurbocharged);
            Console.WriteLine("FuelLevel: " + FuelLevel);
            Console.WriteLine("TypeOfFuel: " + TypeOfFuel);
            Console.WriteLine("EngineVolume: " + EngineVolume);
        }
    }
}
