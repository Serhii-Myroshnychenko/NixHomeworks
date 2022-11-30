using Module2Homework4.Plants.Base;
using Module2Homework4.Plants.Base.Enums;
using Module2Homework4.Plants.Contracts;

namespace Module2Homework4.Plants.Shrubs
{
    public class Shrub : Plant, IWaterer
    {
        public Shrub(string name, double lifeTime, TypeOfHabitat typeOfHabitat)
            : base(name, lifeTime)
        {
            Name = name;
            LifeTime = lifeTime;
            TypeOfHabitat = typeOfHabitat;
        }

        public TypeOfHabitat TypeOfHabitat { get; init; }

        public void WaterPlant()
        {
            Console.WriteLine($"The {Name} is watered");
        }

        public override void PrintPlant()
        {
            base.PrintPlant();
            Console.WriteLine("Type of habitat: " + TypeOfHabitat);
        }
    }
}
