using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    /// <summary>
    /// Mockable Interface used in WorldGreetingExample
    /// </summary>
    public interface ILanguageTranslator
    {
        
        string GenerateHelloGreeting(string language);

        string GenerateGoodbyeGreeting(string language);
    }
}
