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
            throw new NotImplementedException();
        }

        public void Add()
        {
            throw new NotImplementedException();
            /*
            Customer item = new Customer();
            customers.Add(item);
            Console.WriteLine($"Клиен добавлен {customers.Count}");
            */
        }

        public void Search()
        {
            throw new NotImplementedException();
        }
    }
}
