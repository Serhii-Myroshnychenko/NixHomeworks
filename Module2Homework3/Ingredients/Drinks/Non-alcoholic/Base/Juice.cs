using Module2Homework3.Ingredients.Drinks.Non_alcoholic.Types;

namespace Module2Homework3.Ingredients.Drinks.Non_alcoholic
{
    public class Juice : Drink
    {
        public Juice(
            string name,
            double volume,
            double caloriesPerOneHundredMilliliters,
            JuiceType type)
            : base(name, volume, caloriesPerOneHundredMilliliters)
        {
            Name = name;
            Volume = volume;
            CaloriesPerOneHundredMilliliters = caloriesPerOneHundredMilliliters;
            Type = type;
        }

        protected JuiceType Type { get; init; }
        public override void PrintIngredient()
        {
            base.PrintIngredient();
            Console.WriteLine("Type of juice: " + Type);
        }
    }
}
