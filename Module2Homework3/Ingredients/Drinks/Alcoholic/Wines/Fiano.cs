using Module2Homework3.Ingredients.Drinks.Alcoholic.Base;
using Module2Homework3.Ingredients.Drinks.Alcoholic.Types;

namespace Module2Homework3.Ingredients.Drinks.Alcoholic.Wines
{
    public class Fiano : Wine
    {
        public Fiano(double volume)
            : base("Fiano", volume, 23, 7, WineType.Red)
        {
            Volume = volume;
        }
    }
}
