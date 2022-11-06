using Module2Homework3.Ingredients.Drinks.Non_alcoholic.Types;

namespace Module2Homework3.Ingredients.Drinks.Non_alcoholic.Juices
{
    public class Rich : Juice
    {
        public Rich(double volume)
            : base("Rich", volume, 34, JuiceType.Apple)
        {
            Volume = volume;
        }
    }
}
