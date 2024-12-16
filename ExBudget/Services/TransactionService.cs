using ExBudget.Models;
using ExBudget.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExBudget.Services
{
    internal class TransactionService
    {
        private static readonly TransactionRepository transactionRepo = new TransactionRepository();

        internal static string Delete(int tansactionId)
        {
            Transaction transaction = transactionRepo.FindById(tansactionId);

            if (transaction == null) return $"Transaction with id {tansactionId} does not exist";

            if (!transactionRepo.DeleteById(tansactionId)) return "[Internal error]: could not delete the category";

            return string.Empty;
        }

        internal static List<Transaction> GetAllTransactions()
        {
            return transactionRepo.GetAll();
        }

        internal static Transaction GetTransactionById(int selectedTansactionId)
        {
            return transactionRepo.FindById(selectedTansactionId);
        }

        internal static List<Transaction> GetTransactionsForSearch(SearchRequest searchRequest)
        {
            List<Transaction> transactions = new List<Transaction>();

            if (searchRequest != null) {
                if (searchRequest.TransactionType == TransactionType.All)
                {
                    transactions.AddRange(transactionRepo.GetAllFromDateToDate(searchRequest.FromDate, searchRequest.ToDate));
                }
                else 
                {
                    CategoryRepository categoryRepo = new CategoryRepository();
                    List<Category> categories = categoryRepo.GetAllByType(searchRequest.TransactionType);
                    foreach (var category in categories)
                    {
                        transactions.AddRange(transactionRepo.GetAllByCategotyFromDateToDate(category, searchRequest.FromDate, searchRequest.ToDate));
                    }
                }
            }
            return transactions;
        }

        internal static string SaveTransaction(Transaction transaction)
        {
            if (transaction.Id == 0)
            {
                
                if (!transactionRepo.Create(transaction))
                {
                    return "[Internal error]: could not save the transaction";
                }
                return string.Empty;
            }
            else
            {
                Transaction tempTransaction = transactionRepo.FindById(transaction.Id);
                if (tempTransaction != null)
                {
                    if (transaction.Equals(tempTransaction))
                    {
                        return "Trying to save the same transaction";
                    }

                    if (transactionRepo.Update(transaction))
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return "[Internal error]: could not save the transaction";
                    }
                }
                else
                {
                    return "Transaction does not exists!";
                }
            }
        }
    }
}
