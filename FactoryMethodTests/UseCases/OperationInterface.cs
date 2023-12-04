using AssemblyFactoryMethod;
using FactoryMethod;

namespace FactoryMethodTests.UseCases
{
    public interface IOperation
    {
        public int Calc(int x, int y);
    }

    [AssemblyFactoryAttribute(typeof(Operations), nameof(Operations.Add))]
    public class Add : IOperation
    {
        public int Calc(int x, int y)
        {
            return x + y;
        }
    }

    [AssemblyFactoryAttribute(typeof(Operations), nameof(Operations.Multiply))]
    public class Multiply : IOperation
    {
        public int Calc(int x, int y)
        {
            return x * y;
        }
    }

    [AssemblyFactoryAttribute(typeof(Operations), nameof(Operations.Sub))]
    public class Sub : IOperation
    {
        public int Calc(int x, int y)
        {
            return x - y;
        }
    }

    public enum Operations { Add = 1, Multiply = 2 , Sub = 3 }

    public class OperationFactory : AssemblyFactoryBase<IOperation, Operations> {}
}