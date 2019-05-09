using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTspp
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerList customerList = CustomerList.GetInstance();

            InsuranceSpecialist spec2 = new InsuranceSpecialist();
            //spec2.AddCustomer();
            spec2.ViewCustomerList();
            //spec2.SearchCustomer();
            Console.WriteLine("The end");

            Console.ReadKey();
        }
    }
}
