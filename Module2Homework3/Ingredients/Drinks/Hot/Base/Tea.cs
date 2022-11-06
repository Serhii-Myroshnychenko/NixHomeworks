using Module2Homework3.Ingredients.Drinks.Hot.Types;

namespace Module2Homework3.Ingredients.Drinks.Hot.Base
{
    public class Tea : Drink
    {
        public Tea(
            string name,
            double volume,
            double caloriesPerOneHundredMilliliters,
            TeaType type)
            : base(name, volume, caloriesPerOneHundredMilliliters)
        {
            Name = name;
            Volume = volume;
            CaloriesPerOneHundredMilliliters = caloriesPerOneHundredMilliliters;
            Type = type;
        }

        protected TeaType Type { get; init; }
        public override void PrintIngredient()
        {
            base.PrintIngredient();
            Console.WriteLine("Type of tea: " + Type);
        }
    }
}
