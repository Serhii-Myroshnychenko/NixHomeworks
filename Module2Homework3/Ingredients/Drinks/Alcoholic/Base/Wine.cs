using Module2Homework3.Ingredients.Drinks.Alcoholic.Types;

namespace Module2Homework3.Ingredients.Drinks.Alcoholic.Base
{
    public class Wine : AlcoholicDrink
    {
        public Wine(
            string name,
            double volume,
            double caloriesPerOneHundredMilliliters,
            double alcoholLevel,
            WineType type)
            : base(name, volume, caloriesPerOneHundredMilliliters, alcoholLevel)
        {
            Name = name;
            Volume = volume;
            CaloriesPerOneHundredMilliliters = caloriesPerOneHundredMilliliters;
            AlcoholLevel = alcoholLevel;
            Type = type;
        }

        protected WineType Type { get; init; }
        public override void PrintIngredient()
        {
            base.PrintIngredient();
            Console.WriteLine("Type of wine: " + Type);
        }
    }
}
