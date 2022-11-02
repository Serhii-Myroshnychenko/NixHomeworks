using Module2Homework2.Items.Base;
using Module2Homework2.Repository;
namespace Module2Homework2
{
    public class Cart
    {
        private Product[] _products;
        public Cart()
        {
            _products = Array.Empty<Product>();
        }

        public void AddProductToCart(Product product)
        {
            Product[] products = new Product[_products.Length + 1];
            for (int i = 0; i < products.Length - 1; i++)
            {
                products[i] = _products[i];
            }

            products[products.Length - 1] = product;
            _products = products;
        }

        public void GetCurrentListOfProducts()
        {
            if (_products.Length == 0)
            {
                Console.WriteLine("Порожнiй кошик.");
            }
            else
            {
                Console.WriteLine("Ваш кошик: " + "\n");
                foreach (Product product in _products)
                {
                    Console.WriteLine("Кiлькiсть: " + product.Count);
                    product.PrintDescription();
                }
            }
        }

        public void CompleteOrder()
        {
            if (_products.Length == 0)
            {
                Console.WriteLine("Для оформлення замовлення потрiбно наповнити кошик.");
            }
            else
            {
                Console.WriteLine("Замовлення сформовано." + "\n");
                Console.WriteLine("Куплений товар:" + "\n");
                DataProvider.ChangeDataInFile(_products);
                foreach (Product product in _products)
                {
                    Console.WriteLine("Кiлькiсть: " + product.Count);
                    product.PrintDescription();
                }

                _products = Array.Empty<Product>();
            }
        }
    }
}
