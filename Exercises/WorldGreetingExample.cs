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
        String language = "EN";


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

        public void SetLanguage(string p0)
        {
            if (p0 == null || p0.Length < 1) {
                throw new ArgumentNullException("Lauage cannot be null or empty");
            }
            else
            {
                language = p0;
            }
        }

        public string SayGreeting()
        {
            return lt.GenerateHelloGreeting(language) + " " + contactName;
        }

    }
}
