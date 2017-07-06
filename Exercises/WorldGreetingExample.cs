using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public class WorldGreetingExample
    {
        private LanguageTranslator lt;

        String contactName = null;


        public WorldGreetingExample(LanguageTranslator aTranslator)
        {
            if (aTranslator == null)
            {
                throw new ArgumentNullException("Missing Translator Required");
            }
            this.lt = aTranslator;
        }

        public WorldGreetingExample()
        {
        }

        public void setContactName(string p0)
        {
            if (p0 == null)
            {
                throw new ArgumentNullException("Contact name required");
            }
            contactName = p0;
        }

        public string sayGreeting()
        {
            return lt.translateFromEnglish("hello") +" "+contactName;
        }

    }
}
