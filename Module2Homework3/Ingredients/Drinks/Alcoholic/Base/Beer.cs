using Module2Homework3.Ingredients.Drinks.Alcoholic.Types;
namespace Module2Homework3.Ingredients.Drinks.Alcoholic.Base
{
    public class Beer : AlcoholicDrink
    {
        public Beer(
            string name,
            double volume,
            double caloriesPerOneHundredMilliliters,
            double alcoholLevel,
            BeerType type)
            : base(name, volume, caloriesPerOneHundredMilliliters, alcoholLevel)
        {
            Name = name;
            Volume = volume;
            CaloriesPerOneHundredMilliliters = caloriesPerOneHundredMilliliters;
            AlcoholLevel = alcoholLevel;
            Type = type;
        }

        protected BeerType Type { get; init; }
        public override void PrintIngredient()
        {
            base.PrintIngredient();
            Console.WriteLine("Type of beer: " + Type);
        }
    }
}
