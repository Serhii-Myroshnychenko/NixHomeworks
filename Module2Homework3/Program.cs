using Module2Homework3.Dishes;
using Module2Homework3.Extensions;
using Module2Homework3.Ingredients.Drinks.Alcoholic.Beers;
using Module2Homework3.Ingredients.Drinks.Alcoholic.Tequilas;
using Module2Homework3.Ingredients.Drinks.Alcoholic.Wines;
using Module2Homework3.Ingredients.Drinks.Hot.Coffees;
using Module2Homework3.Ingredients.Food.Meats.Base;
using Module2Homework3.Ingredients.Food.Meats.Types;
using Module2Homework3.Models.Ingredients.Base;

Ingredient ingredient1 = new Ale(23);
Ingredient ingredient2 = new Blanco(40);
Ingredient ingredient3 = new Fiano(120);
Ingredient ingredient4 = new Jacobs(120);
Ingredient ingredient5 = new Meet("Chicken", 230, 350, MeetType.Chicken, "leg");

Dish dish = new Dish("Shish-kebab");
dish.AddIngredientToDish(ingredient5);
dish.AddIngredientToDish(ingredient2);
dish.AddIngredientToDish(ingredient1);
dish.AddIngredientToDish(ingredient3);
dish.AddIngredientToDish(ingredient4);

dish.GetListOfIngredients();
Console.WriteLine("Total sum of calories: " + dish.GetTotalSumOfCalories());
Console.WriteLine("-----------------------------");

Console.WriteLine("Search ingredient by name: Ale" + Environment.NewLine);
var ele = dish.GetIngredientByName("Ale");
ele!.PrintIngredient();
Console.WriteLine("-----------------------------");

Console.WriteLine("Sort by total calories: " + Environment.NewLine);
dish.SortIngredientsByTotalCalories();
dish.GetListOfIngredients();