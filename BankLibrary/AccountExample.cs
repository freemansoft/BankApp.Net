using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
    public class AccountExample
    {
        private string firstName;

        public string GetFirstName()
        {
            return firstName;
        }

        public void SetFirstName(string value)
        {
            if (value == null)
                {
                throw new ArgumentException("first name cannot be null");
                }
            firstName = value;
        }

        private string lastName;

        public string GetLastName()
        {
            return lastName;
        }

        public void SetLastName(string value)
        {
            if (value == null)
            {
                throw new ArgumentException("last name cannot be null");
            }
            lastName = value;
        }

        public string AccountNumber { get; set; }

        public Decimal AccountBalance { get; set; }

        public void setupAccount()
        {
            AccountNumber = Guid.NewGuid().ToString();
            AccountBalance = Decimal.Zero;
        }

        public object getAccountNumber()
        {
            // should we throw an exception if an account doesn't exist?
            return AccountNumber;
        }

        public decimal getBalance()
        {
            return AccountBalance;
        }
    }
}
