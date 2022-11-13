using Module2Homework6.Cars.Base;
using Module2Homework6.Fleets;

namespace Module2Homework6.Extensions
{
    public static class FleetExtension
    {
        public static Vehicle? GetVehicleById(this CarsFleet fleet, Guid id)
        {
            return fleet.Vehicles.Where(i => i.Id == id).FirstOrDefault();
        }

        public static Vehicle? GetVechicleByName(this CarsFleet fleet, string name)
        {
            return fleet.Vehicles.Where(i => i.Name.ToLower() == name.ToLower()).FirstOrDefault();
        }

        public static CarsFleet SortVehiclesByName(this CarsFleet fleet)
        {
            fleet.Vehicles = fleet.Vehicles.OrderBy(i => i.Name).ToArray();
            return fleet;
        }

        public static CarsFleet SortVehiclesByConsumption(this CarsFleet fleet)
        {
            fleet.Vehicles = fleet.Vehicles.OrderBy(i => i.Consumption).ToArray();
            return fleet;
        }

        public static CarsFleet SortVehiclesByConsumptionInDescendingOrder(this CarsFleet fleet)
        {
            fleet.Vehicles = fleet.Vehicles.OrderByDescending(i => i.Consumption).ToArray();
            return fleet;
        }
    }
}
