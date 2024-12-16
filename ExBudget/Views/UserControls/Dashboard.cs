using ExBudget.Models;
using ExBudget.Repositories;
using ExBudget.Services;
using ExBudget.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ExBudget.Views.UserControls
{
    public partial class Dashboard : UserControl
    {

        public Dashboard()
        {
            InitializeComponent();
        }

        void LoadStats()
        {

            MainViewStats mainViewStats = StatService.GetMainViewStats();

            labelIncome.Text = mainViewStats.Income.ToString();
            labelExpenses.Text = mainViewStats.Expenses.ToString();
            labelTotalBalance.Text = mainViewStats.TotalBalance.ToString();
            labelTotalLoan.Text = mainViewStats.TotalLoan.ToString();
            labelRepayedLoan.Text = mainViewStats.RepayedLoan.ToString();
            labelRemainingDebt.Text = mainViewStats.RemainingDebt.ToString();
            labelSavings.Text = mainViewStats.Savings.ToString();
        }

        void LoadTransactionChartForCurrentMonth()
        {
            chartTransactionsForCurrentMonth.Series.Clear();
            chartTransactionsForCurrentMonth.Legends.Clear();
            chartTransactionsForCurrentMonth.Titles.Clear();

            Legend legend = new Legend("transactionsLegend");
            chartTransactionsForCurrentMonth.Legends.Add(legend);

            Series seriesTransactions = StatService.CreateTransactionsSeriesForCurrentMonth();

            seriesTransactions["PieLabelStyle"] = "Inside";

            chartTransactionsForCurrentMonth.Series.Add(seriesTransactions);

            chartTransactionsForCurrentMonth.Titles.Add($"Transactions of {EnumUtil.ToEnum<Month>(DateTime.Now.Month - 1)}");

            chartTransactionsForCurrentMonth.Legends["transactionsLegend"].Enabled = true;
        }


        void LoadExpensesChartForCurrentMonth()
        {
            chartExpensesForCurrentMonth.Series.Clear();
            chartExpensesForCurrentMonth.Legends.Clear();
            chartExpensesForCurrentMonth.Titles.Clear();

            Legend legend = new Legend("ExpensesLegend");
            chartExpensesForCurrentMonth.Legends.Add(legend);

            DateTime firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            Series seriesExpenses = StatService.CreateExpensesSeriesFromDate(firstDayOfMonth);

            seriesExpenses["PieLabelStyle"] = "Inside";

            chartExpensesForCurrentMonth.Series.Add(seriesExpenses);

            chartExpensesForCurrentMonth.Titles.Add($"Expenses of {EnumUtil.ToEnum<Month>(DateTime.Now.Month - 1)}");

            chartExpensesForCurrentMonth.Legends["ExpensesLegend"].Enabled = true;
        }

        void LoadExpensesChartForCurrentDay()
        {
            chartExpensesForCurrentDay.Series.Clear();
            chartExpensesForCurrentDay.Legends.Clear();
            chartExpensesForCurrentDay.Titles.Clear();

            Legend legend = new Legend("ExpensesLegend");
            chartExpensesForCurrentDay.Legends.Add(legend);

            DateTime currentDay = DateTime.Now.Date;
            Series seriesExpenses = StatService.CreateExpensesSeriesFromDate(currentDay);

            seriesExpenses["PieLabelStyle"] = "Inside";

            chartExpensesForCurrentDay.Series.Add(seriesExpenses);

            chartExpensesForCurrentDay.Titles.Add($"Expenses of Today");

            chartExpensesForCurrentDay.Legends["ExpensesLegend"].Enabled = true;
        }

        void LoadChartTransactionsForCurrentWeek() 
        {
            chartTransactionsForCurrentWeek.Series.Clear();
            chartTransactionsForCurrentWeek.Legends.Clear();
            chartTransactionsForCurrentWeek.Titles.Clear();

            Legend legend = new Legend("ExpensesLegend");
            chartTransactionsForCurrentWeek.Legends.Add(legend);

            List<Series> seriesExpensesList = StatService.CreateListOfExpensesSeriesForCurrentWeek();

            foreach ( Series series in seriesExpensesList)
            {
                chartTransactionsForCurrentWeek.Series.Add(series);
            }


            chartTransactionsForCurrentWeek.Titles.Add($"Expenses of the week");

            chartTransactionsForCurrentWeek.Legends["ExpensesLegend"].Enabled = true;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            LoadCharts();
        }

        internal void LoadCharts()
        {
            labelStatsTitle.Text = $"Current Month : {EnumUtil.ToEnum<Month>(DateTime.Now.Month - 1)}";
            LoadStats();
            LoadTransactionChartForCurrentMonth();
            LoadExpensesChartForCurrentMonth();
            LoadExpensesChartForCurrentDay();
            LoadChartTransactionsForCurrentWeek();

        }
    }
}
