using System.Reflection;

namespace FactoryMethod
{
    /// <summary>
    /// Caches all types of a certain <typeparamref name="TType"/>.
    /// <para>Each implemation of <see cref="AssemblyFactoryBase{TType}"/> uses its own set of cached types.</para>
    /// <author>Felipe Morais: felipeprodev@gmail.com</author>
    /// </summary>
    public abstract class AssemblyFactoryBase<TType>: IAssemblyFactoryMethod<TType> where TType : class
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
                _cachedTypes.Add(type.Name, type);
            }
        }

        /// <summary>
        /// <inheritdoc cref="IAssemblyFactoryMethod{TType}.CreateInstance{TRequestType}()"/>
        /// </summary>
        /// <typeparam name="TRequestType"><inheritdoc cref="IAssemblyFactoryMethod{TType}.CreateInstance{TRequestType}()"/>.</typeparam>
        /// <returns><inheritdoc cref="IAssemblyFactoryMethod{TType}.CreateInstance{TRequestType}()"/></returns>
        public TType CreateInstance<TRequestType>() where TRequestType : TType, new()
        {
            string className = typeof(TRequestType).Name;

            TType newInstance = CreateInstanceInternal(_cachedTypes[className]);
            return newInstance;
        }

        /// <summary>
        /// <inheritdoc cref="IAssemblyFactoryMethod{TType}.CreateInstance{TRequestType}()"/>
        /// </summary>
        /// <typeparam name="TRequestType"><inheritdoc cref="IAssemblyFactoryMethod{TType}.CreateInstance{TRequestType}()"/>.</typeparam>
        /// <returns><inheritdoc cref="IAssemblyFactoryMethod{TType}.CreateInstance{TRequestType}()"/></returns>
        public TType CreateInstance<TRequestType>(params object[] args) where TRequestType : TType
        {
            string className = typeof(TRequestType).Name;

            TType newInstance = CreateInstanceInternal(_cachedTypes[className], args);
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
