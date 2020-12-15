
namespace CourseProject
{
    class Wine : Product
    {

        public Wine(string name, double cost, string measure, double count) : base(name, cost, measure, count = 100) { }
    }
}
