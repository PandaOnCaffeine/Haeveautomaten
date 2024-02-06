using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hæveautomaten
{
    public class Bank
    {
        private readonly string _bankName;
        private List<Konto> _clientList;
        public Bank(string bankName)
        {
            _bankName = bankName;
            _clientList = new List<Konto>();
        }
        public List<Konto> ShowClientList()
        {
            if (_clientList == null)
            {
                throw new NullReferenceException("null");
            }

            return _clientList;
        }
        public void RegisterClient(Konto client)
        {
            if (client == null)
            {
                throw new ArgumentNullException("null");
            }

            _clientList.Add(client);
        }
        public void UnregisterClient(int index)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            if (index > _clientList.Count - 1)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            _clientList.RemoveAt(index);
        }
        public Konto ClientLogin(int index, string inputPin)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            if (index > _clientList.Count - 1)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            if (_clientList[index].Pin.Pin != inputPin)
            {
                throw new ArgumentException("Pin Not Correct");
            }

            return _clientList[index];
        }
    }
}
