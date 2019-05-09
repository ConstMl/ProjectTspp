using System;

namespace ProjectTspp
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerList customerList = CustomerList.GetInstance();

            InsuranceSpecialist spec2 = new InsuranceSpecialist();
            spec2.AddCustomer();
            //spec2.AddCustomer();
            spec2.AddConract(ContractType.ContractLifeHealth);
            spec2.AddConract(ContractType.ContractMovableProperty);
            spec2.ViewCustomerList();
            spec2.ViewContractList();
            Console.WriteLine("The end");

            Console.ReadKey();
        }
    }
}
