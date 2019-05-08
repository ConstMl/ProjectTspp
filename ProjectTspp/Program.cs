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
            InsuranceSpecialist spec2 = new InsuranceSpecialist();
            spec2.AddCustomer();
            spec2.ViewCustomerList();
            Console.WriteLine("The end");
            Console.ReadKey();
        }
    }
}
