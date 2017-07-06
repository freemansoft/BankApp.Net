using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public class StringSetExample
    {
        private List<string> OurSet { get; set; }

        public StringSetExample()
        {
            OurSet = new List<string>();
        }

        public int Count()
        {
            return OurSet.Count();
        }

        public int Add(string p)
        {
            OurSet.Add(p);
            return this.Count();
        }

        public bool Contains(string p)
        {
            return OurSet.IndexOf(p) != -1;
        }

        public bool ContainsWithLinq(string p)
        {
            IEnumerable<string> matches = OurSet.Where(aString => p.Equals(aString));
            return matches.Count() > 0;
        }


        public void Remove(string p)
        {
            List<string> prunedList = new List<string>();
            foreach (string astring in OurSet)
            {
                if (!astring.Equals(p))
                {
                    prunedList.Add(astring);
                }
            }
            OurSet = prunedList;
        }


        public void RemoveWithLinq(string p)
        {
            List<string> prunedList = OurSet.Where(aString => !aString.Equals(p)).ToList();
            OurSet = prunedList;
        }


        internal IEnumerable<string> GetEnumeration()
        {
            return OurSet.AsEnumerable<string>();
        }

        public StringSetExample Translate(IStringConverter aTranslator)
        {
            StringSetExample result = new StringSetExample();
            foreach (string aString in this.GetEnumeration())
            {
                result.Add(aTranslator.Translate(aString));
            }
            return result;
        }
    }
}
