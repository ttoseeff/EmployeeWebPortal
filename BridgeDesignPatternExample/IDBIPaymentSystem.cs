using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeDesignPatternExample
{
    public class IDBIPaymentSystem : IPaymentSystem
    {

        public void ProcessPayment(string PaymentSystem)
        {
            Console.Write("using IDBIBank gateway for " + PaymentSystem + "\n");
        }
    }
}
