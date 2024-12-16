using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExBudget.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public Category Category { get; set; }

        public bool Equals(Transaction transaction)
        {
            if (transaction == null) return false;
            if (transaction.Id != Id) return false;
            if (!string.Equals(transaction.Description,Description, StringComparison.OrdinalIgnoreCase)) return false;
            if (transaction.Amount != Amount) return false;
            if (transaction.TransactionDate != TransactionDate) return false;
            if (!transaction.Category.Equals(Category)) return false;

            return true;
        }
    }
}
