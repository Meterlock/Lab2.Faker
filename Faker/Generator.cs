using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Collections;

namespace Faker
{
    public class Generator
    {
        private Dictionary<Type, Func<Random, object>> generatorsDict;
        private Assembly asmbl;

        public Generator()
        {
            var dir = new DirectoryInfo(Directory.GetCurrentDirectory());
            dir = dir.Parent.Parent.Parent;
            asmbl = Assembly.LoadFile(dir.FullName + "\\Plugins\\obj\\Debug\\Plugins.dll");

            generatorsDict = new Dictionary<Type, Func<Random, object>>();
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
            Func<Random, object> genDelegate = null;

            if (type.IsGenericType && (type.GetInterface(nameof(IList)) != null))
            {
                result = new ListGenerator(type.GenericTypeArguments[0]).GenerateValue(FakerSingleton.random);                
            }
            else if (generatorsDict.TryGetValue(type, out genDelegate))
            {
                result = genDelegate(FakerSingleton.random);
            }
            else
            {
                if (!FakerSingleton.getInstance().antiCycleList.Contains(type))
                    result = FakerSingleton.getInstance().Create(type);
            }

            return result;
        }
    }
}