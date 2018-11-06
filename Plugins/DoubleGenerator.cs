using System;
using Faker;
using System.Threading;

namespace Plugins
{
    public class DoubleGenerator : IValueGenerator
    {
        public object GenerateValue()
        {
            Thread.Sleep(10);
            byte[] bytes = new byte[sizeof(double)];
            new Random().NextBytes(bytes);
            return BitConverter.ToDouble(bytes, 0);
        }

        public Type GetValueType()
        {
            return typeof(double);
        }
    }
}
