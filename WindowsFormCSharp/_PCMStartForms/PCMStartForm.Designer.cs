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
            components = new System.ComponentModel.Container();
            flp = new FlowLayoutPanel();
            richTextBox1 = new RichTextBox();
            comboBox1 = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            images = new ImageList(components);
            flp.SuspendLayout();
            SuspendLayout();
            // 
            // flp
            // 
            flp.Controls.Add(richTextBox1);
            flp.Location = new Point(12, 12);
            flp.Name = "flp";
            flp.Size = new Size(480, 86);
            flp.TabIndex = 6;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = SystemColors.WindowText;
            richTextBox1.Font = new Font("맑은 고딕", 34F, FontStyle.Regular, GraphicsUnit.Point, 129);
            richTextBox1.ForeColor = Color.AliceBlue;
            richTextBox1.Location = new Point(3, 3);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(477, 86);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "PCM 라벨 발행 시스템";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(14, 136);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(477, 23);
            comboBox1.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("맑은 고딕", 15F);
            label1.Location = new Point(7, 103);
            label1.Name = "label1";
            label1.Size = new Size(126, 28);
            label1.TabIndex = 8;
            label1.Text = "▶ 라벨 발행";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("맑은 고딕", 15F);
            label2.Location = new Point(7, 163);
            label2.Name = "label2";
            label2.Size = new Size(146, 28);
            label2.TabIndex = 9;
            label2.Text = "▶ 프린트 설정";
            // 
            // images
            // 
            images.ColorDepth = ColorDepth.Depth32Bit;
            images.ImageSize = new Size(16, 16);
            images.TransparentColor = Color.Transparent;
            // 
            // PCMStartForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(504, 579);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(flp);
            Name = "PCMStartForm";
            Text = "PCMStartForm";
            flp.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private FlowLayoutPanel flp;
        private RichTextBox richTextBox1;
        private ComboBox comboBox1;
        private Label label1;
        private Label label2;
        private ImageList images;
    }
}