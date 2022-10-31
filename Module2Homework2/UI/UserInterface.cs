
using Module2Homework2.Items.Base;
using Module2Homework2.Repository;

namespace Module2Homework2.UI
{
    public static class UserInterface
    {
        private static Cart _cart;
        static UserInterface()
        {
            _cart = new Cart();
        }

        public static void PrintMenu()
        {
            bool flag = true;
            while (flag)
            {
                List<Product> products = Data.GetProducts();

                Console.WriteLine(
                "Iнтернет-магазин Apple (Оберiть потрiбну операцiю)" + "\n" + "\n" +
                "1 - Переглянути доступнi товари." + "\n" +
                "2 - Переглянути Ваш кошик." + "\n" +
                "3 - Оформити замовлення." + "\n" +
                "4 - Завершити роботу."
                );
                string? input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        GetListOfAvailableProducts(products);
                        break;
                    case "2":
                        GetCart();
                        break;
                    case "3":
                        PlaceOrder();
                        break;
                    case "4":
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Оберiть вiрний номер операцiї.");
                        break;
                }
            }
        }

        private static void GetListOfAvailableProducts(List<Product> products)
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Список доступних товарiв та їх характеристики: " + "\n");
                foreach (Product product in products)
                {
                    Console.WriteLine("Доступна кiлькiсть: " + product.Count);
                    product.PrintDescription();
                }

                Console.WriteLine("\n" + "Оберiть доступну операцiю:" + "\n" +
                    "1 - Додати товар до своєї корзини" + "\n" +
                    "2 - Повернутися до головного меню");

                string? input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        AddProductToCart(products);
                        break;
                    case "2":
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Введiть коректний номер операцiї." + "\n");
                        break;
                }
            }
        }

        private static void AddProductToCart(List<Product> products)
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Введiть назву товару." + "\n");
                string? name = Console.ReadLine();

                if (products.Exists(p => p.Name == name))
                {
                    bool innerFlag = true;
                    while (innerFlag)
                    {
                        var selectedProduct = products.Find(p => p.Name == name);
                        Console.WriteLine("Введiть кiлькiсть товару: " + "\n");
                        string? count = Console.ReadLine();
                        if (int.TryParse(count, out var number) && selectedProduct!.Count >= number && number > 0)
                        {
                            selectedProduct.Count = number;
                            _cart.AddProductToCart(selectedProduct);
                            Console.WriteLine("Товар додано до Вашої корзини." + "\n");
                            flag = false;
                            innerFlag = false;
                        }
                        else
                        {
                            Console.WriteLine("\n" + "Дана кiлькiсть не являється доступною." + "\n");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\n" + "Зазначений товар не iснує" + "\n");
                }
            }
        }

        private static void GetCart() => _cart.GetCurrentListOfProducts();

        private static void PlaceOrder() => _cart.CompleteOrder();
    }
}
