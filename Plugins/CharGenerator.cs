using System;
using Faker;
using System.Threading;

namespace Plugins
{
    class CharGenerator : IValueGenerator
    {
        public object GenerateValue()
        {
            Thread.Sleep(10);
            byte[] bytes = new byte[sizeof(char)];
            new Random().NextBytes(bytes);
            return BitConverter.ToChar(bytes, 0);
        }

        public Type GetValueType()
        {
            return typeof(char);
        }
    }
}
