using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    public static class Faker
    {
        private static Generator generator = new Generator();
        public static List<Type> antiCycleList = new List<Type>();

        private static ConstructorInfo FindBaseConstructor(Type type)
        {
            ConstructorInfo[] constructors = type.GetConstructors();
            ConstructorInfo baseConstructor = null;

            foreach (ConstructorInfo constructor in constructors)
            {
                if (constructor.GetParameters().Count<ParameterInfo>() == 0)
                {
                    baseConstructor = constructor;
                    break;
                }
            }

            return baseConstructor;
        }

        private static ConstructorInfo FindMaxParamConstructor(Type type)
        {
            ConstructorInfo[] constructors = type.GetConstructors();
            ConstructorInfo maxParamConstructor = null;
            int maxCount = 0, paramCount = 0;

            foreach (ConstructorInfo constructor in constructors)
            {
                paramCount = constructor.GetParameters().Count<ParameterInfo>();
                if (paramCount > maxCount)
                {
                    maxCount = paramCount;
                    maxParamConstructor = constructor;
                }
            }

            return maxParamConstructor;
        }

        private static object CreateByFields(Type type)
        {
            object result = Activator.CreateInstance(type);
            FieldInfo[] fields = type.GetFields();
            PropertyInfo[] properties = type.GetProperties();

            foreach (FieldInfo field in fields)
            {
                field.SetValue(result, generator.GenerateValue(field.FieldType));                
            }
            foreach (PropertyInfo property in properties)
            {
                if (property.CanWrite && property.SetMethod.IsPublic)
                {
                    property.SetValue(result, generator.GenerateValue(property.PropertyType));
                }
            }

            return result;
        }

        private static object CreateByConstructor(ConstructorInfo constructor, Type type)
        {
            object[] parametersValues = new object[constructor.GetParameters().Count<ParameterInfo>()];
            ParameterInfo[] parameters = constructor.GetParameters();
            object result = null;

            for (int i = 0; i < parametersValues.Length; i++)
            {
                parametersValues[i] = generator.GenerateValue(parameters[i].ParameterType);
            }
            try
            {
                result = constructor.Invoke(parametersValues);
            }
            catch (Exception e) { }
            
            return result;
        }

        public static T Create<T>()
        {
            Type type = typeof(T);
            antiCycleList.Add(type);
            object result = null;            
            ConstructorInfo maxParamConstructor = FindMaxParamConstructor(type);
            ConstructorInfo baseConstructor = FindBaseConstructor(type);
            int publicFieldsCount = type.GetFields().Count();
            int publicPropertiesCount = type.GetProperties().Count();

            if ((maxParamConstructor == null) && (baseConstructor == null))
                return (type.IsValueType ? (T)Activator.CreateInstance(type) : (T)result);
            if ((maxParamConstructor == null) || ((baseConstructor != null) &&
                (maxParamConstructor.GetParameters().Count() < publicFieldsCount + publicPropertiesCount)))
            {
                result = CreateByFields(type);
            }
            else
            {
                result = CreateByConstructor(maxParamConstructor, type);
            }

            antiCycleList.Remove(type);
            return (T)result;
        }
    }
}
