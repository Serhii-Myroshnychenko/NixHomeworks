using Module2Homework3.Ingredients.Drinks.Non_alcoholic.Types;

namespace Module2Homework3.Ingredients.Drinks.Non_alcoholic.Juices
{
    public class Jaffa : Juice
    {
        public Jaffa(double volume)
            : base("Jaffa", volume, 62, JuiceType.Grape)
        {
            Volume = volume;
        }
    }
}
