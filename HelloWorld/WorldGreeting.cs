using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    public class WorldGreeting
    {

        public WorldGreeting(LanguageTranslator aTranslator)
        {
            if (aTranslator == null)
            {
                throw new ArgumentNullException();
            }
            this.lt = aTranslator;
        }

        public WorldGreeting()
        {
        }

        private LanguageTranslator lt;

        String contactName = null;

        public void seContactName(string p0)
        {
            contactName = p0;
        }

        public string sayGreeting()
        {
            return lt.translateFromEnglish("hello") +" "+contactName;
        }

    }
}
