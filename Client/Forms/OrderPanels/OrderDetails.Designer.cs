namespace Client.Forms.OrderPanels
{
    partial class OrderDetails
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
            label1 = new Label();
            label2 = new Label();
            labelOrderID = new Label();
            label4 = new Label();
            labelDate = new Label();
            label3 = new Label();
            label5 = new Label();
            label6 = new Label();
            labelFirstName = new Label();
            labelLastName = new Label();
            productGridView = new DataGridView();
            iDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            descriptionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            imageDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            salePriceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            purchasePriceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            normalPriceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            stockDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            brandDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            categoryDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            inactiveDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            productBindingSource = new BindingSource(components);
            label7 = new Label();
            labelCustomerID = new Label();
            label9 = new Label();
            labelAddress = new Label();
            buttonClose = new Button();
            label8 = new Label();
            labelOrderPrice = new Label();
            label10 = new Label();
            labelCity = new Label();
            ((System.ComponentModel.ISupportInitialize)productGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)productBindingSource).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(138, 25);
            label1.TabIndex = 0;
            label1.Text = "Ordre Detaljer";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 66);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 1;
            label2.Text = "Ordre ID:";
            // 
            // labelOrderID
            // 
            labelOrderID.AutoSize = true;
            labelOrderID.Location = new Point(117, 66);
            labelOrderID.Name = "labelOrderID";
            labelOrderID.Size = new Size(28, 15);
            labelOrderID.TabIndex = 2;
            labelOrderID.Text = "*ID*";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 96);
            label4.Name = "label4";
            label4.Size = new Size(35, 15);
            label4.TabIndex = 3;
            label4.Text = "Dato:";
            // 
            // labelDate
            // 
            labelDate.AutoSize = true;
            labelDate.Location = new Point(117, 96);
            labelDate.Name = "labelDate";
            labelDate.Size = new Size(44, 15);
            labelDate.TabIndex = 4;
            labelDate.Text = "*DATE*";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 139);
            label3.Name = "label3";
            label3.Size = new Size(70, 25);
            label3.TabIndex = 5;
            label3.Text = "Kunde";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 208);
            label5.Name = "label5";
            label5.Size = new Size(53, 15);
            label5.TabIndex = 6;
            label5.Text = "Fornavn:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 254);
            label6.Name = "label6";
            label6.Size = new Size(60, 15);
            label6.TabIndex = 7;
            label6.Text = "Efternavn:";
            // 
            // labelFirstName
            // 
            labelFirstName.AutoSize = true;
            labelFirstName.Location = new Point(115, 208);
            labelFirstName.Name = "labelFirstName";
            labelFirstName.Size = new Size(79, 15);
            labelFirstName.TabIndex = 8;
            labelFirstName.Text = "*FIRSTNAME*";
            // 
            // labelLastName
            // 
            labelLastName.AutoSize = true;
            labelLastName.Location = new Point(115, 254);
            labelLastName.Name = "labelLastName";
            labelLastName.Size = new Size(77, 15);
            labelLastName.TabIndex = 9;
            labelLastName.Text = "*LASTNAME*";
            // 
            // productGridView
            // 
            productGridView.AutoGenerateColumns = false;
            productGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            productGridView.Columns.AddRange(new DataGridViewColumn[] { iDDataGridViewTextBoxColumn, descriptionDataGridViewTextBoxColumn, imageDataGridViewTextBoxColumn, salePriceDataGridViewTextBoxColumn, purchasePriceDataGridViewTextBoxColumn, normalPriceDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn, stockDataGridViewTextBoxColumn, brandDataGridViewTextBoxColumn, categoryDataGridViewTextBoxColumn, inactiveDataGridViewCheckBoxColumn });
            productGridView.DataSource = productBindingSource;
            productGridView.Location = new Point(267, 12);
            productGridView.Name = "productGridView";
            productGridView.RowTemplate.Height = 25;
            productGridView.Size = new Size(333, 311);
            productGridView.TabIndex = 10;
            productGridView.CellContentClick += ProductGridViewCellContentClick;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            iDDataGridViewTextBoxColumn.HeaderText = "ID";
            iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            // 
            // imageDataGridViewTextBoxColumn
            // 
            imageDataGridViewTextBoxColumn.DataPropertyName = "Image";
            imageDataGridViewTextBoxColumn.HeaderText = "Image";
            imageDataGridViewTextBoxColumn.Name = "imageDataGridViewTextBoxColumn";
            // 
            // salePriceDataGridViewTextBoxColumn
            // 
            salePriceDataGridViewTextBoxColumn.DataPropertyName = "SalePrice";
            salePriceDataGridViewTextBoxColumn.HeaderText = "SalePrice";
            salePriceDataGridViewTextBoxColumn.Name = "salePriceDataGridViewTextBoxColumn";
            // 
            // purchasePriceDataGridViewTextBoxColumn
            // 
            purchasePriceDataGridViewTextBoxColumn.DataPropertyName = "PurchasePrice";
            purchasePriceDataGridViewTextBoxColumn.HeaderText = "PurchasePrice";
            purchasePriceDataGridViewTextBoxColumn.Name = "purchasePriceDataGridViewTextBoxColumn";
            // 
            // normalPriceDataGridViewTextBoxColumn
            // 
            normalPriceDataGridViewTextBoxColumn.DataPropertyName = "NormalPrice";
            normalPriceDataGridViewTextBoxColumn.HeaderText = "NormalPrice";
            normalPriceDataGridViewTextBoxColumn.Name = "normalPriceDataGridViewTextBoxColumn";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "Name";
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // stockDataGridViewTextBoxColumn
            // 
            stockDataGridViewTextBoxColumn.DataPropertyName = "Stock";
            stockDataGridViewTextBoxColumn.HeaderText = "Stock";
            stockDataGridViewTextBoxColumn.Name = "stockDataGridViewTextBoxColumn";
            // 
            // brandDataGridViewTextBoxColumn
            // 
            brandDataGridViewTextBoxColumn.DataPropertyName = "Brand";
            brandDataGridViewTextBoxColumn.HeaderText = "Brand";
            brandDataGridViewTextBoxColumn.Name = "brandDataGridViewTextBoxColumn";
            // 
            // categoryDataGridViewTextBoxColumn
            // 
            categoryDataGridViewTextBoxColumn.DataPropertyName = "Category";
            categoryDataGridViewTextBoxColumn.HeaderText = "Category";
            categoryDataGridViewTextBoxColumn.Name = "categoryDataGridViewTextBoxColumn";
            // 
            // inactiveDataGridViewCheckBoxColumn
            // 
            inactiveDataGridViewCheckBoxColumn.DataPropertyName = "Inactive";
            inactiveDataGridViewCheckBoxColumn.HeaderText = "Inactive";
            inactiveDataGridViewCheckBoxColumn.Name = "inactiveDataGridViewCheckBoxColumn";
            // 
            // productBindingSource
            // 
            productBindingSource.DataSource = typeof(Models.Product);
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(14, 174);
            label7.Name = "label7";
            label7.Size = new Size(90, 15);
            label7.TabIndex = 11;
            label7.Text = "Kundenummer:";
            // 
            // labelCustomerID
            // 
            labelCustomerID.AutoSize = true;
            labelCustomerID.Location = new Point(115, 174);
            labelCustomerID.Name = "labelCustomerID";
            labelCustomerID.Size = new Size(88, 15);
            labelCustomerID.TabIndex = 12;
            labelCustomerID.Text = "*CUSTOMERID*";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(14, 337);
            label9.Name = "label9";
            label9.Size = new Size(51, 15);
            label9.TabIndex = 13;
            label9.Text = "Adresse:";
            // 
            // labelAddress
            // 
            labelAddress.AutoSize = true;
            labelAddress.Location = new Point(115, 337);
            labelAddress.Name = "labelAddress";
            labelAddress.Size = new Size(66, 15);
            labelAddress.TabIndex = 14;
            labelAddress.Text = "*ADDRESS*";
            // 
            // buttonClose
            // 
            buttonClose.Location = new Point(14, 403);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(160, 43);
            buttonClose.TabIndex = 15;
            buttonClose.Text = "Luk";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += buttonClose_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(423, 337);
            label8.Name = "label8";
            label8.Size = new Size(61, 15);
            label8.TabIndex = 16;
            label8.Text = "Fulde pris:";
            // 
            // labelOrderPrice
            // 
            labelOrderPrice.AutoSize = true;
            labelOrderPrice.Location = new Point(515, 337);
            labelOrderPrice.Name = "labelOrderPrice";
            labelOrderPrice.Size = new Size(85, 15);
            labelOrderPrice.TabIndex = 17;
            labelOrderPrice.Text = "*ORDERPRICE*";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(14, 295);
            label10.Name = "label10";
            label10.Size = new Size(23, 15);
            label10.TabIndex = 18;
            label10.Text = "By:";
            // 
            // labelCity
            // 
            labelCity.AutoSize = true;
            labelCity.Location = new Point(115, 295);
            labelCity.Name = "labelCity";
            labelCity.Size = new Size(41, 15);
            labelCity.TabIndex = 19;
            labelCity.Text = "*CITY*";
            // 
            // OrderDetails
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(612, 473);
            Controls.Add(labelCity);
            Controls.Add(label10);
            Controls.Add(labelOrderPrice);
            Controls.Add(label8);
            Controls.Add(buttonClose);
            Controls.Add(labelAddress);
            Controls.Add(label9);
            Controls.Add(labelCustomerID);
            Controls.Add(label7);
            Controls.Add(productGridView);
            Controls.Add(labelLastName);
            Controls.Add(labelFirstName);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(labelDate);
            Controls.Add(label4);
            Controls.Add(labelOrderID);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "OrderDetails";
            Text = "OrderDetails";
            ((System.ComponentModel.ISupportInitialize)productGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)productBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label labelOrderID;
        private Label label4;
        private Label labelDate;
        private Label label3;
        private Label label5;
        private Label label6;
        private Label labelFirstName;
        private Label labelLastName;
        private DataGridView productGridView;
        private Label label7;
        private Label labelCustomerID;
        private Label label9;
        private Label labelAddress;
        private DataGridViewTextBoxColumn ProductID;
        private DataGridViewTextBoxColumn ProductName;
        private DataGridViewTextBoxColumn ProductPrice;
        private Button buttonClose;
        private Label label8;
        private Label labelOrderPrice;
        private Label label10;
        private Label labelCity;
        private DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn imageDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn salePriceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn purchasePriceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn normalPriceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn stockDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn brandDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn categoryDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn inactiveDataGridViewCheckBoxColumn;
        private BindingSource productBindingSource;
    }
}