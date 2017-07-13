using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
    /// <summary>
    /// Interface used as part of the mocking example
    /// </summary>
    public interface IEmailSender
    {
        bool sendEmail(string to, string subject, string message);
    }
}
