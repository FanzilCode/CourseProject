namespace CourseProject
{
    class Client
    {
        public string fullname { get; set; }
        public double sum { get; set; }
        public bool IsRegular { get; set; } = false;
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public string address { get; set; }

        public Client(string fullname, string phoneNumber, string email, string address)
        {
            this.fullname = fullname; this.phoneNumber = phoneNumber; this.email = email; this.address = address;
        }

        public void Check()
        {
            if (sum > 5000)
                IsRegular = true;
        }
        public override string ToString()
        {
            return $"ФИО: {fullname}\n" +
                $"Номер телефона: {phoneNumber}\n" +
                $"email: {email}\n" +
                $"Адрес проживания: {address}\n" +
                $"Является ли постоянным клиентом? {IsRegular}\n" +
                $"Покупок на общую сумму: {sum} рублей\n";
        }
    }
}