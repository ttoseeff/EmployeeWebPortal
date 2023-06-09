using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeWebPortal.Factory.AbstractFactory
{
    public class MAC : IBrand
    {
        public string GetBrand()
        {
            return Enumerations.Brands.APPLE.ToString();
        }
    }
}