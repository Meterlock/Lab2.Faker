using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    public class Faker
    {
        private ConstructorInfo FindBaseConstructor(Type type)
        {
            return null;
        }

        private ConstructorInfo FindMaxParamConstructor(Type type)
        {
            return null;
        }

        public object CreateByFields(Type type)
        {
            return null;
        }

        public object CreateByConstructor(Type type)
        {
            return null;
        }

        public T Create<T>()
        {
            Type type = typeof(T);
            object result = null;
            return (T)result;
        }
    }
}
