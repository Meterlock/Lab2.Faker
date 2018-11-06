using System;
using Faker;
using System.Threading;

namespace Plugins
{
    class ByteGenerator : IValueGenerator
    {
        public object GenerateValue()
        {
            Thread.Sleep(10);
            return Convert.ToByte(new Random().Next(0, 256));
        }

        public Type GetValueType()
        {
            return typeof(byte);
        }
    }
}
