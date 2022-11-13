using Module2Homework6.Cars.Base;
using Module2Homework6.Cars.Electro;
using Module2Homework6.Cars.Hybrid;
using Module2Homework6.Cars.InternalCombustionEngine.Diesel;
using Module2Homework6.Cars.InternalCombustionEngine.Gas;
using Module2Homework6.Cars.InternalCombustionEngine.Gasoline;
using Module2Homework6.Extensions;
using Module2Homework6.Fleets;

ElectroVehicle car = new ElectroVehicle("Tesla Model 3", 50000, 2017, Color.White, 440, 16.5);
HybridVehicle car1 = new HybridVehicle("BMW i8", 45000, 2015, Color.Yellow, 178, 7.8, TypeOfFuel.Gasoline, 1.8);
GasolineVehicle car2 = new GasolineVehicle("BMW X5", 12000, 2010, Color.Black, 215, true, 12.5, 2.8);
DieselVehicle car3 = new DieselVehicle("BMW 530d", 67000, 2018, Color.Black, 340, true, 10.5, 3.0);
GasVehicle car4 = new GasVehicle("Volga 2109", 1200, 1997, Color.Green, 87, false, 7.8, 1.5);

CarsFleet fleet = new CarsFleet();
fleet.AddCarToCarsFleet(car);
fleet.AddCarToCarsFleet(car1);
fleet.AddCarToCarsFleet(car2);
fleet.AddCarToCarsFleet(car3);
fleet.AddCarToCarsFleet(car4);

fleet.GetListOfCars();

Console.WriteLine("Total price of cars: " + fleet.GetTotalPriceOfCarsFleet());
Console.WriteLine("-----------------------------");

Console.WriteLine("Search car by name: BMW 530d" + Environment.NewLine);
var bmw = fleet.GetVechicleByName("BMW 530d");
bmw!.GetCarInformation();
Console.WriteLine("-----------------------------");

Console.WriteLine("Sort by consumption: " + Environment.NewLine);
fleet.SortVehiclesByConsumption();
fleet.GetListOfCars();