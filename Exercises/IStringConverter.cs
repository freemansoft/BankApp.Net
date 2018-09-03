using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    /// <summary>
    /// Mockable interface used in StringSetExample.cs
    /// </summary>
    public interface IStringConverter
    {
        /// <summary>
        /// translates form original string to the language of this translator
        /// </summary>
        /// <param name="originalString"></param>
        /// <returns></returns>
        string Translate(string originalString);
    }
}
