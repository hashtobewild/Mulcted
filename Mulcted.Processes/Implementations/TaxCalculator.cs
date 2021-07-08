using Mulcted.Processes.Interfaces;
using Mulcted.Processes.Models;
using System.Collections.Generic;

namespace Mulcted.Processes.Implementations
{
    public class TaxCalculator : ITaxCalculator
    {
        public TaxCalculator()
        {
            DefaultFactory();
        }

        public List<AgeBasedReliefItem> AgeBasedRelief { get; set; }
        public Dictionary<decimal, decimal> Deductions { get; set; }

        public TaxPayableItem Calculate(int age, decimal salary)
        {
            return default(TaxPayableItem);
        }

        private void DefaultFactory()
        {
            // Table values adjusted to be able to refer to it using "up to" logic, as opposed to "up to and including".
            Deductions = new Dictionary<decimal, decimal>()
            {
                { 0, 0},
                { 5000, 0.005m},
                { 10000, 0.075m},
                { 20000, 0.09m},
                { 35000, 0.15m},
                { 50000, 0.25m},
                { 70000, 0.30m},
            };

            AgeBasedRelief = new List<AgeBasedReliefItem>
            {
                new AgeBasedReliefItem
                {
                    AgeEnd = 50,
                    AgeStart = 18,
                    Deduction = 1m,
                    ReliefAmount = 2000.00m
                },
                new AgeBasedReliefItem
                {
                    AgeEnd = 0,
                    AgeStart = 50,
                    Deduction = 0.85m,
                    ReliefAmount = 5000.00m
                },
            };
        }
    }
}