using EmployeeWebPortal.Managers;
using EmployeeWebPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeWebPortal.Factory.FactoryMethod
{
    public abstract class BaseEmployeeFactory
    {
        protected Employee _emp;
        public BaseEmployeeFactory(Employee emp) 
        {
            _emp= emp;
        }

        public Employee ApplySalary()
        {
            IEmployeeManager manager = this.Create();
            _emp.HourlyPay = manager.GetHourlyPay();
            _emp.Bonus = manager.GetBonus();
            return _emp;
        }

        public abstract IEmployeeManager Create();
    }
}