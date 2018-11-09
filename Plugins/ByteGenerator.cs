using System;
using Faker;
using System.Threading;

namespace Plugins
{
    class ByteGenerator : IValueGenerator
    {
        public object GenerateValue(Random random)
        {
            return Convert.ToByte(random.Next(0, 256));
        }

        public Type GetValueType()
        {
            return typeof(byte);
        }
    }
}
