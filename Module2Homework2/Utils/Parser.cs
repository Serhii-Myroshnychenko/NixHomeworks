using Module2Homework2.Items;
using Module2Homework2.Items.Base;

namespace Module2Homework2.Utils
{
    public static class Parser
    {
        public static List<Product> ParseData(string[] data)
        {
            List<Product> products = new List<Product>();

            foreach (string line in data)
            {
                string[] split = line.Split(',');
                Product product = new Phone(Guid.Parse(split[0]), split[1], int.Parse(split[2]), split[3], split[4], split[5], split[6], split[7], int.Parse(split[8]), decimal.Parse(split[9]), Enum.Parse<Color>(split[10]));

                products.Add(product);
            }

            return products;
        }
    }
}
