using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Faker;

namespace Plugins
{
    class IntGenerator : IValueGenerator
    {
        public object GenerateValue()
        {
            return new Random().Next();
        }
    }
}
