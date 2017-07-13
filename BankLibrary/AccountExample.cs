using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
    public class AccountExample
    {
        private IEmailSender emailSender;

        public AccountExample(IEmailSender sender)
        {
            this.emailSender = sender;
        }
        private string firstName;

        public string GetFirstName()
        {
            return firstName;
        }

        public AccountExample SetFirstName(string value)
        {
            if (value == null)
            {
                throw new ArgumentException("first name cannot be null");
            }
            firstName = value;
            return this;
        }

        private string lastName;

        public string GetLastName()
        {
            return lastName;
        }

        public AccountExample SetLastName(string value)
        {
            if (value == null)
            {
                throw new ArgumentException("last name cannot be null");
            }
            lastName = value;
            return this;
        }

        public string AccountNumber { get; set; }

        public Decimal AccountBalance { get; set; }

        public AccountExample SetupAccount()
        {
            ValidateState();
            AccountNumber = Guid.NewGuid().ToString();
            AccountBalance = Decimal.Zero;
            return this; ;
        }

        public string GetAccountNumber()
        {
            ValidateState();
            // should we throw an exception if an account doesn't exist?
            return AccountNumber;
        }

        public decimal GetBalance()
        {
            ValidateState();
            return AccountBalance;
        }


        private void ValidateState()
        {
            if (firstName == null)
            {
                throw new ArgumentException("first name cannot be null");
            }
            if (lastName == null)
            {
                throw new ArgumentException("last name cannot be null");
            }
        }

        public decimal Deposit(decimal depositAmount)
        {
            AccountBalance += depositAmount;
            return AccountBalance;
        }

        public decimal Debit(decimal debitAmount)
        {
            if (debitAmount > AccountBalance)
            {
                if (emailSender != null)
                {
                    emailSender.sendEmail("foo@bar.com", "debit denied due to insufficient funds", " balance " + AccountBalance + "debit request " + debitAmount);
                }
                throw new ArgumentException("Unable to debit " + debitAmount + "because balance is " + AccountBalance);
            }
            AccountBalance -= debitAmount;
            return AccountBalance;
        }
    }
}
