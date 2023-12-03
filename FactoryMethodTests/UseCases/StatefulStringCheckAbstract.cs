
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

    public class IsEvenStrategy : NumberProcessorBase
    {
        public IsEvenStrategy(int value) : base(value) { }

        public override bool Check() => Value % 2 == 0;
    }

    public class IsOddStrategy : NumberProcessorBase
    {
        public IsOddStrategy(int value) : base(value){}

        public override bool Check() => Value % 2 != 0;
    }

    public class NumberProcessorFactory : AssemblyFactoryBase<NumberProcessorBase> { }

}
