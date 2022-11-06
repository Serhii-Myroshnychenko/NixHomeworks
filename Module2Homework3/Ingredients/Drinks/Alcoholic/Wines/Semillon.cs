using Module2Homework3.Ingredients.Drinks.Alcoholic.Base;
using Module2Homework3.Ingredients.Drinks.Alcoholic.Types;

namespace Module2Homework3.Ingredients.Drinks.Alcoholic.Wines
{
    public class Semillon : Wine
    {
        public Semillon(double volume)
            : base("Semillon", volume, 67, 20, WineType.Dessert)
        {
            Volume = volume;
        }
    }
}
