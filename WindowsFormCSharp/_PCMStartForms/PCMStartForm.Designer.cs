namespace WindowsFormCSharp._PCMStartForms
{
    partial class PCMStartForm
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
            l_print = new Label();
            cbm_01 = new ComboBox();
            btn_01 = new Button();
            rtb_02 = new RichTextBox();
            btn_coupang = new Button();
            btn_iced = new Button();
            btn_school = new Button();
            btn_emart = new Button();
            btn_refrigeration = new Button();
            btn_bowl = new Button();
            l_label = new Label();
            pb_logo = new PictureBox();
            lb_title = new Label();
            ((System.ComponentModel.ISupportInitialize)pb_logo).BeginInit();
            SuspendLayout();
            // 
            // l_print
            // 
            l_print.AutoSize = true;
            l_print.Font = new Font("맑은 고딕", 15F, FontStyle.Bold);
            l_print.Location = new Point(8, 373);
            l_print.Name = "l_print";
            l_print.Size = new Size(146, 28);
            l_print.TabIndex = 9;
            l_print.Text = "▶ 프린트 설정";
            // 
            // cbm_01
            // 
            cbm_01.DropDownStyle = ComboBoxStyle.DropDownList;
            cbm_01.FormattingEnabled = true;
            cbm_01.Location = new Point(12, 404);
            cbm_01.Name = "cbm_01";
            cbm_01.Size = new Size(237, 23);
            cbm_01.TabIndex = 24;
            // 
            // btn_01
            // 
            btn_01.Location = new Point(255, 404);
            btn_01.Name = "btn_01";
            btn_01.Size = new Size(75, 23);
            btn_01.TabIndex = 28;
            btn_01.Text = "설정";
            btn_01.UseVisualStyleBackColor = true;
            // 
            // rtb_02
            // 
            rtb_02.Location = new Point(12, 430);
            rtb_02.Name = "rtb_02";
            rtb_02.Size = new Size(480, 137);
            rtb_02.TabIndex = 29;
            rtb_02.Text = "";
            // 
            // btn_coupang
            // 
            btn_coupang.BackColor = Color.Olive;
            btn_coupang.Cursor = Cursors.Hand;
            btn_coupang.Font = new Font("문체부 돋음체", 12F, FontStyle.Bold);
            btn_coupang.ForeColor = Color.White;
            btn_coupang.Location = new Point(255, 295);
            btn_coupang.Name = "btn_coupang";
            btn_coupang.Size = new Size(237, 80);
            btn_coupang.TabIndex = 36;
            btn_coupang.Text = "쿠팡 라벨발행 (생산출고)";
            btn_coupang.UseVisualStyleBackColor = false;
            // 
            // btn_iced
            // 
            btn_iced.BackColor = Color.DarkBlue;
            btn_iced.Cursor = Cursors.Hand;
            btn_iced.Font = new Font("문체부 돋음체", 11F, FontStyle.Bold);
            btn_iced.ForeColor = Color.White;
            btn_iced.Location = new Point(12, 295);
            btn_iced.Name = "btn_iced";
            btn_iced.Size = new Size(237, 80);
            btn_iced.TabIndex = 35;
            btn_iced.Text = "일반냉동 라벨발행 (재고생산)";
            btn_iced.UseVisualStyleBackColor = false;
            // 
            // btn_school
            // 
            btn_school.BackColor = Color.DarkRed;
            btn_school.Cursor = Cursors.Hand;
            btn_school.Font = new Font("문체부 돋음체", 11F, FontStyle.Bold);
            btn_school.ForeColor = Color.White;
            btn_school.Location = new Point(255, 213);
            btn_school.Name = "btn_school";
            btn_school.Size = new Size(237, 80);
            btn_school.TabIndex = 34;
            btn_school.Text = "학교급식 라벨발행 (생산출고)";
            btn_school.UseVisualStyleBackColor = false;
            // 
            // btn_emart
            // 
            btn_emart.BackColor = Color.Purple;
            btn_emart.Cursor = Cursors.Hand;
            btn_emart.Font = new Font("문체부 돋음체", 12F, FontStyle.Bold);
            btn_emart.ForeColor = Color.White;
            btn_emart.Location = new Point(12, 213);
            btn_emart.Name = "btn_emart";
            btn_emart.Size = new Size(237, 80);
            btn_emart.TabIndex = 33;
            btn_emart.Text = "EMART 라벨발행 (생산출고)";
            btn_emart.UseVisualStyleBackColor = false;
            // 
            // btn_refrigeration
            // 
            btn_refrigeration.BackColor = Color.Green;
            btn_refrigeration.Cursor = Cursors.Hand;
            btn_refrigeration.Font = new Font("문체부 돋음체", 11F, FontStyle.Bold);
            btn_refrigeration.ForeColor = Color.White;
            btn_refrigeration.Location = new Point(255, 131);
            btn_refrigeration.Name = "btn_refrigeration";
            btn_refrigeration.Size = new Size(237, 80);
            btn_refrigeration.TabIndex = 32;
            btn_refrigeration.Text = "일반냉장 라벨발행 (생산출고)";
            btn_refrigeration.UseVisualStyleBackColor = false;
            // 
            // btn_bowl
            // 
            btn_bowl.BackColor = Color.Gray;
            btn_bowl.Cursor = Cursors.Hand;
            btn_bowl.Font = new Font("문체부 돋음체", 14F, FontStyle.Bold);
            btn_bowl.ForeColor = Color.White;
            btn_bowl.Location = new Point(12, 131);
            btn_bowl.Name = "btn_bowl";
            btn_bowl.Size = new Size(237, 80);
            btn_bowl.TabIndex = 31;
            btn_bowl.Text = "용기 라벨 발행";
            btn_bowl.UseVisualStyleBackColor = false;
            btn_bowl.Click += btn_bowl_Click;
            // 
            // l_label
            // 
            l_label.AutoSize = true;
            l_label.Font = new Font("맑은 고딕", 15F, FontStyle.Bold);
            l_label.Location = new Point(9, 103);
            l_label.Name = "l_label";
            l_label.Size = new Size(126, 28);
            l_label.TabIndex = 30;
            l_label.Text = "▶ 라벨 발행";
            // 
            // pb_logo
            // 
            pb_logo.BackgroundImageLayout = ImageLayout.None;
            pb_logo.Location = new Point(12, 12);
            pb_logo.Name = "pb_logo";
            pb_logo.Size = new Size(227, 31);
            pb_logo.SizeMode = PictureBoxSizeMode.CenterImage;
            pb_logo.TabIndex = 38;
            pb_logo.TabStop = false;
            // 
            // lb_title
            // 
            lb_title.AutoSize = true;
            lb_title.BackColor = Color.White;
            lb_title.BorderStyle = BorderStyle.Fixed3D;
            lb_title.Font = new Font("문체부 돋음체", 30F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lb_title.Location = new Point(38, 54);
            lb_title.Name = "lb_title";
            lb_title.Size = new Size(428, 42);
            lb_title.TabIndex = 39;
            lb_title.Text = "PCM 라벨 발행 시스템";
            // 
            // PCMStartForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(504, 579);
            Controls.Add(lb_title);
            Controls.Add(pb_logo);
            Controls.Add(btn_coupang);
            Controls.Add(btn_iced);
            Controls.Add(btn_school);
            Controls.Add(btn_emart);
            Controls.Add(btn_refrigeration);
            Controls.Add(btn_bowl);
            Controls.Add(l_label);
            Controls.Add(rtb_02);
            Controls.Add(btn_01);
            Controls.Add(cbm_01);
            Controls.Add(l_print);
            KeyPreview = true;
            Name = "PCMStartForm";
            Text = "PCMStartForm";
            KeyDown += PCMStartForm_KeyDown;
            ((System.ComponentModel.ISupportInitialize)pb_logo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label l_print;
        private ComboBox cbm_01;
        private Button btn_01;
        private RichTextBox rtb_02;
        private Button btn_coupang;
        private Button btn_iced;
        private Button btn_school;
        private Button btn_emart;
        private Button btn_refrigeration;
        private Button btn_bowl;
        private Label l_label;
        private PictureBox pb_logo;
        private Label lb_title;
    }
}