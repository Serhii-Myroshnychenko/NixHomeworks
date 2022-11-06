using Module2Homework3.Ingredients.Drinks.Hot.Base;
using Module2Homework3.Ingredients.Drinks.Hot.Types;

namespace Module2Homework3.Ingredients.Drinks.Hot.Coffees
{
    public class Nero : Coffee
    {
        public Nero(double volume)
            : base("Nero", volume, 67, CoffeeType.Arabica)
        {
            Volume = volume;
        }
    }
}
