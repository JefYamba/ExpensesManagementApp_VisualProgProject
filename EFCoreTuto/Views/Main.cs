using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFCoreTuto.Views
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void buttonCustomers_Click(object sender, EventArgs e)
        {
            CustomersForm customers = new CustomersForm();
            customers.ShowDialog(this);
        }

    }
}
