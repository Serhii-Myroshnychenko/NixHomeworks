using Module2Homework6.Cars.Base;
using Module2Homework6.Contracts;

namespace Module2Homework6.Fleets
{
    public class CarsFleet : ICarsFleet
    {
        public CarsFleet()
        {
            Vehicles = Array.Empty<Vehicle>();
        }

        public Vehicle[] Vehicles { get; set; }

        public void AddCarToCarsFleet(Vehicle vehicle)
        {
            Vehicle[] result = new Vehicle[Vehicles.Length + 1];
            for (int i = 0; i < Vehicles.Length; i++)
            {
                result[i] = Vehicles[i];
            }

            result[Vehicles.Length] = vehicle;
            Vehicles = result;
        }

        public void GetListOfCars()
        {
            Console.WriteLine("Cars: " + Environment.NewLine);

            foreach (Vehicle vehicle in Vehicles)
            {
                vehicle.GetCarInformation();
                Console.WriteLine();
            }
        }

        public double GetTotalPriceOfCarsFleet()
        {
            double total = 0;
            foreach (Vehicle vehicle in Vehicles)
            {
                total += vehicle.Price;
            }

            return total;
        }

        public void RemoveCarFromCarsFleet(Vehicle vehicle)
        {
            int pointer = GetIndexOfVehicle(vehicle);
            if (pointer != -1)
            {
                Vehicle[] result = new Vehicle[Vehicles.Length - 1];
                int index = 0;
                for (int i = 0; i < Vehicles.Length; i++)
                {
                    if (i != pointer)
                    {
                        result[index++] = Vehicles[i];
                    }
                }

                Vehicles = result;
            }
            else
            {
                Console.WriteLine("There is no such a car");
            }
        }

        private int GetIndexOfVehicle(Vehicle vehicle)
        {
            for (int i = 0; i < Vehicles.Length; i++)
            {
                if (Vehicles[i].Id == vehicle.Id)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
