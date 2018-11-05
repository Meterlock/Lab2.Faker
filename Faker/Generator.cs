using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    public class Generator
    {
        private Dictionary<Type, Func<object>> generatorsDict;
        private Assembly asmbl;

        public Generator()
        {
            var dir = new DirectoryInfo(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));
            dir = dir.Parent.Parent.Parent;
            asmbl = Assembly.LoadFile(dir.FullName + "\\Plugins\\bin\\Debug\\Plugins.dll");

            generatorsDict = new Dictionary<Type, Func<object>>();
            DictionaryFilling();
        }

        private void DictionaryFilling()
        {
            Type[] asmblTypes = asmbl.GetTypes();

            foreach (var type in asmblTypes)
            {
                if (type.GetInterface(typeof(IValueGenerator).ToString()) != null)
                {
                    var plugin = asmbl.CreateInstance(type.FullName) as IValueGenerator;

                    if (!generatorsDict.ContainsKey(plugin.GetValueType()))
                        generatorsDict.Add(plugin.GetValueType(), plugin.GenerateValue);
                }
            }
        }

        public object GenerateValue(Type type)
        {
            object result = null;
            return result;
        }
    }
}
