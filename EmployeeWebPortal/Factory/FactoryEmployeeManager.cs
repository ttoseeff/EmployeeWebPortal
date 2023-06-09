using EmployeeWebPortal.Enums;
using EmployeeWebPortal.Managers;
using EmployeeWebPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeWebPortal.Factory
{
    public class FactoryEmployeeManager
    {
        public IEmployeeManager GetEmployeeManager(int EmployeeTypeId)
        {
            IEmployeeManager returnValue = null;
            switch (EmployeeTypeId)
            {
                case (int)EmployeeTypes.PermanantEmployee:
                    returnValue = new PermanentEmployeeManager();
                    break;
                case (int)EmployeeTypes.ContractEmployee:
                    returnValue = new ContractEmployeeManager();
                    break;
            }
            return returnValue;
        }
    }
}
