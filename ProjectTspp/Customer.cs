using System;

namespace ProjectTspp
{
    class Customer
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public long PasportSeriesNumber { get; set; }
        public long Phone { get; set; }

        public void ViewContract()
        {
            throw new NotImplementedException();
        }
    }
}
