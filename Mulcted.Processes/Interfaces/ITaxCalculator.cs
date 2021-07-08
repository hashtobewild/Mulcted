using Mulcted.Processes.Models;
using System.Collections.Generic;

namespace Mulcted.Processes.Interfaces
{
    public interface ITaxCalculator
    {
        List<AgeBasedReliefItem> AgeBasedRelief { get; set; }
        Dictionary<decimal, decimal> Deductions { get; set; }

        TaxPayableItem Calculate(int age, decimal salary);
    }
}