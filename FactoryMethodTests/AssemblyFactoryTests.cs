
namespace FactoryMethodTests.UseCases
{
    [TestClass]
	public class AssemblyFactoryAbilityTests
	{

        private AbilityFactory _abilityFactory = new AbilityFactory();
        private OperationFactory _operationFactory = new OperationFactory();
        private NumberProcessorFactory _numberProcessorFactory = new NumberProcessorFactory();


        #region Abstract Class

        [TestMethod, TestCategory("FactoryMethod")]
        public void Count_CheckCurrentSize_ItShouldBeFour()
        {
            
            //Arrange
            //Act
            //Assert
            Assert.IsTrue(_abilityFactory.Count == 4);
        }

        [TestMethod, TestCategory("FactoryMethod")]
        public void CreateInstance_GettingAbstractType_FireTypeCreated()
        {
            //Arrange
            //Act
            AbilityBase ability = _abilityFactory.CreateInstance<FireAbility>();
            //Assert
            Assert.IsTrue(ability.Name == "Fire");
        }

        #endregion


        #region Operation Interface

        [TestMethod, TestCategory("FactoryMethod")]
        public void Count_CheckCurrentSize_ItShouldBeThree()
        {
            //Arrange
            //Act
            //Assert
            Assert.IsTrue(_operationFactory.Count == 3);
        }

        [TestMethod, TestCategory("FactoryMethod")]
        public void CreateInstance_GettingInterfaceType_Success()
        {
            //Arrange
            //Act
            IOperation operation = _operationFactory.CreateInstance<Add>();
            var result = operation.Calc(5,5);
            //Assert
            Assert.IsTrue(result == 10);
        }

        #endregion

        #region Stateful Class 

        [TestMethod, TestCategory("FactoryMethod")]
        public void CreateInstance_CreatingTypeWithArgs_Success()
        {
            //Arrange
            //Act
            NumberProcessorBase numberProcessor = _numberProcessorFactory.CreateInstance<IsEvenStrategy>(10);
            //Assert
            Assert.IsTrue(numberProcessor.Check());
        }

        #endregion
    }
}
