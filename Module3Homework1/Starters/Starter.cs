using Module3Homework1.Collection;
using Module3Homework1.Models;

namespace Module3Homework1.Starters
{
    public static class Starter
    {
        public static void Run()
        {
            Car[] initArray = new Car[] { new ("AUDI A6", 210), new ("Nissan GTR", 300) };
            Car[] range = new Car[] { new ("BMW 530d", 245), new ("AUDI Q7", 212) };
            Car bmw = new ("BMW X5", 220);
            Catalog<Car> cars = new (initArray);

            cars.Add(new ("Mazda RX7", 256));
            cars.Add(bmw);
            cars.AddRange(range);

            Console.WriteLine("Collection after adding new cars:" + Environment.NewLine);
            foreach (var car in cars)
            {
                Console.WriteLine("Name: " + car.Name + ", MaxSpeed: " + car.MaxSpeed);
            }

            Console.WriteLine(Environment.NewLine + "Collection after deleting сars and sorting by maximum speed:" + Environment.NewLine);

            cars.Remove(bmw);
            cars.RemoveAt(2);
            cars.Sort();

            foreach (var car in cars)
            {
                Console.WriteLine("Name: " + car.Name + ", MaxSpeed: " + car.MaxSpeed);
            }
        }
    }
}
