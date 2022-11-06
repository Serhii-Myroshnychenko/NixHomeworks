using Module2Homework3.Ingredients.Drinks.Alcoholic.Base;
using Module2Homework3.Ingredients.Drinks.Alcoholic.Types;

namespace Module2Homework3.Ingredients.Drinks.Alcoholic.Beers
{
    public class Porter : Beer
    {
        public Porter(double volume)
            : base("Porter", volume, 45, 5.5, BeerType.Light)
        {
            Volume = volume;
        }
    }
}
