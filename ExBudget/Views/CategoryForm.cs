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

namespace ExBudget.Views
{
    public partial class CategoryForm : Form
    {
        Category currentCategory;
        public CategoryForm()
        {
            InitializeComponent();
        }

        private void Init()
        {
            foreach (TransactionType type in EnumUtil.GetValues<TransactionType>())
            {
                if (type != TransactionType.All)
                {
                    typeField.Items.Add(type);
                }
                
            }
            typeField.SelectedIndex = 0;
        }

        

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Category category = GetCategoryInfo();
            if (category != null)
            {
                string requestResponse = CategoryService.SaveCategory(category);
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

        Category GetCategoryInfo()
        {

            string errorMessage = string.Empty;

            string name = textBoxName.Text.Trim();
            string typeString = typeField.SelectedItem == null ? null : typeField.SelectedItem.ToString();

            if (string.IsNullOrEmpty(name))
            {
                AppUtils.AddErrorMessage(ref errorMessage, "Name can not be empty");
            }
            if (string.IsNullOrEmpty(typeString))
            {
                AppUtils.AddErrorMessage(ref errorMessage, "Type can not be empty");
            }

            // verify the error message
            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show($"Please Fill the required fields correctly \n{errorMessage}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            return new Category
            {
                Id = currentCategory.Id,
                Name = name,
                TransactionType = EnumUtil.ToEnum<TransactionType>(typeString)
            };
        }

        void SetCategoryInfo(Category category)
        {

            Init();

            textBoxName.Text = category.Name;
            typeField.SelectedItem = category.TransactionType;
        }

        internal void UpdateCategory(Category category)
        {
            currentCategory  = category;
            SetCategoryInfo(currentCategory);
        }

        internal void AddCategory()
        {
            currentCategory = new Category()
            {
                Id = 0,
                TransactionType = TransactionType.Expense,
                Name = string.Empty
            };
            SetCategoryInfo(currentCategory);
        }

    }
}
