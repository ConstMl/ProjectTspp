using System;
using System.Collections.Generic;

namespace ProjectTspp
{
    class CustomerList
    {
        private List<Customer> customers = new List<Customer>();

        private static CustomerList instance;
        private CustomerList() { }
        public static CustomerList GetInstance()
        {
            if (instance == null)
            {
                instance = new CustomerList();
            }
            return instance;
        }

        public void View()
        {
            foreach (var cust in customers)
            {
                Console.WriteLine($"|{cust.Name}\t |{cust.Surname}\t |{cust.PasportSeriesNumber}\t |{cust.Phone}\t |");
            }
        }

        public void Add()
        {
            var item = new Customer();
            Console.Write("Имя: ");
            item.Name = Console.ReadLine();
            Console.Write("Фамилия: ");
            item.Surname = Console.ReadLine();
            Console.Write("Номер паспорта: ");
            long temp;
            while (!Int64.TryParse(Console.ReadLine(), out temp))
            {
                Console.Write("Данные введены неверно, повторите ввод: ");
            }
            item.PasportSeriesNumber = temp;
            Console.Write("Номер телефона: ");
            while (!Int64.TryParse(Console.ReadLine(), out temp))
            {
                Console.Write("Данные введены неверно, повторите ввод: ");
            }
            item.Phone = temp;
            customers.Add(item);
            Console.WriteLine($"Клиен добавлен {customers.Count}");
        }

        public void Search()
        {
            throw new NotImplementedException();
        }
    }
}
