using System;
using Faker;
using System.Threading;

namespace Plugins
{
    class FloatGenerator : IValueGenerator
    {
        public object GenerateValue()
        {
            Thread.Sleep(10);
            byte[] bytes = new byte[sizeof(float)];
            new Random().NextBytes(bytes);
            return BitConverter.ToSingle(bytes, 0);
        }

        public Type GetValueType()
        {
            return typeof(float);
        }
    }
}
