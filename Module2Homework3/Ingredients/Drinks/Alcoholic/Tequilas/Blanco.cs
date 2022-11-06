using Module2Homework3.Ingredients.Drinks.Alcoholic.Base;
using Module2Homework3.Ingredients.Drinks.Alcoholic.Types;

namespace Module2Homework3.Ingredients.Drinks.Alcoholic.Tequilas
{
    public class Blanco : Tequila
    {
        public Blanco(double volume)
            : base("Blanco", volume, 33, 36, TequilaType.Anejo)
        {
            Volume = volume;
        }
    }
}
