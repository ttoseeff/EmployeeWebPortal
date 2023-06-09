using DecoratorDesignPattern.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorDesignPattern.ConcreteComponent
{
    public class Suzuki : ICar
    {
        public string Make => "Sedan";

        public double GetPrice()
        {
            return 1000000;
        }
    }
}
