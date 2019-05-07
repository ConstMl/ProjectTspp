using System;

namespace ProjectTspp
{
    class Contract
    {
        public Customer Cust { get; set; }
        public DateTime Validity { get; set; }
        public int InsuranceAmuont { get; set; }
        public int CompensationPrecentage { get; set; }

        public void Activate()
        {
            throw new NotImplementedException();
        }

        public void RenewContract()
        {
            throw new NotImplementedException();
        }
    }
}
