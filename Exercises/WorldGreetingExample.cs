using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public class WorldGreetingExample
    {
        private ILanguageTranslator lt;

        String contactName = null;


        public WorldGreetingExample(ILanguageTranslator aTranslator)
        {
            this.lt = aTranslator ?? throw new ArgumentNullException("Missing Translator Required");
        }

        public WorldGreetingExample()
        {
        }

        public void SetContactName(string p0)
        {
            contactName = p0 ?? throw new ArgumentNullException("Contact name required");
        }

        public string SayGreeting()
        {
            return lt.TranslateFromEnglish("hello") + " " + contactName;
        }

    }
}
