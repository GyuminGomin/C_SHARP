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
            groupBox3 = new GroupBox();
            dgv_subItem = new DataGridView();
            groupBox8 = new GroupBox();
            dgv_traceInfo = new DataGridView();
            panel1 = new Panel();
            mtb_traceNo = new MaskedTextBox();
            label1 = new Label();
            btn_frzDiv2 = new Button();
            btn_frzDiv1 = new Button();
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
            panel3 = new Panel();
            groupBox5 = new GroupBox();
            panel4 = new Panel();
            mtb_orderQtyNotEvery = new MaskedTextBox();
            label8 = new Label();
            cb_88 = new CheckBox();
            cb_longSize = new CheckBox();
            groupBox6 = new GroupBox();
            panel5 = new Panel();
            rdb_10 = new RadioButton();
            rdb_09 = new RadioButton();
            rdb_08 = new RadioButton();
            rdb_07 = new RadioButton();
            mtb_orderQtyEvery = new MaskedTextBox();
            label10 = new Label();
            cb_7day = new CheckBox();
            groupBox7 = new GroupBox();
            panel6 = new Panel();
            tb_status = new TextBox();
            btn_exit = new Button();
            btn_popupPrint = new Button();
            ppd_printView = new PrintPreviewDialog();
            pd_printDocument = new System.Drawing.Printing.PrintDocument();
            btn_kindCd2 = new Button();
            btn_kindCd1 = new Button();
            cb_coupang = new CheckBox();
            dgv_item = new DataGridView();
            groupBox1 = new GroupBox();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_subItem).BeginInit();
            groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_traceInfo).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox4.SuspendLayout();
            panel3.SuspendLayout();
            groupBox5.SuspendLayout();
            panel4.SuspendLayout();
            groupBox6.SuspendLayout();
            panel5.SuspendLayout();
            groupBox7.SuspendLayout();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_item).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.None;
            groupBox3.Controls.Add(dgv_subItem);
            groupBox3.Location = new Point(569, 0);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(600, 527);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "상세제품";
            // 
            // dgv_subItem
            // 
            dgv_subItem.Anchor = AnchorStyles.None;
            dgv_subItem.BorderStyle = BorderStyle.Fixed3D;
            dgv_subItem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_subItem.Location = new Point(6, 22);
            dgv_subItem.Name = "dgv_subItem";
            dgv_subItem.Size = new Size(588, 499);
            dgv_subItem.TabIndex = 5;
            dgv_subItem.CellClick += dgv_subItem_CellClick;
            dgv_subItem.CellDoubleClick += dgv_subItem_CellDoubleClick;
            // 
            // groupBox8
            // 
            groupBox8.Anchor = AnchorStyles.None;
            groupBox8.Controls.Add(dgv_traceInfo);
            groupBox8.Location = new Point(5, 315);
            groupBox8.Name = "groupBox8";
            groupBox8.Size = new Size(554, 132);
            groupBox8.TabIndex = 19;
            groupBox8.TabStop = false;
            groupBox8.Text = "재고정보";
            // 
            // dgv_traceInfo
            // 
            dgv_traceInfo.BorderStyle = BorderStyle.Fixed3D;
            dgv_traceInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_traceInfo.ColumnHeadersVisible = false;
            dgv_traceInfo.Location = new Point(6, 21);
            dgv_traceInfo.Name = "dgv_traceInfo";
            dgv_traceInfo.Size = new Size(542, 104);
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
            panel1.Controls.Add(btn_frzDiv1);
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
            label1.Location = new Point(3, 54);
            label1.Name = "label1";
            label1.Size = new Size(81, 17);
            label1.TabIndex = 3;
            label1.Text = "생산이력번호";
            // 
            // btn_frzDiv2
            // 
            btn_frzDiv2.Font = new Font("맑은 고딕", 12F);
            btn_frzDiv2.Location = new Point(134, 5);
            btn_frzDiv2.Name = "btn_frzDiv2";
            btn_frzDiv2.Size = new Size(100, 40);
            btn_frzDiv2.TabIndex = 2;
            btn_frzDiv2.Text = "냉장";
            btn_frzDiv2.UseVisualStyleBackColor = true;
            btn_frzDiv2.Click += btn_frzDiv2_Click;
            // 
            // btn_frzDiv1
            // 
            btn_frzDiv1.Font = new Font("맑은 고딕", 12F);
            btn_frzDiv1.Location = new Point(22, 5);
            btn_frzDiv1.Name = "btn_frzDiv1";
            btn_frzDiv1.Size = new Size(100, 40);
            btn_frzDiv1.TabIndex = 1;
            btn_frzDiv1.Text = "냉동";
            btn_frzDiv1.UseVisualStyleBackColor = true;
            btn_frzDiv1.Click += btn_frzDiv1_Click;
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
            panel2.Size = new Size(261, 259);
            panel2.TabIndex = 2;
            // 
            // btn_print
            // 
            btn_print.BackColor = Color.Red;
            btn_print.Font = new Font("맑은 고딕", 15F, FontStyle.Bold);
            btn_print.ForeColor = Color.White;
            btn_print.Location = new Point(142, 182);
            btn_print.Name = "btn_print";
            btn_print.Size = new Size(106, 67);
            btn_print.TabIndex = 16;
            btn_print.Text = "라벨\r\n발행";
            btn_print.UseVisualStyleBackColor = false;
            btn_print.Click += btn_print_Click;
            // 
            // mtb_printCnt
            // 
            mtb_printCnt.Location = new Point(69, 185);
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
            label7.Location = new Point(5, 188);
            label7.Name = "label7";
            label7.Size = new Size(57, 17);
            label7.TabIndex = 14;
            label7.Text = "발행수량";
            // 
            // mtb_weight
            // 
            mtb_weight.Location = new Point(69, 152);
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
            label6.Location = new Point(5, 155);
            label6.Name = "label6";
            label6.Size = new Size(57, 17);
            label6.TabIndex = 12;
            label6.Text = "중량[Kg]";
            // 
            // mtb_count
            // 
            mtb_count.InsertKeyMode = InsertKeyMode.Insert;
            mtb_count.Location = new Point(69, 120);
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
            label5.Location = new Point(5, 122);
            label5.Name = "label5";
            label5.Size = new Size(57, 17);
            label5.TabIndex = 10;
            label5.Text = "수량[Ea]";
            // 
            // mtb_boxWt
            // 
            mtb_boxWt.Location = new Point(69, 86);
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
            label4.Location = new Point(5, 89);
            label4.Name = "label4";
            label4.Size = new Size(57, 17);
            label4.TabIndex = 8;
            label4.Text = "기준중량";
            // 
            // mtb_itemCd
            // 
            mtb_itemCd.Location = new Point(69, 51);
            mtb_itemCd.Name = "mtb_itemCd";
            mtb_itemCd.Size = new Size(179, 23);
            mtb_itemCd.TabIndex = 7;
            mtb_itemCd.TextAlign = HorizontalAlignment.Center;
            // 
            // label3
            // 
            label3.BackColor = Color.Turquoise;
            label3.BorderStyle = BorderStyle.Fixed3D;
            label3.Location = new Point(5, 54);
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
            groupBox2.Location = new Point(6, 453);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(273, 379);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "라벨정보";
            // 
            // dtp_orderDate
            // 
            dtp_orderDate.CustomFormat = "yyyy-MM-dd";
            dtp_orderDate.Format = DateTimePickerFormat.Custom;
            dtp_orderDate.Location = new Point(48, 13);
            dtp_orderDate.Name = "dtp_orderDate";
            dtp_orderDate.Size = new Size(160, 23);
            dtp_orderDate.TabIndex = 7;
            dtp_orderDate.ValueChanged += dtp_orderDate_ValueChanged;
            // 
            // groupBox4
            // 
            groupBox4.Anchor = AnchorStyles.None;
            groupBox4.Controls.Add(panel3);
            groupBox4.Location = new Point(285, 453);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(274, 74);
            groupBox4.TabIndex = 4;
            groupBox4.TabStop = false;
            groupBox4.Text = "주문일자";
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ControlDark;
            panel3.BorderStyle = BorderStyle.Fixed3D;
            panel3.Controls.Add(dtp_orderDate);
            panel3.Location = new Point(6, 15);
            panel3.Name = "panel3";
            panel3.Size = new Size(262, 53);
            panel3.TabIndex = 20;
            // 
            // groupBox5
            // 
            groupBox5.Anchor = AnchorStyles.None;
            groupBox5.Controls.Add(panel4);
            groupBox5.Location = new Point(285, 525);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(274, 98);
            groupBox5.TabIndex = 5;
            groupBox5.TabStop = false;
            groupBox5.Text = "일반 라벨 발행 정보";
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.ControlDark;
            panel4.BorderStyle = BorderStyle.Fixed3D;
            panel4.Controls.Add(mtb_orderQtyNotEvery);
            panel4.Controls.Add(label8);
            panel4.Controls.Add(cb_88);
            panel4.Controls.Add(cb_longSize);
            panel4.Location = new Point(5, 16);
            panel4.Name = "panel4";
            panel4.Size = new Size(262, 76);
            panel4.TabIndex = 21;
            // 
            // mtb_orderQtyNotEvery
            // 
            mtb_orderQtyNotEvery.Location = new Point(71, 39);
            mtb_orderQtyNotEvery.Name = "mtb_orderQtyNotEvery";
            mtb_orderQtyNotEvery.ReadOnly = true;
            mtb_orderQtyNotEvery.Size = new Size(57, 23);
            mtb_orderQtyNotEvery.TabIndex = 20;
            mtb_orderQtyNotEvery.TextAlign = HorizontalAlignment.Center;
            // 
            // label8
            // 
            label8.BackColor = Color.FromArgb(204, 204, 204);
            label8.Location = new Point(16, 43);
            label8.Name = "label8";
            label8.Size = new Size(50, 15);
            label8.TabIndex = 19;
            label8.Text = "발주량";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cb_88
            // 
            cb_88.AutoSize = true;
            cb_88.Location = new Point(151, 12);
            cb_88.Name = "cb_88";
            cb_88.Size = new Size(92, 19);
            cb_88.TabIndex = 18;
            cb_88.Text = "88코드 삭제";
            cb_88.UseVisualStyleBackColor = true;
            // 
            // cb_longSize
            // 
            cb_longSize.AutoSize = true;
            cb_longSize.Location = new Point(19, 12);
            cb_longSize.Name = "cb_longSize";
            cb_longSize.Size = new Size(90, 19);
            cb_longSize.TabIndex = 17;
            cb_longSize.Text = "大용기 라벨";
            cb_longSize.UseVisualStyleBackColor = true;
            cb_longSize.Click += cb_longSize_Click;
            // 
            // groupBox6
            // 
            groupBox6.Anchor = AnchorStyles.None;
            groupBox6.Controls.Add(panel5);
            groupBox6.Location = new Point(285, 621);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(274, 113);
            groupBox6.TabIndex = 17;
            groupBox6.TabStop = false;
            groupBox6.Text = "에브리 라벨 발행 정보";
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.ControlDark;
            panel5.BorderStyle = BorderStyle.Fixed3D;
            panel5.Controls.Add(rdb_10);
            panel5.Controls.Add(rdb_09);
            panel5.Controls.Add(rdb_08);
            panel5.Controls.Add(rdb_07);
            panel5.Controls.Add(mtb_orderQtyEvery);
            panel5.Controls.Add(label10);
            panel5.Controls.Add(cb_7day);
            panel5.Location = new Point(5, 15);
            panel5.Name = "panel5";
            panel5.Size = new Size(262, 95);
            panel5.TabIndex = 21;
            // 
            // rdb_10
            // 
            rdb_10.AutoSize = true;
            rdb_10.Location = new Point(180, 67);
            rdb_10.Name = "rdb_10";
            rdb_10.Size = new Size(51, 19);
            rdb_10.TabIndex = 27;
            rdb_10.Text = "10일\r\n";
            rdb_10.UseVisualStyleBackColor = true;
            // 
            // rdb_09
            // 
            rdb_09.AutoSize = true;
            rdb_09.Location = new Point(180, 46);
            rdb_09.Name = "rdb_09";
            rdb_09.Size = new Size(51, 19);
            rdb_09.TabIndex = 26;
            rdb_09.Text = "09일\r\n";
            rdb_09.UseVisualStyleBackColor = true;
            // 
            // rdb_08
            // 
            rdb_08.AutoSize = true;
            rdb_08.Location = new Point(180, 27);
            rdb_08.Name = "rdb_08";
            rdb_08.Size = new Size(51, 19);
            rdb_08.TabIndex = 25;
            rdb_08.Text = "08일\r\n";
            rdb_08.UseVisualStyleBackColor = true;
            // 
            // rdb_07
            // 
            rdb_07.AutoSize = true;
            rdb_07.Checked = true;
            rdb_07.Location = new Point(180, 6);
            rdb_07.Name = "rdb_07";
            rdb_07.Size = new Size(51, 19);
            rdb_07.TabIndex = 24;
            rdb_07.TabStop = true;
            rdb_07.Text = "07일\r\n";
            rdb_07.UseVisualStyleBackColor = true;
            // 
            // mtb_orderQtyEvery
            // 
            mtb_orderQtyEvery.Location = new Point(71, 53);
            mtb_orderQtyEvery.Name = "mtb_orderQtyEvery";
            mtb_orderQtyEvery.ReadOnly = true;
            mtb_orderQtyEvery.Size = new Size(57, 23);
            mtb_orderQtyEvery.TabIndex = 23;
            mtb_orderQtyEvery.TextAlign = HorizontalAlignment.Center;
            // 
            // label10
            // 
            label10.BackColor = Color.FromArgb(204, 204, 204);
            label10.Location = new Point(16, 57);
            label10.Name = "label10";
            label10.Size = new Size(50, 15);
            label10.TabIndex = 22;
            label10.Text = "발주량";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cb_7day
            // 
            cb_7day.AutoSize = true;
            cb_7day.Checked = true;
            cb_7day.CheckState = CheckState.Checked;
            cb_7day.Location = new Point(16, 21);
            cb_7day.Name = "cb_7day";
            cb_7day.Size = new Size(114, 19);
            cb_7day.TabIndex = 21;
            cb_7day.Text = "에브리데이 라벨";
            cb_7day.UseVisualStyleBackColor = true;
            cb_7day.Click += cb_7day_Click;
            // 
            // groupBox7
            // 
            groupBox7.Anchor = AnchorStyles.None;
            groupBox7.Controls.Add(panel6);
            groupBox7.Location = new Point(285, 732);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(274, 100);
            groupBox7.TabIndex = 18;
            groupBox7.TabStop = false;
            groupBox7.Text = "기타정보";
            // 
            // panel6
            // 
            panel6.BackColor = SystemColors.ControlDark;
            panel6.BorderStyle = BorderStyle.Fixed3D;
            panel6.Controls.Add(tb_status);
            panel6.Controls.Add(btn_exit);
            panel6.Controls.Add(btn_popupPrint);
            panel6.Location = new Point(6, 16);
            panel6.Name = "panel6";
            panel6.Size = new Size(262, 80);
            panel6.TabIndex = 21;
            // 
            // tb_status
            // 
            tb_status.BackColor = Color.Yellow;
            tb_status.BorderStyle = BorderStyle.FixedSingle;
            tb_status.Location = new Point(21, 50);
            tb_status.Name = "tb_status";
            tb_status.Size = new Size(215, 23);
            tb_status.TabIndex = 5;
            // 
            // btn_exit
            // 
            btn_exit.Font = new Font("맑은 고딕", 12F);
            btn_exit.Location = new Point(136, 3);
            btn_exit.Name = "btn_exit";
            btn_exit.Size = new Size(100, 40);
            btn_exit.TabIndex = 4;
            btn_exit.Text = "종료";
            btn_exit.UseVisualStyleBackColor = true;
            btn_exit.Click += btn_exit_Click;
            // 
            // btn_popupPrint
            // 
            btn_popupPrint.Font = new Font("맑은 고딕", 12F);
            btn_popupPrint.Location = new Point(21, 3);
            btn_popupPrint.Name = "btn_popupPrint";
            btn_popupPrint.Size = new Size(100, 40);
            btn_popupPrint.TabIndex = 3;
            btn_popupPrint.Text = "프린터설정";
            btn_popupPrint.UseVisualStyleBackColor = true;
            btn_popupPrint.Click += btn_popupPrint_Click;
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
            // btn_kindCd2
            // 
            btn_kindCd2.BackColor = SystemColors.ControlDark;
            btn_kindCd2.Font = new Font("맑은 고딕", 15F, FontStyle.Bold);
            btn_kindCd2.ForeColor = SystemColors.ControlText;
            btn_kindCd2.Location = new Point(10, 17);
            btn_kindCd2.Name = "btn_kindCd2";
            btn_kindCd2.Size = new Size(100, 55);
            btn_kindCd2.TabIndex = 0;
            btn_kindCd2.Text = "돈육";
            btn_kindCd2.TextAlign = ContentAlignment.TopCenter;
            btn_kindCd2.UseVisualStyleBackColor = false;
            btn_kindCd2.Click += btn_kindCd2_Click;
            // 
            // btn_kindCd1
            // 
            btn_kindCd1.BackColor = SystemColors.ControlDark;
            btn_kindCd1.Enabled = false;
            btn_kindCd1.Font = new Font("맑은 고딕", 15F, FontStyle.Bold);
            btn_kindCd1.Location = new Point(117, 17);
            btn_kindCd1.Name = "btn_kindCd1";
            btn_kindCd1.Size = new Size(100, 55);
            btn_kindCd1.TabIndex = 1;
            btn_kindCd1.Text = "한우";
            btn_kindCd1.TextAlign = ContentAlignment.TopCenter;
            btn_kindCd1.UseVisualStyleBackColor = false;
            btn_kindCd1.Click += btn_kindCd1_Click;
            // 
            // cb_coupang
            // 
            cb_coupang.AutoSize = true;
            cb_coupang.Font = new Font("맑은 고딕", 15F);
            cb_coupang.ForeColor = Color.Red;
            cb_coupang.Location = new Point(450, 39);
            cb_coupang.Name = "cb_coupang";
            cb_coupang.Size = new Size(71, 32);
            cb_coupang.TabIndex = 2;
            cb_coupang.Text = "쿠팡";
            cb_coupang.UseVisualStyleBackColor = true;
            cb_coupang.CheckedChanged += cb_coupang_CheckedChanged;
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
            groupBox1.Controls.Add(dgv_item);
            groupBox1.Controls.Add(cb_coupang);
            groupBox1.Controls.Add(btn_kindCd1);
            groupBox1.Controls.Add(btn_kindCd2);
            groupBox1.Font = new Font("맑은 고딕", 9F);
            groupBox1.Location = new Point(5, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(554, 309);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "MAIN";
            // 
            // PCMLabelForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1184, 839);
            Controls.Add(groupBox8);
            Controls.Add(groupBox7);
            Controls.Add(groupBox6);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            KeyPreview = true;
            Name = "PCMLabelForm";
            Text = "PCMLabelForm";
            FormClosing += PCMLabelForm_FormClosing;
            Load += PCMLabelForm_Load;
            KeyDown += PCMLabelForm_KeyDown;
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_subItem).EndInit();
            groupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_traceInfo).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            panel3.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            groupBox6.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            groupBox7.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_item).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox3;
        private GroupBox groupBox8;
        private Panel panel1;
        private MaskedTextBox mtb_traceNo;
        private Label label1;
        private Button btn_frzDiv2;
        private Button btn_frzDiv1;
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
        private GroupBox groupBox6;
        private GroupBox groupBox7;
        private DataGridView dgv_subItem;
        private DataGridView dgv_traceInfo;
        private PrintPreviewDialog ppd_printView;
        private System.Drawing.Printing.PrintDocument pd_printDocument;
        private Button btn_kindCd2;
        private Button btn_kindCd1;
        private CheckBox cb_coupang;
        private DataGridView dgv_item;
        private GroupBox groupBox1;
        private Panel panel3;
        private Panel panel4;
        private MaskedTextBox mtb_orderQtyNotEvery;
        private Label label8;
        private CheckBox cb_88;
        private CheckBox cb_longSize;
        private Panel panel5;
        private RadioButton rdb_10;
        private RadioButton rdb_09;
        private RadioButton rdb_08;
        private RadioButton rdb_07;
        private MaskedTextBox mtb_orderQtyEvery;
        private Label label10;
        private CheckBox cb_7day;
        private Panel panel6;
        private TextBox tb_status;
        private Button btn_exit;
        private Button btn_popupPrint;
    }
}