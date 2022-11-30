using System.Text;

namespace Module2Homework4.Plants.Base
{
    public abstract class Plant
    {
        public Plant(string name, double lifeTime)
        {
            Id = Guid.NewGuid();
            Name = name;
            LifeTime = lifeTime;
            PlantingTime = DateTime.Now;
        }

        public Guid Id { get; init; }
        public string Name { get; init; }
        public double LifeTime { get; init; }
        public DateTime PlantingTime { get; init; }
        public virtual void PrintPlant()
        {
            StringBuilder info = new ();
            info.AppendLine("Name: " + Name);
            info.AppendLine("LifeTime(years): " + LifeTime);
            Console.Write(info.ToString());
        }
    }
}
