namespace Module2Homework3.Models.Ingredients.Base
{
    public abstract class Ingredient
    {
        public Ingredient(string name)
        {
            Name = name;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; init; }
        public string Name { get; init; }
        public abstract void PrintIngredient();
        public abstract double GetTotalCalories();
    }
}
