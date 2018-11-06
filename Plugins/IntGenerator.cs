using System;
using Faker;
using System.Threading;

namespace Plugins
{
    public class IntGenerator : IValueGenerator
    {
        public object GenerateValue()
        {
            Thread.Sleep(10);
            return new Random().Next();            
        }

        public Type GetValueType()
        {
            return typeof(int);
        }
    }
}
