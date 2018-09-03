using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    /// <summary>
    /// Simple Hello World that accepts a parameter
    /// </summary>
    public class HelloWorldExample
    {
        String contactName = null;

        public void SetContactName(string p0)
        {
            contactName = p0;
        }

        public string SayHello()
        {
            if (contactName != null)
            {
                return "Hello " + contactName;
            }
            else
            {
                return "Hello";
            }
        }
    }
}
