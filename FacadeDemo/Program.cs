// See https://aka.ms/new-console-template for more information
using ShoppingCart;
using ShoppingFacade;

Console.WriteLine("Hello, World!");

IUserOrder userOrder = new UserOrder();
Console.WriteLine("Facade : Start");
Console.WriteLine("************************************");
int cartID = userOrder.AddToCart(10, 1);
int userID = 1234;
Console.WriteLine("************************************");
int orderID = userOrder.PlaceOrder(cartID, userID);
Console.WriteLine("************************************");
Console.WriteLine("Facade : End CartID = {0}, OrderID = {1}",
    cartID, orderID);