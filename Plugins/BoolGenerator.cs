using System;
using Faker;
using System.Threading;

namespace Plugins
{
    class BoolGenerator : IValueGenerator
    {
        public object GenerateValue()
        {
            /*Thread.Sleep(10);
            return Convert.ToBoolean(new Random().Next(0, 2));*/
            return true;
        }

        public Type GetValueType()
        {
            return typeof(bool);
        }
    }
}
