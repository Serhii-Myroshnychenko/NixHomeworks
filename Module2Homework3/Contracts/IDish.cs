using Module2Homework3.Models.Ingredients.Base;
namespace Module2Homework3.Contracts
{
    public interface IDish
    {
        void GetListOfIngredients();
        void AddIngredientToDish(Ingredient ingredient);
        void RemoveIngredientFromDish(Ingredient ingredient);
        double GetTotalSumOfCalories();
    }
}
