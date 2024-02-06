using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hæveautomaten
{
    public class Konto
    {
        private readonly string _name;
        private PinCode _pin;
        private decimal _balance;
        public Konto(string name, string pin, decimal balance)
        {
            _name = name;
            _pin = new PinCode(pin);
            _balance = balance;
        }
        public string Name
        {
            get { return _name; }
        }
        public PinCode Pin
        {
            get { return _pin; }
        }
        public decimal Balance
        {
            get { return _balance; }
        }
        public void Deposit(decimal amount, string inputPin)
        {
            if (!_pin.CheckPinInput(inputPin))
            {
                throw new ArgumentException();
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }

            _balance += amount;
        }
        public void Withdraw(decimal amount, string inputPin)
        {
            if (!_pin.CheckPinInput(inputPin))
            {
                throw new Exception();
            }

            if (amount > _balance)
            {
                throw new ArgumentOutOfRangeException("amount");
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }

            _balance -= amount;
        }
        public void Transfer(decimal transferAmount, string inputPin, Konto transferTo)
        {
            if (!_pin.CheckPinInput(inputPin))
            {
                throw new ArgumentException();
            }

            if (transferAmount > _balance)
            {
                throw new ArgumentOutOfRangeException("Amount");
            }

            if (transferAmount < 0)
            {
                throw new ArgumentOutOfRangeException("Amount");
            }

            _balance -= transferAmount;
            transferTo.TransferAccept(transferAmount);
        }

        public void TransferAccept(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }

            _balance += amount;
        }
    }
}
