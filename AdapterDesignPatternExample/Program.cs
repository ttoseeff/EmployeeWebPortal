// See https://aka.ms/new-console-template for more information
using AdapterDesignPatternExample.Adapter;
using AdapterDesignPatternExample.Adatper;

Console.WriteLine("Hello, World!");

IEmployee emp = new EmployeeAdapter();
var value = emp.GetAllEmployees();
Console.WriteLine(value);

