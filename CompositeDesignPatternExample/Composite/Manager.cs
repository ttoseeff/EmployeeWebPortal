using CompositeDesignPatternExample.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeDesignPatternExample.Composite
{
    public class Manager : IEmployee
    {
        public List<IEmployee> SubOrdinates;
        public string Name { get; set; }
        public string Department { get; set; }

        public Manager(string Name, string Department)
        {
            this.Name = Name;
            this.Department = Department;
            SubOrdinates = new List<IEmployee>();
        }
        public void GetDetails(int indentation)
        {
            Console.WriteLine(string.Format("{0}+ Name: {1} Dept:{2} ", new String('-', indentation), this.Name, this.Department));
            foreach(var employee in SubOrdinates)
            {
                employee.GetDetails(indentation + 1);
            }
        }
    }
}
