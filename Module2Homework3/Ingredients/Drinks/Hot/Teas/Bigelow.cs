using Module2Homework3.Ingredients.Drinks.Hot.Base;
using Module2Homework3.Ingredients.Drinks.Hot.Types;

namespace Module2Homework3.Ingredients.Drinks.Hot.Teas
{
    public class Bigelow : Tea
    {
        public Bigelow(double volume)
            : base("Bigelow", volume, 25, TeaType.Black)
        {
            Volume = volume;
        }
    }
}
