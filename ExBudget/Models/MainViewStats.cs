using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExBudget.Models
{
    public class MainViewStats
    {
        public decimal TotalBalance { get; set; }
        public decimal Income { get; set; }
        public decimal Expenses { get; set; }
        public decimal RemainingDebt { get; set; }
        public decimal TotalLoan { get; set; }
        public decimal RepayedLoan { get; set; }
        public decimal Savings { get; set; }

    }
}
