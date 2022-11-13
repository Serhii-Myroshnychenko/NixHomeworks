using Module2Homework6.Cars.Base;

namespace Module2Homework6.Contracts
{
    public interface ICarsFleet
    {
        void GetListOfCars();
        void AddCarToCarsFleet(Vehicle vehicle);
        void RemoveCarFromCarsFleet(Vehicle vehicle);
        double GetTotalPriceOfCarsFleet();
    }
}
