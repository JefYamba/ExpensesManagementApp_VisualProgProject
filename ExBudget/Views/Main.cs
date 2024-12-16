using ExBudget.Models;
using ExBudget.Services;
using ExBudget.Views.UserControls;
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
    public partial class Main : Form
    {
        Dashboard dashboard  = new Dashboard();
        Transactions transactions = new Transactions();
        Categories categories = new Categories();

        public Main()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            ShowLoginWindow();
        }

        private void ShowLoginWindow()
        {
            Hide();
            Login loginForm = new Login();
            DialogResult result = loginForm.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                Show();
                User currentuser = AuthService.currentUser;

                labelUserProfile.Text = currentuser == null ? string.Empty : currentuser.DisplayName;

                ShowDashnoard();
            }
            else
            {
                Application.Exit();
            }
        }

        private void buttonDashboard_Click(object sender, EventArgs e)
        {
            ShowDashnoard();
        }

        private void buttonTransactions_Click(object sender, EventArgs e)
        {
            ShowTransactions();
        }


        private void ShowDashnoard()
        {
            labelPageName.Text = "Dashboard";
            panelContent.Controls.Clear();
            panelContent.Controls.Add(dashboard);
            dashboard.LoadCharts();
            dashboard.Dock = DockStyle.Fill;
        }
        private void ShowTransactions()
        {
            labelPageName.Text = "Transactions";
            panelContent.Controls.Clear();
            panelContent.Controls.Add(transactions);
            transactions.Dock = DockStyle.Fill;
        }

        private void buttonCategories_Click(object sender, EventArgs e)
        {
            labelPageName.Text = "Categories";
            panelContent.Controls.Clear();
            panelContent.Controls.Add(categories);
            categories.Dock = DockStyle.Fill;
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            ShowLoginWindow();
        }
    }
}
