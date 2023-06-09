using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeWebPortal.Factory.AbstractFactory
{
    public class Enumerations
    {
        public enum ComputerTypes
        {
            Laptop,
            Desktop
        }
        
        public enum Brands
        {
            APPLE,
            DELL
        }
        
        public enum Processers
        {
            I3,
            I5,
            I7
        }
    }
}