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

namespace ExBudget.Views
{
    public partial class Login : Form
    {
        private AuthService authService = new AuthService();
        public Login()
        {
            InitializeComponent();
            labelErrorMessage.Text = string.Empty;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text.Trim();
            string password = textBoxPassword.Text.Trim();
            if (authService.Login(username, password))
            {
                DialogResult = DialogResult.OK;
                Close();
            } else
            {
                ShowError();
            }
            
        }

        void ShowError()
        {
            labelErrorMessage.Text = "Wrong Username of password. \nPlease try again!";
            textBoxUsername.BackColor = Color.LightPink;
            textBoxPassword.BackColor = Color.LightPink;
        }

        void removeError()
        {
            labelErrorMessage.Text = string.Empty;
            textBoxUsername.BackColor = Color.White;
            textBoxPassword.BackColor = Color.White;
        }

        private void textBoxPassword_MouseDown(object sender, MouseEventArgs e)
        {
            removeError();
        }

        private void textBoxUsername_MouseDown(object sender, MouseEventArgs e)
        {
            removeError();
        }
    }
}
