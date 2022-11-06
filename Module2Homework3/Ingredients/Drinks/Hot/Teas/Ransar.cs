using Module2Homework3.Ingredients.Drinks.Hot.Base;
using Module2Homework3.Ingredients.Drinks.Hot.Types;

namespace Module2Homework3.Ingredients.Drinks.Hot.Teas
{
    public class Ransar : Tea
    {
        public Ransar(double volume)
            : base("Ransar", volume, 45, TeaType.Yellow)
        {
            Volume = volume;
        }
    }
}
