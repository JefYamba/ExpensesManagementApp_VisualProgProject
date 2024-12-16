namespace ExBudget.Views
{
    partial class TransactionForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelAmountToRepay = new System.Windows.Forms.Label();
            this.labelToRepay = new System.Windows.Forms.Label();
            this.pourcentageField = new System.Windows.Forms.NumericUpDown();
            this.labelPourcentage = new System.Windows.Forms.Label();
            this.buttonAddCategory = new System.Windows.Forms.Button();
            this.categoryField = new System.Windows.Forms.ComboBox();
            this.amountField = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateField = new System.Windows.Forms.DateTimePicker();
            this.typeField = new System.Windows.Forms.ComboBox();
            this.descriptionField = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pourcentageField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.amountField)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.labelAmountToRepay);
            this.groupBox1.Controls.Add(this.labelToRepay);
            this.groupBox1.Controls.Add(this.pourcentageField);
            this.groupBox1.Controls.Add(this.labelPourcentage);
            this.groupBox1.Controls.Add(this.buttonAddCategory);
            this.groupBox1.Controls.Add(this.categoryField);
            this.groupBox1.Controls.Add(this.amountField);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dateField);
            this.groupBox1.Controls.Add(this.typeField);
            this.groupBox1.Controls.Add(this.descriptionField);
            this.groupBox1.Location = new System.Drawing.Point(12, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(558, 198);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Edit ";
            // 
            // labelAmountToRepay
            // 
            this.labelAmountToRepay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelAmountToRepay.Location = new System.Drawing.Point(376, 82);
            this.labelAmountToRepay.Name = "labelAmountToRepay";
            this.labelAmountToRepay.Size = new System.Drawing.Size(145, 23);
            this.labelAmountToRepay.TabIndex = 24;
            this.labelAmountToRepay.Text = "0.00";
            this.labelAmountToRepay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelToRepay
            // 
            this.labelToRepay.AutoSize = true;
            this.labelToRepay.Location = new System.Drawing.Point(283, 84);
            this.labelToRepay.Name = "labelToRepay";
            this.labelToRepay.Size = new System.Drawing.Size(87, 15);
            this.labelToRepay.TabIndex = 23;
            this.labelToRepay.Text = "Total to Repay";
            // 
            // pourcentageField
            // 
            this.pourcentageField.DecimalPlaces = 2;
            this.pourcentageField.Location = new System.Drawing.Point(116, 82);
            this.pourcentageField.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.pourcentageField.Name = "pourcentageField";
            this.pourcentageField.Size = new System.Drawing.Size(148, 23);
            this.pourcentageField.TabIndex = 21;
            this.pourcentageField.ValueChanged += new System.EventHandler(this.pourcentageField_ValueChanged);
            this.pourcentageField.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pourcentageField_KeyDown);
            this.pourcentageField.KeyUp += new System.Windows.Forms.KeyEventHandler(this.pourcentageField_KeyUp);
            // 
            // labelPourcentage
            // 
            this.labelPourcentage.AutoSize = true;
            this.labelPourcentage.Location = new System.Drawing.Point(13, 84);
            this.labelPourcentage.Name = "labelPourcentage";
            this.labelPourcentage.Size = new System.Drawing.Size(97, 15);
            this.labelPourcentage.TabIndex = 22;
            this.labelPourcentage.Text = "Repayement % :";
            // 
            // buttonAddCategory
            // 
            this.buttonAddCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddCategory.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonAddCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddCategory.Location = new System.Drawing.Point(527, 21);
            this.buttonAddCategory.Name = "buttonAddCategory";
            this.buttonAddCategory.Size = new System.Drawing.Size(23, 23);
            this.buttonAddCategory.TabIndex = 10;
            this.buttonAddCategory.Text = "+";
            this.buttonAddCategory.UseVisualStyleBackColor = false;
            this.buttonAddCategory.Click += new System.EventHandler(this.buttonAddCategory_Click);
            // 
            // categoryField
            // 
            this.categoryField.FormattingEnabled = true;
            this.categoryField.Location = new System.Drawing.Point(376, 21);
            this.categoryField.Name = "categoryField";
            this.categoryField.Size = new System.Drawing.Size(145, 23);
            this.categoryField.TabIndex = 20;
            // 
            // amountField
            // 
            this.amountField.DecimalPlaces = 2;
            this.amountField.Location = new System.Drawing.Point(116, 50);
            this.amountField.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.amountField.Name = "amountField";
            this.amountField.Size = new System.Drawing.Size(148, 23);
            this.amountField.TabIndex = 12;
            this.amountField.ValueChanged += new System.EventHandler(this.amountField_ValueChanged);
            this.amountField.KeyDown += new System.Windows.Forms.KeyEventHandler(this.amountField_KeyDown);
            this.amountField.KeyUp += new System.Windows.Forms.KeyEventHandler(this.amountField_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "Amount :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(307, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 19;
            this.label1.Text = "Category :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 15);
            this.label7.TabIndex = 17;
            this.label7.Text = "Description :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(330, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 15);
            this.label5.TabIndex = 16;
            this.label5.Text = "Date :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "Type :";
            // 
            // dateField
            // 
            this.dateField.CustomFormat = "yyyy-MM-dd";
            this.dateField.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateField.Location = new System.Drawing.Point(376, 50);
            this.dateField.Name = "dateField";
            this.dateField.Size = new System.Drawing.Size(145, 23);
            this.dateField.TabIndex = 13;
            this.dateField.Value = new System.DateTime(2023, 2, 15, 0, 0, 0, 0);
            // 
            // typeField
            // 
            this.typeField.FormattingEnabled = true;
            this.typeField.Location = new System.Drawing.Point(116, 21);
            this.typeField.Name = "typeField";
            this.typeField.Size = new System.Drawing.Size(148, 23);
            this.typeField.TabIndex = 11;
            this.typeField.SelectedIndexChanged += new System.EventHandler(this.typeField_SelectedIndexChanged);
            // 
            // descriptionField
            // 
            this.descriptionField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.descriptionField.Location = new System.Drawing.Point(116, 115);
            this.descriptionField.Multiline = true;
            this.descriptionField.Name = "descriptionField";
            this.descriptionField.Size = new System.Drawing.Size(405, 67);
            this.descriptionField.TabIndex = 10;
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Location = new System.Drawing.Point(361, 0);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(94, 28);
            this.buttonSave.TabIndex = 8;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Location = new System.Drawing.Point(463, 0);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(94, 28);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.buttonCancel);
            this.panel1.Controls.Add(this.buttonSave);
            this.panel1.Location = new System.Drawing.Point(12, 227);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(557, 28);
            this.panel1.TabIndex = 12;
            // 
            // TransactionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 267);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(597, 306);
            this.MinimumSize = new System.Drawing.Size(597, 306);
            this.Name = "TransactionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EditTransaction";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pourcentageField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.amountField)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateField;
        private System.Windows.Forms.NumericUpDown amountField;
        private System.Windows.Forms.ComboBox typeField;
        private System.Windows.Forms.TextBox descriptionField;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox categoryField;
        private System.Windows.Forms.Button buttonAddCategory;
        private System.Windows.Forms.NumericUpDown pourcentageField;
        private System.Windows.Forms.Label labelPourcentage;
        private System.Windows.Forms.Label labelToRepay;
        private System.Windows.Forms.Label labelAmountToRepay;
    }
}