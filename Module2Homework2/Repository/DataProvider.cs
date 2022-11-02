using System.Text;
using Module2Homework2.Items.Base;

namespace Module2Homework2.Repository
{
    public static class DataProvider
    {
        private static string _path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()) !.Parent!.Parent!.Parent!.FullName, "products.txt");
        public static string[] GetDataFromFile() => File.ReadAllLines(_path);

        public static void ChangeDataInFile(Product[] order)
        {
            Product[] productsFromFile = Data.GetProducts();

            for (int i = 0; i < productsFromFile.Length; i++)
            {
                for (int k = 0; k < order.Length; k++)
                {
                    if (productsFromFile[i].Id == order[k].Id)
                    {
                        productsFromFile[i].Count -= order[k].Count;
                        if (!productsFromFile[i].IsAvailable())
                        {
                            productsFromFile = (Product[])productsFromFile.Where(p => p.Id != productsFromFile[i].Id);
                        }
                    }
                }
            }

            WriteDataToFile(productsFromFile);
        }

        private static void WriteDataToFile(Product[] products)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var elem in products)
            {
                sb.AppendLine(elem.ToString());
            }

            File.WriteAllText(_path, sb.ToString());
        }
    }
}
