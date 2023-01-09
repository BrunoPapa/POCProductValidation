using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProductValidation.Tests
{
    [TestClass]
    public class PrimeService_IsPrimeShould
    {
        
        public PrimeService_IsPrimeShould()
        {
            
        }

        [TestMethod]
        public void IsPrime_InputIs1_ReturnFalse()
        {
            bool result = false;
            Assert.IsFalse(result, "1 should not be prime");
        }
    }
}