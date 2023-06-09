using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeDesignPatternExample
{
    public class CitiPaymentSystem : IPaymentSystem
    {
        public void ProcessPayment(string PaymentSystem)
        {
            Console.Write("using CitiBank gateway for " + PaymentSystem + "\n");
        }
    }
}
