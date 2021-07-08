using System;
using System.Collections.Generic;
using System.Text;

namespace Mulcted.Processes.Models
{
    public class AgeBasedReliefItem
    {
        public int AgeEnd { get; set; }
        public int AgeStart { get; set; }
        public decimal Deduction { get; set; }
        public decimal ReliefAmount { get; set; }
    }
}