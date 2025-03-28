namespace WindowsFormCSharp._PCMLabel
{
    partial class PCMLabelForm_P1
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
            rtb_02 = new RichTextBox();
            btn_01 = new Button();
            cbm_01 = new ComboBox();
            l_print = new Label();
            SuspendLayout();
            // 
            // rtb_02
            // 
            rtb_02.Location = new Point(7, 65);
            rtb_02.Name = "rtb_02";
            rtb_02.Size = new Size(480, 137);
            rtb_02.TabIndex = 33;
            rtb_02.Text = "";
            // 
            // btn_01
            // 
            btn_01.Location = new Point(250, 39);
            btn_01.Name = "btn_01";
            btn_01.Size = new Size(75, 23);
            btn_01.TabIndex = 32;
            btn_01.Text = "설정";
            btn_01.UseVisualStyleBackColor = true;
            // 
            // cbm_01
            // 
            cbm_01.DropDownStyle = ComboBoxStyle.DropDownList;
            cbm_01.FormattingEnabled = true;
            cbm_01.Location = new Point(7, 39);
            cbm_01.Name = "cbm_01";
            cbm_01.Size = new Size(237, 23);
            cbm_01.TabIndex = 31;
            // 
            // l_print
            // 
            l_print.AutoSize = true;
            l_print.Font = new Font("맑은 고딕", 15F, FontStyle.Bold);
            l_print.Location = new Point(3, 8);
            l_print.Name = "l_print";
            l_print.Size = new Size(146, 28);
            l_print.TabIndex = 30;
            l_print.Text = "▶ 프린트 설정";
            // 
            // PCMLabelForm_P1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(493, 211);
            Controls.Add(rtb_02);
            Controls.Add(btn_01);
            Controls.Add(cbm_01);
            Controls.Add(l_print);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PCMLabelForm_P1";
            Text = "PCMLabelForm_P1";
            FormClosing += PCMLabelForm_P1_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox rtb_02;
        private Button btn_01;
        private ComboBox cbm_01;
        private Label l_print;
    }
}