// See https://aka.ms/new-console-template for more information
using CompositeDesignPatternExample.Component;
using CompositeDesignPatternExample.Composite;
using CompositeDesignPatternExample.Leaf;

IEmployee John = new Employee("John", "IT");
IEmployee Mike = new Employee("Mike", "IT");
IEmployee Jason = new Employee("Jason", "HR");
IEmployee Eric = new Employee("Eric", "HR");
IEmployee Henry = new Employee("Henry", "HR");

IEmployee James = new Manager("James", "IT")
{ SubOrdinates = { John, Mike } };
IEmployee Philip = new Manager("Philip", "HR")
{ SubOrdinates = { Jason, Eric, Henry } };

IEmployee Bob = new Manager("Bob", "Head")
{ SubOrdinates = { James, Philip } };
Bob.GetDetails(1);
Console.ReadLine();
