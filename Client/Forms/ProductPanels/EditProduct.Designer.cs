namespace Client.Forms.ProductPanels {
    partial class EditProduct {
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            buttonSave = new Button();
            buttonCancel = new Button();
            textBoxID = new TextBox();
            textBoxProductName = new TextBox();
            textBoxStock = new TextBox();
            textBoxNormalPrice = new TextBox();
            textBoxSalesPrice = new TextBox();
            textBoxPurchasePrice = new TextBox();
            pictureBoxImage = new PictureBox();
            buttonChoosePicture = new Button();
            label9 = new Label();
            textBoxBrand = new TextBox();
            comboBoxCategory = new ComboBox();
            label10 = new Label();
            textBoxDescription = new TextBox();
            label11 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBoxImage).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 49);
            label1.Name = "label1";
            label1.Size = new Size(18, 15);
            label1.TabIndex = 0;
            label1.Text = "ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 87);
            label2.Name = "label2";
            label2.Size = new Size(75, 15);
            label2.TabIndex = 1;
            label2.Text = "Produktnavn";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 199);
            label3.Name = "label3";
            label3.Size = new Size(53, 15);
            label3.TabIndex = 2;
            label3.Text = "Salgspris";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 160);
            label4.Name = "label4";
            label4.Size = new Size(66, 15);
            label4.TabIndex = 3;
            label4.Text = "Normalpris";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 493);
            label5.Name = "label5";
            label5.Size = new Size(68, 15);
            label5.TabIndex = 4;
            label5.Text = "Indkøbspris";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 232);
            label6.Name = "label6";
            label6.Size = new Size(51, 15);
            label6.TabIndex = 5;
            label6.Text = "Kategori";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 121);
            label7.Name = "label7";
            label7.Size = new Size(80, 15);
            label7.TabIndex = 6;
            label7.Text = "Antal på lager";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 424);
            label8.Name = "label8";
            label8.Size = new Size(84, 15);
            label8.TabIndex = 7;
            label8.Text = "Produktbillede";
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(90, 530);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(120, 33);
            buttonSave.TabIndex = 8;
            buttonSave.Text = "Gem Ændringer";
            buttonSave.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(90, 569);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(120, 33);
            buttonCancel.TabIndex = 9;
            buttonCancel.Text = "Fortryd";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // textBoxID
            // 
            textBoxID.Location = new Point(146, 46);
            textBoxID.Name = "textBoxID";
            textBoxID.Size = new Size(149, 23);
            textBoxID.TabIndex = 10;
            // 
            // textBoxProductName
            // 
            textBoxProductName.Location = new Point(146, 84);
            textBoxProductName.Name = "textBoxProductName";
            textBoxProductName.Size = new Size(149, 23);
            textBoxProductName.TabIndex = 11;
            // 
            // textBoxStock
            // 
            textBoxStock.Location = new Point(146, 118);
            textBoxStock.Name = "textBoxStock";
            textBoxStock.Size = new Size(149, 23);
            textBoxStock.TabIndex = 12;
            // 
            // textBoxNormalPrice
            // 
            textBoxNormalPrice.Location = new Point(146, 157);
            textBoxNormalPrice.Name = "textBoxNormalPrice";
            textBoxNormalPrice.Size = new Size(149, 23);
            textBoxNormalPrice.TabIndex = 13;
            // 
            // textBoxSalesPrice
            // 
            textBoxSalesPrice.Location = new Point(146, 196);
            textBoxSalesPrice.Name = "textBoxSalesPrice";
            textBoxSalesPrice.Size = new Size(149, 23);
            textBoxSalesPrice.TabIndex = 14;
            // 
            // textBoxPurchasePrice
            // 
            textBoxPurchasePrice.Location = new Point(146, 490);
            textBoxPurchasePrice.Name = "textBoxPurchasePrice";
            textBoxPurchasePrice.Size = new Size(149, 23);
            textBoxPurchasePrice.TabIndex = 16;
            // 
            // pictureBoxImage
            // 
            pictureBoxImage.Location = new Point(146, 356);
            pictureBoxImage.Name = "pictureBoxImage";
            pictureBoxImage.Size = new Size(149, 99);
            pictureBoxImage.TabIndex = 17;
            pictureBoxImage.TabStop = false;
            // 
            // buttonChoosePicture
            // 
            buttonChoosePicture.Location = new Point(146, 461);
            buttonChoosePicture.Name = "buttonChoosePicture";
            buttonChoosePicture.Size = new Size(64, 23);
            buttonChoosePicture.TabIndex = 18;
            buttonChoosePicture.Text = "Vælg";
            buttonChoosePicture.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(12, 271);
            label9.Name = "label9";
            label9.Size = new Size(44, 15);
            label9.TabIndex = 19;
            label9.Text = "Mærke";
            // 
            // textBoxBrand
            // 
            textBoxBrand.Location = new Point(146, 268);
            textBoxBrand.Name = "textBoxBrand";
            textBoxBrand.Size = new Size(149, 23);
            textBoxBrand.TabIndex = 20;
            // 
            // comboBoxCategory
            // 
            comboBoxCategory.FormattingEnabled = true;
            comboBoxCategory.Location = new Point(146, 229);
            comboBoxCategory.Name = "comboBoxCategory";
            comboBoxCategory.Size = new Size(149, 23);
            comboBoxCategory.TabIndex = 21;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(12, 314);
            label10.Name = "label10";
            label10.Size = new Size(64, 15);
            label10.TabIndex = 22;
            label10.Text = "Beskrivelse";
            // 
            // textBoxDescription
            // 
            textBoxDescription.Location = new Point(146, 311);
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.Size = new Size(149, 23);
            textBoxDescription.TabIndex = 23;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label11.Location = new Point(12, 9);
            label11.Name = "label11";
            label11.Size = new Size(266, 25);
            label11.TabIndex = 24;
            label11.Text = "Rediger Produktoplysninger";
            // 
            // EditProduct
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(307, 614);
            Controls.Add(label11);
            Controls.Add(textBoxDescription);
            Controls.Add(label10);
            Controls.Add(comboBoxCategory);
            Controls.Add(textBoxBrand);
            Controls.Add(label9);
            Controls.Add(buttonChoosePicture);
            Controls.Add(pictureBoxImage);
            Controls.Add(textBoxPurchasePrice);
            Controls.Add(textBoxSalesPrice);
            Controls.Add(textBoxNormalPrice);
            Controls.Add(textBoxStock);
            Controls.Add(textBoxProductName);
            Controls.Add(textBoxID);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "EditProduct";
            Text = "EditProduct";
            ((System.ComponentModel.ISupportInitialize)pictureBoxImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Button buttonSave;
        private Button buttonCancel;
        private TextBox textBoxID;
        private TextBox textBoxProductName;
        private TextBox textBoxStock;
        private TextBox textBoxNormalPrice;
        private TextBox textBoxSalesPrice;
        private TextBox textBoxPurchasePrice;
        private PictureBox pictureBoxImage;
        private Button buttonChoosePicture;
        private Label label9;
        private TextBox textBoxBrand;
        private ComboBox comboBoxCategory;
        private Label label10;
        private TextBox textBoxDescription;
        private Label label11;
    }
}