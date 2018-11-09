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
            TestClass3 test2 = Faker.Create<TestClass3>();
            Console.WriteLine(test2.val1);
            Console.WriteLine(test2.val2);
            Console.WriteLine(test2.val3);

            Console.ReadKey();
        }
    }
}
