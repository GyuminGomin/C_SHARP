namespace WindowsFormCSharp._PCMLabel
{
    partial class PCMLabelForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PCMLabelForm));
            btn_kindCd2 = new Button();
            btn_kindCd1 = new Button();
            dgv_item = new DataGridView();
            groupBox1 = new GroupBox();
            groupBox8 = new GroupBox();
            dgv_traceInfo = new DataGridView();
            panel1 = new Panel();
            mtb_traceNo = new MaskedTextBox();
            label1 = new Label();
            btn_frzDiv2 = new Button();
            panel2 = new Panel();
            btn_print = new Button();
            mtb_printCnt = new MaskedTextBox();
            label7 = new Label();
            mtb_weight = new MaskedTextBox();
            label6 = new Label();
            mtb_count = new MaskedTextBox();
            label5 = new Label();
            mtb_boxWt = new MaskedTextBox();
            label4 = new Label();
            mtb_itemCd = new MaskedTextBox();
            label3 = new Label();
            dtp_workDate = new DateTimePicker();
            label2 = new Label();
            groupBox2 = new GroupBox();
            dtp_orderDate = new DateTimePicker();
            groupBox4 = new GroupBox();
            groupBox5 = new GroupBox();
            btn_popupPrint = new Button();
            btn_exit = new Button();
            tb_status = new TextBox();
            groupBox7 = new GroupBox();
            ppd_printView = new PrintPreviewDialog();
            pd_printDocument = new System.Drawing.Printing.PrintDocument();
            label10 = new Label();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            groupBox6 = new GroupBox();
            dataGridView2 = new DataGridView();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            dgv_subItem = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgv_item).BeginInit();
            groupBox1.SuspendLayout();
            groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_traceInfo).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_subItem).BeginInit();
            SuspendLayout();
            // 
            // btn_kindCd2
            // 
            btn_kindCd2.BackColor = Color.Gray;
            btn_kindCd2.Font = new Font("맑은 고딕", 15F, FontStyle.Bold);
            btn_kindCd2.ForeColor = SystemColors.ControlText;
            btn_kindCd2.Location = new Point(10, 17);
            btn_kindCd2.Name = "btn_kindCd2";
            btn_kindCd2.Size = new Size(100, 55);
            btn_kindCd2.TabIndex = 0;
            btn_kindCd2.Text = "돈육";
            btn_kindCd2.TextAlign = ContentAlignment.TopCenter;
            btn_kindCd2.UseVisualStyleBackColor = true;
            btn_kindCd2.Click += btn_kindCd2_Click;
            // 
            // btn_kindCd1
            // 
            btn_kindCd1.Enabled = false;
            btn_kindCd1.Font = new Font("맑은 고딕", 15F, FontStyle.Bold);
            btn_kindCd1.ForeColor = Color.Black;
            btn_kindCd1.Location = new Point(117, 17);
            btn_kindCd1.Name = "btn_kindCd1";
            btn_kindCd1.Size = new Size(100, 55);
            btn_kindCd1.TabIndex = 1;
            btn_kindCd1.Text = "한우";
            btn_kindCd1.TextAlign = ContentAlignment.TopCenter;
            btn_kindCd1.UseVisualStyleBackColor = true;
            btn_kindCd1.Click += btn_kindCd1_Click;
            // 
            // dgv_item
            // 
            dgv_item.BorderStyle = BorderStyle.Fixed3D;
            dgv_item.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_item.Location = new Point(6, 77);
            dgv_item.Name = "dgv_item";
            dgv_item.Size = new Size(542, 224);
            dgv_item.TabIndex = 4;
            dgv_item.CellClick += dgv_item_CellClick;
            dgv_item.CellDoubleClick += dgv_item_CellDoubleClick;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.None;
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(dgv_item);
            groupBox1.Controls.Add(btn_kindCd1);
            groupBox1.Controls.Add(btn_kindCd2);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(5, 1);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(554, 309);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "MAIN";
            // 
            // groupBox8
            // 
            groupBox8.Anchor = AnchorStyles.None;
            groupBox8.Controls.Add(dgv_traceInfo);
            groupBox8.ForeColor = Color.White;
            groupBox8.Location = new Point(285, 313);
            groupBox8.Name = "groupBox8";
            groupBox8.Size = new Size(274, 104);
            groupBox8.TabIndex = 19;
            groupBox8.TabStop = false;
            groupBox8.Text = "재고정보";
            // 
            // dgv_traceInfo
            // 
            dgv_traceInfo.BorderStyle = BorderStyle.Fixed3D;
            dgv_traceInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_traceInfo.ColumnHeadersVisible = false;
            dgv_traceInfo.Location = new Point(6, 20);
            dgv_traceInfo.Name = "dgv_traceInfo";
            dgv_traceInfo.Size = new Size(262, 76);
            dgv_traceInfo.TabIndex = 5;
            dgv_traceInfo.CellClick += dgv_traceInfo_CellClick;
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkGray;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(mtb_traceNo);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btn_frzDiv2);
            panel1.Location = new Point(6, 20);
            panel1.Name = "panel1";
            panel1.Size = new Size(261, 82);
            panel1.TabIndex = 1;
            // 
            // mtb_traceNo
            // 
            mtb_traceNo.Location = new Point(88, 51);
            mtb_traceNo.Name = "mtb_traceNo";
            mtb_traceNo.Size = new Size(160, 23);
            mtb_traceNo.TabIndex = 4;
            mtb_traceNo.TextAlign = HorizontalAlignment.Center;
            mtb_traceNo.Click += mtb_selectAll;
            mtb_traceNo.Enter += mtb_selectAll;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Turquoise;
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.ForeColor = Color.Black;
            label1.Location = new Point(3, 54);
            label1.Name = "label1";
            label1.Size = new Size(81, 17);
            label1.TabIndex = 3;
            label1.Text = "생산이력번호";
            // 
            // btn_frzDiv2
            // 
            btn_frzDiv2.Font = new Font("맑은 고딕", 12F);
            btn_frzDiv2.ForeColor = Color.Black;
            btn_frzDiv2.Location = new Point(134, 5);
            btn_frzDiv2.Name = "btn_frzDiv2";
            btn_frzDiv2.Size = new Size(100, 40);
            btn_frzDiv2.TabIndex = 2;
            btn_frzDiv2.Text = "냉장";
            btn_frzDiv2.UseVisualStyleBackColor = true;
            btn_frzDiv2.Click += btn_frzDiv2_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.DarkGray;
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.Controls.Add(btn_print);
            panel2.Controls.Add(mtb_printCnt);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(mtb_weight);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(mtb_count);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(mtb_boxWt);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(mtb_itemCd);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(dtp_workDate);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(6, 110);
            panel2.Name = "panel2";
            panel2.Size = new Size(261, 232);
            panel2.TabIndex = 2;
            // 
            // btn_print
            // 
            btn_print.BackColor = Color.Red;
            btn_print.Font = new Font("맑은 고딕", 15F, FontStyle.Bold);
            btn_print.ForeColor = Color.White;
            btn_print.Location = new Point(142, 157);
            btn_print.Name = "btn_print";
            btn_print.Size = new Size(106, 67);
            btn_print.TabIndex = 16;
            btn_print.Text = "라벨\r\n발행";
            btn_print.UseVisualStyleBackColor = false;
            btn_print.Click += btn_print_Click;
            // 
            // mtb_printCnt
            // 
            mtb_printCnt.Location = new Point(69, 159);
            mtb_printCnt.Name = "mtb_printCnt";
            mtb_printCnt.Size = new Size(67, 23);
            mtb_printCnt.TabIndex = 15;
            mtb_printCnt.TextAlign = HorizontalAlignment.Right;
            mtb_printCnt.ValidatingType = typeof(int);
            mtb_printCnt.Click += mtb_selectAll;
            mtb_printCnt.Enter += mtb_selectAll;
            // 
            // label7
            // 
            label7.BackColor = Color.Turquoise;
            label7.BorderStyle = BorderStyle.Fixed3D;
            label7.ForeColor = Color.Black;
            label7.Location = new Point(5, 162);
            label7.Name = "label7";
            label7.Size = new Size(57, 17);
            label7.TabIndex = 14;
            label7.Text = "발행수량";
            // 
            // mtb_weight
            // 
            mtb_weight.Location = new Point(69, 130);
            mtb_weight.Name = "mtb_weight";
            mtb_weight.ReadOnly = true;
            mtb_weight.Size = new Size(179, 23);
            mtb_weight.TabIndex = 13;
            mtb_weight.TextAlign = HorizontalAlignment.Right;
            // 
            // label6
            // 
            label6.BackColor = Color.Turquoise;
            label6.BorderStyle = BorderStyle.Fixed3D;
            label6.ForeColor = Color.Black;
            label6.Location = new Point(5, 133);
            label6.Name = "label6";
            label6.Size = new Size(57, 17);
            label6.TabIndex = 12;
            label6.Text = "중량[Kg]";
            // 
            // mtb_count
            // 
            mtb_count.InsertKeyMode = InsertKeyMode.Insert;
            mtb_count.Location = new Point(69, 101);
            mtb_count.Name = "mtb_count";
            mtb_count.PromptChar = ' ';
            mtb_count.ReadOnly = true;
            mtb_count.RejectInputOnFirstFailure = true;
            mtb_count.Size = new Size(179, 23);
            mtb_count.TabIndex = 11;
            mtb_count.TextAlign = HorizontalAlignment.Right;
            // 
            // label5
            // 
            label5.BackColor = Color.Turquoise;
            label5.BorderStyle = BorderStyle.Fixed3D;
            label5.ForeColor = Color.Black;
            label5.Location = new Point(5, 104);
            label5.Name = "label5";
            label5.Size = new Size(57, 17);
            label5.TabIndex = 10;
            label5.Text = "수량[Ea]";
            // 
            // mtb_boxWt
            // 
            mtb_boxWt.Location = new Point(69, 72);
            mtb_boxWt.Name = "mtb_boxWt";
            mtb_boxWt.ReadOnly = true;
            mtb_boxWt.Size = new Size(179, 23);
            mtb_boxWt.TabIndex = 9;
            mtb_boxWt.TextAlign = HorizontalAlignment.Right;
            // 
            // label4
            // 
            label4.BackColor = Color.Turquoise;
            label4.BorderStyle = BorderStyle.Fixed3D;
            label4.ForeColor = Color.Black;
            label4.Location = new Point(5, 75);
            label4.Name = "label4";
            label4.Size = new Size(57, 17);
            label4.TabIndex = 8;
            label4.Text = "기준중량";
            // 
            // mtb_itemCd
            // 
            mtb_itemCd.Location = new Point(69, 43);
            mtb_itemCd.Name = "mtb_itemCd";
            mtb_itemCd.Size = new Size(179, 23);
            mtb_itemCd.TabIndex = 7;
            mtb_itemCd.TextAlign = HorizontalAlignment.Center;
            // 
            // label3
            // 
            label3.BackColor = Color.Turquoise;
            label3.BorderStyle = BorderStyle.Fixed3D;
            label3.ForeColor = Color.Black;
            label3.Location = new Point(5, 46);
            label3.Name = "label3";
            label3.Size = new Size(57, 17);
            label3.TabIndex = 6;
            label3.Text = "제품번호";
            // 
            // dtp_workDate
            // 
            dtp_workDate.CustomFormat = "yyyy-MM-dd";
            dtp_workDate.DropDownAlign = LeftRightAlignment.Right;
            dtp_workDate.Format = DateTimePickerFormat.Custom;
            dtp_workDate.Location = new Point(69, 14);
            dtp_workDate.Name = "dtp_workDate";
            dtp_workDate.Size = new Size(179, 23);
            dtp_workDate.TabIndex = 5;
            dtp_workDate.Value = new DateTime(2025, 3, 25, 0, 0, 0, 0);
            dtp_workDate.ValueChanged += dtp_workDate_ValueChanged;
            // 
            // label2
            // 
            label2.BackColor = Color.Turquoise;
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.ForeColor = Color.Black;
            label2.Location = new Point(5, 17);
            label2.Name = "label2";
            label2.Size = new Size(57, 17);
            label2.TabIndex = 4;
            label2.Text = "작업일자";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.None;
            groupBox2.Controls.Add(panel2);
            groupBox2.Controls.Add(panel1);
            groupBox2.ForeColor = Color.White;
            groupBox2.Location = new Point(6, 313);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(273, 351);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "박스정보";
            // 
            // dtp_orderDate
            // 
            dtp_orderDate.CustomFormat = "yyyy-MM-dd";
            dtp_orderDate.Format = DateTimePickerFormat.Custom;
            dtp_orderDate.Location = new Point(53, 27);
            dtp_orderDate.Name = "dtp_orderDate";
            dtp_orderDate.Size = new Size(160, 23);
            dtp_orderDate.TabIndex = 7;
            dtp_orderDate.ValueChanged += dtp_orderDate_ValueChanged;
            // 
            // groupBox4
            // 
            groupBox4.Anchor = AnchorStyles.None;
            groupBox4.Controls.Add(dtp_orderDate);
            groupBox4.ForeColor = Color.White;
            groupBox4.Location = new Point(285, 423);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(274, 74);
            groupBox4.TabIndex = 4;
            groupBox4.TabStop = false;
            groupBox4.Text = "주문일자";
            // 
            // groupBox5
            // 
            groupBox5.Anchor = AnchorStyles.None;
            groupBox5.Controls.Add(dataGridView1);
            groupBox5.ForeColor = Color.White;
            groupBox5.Location = new Point(285, 500);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(274, 308);
            groupBox5.TabIndex = 5;
            groupBox5.TabStop = false;
            groupBox5.Text = "일반발주 주문리스트";
            // 
            // btn_popupPrint
            // 
            btn_popupPrint.Font = new Font("맑은 고딕", 12F);
            btn_popupPrint.ForeColor = Color.Black;
            btn_popupPrint.Location = new Point(16, 20);
            btn_popupPrint.Name = "btn_popupPrint";
            btn_popupPrint.Size = new Size(100, 40);
            btn_popupPrint.TabIndex = 0;
            btn_popupPrint.Text = "프린터설정";
            btn_popupPrint.UseVisualStyleBackColor = true;
            btn_popupPrint.Click += btn_popupPrint_Click;
            // 
            // btn_exit
            // 
            btn_exit.Font = new Font("맑은 고딕", 12F);
            btn_exit.ForeColor = Color.Black;
            btn_exit.Location = new Point(16, 66);
            btn_exit.Name = "btn_exit";
            btn_exit.Size = new Size(240, 40);
            btn_exit.TabIndex = 1;
            btn_exit.Text = "종료";
            btn_exit.UseVisualStyleBackColor = true;
            btn_exit.Click += btn_exit_Click;
            // 
            // tb_status
            // 
            tb_status.BackColor = Color.Yellow;
            tb_status.BorderStyle = BorderStyle.FixedSingle;
            tb_status.Location = new Point(10, 112);
            tb_status.Name = "tb_status";
            tb_status.Size = new Size(257, 23);
            tb_status.TabIndex = 2;
            // 
            // groupBox7
            // 
            groupBox7.Anchor = AnchorStyles.None;
            groupBox7.Controls.Add(button1);
            groupBox7.Controls.Add(tb_status);
            groupBox7.Controls.Add(btn_exit);
            groupBox7.Controls.Add(btn_popupPrint);
            groupBox7.ForeColor = Color.White;
            groupBox7.Location = new Point(6, 662);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(274, 146);
            groupBox7.TabIndex = 18;
            groupBox7.TabStop = false;
            groupBox7.Text = "기타정보";
            // 
            // ppd_printView
            // 
            ppd_printView.AutoScrollMargin = new Size(0, 0);
            ppd_printView.AutoScrollMinSize = new Size(0, 0);
            ppd_printView.ClientSize = new Size(400, 300);
            ppd_printView.Enabled = true;
            ppd_printView.Icon = (Icon)resources.GetObject("ppd_printView.Icon");
            ppd_printView.Name = "ppd_printView";
            ppd_printView.Visible = false;
            // 
            // pd_printDocument
            // 
            pd_printDocument.PrintPage += pd_printDocument_PrintPage;
            // 
            // label10
            // 
            label10.BorderStyle = BorderStyle.Fixed3D;
            label10.Font = new Font("맑은 고딕", 21F);
            label10.ForeColor = Color.White;
            label10.Location = new Point(290, 20);
            label10.Name = "label10";
            label10.Size = new Size(258, 45);
            label10.TabIndex = 5;
            label10.Text = "일반냉장발주 라벨";
            label10.TextAlign = ContentAlignment.TopCenter;
            // 
            // button1
            // 
            button1.Font = new Font("맑은 고딕", 12F);
            button1.ForeColor = Color.Black;
            button1.Location = new Point(157, 20);
            button1.Name = "button1";
            button1.Size = new Size(100, 40);
            button1.TabIndex = 3;
            button1.Text = "통 계";
            button1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.BorderStyle = BorderStyle.Fixed3D;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.Location = new Point(6, 17);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(262, 280);
            dataGridView1.TabIndex = 17;
            // 
            // groupBox6
            // 
            groupBox6.Anchor = AnchorStyles.None;
            groupBox6.Controls.Add(button4);
            groupBox6.Controls.Add(button3);
            groupBox6.Controls.Add(button2);
            groupBox6.Controls.Add(dataGridView2);
            groupBox6.ForeColor = Color.White;
            groupBox6.Location = new Point(569, 500);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(600, 308);
            groupBox6.TabIndex = 20;
            groupBox6.TabStop = false;
            groupBox6.Text = "생산정보";
            // 
            // dataGridView2
            // 
            dataGridView2.BorderStyle = BorderStyle.Fixed3D;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.ColumnHeadersVisible = false;
            dataGridView2.Location = new Point(6, 58);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(588, 239);
            dataGridView2.TabIndex = 17;
            // 
            // button2
            // 
            button2.Font = new Font("맑은 고딕", 12F);
            button2.ForeColor = Color.Black;
            button2.Location = new Point(6, 17);
            button2.Name = "button2";
            button2.Size = new Size(125, 33);
            button2.TabIndex = 18;
            button2.Text = "조회";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Font = new Font("맑은 고딕", 12F);
            button3.ForeColor = Color.Black;
            button3.Location = new Point(137, 17);
            button3.Name = "button3";
            button3.Size = new Size(125, 33);
            button3.TabIndex = 19;
            button3.Text = "저장";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Font = new Font("맑은 고딕", 12F);
            button4.ForeColor = Color.Black;
            button4.Location = new Point(268, 17);
            button4.Name = "button4";
            button4.Size = new Size(125, 33);
            button4.TabIndex = 20;
            button4.Text = "삭제";
            button4.UseVisualStyleBackColor = true;
            // 
            // dgv_subItem
            // 
            dgv_subItem.Anchor = AnchorStyles.None;
            dgv_subItem.BorderStyle = BorderStyle.Fixed3D;
            dgv_subItem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_subItem.Location = new Point(571, 9);
            dgv_subItem.Name = "dgv_subItem";
            dgv_subItem.Size = new Size(598, 488);
            dgv_subItem.TabIndex = 21;
            // 
            // PCMLabelForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Green;
            ClientSize = new Size(1184, 839);
            Controls.Add(dgv_subItem);
            Controls.Add(groupBox6);
            Controls.Add(groupBox8);
            Controls.Add(groupBox7);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            KeyPreview = true;
            Name = "PCMLabelForm";
            Text = "PCMLabelProdStdForm";
            FormClosing += PCMLabelForm_FormClosing;
            Load += PCMLabelForm_Load;
            KeyDown += PCMLabelForm_KeyDown;
            ((System.ComponentModel.ISupportInitialize)dgv_item).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_traceInfo).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv_subItem).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button btn_kindCd2;
        private Button btn_kindCd1;
        private DataGridView dgv_item;
        private GroupBox groupBox1;
        private GroupBox groupBox8;
        private Panel panel1;
        private MaskedTextBox mtb_traceNo;
        private Label label1;
        private Button btn_frzDiv2;
        private Panel panel2;
        private Button btn_print;
        private MaskedTextBox mtb_printCnt;
        private Label label7;
        private MaskedTextBox mtb_weight;
        private Label label6;
        private MaskedTextBox mtb_count;
        private Label label5;
        private MaskedTextBox mtb_boxWt;
        private Label label4;
        private MaskedTextBox mtb_itemCd;
        private Label label3;
        private DateTimePicker dtp_workDate;
        private Label label2;
        private GroupBox groupBox2;
        private DateTimePicker dtp_orderDate;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
        private Button btn_popupPrint;
        private Button btn_exit;
        private TextBox tb_status;
        private GroupBox groupBox7;
        private DataGridView dgv_traceInfo;
        private PrintPreviewDialog ppd_printView;
        private System.Drawing.Printing.PrintDocument pd_printDocument;
        private Label label10;
        private Button button1;
        private DataGridView dataGridView1;
        private GroupBox groupBox6;
        private DataGridView dataGridView2;
        private Button button4;
        private Button button3;
        private Button button2;
        private DataGridView dgv_subItem;
    }
}