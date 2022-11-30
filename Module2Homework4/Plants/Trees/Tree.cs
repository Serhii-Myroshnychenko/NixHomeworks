using Module2Homework4.Plants.Base;
using Module2Homework4.Plants.Base.Enums;
using Module2Homework4.Plants.Contracts;

namespace Module2Homework4.Plants.Trees
{
    public class Tree : Plant, IPestController, ITrimmer, IWaterer
    {
        public Tree(string name, double lifeTime, TypeOfTree typeOfTree)
            : base(name, lifeTime)
        {
            Name = name;
            LifeTime = lifeTime;
            TypeOfTree = typeOfTree;
        }

        protected TypeOfTree TypeOfTree { get; init; }

        public void DestroyPests(TypeOfPecticide typeOfPecticide)
        {
            Console.WriteLine($"The {Name} was treated with " + typeOfPecticide);
        }

        public void TrimPlant(TypeOfCut typeOfCut)
        {
            Console.WriteLine($"The {Name} was trimmed with " + typeOfCut);
        }

        public void WaterPlant()
        {
            Console.WriteLine($"The {Name} is watered");
        }

        public override void PrintPlant()
        {
            base.PrintPlant();
            Console.WriteLine("TypeOfTree: " + TypeOfTree);
        }
    }
}
