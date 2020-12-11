using System;
using System.Collections.Generic;
namespace CourseProject
{
    class Shop
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();

            products.Add(new Product("Банан", 25.5, "шт"));

            products.Add(new Product("Груша", 15.5, "шт"));

            products.Add(new Product("Апельсин", 55.99, "шт"));

            products.Add(new Product("Водка", 400, "шт"));

            Client(products);
        }
        static int IndexOf(string name, List<Sale> order)
        {
            int index;
            for (int i = 0; i < order.Count; i++)
            {
                if (order[i].product.name == name)
                    return i;
            }
            return -1;
        }
        static void Client(List<Product> products)
        {
            Console.WriteLine("Пожалуйста, введите ФИО:");
            string fullname = Console.ReadLine();
            Client client = new Client(fullname);
            List<Sale> order = new List<Sale>();
            while (true)
            {
                Console.WriteLine("Выберите действие: ");
                Console.WriteLine("1) Показать список товаров\n" +
                "2) Добавить товар в корзину.\n" +
                "3) Посмотреть товары в корзине\n" +
                "4) Удалить товар из корзины\n" +
                "5) Изменить кол-во какого-либо товара в корзине\n" +
                "6) Купить все товары в корзине\n");
                int choise = Convert.ToInt32(Console.ReadLine());
                switch (choise)

                {

                    case 1:

                        {

                            foreach (var p in products)

                            {

                                Console.WriteLine(p);

                            }

                            break;

                        }

                    case 2:

                        {

                            Console.Write("Введите номер товара: ");

                            int number = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Введите кол-во товара: ");

                            int count = Convert.ToInt32(Console.ReadLine());

                            order.Add(new Sale(products[number], client, count));

                            break;

                        }

                    case 3:

                        {

                            foreach (var o in order)

                                Console.WriteLine($"{o.count} {o.product.measure} {o.product.name} по цене {o.product.cost} за {o.product.measure}");

                            break;

                        }

                    case 4:

                        {

                            Console.WriteLine("Введите название товара: ");

                            string name = Console.ReadLine();

                            if (IndexOf(name, order) != -1)

                            {

                                order.RemoveAt(IndexOf(name, order));

                                Console.WriteLine($"Товар {name} удалён из корзины.");

                            }

                            else Console.WriteLine("Ошибка. Неверно введено название товара");

                            break;

                        }

                    case 5:

                        {

                            Console.WriteLine("Введите название товара, кол-во которого хотите изменить: ");

                            string name = Console.ReadLine();

                            if (IndexOf(name, order) != -1)

                            {

                                Console.Write("Введите новое кол-во товара: ");

                                int count = Convert.ToInt32(Console.ReadLine());

                                order[IndexOf(name, order)].count = count;

                                Console.WriteLine("Кол-во товара в корзине изменено.");

                            }

                            break;

                        }

                    case 6:

                        {

                            double sum = 0;

                            foreach (var o in order)

                            {

                                sum += o.Check();

                            }

                            Console.WriteLine($"Подтвердите действие: Купить все товары в корзине за {sum} рублей?\nВыберите:\n1) Подтвердить\t2) Отменить.");

                            int choise2 = Convert.ToInt32(Console.ReadLine());

                            if (choise2 == 1)

                            {

                                Console.WriteLine("Покупка успешна.");

                                client.sum += sum;

                                if (!client.IsRegular)

                                {

                                    client.Check();

                                    if (client.IsRegular)

                                        Console.WriteLine("Поздравляем! Теперь вы зачислены в список постоянных покупателей: на последующие покупки у вас будет скидка в 2%");

                                }

                                order.Clear();

                            }

                            else

                                Console.WriteLine("Покупка отменена.");

                            break;

                        }

                }

            }

        }
    }
}
