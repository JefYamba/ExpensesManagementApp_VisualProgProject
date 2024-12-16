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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ExBudget.Views
{
    public partial class Transactions : UserControl
    {

        bool searchMode = false;
        


        public Transactions()
        {
            InitializeComponent();
            
        }

        private void Transactions_Load(object sender, EventArgs e)
        {
            InitSearch();
            LoadTransactions();
        }

        string GetCurrencyValue(decimal value)
        {
            string currency = "₺";
            return $"{currency}{value}";
        }

        void LoadTransactions()
        {
            dataGridViewTransactions.Rows.Clear();
            
            List<Transaction> transactions = new List<Transaction>();

            if (searchMode) 
            {
                SearchRequest searchRequest = GetSearchRequest();
                if (searchRequest != null) {
                    transactions = TransactionService.GetTransactionsForSearch(searchRequest);
                } 
            }
            else
            {
                transactions = TransactionService.GetAllTransactions();
            }
           
            foreach (Transaction transaction in transactions)
            {
                
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(
                    dataGridViewTransactions,
                    transaction.Id,
                    transaction.Category.TransactionType,
                    transaction.Category.Name,
                    transaction.Description,
                    GetCurrencyValue(transaction.Amount),
                    transaction.TransactionDate.ToString("yyyy-MM-dd")
                    );
                dataGridViewTransactions.Rows.Add( row );
            }
        }

        SearchRequest GetSearchRequest() {
            string errorMessage = string.Empty;

            string typeString = typeField.SelectedItem == null ? null : typeField.SelectedItem.ToString();
            DateTime fromDate = fromDateField.Value.Date;
            DateTime toDate = toDateField.Value.Date;

            if (string.IsNullOrEmpty(typeString))
            {
                AppUtils.AddErrorMessage(ref errorMessage, "Type cannot be empty");
            }

            if(fromDate > DateTime.Now.Date || toDate > DateTime.Now.Date)
            {
                AppUtils.AddErrorMessage(ref errorMessage, "Dates cannot be greater than today's date");
            }

            if (fromDate > toDate) {
                AppUtils.AddErrorMessage(ref errorMessage, "The start date must be lower or equal to the end date");
            }

            if (!string.IsNullOrEmpty(errorMessage)) 
            {
                MessageBox.Show($"Please Fill the required fields correctly \n{errorMessage}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            return new SearchRequest()
            {
                TransactionType = EnumUtil.ToEnum<TransactionType>(typeString),
                FromDate = fromDate,
                ToDate = toDate,


            };
        }

        

        private void InitSearch()
        {
            typeField.Items.Clear();
            foreach (TransactionType type in EnumUtil.GetValues<TransactionType>()) {
                typeField.Items.Add(type);
            }
            typeField.SelectedIndex = 0;
            fromDateField.Value = DateTime.Now;
            toDateField.Value = DateTime.Now;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            TransactionForm addTransactionForm = new TransactionForm();
            addTransactionForm.AddTransaction();
            DialogResult dialogResult = addTransactionForm.ShowDialog(this);
            if(dialogResult == DialogResult.OK)
            {
                LoadTransactions();
            }

        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedTansactionId = Convert.ToInt32(dataGridViewTransactions.SelectedRows[0].Cells[0].Value);
                Transaction transaction = TransactionService.GetTransactionById(selectedTansactionId);
                if (transaction == null) return;

                TransactionForm updateTransactionForm = new TransactionForm();
                updateTransactionForm.UpdateTransaction(transaction);
                if (updateTransactionForm.ShowDialog(this) == DialogResult.OK)
                {
                    LoadTransactions();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("please select a row before trying to update" + ex);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {


            try
            {
                int selectedTansactionId = Convert.ToInt32(dataGridViewTransactions.SelectedRows[0].Cells[0].Value);

                DialogResult dialogResult = MessageBox.Show("Do you realy want to delete this transaction?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);


                if (dialogResult == DialogResult.Yes)
                {
                    string requestResponse = TransactionService.Delete(selectedTansactionId);
                    if (string.IsNullOrEmpty(requestResponse))
                    {
                        MessageBox.Show($"Transaction deleted Successfully", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadTransactions();
                    }
                    else
                    {
                        MessageBox.Show($"{requestResponse}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("please select a row before trying to update" + ex);
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            LoadTransactions();
        }

        private void tabMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabMenu.SelectedTab == tabMenu.TabPages["tabPageManage"])
            {
                SetManageMode();
            }
            else if (tabMenu.SelectedTab == tabMenu.TabPages["tabPageSearch"])
            {
                SetSearchMode();
                InitSearch();
            }

            LoadTransactions();
        }

        void SetManageMode()
        {
            searchMode = false;
        }

        void SetSearchMode()
        {
            searchMode = true;
        }

    }
}
