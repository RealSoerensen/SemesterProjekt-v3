namespace Client {
    partial class Main {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            panelMenu = new Panel();
            buttonOrders = new Button();
            buttonCustomers = new Button();
            buttonProducts = new Button();
            panelPicture = new Panel();
            panelMain = new Panel();
            panelMenu.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BorderStyle = BorderStyle.FixedSingle;
            panelMenu.Controls.Add(buttonOrders);
            panelMenu.Controls.Add(buttonCustomers);
            panelMenu.Controls.Add(buttonProducts);
            panelMenu.Controls.Add(panelPicture);
            panelMenu.ForeColor = SystemColors.ActiveCaptionText;
            panelMenu.Location = new Point(12, 12);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(200, 581);
            panelMenu.TabIndex = 0;
            // 
            // buttonOrders
            // 
            buttonOrders.Location = new Point(16, 331);
            buttonOrders.Name = "buttonOrders";
            buttonOrders.Size = new Size(169, 50);
            buttonOrders.TabIndex = 3;
            buttonOrders.Text = "Ordre";
            buttonOrders.UseVisualStyleBackColor = true;
            // 
            // buttonCustomers
            // 
            buttonCustomers.Location = new Point(16, 237);
            buttonCustomers.Name = "buttonCustomers";
            buttonCustomers.Size = new Size(169, 50);
            buttonCustomers.TabIndex = 2;
            buttonCustomers.Text = "Kunder";
            buttonCustomers.UseVisualStyleBackColor = true;
            buttonCustomers.Click += buttonCustomers_Click;
            // 
            // buttonProducts
            // 
            buttonProducts.Location = new Point(16, 151);
            buttonProducts.Name = "buttonProducts";
            buttonProducts.Size = new Size(169, 50);
            buttonProducts.TabIndex = 1;
            buttonProducts.Text = "Produkter";
            buttonProducts.UseVisualStyleBackColor = true;
            buttonProducts.Click += buttonProducts_Click;
            // 
            // panelPicture
            // 
            panelPicture.BorderStyle = BorderStyle.FixedSingle;
            panelPicture.Location = new Point(-1, -1);
            panelPicture.Name = "panelPicture";
            panelPicture.Size = new Size(200, 121);
            panelPicture.TabIndex = 0;
            // 
            // panelMain
            // 
            panelMain.Location = new Point(218, 12);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(784, 581);
            panelMain.TabIndex = 1;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1013, 605);
            Controls.Add(panelMain);
            Controls.Add(panelMenu);
            Name = "Main";
            Text = "Form1";
            panelMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMenu;
        private Panel panelPicture;
        private Button buttonCustomers;
        private Button buttonProducts;
        private Button buttonOrders;
        private Panel panelMain;
    }
}