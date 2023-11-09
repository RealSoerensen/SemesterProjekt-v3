namespace Client.Forms.CustomerPanels
{
    partial class EditCustomer
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
            tbFirstName = new TextBox();
            tbLastName = new TextBox();
            tbEmail = new TextBox();
            tbPhoneNo = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            saveButton = new Button();
            cancelButton = new Button();
            tbID = new TextBox();
            label5 = new Label();
            label6 = new Label();
            tbDateCreated = new TextBox();
            label7 = new Label();
            tbHouseNumber = new TextBox();
            tbStreet = new TextBox();
            tbCity = new TextBox();
            tbZip = new TextBox();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            SuspendLayout();
            // 
            // tbFirstName
            // 
            tbFirstName.Location = new Point(137, 72);
            tbFirstName.Name = "tbFirstName";
            tbFirstName.Size = new Size(159, 23);
            tbFirstName.TabIndex = 0;
            // 
            // tbLastName
            // 
            tbLastName.Location = new Point(137, 101);
            tbLastName.Name = "tbLastName";
            tbLastName.Size = new Size(159, 23);
            tbLastName.TabIndex = 1;
            // 
            // tbEmail
            // 
            tbEmail.Location = new Point(137, 130);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(159, 23);
            tbEmail.TabIndex = 2;
            // 
            // tbPhoneNo
            // 
            tbPhoneNo.Location = new Point(137, 159);
            tbPhoneNo.Name = "tbPhoneNo";
            tbPhoneNo.Size = new Size(159, 23);
            tbPhoneNo.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 75);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 4;
            label1.Text = "Fornavn";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 104);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 5;
            label2.Text = "Efternavn";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 133);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 6;
            label3.Text = "Email";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 162);
            label4.Name = "label4";
            label4.Size = new Size(72, 15);
            label4.TabIndex = 7;
            label4.Text = "Tlf. nummer";
            // 
            // saveButton
            // 
            saveButton.Location = new Point(86, 409);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(128, 33);
            saveButton.TabIndex = 8;
            saveButton.Text = "Gem ændringer";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(86, 448);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(128, 33);
            cancelButton.TabIndex = 9;
            cancelButton.Text = "Fortryd";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // tbID
            // 
            tbID.Enabled = false;
            tbID.Location = new Point(137, 43);
            tbID.Name = "tbID";
            tbID.Size = new Size(159, 23);
            tbID.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 43);
            label5.Name = "label5";
            label5.Size = new Size(18, 15);
            label5.TabIndex = 11;
            label5.Text = "ID";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 194);
            label6.Name = "label6";
            label6.Size = new Size(77, 15);
            label6.TabIndex = 12;
            label6.Text = "Dato oprettet";
            // 
            // tbDateCreated
            // 
            tbDateCreated.Enabled = false;
            tbDateCreated.Location = new Point(137, 191);
            tbDateCreated.Name = "tbDateCreated";
            tbDateCreated.Size = new Size(159, 23);
            tbDateCreated.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(12, 240);
            label7.Name = "label7";
            label7.Size = new Size(160, 21);
            label7.TabIndex = 14;
            label7.Text = "Adresseoplysninger";
            // 
            // tbHouseNumber
            // 
            tbHouseNumber.Location = new Point(137, 274);
            tbHouseNumber.Name = "tbHouseNumber";
            tbHouseNumber.Size = new Size(159, 23);
            tbHouseNumber.TabIndex = 15;
            // 
            // tbStreet
            // 
            tbStreet.Location = new Point(137, 303);
            tbStreet.Name = "tbStreet";
            tbStreet.Size = new Size(159, 23);
            tbStreet.TabIndex = 16;
            // 
            // tbCity
            // 
            tbCity.Location = new Point(137, 332);
            tbCity.Name = "tbCity";
            tbCity.Size = new Size(159, 23);
            tbCity.TabIndex = 17;
            // 
            // tbZip
            // 
            tbZip.Location = new Point(137, 361);
            tbZip.Name = "tbZip";
            tbZip.Size = new Size(159, 23);
            tbZip.TabIndex = 18;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(13, 306);
            label8.Name = "label8";
            label8.Size = new Size(48, 15);
            label8.TabIndex = 19;
            label8.Text = "Vejnavn";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(12, 277);
            label9.Name = "label9";
            label9.Size = new Size(74, 15);
            label9.TabIndex = 20;
            label9.Text = "Husnummer";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(13, 335);
            label10.Name = "label10";
            label10.Size = new Size(20, 15);
            label10.TabIndex = 21;
            label10.Text = "By";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(13, 364);
            label11.Name = "label11";
            label11.Size = new Size(79, 15);
            label11.TabIndex = 22;
            label11.Text = "Post nummer";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label12.Location = new Point(12, 9);
            label12.Name = "label12";
            label12.Size = new Size(153, 21);
            label12.TabIndex = 23;
            label12.Text = "Personoplysninger";
            // 
            // EditCustomer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(307, 495);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(tbZip);
            Controls.Add(tbCity);
            Controls.Add(tbStreet);
            Controls.Add(tbHouseNumber);
            Controls.Add(label7);
            Controls.Add(tbDateCreated);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(tbID);
            Controls.Add(cancelButton);
            Controls.Add(saveButton);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tbPhoneNo);
            Controls.Add(tbEmail);
            Controls.Add(tbLastName);
            Controls.Add(tbFirstName);
            Name = "EditCustomer";
            Text = "Ændre kundeoplysninger";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbFirstName;
        private TextBox tbLastName;
        private TextBox tbEmail;
        private TextBox tbPhoneNo;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button saveButton;
        private Button cancelButton;
        private TextBox tbID;
        private Label label5;
        private Label label6;
        private TextBox tbDateCreated;
        private Label label7;
        private TextBox tbHouseNumber;
        private TextBox tbStreet;
        private TextBox tbCity;
        private TextBox tbZip;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
    }
}