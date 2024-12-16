using ExBudget.Models;
using ExBudget.Repositories;
using ExBudget.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExBudget.Views.UserControls
{
    public partial class Categories : UserControl
    {
        public Categories()
        {
            InitializeComponent();
            LoadCategories();
        }

        private void LoadCategories()
        {
            dataGridCategories.Rows.Clear();
            CategoryService.GetAllCategories()
                .ForEach(category => {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(
                        dataGridCategories,
                        category.Id,
                        category.Name,
                        category.TransactionType
                        );
                    dataGridCategories.Rows.Add(row);
                });
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            CategoryForm addCategoryForm = new CategoryForm();
            addCategoryForm.AddCategory();
            if (addCategoryForm.ShowDialog(this) == DialogResult.OK)
            {
                LoadCategories();
            }

        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {

            try
            {
                int selectedCategoryId = Convert.ToInt32(dataGridCategories.SelectedRows[0].Cells[0].Value);

                Category category = CategoryService.GetCategoryById(selectedCategoryId);
                if (category == null) return;

                CategoryForm updateCategoryForm = new CategoryForm();
                updateCategoryForm.UpdateCategory(category);
                if (updateCategoryForm.ShowDialog(this) == DialogResult.OK)
                {
                    LoadCategories();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("please select a row before trying to update");
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedCategoryId = Convert.ToInt32(dataGridCategories.SelectedRows[0].Cells[0].Value);

                DialogResult dialogResult = MessageBox.Show("Do you realy want to delete this category?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
               
                if (dialogResult == DialogResult.Yes)
                {

                    string requestResponse = CategoryService.Delete(selectedCategoryId);
                    if (string.IsNullOrEmpty(requestResponse))
                    {
                        MessageBox.Show($"Category deleted Successfully", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadCategories();
                    }
                    else
                    {
                        MessageBox.Show($"{requestResponse}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("please select a row before trying to update");
            }
        }
    }
}
