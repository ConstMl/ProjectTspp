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
                cont.Print();
            }
        }

        public void Add(ContractType contractType)
        {
            var item = ContractFactory.GetNewContract(contractType);

            item.SetCust();
            if (item.Cust == null)
            {
                return;
            }
            item.SetValidity();
            item.SetInsuranceAmuont();
            item.SetCompensationPrecentage();
            item.SetSpecialFields();

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
                    cont.Print();
                    searchFlag = true;
                }
            }
            if (!searchFlag)
            {
                Console.WriteLine("Договоры не найдены.");
            }
        }
    }
}
