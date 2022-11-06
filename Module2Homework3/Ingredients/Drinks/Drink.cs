using System.Text;
using Module2Homework3.Models.Ingredients.Base;

namespace Module2Homework3.Ingredients.Drinks
{
    public class Drink : Ingredient
    {
        public Drink(string name, double volume, double caloriesPerOneHundredMilliliters)
            : base(name)
        {
            Name = name;
            Volume = volume;
            CaloriesPerOneHundredMilliliters = caloriesPerOneHundredMilliliters;
        }

        protected double Volume { get; init; }
        protected double CaloriesPerOneHundredMilliliters { get; init; }
        public override double GetTotalCalories() => (Volume * CaloriesPerOneHundredMilliliters) / 100;
        public override void PrintIngredient()
        {
            StringBuilder stringBuilder = new ();
            stringBuilder.AppendLine("Name: " + Name);
            stringBuilder.AppendLine("Volume(ml): " + Volume);
            stringBuilder.AppendLine("CaloriesPerOneHundredMilliliters: " + CaloriesPerOneHundredMilliliters);
            stringBuilder.AppendLine("Total calories: " + GetTotalCalories());
            Console.Write(stringBuilder.ToString());
        }
    }
}
