using Module2Homework4.Plants.Base;
using Module2Homework4.Plants.Base.Enums;

namespace Module2Homework4.Plants.Herbs
{
    public class Herb : Plant
    {
        public Herb(string name, double lifeTime, TypeOfHerb typeOfHerb)
            : base(name, lifeTime)
        {
            Name = name;
            LifeTime = lifeTime;
            TypeOfHerb = typeOfHerb;
        }

        public TypeOfHerb TypeOfHerb { get; init; }
        public override void PrintPlant()
        {
            base.PrintPlant();
            Console.WriteLine("Type of herb: " + TypeOfHerb);
        }
    }
}
