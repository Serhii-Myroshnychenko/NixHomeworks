using Module2Homework2.Items.Base;
using Module2Homework2.Repository;
namespace Module2Homework2
{
    public class Cart
    {
        private List<Product> _products;
        public Cart()
        {
            _products = new List<Product>();
        }

        public void AddProductToCart(Product product) => _products.Add(product);
        public void RemoveProductFromCart(Product product) => _products.Remove(product);
        public void GetCurrentListOfProducts()
        {
            if (_products.Count == 0)
            {
                Console.WriteLine("Порожнiй кошик.");
            }
            else
            {
                Console.WriteLine("Ваш кошик: " + "\n");
                _products.ForEach(p => p.PrintDescription());
            }
        }

        public void CompleteOrder()
        {
            if (_products.Count == 0)
            {
                Console.WriteLine("Для оформлення замовлення потрiбно наповнити кошик.");
            }
            else
            {
                Console.WriteLine("Замовлення сформовано." + "\n");
                DataProvider.ChangeDataInFile(_products);
            }
        }
    }
}
