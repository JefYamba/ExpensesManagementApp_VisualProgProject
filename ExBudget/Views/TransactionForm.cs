using ExBudget.Models;
using ExBudget.Repositories;
using ExBudget.Services;
using ExBudget.Utils;
using ExBudget.Views.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ExBudget.Views
{
    public partial class TransactionForm : Form
    {

        TransactionRepository transactionRepository = new TransactionRepository();

        Transaction currentTransaction;
        TransactionType currentTransactionType;
        public TransactionForm()
        {
            InitializeComponent();
            
        }

        private void Init()
        {
            HidePourcentage();
            LoadTypes();
        }

        private void buttonAddCategory_Click(object sender, EventArgs e)
        {
            CategoryForm addCategoryForm = new CategoryForm();
            addCategoryForm.AddCategory();
            DialogResult dialogResult = addCategoryForm.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                LoadCategories();
            }
        }

        private void LoadCategories()
        {
            categoryField.DataBindings.Clear();
            categoryField.Text = string.Empty;            
            CategoryRepository categoryRepository = new CategoryRepository();
            List<Category> categories = categoryRepository.GetAllByType(currentTransactionType);

            categoryField.DataSource = categories;
            categoryField.DisplayMember = "Name";
            categoryField.ValueMember = "Id";

           
            if (categoryField.Items.Count > 0)
            {
                if (currentTransaction.Id != 0)
                {
                    categoryField.SelectedValue = currentTransaction.Category.Id;
                }
                else
                {
                    categoryField.SelectedIndex = 0;
                }
            }


        }

        private void LoadTypes()
        {
            typeField.Items.Clear();


            List<TransactionType> types = EnumUtil.GetValues<TransactionType>().ToList();


            foreach (TransactionType type in types)
            {
                if (type != TransactionType.All)
                {
                    typeField.Items.Add(type);
                }
            }
            typeField.SelectedIndex = 0;
            currentTransactionType = GetCurrentTransactionType();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Transaction transaction = GetTransactionInfo();
            if (transaction != null)
            {
                string requestResponse = TransactionService.SaveTransaction(transaction);
                if (string.IsNullOrEmpty(requestResponse))
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show($"{requestResponse}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }


        private Transaction GetTransactionInfo()
        {
            string errorMessage = string.Empty;

            decimal amount = amountField.Value;
            DateTime date = dateField.Value.Date;
            Category category = categoryField.SelectedItem as Category;
            string description = descriptionField.Text.Trim();


            if (category == null)
            {
                AppUtils.AddErrorMessage(ref errorMessage, "Select a category");
            }

            if(amount == 0)
            {
                AppUtils.AddErrorMessage(ref errorMessage, "Amount must be greater than 0");
            }

            if (date > DateTime.Now.Date)
            {
                AppUtils.AddErrorMessage(ref errorMessage, "Date cannot be greater than today's date");
            }

            if (string.IsNullOrEmpty(description)) {
                AppUtils.AddErrorMessage(ref errorMessage, "Description cannot be empty");
            }

            // verify the error message
            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show($"Please Fill the required fields correctly \n{errorMessage}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            if (GetCurrentTransactionType() == TransactionType.Loan)
            {
                decimal pourcentageLoan = pourcentageField.Value;
                amount = amount + (amount * pourcentageLoan) / 100;
            }

            return new Transaction
            {
                Id = currentTransaction.Id,
                Category = category,
                Description = description,
                TransactionDate = date,
                Amount = amount
            };
        }

        void SetTransactionInfo(Transaction transaction)
        {
            Init();
            if (transaction.Id != 0)
            {
                currentTransactionType = transaction.Category.TransactionType;
                typeField.SelectedItem = transaction.Category.TransactionType;
                LoadCategories();
            }

            descriptionField.Text = transaction.Description;
            amountField.Value = transaction.Amount;
            dateField.Value = transaction.TransactionDate.ToLocalTime();
        }

        internal void UpdateTransaction(Transaction transaction)
        {
            currentTransaction = transaction;
            SetTransactionInfo(currentTransaction);
        }

        internal void AddTransaction()
        {
            currentTransaction = new Transaction
            {
                Id = 0,
                Amount = 0, 
                Category = null,
                Description = string.Empty,
                TransactionDate = DateTime.Now,
            };

            SetTransactionInfo(currentTransaction);
        }

        private void typeField_SelectedIndexChanged(object sender, EventArgs e)
        {

            currentTransactionType = GetCurrentTransactionType();
            LoadCategories();
            pourcentageField.Value = decimal.Parse("0.00");
            performDynamicAmountChanges();

            if (currentTransactionType == TransactionType.Loan)
            {
                ShowPourcentage();
            }
            else
            {
                HidePourcentage();
            }
        }

        private TransactionType GetCurrentTransactionType()
        {
            string typeString = typeField.SelectedItem == null ? null : typeField.SelectedItem.ToString();
            return EnumUtil.ToEnum<TransactionType>(typeString);
        }

        void HidePourcentage()
        {
            pourcentageField.Hide();
            labelPourcentage.Hide();
            labelToRepay.Hide();
            labelAmountToRepay.Hide();
        }
        void ShowPourcentage()
        {
            pourcentageField.Show();
            labelPourcentage.Show();
            labelToRepay.Show();
            labelAmountToRepay.Show();
        }

        private void pourcentageField_ValueChanged(object sender, EventArgs e)
        {
            performDynamicAmountChanges();
        }

        private void amountField_ValueChanged(object sender, EventArgs e)
        {
            performDynamicAmountChanges();
        }

        void performDynamicAmountChanges()
        {
            decimal amount = amountField.Value;
            decimal pourcentageLoan = pourcentageField.Value;
            labelAmountToRepay.Text = (amount + (amount * pourcentageLoan) / 100).ToString();
        }

        private void pourcentageField_KeyPress(object sender, KeyPressEventArgs e)
        {
            performDynamicAmountChanges();
        }

        private void amountField_KeyDown(object sender, KeyEventArgs e)
        {
            performDynamicAmountChanges();
        }

        private void pourcentageField_KeyDown(object sender, KeyEventArgs e)
        {
            performDynamicAmountChanges();
        }

        private void amountField_KeyUp(object sender, KeyEventArgs e)
        {
            performDynamicAmountChanges();
        }

        private void pourcentageField_KeyUp(object sender, KeyEventArgs e)
        {
            performDynamicAmountChanges();
        }
    }
}
