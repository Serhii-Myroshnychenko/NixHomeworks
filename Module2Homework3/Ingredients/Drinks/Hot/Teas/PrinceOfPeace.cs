using Module2Homework3.Ingredients.Drinks.Hot.Base;
using Module2Homework3.Ingredients.Drinks.Hot.Types;

namespace Module2Homework3.Ingredients.Drinks.Hot.Teas
{
    public class PrinceOfPeace : Tea
    {
        public PrinceOfPeace(double volume)
            : base("PrinceOfPeace", volume, 45, TeaType.Black)
        {
            Volume = volume;
        }
    }
}
