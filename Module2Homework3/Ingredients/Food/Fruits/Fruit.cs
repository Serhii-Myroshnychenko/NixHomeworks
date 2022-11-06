namespace Module2Homework3.Ingredients.Food.Fruits
{
    public class Fruit : Food
    {
        public Fruit(
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
