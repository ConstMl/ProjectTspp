using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

namespace ProjectTspp
{
    class CustomerList
    {
        private string custometListPath = "customerList";
        private List<Customer> customers = new List<Customer>();

        private static CustomerList instance;
        private CustomerList() { }
        public static CustomerList GetInstance()
        {
            if (instance == null)
            {
                instance = new CustomerList();
                instance.ReadAndDeserialize(instance.custometListPath);
            }
            return instance;
        }

        public List<Customer> Get() => customers;

        public void View()
        {
            Console.WriteLine($"------------------------------------------------------------");
            Console.WriteLine($"|Имя            |Фамилия        |Паспорт     |Телефон      |");
            Console.WriteLine($"------------------------------------------------------------");
            foreach (var cust in customers)
            {
                Console.WriteLine($"|{cust.Name,-15}|{cust.Surname,-15}|{cust.PasportSeriesNumber,12}|{cust.Phone,13}|");
            }
            Console.WriteLine($"------------------------------------------------------------");
        }

        private void ViewItem(Customer cust)
        {
            Console.WriteLine($"|{cust.Name,-15}|{cust.Surname,-15}|{cust.PasportSeriesNumber,12}|{cust.Phone,13}|");
        }

        public void Add()
        {
            var item = new Customer();
            long tempLong;
            string tempString;

            Console.Write("Имя: "); tempString = Console.ReadLine();
            while (tempString.Length > 12)
            {
                Console.Write("Данные введены неверно (длинное имя), повторите ввод: ");
                tempString = Console.ReadLine();
            }
            item.Name = tempString;

            Console.Write("Фамилия: "); tempString = Console.ReadLine();
            while (tempString.Length > 12)
            {
                Console.Write("Данные введены неверно (длинная фамилия), повторите ввод: ");
                tempString = Console.ReadLine();
            }
            item.Surname = tempString;

            Console.Write("Серия и номер паспорта: ");
            while (!Int64.TryParse(Console.ReadLine(), out tempLong))
            {
                Console.Write("Данные введены неверно, повторите ввод: ");
            }
            foreach (var cust in customers)
            {
                if (cust.PasportSeriesNumber == tempLong)
                {
                    Console.WriteLine("Данный клиент уже есть в базе.");
                    Console.ReadKey();
                    return;
                }
            }
            item.PasportSeriesNumber = tempLong;

            Console.Write("Номер телефона: ");
            while (!Int64.TryParse(Console.ReadLine(), out tempLong))
            {
                Console.Write("Данные введены неверно, повторите ввод: ");
            }
            item.Phone = tempLong;

            customers.Add(item);
            Console.WriteLine($"Клиен добавлен {customers.Count}");
            Console.ReadKey();
        }

        public void Search()
        {
            long pasportSeriesNumber;
            Console.Write("Серия и номер паспорта: ");
            while (!Int64.TryParse(Console.ReadLine(), out pasportSeriesNumber))
            {
                Console.Write("Данные введены неверно, повторите ввод: ");
            }
            bool searchFlag = false;
            foreach (var cust in customers)
            {
                if (cust.PasportSeriesNumber == pasportSeriesNumber)
                {
                    if (!searchFlag)
                    {
                        Console.WriteLine($"------------------------------------------------------------");
                        Console.WriteLine($"|Имя            |Фамилия        |Паспорт     |Телефон      |");
                        Console.WriteLine($"------------------------------------------------------------");
                    }
                    ViewItem(cust);
                    searchFlag = true;
                    break;
                }
            }
            if (!searchFlag)
            {
                Console.WriteLine("Такого клиента не существует.");
            }
            else
            {
                Console.WriteLine($"------------------------------------------------------------");
            }
        }

        private void ReadAndDeserialize(string path)
        {
            var serializer = new XmlSerializer(typeof(List<Customer>));
            using (var reader = new StreamReader(path))
            {
                customers = (List<Customer>)serializer.Deserialize(reader);
                return;
            }
        }

        public void SerializeAndSave(string path)
        {
            var serializer = new XmlSerializer(typeof(List<Customer>));
            using (var writer = new StreamWriter(path))
            {
                serializer.Serialize(writer, customers);
            }
        }
    }
}
