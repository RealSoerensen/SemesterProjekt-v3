namespace Client.Forms.CustomerPanels
{
    partial class CustomersPanel
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
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            filterBox = new ComboBox();
            sortBox = new ComboBox();
            labelCustomersTxt = new Label();
            buttonSearch = new Button();
            textboxSearch = new TextBox();
            panel2 = new Panel();
            buttonDelete = new Button();
            buttonEdit = new Button();
            buttonCreate = new Button();
            customerGrid = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
            bindingSource1 = new BindingSource(components);
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)customerGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(filterBox);
            panel1.Controls.Add(sortBox);
            panel1.Controls.Add(labelCustomersTxt);
            panel1.Controls.Add(buttonSearch);
            panel1.Controls.Add(textboxSearch);
            panel1.Location = new Point(4, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(757, 98);
            panel1.TabIndex = 0;
            // 
            // filterBox
            // 
            filterBox.FormattingEnabled = true;
            filterBox.Items.AddRange(new object[] { "ID", "Fornavn", "Efternavn", "Email", "Tlf. nummer" });
            filterBox.Location = new Point(167, 34);
            filterBox.Name = "filterBox";
            filterBox.Size = new Size(121, 23);
            filterBox.TabIndex = 4;
            filterBox.Text = "Filtrér";
            // 
            // sortBox
            // 
            sortBox.FormattingEnabled = true;
            sortBox.Items.AddRange(new object[] { "Dato oprettet (nyeste-ældst)", "Dato oprettet (ældst-nyeste)" });
            sortBox.Location = new Point(617, 35);
            sortBox.Name = "sortBox";
            sortBox.Size = new Size(121, 23);
            sortBox.TabIndex = 3;
            sortBox.Text = "Sortér";
            sortBox.SelectedIndexChanged += sortBox_SelectedIndexChanged;
            // 
            // labelCustomersTxt
            // 
            labelCustomersTxt.AutoSize = true;
            labelCustomersTxt.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            labelCustomersTxt.Location = new Point(3, 20);
            labelCustomersTxt.Name = "labelCustomersTxt";
            labelCustomersTxt.Size = new Size(102, 37);
            labelCustomersTxt.TabIndex = 2;
            labelCustomersTxt.Text = "Kunder";
            // 
            // buttonSearch
            // 
            buttonSearch.Location = new Point(530, 34);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(46, 23);
            buttonSearch.TabIndex = 1;
            buttonSearch.Text = "Søg";
            buttonSearch.UseVisualStyleBackColor = true;
            buttonSearch.Click += buttonSearch_Click;
            // 
            // textboxSearch
            // 
            textboxSearch.Location = new Point(307, 34);
            textboxSearch.Name = "textboxSearch";
            textboxSearch.Size = new Size(221, 23);
            textboxSearch.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(buttonDelete);
            panel2.Controls.Add(buttonEdit);
            panel2.Controls.Add(buttonCreate);
            panel2.Location = new Point(594, 106);
            panel2.Name = "panel2";
            panel2.Size = new Size(167, 410);
            panel2.TabIndex = 1;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(18, 197);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(130, 46);
            buttonDelete.TabIndex = 2;
            buttonDelete.Text = "Fjern";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonEdit
            // 
            buttonEdit.Location = new Point(18, 117);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(130, 46);
            buttonEdit.TabIndex = 1;
            buttonEdit.Text = "Rediger";
            buttonEdit.UseVisualStyleBackColor = true;
            buttonEdit.Click += buttonEdit_Click;
            // 
            // buttonCreate
            // 
            buttonCreate.Location = new Point(18, 36);
            buttonCreate.Name = "buttonCreate";
            buttonCreate.Size = new Size(130, 46);
            buttonCreate.TabIndex = 0;
            buttonCreate.Text = "Opret";
            buttonCreate.UseVisualStyleBackColor = true;
            buttonCreate.Click += buttonCreate_Click;
            // 
            // customerGrid
            // 
            customerGrid.AllowUserToAddRows = false;
            customerGrid.AllowUserToDeleteRows = false;
            customerGrid.AllowUserToResizeColumns = false;
            customerGrid.AutoGenerateColumns = false;
            customerGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            customerGrid.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6, dataGridViewTextBoxColumn7, dataGridViewTextBoxColumn8 });
            customerGrid.DataSource = bindingSource1;
            customerGrid.EditMode = DataGridViewEditMode.EditProgrammatically;
            customerGrid.Location = new Point(6, 106);
            customerGrid.Name = "customerGrid";
            customerGrid.ReadOnly = true;
            customerGrid.RowTemplate.Height = 25;
            customerGrid.Size = new Size(575, 410);
            customerGrid.TabIndex = 2;
            customerGrid.CellContentClick += customerGrid_CellContentClick;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            dataGridViewTextBoxColumn1.HeaderText = "ID";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.DataPropertyName = "FirstName";
            dataGridViewTextBoxColumn2.HeaderText = "FirstName";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.DataPropertyName = "LastName";
            dataGridViewTextBoxColumn3.HeaderText = "LastName";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.DataPropertyName = "AddressID";
            dataGridViewTextBoxColumn4.HeaderText = "AddressID";
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.DataPropertyName = "Email";
            dataGridViewTextBoxColumn5.HeaderText = "Email";
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.DataPropertyName = "PhoneNo";
            dataGridViewTextBoxColumn6.HeaderText = "PhoneNo";
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewTextBoxColumn7.DataPropertyName = "Password";
            dataGridViewTextBoxColumn7.HeaderText = "Password";
            dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewTextBoxColumn8.DataPropertyName = "RegisterDate";
            dataGridViewTextBoxColumn8.HeaderText = "RegisterDate";
            dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // bindingSource1
            // 
            bindingSource1.DataSource = typeof(Models.Customer);
            // 
            // CustomersPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(765, 528);
            ControlBox = false;
            Controls.Add(customerGrid);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CustomersPanel";
            Text = "Kunder";
            WindowState = FormWindowState.Maximized;
            Load += CustomersPanel_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)customerGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Button buttonDelete;
        private Button buttonEdit;
        private Button buttonCreate;
        private Button buttonSearch;
        private TextBox textBoxSearchbar;
        private Label labelCustomersTxt;
        private ComboBox comboBox2;
        private ComboBox comboBox1;
        private DataGridView customerGrid;
        private DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn firstNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn lastNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn addressIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn phoneNoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn passwordDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn registerDateDataGridViewTextBoxColumn;
        private BindingSource customerBindingSource;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private BindingSource bindingSource1;
        private ComboBox filterBox;
        private ComboBox sortBox;
        private TextBox textboxSearch;
    }
}