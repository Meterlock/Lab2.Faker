using System;
using Faker;
using System.Threading;

namespace Plugins
{
    public class DoubleGenerator : IValueGenerator
    {
        public object GenerateValue(Random random)
        {
            byte[] bytes = new byte[sizeof(double)];
            random.NextBytes(bytes);
            return BitConverter.ToDouble(bytes, 0);
        }

        public Type GetValueType()
        {
            return typeof(double);
        }
    }
}
