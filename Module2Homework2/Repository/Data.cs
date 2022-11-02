using Module2Homework2.Items.Base;
using Module2Homework2.Utils;

namespace Module2Homework2.Repository
{
    public static class Data
    {
        public static Product[] GetProducts() => Parser.ParseData(DataProvider.GetDataFromFile()).ToArray();
    }
}
