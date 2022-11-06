using Module2Homework3.Ingredients.Food.Meats.Types;

namespace Module2Homework3.Ingredients.Food.Meats.Base
{
    public class Meet : Food
    {
        public Meet(
            string name,
            double weight,
            double caloriesPerOneHundredGrams,
            MeetType type,
            string partOfBody)
            : base(name, weight, caloriesPerOneHundredGrams)
        {
            Name = name;
            Weight = weight;
            CaloriesPerOneHundredGrams = caloriesPerOneHundredGrams;
            Type = type;
            PartOfBody = partOfBody;
        }

        protected MeetType Type { get; init; }
        protected string PartOfBody { get; init; }
        public override void PrintIngredient()
        {
            base.PrintIngredient();
            Console.WriteLine("MeetType: " + Type);
            Console.WriteLine("PartOfBody: " + PartOfBody);
        }
    }
}
