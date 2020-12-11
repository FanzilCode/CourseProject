using System;

namespace CourseProject
{
    class Client
    {
        string fullname;
        public double sum { get; set; }
        public bool IsRegular { get; set; } = false;
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public string address { get; set; }

        public Client(string fullname)
        {
            this.fullname = fullname;
        }

        public void Check()
        {
            if (sum > 5000)
                IsRegular = true;
        }
    }
}