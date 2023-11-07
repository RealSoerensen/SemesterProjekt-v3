namespace Client {
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
            panel1 = new Panel();
            panel2 = new Panel();
            button1 = new Button();
            buttonEdit = new Button();
            buttonDelete = new Button();
            textBoxSearchbar = new TextBox();
            buttonSearch = new Button();
            labelProductsTxt = new Label();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(comboBox2);
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(labelProductsTxt);
            panel1.Controls.Add(buttonSearch);
            panel1.Controls.Add(textBoxSearchbar);
            panel1.Location = new Point(4, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(757, 98);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(buttonDelete);
            panel2.Controls.Add(buttonEdit);
            panel2.Controls.Add(button1);
            panel2.Location = new Point(594, 106);
            panel2.Name = "panel2";
            panel2.Size = new Size(167, 410);
            panel2.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(18, 36);
            button1.Name = "button1";
            button1.Size = new Size(130, 46);
            button1.TabIndex = 0;
            button1.Text = "Opret";
            button1.UseVisualStyleBackColor = true;
            // 
            // buttonEdit
            // 
            buttonEdit.Location = new Point(18, 117);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(130, 46);
            buttonEdit.TabIndex = 1;
            buttonEdit.Text = "Rediger";
            buttonEdit.UseVisualStyleBackColor = true;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(18, 197);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(130, 46);
            buttonDelete.TabIndex = 2;
            buttonDelete.Text = "Fjern";
            buttonDelete.UseVisualStyleBackColor = true;
            // 
            // textBoxSearchbar
            // 
            textBoxSearchbar.Location = new Point(454, 34);
            textBoxSearchbar.Name = "textBoxSearchbar";
            textBoxSearchbar.Size = new Size(221, 23);
            textBoxSearchbar.TabIndex = 0;
            // 
            // buttonSearch
            // 
            buttonSearch.Location = new Point(677, 34);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(46, 23);
            buttonSearch.TabIndex = 1;
            buttonSearch.Text = "Søg";
            buttonSearch.UseVisualStyleBackColor = true;
            buttonSearch.Click += button4_Click;
            // 
            // labelProductsTxt
            // 
            labelProductsTxt.AutoSize = true;
            labelProductsTxt.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            labelProductsTxt.Location = new Point(3, 20);
            labelProductsTxt.Name = "labelProductsTxt";
            labelProductsTxt.Size = new Size(133, 37);
            labelProductsTxt.TabIndex = 2;
            labelProductsTxt.Text = "Produkter";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(161, 34);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 3;
            comboBox1.Text = "Sortér";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(314, 34);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(121, 23);
            comboBox2.TabIndex = 4;
            comboBox2.Text = "Filtrér";
            // 
            // ProductsMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(765, 528);
            ControlBox = false;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "ProductsMain";
            Text = "Produkter";
            WindowState = FormWindowState.Maximized;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
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
        private ComboBox comboBox2;
        private ComboBox comboBox1;
    }
}