namespace CourseProject
{
    class Bourbon : Product
    {
        public Bourbon(string name, double cost, string measure, double count) : base(name, cost, measure, count = 100) { }
    }
}
