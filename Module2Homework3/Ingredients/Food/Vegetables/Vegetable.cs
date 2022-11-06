namespace Module2Homework3.Ingredients.Food.Vegetables
{
    public class Vegetable : Food
    {
        public Vegetable(
            string name,
            double weight,
            double caloriesPerOneHundredGrams,
            int count)
            : base(name, weight, caloriesPerOneHundredGrams)
        {
            Name = name;
            Weight = weight;
            CaloriesPerOneHundredGrams = caloriesPerOneHundredGrams;
            Count = count;
        }

        protected int Count { get; init; }
        public override void PrintIngredient()
        {
            base.PrintIngredient();
            Console.WriteLine("Count: " + Count);
        }
    }
}
