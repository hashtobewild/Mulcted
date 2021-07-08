using Mulcted.Processes.Implementations;
using NUnit.Framework;

namespace Mulcted.UnitTests
{
    public class Tests
    {
        private TaxCalculator _taxCalculator;

        [SetUp]
        public void Setup()
        {
            _taxCalculator = new TaxCalculator();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void TestListAgeBasedValues_ReturnsAgeBasedItemCountEqualsTwo()
        {
            Assert.AreEqual(2, _taxCalculator.AgeBasedRelief.Count);
        }

        [Test]
        public void TestListDeductionsValues_ReturnsDeductionsCountEqualsSeven()
        {
            Assert.AreEqual(7, _taxCalculator.Deductions.Count);
        }
    }
}