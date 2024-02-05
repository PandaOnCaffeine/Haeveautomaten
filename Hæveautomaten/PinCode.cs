using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hæveautomaten
{
    public class PinCode
    {
        private string _pin;
        public PinCode(string pin)
        {
            _pin = pin;
        }
        public string Pin
        {
            get { return _pin; }
        }

        public bool CheckPinInput(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException("null");
            }
            if (input != _pin)
            {
                throw new ArgumentException("Not Correct pin");
            }
            else
            {
                return true;
            }
        }
        public void ChangePin(string newPin)
        {
            if (newPin == null)
            {
                throw new ArgumentNullException("null");
            }

            if (newPin.Length < 4)
            {
                throw new ArgumentOutOfRangeException("Too Short");
            }

            if (newPin.Length > 8)
            {
                throw new ArgumentOutOfRangeException("Too Long");
            }

            _pin = newPin;
        }
    }
}
