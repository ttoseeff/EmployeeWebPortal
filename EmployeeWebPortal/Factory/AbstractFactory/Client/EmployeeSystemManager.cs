using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeWebPortal.Factory.AbstractFactory
{
    public class EmployeeSystemManager
    {
        IComputerFactory _IComputerFactory;
        public EmployeeSystemManager(IComputerFactory computerFactory)
        {
            _IComputerFactory = computerFactory;
        }

        public string GetSystemDetails()
        {
            IBrand brand = _IComputerFactory.Brand();
            IProcesser processer = _IComputerFactory.Processer();
            ISystemType systemType = _IComputerFactory.SystemType();
            string returnValue = string.Format("{0} {1} {2}", brand.GetBrand(), processer.GetProceeser(), systemType.GetSystemType());
            return returnValue;
        }
    }
}