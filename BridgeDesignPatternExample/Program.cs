// See https://aka.ms/new-console-template for more information
using BridgeDesignPatternExample;
using System.Reflection.Metadata.Ecma335;

Console.WriteLine("Hello, World!");

Payment order = new CardPayment();
order._IPaymentSystem = new CitiPaymentSystem();
order.MakePayment();

order._IPaymentSystem = new IDBIPaymentSystem();
order.MakePayment();

order = new NetBankingPayment();
order._IPaymentSystem = new CitiPaymentSystem();
order.MakePayment();

