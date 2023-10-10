namespace Client;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        listBox1 = new ListBox();
        refreshBtn = new Button();
        SuspendLayout();
        // 
        // listBox1
        // 
        listBox1.FormattingEnabled = true;
        listBox1.ItemHeight = 15;
        listBox1.Location = new Point(12, 12);
        listBox1.Name = "listBox1";
        listBox1.Size = new Size(220, 334);
        listBox1.TabIndex = 0;
        // 
        // refreshBtn
        // 
        refreshBtn.Location = new Point(12, 352);
        refreshBtn.Name = "refreshBtn";
        refreshBtn.Size = new Size(75, 23);
        refreshBtn.TabIndex = 1;
        refreshBtn.Text = "Refresh";
        refreshBtn.UseVisualStyleBackColor = true;
        refreshBtn.Click += refreshBtn_Click;
        // 
        // Form1
        // 
        ClientSize = new Size(424, 386);
        Controls.Add(refreshBtn);
        Controls.Add(listBox1);
        Name = "Form1";
        ResumeLayout(false);
    }

    #endregion

    private ListBox listBox1;
    private Button refreshBtn;
}