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

        public Client(string fullname, string phoneNumber, string email, string address, double sum)
        {
            this.fullname = fullname; this.phoneNumber = phoneNumber; this.email = email; this.address = address; this.sum = sum;
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
        public string ToFileString()
        {
            return $"{fullname},{phoneNumber},{email},{address},{sum}";
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Client client = obj as Client;
            if (obj as Client == null)
                return false;
            return client.fullname == fullname && client.email == email && client.phoneNumber == phoneNumber;
        }
        public static bool operator ==(Client client1, Client client2)
        {
            return client1.Equals(client2);
        }

        public static bool operator !=(Client client1, Client client2)
        {
            return !client1.Equals(client2);
        }
    }
}