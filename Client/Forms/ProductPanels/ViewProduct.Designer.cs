using System.ComponentModel;

namespace Client.Forms.ProductPanels {
    partial class ViewProduct {
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
            pictureBoxImage = new PictureBox();
            labelProductName = new Label();
            label1 = new Label();
            labelStock = new Label();
            label2 = new Label();
            label3 = new Label();
            labelPurchasePrice = new Label();
            labelNormalPrice = new Label();
            label4 = new Label();
            labelSalesPrice = new Label();
            label5 = new Label();
            labelID = new Label();
            label6 = new Label();
            labelBrand = new Label();
            label7 = new Label();
            labelCategory = new Label();
            labelDescription = new Label();
            label8 = new Label();
            buttonEditProduct = new Button();
            buttonClose = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxImage).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxImage
            // 
            pictureBoxImage.Location = new Point(464, 12);
            pictureBoxImage.Name = "pictureBoxImage";
            pictureBoxImage.Size = new Size(280, 269);
            pictureBoxImage.TabIndex = 0;
            pictureBoxImage.TabStop = false;
            // 
            // labelProductName
            // 
            labelProductName.AutoSize = true;
            labelProductName.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            labelProductName.Location = new Point(12, 12);
            labelProductName.Name = "labelProductName";
            labelProductName.Size = new Size(221, 32);
            labelProductName.TabIndex = 1;
            labelProductName.Text = "*PRODUCTNAME*";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 196);
            label1.Name = "label1";
            label1.Size = new Size(57, 21);
            label1.TabIndex = 2;
            label1.Text = "Lager:";
            // 
            // labelStock
            // 
            labelStock.AutoSize = true;
            labelStock.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelStock.Location = new Point(88, 196);
            labelStock.Name = "labelStock";
            labelStock.Size = new Size(71, 21);
            labelStock.TabIndex = 3;
            labelStock.Text = "*STOCK*";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(230, 196);
            label2.Name = "label2";
            label2.Size = new Size(103, 21);
            label2.TabIndex = 4;
            label2.Text = "Indkøbspris:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(9, 260);
            label3.Name = "label3";
            label3.Size = new Size(100, 21);
            label3.TabIndex = 5;
            label3.Text = "Normalpris:";
            // 
            // labelPurchasePrice
            // 
            labelPurchasePrice.AutoSize = true;
            labelPurchasePrice.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelPurchasePrice.Location = new Point(349, 196);
            labelPurchasePrice.Name = "labelPurchasePrice";
            labelPurchasePrice.Size = new Size(74, 21);
            labelPurchasePrice.TabIndex = 6;
            labelPurchasePrice.Text = "*PPRICE*";
            // 
            // labelNormalPrice
            // 
            labelNormalPrice.AutoSize = true;
            labelNormalPrice.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelNormalPrice.Location = new Point(123, 260);
            labelNormalPrice.Name = "labelNormalPrice";
            labelNormalPrice.Size = new Size(77, 21);
            labelNormalPrice.TabIndex = 7;
            labelNormalPrice.Text = "*NPRICE*";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(230, 260);
            label4.Name = "label4";
            label4.Size = new Size(82, 21);
            label4.TabIndex = 8;
            label4.Text = "Salgspris:";
            // 
            // labelSalesPrice
            // 
            labelSalesPrice.AutoSize = true;
            labelSalesPrice.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelSalesPrice.Location = new Point(349, 260);
            labelSalesPrice.Name = "labelSalesPrice";
            labelSalesPrice.Size = new Size(74, 21);
            labelSalesPrice.TabIndex = 9;
            labelSalesPrice.Text = "*SPRICE*";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(12, 79);
            label5.Name = "label5";
            label5.Size = new Size(31, 21);
            label5.TabIndex = 10;
            label5.Text = "ID:";
            // 
            // labelID
            // 
            labelID.AutoSize = true;
            labelID.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelID.Location = new Point(62, 79);
            labelID.Name = "labelID";
            labelID.Size = new Size(39, 21);
            labelID.TabIndex = 11;
            labelID.Text = "*ID*";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(12, 135);
            label6.Name = "label6";
            label6.Size = new Size(66, 21);
            label6.TabIndex = 12;
            label6.Text = "Mærke:";
            // 
            // labelBrand
            // 
            labelBrand.AutoSize = true;
            labelBrand.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelBrand.Location = new Point(88, 135);
            labelBrand.Name = "labelBrand";
            labelBrand.Size = new Size(76, 21);
            labelBrand.TabIndex = 13;
            labelBrand.Text = "*BRAND*";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(230, 135);
            label7.Name = "label7";
            label7.Size = new Size(79, 21);
            label7.TabIndex = 14;
            label7.Text = "Kategori:";
            // 
            // labelCategory
            // 
            labelCategory.AutoSize = true;
            labelCategory.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelCategory.Location = new Point(349, 135);
            labelCategory.Name = "labelCategory";
            labelCategory.Size = new Size(101, 21);
            labelCategory.TabIndex = 15;
            labelCategory.Text = "*CATEGORY*";
            // 
            // labelDescription
            // 
            labelDescription.BorderStyle = BorderStyle.FixedSingle;
            labelDescription.Location = new Point(464, 344);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(280, 112);
            labelDescription.TabIndex = 16;
            labelDescription.Text = "*DESCRIPTION*";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(464, 315);
            label8.Name = "label8";
            label8.Size = new Size(74, 15);
            label8.TabIndex = 17;
            label8.Text = "Beskrivelse:";
            // 
            // buttonEditProduct
            // 
            buttonEditProduct.Location = new Point(81, 393);
            buttonEditProduct.Name = "buttonEditProduct";
            buttonEditProduct.Size = new Size(119, 63);
            buttonEditProduct.TabIndex = 18;
            buttonEditProduct.Text = "Rediger Produkt";
            buttonEditProduct.UseVisualStyleBackColor = true;
            // 
            // buttonClose
            // 
            buttonClose.Location = new Point(230, 393);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(119, 63);
            buttonClose.TabIndex = 19;
            buttonClose.Text = "Luk";
            buttonClose.UseVisualStyleBackColor = true;
            // 
            // ViewProduct
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(756, 496);
            Controls.Add(buttonClose);
            Controls.Add(buttonEditProduct);
            Controls.Add(label8);
            Controls.Add(labelDescription);
            Controls.Add(labelCategory);
            Controls.Add(label7);
            Controls.Add(labelBrand);
            Controls.Add(label6);
            Controls.Add(labelID);
            Controls.Add(label5);
            Controls.Add(labelSalesPrice);
            Controls.Add(label4);
            Controls.Add(labelNormalPrice);
            Controls.Add(labelPurchasePrice);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(labelStock);
            Controls.Add(label1);
            Controls.Add(labelProductName);
            Controls.Add(pictureBoxImage);
            Name = "ViewProduct";
            Text = "ViewProduct";
            ((System.ComponentModel.ISupportInitialize)pictureBoxImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBoxImage;
        private Label labelProductName;
        private Label label1;
        private Label labelStock;
        private Label label2;
        private Label label3;
        private Label labelPurchasePrice;
        private Label labelNormalPrice;
        private Label label4;
        private Label labelSalesPrice;
        private Label label5;
        private Label labelID;
        private Label label6;
        private Label labelBrand;
        private Label label7;
        private Label labelCategory;
        private Label labelDescription;
        private Label label8;
        private Button buttonEditProduct;
        private Button buttonClose;
    }
}