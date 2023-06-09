using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace EmployeeWebPortal
{
    public class ComputerSystem
    {
        public string RAM { get; set; }
        public string HDDSize { get; set; }
        public string Keyboard { get; set; }
        public string Mouse { get; set; }
        public string TouchScreen { get; set; }

        public ComputerSystem() { }
        //public string Build()
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append(string.Format("RAM: {0}", RAM));
        //    sb.Append(string.Format(" HDD Size: {0}", HDDSize));
        //    return sb.ToString();
        //}
    }
}