using System.Text;
using Module2Homework3.Models.Ingredients.Base;

namespace Module2Homework3.Ingredients.Food
{
    public class Food : Ingredient
    {
        public Food(
            string name,
            double weight,
            double caloriesPerOneHundredGrams)
            : base(name)
        {
            Name = name;
            Weight = weight;
            CaloriesPerOneHundredGrams = caloriesPerOneHundredGrams;
        }

        protected double Weight { get; init; }
        protected double CaloriesPerOneHundredGrams { get; init; }
        public override double GetTotalCalories() => (Weight * CaloriesPerOneHundredGrams) / 100;
        public override void PrintIngredient()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Name: " + Name);
            stringBuilder.AppendLine("Weight(gr): " + Weight);
            stringBuilder.AppendLine("CaloriesPerOneHundredGrams: " + CaloriesPerOneHundredGrams);
            stringBuilder.AppendLine("Total calories: " + GetTotalCalories());
            Console.Write(stringBuilder.ToString());
        }
    }
}
