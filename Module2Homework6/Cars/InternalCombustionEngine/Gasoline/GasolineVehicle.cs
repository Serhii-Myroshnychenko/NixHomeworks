using Module2Homework6.Cars.Base;

namespace Module2Homework6.Cars.InternalCombustionEngine.Gasoline
{
    public class GasolineVehicle : CombustionEngineVehicle
    {
        public GasolineVehicle(
            string name,
            double price,
            int year,
            Color color,
            int horsepower,
            bool isTurbocharged,
            double consumption,
            double engineVolume)
            : base(
                name,
                price,
                year,
                color,
                horsepower,
                isTurbocharged,
                consumption,
                TypeOfFuel.Gasoline,
                engineVolume)
        {
            Name = name;
            Price = price;
            Year = year;
            Color = color;
            Horsepower = horsepower;
            IsTurbocharged = isTurbocharged;
            Consumption = consumption;
            TypeOfFuel = TypeOfFuel.Gasoline;
            EngineVolume = engineVolume;
        }
    }
}
