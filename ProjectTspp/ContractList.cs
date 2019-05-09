using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace ProjectTspp
{
    class ContractList
    {
        public string contractListPath = "contractList";
        List<Contract> contracts = new List<Contract>();

        private static ContractList instance;
        private ContractList() { }
        public static ContractList GetInstance()
        {
            if (instance == null)
            {
                instance = new ContractList();
                instance.ReadAndDeserialize(instance.contractListPath);
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
            Console.WriteLine($"Договор заключен. Всего договоров: {contracts.Count}");
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

        private void ReadAndDeserialize(string path)
        {
            var serializer = new XmlSerializer(typeof(List<Contract>));
            using (var reader = new StreamReader(path))
            {
                contracts = (List<Contract>)serializer.Deserialize(reader);
                return;
            }
        }

        public void SerializeAndSave(string path)
        {
            var serializer = new XmlSerializer(typeof(List<Contract>));
            using (var writer = new StreamWriter(path))
            {
                serializer.Serialize(writer, contracts);
            }
        }
    }
}
