using CompositeDesignPatternExample.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeDesignPatternExample.Leaf
{
    public class Employee : IEmployee
    {
        public string  Name { get; set; }
        public string Department { get; set; }

        public Employee(string Name, string Department) 
        {
            this.Name = Name;
            this.Department = Department;
        }
        public void GetDetails(int indentation)
        {
           Console.WriteLine(string.Format("{0}+ Name: {1} Dept:{2} ", new String('-', indentation), this.Name, this.Department));
        }
    }
}
