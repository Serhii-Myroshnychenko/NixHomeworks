using Module2Homework4.Extensions;
using Module2Homework4.Gardens;
using Module2Homework4.Plants.Base.Enums;
using Module2Homework4.Plants.Herbs;
using Module2Homework4.Plants.Shrubs;
using Module2Homework4.Plants.Trees.DecorativeTree;
using Module2Homework4.Plants.Trees.FruitTree;

FruitTree fruitTree = new ("PearTree", 45, TypeOfTree.Dwarf, "Pear", new DateTime(2023, 05, 10));
DecorativeTree decorativeTree = new ("FirTree", 120, TypeOfTree.FullSized, "bumps");
Shrub shrub = new ("Currant", 12.5, TypeOfHabitat.Forest);
Herb herb = new ("Daisies", 3, TypeOfHerb.Forage);

Garden garden = new ();
garden.AddPlantToGarden(fruitTree);
garden.AddPlantToGarden(decorativeTree);
garden.AddPlantToGarden(shrub);
garden.AddPlantToGarden(herb);

garden.GetListOfPlants();

Console.WriteLine("Search plant by name: Currant" + Environment.NewLine);
var currant = garden.GetPlantByName("Currant");
currant!.PrintPlant();
Console.WriteLine("-----------------------------");

Console.WriteLine("Sort by life time in descending order: " + Environment.NewLine);
garden.SortPlantsByLifeTimeInDescendingOrder();
garden.GetListOfPlants();