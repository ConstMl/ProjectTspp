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
            throw new NotImplementedException();
        }

        public void Add()
        {
            throw new NotImplementedException();
        }

        public void Search()
        {
            throw new NotImplementedException();
        }

    }
}
