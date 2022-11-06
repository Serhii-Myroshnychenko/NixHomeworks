namespace Module2Homework3.Ingredients.Drinks.Hot
{
    public class HotDrink : Drink
    {
        public HotDrink(
            string name,
            double volume,
            double caloriesPerOneHundredMilliliters,
            double сelsiusTemperature)
            : base(name, volume, caloriesPerOneHundredMilliliters)
        {
            Name = name;
            Volume = volume;
            CaloriesPerOneHundredMilliliters = caloriesPerOneHundredMilliliters;
            CelsiusTemperature = сelsiusTemperature;
        }

        protected double CelsiusTemperature { get; init; }
        public override void PrintIngredient()
        {
            base.PrintIngredient();
            Console.WriteLine("Temperature: " + CelsiusTemperature);
        }
    }
}
