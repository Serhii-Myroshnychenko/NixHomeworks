using Module2Homework4.Exceptions;
using Module2Homework4.Plants.Base.Enums;
using Module2Homework4.Plants.Contracts;

namespace Module2Homework4.Plants.Trees.FruitTree
{
    public class FruitTree : Tree, IGatherer
    {
        public FruitTree(
            string name,
            double lifeTime,
            TypeOfTree typeOfTree,
            string nameOfFruit,
            DateTime ripeningTime)
            : base(name, lifeTime, typeOfTree)
        {
            Name = name;
            LifeTime = lifeTime;
            TypeOfTree = typeOfTree;
            NameOfFruit = nameOfFruit;
            RipeningTime = ripeningTime;
        }

        public string NameOfFruit { get; init; }
        public DateTime RipeningTime { get; init; }
        public void HarvestFruits()
        {
            if (!IsRipe())
            {
                throw new HarvestException($"{NameOfFruit} are unripe");
            }

            Console.WriteLine($"{NameOfFruit} are harvested");
        }

        public bool IsRipe()
        {
            return DateTime.Now >= RipeningTime;
        }

        public override void PrintPlant()
        {
            base.PrintPlant();
            Console.WriteLine("Name of the fruit: " + NameOfFruit);
            Console.WriteLine("Ripening time: " + RipeningTime);
        }
    }
}
