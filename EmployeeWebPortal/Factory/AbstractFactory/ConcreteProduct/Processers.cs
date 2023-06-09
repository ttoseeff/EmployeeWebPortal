using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeWebPortal.Factory.AbstractFactory
{
    public class I3 : IProcesser
    {
        public string GetProceeser()
        {
            return Enumerations.Processers.I3.ToString();
        }
    }

    public class I5 : IProcesser
    {
        public string GetProceeser()
        {
            return Enumerations.Processers.I5.ToString();
        }
    }

    public class I7 : IProcesser
    {
        public string GetProceeser()
        {
            return Enumerations.Processers.I7.ToString();
        }
    }
}