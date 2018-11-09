using System;
using Faker;
using System.Threading;

namespace Plugins
{
    class StringGenerator : IValueGenerator
    {
        public object GenerateValue(Random random)
        {
            //Random random = new Random();
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            int length = random.Next(1, 30);
            string result = "";

            for (int i = 0; i < length; i++)
            {
                result += chars[random.Next(0, chars.Length)];
            }
            return result;
        }

        public Type GetValueType()
        {
            return typeof(string);
        }
    }
}
