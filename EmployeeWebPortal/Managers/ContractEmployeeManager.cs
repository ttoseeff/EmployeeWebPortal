using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeWebPortal.Managers
{
    public class ContractEmployeeManager : IEmployeeManager
    {
        public decimal GetBonus()
        {
            return 5;
        }

        public decimal GetHourlyPay()
        {
            return 7;
        }

        public decimal  GetMedicalAllowance()
        {
            return 100;
        }
    }
}