using Module2Homework3.Ingredients.Drinks.Hot.Base;
using Module2Homework3.Ingredients.Drinks.Hot.Types;

namespace Module2Homework3.Ingredients.Drinks.Hot.Coffees
{
    public class Jacobs : Coffee
    {
        public Jacobs(double volume)
            : base("Jacobs", volume, 47, CoffeeType.Black)
        {
            Volume = volume;
        }
    }
}
