using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
    public class SimpleAccount
    {
        private Decimal amount;
        private string firstName;
        private string lastName;

        public IEmailSender sender { set; get; }

        public SimpleAccount(string firstName, string lastName, Decimal amount)
        {
            if (firstName == null) { throw new ArgumentException("I need a first name"); }
            if (lastName == null) { throw new ArgumentException("I need a last name");  }
            this.firstName = firstName;
            this.lastName = lastName;
            this.amount = amount;
        }

        public Decimal getCurrentBalance()
        {
            return amount;
        }

        public void Debit(decimal v)
        {
            if (v > amount)
            {
                if (sender != null)
                {
                    sender.SendEmail("warning@mybank.com", "overdraft", "withdrawl request " + v + " too large for balance " + amount);
                }
                throw new ArgumentException("withdrawl too large");
            }
            amount = amount - v;
        }
    }
}
