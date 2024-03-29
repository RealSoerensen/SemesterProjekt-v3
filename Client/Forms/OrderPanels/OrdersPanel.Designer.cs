﻿using System.ComponentModel;

namespace Client.Forms.OrderPanels {
    partial class OrdersPanel {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            panel1 = new Panel();
            label4 = new Label();
            label3 = new Label();
            checkBox2 = new CheckBox();
            checkBox1 = new CheckBox();
            checkBoxPrice6 = new CheckBox();
            checkBoxPrice5 = new CheckBox();
            checkBoxPrice4 = new CheckBox();
            checkBoxPrice3 = new CheckBox();
            checkBoxPrice2 = new CheckBox();
            checkBoxPrice1 = new CheckBox();
            label2 = new Label();
            comboBox1 = new ComboBox();
            labelOrdersTxt = new Label();
            textBoxSearchbar = new TextBox();
            panel2 = new Panel();
            buttonDetails = new Button();
            orderGrid = new DataGridView();
            OrderID = new DataGridViewTextBoxColumn();
            Date = new DataGridViewTextBoxColumn();
            Customer = new DataGridViewTextBoxColumn();
            NumberOfOrderlines = new DataGridViewTextBoxColumn();
            NumberOfProducts = new DataGridViewTextBoxColumn();
            PriceOfOrder = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)orderGrid).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(checkBox2);
            panel1.Controls.Add(checkBox1);
            panel1.Controls.Add(checkBoxPrice6);
            panel1.Controls.Add(checkBoxPrice5);
            panel1.Controls.Add(checkBoxPrice4);
            panel1.Controls.Add(checkBoxPrice3);
            panel1.Controls.Add(checkBoxPrice2);
            panel1.Controls.Add(checkBoxPrice1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(labelOrdersTxt);
            panel1.Controls.Add(textBoxSearchbar);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(837, 159);
            panel1.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F);
            label4.Location = new Point(253, 30);
            label4.Name = "label4";
            label4.Size = new Size(48, 25);
            label4.TabIndex = 21;
            label4.Text = "Søg:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F);
            label3.Location = new Point(615, 33);
            label3.Name = "label3";
            label3.Size = new Size(67, 25);
            label3.TabIndex = 20;
            label3.Text = "Sortér:";
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(449, 126);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(58, 19);
            checkBox2.TabIndex = 19;
            checkBox2.Text = "3500+";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += CheckBox_CheckedChanged;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(449, 101);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(79, 19);
            checkBox1.TabIndex = 18;
            checkBox1.Text = "3000-3500";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += CheckBox_CheckedChanged;
            // 
            // checkBoxPrice6
            // 
            checkBoxPrice6.AutoSize = true;
            checkBoxPrice6.Location = new Point(359, 126);
            checkBoxPrice6.Name = "checkBoxPrice6";
            checkBoxPrice6.Size = new Size(79, 19);
            checkBoxPrice6.TabIndex = 17;
            checkBoxPrice6.Text = "2500-3000";
            checkBoxPrice6.UseVisualStyleBackColor = true;
            checkBoxPrice6.CheckedChanged += CheckBox_CheckedChanged;
            // 
            // checkBoxPrice5
            // 
            checkBoxPrice5.AutoSize = true;
            checkBoxPrice5.Location = new Point(359, 101);
            checkBoxPrice5.Name = "checkBoxPrice5";
            checkBoxPrice5.Size = new Size(79, 19);
            checkBoxPrice5.TabIndex = 16;
            checkBoxPrice5.Text = "2000-2500";
            checkBoxPrice5.UseVisualStyleBackColor = true;
            checkBoxPrice5.CheckedChanged += CheckBox_CheckedChanged;
            // 
            // checkBoxPrice4
            // 
            checkBoxPrice4.AutoSize = true;
            checkBoxPrice4.Location = new Point(254, 126);
            checkBoxPrice4.Name = "checkBoxPrice4";
            checkBoxPrice4.Size = new Size(79, 19);
            checkBoxPrice4.TabIndex = 15;
            checkBoxPrice4.Text = "1500-2000";
            checkBoxPrice4.UseVisualStyleBackColor = true;
            checkBoxPrice4.CheckedChanged += CheckBox_CheckedChanged;
            // 
            // checkBoxPrice3
            // 
            checkBoxPrice3.AutoSize = true;
            checkBoxPrice3.Location = new Point(254, 102);
            checkBoxPrice3.Name = "checkBoxPrice3";
            checkBoxPrice3.Size = new Size(79, 19);
            checkBoxPrice3.TabIndex = 14;
            checkBoxPrice3.Text = "1000-1500";
            checkBoxPrice3.UseVisualStyleBackColor = true;
            checkBoxPrice3.CheckedChanged += CheckBox_CheckedChanged;
            // 
            // checkBoxPrice2
            // 
            checkBoxPrice2.AutoSize = true;
            checkBoxPrice2.Location = new Point(162, 126);
            checkBoxPrice2.Name = "checkBoxPrice2";
            checkBoxPrice2.Size = new Size(73, 19);
            checkBoxPrice2.TabIndex = 13;
            checkBoxPrice2.Text = "500-1000";
            checkBoxPrice2.UseVisualStyleBackColor = true;
            checkBoxPrice2.CheckedChanged += CheckBox_CheckedChanged;
            // 
            // checkBoxPrice1
            // 
            checkBoxPrice1.AutoSize = true;
            checkBoxPrice1.Location = new Point(162, 101);
            checkBoxPrice1.Name = "checkBoxPrice1";
            checkBoxPrice1.Size = new Size(55, 19);
            checkBoxPrice1.TabIndex = 12;
            checkBoxPrice1.Text = "0-500";
            checkBoxPrice1.UseVisualStyleBackColor = true;
            checkBoxPrice1.CheckedChanged += CheckBox_CheckedChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F);
            label2.Location = new Point(8, 102);
            label2.Name = "label2";
            label2.Size = new Size(124, 25);
            label2.TabIndex = 11;
            label2.Text = "Pris på ordre:";
            // 
            // comboBox1
            // 
            comboBox1.BackColor = SystemColors.Window;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Dato (ny-gammel)", "Data (gammel-ny)", "Ordrelinjer (mange-få)", "Ordrelinjer (få-mange)", "Produkter (mange-få)", "Produkter (få-mange)", "Pris (høj-lav)", "Pris (lav-høj)" });
            comboBox1.Location = new Point(688, 35);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 3;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // labelOrdersTxt
            // 
            labelOrdersTxt.AutoSize = true;
            labelOrdersTxt.Font = new Font("Segoe UI", 20F);
            labelOrdersTxt.Location = new Point(3, 20);
            labelOrdersTxt.Name = "labelOrdersTxt";
            labelOrdersTxt.Size = new Size(94, 37);
            labelOrdersTxt.TabIndex = 2;
            labelOrdersTxt.Text = "Ordrer";
            // 
            // textBoxSearchbar
            // 
            textBoxSearchbar.Location = new Point(307, 34);
            textBoxSearchbar.Name = "textBoxSearchbar";
            textBoxSearchbar.Size = new Size(221, 23);
            textBoxSearchbar.TabIndex = 0;
            textBoxSearchbar.TextChanged += textBoxSearchbar_TextChanged_1;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(buttonDetails);
            panel2.Location = new Point(673, 167);
            panel2.Name = "panel2";
            panel2.Size = new Size(167, 403);
            panel2.TabIndex = 2;
            // 
            // buttonDetails
            // 
            buttonDetails.Location = new Point(3, 115);
            buttonDetails.Name = "buttonDetails";
            buttonDetails.Size = new Size(159, 46);
            buttonDetails.TabIndex = 2;
            buttonDetails.Text = "Se detaljer på ordren";
            buttonDetails.UseVisualStyleBackColor = true;
            buttonDetails.Click += buttonDetails_Click;
            // 
            // orderGrid
            // 
            orderGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            orderGrid.Location = new Point(3, 167);
            orderGrid.Name = "orderGrid";
            orderGrid.RowTemplate.Height = 25;
            orderGrid.Size = new Size(664, 403);
            orderGrid.TabIndex = 3;
            orderGrid.SelectionChanged += orderGrid_SelectionChanged;
            orderGrid.DoubleClick += orderGrid_CellDoubleClick;
            // 
            // OrderID
            // 
            OrderID.HeaderText = "OrderID";
            OrderID.Name = "OrderID";
            OrderID.ReadOnly = true;
            OrderID.Width = 60;
            // 
            // Date
            // 
            Date.HeaderText = "Date";
            Date.Name = "Date";
            Date.ReadOnly = true;
            Date.Width = 70;
            // 
            // Customer
            // 
            Customer.HeaderText = "Customer";
            Customer.Name = "Customer";
            Customer.ReadOnly = true;
            Customer.Width = 180;
            // 
            // NumberOfOrderlines
            // 
            NumberOfOrderlines.HeaderText = "Number of Orderlines";
            NumberOfOrderlines.Name = "NumberOfOrderlines";
            NumberOfOrderlines.ReadOnly = true;
            NumberOfOrderlines.Width = 80;
            // 
            // NumberOfProducts
            // 
            NumberOfProducts.HeaderText = "Number of Products";
            NumberOfProducts.Name = "NumberOfProducts";
            NumberOfProducts.ReadOnly = true;
            NumberOfProducts.Width = 80;
            // 
            // PriceOfOrder
            // 
            PriceOfOrder.HeaderText = "Price of Order";
            PriceOfOrder.Name = "PriceOfOrder";
            PriceOfOrder.ReadOnly = true;
            PriceOfOrder.Width = 80;
            // 
            // OrdersPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(843, 582);
            ControlBox = false;
            Controls.Add(orderGrid);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "OrdersPanel";
            Text = "OrdersPanel";
            Load += OrdersPanel_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)orderGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private CheckBox checkBoxPrice6;
        private CheckBox checkBoxPrice5;
        private CheckBox checkBoxPrice4;
        private CheckBox checkBoxPrice3;
        private CheckBox checkBoxPrice2;
        private Label label2;
        private ComboBox comboBox1;
        private Label labelOrdersTxt;
        private TextBox textBoxSearchbar;
        private Panel panel2;
        private Button buttonDetails;
        private DataGridView orderGrid;
        private DataGridViewTextBoxColumn OrderID;
        private DataGridViewTextBoxColumn Date;
        private DataGridViewTextBoxColumn Customer;
        private DataGridViewTextBoxColumn NumberOfOrderlines;
        private DataGridViewTextBoxColumn NumberOfProducts;
        private DataGridViewTextBoxColumn PriceOfOrder;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private Label label3;
        private Label label4;
        private CheckBox checkBoxPrice1;
    }
}