
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hæveautomaten
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Konto ba = new Konto("Mr. Bryan Walton", "1234", 11.99M);

            ba.Withdraw(4.99M, "1234");
            Console.WriteLine("Current balance is ${0}", ba.Balance);

            decimal startBalance = 12.45M;
            Console.WriteLine(startBalance);
            Console.ReadLine();
        }
    }
}
