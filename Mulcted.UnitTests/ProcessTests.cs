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
        // These should all yield a zero taxable amount
        [TestCase(0, 0, 0)]
        [TestCase(17, 60000, 300)]
        [TestCase(18, 60000, 0)]
        [TestCase(50, 60000, 0)]
        [TestCase(51, 120000, 0)]
        // Age varience
        [TestCase(51, 180000, 7650)]
        public void TestInputTaxCalculations(int age, decimal salary, decimal taxAmount)
        {
            var result = _taxCalculator.Calculate(age, salary);
            Assert.AreEqual(taxAmount, result.DeductionAmount);
        }

        [Test]
        public void TestListAgeBasedValues_ReturnsAgeBasedItemCountEqualsTwo()
        {
            Assert.AreEqual(3, _taxCalculator.AgeBasedRelief.Count);
        }

        [Test]
        public void TestListDeductionsValues_ReturnsDeductionsCountEqualsSeven()
        {
            Assert.AreEqual(7, _taxCalculator.Deductions.Count);
        }
    }
}