namespace EFCoreTuto.Views
{
    partial class CustomersForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxFirstName = new TextBox();
            labelFirstname = new Label();
            textBoxLastName = new TextBox();
            labelLastName = new Label();
            textBoxPhone = new TextBox();
            labelPhone = new Label();
            textBoxEmail = new TextBox();
            labelEmail = new Label();
            textBoxAddress = new TextBox();
            labelAddress = new Label();
            listBoxCustomerList = new ListBox();
            buttonSaveCustomer = new Button();
            SuspendLayout();
            // 
            // textBoxFirstName
            // 
            textBoxFirstName.BorderStyle = BorderStyle.FixedSingle;
            textBoxFirstName.Location = new Point(116, 30);
            textBoxFirstName.Name = "textBoxFirstName";
            textBoxFirstName.Size = new Size(168, 23);
            textBoxFirstName.TabIndex = 0;
            // 
            // labelFirstname
            // 
            labelFirstname.AutoSize = true;
            labelFirstname.Location = new Point(40, 34);
            labelFirstname.Name = "labelFirstname";
            labelFirstname.Size = new Size(70, 15);
            labelFirstname.TabIndex = 1;
            labelFirstname.Text = "First Name :";
            labelFirstname.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxLastName
            // 
            textBoxLastName.BorderStyle = BorderStyle.FixedSingle;
            textBoxLastName.Location = new Point(379, 30);
            textBoxLastName.Name = "textBoxLastName";
            textBoxLastName.Size = new Size(168, 23);
            textBoxLastName.TabIndex = 2;
            // 
            // labelLastName
            // 
            labelLastName.AutoSize = true;
            labelLastName.Location = new Point(304, 34);
            labelLastName.Name = "labelLastName";
            labelLastName.Size = new Size(69, 15);
            labelLastName.TabIndex = 3;
            labelLastName.Text = "Last Name :";
            labelLastName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxPhone
            // 
            textBoxPhone.BorderStyle = BorderStyle.FixedSingle;
            textBoxPhone.Location = new Point(662, 30);
            textBoxPhone.Name = "textBoxPhone";
            textBoxPhone.Size = new Size(186, 23);
            textBoxPhone.TabIndex = 4;
            // 
            // labelPhone
            // 
            labelPhone.AutoSize = true;
            labelPhone.Location = new Point(587, 34);
            labelPhone.Name = "labelPhone";
            labelPhone.Size = new Size(47, 15);
            labelPhone.TabIndex = 5;
            labelPhone.Text = "Phone :";
            labelPhone.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxEmail
            // 
            textBoxEmail.BorderStyle = BorderStyle.FixedSingle;
            textBoxEmail.Location = new Point(116, 64);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(168, 23);
            textBoxEmail.TabIndex = 6;
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Location = new Point(40, 68);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(42, 15);
            labelEmail.TabIndex = 7;
            labelEmail.Text = "Email :";
            labelEmail.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxAddress
            // 
            textBoxAddress.BorderStyle = BorderStyle.FixedSingle;
            textBoxAddress.Location = new Point(379, 64);
            textBoxAddress.Name = "textBoxAddress";
            textBoxAddress.Size = new Size(469, 23);
            textBoxAddress.TabIndex = 8;
            // 
            // labelAddress
            // 
            labelAddress.AutoSize = true;
            labelAddress.Location = new Point(304, 68);
            labelAddress.Name = "labelAddress";
            labelAddress.Size = new Size(55, 15);
            labelAddress.TabIndex = 9;
            labelAddress.Text = "Address :";
            labelAddress.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // listBoxCustomerList
            // 
            listBoxCustomerList.FormattingEnabled = true;
            listBoxCustomerList.ItemHeight = 15;
            listBoxCustomerList.Location = new Point(40, 128);
            listBoxCustomerList.Name = "listBoxCustomerList";
            listBoxCustomerList.Size = new Size(808, 409);
            listBoxCustomerList.TabIndex = 10;
            // 
            // buttonSaveCustomer
            // 
            buttonSaveCustomer.FlatStyle = FlatStyle.Popup;
            buttonSaveCustomer.Location = new Point(773, 99);
            buttonSaveCustomer.Name = "buttonSaveCustomer";
            buttonSaveCustomer.Size = new Size(75, 23);
            buttonSaveCustomer.TabIndex = 11;
            buttonSaveCustomer.Text = "Save";
            buttonSaveCustomer.UseVisualStyleBackColor = true;
            buttonSaveCustomer.Click += buttonSaveCustomer_Click;
            // 
            // CustomersForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(896, 576);
            Controls.Add(buttonSaveCustomer);
            Controls.Add(listBoxCustomerList);
            Controls.Add(textBoxAddress);
            Controls.Add(labelAddress);
            Controls.Add(textBoxEmail);
            Controls.Add(labelEmail);
            Controls.Add(textBoxPhone);
            Controls.Add(labelPhone);
            Controls.Add(textBoxLastName);
            Controls.Add(textBoxFirstName);
            Controls.Add(labelLastName);
            Controls.Add(labelFirstname);
            Name = "CustomersForm";
            Text = "Customers";
            Load += CustomersForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxFirstName;
        private Label labelFirstname;
        private TextBox textBoxLastName;
        private Label labelLastName;
        private TextBox textBoxPhone;
        private Label labelPhone;
        private TextBox textBoxEmail;
        private Label labelEmail;
        private TextBox textBoxAddress;
        private Label labelAddress;
        private ListBox listBoxCustomerList;
        private Button buttonSaveCustomer;
    }
}