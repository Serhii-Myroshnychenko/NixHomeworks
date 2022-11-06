using Module2Homework3.Ingredients.Drinks.Alcoholic.Base;
using Module2Homework3.Ingredients.Drinks.Alcoholic.Types;

namespace Module2Homework3.Ingredients.Drinks.Alcoholic.Beers
{
    public class Lager : Beer
    {
        public Lager(double volume)
            : base("Lager", volume, 66, 4, BeerType.Dark)
        {
            Volume = volume;
        }
    }
}
