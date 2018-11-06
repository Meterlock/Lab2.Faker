using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("App is running!");
            
            TestClass1 test1 = Faker.Create<TestClass1>();
            Console.WriteLine(test1.val1);
            Console.WriteLine(test1.val2);
            Console.WriteLine(test1.val3.val0);

            Console.ReadKey();
        }
    }
}
