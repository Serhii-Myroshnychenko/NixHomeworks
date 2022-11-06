using Module2Homework3.Dishes;
using Module2Homework3.Models.Ingredients.Base;

namespace Module2Homework3.Extensions
{
    public static class DishExtension
    {
        public static Ingredient? GetIngredientById(this Dish dish, Guid id)
        {
            return dish.Ingredients.Where(i => i.Id == id).FirstOrDefault();
        }

        public static Ingredient? GetIngredientByName(this Dish dish, string name)
        {
            return dish.Ingredients.Where(i => i.Name.ToLower() == name.ToLower()).FirstOrDefault();
        }

        public static Dish SortIngredientsByName(this Dish dish)
        {
            dish.Ingredients = dish.Ingredients.OrderBy(i => i.Name).ToArray();
            return dish;
        }

        public static Dish SortIngredientsByTotalCalories(this Dish dish)
        {
            dish.Ingredients = dish.Ingredients.OrderBy(i => i.GetTotalCalories()).ToArray();
            return dish;
        }

        public static Dish SortIngredientsByTotalCaloriesInDescendingOrder(this Dish dish)
        {
            dish.Ingredients = dish.Ingredients.OrderByDescending(i => i.GetTotalCalories()).ToArray();
            return dish;
        }
    }
}
