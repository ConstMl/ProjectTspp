using System;

namespace ProjectTspp
{
    [Serializable]
    public class Customer
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public long PasportSeriesNumber { get; private set; }
        public long Phone { get; private set; }

        public void ViewContract()
        {
            throw new NotImplementedException();
        }

        public void Print()
        {
            Console.WriteLine($"|{Name,-15}|{Surname,-15}|{PasportSeriesNumber,12}|{Phone,13}|");
        }

        public void SetName()
        {
            string temp;
            Console.Write("Имя: "); temp = Console.ReadLine();
            while (temp.Length > 12)
            {
                Console.Write("Данные введены неверно (длинное имя), повторите ввод: ");
                temp = Console.ReadLine();
            }
            Name = temp;
        }

        public void SetSurname()
        {
            string temp;
            Console.Write("Фамилия: "); temp = Console.ReadLine();
            while (temp.Length > 12)
            {
                Console.Write("Данные введены неверно (длинная фамилия), повторите ввод: ");
                temp = Console.ReadLine();
            }
            Surname = temp;
        }

        public void SetPasportSeriesNumber()
        {
            long temp;
            Console.Write("Серия и номер паспорта: ");
            while (!Int64.TryParse(Console.ReadLine(), out temp))
            {
                Console.Write("Данные введены неверно, повторите ввод: ");
            }
            PasportSeriesNumber = temp;
        }

        public void SetPhone()
        {
            long temp;
            Console.Write("Номер телефона: ");
            while (!Int64.TryParse(Console.ReadLine(), out temp))
            {
                Console.Write("Данные введены неверно, повторите ввод: ");
            }
            Phone = temp;
        }
    }
}
