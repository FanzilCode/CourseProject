using System;

namespace CourseProject
{
    class Sale
    {
        public IAlcohol product { get; set; }
        public Client client { get; set; }
        public double count { get; set; }

        public DateTime saleDate { get; set; }
        public DateTime deliveryDate { get; set; }

        public Sale(IAlcohol product, Client client, double count)
        {
            this.product = product; this.client = client; this.count = count;
        }

        public double Check()
        {
            double res;
            res = product.cost * count;
            if (client.IsRegular)
                return 0.98 * res;
            return res;
        }
        public override string ToString()
        {
            return $"Товар: {product.name}\n" +
                $"Клиент: {client.fullname}\n" +
                $"Количество: {count}\n" +
                $"Дата заказа: {saleDate}\n" +
                $"Дата доставки: {deliveryDate}\n";
        }
    }
}
