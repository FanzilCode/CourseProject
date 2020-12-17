namespace CourseProject
{
    class Product : IAlcohol
    {
        public string name { get; set; }
        public double cost { get; set; }
        public string measure { get; set; }
        public double count { get; set;  } // количество товара, которое есть на складе

        public double Count
        {
            get
            {
                return count;
            }
        }


        public Product(string name, double cost, string measure, double count = 100)
        {
            this.name = name; this.cost = cost; this.measure = measure; this.count = count;
        }

        public override string ToString()
        {
            return $"Название товара: {name}\n" +
                $"Цена товара: {cost} рублей\n" +
                $"Единица измерения: {measure}\n";
        }
    }
}
