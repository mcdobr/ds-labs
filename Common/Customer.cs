using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [Serializable]
    public class Customer
    {
        public string name, creditCard, email;

        public Customer() { }

        public Customer(string name, string creditCard, string email)
        {
            this.name = name;
            this.creditCard = creditCard;
            this.email = email;
        }
    }
}
