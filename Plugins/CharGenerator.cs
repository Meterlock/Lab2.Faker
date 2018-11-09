using System;
using Faker;
using System.Threading;

namespace Plugins
{
    class CharGenerator : IValueGenerator
    {
        public object GenerateValue(Random random)
        {
            byte[] bytes = new byte[sizeof(char)];
            random.NextBytes(bytes);            
            return BitConverter.ToChar(bytes, 0);
        }

        public Type GetValueType()
        {
            return typeof(char);
        }
    }
}
