using Mulcted.Processes.Interfaces;
using Mulcted.Processes.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
            var ageRate = GetAgeRelief(age);
            var workingSalary = salary - ageRate.ReliefAmount;
            workingSalary = workingSalary > 0 ? workingSalary : 0;
            var baseRate = GetBaseRate(workingSalary);
            var effectiveRate = ageRate.Deduction > 0 ? baseRate * ageRate.Deduction : baseRate;
            workingSalary = effectiveRate * workingSalary;
            return new TaxPayableItem
            {
                BaseRate = baseRate,
                DeductionAmount = workingSalary,
                DeductionRate = effectiveRate,
                ReliefAmount = ageRate.ReliefAmount,
                ReliefRate = ageRate.Deduction,
            };
        }

        private void DefaultFactory()
        {
            // Table values adjusted to be able to refer to it using "up to" logic, as opposed to "up to and including".
            Deductions = new Dictionary<decimal, decimal>()
            {
                { 0m, 0m},
                { 5000m * 12m, 0.005m},
                { 10000m * 12m, 0.075m},
                { 20000m * 12m, 0.09m},
                { 35000m * 12m, 0.15m},
                { 50000m * 12m, 0.25m},
                { 70000m * 12m, 0.30m},
            };

            AgeBasedRelief = new List<AgeBasedReliefItem>
            {
                new AgeBasedReliefItem
                {
                    AgeEnd = 18,
                    AgeStart = int.MinValue,
                    Deduction = 1m,
                    ReliefAmount = 0m
                },
                new AgeBasedReliefItem
                {
                    AgeEnd = 50,
                    AgeStart = 18,
                    Deduction = 1m,
                    ReliefAmount = 2000m * 12m
                },
                new AgeBasedReliefItem
                {
                    AgeEnd = int.MaxValue,
                    AgeStart = 50,
                    Deduction = 0.85m,
                    ReliefAmount = 5000m * 12m
                },
            };
        }

        private AgeBasedReliefItem GetAgeRelief(int age)
        {
            return AgeBasedRelief.First(x => x.AgeStart <= age && x.AgeEnd >= age);
        }

        private decimal GetBaseRate(decimal salary)
        {
            return Deductions.Where(x => x.Key <= salary).OrderByDescending(x => x.Key).First().Value;
        }
    }
}