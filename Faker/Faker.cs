using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    public class Faker
    {
        private ConstructorInfo FindBaseConstructor(Type type)
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

        private ConstructorInfo FindMaxParamConstructor(Type type)
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

        public object CreateByFields(Type type)
        {
            return null;
        }

        public object CreateByConstructor(ConstructorInfo constructor, Type type)
        {
            return null;
        }

        public T Create<T>()
        {
            Type type = typeof(T);
            object result = null;            
            ConstructorInfo maxParamConstructor = FindMaxParamConstructor(type);
            ConstructorInfo baseConstructor = FindBaseConstructor(type);
            int publicFieldsCount = type.GetFields().Count<FieldInfo>();
            int publicPropertiesCount = type.GetProperties().Count<PropertyInfo>();
            
            if ((maxParamConstructor == null) || ((baseConstructor != null) &&
                (maxParamConstructor.GetParameters().Count<ParameterInfo>() < publicFieldsCount + publicPropertiesCount)))
            {
                result = CreateByFields(type);
            }
            else
            {
                result = CreateByConstructor(maxParamConstructor, type);
            }

            return (T)result;
        }
    }
}
