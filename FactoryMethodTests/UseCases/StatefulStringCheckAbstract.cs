using AssemblyFactoryMethod;
using FactoryMethod;

namespace FactoryMethodTests.UseCases
{
    public abstract class NumberProcessorBase
    {
        public int Value { get; private set; }

        protected NumberProcessorBase(int value) 
        {
            Value = value;
        }

        public abstract bool Check();
    }

    [AssemblyFactoryAttribute(typeof(NumberProcessors), nameof(NumberProcessors.Even))]
    public class IsEvenStrategy : NumberProcessorBase
    {
        public IsEvenStrategy(int value) : base(value) { }

        public override bool Check() => Value % 2 == 0;
    }

    [AssemblyFactoryAttribute(typeof(NumberProcessors), nameof(NumberProcessors.Odd))]
    public class IsOddStrategy : NumberProcessorBase
    {
        public IsOddStrategy(int value) : base(value){}

        public override bool Check() => Value % 2 != 0;
    }

    public enum NumberProcessors { Odd = 1, Even = 2}

    public class NumberProcessorFactory : AssemblyFactoryBase<NumberProcessorBase, NumberProcessors> { }

}
