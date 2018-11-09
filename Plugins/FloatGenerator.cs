using System;
using Faker;
using System.Threading;

namespace Plugins
{
    class FloatGenerator : IValueGenerator
    {
        public object GenerateValue(Random random)
        {
            byte[] bytes = new byte[sizeof(float)];
            random.NextBytes(bytes);
            return BitConverter.ToSingle(bytes, 0);
        }

        public Type GetValueType()
        {
            return typeof(float);
        }
    }
}
