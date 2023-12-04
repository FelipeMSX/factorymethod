﻿using AssemblyFactoryMethod;
using OmegaCore.Exceptions;
using System.Reflection;

namespace FactoryMethod
{
    /// <summary>
    /// Caches all types of a certain <typeparamref name="TType"/>.
    /// <para>Each implemation of <see cref="AssemblyFactoryBase{TType}"/> uses its own set of cached types.</para>
    /// <author>Felipe Morais: felipeprodev@gmail.com</author>
    /// </summary>
    public abstract class AssemblyFactoryBase<TType, TEnum>: IAssemblyFactoryMethod<TType, TEnum> 
        where TType : class
        where TEnum : Enum
    {
        public int Count => _cachedTypes.Count;

        /// <summary>
        /// Contains all registereds types to be used in runtime.
        /// </summary>
        private static readonly Dictionary<string, Type> _cachedTypes = new();

        static AssemblyFactoryBase()
        {
            Initialize();
        }

        private static void Initialize()
        {
            Type typeOfT = typeof(TType);

            var registredTypes = Assembly.GetAssembly(typeOfT)!.GetTypes().Where(t => CheckInstanceType(typeOfT, t));

            foreach (Type type in registredTypes)
            {
                AssemblyFactoryAttribute? assemblyFactoryAttribute = type.GetCustomAttribute<AssemblyFactoryAttribute>();
                
                //How can I log this?
                if (assemblyFactoryAttribute == null)
                    throw new AttributeIsMissingException();

                if(_cachedTypes.ContainsKey(assemblyFactoryAttribute.Name))
                    throw new DuplicatedKeyException();

                _cachedTypes.Add(assemblyFactoryAttribute.Name, type);
            }
        }

        /// <summary>
        /// <inheritdoc cref="IAssemblyFactoryMethod{TType, TEnum}.CreateInstance(TEnum)"/>
        /// </summary>
        /// <returns><inheritdoc cref="IAssemblyFactoryMethod{TType, TEnum}.CreateInstance(TEnum)"/></returns>
        public TType CreateInstance(TEnum value)
        {
            string keyType = value.ToString();

            if (!_cachedTypes.ContainsKey(keyType))
                throw new TypeNotRegisteredException();
            

            TType newInstance = CreateInstanceInternal(_cachedTypes[keyType]);

            return newInstance;
        }


        public TType CreateInstance(TEnum value, params object[] args)
        {
            string keyType = value.ToString();

            if (!_cachedTypes.ContainsKey(keyType))
                throw new TypeNotRegisteredException();

            TType newInstance = CreateInstanceInternal(_cachedTypes[keyType], args);

            return newInstance;
        }

        private static bool CheckInstanceType(Type typeOfT, Type type)
        {
            bool isDerived = typeOfT.IsAssignableFrom(type) && type.IsClass && !type.IsAbstract;

            return isDerived;
        }

        private static TType CreateInstanceInternal(Type type)
        {
            return (TType)Activator.CreateInstance(type)!;
        }

        private static TType CreateInstanceInternal(Type type, params object[] args)
        {
            return (TType)Activator.CreateInstance(type, args)!;
        }
    }
}
