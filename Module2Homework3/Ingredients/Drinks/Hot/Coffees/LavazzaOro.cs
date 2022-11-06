using Module2Homework3.Ingredients.Drinks.Hot.Base;
using Module2Homework3.Ingredients.Drinks.Hot.Types;

namespace Module2Homework3.Ingredients.Drinks.Hot.Coffees
{
    public class LavazzaOro : Coffee
    {
        public LavazzaOro(double volume)
            : base("LavazzaOro", volume, 34, CoffeeType.Americano)
        {
            Volume = volume;
        }
    }
}
