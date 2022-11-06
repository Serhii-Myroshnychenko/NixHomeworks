using Module2Homework3.Contracts;
using Module2Homework3.Models.Ingredients.Base;

namespace Module2Homework3.Dishes
{
    public class Dish : IDish
    {
        private readonly string _name;
        public Dish(string name)
        {
            _name = name;
            Ingredients = Array.Empty<Ingredient>();
        }

        public Ingredient[] Ingredients { get; set; }

        public void AddIngredientToDish(Ingredient ingredient)
        {
            Ingredient[] ingredients = new Ingredient[Ingredients.Length + 1];
            for (int i = 0; i < ingredients.Length - 1; i++)
            {
                ingredients[i] = Ingredients[i];
            }

            ingredients[^1] = ingredient;
            Ingredients = ingredients;
        }

        public void GetListOfIngredients()
        {
            Console.WriteLine("Name of dish: " + _name);
            Console.WriteLine("Ingredients: " + Environment.NewLine);

            foreach (Ingredient ingredient in Ingredients)
            {
                ingredient.PrintIngredient();
                Console.WriteLine();
            }
        }

        public void RemoveIngredientFromDish(Ingredient ingredient)
        {
            int index = GetIndexOfElement(ingredient);
            if (index != -1)
            {
                Ingredient[] ingredients = new Ingredient[Ingredients.Length - 1];
                int indexOfNewCollection = 0;
                for
                    (int i = 0; i < Ingredients.Length; i++)
                {
                    if (i != index)
                    {
                        ingredients[indexOfNewCollection++] = Ingredients[i];
                    }
                }

                Ingredients = ingredients;
            }
            else
            {
                Console.WriteLine("Даний інгредієнт відсутній");
            }
        }

        public double GetTotalSumOfCalories()
        {
            double sum = 0;
            foreach (Ingredient ingredient in Ingredients)
            {
                sum += ingredient.GetTotalCalories();
            }

            return sum;
        }

        private int GetIndexOfElement(Ingredient ingredient)
        {
            for (int i = 0; i < Ingredients.Length; i++)
            {
                if (ingredient.Id == Ingredients[i].Id)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
