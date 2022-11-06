namespace Module2Homework3.Ingredients.Drinks.Alcoholic
{
    public class AlcoholicDrink : Drink
    {
        public AlcoholicDrink(
            string name,
            double volume,
            double caloriesPerOneHundredMilliliters,
            double alcoholLevel)
                : base(name, volume, caloriesPerOneHundredMilliliters)
        {
            Name = name;
            Volume = volume;
            CaloriesPerOneHundredMilliliters = caloriesPerOneHundredMilliliters;
            AlcoholLevel = alcoholLevel;
        }

        protected double AlcoholLevel { get; init; }
        public override void PrintIngredient()
        {
            base.PrintIngredient();
            Console.WriteLine("AlcoholLevel: " + AlcoholLevel);
        }
    }
}
