using Module2Homework4.Gardens;
using Module2Homework4.Plants.Base;

namespace Module2Homework4.Extensions
{
    public static class GardenExtension
    {
        public static Plant? GetPlantById(this Garden garden, Guid id)
        {
            return garden.Plants.Where(i => i.Id == id).FirstOrDefault();
        }

        public static Plant? GetPlantByName(this Garden garden, string name)
        {
            return garden.Plants.Where(i => i.Name.ToLower() == name.ToLower()).FirstOrDefault();
        }

        public static Garden SortPlantsByName(this Garden garden)
        {
            garden.Plants = garden.Plants.OrderBy(i => i.Name).ToArray();
            return garden;
        }

        public static Garden SortVehiclesByLifeTime(this Garden garden)
        {
            garden.Plants = garden.Plants.OrderBy(i => i.LifeTime).ToArray();
            return garden;
        }

        public static Garden SortPlantsByLifeTimeInDescendingOrder(this Garden garden)
        {
            garden.Plants = garden.Plants.OrderByDescending(i => i.LifeTime).ToArray();
            return garden;
        }
    }
}
