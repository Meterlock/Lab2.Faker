using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    public static class FakerSingleton
    {
        private static Faker instance;
        public static Random random = new Random();

        public static Faker getInstance()
        {
            if (instance == null)
                instance = new Faker();
            return instance;
        }

        
    }
}
