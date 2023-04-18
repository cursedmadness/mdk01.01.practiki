namespace ConsoleApp1
{
class Program
    {
        static void Main(string[] args)
        {

            Adapter adapter = new Adapter();

            //Передача клиенту класса adapter.
            Client client = new Client(adapter);
            client.Show();

        }
    }

    class Original
    {
        public void OriginalDouble(double value)
        {
            Console.WriteLine("Метод Original.OriginalDouble(), значение = {0}", value);
        }

        public void OriginalInt(int value)
        {
            Console.WriteLine("Метод Original.OriginalInt(), значение = {0}", value);
        }

        public void OriginalChar(char value)
        {
            Console.WriteLine("Метод Original.OriginalChar, символ = {0}", value);
        }
    }

    // Класс Client - получает ссылку на интерфейс ITarget в конструкторе
    class Client
    {
        private ITarget client; //Наличие ссылки на интерфейс

        //Конструктор.
        public Client(ITarget _client)
        {
            client = _client;
        }

        //создание метода с вызовом всех методов.
        public void Show()
        {
            client.ClientDouble(36.6);
            client.ClientInt(0);
            client.ClientChar('*');
        }
    }

    // Объявить интерфейс ITarget, который содержит нужные для работы клиента методы.
    interface ITarget
    {
        void ClientDouble(double value);
        void ClientInt(int value);
        void ClientChar(char value);
    }

    // Класс Adapter реализует интерфейс ITarget и наследует класс Original.
    class Adapter : Original, ITarget
    {
        public void ClientDouble(double value)
        {
            // в методе ClientDouble() вызвать метод OriginalDouble().
            OriginalDouble(value);
        }
        //Метод ClientInt() двойное значение параметра.
        public void ClientInt(int value)
        {
            OriginalInt(value * 2);
        }
        //метод ClientChar() выводит параметр указанное кол-во (5) раз.
        public void ClientChar(char value)
        {
            for (int i = 0; i < 5; i++)
                OriginalChar(value);
        }
    }
}