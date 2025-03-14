namespace WindowsFormCSharp._LoginForms;

partial class LoginForm
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
        tb_Note = new TextBox();
        label1 = new Label();
        label2 = new Label();
        panel1 = new Panel();
        tb_StaffPwd = new TextBox();
        tb_StaffCode = new TextBox();
        tb_Nm = new TextBox();
        tb_TeamNm = new TextBox();
        label8 = new Label();
        label7 = new Label();
        label6 = new Label();
        label5 = new Label();
        tb_PcTime = new TextBox();
        tb_SystemTime = new TextBox();
        label4 = new Label();
        label3 = new Label();
        panel1.SuspendLayout();
        SuspendLayout();
        // 
        // tb_Note
        // 
        tb_Note.Location = new Point(12, 30);
        tb_Note.Name = "tb_Note";
        tb_Note.ReadOnly = true;
        tb_Note.Size = new Size(256, 23);
        tb_Note.TabIndex = 0;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Font = new Font("맑은 고딕", 11F);
        label1.ForeColor = Color.Red;
        label1.Location = new Point(15, 8);
        label1.Name = "label1";
        label1.Size = new Size(50, 20);
        label1.TabIndex = 1;
        label1.Text = "Status";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
        label2.Location = new Point(14, 68);
        label2.Name = "label2";
        label2.Size = new Size(67, 15);
        label2.TabIndex = 2;
        label2.Text = "Date Time";
        // 
        // panel1
        // 
        panel1.BackColor = Color.DarkCyan;
        panel1.Controls.Add(tb_StaffPwd);
        panel1.Controls.Add(tb_StaffCode);
        panel1.Controls.Add(tb_Nm);
        panel1.Controls.Add(tb_TeamNm);
        panel1.Controls.Add(label8);
        panel1.Controls.Add(label7);
        panel1.Controls.Add(label6);
        panel1.Controls.Add(label5);
        panel1.Controls.Add(tb_PcTime);
        panel1.Controls.Add(tb_SystemTime);
        panel1.Controls.Add(label4);
        panel1.Controls.Add(label3);
        panel1.Location = new Point(12, 86);
        panel1.Name = "panel1";
        panel1.Size = new Size(256, 307);
        panel1.TabIndex = 3;
        // 
        // tb_StaffPwd
        // 
        tb_StaffPwd.Location = new Point(86, 253);
        tb_StaffPwd.Name = "tb_StaffPwd";
        tb_StaffPwd.Size = new Size(90, 23);
        tb_StaffPwd.TabIndex = 11;
        tb_StaffPwd.KeyDown += tb_StaffPwd_KeyDown;
        // 
        // tb_StaffCode
        // 
        tb_StaffCode.Location = new Point(86, 229);
        tb_StaffCode.Name = "tb_StaffCode";
        tb_StaffCode.Size = new Size(90, 23);
        tb_StaffCode.TabIndex = 10;
        tb_StaffCode.Leave += tb_StaffCode_Leave;
        // 
        // tb_Nm
        // 
        tb_Nm.Location = new Point(86, 205);
        tb_Nm.Name = "tb_Nm";
        tb_Nm.ReadOnly = true;
        tb_Nm.Size = new Size(90, 23);
        tb_Nm.TabIndex = 9;
        // 
        // tb_TeamNm
        // 
        tb_TeamNm.Location = new Point(86, 181);
        tb_TeamNm.Name = "tb_TeamNm";
        tb_TeamNm.ReadOnly = true;
        tb_TeamNm.Size = new Size(90, 23);
        tb_TeamNm.TabIndex = 8;
        // 
        // label8
        // 
        label8.AutoSize = true;
        label8.BackColor = Color.Silver;
        label8.Font = new Font("맑은 고딕", 11F);
        label8.Location = new Point(8, 253);
        label8.Name = "label8";
        label8.Size = new Size(69, 20);
        label8.TabIndex = 7;
        label8.Text = "비밀번호";
        // 
        // label7
        // 
        label7.AutoSize = true;
        label7.BackColor = Color.Silver;
        label7.Font = new Font("맑은 고딕", 11F);
        label7.Location = new Point(8, 228);
        label7.Name = "label7";
        label7.Size = new Size(69, 20);
        label7.TabIndex = 6;
        label7.Text = "사원번호";
        // 
        // label6
        // 
        label6.AutoSize = true;
        label6.BackColor = Color.Silver;
        label6.Font = new Font("맑은 고딕", 11F);
        label6.Location = new Point(8, 205);
        label6.Name = "label6";
        label6.Size = new Size(69, 20);
        label6.TabIndex = 5;
        label6.Text = "성      명";
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.BackColor = Color.Silver;
        label5.Font = new Font("맑은 고딕", 11F);
        label5.Location = new Point(8, 181);
        label5.Name = "label5";
        label5.Size = new Size(69, 20);
        label5.TabIndex = 4;
        label5.Text = "팀      명";
        // 
        // tb_PcTime
        // 
        tb_PcTime.Location = new Point(89, 48);
        tb_PcTime.Name = "tb_PcTime";
        tb_PcTime.ReadOnly = true;
        tb_PcTime.Size = new Size(160, 23);
        tb_PcTime.TabIndex = 3;
        // 
        // tb_SystemTime
        // 
        tb_SystemTime.Location = new Point(89, 23);
        tb_SystemTime.Name = "tb_SystemTime";
        tb_SystemTime.ReadOnly = true;
        tb_SystemTime.Size = new Size(160, 23);
        tb_SystemTime.TabIndex = 2;
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Font = new Font("맑은 고딕", 13F, FontStyle.Bold);
        label4.ForeColor = Color.Blue;
        label4.Location = new Point(12, 44);
        label4.Name = "label4";
        label4.Size = new Size(34, 25);
        label4.TabIndex = 1;
        label4.Text = "PC";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Font = new Font("맑은 고딕", 13F, FontStyle.Bold);
        label3.ForeColor = Color.Blue;
        label3.Location = new Point(12, 19);
        label3.Name = "label3";
        label3.Size = new Size(80, 25);
        label3.TabIndex = 0;
        label3.Text = "SYSTEM";
        // 
        // LoginForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = SystemColors.ActiveBorder;
        ClientSize = new Size(280, 399);
        Controls.Add(panel1);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(tb_Note);
        KeyPreview = true;
        Name = "LoginForm";
        Text = "SYSTEM LOGIN";
        KeyDown += LoginForm_KeyDown;
        panel1.ResumeLayout(false);
        panel1.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private TextBox tb_Note;
    private Label label1;
    private Label label2;
    private Panel panel1;
    private Label label3;
    private Label label5;
    private TextBox tb_PcTime;
    private TextBox tb_SystemTime;
    private Label label4;
    private Label label8;
    private Label label7;
    private Label label6;
    private TextBox tb_StaffPwd;
    private TextBox tb_StaffCode;
    private TextBox tb_Nm;
    private TextBox tb_TeamNm;
}
