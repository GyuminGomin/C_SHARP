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
            components = new System.ComponentModel.Container();
            oDBCBindingSource = new BindingSource(components);
            oDBCBindingSource1 = new BindingSource(components);
            dBContextBindingSource = new BindingSource(components);
            oracleCommand1 = new Oracle.ManagedDataAccess.Client.OracleCommand();
            groupBox3 = new GroupBox();
            dgv_subItem = new DataGridView();
            btn_kindCd2 = new Button();
            btn_kindCd1 = new Button();
            cb_coupang = new CheckBox();
            dgv_item = new DataGridView();
            groupBox1 = new GroupBox();
            groupBox8 = new GroupBox();
            dgv_traceInfo = new DataGridView();
            panel1 = new Panel();
            mtb_traceNo = new MaskedTextBox();
            label1 = new Label();
            btn_frzDiv2 = new Button();
            btn_frzDiv1 = new Button();
            panel2 = new Panel();
            button5 = new Button();
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
            cb_longSize = new CheckBox();
            checkBox3 = new CheckBox();
            label8 = new Label();
            mtb_orderQtyNotEvery = new MaskedTextBox();
            groupBox5 = new GroupBox();
            cb_7day = new CheckBox();
            label9 = new Label();
            mtb_orderQtyEvery = new MaskedTextBox();
            rdb_01 = new RadioButton();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton3 = new RadioButton();
            groupBox6 = new GroupBox();
            button6 = new Button();
            button7 = new Button();
            tb_status = new TextBox();
            groupBox7 = new GroupBox();
            oracleCommand2 = new Oracle.ManagedDataAccess.Client.OracleCommand();
            ((System.ComponentModel.ISupportInitialize)oDBCBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)oDBCBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dBContextBindingSource).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_subItem).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_item).BeginInit();
            groupBox1.SuspendLayout();
            groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_traceInfo).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox7.SuspendLayout();
            SuspendLayout();
            // 
            // oDBCBindingSource
            // 
            oDBCBindingSource.DataSource = typeof(Config.ODBC);
            // 
            // oDBCBindingSource1
            // 
            oDBCBindingSource1.DataSource = typeof(Config.ODBC);
            // 
            // dBContextBindingSource
            // 
            dBContextBindingSource.DataSource = typeof(Data.DBContext);
            // 
            // oracleCommand1
            // 
            oracleCommand1.RowsToFetchPerRoundTrip = 0L;
            oracleCommand1.Transaction = null;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.None;
            groupBox3.Controls.Add(dgv_subItem);
            groupBox3.Location = new Point(569, 0);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(600, 496);
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
            dgv_subItem.Size = new Size(588, 468);
            dgv_subItem.TabIndex = 5;
            dgv_subItem.CellClick += dgv_subItem_CellClick;
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
            btn_kindCd1.Location = new Point(117, 17);
            btn_kindCd1.Name = "btn_kindCd1";
            btn_kindCd1.Size = new Size(100, 55);
            btn_kindCd1.TabIndex = 1;
            btn_kindCd1.Text = "한우";
            btn_kindCd1.TextAlign = ContentAlignment.TopCenter;
            btn_kindCd1.UseVisualStyleBackColor = true;
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
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.None;
            groupBox1.Controls.Add(dgv_item);
            groupBox1.Controls.Add(cb_coupang);
            groupBox1.Controls.Add(btn_kindCd1);
            groupBox1.Controls.Add(btn_kindCd2);
            groupBox1.Location = new Point(5, 0);
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
            groupBox8.Location = new Point(5, 310);
            groupBox8.Name = "groupBox8";
            groupBox8.Size = new Size(554, 106);
            groupBox8.TabIndex = 19;
            groupBox8.TabStop = false;
            groupBox8.Text = "재고정보";
            // 
            // dgv_traceInfo
            // 
            dgv_traceInfo.BorderStyle = BorderStyle.Fixed3D;
            dgv_traceInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_traceInfo.Location = new Point(6, 22);
            dgv_traceInfo.Name = "dgv_traceInfo";
            dgv_traceInfo.Size = new Size(542, 78);
            dgv_traceInfo.TabIndex = 5;
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkGray;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(mtb_traceNo);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btn_frzDiv2);
            panel1.Controls.Add(btn_frzDiv1);
            panel1.Location = new Point(6, 22);
            panel1.Name = "panel1";
            panel1.Size = new Size(261, 82);
            panel1.TabIndex = 1;
            // 
            // mtb_traceNo
            // 
            mtb_traceNo.Location = new Point(83, 51);
            mtb_traceNo.Name = "mtb_traceNo";
            mtb_traceNo.Size = new Size(160, 23);
            mtb_traceNo.TabIndex = 4;
            mtb_traceNo.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 55);
            label1.Name = "label1";
            label1.Size = new Size(79, 15);
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
            panel2.Controls.Add(button5);
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
            // button5
            // 
            button5.Location = new Point(137, 182);
            button5.Name = "button5";
            button5.Size = new Size(106, 67);
            button5.TabIndex = 16;
            button5.Text = "라벨\r\n발행";
            button5.UseVisualStyleBackColor = true;
            // 
            // mtb_printCnt
            // 
            mtb_printCnt.Location = new Point(64, 185);
            mtb_printCnt.Name = "mtb_printCnt";
            mtb_printCnt.Size = new Size(67, 23);
            mtb_printCnt.TabIndex = 15;
            mtb_printCnt.TextAlign = HorizontalAlignment.Right;
            mtb_printCnt.ValidatingType = typeof(int);
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(4, 188);
            label7.Name = "label7";
            label7.Size = new Size(55, 15);
            label7.TabIndex = 14;
            label7.Text = "발행수량";
            // 
            // mtb_weight
            // 
            mtb_weight.Location = new Point(64, 152);
            mtb_weight.Name = "mtb_weight";
            mtb_weight.Size = new Size(179, 23);
            mtb_weight.TabIndex = 13;
            mtb_weight.TextAlign = HorizontalAlignment.Right;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(4, 156);
            label6.Name = "label6";
            label6.Size = new Size(53, 15);
            label6.TabIndex = 12;
            label6.Text = "중량[Kg]";
            // 
            // mtb_count
            // 
            mtb_count.InsertKeyMode = InsertKeyMode.Insert;
            mtb_count.Location = new Point(64, 120);
            mtb_count.Name = "mtb_count";
            mtb_count.PromptChar = ' ';
            mtb_count.RejectInputOnFirstFailure = true;
            mtb_count.Size = new Size(179, 23);
            mtb_count.TabIndex = 11;
            mtb_count.TextAlign = HorizontalAlignment.Right;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(4, 124);
            label5.Name = "label5";
            label5.Size = new Size(51, 15);
            label5.TabIndex = 10;
            label5.Text = "수량[Ea]";
            // 
            // mtb_boxWt
            // 
            mtb_boxWt.Location = new Point(64, 86);
            mtb_boxWt.Name = "mtb_boxWt";
            mtb_boxWt.Size = new Size(179, 23);
            mtb_boxWt.TabIndex = 9;
            mtb_boxWt.TextAlign = HorizontalAlignment.Right;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 90);
            label4.Name = "label4";
            label4.Size = new Size(55, 15);
            label4.TabIndex = 8;
            label4.Text = "기준중량";
            // 
            // mtb_itemCd
            // 
            mtb_itemCd.Location = new Point(64, 51);
            mtb_itemCd.Name = "mtb_itemCd";
            mtb_itemCd.Size = new Size(179, 23);
            mtb_itemCd.TabIndex = 7;
            mtb_itemCd.TextAlign = HorizontalAlignment.Center;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 55);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 6;
            label3.Text = "제품번호";
            // 
            // dtp_workDate
            // 
            dtp_workDate.Location = new Point(64, 14);
            dtp_workDate.Name = "dtp_workDate";
            dtp_workDate.Size = new Size(179, 23);
            dtp_workDate.TabIndex = 5;
            dtp_workDate.ValueChanged += dtp_workDate_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 20);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 4;
            label2.Text = "작업일자";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.None;
            groupBox2.Controls.Add(panel2);
            groupBox2.Controls.Add(panel1);
            groupBox2.Location = new Point(6, 422);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(273, 387);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "라벨정보";
            // 
            // dtp_orderDate
            // 
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
            groupBox4.Location = new Point(285, 422);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(274, 74);
            groupBox4.TabIndex = 4;
            groupBox4.TabStop = false;
            groupBox4.Text = "주문일자";
            // 
            // cb_longSize
            // 
            cb_longSize.AutoSize = true;
            cb_longSize.Location = new Point(9, 24);
            cb_longSize.Name = "cb_longSize";
            cb_longSize.Size = new Size(90, 19);
            cb_longSize.TabIndex = 0;
            cb_longSize.Text = "大용기 라벨";
            cb_longSize.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(135, 24);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(92, 19);
            checkBox3.TabIndex = 1;
            checkBox3.Text = "88코드 삭제";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 56);
            label8.Name = "label8";
            label8.Size = new Size(43, 15);
            label8.TabIndex = 2;
            label8.Text = "발주량";
            // 
            // mtb_orderQtyNotEvery
            // 
            mtb_orderQtyNotEvery.Location = new Point(53, 53);
            mtb_orderQtyNotEvery.Name = "mtb_orderQtyNotEvery";
            mtb_orderQtyNotEvery.Size = new Size(57, 23);
            mtb_orderQtyNotEvery.TabIndex = 16;
            mtb_orderQtyNotEvery.TextAlign = HorizontalAlignment.Right;
            // 
            // groupBox5
            // 
            groupBox5.Anchor = AnchorStyles.None;
            groupBox5.Controls.Add(mtb_orderQtyNotEvery);
            groupBox5.Controls.Add(label8);
            groupBox5.Controls.Add(checkBox3);
            groupBox5.Controls.Add(cb_longSize);
            groupBox5.Location = new Point(285, 494);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(274, 98);
            groupBox5.TabIndex = 5;
            groupBox5.TabStop = false;
            groupBox5.Text = "일반 라벨 발행 정보";
            // 
            // cb_7day
            // 
            cb_7day.AutoSize = true;
            cb_7day.Location = new Point(9, 24);
            cb_7day.Name = "cb_7day";
            cb_7day.Size = new Size(114, 19);
            cb_7day.TabIndex = 0;
            cb_7day.Text = "에브리데이 라벨";
            cb_7day.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(17, 66);
            label9.Name = "label9";
            label9.Size = new Size(43, 15);
            label9.TabIndex = 2;
            label9.Text = "발주량";
            // 
            // mtb_orderQtyEvery
            // 
            mtb_orderQtyEvery.Location = new Point(66, 61);
            mtb_orderQtyEvery.Name = "mtb_orderQtyEvery";
            mtb_orderQtyEvery.Size = new Size(57, 23);
            mtb_orderQtyEvery.TabIndex = 16;
            mtb_orderQtyEvery.TextAlign = HorizontalAlignment.Right;
            // 
            // rdb_01
            // 
            rdb_01.AutoSize = true;
            rdb_01.Checked = true;
            rdb_01.Location = new Point(194, 13);
            rdb_01.Name = "rdb_01";
            rdb_01.Size = new Size(51, 19);
            rdb_01.TabIndex = 17;
            rdb_01.TabStop = true;
            rdb_01.Text = "07일\r\n";
            rdb_01.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(194, 35);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(51, 19);
            radioButton1.TabIndex = 18;
            radioButton1.Text = "08일\r\n";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(194, 57);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(51, 19);
            radioButton2.TabIndex = 19;
            radioButton2.Text = "09일\r\n";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(194, 80);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(51, 19);
            radioButton3.TabIndex = 20;
            radioButton3.Text = "10일\r\n";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            groupBox6.Anchor = AnchorStyles.None;
            groupBox6.Controls.Add(radioButton3);
            groupBox6.Controls.Add(radioButton2);
            groupBox6.Controls.Add(radioButton1);
            groupBox6.Controls.Add(rdb_01);
            groupBox6.Controls.Add(mtb_orderQtyEvery);
            groupBox6.Controls.Add(label9);
            groupBox6.Controls.Add(cb_7day);
            groupBox6.Location = new Point(285, 590);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(274, 121);
            groupBox6.TabIndex = 17;
            groupBox6.TabStop = false;
            groupBox6.Text = "에브리 라벨 발행 정보";
            // 
            // button6
            // 
            button6.Location = new Point(35, 22);
            button6.Name = "button6";
            button6.Size = new Size(75, 23);
            button6.TabIndex = 0;
            button6.Text = "프린터설정";
            button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.Location = new Point(170, 22);
            button7.Name = "button7";
            button7.Size = new Size(75, 23);
            button7.TabIndex = 1;
            button7.Text = "종료";
            button7.UseVisualStyleBackColor = true;
            // 
            // tb_status
            // 
            tb_status.Location = new Point(10, 55);
            tb_status.Name = "tb_status";
            tb_status.Size = new Size(257, 23);
            tb_status.TabIndex = 2;
            // 
            // groupBox7
            // 
            groupBox7.Anchor = AnchorStyles.None;
            groupBox7.Controls.Add(tb_status);
            groupBox7.Controls.Add(button7);
            groupBox7.Controls.Add(button6);
            groupBox7.Location = new Point(285, 709);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(274, 100);
            groupBox7.TabIndex = 18;
            groupBox7.TabStop = false;
            groupBox7.Text = "기타정보";
            // 
            // oracleCommand2
            // 
            oracleCommand2.RowsToFetchPerRoundTrip = 0L;
            oracleCommand2.Transaction = null;
            // 
            // PCMLabelForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.Gray;
            ClientSize = new Size(1184, 839);
            Controls.Add(groupBox8);
            Controls.Add(groupBox7);
            Controls.Add(groupBox6);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "PCMLabelForm";
            Text = "PCMLabelForm";
            Load += PCMLabelForm_Load_1;
            ((System.ComponentModel.ISupportInitialize)oDBCBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)oDBCBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dBContextBindingSource).EndInit();
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_subItem).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv_item).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_traceInfo).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private BindingSource oDBCBindingSource;
        private BindingSource oDBCBindingSource1;
        private BindingSource dBContextBindingSource;
        private Oracle.ManagedDataAccess.Client.OracleCommand oracleCommand1;
        private GroupBox groupBox3;
        private Button btn_kindCd2;
        private Button btn_kindCd1;
        private CheckBox cb_coupang;
        private DataGridView dgv_item;
        private GroupBox groupBox1;
        private GroupBox groupBox8;
        private Panel panel1;
        private MaskedTextBox mtb_traceNo;
        private Label label1;
        private Button btn_frzDiv2;
        private Button btn_frzDiv1;
        private Panel panel2;
        private Button button5;
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
        private CheckBox cb_longSize;
        private CheckBox checkBox3;
        private Label label8;
        private MaskedTextBox mtb_orderQtyNotEvery;
        private GroupBox groupBox5;
        private CheckBox cb_7day;
        private Label label9;
        private MaskedTextBox mtb_orderQtyEvery;
        private RadioButton rdb_01;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private RadioButton radioButton3;
        private GroupBox groupBox6;
        private Button button6;
        private Button button7;
        private TextBox tb_status;
        private GroupBox groupBox7;
        private DataGridView dgv_subItem;
        private DataGridView dgv_traceInfo;
        private Oracle.ManagedDataAccess.Client.OracleCommand oracleCommand2;
    }
}