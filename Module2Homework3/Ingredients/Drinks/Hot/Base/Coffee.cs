using Module2Homework3.Ingredients.Drinks.Hot.Types;

namespace Module2Homework3.Ingredients.Drinks.Hot.Base
{
    public class Coffee : Drink
    {
        public Coffee(
            string name,
            double volume,
            double caloriesPerOneHundredMilliliters,
            CoffeeType type)
            : base(name, volume, caloriesPerOneHundredMilliliters)
        {
            Name = name;
            Volume = volume;
            CaloriesPerOneHundredMilliliters = caloriesPerOneHundredMilliliters;
            Type = type;
        }

        protected CoffeeType Type { get; init; }
        public override void PrintIngredient()
        {
            base.PrintIngredient();
            Console.WriteLine("Type of coffee: " + Type);
        }
    }
}
