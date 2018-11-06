using System;
using Faker;
using System.Threading;

namespace Plugins
{
    public class LongGenerator : IValueGenerator
    {
        public object GenerateValue()
        {
            Thread.Sleep(10);
            byte[] bytes = new byte[sizeof(long)];
            new Random().NextBytes(bytes);
            return BitConverter.ToInt64(bytes, 0);
        }

        public Type GetValueType()
        {
            return typeof(long);
        }
    }
}
