namespace CourseProject
{
    class Brandy : Product
    {
        public Brandy(string name, double cost, string measure, double count) : base(name, cost, measure, count = 100) { }
    }
}
