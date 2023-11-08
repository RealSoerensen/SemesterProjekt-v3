﻿namespace Client.Forms.CustomerPanels
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
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // tbFirstName
            // 
            tbFirstName.Location = new Point(136, 41);
            tbFirstName.Name = "tbFirstName";
            tbFirstName.Size = new Size(159, 23);
            tbFirstName.TabIndex = 0;
            // 
            // tbLastName
            // 
            tbLastName.Location = new Point(136, 70);
            tbLastName.Name = "tbLastName";
            tbLastName.Size = new Size(159, 23);
            tbLastName.TabIndex = 1;
            // 
            // tbEmail
            // 
            tbEmail.Location = new Point(136, 99);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(159, 23);
            tbEmail.TabIndex = 2;
            // 
            // tbPhoneNo
            // 
            tbPhoneNo.Location = new Point(136, 128);
            tbPhoneNo.Name = "tbPhoneNo";
            tbPhoneNo.Size = new Size(159, 23);
            tbPhoneNo.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 44);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 4;
            label1.Text = "Fornavn";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 73);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 5;
            label2.Text = "Efternavn";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 102);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 6;
            label3.Text = "Email";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 131);
            label4.Name = "label4";
            label4.Size = new Size(72, 15);
            label4.TabIndex = 7;
            label4.Text = "Tlf. nummer";
            // 
            // saveButton
            // 
            saveButton.Location = new Point(89, 197);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(128, 33);
            saveButton.TabIndex = 8;
            saveButton.Text = "Gem ændringer";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // closeButton
            // 
            cancelButton.Location = new Point(89, 236);
            cancelButton.Name = "closeButton";
            cancelButton.Size = new Size(128, 33);
            cancelButton.TabIndex = 9;
            cancelButton.Text = "Fortryd";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // tbID
            // 
            tbID.Enabled = false;
            tbID.Location = new Point(136, 12);
            tbID.Name = "tbID";
            tbID.Size = new Size(159, 23);
            tbID.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 15);
            label5.Name = "label5";
            label5.Size = new Size(18, 15);
            label5.TabIndex = 11;
            label5.Text = "ID";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 160);
            label6.Name = "label6";
            label6.Size = new Size(77, 15);
            label6.TabIndex = 12;
            label6.Text = "Dato oprettet";
            // 
            // textBox1
            // 
            textBox1.Enabled = false;
            textBox1.Location = new Point(136, 160);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(159, 23);
            textBox1.TabIndex = 13;
            // 
            // EditCustomer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(307, 276);
            Controls.Add(textBox1);
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
        private TextBox textBox1;
    }
}