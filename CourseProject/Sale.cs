using System;
using System.Collections.Generic;
using System.Text;

namespace CourseProject
{
    class Sale
    {
        public Product product { get; set; }
        public Client client { get; set; }
        public double count { get; set; }

        DateTime saleDate;
        DateTime deliveryDate;

        public Sale(Product product, Client client, double count)
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
    }
}
