namespace FactoryMethod
{
    /// <summary>
    /// <author>Felipe Morais: felipeprodev@gmail.com</author>
    /// </summary>
    /// <typeparam name="TType">The type of the object to be cached.</typeparam>
    public interface IAssemblyFactoryMethod<TType>
    {
        /// <summary>
        /// The numbers of cached types of <typeparamref name="TType"/>
        /// </summary>
        public int Count { get; }

        /// <summary>
        /// Creates an instance of <typeparamref name="TRequestType"/>
        /// </summary>
        /// <typeparam name="TRequestType">The type of the object to be looked up in the cache.</typeparam>
        /// <returns> Returns a new instance of the requested type.</returns>>
        TType CreateInstance<TRequestType>() where TRequestType : TType, new();

        /// <summary>
        /// <inheritdoc cref="IAssemblyFactoryMethod{TType}.CreateInstance{TRequestType}()"/>
        /// </summary>
        /// <typeparam name="TRequestType"><inheritdoc cref="IAssemblyFactoryMethod{TType}.CreateInstance{TRequestType}()"/>.</typeparam>
        /// <returns><inheritdoc cref="IAssemblyFactoryMethod{TType}.CreateInstance{TRequestType}()"/></returns>
        TType CreateInstance<TRequestType>(params object[] args) where TRequestType : TType;
    }
}