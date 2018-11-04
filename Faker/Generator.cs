using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    public class Generator
    {
        private Dictionary<Type, Func<object>> generatorsDict;

        private void DictionaryFilling() { }

        public object GenerateValue(Type type)
        {
            object result = null;
            return result;
        }
    }
}
