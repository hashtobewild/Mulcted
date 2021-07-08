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
        [TestCase(18, 60000, 0)]
        [TestCase(50, 60000, 0)]
        // Age varience
        [TestCase(17, 60000, 300)]
        [TestCase(51, 180000, 7650)]
        [TestCase(19, 180000, 11700)]
        [TestCase(5, 180000, 13500)]
        // Amount vairance
        [TestCase(51, 120000, 255)]
        [TestCase(25, 120000, 480)]
        [TestCase(5, 120000, 9000)]
        [TestCase(51, 852000, 168300)]
        [TestCase(25, 852000, 207000)]
        [TestCase(5, 852000, 255600)]
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