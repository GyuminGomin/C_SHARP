namespace WindowsFormCSharp._PCMLabelProdStdForms
{
    partial class PCMLabelProdStdForm_P1
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
            groupBox1 = new GroupBox();
            panel1 = new Panel();
            btn_exit = new Button();
            btn_search = new Button();
            dtp_eDate = new DateTimePicker();
            label2 = new Label();
            dtp_sDate = new DateTimePicker();
            label1 = new Label();
            wv_01 = new Microsoft.Web.WebView2.WinForms.WebView2();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)wv_01).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(panel1);
            groupBox1.Location = new Point(1, 1);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(799, 70);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "[검색조건]";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = SystemColors.ControlDark;
            panel1.Controls.Add(btn_exit);
            panel1.Controls.Add(btn_search);
            panel1.Controls.Add(dtp_eDate);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(dtp_sDate);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(6, 16);
            panel1.Name = "panel1";
            panel1.Size = new Size(787, 47);
            panel1.TabIndex = 0;
            // 
            // btn_exit
            // 
            btn_exit.Font = new Font("맑은 고딕", 12F);
            btn_exit.ForeColor = Color.Black;
            btn_exit.Location = new Point(537, 6);
            btn_exit.Name = "btn_exit";
            btn_exit.Size = new Size(125, 33);
            btn_exit.TabIndex = 20;
            btn_exit.Text = "종료";
            btn_exit.UseVisualStyleBackColor = true;
            btn_exit.Click += btn_exit_Click;
            // 
            // btn_search
            // 
            btn_search.Font = new Font("맑은 고딕", 12F);
            btn_search.ForeColor = Color.Black;
            btn_search.Location = new Point(406, 6);
            btn_search.Name = "btn_search";
            btn_search.Size = new Size(125, 33);
            btn_search.TabIndex = 19;
            btn_search.Text = "조회";
            btn_search.UseVisualStyleBackColor = true;
            btn_search.Click += button2_Click;
            // 
            // dtp_eDate
            // 
            dtp_eDate.Format = DateTimePickerFormat.Custom;
            dtp_eDate.Location = new Point(263, 11);
            dtp_eDate.Name = "dtp_eDate";
            dtp_eDate.Size = new Size(137, 23);
            dtp_eDate.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(242, 15);
            label2.Name = "label2";
            label2.Size = new Size(15, 15);
            label2.TabIndex = 2;
            label2.Text = "~";
            // 
            // dtp_sDate
            // 
            dtp_sDate.Format = DateTimePickerFormat.Custom;
            dtp_sDate.Location = new Point(94, 11);
            dtp_sDate.Name = "dtp_sDate";
            dtp_sDate.Size = new Size(142, 23);
            dtp_sDate.TabIndex = 1;
            // 
            // label1
            // 
            label1.Location = new Point(8, 11);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 0;
            label1.Text = "조회일자";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // wv_01
            // 
            wv_01.AllowExternalDrop = true;
            wv_01.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            wv_01.CreationProperties = null;
            wv_01.DefaultBackgroundColor = Color.White;
            wv_01.Location = new Point(7, 77);
            wv_01.Name = "wv_01";
            wv_01.Size = new Size(787, 370);
            wv_01.Source = new Uri("about:blank", UriKind.Absolute);
            wv_01.TabIndex = 1;
            wv_01.ZoomFactor = 1D;
            // 
            // PCMLabelProdStdForm_P1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(wv_01);
            Controls.Add(groupBox1);
            Name = "PCMLabelProdStdForm_P1";
            Text = "PCMLabelProdStdForm_P1";
            groupBox1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)wv_01).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Panel panel1;
        private DateTimePicker dtp_eDate;
        private Label label2;
        private DateTimePicker dtp_sDate;
        private Label label1;
        private Button btn_exit;
        private Button btn_search;
        private Microsoft.Web.WebView2.WinForms.WebView2 wv_01;
    }
}