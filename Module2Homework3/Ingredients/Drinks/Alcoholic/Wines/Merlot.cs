using Module2Homework3.Ingredients.Drinks.Alcoholic.Base;
using Module2Homework3.Ingredients.Drinks.Alcoholic.Types;

namespace Module2Homework3.Ingredients.Drinks.Alcoholic.Wines
{
    public class Merlot : Wine
    {
        public Merlot(double volume)
            : base("Merlot", volume, 36, 15, WineType.White)
        {
            Volume = volume;
        }
    }
}
