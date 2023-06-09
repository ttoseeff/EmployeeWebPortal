// See https://aka.ms/new-console-template for more information

using DecoratorDesignPattern.Component;
using DecoratorDesignPattern.ConcreteComponent;
using DecoratorDesignPattern.ConcreteDecorator;
using DecoratorDesignPattern.Decorator;

ICar car = new Suzuki();

CarDecorator decorator = new OfferPrice(car);

var value = string.Format("Make: {0}, Price: {1}, Discounted Price: {2}", decorator.Make, decorator.GetPrice(), decorator.GetDiscountedPrice());
Console.WriteLine(value);

ICar car2 = new Hyndai();
decorator = new OfferPrice(car2);

var value2 = string.Format("Make: {0}, Price: {1}, Discounted Price: {2}", decorator.Make, decorator.GetPrice(), decorator.GetDiscountedPrice());

Console.WriteLine(value2);