using System;
using Faker;
using System.Threading;

namespace Plugins
{
    public class IntGenerator : IValueGenerator
    {
        public object GenerateValue(Random random)
        {
            return random.Next();            
        }

        public Type GetValueType()
        {
            return typeof(int);
        }
    }
}
