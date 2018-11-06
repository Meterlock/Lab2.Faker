using System;
using Faker;

namespace Plugins
{
    class IntGenerator : IValueGenerator
    {
        public object GenerateValue()
        {
            return new Random().Next();
        }

        public Type GetValueType()
        {
            return typeof(int);
        }
    }
}
