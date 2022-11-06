using Module2Homework3.Ingredients.Drinks.Alcoholic.Base;
using Module2Homework3.Ingredients.Drinks.Alcoholic.Types;

namespace Module2Homework3.Ingredients.Drinks.Alcoholic.Beers
{
    public class Ale : Beer
    {
        public Ale(double volume)
            : base("Ale", volume, 55, 3, BeerType.Dark)
        {
            Volume = volume;
        }
    }
}
