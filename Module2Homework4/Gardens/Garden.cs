using Module2Homework4.Exceptions;
using Module2Homework4.Interfaces;
using Module2Homework4.Plants.Base;

namespace Module2Homework4.Gardens
{
    public class Garden : IGarden
    {
        public Garden()
        {
            Plants = Array.Empty<Plant>();
        }

        public Plant[] Plants { get; set; }

        public void AddPlantToGarden(Plant plant)
        {
            Plant[] result = new Plant[Plants.Length + 1];
            for (int i = 0; i < Plants.Length; i++)
            {
                result[i] = Plants[i];
            }

            result[Plants.Length] = plant;
            Plants = result;
        }

        public void GetListOfPlants()
        {
            Console.WriteLine("Plants: " + Environment.NewLine);

            foreach (Plant plant in Plants)
            {
                plant.PrintPlant();
                Console.WriteLine();
            }
        }

        public void RemovePlantFromGarden(Plant plant)
        {
            int pointer = GetIndexOfPlant(plant);
            if (pointer != -1)
            {
                Plant[] result = new Plant[Plants.Length - 1];
                int index = 0;
                for (int i = 0; i < Plants.Length; i++)
                {
                    if (i != pointer)
                    {
                        result[index++] = Plants[i];
                    }
                }

                Plants = result;
            }
            else
            {
                throw new RemovePlantException($"There is no such a {plant.Name}");
            }
        }

        private int GetIndexOfPlant(Plant plant)
        {
            for (int i = 0; i < Plants.Length; i++)
            {
                if (Plants[i].Id == plant.Id)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
