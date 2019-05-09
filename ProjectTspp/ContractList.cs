using System;
using System.Collections.Generic;

namespace ProjectTspp
{
    class ContractList
    {
        List<Contract> contracts = new List<Contract>();

        private static ContractList instance;
        private ContractList() { }
        public static ContractList GetInstance()
        {
            if (instance == null)
            {
                instance = new ContractList();
            }
            return instance;
        }

        public void View()
        {
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("|Фамилия клиента|Срок действия  |Страховая сумма|Процент выплаты|");
            Console.WriteLine("-----------------------------------------------------------------");
            foreach (var cont in contracts)
            {
                Console.WriteLine($"|{cont.Cust.Surname,-15}|{cont.Validity.ToShortDateString(),15}|{cont.InsuranceAmuont,15}|{cont.CompensationPrecentage,15}");
            }
            Console.WriteLine("-----------------------------------------------------------------");
        }
        private void ViewItem(Contract cont)
        {
            Console.WriteLine($"|{cont.Cust.Surname,-15}|{cont.Validity.ToShortDateString(),15}|{cont.InsuranceAmuont,15}|{cont.CompensationPrecentage,15}");
        }

        public void Add()
        {
            var item = new Contract();
            long tempLong;
            Console.Write("Серия и номер паспорта клиента: ");
            while (!Int64.TryParse(Console.ReadLine(), out tempLong))
            {
                Console.Write("Данные введены неверно, повторите ввод: ");
            }
            var custList = CustomerList.GetInstance();
            foreach (var cust in custList.Get())
            {
                if (cust.PasportSeriesNumber == tempLong)
                {
                    item.Cust = cust;
                }
            }
            if (item.Cust == null)
            {
                Console.WriteLine("Данного клиента нет в базе. Заключение констракта не может быть выполнено.");
                Console.ReadKey();
                return;
            }
            item.Validity = DateTime.Now.AddYears(1);
            Console.Write("Страховая сумма: ");
            while (!Int64.TryParse(Console.ReadLine(), out tempLong))
            {
                Console.Write("Данные введены неверно, повторите ввод: ");
            }
            item.InsuranceAmuont = tempLong;
            Console.Write("Процент выплаты: ");
            while (!Int64.TryParse(Console.ReadLine(), out tempLong) || (tempLong < 1 || tempLong > 100))
            {
                Console.Write("Данные введены неверно, повторите ввод: ");
            }
            item.CompensationPrecentage = (int)tempLong;
            contracts.Add(item);
            Console.WriteLine($"Контракт заключен {contracts.Count}");
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
            foreach (var cont in contracts)
            {
                if (cont.Cust.PasportSeriesNumber == pasportSeriesNumber)
                {
                    if (!searchFlag)
                    {
                        Console.WriteLine("-----------------------------------------------------------------");
                        Console.WriteLine("|Фамилия клиента|Срок действия  |Страховая сумма|Процент выплаты|");
                        Console.WriteLine("-----------------------------------------------------------------");
                    }
                    ViewItem(cont);
                    searchFlag = true;
                }
            }
            if (!searchFlag)
            {
                Console.WriteLine("Договоры не найдены.");
            }
            else
            {
                Console.WriteLine("-----------------------------------------------------------------");
            }
        }

    }
}
