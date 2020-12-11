using System;
using System.Collections.Generic;
using System.Text;

namespace CourseProject
{
    class Product
    {
        public string name { get; set; }
        public double cost { get; set; }
        public string measure { get; set; }

        double count; // количество товара, которое есть на складе

        public double Count
        {
            get
            {
                return count;
            }
        }


        public Product(string name, double cost, string measure)
        {
            this.name = name; this.cost = cost; this.measure = measure;
        }

        public override string ToString()
        {
            return $"Название товара: {name}\n" +
                $"Цена товара: {cost}\n" +
                $"Единица измерения: {measure}\n";
        }
    }
}
