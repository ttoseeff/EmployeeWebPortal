using DecoratorDesignPattern.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorDesignPattern.Decorator
{
    public abstract class CarDecorator : ICar
    {
        private ICar car;
        public CarDecorator(ICar car)
        {
            this.car = car;
        }

        public string Make => this.car.Make
            ;

        public double GetPrice()
        {
            return this.car.GetPrice();
        }
        public abstract double GetDiscountedPrice();
    }
}
