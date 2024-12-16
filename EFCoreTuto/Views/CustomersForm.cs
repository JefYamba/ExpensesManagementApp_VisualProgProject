using EFCoreTuto.Models;
using EFCoreTuto.Services;
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
    public partial class CustomersForm : Form
    {
        CustomerService customerService;
        public CustomersForm()
        {
            InitializeComponent();
            //this.DialogResult = DialogResult.Cancel;
            customerService = new CustomerService();
        }

        private void CustomersForm_Load(object sender, EventArgs e)
        {
            loadCustomersToList();
        }

        private void buttonSaveCustomer_Click(object sender, EventArgs e)
        {
            Customer? customer = getCustomer();
            if (customer == null)
            {
                MessageBox.Show("Fistname and Lastname can not be empty","Warnig",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            else
            {
                customerService.RegisterCustomer(customer);

                loadCustomersToList();
                clearForm();
            }
        }

        private void loadCustomersToList()
        {
            listBoxCustomerList.Items.Clear();
            List<Customer> customerList = customerService.GetAllCustomers();
            foreach (var customer in customerList)
            {
                listBoxCustomerList.Items.Add($"{customer.Id} {customer.FirstName} {customer.LastName} {customer.Email} {customer.Phone} {customer.Address}");
            }
        }

        Customer? getCustomer()
        {
            string firstname = textBoxFirstName.Text.Trim();
            string lastname = textBoxLastName.Text.Trim();
            string phone = textBoxPhone.Text.Trim();
            string email = textBoxEmail.Text.Trim();
            string address = textBoxAddress.Text.Trim();
            if (firstname == null || firstname.Length == 0 || lastname == null || lastname.Length == 0) {
                return null;
            }

            Customer customer = new Customer();
            customer.FirstName = firstname;
            customer.LastName = lastname;
            customer.Phone = phone;
            customer.Email = email;
            customer.Address = address;

            return customer;
        }

        void clearForm()
        {
            textBoxFirstName.Text = string.Empty;
            textBoxLastName.Text = string.Empty;
            textBoxPhone.Text = string.Empty;
            textBoxEmail.Text = string.Empty;
            textBoxAddress.Text = string.Empty;
        }

        void setCustomerToForm(Customer customer)
        {
            textBoxFirstName.Text =customer.FirstName;
            textBoxLastName.Text = customer.LastName;
            textBoxPhone.Text = customer.Phone;
            textBoxEmail.Text = customer.Email;
            textBoxAddress.Text = customer.Address;
        }
    }
}
