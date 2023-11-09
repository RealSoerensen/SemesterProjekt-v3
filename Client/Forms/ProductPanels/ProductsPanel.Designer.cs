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
            checkBox7 = new CheckBox();
            checkBox8 = new CheckBox();
            checkBox9 = new CheckBox();
            checkBox10 = new CheckBox();
            checkBox11 = new CheckBox();
            checkBox12 = new CheckBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(checkBox12);
            panel1.Controls.Add(checkBox11);
            panel1.Controls.Add(checkBox10);
            panel1.Controls.Add(checkBox9);
            panel1.Controls.Add(checkBox8);
            panel1.Controls.Add(checkBox7);
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(404, 95);
            label2.Name = "label2";
            label2.Size = new Size(47, 25);
            label2.TabIndex = 11;
            label2.Text = "Pris:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
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
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Mest relevante", "Pris (høj-lav)", "Pris (lav-høj)", "Alfabetisk (a-å)", "Alfabetisk (å-a)" });
            comboBox1.Location = new Point(617, 35);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 3;
            comboBox1.Text = "Sortér";
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
            // button1
            // 
            button1.Location = new Point(18, 36);
            button1.Name = "button1";
            button1.Size = new Size(130, 46);
            button1.TabIndex = 0;
            button1.Text = "Opret";
            button1.UseVisualStyleBackColor = true;
            // 
            // checkBox7
            // 
            checkBox7.AutoSize = true;
            checkBox7.Location = new Point(468, 95);
            checkBox7.Name = "checkBox7";
            checkBox7.Size = new Size(55, 19);
            checkBox7.TabIndex = 12;
            checkBox7.Text = "0-150";
            checkBox7.UseVisualStyleBackColor = true;
            // 
            // checkBox8
            // 
            checkBox8.AutoSize = true;
            checkBox8.Location = new Point(468, 120);
            checkBox8.Name = "checkBox8";
            checkBox8.Size = new Size(67, 19);
            checkBox8.TabIndex = 13;
            checkBox8.Text = "150-300";
            checkBox8.UseVisualStyleBackColor = true;
            // 
            // checkBox9
            // 
            checkBox9.AutoSize = true;
            checkBox9.Location = new Point(557, 95);
            checkBox9.Name = "checkBox9";
            checkBox9.Size = new Size(67, 19);
            checkBox9.TabIndex = 14;
            checkBox9.Text = "300-500";
            checkBox9.UseVisualStyleBackColor = true;
            // 
            // checkBox10
            // 
            checkBox10.AutoSize = true;
            checkBox10.Location = new Point(557, 120);
            checkBox10.Name = "checkBox10";
            checkBox10.Size = new Size(73, 19);
            checkBox10.TabIndex = 15;
            checkBox10.Text = "500-1000";
            checkBox10.UseVisualStyleBackColor = true;
            // 
            // checkBox11
            // 
            checkBox11.AutoSize = true;
            checkBox11.Location = new Point(649, 95);
            checkBox11.Name = "checkBox11";
            checkBox11.Size = new Size(79, 19);
            checkBox11.TabIndex = 16;
            checkBox11.Text = "1000-1500";
            checkBox11.UseVisualStyleBackColor = true;
            // 
            // checkBox12
            // 
            checkBox12.AutoSize = true;
            checkBox12.Location = new Point(649, 120);
            checkBox12.Name = "checkBox12";
            checkBox12.Size = new Size(58, 19);
            checkBox12.TabIndex = 17;
            checkBox12.Text = "1500+";
            checkBox12.UseVisualStyleBackColor = true;
            // 
            // ProductsPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(843, 582);
            ControlBox = false;
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ProductsPanel";
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
    }
}