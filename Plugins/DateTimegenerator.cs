using System;
using Faker;
using System.Threading;

namespace Plugins
{
    class DateTimegenerator : IValueGenerator
    {
        public object GenerateValue(Random random)
        {
            //Random random = new Random();
            DateTime result = new DateTime(random.Next(1, 3000), random.Next(1, 13), random.Next(1, 29), 
                random.Next(0, 24), random.Next(0, 60), random.Next(0, 60));
            return result;
        }

        public Type GetValueType()
        {
            return typeof(DateTime);
        }
    }
}
