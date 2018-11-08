using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    class ListGenerator : IValueGenerator
    {
        public Type type;
        private Generator generator = new Generator();

        public ListGenerator(Type _type)
        {
            type = _type;
        }

        public object GenerateValue()
        {
            Random random = new Random();
            object list = Activator.CreateInstance(typeof(List<>).MakeGenericType(type));
            int count = random.Next(1, 25);
            for (int i = 0; i < count; i++)
            {
                ((IList)list).Add(generator.GenerateValue(type));
            }
            return list;
        }

        public Type GetValueType()
        {
            return typeof(List<>);
        }
    }
}
