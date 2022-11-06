using Module2Homework3.Ingredients.Drinks.Alcoholic.Base;
using Module2Homework3.Ingredients.Drinks.Alcoholic.Types;

namespace Module2Homework3.Ingredients.Drinks.Alcoholic.Tequilas
{
    public class Joven : Tequila
    {
        public Joven(double volume)
            : base("Joven", volume, 78, 45, TequilaType.Gold)
        {
            Volume = volume;
        }
    }
}
