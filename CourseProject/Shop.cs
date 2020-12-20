using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace CourseProject
{
    class AlcoStore
    {
        static List<IAlcohol> products = new List<IAlcohol>();
        static List<Sale> sales = new List<Sale>();
        static List<Client> clients = new List<Client>();
        static void ReadProductsFromFile(string path)
        {
            FileInfo file = new FileInfo(path);
            string line;
            if (file.Exists)
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] str = line.Split('/');
                        products.Add(new Product(str[0], Convert.ToDouble(str[1]), str[2]));
                    }
                }
            }
        }
        static void ReadClientsFromFile(string path)
        {
            FileInfo file = new FileInfo(path);
            string line;
            if (file.Exists)
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] str = line.Split(',');
                        Client client = new Client(str[0], str[1], str[2], str[3], Convert.ToDouble(str[4]));
                        client.Check();
                        clients.Add(client);
                    }
                }
            }
        }
        static void WriteToFileProducts(string path)
        {
            FileInfo file = new FileInfo(path);
            using(StreamWriter sw = new StreamWriter(path))
            {
                foreach(var p in products)
                {
                    sw.WriteLine($"{p.name}/{p.cost}/{p.measure}");
                }
            }
        }
        static void WriteToFileClients(string path)
        {
            FileInfo file = new FileInfo(path);
            string line;
            if (!file.Exists)
            {
                file.Create();
            }
            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                foreach(var c in clients)
                {
                    sw.WriteLine(c.ToFileString());
                }
            }
        }
        static void Main(string[] args)
        {
            // TODO: добавить товары через консоль(как администратор) / базу данных
            ReadProductsFromFile(@"products.txt");
            ReadClientsFromFile(@"clients.txt");
            int choise = 0;
            while (choise != 3)
            {
                Console.WriteLine("Выберите способ входа:\n1) Я администратор\t2) Я клиент 3) Выход");
                choise = Convert.ToInt32(Console.ReadLine());
                if (choise == 2)
                    Client();
                else if(choise == 1)
                {
                    Console.WriteLine("Input password: ");
                    string password = Console.ReadLine();
                    if (password == "password")
                    {
                        Console.WriteLine("Пароль верный.");
                        Admin();
                    }
                    else
                    {
                        Console.WriteLine("Пароль неверный.");
                    }
                }
            }
            WriteToFileClients(@"clients.txt");
            WriteToFileProducts(@"products.txt");
        }
        static int IndexOf(string name, List<Sale> order)
        {
            for (int i = 0; i < order.Count; i++)
            {
                if (order[i].product.name == name)
                    return i;
            }
            return -1;
        }
        static int IndexOf(string name, List<IAlcohol> products)
        {
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].name == name)
                    return i;
            }
            return -1;
        }
        static void PrintCollection(IList list)
        {
            foreach(var l in list)
                Console.WriteLine(l);
        }
        static void Admin()
        {
            int choise = 0;
            while (choise != 7)
            {
                Console.WriteLine("Выберите действие:\n" +
                "1) Добавить новые товары в ассортимент\n" +
                "2) Удалить какой-либо товар\n" +
                "3) Изменить цену какого-либо товара\n" +
                "4) Показать список всех товаров\n" +
                "5) Показать список всех клиентов\n" +
                "6) Выход.");
                choise = Convert.ToInt32(Console.ReadLine());
                switch (choise)
                {
                    case 1:
                        {
                            Console.WriteLine("Выберите тип товара:\n1) Бурбон\t2)Бренди\t3)Вино");
                            int ch = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Введите название товара: "); string name = Console.ReadLine();
                            Console.WriteLine("Введите кол-во товара, которое хотите завести на склад: ");
                            double count = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Введите единицу измерения товара: "); string measure = Console.ReadLine();
                            Console.WriteLine("Введите цену: "); double cost = Convert.ToDouble(Console.ReadLine());
                            products.Add(new Product(name, cost, measure, count));
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Введите название товара: ");
                            string name = Console.ReadLine();
                            try
                            {
                                products.RemoveAt(IndexOf(name, products));
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Введите название товара: ");
                            string name = Console.ReadLine();
                            int index = IndexOf(name, products);
                            Console.WriteLine("Введите новую цену товара: ");
                            double cost = Convert.ToDouble(Console.ReadLine());
                            try
                            {
                                products[index].cost = cost;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;
                        }
                    case 4:
                        {
                            PrintCollection(products);
                            break;
                        }
                    case 5:
                        {
                            PrintCollection(clients);
                            break;
                        }
                    case 6:
                        {
                            PrintCollection(sales);
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }
        static void Client()
        {
            Console.WriteLine("Пожалуйста, заполните следующие поля:");
            Console.WriteLine("ФИО");
            string fullname = Console.ReadLine();
            Console.Write("Номер телефона: ");
            string phoneNumber = Console.ReadLine();
            Console.Write("Ваш email: ");
            string email = Console.ReadLine();
            Console.Write("Адрес вашего проживания: ");
            string address = Console.ReadLine();
            Client client = new Client(fullname, phoneNumber, email, address, 0);
            int index;
            if (!clients.Contains(client))
            {
                clients.Add(client);
                index = clients.Count - 1;
            }
            else
            {
                index = clients.IndexOf(client);
            }
            client = clients[index];
            List<Sale> order = new List<Sale>();
            int choise = 0;
            while (choise != 7)
            {
                Console.WriteLine("Выберите действие: ");
                Console.WriteLine("1) Показать список товаров\n" +
                "2) Добавить товар в корзину.\n" +
                "3) Посмотреть товары в корзине\n" +
                "4) Удалить товар из корзины\n" +
                "5) Изменить кол-во какого-либо товара в корзине\n" +
                "6) Купить все товары в корзине\n" +
                "7) Выход.\n");

                choise = Convert.ToInt32(Console.ReadLine());
                switch (choise)
                {
                    case 1:
                        {
                            PrintCollection(products);
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
                                Console.WriteLine($"{o.count} {o.product.measure} {o.product.name} по цене {o.product.cost} рублей за {o.product.measure}");
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
                                foreach(var o in order)
                                {
                                    o.saleDate = DateTime.Now;
                                    o.deliveryDate = o.saleDate + new TimeSpan(7, 0, 0, 0);
                                }
                                sales.AddRange(order);
                                order.Clear();
                            }
                            else
                                Console.WriteLine("Покупка отменена.");
                            break;
                        }
                    default:
                        break;
                }
            }
        }
    }
}
