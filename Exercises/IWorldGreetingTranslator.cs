﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public interface ILanguageTranslator
    {
        
        string GenerateHelloGreeting(string language);

        string GenerateGoodbyeGreeting(string language);
    }
}