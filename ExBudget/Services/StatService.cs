using ExBudget.Models;
using ExBudget.Repositories;
using ExBudget.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace ExBudget.Services
{
    public class StatService
    {
        private static readonly TransactionRepository transactionRepository = new TransactionRepository();
        private static readonly CategoryRepository categoryRepository = new CategoryRepository();

        public static MainViewStats GetMainViewStats() {
            // Since the beginig, not a specific month or year
            
            calculateStatsForGeneralTransaction(out decimal totalBalance, out decimal remainingDebt, out decimal savings);

            // For the current month
            calculateStatsForCurrentMonth(out decimal income, out decimal loan, out decimal expenses, out decimal repayedDebt);

            return new MainViewStats() {
                 Expenses = expenses,
                 TotalBalance = totalBalance,
                 RemainingDebt = remainingDebt,
                 Savings = savings,
                 Income = income,
                 RepayedLoan = repayedDebt,
                 TotalLoan = loan
            }; 
        }

        private static void calculateStatsForCurrentMonth(out decimal income, out decimal loan, out decimal expenses, out decimal repayedDebt)
        {
            income = 0;
            loan = 0;
            expenses = 0;
            repayedDebt = 0;

            List<TransactionType> transactionTypes = EnumUtil.GetValues<TransactionType>().ToList();
            foreach (TransactionType type in transactionTypes)
            {
                if (type == TransactionType.Income)
                {
                    income = GetTotalAmountForATypeAndCurrentMonth(type);
                }
                else if (type == TransactionType.Loan)
                {
                    loan = GetTotalAmountForATypeAndCurrentMonth(type);
                }
                else if (type == TransactionType.Expense)
                {
                    expenses = GetTotalAmountForATypeAndCurrentMonth(type);
                }
                else if (type == TransactionType.Repayment)
                {
                    repayedDebt = GetTotalAmountForATypeAndCurrentMonth(type);
                }
            }
        }

        private static void calculateStatsForGeneralTransaction(out decimal totalBalance, out decimal remainingDebt, out decimal savings)
        {
            totalBalance = 0;
            remainingDebt = 0;
            
            savings = 0;

            decimal totalIncomes = 0;
            decimal totalLoan = 0;
            decimal totalExpenses = 0;
            decimal totalRepayedDebt = 0;

            List<TransactionType> transactionTypes = EnumUtil.GetValues<TransactionType>().ToList();
            foreach (TransactionType type in transactionTypes)
            {
                if (type == TransactionType.Saving)
                {
                    savings = getTotalAmountForAType(type);
                }
                else if (type == TransactionType.Income) 
                { 
                    totalIncomes = getTotalAmountForAType(type);
                }
                else if (type == TransactionType.Loan)
                {
                    totalLoan = getTotalAmountForAType(type);
                }
                else if (type == TransactionType.Expense)
                {
                    totalExpenses = getTotalAmountForAType(type);
                }
                else if (type == TransactionType.Repayment)
                {
                    totalRepayedDebt = getTotalAmountForAType(type);
                }
            }
            totalBalance = (totalIncomes + totalLoan) - (totalExpenses +  totalRepayedDebt + savings);
            remainingDebt = totalLoan - totalRepayedDebt;

        }

        private static decimal getTotalAmountForAType(TransactionType type)
        {
            decimal totalAmount = 0;

            var categories = categoryRepository.GetAllByType(type);

            foreach (Category category in categories)
            {
                var transactions = transactionRepository.GetAllByCategoty(category);
                foreach (var transaction in transactions)
                {
                    totalAmount += transaction.Amount;
                }
            }
            return totalAmount;
        }

        private static decimal GetTotalAmountForATypeAndCurrentMonth(TransactionType type)
        {
            decimal totalAmount = 0;
            DateTime firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            var categories = categoryRepository.GetAllByType(type);

            foreach (Category category in categories)
            {
                var transactions = transactionRepository.GetAllByCategotyFromDate(category, firstDayOfMonth);
                foreach (var transaction in transactions)
                {
                    totalAmount += transaction.Amount;
                }
            }
            return totalAmount;
        }

        public static Series CreateExpensesSeriesFromDate(DateTime fromDate)
        {
            Series seriesExpenses = new Series
            {
                Name = "Expenses",
                ChartType = SeriesChartType.Pie,
            };

            var categories = categoryRepository.GetAllByType(TransactionType.Expense);

            foreach (Category category in categories)
            {
                var transactions = transactionRepository.GetAllByCategotyFromDate(category, fromDate);
                decimal totalAmountForCategoryatefory = 0;

                foreach (var transaction in transactions)
                {
                    totalAmountForCategoryatefory = transaction.Amount;
                }

                DataPoint pointIncome = new DataPoint(0, float.Parse(totalAmountForCategoryatefory.ToString()))
                {
                    AxisLabel = totalAmountForCategoryatefory.ToString(),
                    LegendText = category.Name
                };
                seriesExpenses.Points.Add(pointIncome);
            }

            return seriesExpenses;
        }

        public static Series CreateTransactionsSeriesForCurrentMonth()
        {
            
            Series seriesTransactions = new Series
            {
                Name = "Transactions",
                ChartType = SeriesChartType.Doughnut,
            };

            DateTime firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            List<TransactionType> transactionTypes = EnumUtil.GetValues<TransactionType>().ToList();
            foreach (TransactionType type in transactionTypes)
            {
                if (type != TransactionType.All)
                {
                    decimal totalTypeAmount = 0;


                    var categories = categoryRepository.GetAllByType(type);

                    foreach (Category category in categories)
                    {
                        var transactions = transactionRepository.GetAllByCategotyFromDate(category, firstDayOfMonth);
                        foreach (var transaction in transactions)
                        {
                            totalTypeAmount += transaction.Amount;
                        }
                    }

                    DataPoint point = new DataPoint(0, float.Parse(totalTypeAmount.ToString()))
                    {
                        AxisLabel = totalTypeAmount.ToString(),
                        LegendText = type.ToString(),
                    };
                    seriesTransactions.Points.Add(point);
                }
            }

            return seriesTransactions;
        }

        internal static List<Series> CreateListOfExpensesSeriesForCurrentWeek()
        {
            List<Series> seriesList = new List<Series>();

            List<TransactionType> transactionTypes = EnumUtil.GetValues<TransactionType>().ToList();
            foreach (TransactionType type in transactionTypes)
            {
                if (type == TransactionType.Saving)
                {
                    Series seriesSavings = GetSeriesFromType(type);
                    seriesList.Add(seriesSavings);
                }
                else if (type == TransactionType.Income)
                {
                    Series seriesIncome = GetSeriesFromType(type);
                    seriesList.Add(seriesIncome);
                }
                else if (type == TransactionType.Loan)
                {
                    Series seriesLoan = GetSeriesFromType(type);
                    seriesList.Add(seriesLoan);
                }
                else if (type == TransactionType.Expense)
                {
                    Series seriesExpense = GetSeriesFromType(type);
                    seriesList.Add(seriesExpense);
                }
                else if (type == TransactionType.Repayment)
                {
                    Series seriesRepayment = GetSeriesFromType(type);
                    seriesList.Add(seriesRepayment);
                }
            }


            

            return seriesList;
        }

        private static Series GetSeriesFromType(TransactionType type)
        {
            Series series = new Series
            {
                Name = type.ToString(),
                ChartType = SeriesChartType.Column,
            };

            DateTime currentDate = DateTime.Now.Date;
            var categories = categoryRepository.GetAllByType(type);

            for (int i = 0; i < 7; i++) {
                
                decimal totalDayAmount = 0;
                foreach (Category category in categories)
                {
                    var transactions = transactionRepository.GetAllByCategotyFromDateToDate(category, currentDate, currentDate);
                    foreach (var transaction in transactions)
                    {
                        totalDayAmount += transaction.Amount;
                        Console.WriteLine($"{type.ToString()} - {category}: {totalDayAmount}");
                    }
                }
                series.Points.AddXY(currentDate.ToString("yyyy-MM-dd"), totalDayAmount);

                currentDate = currentDate.AddDays(-1);
            }

            var reversedPoints = series.Points.Reverse().ToList();
            series.Points.Clear();

            foreach (var point in reversedPoints)
            {
                series.Points.Add(point);
            }

            return series;
        }

     
    }
}
