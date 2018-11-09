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

            TestClass1 test1 = FakerSingleton.getInstance().Create<TestClass1>();
            TestClass3 test2 = FakerSingleton.getInstance().Create<TestClass3>();

            foreach(byte elem in test1.val10)
            {
                Console.WriteLine(elem);
            }

            Console.ReadKey();
        }
    }
}
