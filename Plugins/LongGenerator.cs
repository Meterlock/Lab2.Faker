using System;
using Faker;
using System.Threading;

namespace Plugins
{
    public class LongGenerator : IValueGenerator
    {
        public object GenerateValue(Random random)
        {
            byte[] bytes = new byte[sizeof(long)];
            random.NextBytes(bytes);
            return BitConverter.ToInt64(bytes, 0);
        }

        public Type GetValueType()
        {
            return typeof(long);
        }
    }
}
