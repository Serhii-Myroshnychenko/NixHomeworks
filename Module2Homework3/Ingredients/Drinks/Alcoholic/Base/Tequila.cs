using Module2Homework3.Ingredients.Drinks.Alcoholic.Types;
namespace Module2Homework3.Ingredients.Drinks.Alcoholic.Base
{
    public class Tequila : AlcoholicDrink
    {
        public Tequila(
            string name,
            double volume,
            double caloriesPerOneHundredMilliliters,
            double alcoholLevel,
            TequilaType type)
            : base(name, volume, caloriesPerOneHundredMilliliters, alcoholLevel)
        {
            Name = name;
            Volume = volume;
            CaloriesPerOneHundredMilliliters = caloriesPerOneHundredMilliliters;
            AlcoholLevel = alcoholLevel;
            Type = type;
        }

        protected TequilaType Type { get; init; }
        public override void PrintIngredient()
        {
            base.PrintIngredient();
            Console.WriteLine("Type of tequila: " + Type);
        }
    }
}
