using Module2Homework4.Plants.Base;

namespace Module2Homework4.Interfaces
{
    public interface IGarden
    {
        void GetListOfPlants();
        void AddPlantToGarden(Plant plant);
        void RemovePlantFromGarden(Plant plant);
    }
}
