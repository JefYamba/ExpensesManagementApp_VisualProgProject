using System;

namespace ExBudget.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TransactionType TransactionType { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public  bool Equals(Category category)
        {
            if(category == null) return false;
            if(category.Id != Id) return false;
            if(!string.Equals(category.Name, Name, StringComparison.OrdinalIgnoreCase)) return false;
            if(category.TransactionType != TransactionType) return false;

            return true;
        }

    }
}