using AssemblyFactoryMethod;
using FactoryMethod;

namespace FactoryMethodTests.UseCases
{
    public abstract class AbilityBase
    {
        public abstract string Name { get; set; }

        public abstract string CreateMessage();
    }

    [AssemblyFactoryAttribute(typeof(AbilityEnum), nameof(AbilityEnum.Fire))]
    public class FireAbility : AbilityBase
    {
        public override string Name { get; set; } = "Fire";

        public override string CreateMessage() => "It does 1 damage.";
    }

    [AssemblyFactoryAttribute(typeof(AbilityEnum), nameof(AbilityEnum.Poison))]
    public class PoisonAbility : AbilityBase
    {
        public override string Name { get; set; } = "Poison";

        public override string CreateMessage() => "it does 1 damage over time during 5 seconds.";
    }

    [AssemblyFactoryAttribute(typeof(AbilityEnum), nameof(AbilityEnum.Explosion))]
    public class ExplosionAbility : AbilityBase
    {
        public override string Name { get; set; } = "Explosion";

        public override string CreateMessage() => "It does 1 damage in a big radius.";
    }

    [AssemblyFactoryAttribute(typeof(AbilityEnum), nameof(AbilityEnum.Nullable))]
    //Null Object Pattern
    public class NullableAbility : AbilityBase
    {
        public override string Name { get; set; } = "Nullable";

        public override string CreateMessage() => "It does nothing.";
    }

    public enum AbilityEnum { Fire = 0, Poison = 1, Explosion = 2, Nullable = 3 }


    public class AbilityFactory : AssemblyFactoryBase<AbilityBase, AbilityEnum> {}
}
