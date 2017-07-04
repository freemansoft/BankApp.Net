using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
    public class HelloWorld
    {
        String contactName = null;

        public void seContactName(string p0)
        {
            contactName = p0;
        }

        public string sayHello()
        {
            return "Hello " + contactName;
        }
    }
}
