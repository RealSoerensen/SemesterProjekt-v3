namespace Client.Forms.ProductPanels {
    partial class ProductsPanel {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            checkBoxAccessories = new CheckBox();
            checkBoxPrice6 = new CheckBox();
            checkBoxPrice5 = new CheckBox();
            checkBoxPrice4 = new CheckBox();
            checkBoxPrice3 = new CheckBox();
            checkBoxPrice2 = new CheckBox();
            checkBoxPrice1 = new CheckBox();
            label2 = new Label();
            label1 = new Label();
            checkBoxBags = new CheckBox();
            checkBoxRacket = new CheckBox();
            checkBoxBalls = new CheckBox();
            checkBoxShoes = new CheckBox();
            checkBoxClothes = new CheckBox();
            comboBox1 = new ComboBox();
            labelProductsTxt = new Label();
            buttonSearch = new Button();
            textBoxSearchbar = new TextBox();
            panel2 = new Panel();
            buttonDelete = new Button();
            buttonEdit = new Button();
            button1 = new Button();
            productGrid = new DataGridView();
            iDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            descriptionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            salePriceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            purchasePriceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            normalPriceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            stockDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            brandDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            categoryDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            productBindingSource = new BindingSource(components);
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)productGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)productBindingSource).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(checkBoxAccessories);
            panel1.Controls.Add(checkBoxPrice6);
            panel1.Controls.Add(checkBoxPrice5);
            panel1.Controls.Add(checkBoxPrice4);
            panel1.Controls.Add(checkBoxPrice3);
            panel1.Controls.Add(checkBoxPrice2);
            panel1.Controls.Add(checkBoxPrice1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(checkBoxBags);
            panel1.Controls.Add(checkBoxRacket);
            panel1.Controls.Add(checkBoxBalls);
            panel1.Controls.Add(checkBoxShoes);
            panel1.Controls.Add(checkBoxClothes);
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(labelProductsTxt);
            panel1.Controls.Add(buttonSearch);
            panel1.Controls.Add(textBoxSearchbar);
            panel1.Location = new Point(4, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(834, 159);
            panel1.TabIndex = 0;
            // 
            // checkBoxAccessories
            // 
            checkBoxAccessories.AutoSize = true;
            checkBoxAccessories.Location = new Point(266, 120);
            checkBoxAccessories.Name = "checkBoxAccessories";
            checkBoxAccessories.Size = new Size(69, 19);
            checkBoxAccessories.TabIndex = 18;
            checkBoxAccessories.Text = "Tilbehør";
            checkBoxAccessories.UseVisualStyleBackColor = true;
            checkBoxAccessories.CheckedChanged += CheckBox_CheckedChanged;
            // 
            // checkBoxPrice6
            // 
            checkBoxPrice6.AutoSize = true;
            checkBoxPrice6.Location = new Point(649, 120);
            checkBoxPrice6.Name = "checkBoxPrice6";
            checkBoxPrice6.Size = new Size(58, 19);
            checkBoxPrice6.TabIndex = 17;
            checkBoxPrice6.Text = "1500+";
            checkBoxPrice6.UseVisualStyleBackColor = true;
            checkBoxPrice6.CheckedChanged += CheckBox_CheckedChanged;
            // 
            // checkBoxPrice5
            // 
            checkBoxPrice5.AutoSize = true;
            checkBoxPrice5.Location = new Point(649, 95);
            checkBoxPrice5.Name = "checkBoxPrice5";
            checkBoxPrice5.Size = new Size(79, 19);
            checkBoxPrice5.TabIndex = 16;
            checkBoxPrice5.Text = "1000-1500";
            checkBoxPrice5.UseVisualStyleBackColor = true;
            checkBoxPrice5.CheckedChanged += CheckBox_CheckedChanged;
            // 
            // checkBoxPrice4
            // 
            checkBoxPrice4.AutoSize = true;
            checkBoxPrice4.Location = new Point(557, 120);
            checkBoxPrice4.Name = "checkBoxPrice4";
            checkBoxPrice4.Size = new Size(73, 19);
            checkBoxPrice4.TabIndex = 15;
            checkBoxPrice4.Text = "500-1000";
            checkBoxPrice4.UseVisualStyleBackColor = true;
            checkBoxPrice4.CheckedChanged += CheckBox_CheckedChanged;
            // 
            // checkBoxPrice3
            // 
            checkBoxPrice3.AutoSize = true;
            checkBoxPrice3.Location = new Point(557, 95);
            checkBoxPrice3.Name = "checkBoxPrice3";
            checkBoxPrice3.Size = new Size(67, 19);
            checkBoxPrice3.TabIndex = 14;
            checkBoxPrice3.Text = "300-500";
            checkBoxPrice3.UseVisualStyleBackColor = true;
            checkBoxPrice3.CheckedChanged += CheckBox_CheckedChanged;
            // 
            // checkBoxPrice2
            // 
            checkBoxPrice2.AutoSize = true;
            checkBoxPrice2.Location = new Point(468, 120);
            checkBoxPrice2.Name = "checkBoxPrice2";
            checkBoxPrice2.Size = new Size(67, 19);
            checkBoxPrice2.TabIndex = 13;
            checkBoxPrice2.Text = "150-300";
            checkBoxPrice2.UseVisualStyleBackColor = true;
            checkBoxPrice2.CheckedChanged += CheckBox_CheckedChanged;
            // 
            // checkBoxPrice1
            // 
            checkBoxPrice1.AutoSize = true;
            checkBoxPrice1.Location = new Point(468, 95);
            checkBoxPrice1.Name = "checkBoxPrice1";
            checkBoxPrice1.Size = new Size(55, 19);
            checkBoxPrice1.TabIndex = 12;
            checkBoxPrice1.Text = "0-150";
            checkBoxPrice1.UseVisualStyleBackColor = true;
            checkBoxPrice1.CheckedChanged += CheckBox_CheckedChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F);
            label2.Location = new Point(404, 95);
            label2.Name = "label2";
            label2.Size = new Size(47, 25);
            label2.TabIndex = 11;
            label2.Text = "Pris:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F);
            label1.Location = new Point(3, 95);
            label1.Name = "label1";
            label1.Size = new Size(65, 25);
            label1.TabIndex = 10;
            label1.Text = "Filtrér:";
            // 
            // checkBoxBags
            // 
            checkBoxBags.AutoSize = true;
            checkBoxBags.Location = new Point(266, 95);
            checkBoxBags.Name = "checkBoxBags";
            checkBoxBags.Size = new Size(58, 19);
            checkBoxBags.TabIndex = 8;
            checkBoxBags.Text = "Tasker";
            checkBoxBags.UseVisualStyleBackColor = true;
            checkBoxBags.CheckedChanged += CheckBox_CheckedChanged;
            // 
            // checkBoxRacket
            // 
            checkBoxRacket.AutoSize = true;
            checkBoxRacket.Location = new Point(177, 120);
            checkBoxRacket.Name = "checkBoxRacket";
            checkBoxRacket.Size = new Size(72, 19);
            checkBoxRacket.TabIndex = 7;
            checkBoxRacket.Text = "Padelbat";
            checkBoxRacket.UseVisualStyleBackColor = true;
            checkBoxRacket.CheckedChanged += CheckBox_CheckedChanged;
            // 
            // checkBoxBalls
            // 
            checkBoxBalls.AutoSize = true;
            checkBoxBalls.Location = new Point(177, 95);
            checkBoxBalls.Name = "checkBoxBalls";
            checkBoxBalls.Size = new Size(56, 19);
            checkBoxBalls.TabIndex = 6;
            checkBoxBalls.Text = "Bolde";
            checkBoxBalls.UseVisualStyleBackColor = true;
            checkBoxBalls.CheckedChanged += CheckBox_CheckedChanged;
            // 
            // checkBoxShoes
            // 
            checkBoxShoes.AutoSize = true;
            checkBoxShoes.Location = new Point(88, 120);
            checkBoxShoes.Name = "checkBoxShoes";
            checkBoxShoes.Size = new Size(45, 19);
            checkBoxShoes.TabIndex = 5;
            checkBoxShoes.Text = "Sko";
            checkBoxShoes.UseVisualStyleBackColor = true;
            checkBoxShoes.CheckedChanged += CheckBox_CheckedChanged;
            // 
            // checkBoxClothes
            // 
            checkBoxClothes.AutoSize = true;
            checkBoxClothes.Location = new Point(88, 95);
            checkBoxClothes.Name = "checkBoxClothes";
            checkBoxClothes.Size = new Size(42, 19);
            checkBoxClothes.TabIndex = 4;
            checkBoxClothes.Text = "Tøj";
            checkBoxClothes.UseVisualStyleBackColor = true;
            checkBoxClothes.CheckedChanged += CheckBox_CheckedChanged;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Name (a-å)", "Name (å-a)", "SalePrice (høj-lav)", "SalePrice (lav-høj)", "PurchasePrice (høj-lav)", "PurchasePrice (lav-høj)", "NormalPrice (høj-lav)", "NormalPrice (lav-høj)", "Stock (høj-lav)", "Stock (lav-høj)" });
            comboBox1.Location = new Point(617, 35);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 3;
            comboBox1.Text = "Sortér";
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // labelProductsTxt
            // 
            labelProductsTxt.AutoSize = true;
            labelProductsTxt.Font = new Font("Segoe UI", 20F);
            labelProductsTxt.Location = new Point(3, 20);
            labelProductsTxt.Name = "labelProductsTxt";
            labelProductsTxt.Size = new Size(133, 37);
            labelProductsTxt.TabIndex = 2;
            labelProductsTxt.Text = "Produkter";
            // 
            // buttonSearch
            // 
            buttonSearch.Location = new Point(530, 34);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(46, 23);
            buttonSearch.TabIndex = 1;
            buttonSearch.Text = "Søg";
            buttonSearch.UseVisualStyleBackColor = true;
            // 
            // textBoxSearchbar
            // 
            textBoxSearchbar.Location = new Point(307, 34);
            textBoxSearchbar.Name = "textBoxSearchbar";
            textBoxSearchbar.Size = new Size(221, 23);
            textBoxSearchbar.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(buttonDelete);
            panel2.Controls.Add(buttonEdit);
            panel2.Controls.Add(button1);
            panel2.Location = new Point(671, 167);
            panel2.Name = "panel2";
            panel2.Size = new Size(167, 403);
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
            // button1
            // 
            button1.Location = new Point(18, 36);
            button1.Name = "button1";
            button1.Size = new Size(130, 46);
            button1.TabIndex = 0;
            button1.Text = "Opret";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnCreateProduct_Click;
            // 
            // productGrid
            // 
            productGrid.AutoGenerateColumns = false;
            productGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            productGrid.Columns.AddRange(new DataGridViewColumn[] { iDDataGridViewTextBoxColumn, descriptionDataGridViewTextBoxColumn, salePriceDataGridViewTextBoxColumn, purchasePriceDataGridViewTextBoxColumn, normalPriceDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn, stockDataGridViewTextBoxColumn, brandDataGridViewTextBoxColumn, categoryDataGridViewTextBoxColumn });
            productGrid.DataSource = productBindingSource;
            productGrid.Location = new Point(4, 167);
            productGrid.Name = "productGrid";
            productGrid.RowTemplate.Height = 25;
            productGrid.Size = new Size(661, 403);
            productGrid.TabIndex = 2;
            productGrid.CellContentClick += productGrid_CellContentClick;
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
            // productBindingSource
            // 
            productBindingSource.DataSource = typeof(Models.Product);
            // 
            // ProductsPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(843, 582);
            ControlBox = false;
            Controls.Add(productGrid);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ProductsPanel";
            Text = "Produkter";
            WindowState = FormWindowState.Maximized;
            Load += ProductsPanel_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)productGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)productBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Button buttonDelete;
        private Button buttonEdit;
        private Button button1;
        private Button buttonSearch;
        private TextBox textBoxSearchbar;
        private Label labelProductsTxt;
        private ComboBox comboBox1;
        private CheckBox checkBoxRacket;
        private CheckBox checkBoxBalls;
        private CheckBox checkBoxShoes;
        private CheckBox checkBoxClothes;
        private Label label1;
        private CheckBox checkBoxBags;
        private Label label2;
        private CheckBox checkBox8;
        private CheckBox checkBox7;
        private CheckBox checkBox12;
        private CheckBox checkBox11;
        private CheckBox checkBox10;
        private CheckBox checkBox9;
        private DataGridView productGrid;
        private BindingSource productBindingSource;
        private DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn salePriceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn purchasePriceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn normalPriceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn stockDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn brandDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn categoryDataGridViewTextBoxColumn;
        private CheckBox checkBoxAccessories;
        private CheckBox checkBoxPrice6;
        private CheckBox checkBoxPrice5;
        private CheckBox checkBoxPrice4;
        private CheckBox checkBoxPrice3;
        private CheckBox checkBoxPrice2;
        private CheckBox checkBoxPrice1;
    }
}