using Module2Homework4.Plants.Base.Enums;

namespace Module2Homework4.Plants.Trees.DecorativeTree
{
    public class DecorativeTree : Tree
    {
        public DecorativeTree(string name, double lifeTime, TypeOfTree typeOfTree, string flower)
            : base(name, lifeTime, typeOfTree)
        {
            Name = name;
            LifeTime = lifeTime;
            TypeOfTree = typeOfTree;
            Flower = flower;
        }

        public string Flower { get; init; }
        public override void PrintPlant()
        {
            base.PrintPlant();
            Console.WriteLine("Flower: " + Flower);
        }
    }
}
