using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Reflection.Metadata.Ecma335;
using System.Security.Policy;
using WindowsFormCSharp._PCMStartForms;

namespace WindowsFormCSharp._PCMLabel
{
    public partial class PCMLabelForm : Form
    {
        public PCMLabelForm(PrinterSettings ps, PageSettings ps2)
        {
            InitializeComponent();
            // 프린트 설정
            printerSettings = ps;
            pageSettings = ps2;

            fn_init();
        }
        // 이거는 제일 위에 둔 이유 : 폼이 열릴 때 초기에 셋팅할 수 있기 때문 (가시적이어야 한다.)
        private void PCMLabelForm_Load(object sender, EventArgs e)
        {
            // UI 초기화가 끝난 이후 동작하도록 지연
            this.BeginInvoke((MethodInvoker)delegate
            {
                // 시작 시 돈육 버튼 강제 클릭
                this.btn_kindCd2.PerformClick();
            });
        }

        // 이거를 제일 위에 둔 이유 : 폼이 닫힐 때, StartForm을 다시 열기 위해
        private void PCMLabelForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            new PCMStartForm(printerSettings, pageSettings).Show();
        }

        // Form에서 키 이벤트 발생 시
        private void PCMLabelForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (MessageBox.Show("용기라벨발행 창을 종료하시겠습니까?", "종료", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.FindForm().Close();
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                this.btn_print.PerformClick();
            }
        }

        /* ********************---------------------------------------- */
        // Region : Global Variables 전역 변수
        /* ********************---------------------------------------- */
        PCMLabelQuery pcmLabelQuery = new PCMLabelQuery();
        MySelfLibrary mySelfLibrary = new MySelfLibrary();
        MySelfStyle mySelfStyle = new MySelfStyle();
        MyselfDate mySelfDate = new MyselfDate();
        PrinterManage printerManage = new PrinterManage();
        private PrinterSettings printerSettings;
        private PageSettings pageSettings;

        private string temp_date; // 정보 처리를 위한 일자 (작업일자)
        private string order_date; // 정보 처리를 위한 일자 (주문일자)
        private int item_kind_cd; // 제품구분 (1: 한우, 2: 돈육)
        private string item_main; // 대표품목코드
        private string item_cd; // 제품코드
        private int frz_div = 2; // 냉장구분(1: 냉동, 2: 냉장)

        private int prevRowIndexDgvItem = 0; // dgv_item (이전 정보)
        private int prevColindexDgvItem = 0;
        private int prevRowIndexDgvSub = 0; // dgv_subItem (이전 정보)
        private int prevColIndexDgvSub = 0;
        /* ********************---------------------------------------- */
        // Region : Global Variables 전역 변수 ( DataTable )
        /* ********************---------------------------------------- */
        private DataTable dt_list;
        private DataTable dt_subItem;
        private DataTable dt_subItemEngName;
        private DataTable dt_subItemDetail;
        private DataTable dt_subItemOrderQtyEvery;
        private DataTable dt_subItemOrderQtyNotEvery;
        private DataTable dt_yukgagongItem;
        private DataTable dt_yukgagongKillArea;
        private DataTable dt_yukgagongTraceInfo;
        /* ********************---------------------------------------- */
        // Region : Functions 직접만든 함수
        /* ********************---------------------------------------- */

        private void fn_init()
        {
            // 작업일자, 주문일자 초기 값
            this.dtp_workDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            this.dtp_orderDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

            // temp_date, order_date 초기 값 가져오기
            temp_date = mySelfLibrary.DateTimeFormat(this.dtp_workDate);
            order_date = mySelfLibrary.DateTimeFormat(this.dtp_orderDate);

            // 발행수량
            this.mtb_printCnt.Text = mySelfLibrary.NumberFormatIntToString(1);

            if (this.cb_7day.Checked)
            {
                this.cb_7day.BackColor = Color.FromArgb(000, 102, 255);
            }
            else
            {
                this.cb_7day.BackColor = Color.FromArgb(204, 204, 204);
            }
            if (cb_longSize.Checked)
            {
                this.cb_longSize.BackColor = Color.FromArgb(000, 255, 000);
            }
            else
            {
                this.cb_longSize.BackColor = Color.FromArgb(204, 204, 204);
            }

            mySelfStyle.DataGridViewRectangle(this.dgv_item);
            mySelfStyle.DataGridViewRectangle(this.dgv_subItem);

            // 초기 버튼 설정
            this.btn_kindCd2.FlatStyle = FlatStyle.Flat;
            this.btn_kindCd2.FlatAppearance.BorderSize = 0;
            this.btn_kindCd2.BackColor = Color.SkyBlue;
            this.btn_kindCd2.ForeColor = Color.White;
            this.btn_kindCd1.FlatStyle = FlatStyle.Flat;
            this.btn_kindCd1.FlatAppearance.BorderSize = 0;
            this.btn_kindCd1.BackColor = Color.DarkGray;
            this.btn_kindCd1.ForeColor = DefaultForeColor;
            this.btn_frzDiv2.BackColor = Color.HotPink;
            this.btn_frzDiv2.ForeColor = Color.White;

            // 초기 숫자만 입력가능 MaskedTextBox 설정
            mySelfStyle.MaskedTextBoxNumber(this.mtb_count);
        }

        private void fn_itemView(int item_kind_cd)
        {
            DataTable dataTable;
            Dictionary<string, object> dict;
            if (item_kind_cd == 2)
            {
                if (frz_div == 2) // 냉장
                {
                    dict = new Dictionary<string, object>();
                    dict.Add("KIND_CD", "7150__");
                    dataTable = Query.fn_createDataTable(pcmLabelQuery, q => ((PCMLabelQuery)q).GetItemCdKindQry(dict, null));

                    this.btn_kindCd1.Enabled = true;

                    Grid_CellFormat(dataTable, this.dgv_item, "ITEM_NAME", null);
                }
                else // 냉동
                {
                    dict = new Dictionary<string, object>();
                    dict.Add("KIND_CD", "710155");
                    dataTable = Query.fn_createDataTable(pcmLabelQuery, q => ((PCMLabelQuery)q).GetItemCdKindQry(dict, null));

                    this.btn_kindCd1.Enabled = false;

                    Grid_CellFormat(dataTable, this.dgv_item, "ITEM_NAME", null);
                }
                this.tb_status.Text = "";
            }
            else if (item_kind_cd == 1)
            {
                if (frz_div == 2) // 한우는 냉장밖에 없다.
                {
                    dict = new Dictionary<string, object>();
                    dict.Add("KIND_CD", "7151__");
                    dataTable = Query.fn_createDataTable(pcmLabelQuery, q => ((PCMLabelQuery)q).GetItemCdKindQry(dict, null));

                    Grid_CellFormat(dataTable, this.dgv_item, "ITEM_NAME", null);
                }
                else
                {
                    this.btn_kindCd2.PerformClick();
                    return;
                }
                this.tb_status.Text = "3";
            }

            this.BeginInvoke((MethodInvoker)(() =>
            {
                // 처음에 있는 Cell 강제 클릭
                int rowIndex = 0;
                int colIndex = 0;
                this.dgv_item.CurrentCell = this.dgv_item.Rows[rowIndex].Cells[colIndex];
                // CellClick 이벤트 강제 호출
                DataGridViewCellEventArgs args = new DataGridViewCellEventArgs(colIndex, rowIndex);
                dgv_item_CellClick(this.dgv_item, args);
            }));
        }

        // Coupang이 체크되었는지 여부를 포함해서 MainButtonClick Event 관련
        private void IsCoupangCheck()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("ITEM_MAIN", item_main);
            if (this.cb_coupang.Checked) // 쿠팡 체크 상태일 때 1등급이상 필터링 필요
            {
                if (frz_div == 1)
                {
                    // 냉동일 때, 필터링 추가
                    this.dgv_subItem.Columns.Clear();
                    dt_subItemEngName = Query.fn_createDataTable(pcmLabelQuery, q => ((PCMLabelQuery)q).GetSubItemFilterEngNameQry(dic, null));
                    DataTable filteredDataTable = dt_subItemEngName.Clone();
                    if (dt_subItemEngName.Columns.Contains("FRZ_DIV3"))
                    {
                        DataRow[] filteredRow = dt_subItemEngName.Select("FRZ_DIV3 = 1");
                        foreach (DataRow row in filteredRow)
                        {
                            filteredDataTable.ImportRow(row);
                        }
                    }
                    Grid_CellFormat(filteredDataTable, this.dgv_subItem, "ITEM_NAME", new Font("맑은 고딕", 10, FontStyle.Bold));
                }
                else
                {
                    // 데이터 초기화
                    this.dgv_subItem.Columns.Clear();
                    dt_subItemEngName = Query.fn_createDataTable(pcmLabelQuery, q => ((PCMLabelQuery)q).GetSubItemFilterEngNameQry(dic, null));

                    Grid_CellFormat(dt_subItemEngName, this.dgv_subItem, "ITEM_NAME", new Font("맑은 고딕", 10, FontStyle.Bold));
                }
            }
            else
            {
                if (frz_div == 1)
                {
                    // 냉동일 때, 필터링 추가
                    this.dgv_subItem.Columns.Clear();
                    dt_subItem = Query.fn_createDataTable(pcmLabelQuery, q => ((PCMLabelQuery)q).GetSubItemCdKindQry(dic, null));
                    DataTable filteredDataTable = dt_subItem.Clone();
                    if (dt_subItem.Columns.Contains("FRZ_DIV3"))
                    {
                        DataRow[] filteredRow = dt_subItem.Select("FRZ_DIV3 = 1");
                        foreach (DataRow row in filteredRow)
                        {
                            filteredDataTable.ImportRow(row);
                        }
                    }
                    Grid_CellFormat(filteredDataTable, this.dgv_subItem, "ITEM_NAME", new Font("맑은 고딕", 10, FontStyle.Bold));
                }
                else
                {
                    // 데이터 초기화
                    this.dgv_subItem.Columns.Clear();
                    dt_subItem = Query.fn_createDataTable(pcmLabelQuery, q => ((PCMLabelQuery)q).GetSubItemCdKindQry(dic, null));

                    Grid_CellFormat(dt_subItem, this.dgv_subItem, "ITEM_NAME", new Font("맑은 고딕", 10, FontStyle.Bold));
                }
            }

            this.BeginInvoke((MethodInvoker)(() =>
            {
                // 처음에 있는 Cell 강제 클릭
                int rowIndex = 0;
                int colIndex = 0;
                if (this.dgv_subItem.Rows.Count > 0)
                {
                    this.dgv_subItem.CurrentCell = this.dgv_subItem.Rows[rowIndex].Cells[colIndex];
                    // CellClick 이벤트 강제 호출
                    DataGridViewCellEventArgs args = new DataGridViewCellEventArgs(colIndex, rowIndex);
                    dgv_subItem_CellClick(this.dgv_subItem, args);
                }
                else
                {
                    // 만약 비어있다면 셀 클릭할때만 발생하는 재고정보 초기화가 안될 수도 있기 때문에
                    this.dgv_traceInfo.Columns.Clear();
                }
            }));
        }

        /*
         * DataGridView에 dataTable (ITEM_NAME) 데이터 바인딩 (5열로 나누어서)
         */
        private void Grid_CellFormat(DataTable dt, DataGridView dgv, string showValueColumn, Font? font)
        {
            // 먼저 그리드 초기화
            dgv.Columns.Clear();
            // 각 열에 버튼 추가
            for (int i = 0; i < 5; i++)
            {
                DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                buttonColumn.FlatStyle = FlatStyle.Popup;
                buttonColumn.DefaultCellStyle.BackColor = Color.White;
                buttonColumn.DefaultCellStyle.ForeColor = Color.Black;
                buttonColumn.DefaultCellStyle.SelectionBackColor = Color.Blue;
                buttonColumn.DefaultCellStyle.SelectionForeColor = Color.White;
                buttonColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
                if (font != null) buttonColumn.DefaultCellStyle.Font = font;
                else buttonColumn.DefaultCellStyle.Font = new Font("맑은 고딕", 12, FontStyle.Bold);
                buttonColumn.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                buttonColumn.FillWeight = 0.15f;
                dgv.Columns.Add(buttonColumn);
            }
            // 데이터 바인딩
            // 중요한 개념 획득 (ROW를 생성할 때, Focus가 생기므로 Enter 이벤트 핸들러를 사용하면 모두 동작하기 전에 실행됨)
            int count = 0;
            foreach (DataRow row in dt.Rows)
            {
                if (count % 5 == 0)
                {
                    dgv.Rows.Add();
                }
                int rowIndex = count / 5;
                int colIndex = count % 5;

                dgv.Rows[rowIndex].Cells[colIndex].Value = row[showValueColumn].ToString();

                DataGridViewButtonCell buttonCell = (DataGridViewButtonCell)dgv.Rows[rowIndex].Cells[colIndex];
                // 여러 정보를 Dictionary로 Tag에 저장
                var cellData = new Dictionary<string, object>();

                foreach (DataColumn col in dt.Columns)
                {
                    cellData[col.ColumnName] = row[col].ToString();
                }
                buttonCell.Tag = cellData;
                count++;
            }
            int totalCells = (dt.Rows.Count + 4) / 5 * 5; // 전체 버튼 셀 개수
            for (int i = dt.Rows.Count; i < totalCells; i++)
            {
                int rowIndex = i / 5;
                int colIndex = i % 5;
                dgv.Rows[rowIndex].Cells[colIndex] = new DataGridViewTextBoxCell();
                dgv.Rows[rowIndex].Cells[colIndex].ReadOnly = true;
            }
        }

        /*
         * DataGridView (재고수량, 묶음번호, 재고 라벨발행버튼)
         */
        private void Grid_CellFormat2(DataTable dt, DataGridView dgv, string showValueColumn, Font? font)
        {
            // 먼저 그리드 초기화
            dgv.Columns.Clear();
            dgv.ColumnHeadersVisible = true; // 이걸 추가하니까 컬럼 헤더가 추가잘된다.
            if (dt.Rows.Count > 0)
            {
                dgv.AutoGenerateColumns = false; // 컬럼 자동 생성 비활성화
                dgv.AllowUserToAddRows = false; // 자동 추가 행 제거
                dgv.AllowUserToResizeRows = false; // 로우 조절 불가능
                dgv.AllowUserToResizeColumns = false; // 컬럼 조절 불가능
                dgv.ReadOnly = true; // 다른 TextBoxColumn 수정 불가능
                // 1, 2열은 텍스트, 3열은 버튼
                DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "WORK_FRZ2", HeaderText = "재고수량", Width = 80 });
                dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TRACE_NO", HeaderText = "묶음번호", Width = 120 });
                buttonColumn.Width = 250;
                buttonColumn.HeaderText = "";
                buttonColumn.Text = showValueColumn;
                buttonColumn.UseColumnTextForButtonValue = true;
                buttonColumn.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                if (font != null) buttonColumn.DefaultCellStyle.Font = font;
                else buttonColumn.DefaultCellStyle.Font = new Font("맑은 고딕", 10, FontStyle.Bold);
                dgv.Columns.Add(buttonColumn);

                // 헤더, 셀 높이 지정
                dgv.RowTemplate.Height = 30; // 모든 행의 기본 높이 설정
                dgv.BackgroundColor = Color.White;

                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = dt;

                dgv.DataSource = bindingSource;
            }
        }

        private void InventoryLabelPrint()
        {
            if (this.mtb_itemCd.Text.ToString().Trim().Equals(""))
            {
                MessageBox.Show("제품번호가 미존재, 제품을 선택하세요!", "확인");
                return;
            }
            else if (this.mtb_weight.Text.ToString().Trim().Equals(""))
            {
                MessageBox.Show("중량 미존재, 중량을 입력하세요!", "확인");
                return;
            }
            else if (this.mtb_count.Text.ToString().Trim().Equals("") || this.mtb_count.Text.ToString().Trim().Equals("0"))
            {
                MessageBox.Show("수량 미존재, 수량을 입력하세요!", "확인");
                return;
            }

            string pcm_item = this.mtb_itemCd.Text;
            int prt_cnt = Convert.ToInt32(this.mtb_printCnt.Text);
            string trace_no = this.mtb_traceNo.Text;

            if (string.IsNullOrWhiteSpace(trace_no))
            {
                MessageBox.Show("생산이력번호 미입력, 생산이력번호를 입력하세요!", "확인");
                this.mtb_traceNo.Focus();
                return;
            }

            Dictionary<string, object> dic = new Dictionary<string, object>();
            if (item_kind_cd == 1) // 한우일 경우
            {
                dic.Add("TEMP_DATE", temp_date);
                dic.Add("GBN", "L0");
                List<Dictionary<string, object>> traceDatasetNoList = pcmLabelQuery.GetTraceNoIsExistQry(dic, null);
                List<string> traceNoList = new List<string>();

                foreach (Dictionary<string, object> traceDic in traceDatasetNoList)
                {
                    traceNoList.Add(traceDic["TRACE_NO"].ToString());
                }

                if (!traceNoList.Contains(trace_no))
                {
                    MessageBox.Show($"""
                        존재하지 않는 생산이력번호 : {trace_no}
                        입력 가능 : {traceNoList.ToStringCustom()}
                        """);
                    this.mtb_traceNo.Text = "";
                    this.mtb_traceNo.Focus();
                    return;
                }
            }
            else if (item_kind_cd == 2) // 돈육일 경우
            {
                dic.Add("TEMP_DATE", temp_date);
                dic.Add("GBN", "L1");
                List<Dictionary<string, object>> traceDatasetNoList = pcmLabelQuery.GetTraceNoIsExistQry(dic, null);
                List<string> traceNoList = new List<string>();

                foreach (Dictionary<string, object> traceDic in traceDatasetNoList)
                {
                    traceNoList.Add(traceDic["TRACE_NO"].ToString());
                }

                if (!traceNoList.Contains(trace_no))
                {
                    MessageBox.Show($"""
                        존재하지 않는 생산이력번호 : {trace_no}
                        입력 가능 : {traceNoList.ToStringCustom()}
                        """, "존재하지 않는 생산이력번호");
                    this.mtb_traceNo.Text = "";
                    this.mtb_traceNo.Focus();
                    return;
                }
            }

            dic.Clear();
            dic.Add("PCM_ITEM", pcm_item);
            dt_yukgagongItem = Query.fn_createDataTable(pcmLabelQuery, q => ((PCMLabelQuery)q).GetYukGagongItemInfoQry(dic, null));

            string circul_date = dt_yukgagongItem.Rows[0]["CIRCUL_DATE"]?.ToString();
            if (Convert.ToInt32(circul_date).Equals("0"))
            {
                MessageBox.Show("[육가공 품목기준관리]유통기한 입력바랍니다.", "확인");
                return;
            }

            if (trace_no.Substring(0, 2).Equals("L1")) // 돈육
            {
                if (trace_no.Substring(8, 4).Equals("9995") || trace_no.Substring(8, 4).Equals("9195") || trace_no.Substring(8, 4).Equals("9925")) { }
                else
                {
                    MessageBox.Show("이력번호 입력확인 바랍니다.", "확인");
                    return;
                }

                if (dt_yukgagongKillArea != null) dt_yukgagongKillArea.Columns.Clear();
                dic.Clear();
                dic.Add("TRACE_NO", trace_no);
                dt_yukgagongKillArea = Query.fn_createDataTable(pcmLabelQuery, q => ((PCMLabelQuery)q).GetYukGagongKillAreaL1Qry(dic, null));
            }
            else if (trace_no.Substring(0, 2).Equals("L0")) // 한우
            {
                if (dt_yukgagongKillArea != null) dt_yukgagongKillArea.Columns.Clear();
                dic.Clear();
                dic.Add("TRACE_NO", trace_no);
                dt_yukgagongKillArea = Query.fn_createDataTable(pcmLabelQuery, q => ((PCMLabelQuery)q).GetYukGagongKillAreaL0Qry(dic, null));
            }

            this.pd_printDocument.PrinterSettings = printerSettings;
            this.pd_printDocument.DefaultPageSettings = pageSettings;

            // 미리보기
            this.ppd_printView.Document = this.pd_printDocument;
            this.ppd_printView.Width = 1000;
            this.ppd_printView.Height = 2000;

            ppd_printView.ShowDialog(); // 사용자 확인 후 실제 인쇄 아님 (Show()는 비동기, ShowDialog()는 동기)

            // 실제 출력 -- TODO 사용 시 
            /*
            for (int i = 0; i < Convert.ToInt32(this.mtb_printCnt.Text); i++)
            {
                this.pd_printDocument.Print();
            }
            */
        }

        private PointF DpiToMM(long width, long height)
        {
            return new PointF(mySelfLibrary.PowerBuilderToMilimeter(width), mySelfLibrary.PowerBuilderToMilimeter(height));
        }

        /* ********************---------------------------------------- */
        // Region : Event Functions 이벤트 함수
        /* ********************---------------------------------------- */
        private void btn_kindCd2_Click(object sender, EventArgs e)
        {
            this.btn_kindCd2.BackColor = Color.SkyBlue;
            this.btn_kindCd2.ForeColor = Color.White;

            this.btn_kindCd1.BackColor = Color.DarkGray;
            this.btn_kindCd1.ForeColor = DefaultForeColor;

            item_kind_cd = 2;
            fn_itemView(item_kind_cd);
        }

        private void btn_kindCd1_Click(object sender, EventArgs e)
        {
            this.btn_kindCd1.BackColor = Color.SkyBlue;
            this.btn_kindCd1.ForeColor = Color.White;

            this.btn_kindCd2.BackColor = Color.DarkGray;
            this.btn_kindCd2.ForeColor = DefaultForeColor;

            // 한우 클릭
            item_kind_cd = 1;
            fn_itemView(item_kind_cd);
        }

        // MAIN 셀 클릭
        private void dgv_item_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 클릭한 셀이 버튼 셀인지 확인
            if (this.dgv_item.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewButtonCell)
            {
                prevRowIndexDgvItem = e.RowIndex;
                prevColindexDgvItem = e.ColumnIndex;

                // 데이터 초기화
                this.dgv_subItem.Columns.Clear();
                // 클릭된 셀의 행 인덱스를 사용하여 ITEM_CD 열 값을 가져옴
                DataGridViewButtonCell buttonCell = (DataGridViewButtonCell)this.dgv_item.Rows[e.RowIndex].Cells[e.ColumnIndex];
                var cellData = (Dictionary<string, object>)buttonCell.Tag;
                item_main = cellData["ITEM_CD"].ToString();

                IsCoupangCheck();

                this.mtb_itemCd.Text = "";
                this.mtb_boxWt.Text = "1";
                this.mtb_count.Text = "1";
            }
            else
            {
                this.dgv_item.CurrentCell = this.dgv_item.Rows[prevRowIndexDgvItem].Cells[prevColindexDgvItem];
            }
        }

        private void dgv_item_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // 클릭한 셀이 버튼 셀인지 확인
            if (this.dgv_item.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewButtonCell)
            {
            }
            else
            {
                this.dgv_item.CurrentCell = this.dgv_item.Rows[prevRowIndexDgvItem].Cells[prevColindexDgvItem];
            }
        }

        // 쿠팡 체크 여부에 따라 dgv_subItem 필터
        private void cb_coupang_CheckedChanged(object sender, EventArgs e)
        {
            IsCoupangCheck();
        }

        // 상세제품 셀 클릭
        private void dgv_subItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 클릭한 셀이 버튼 셀인지 확인
            if (this.dgv_subItem.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewButtonCell)
            {
                // 품목정보 조회 (내수인것만 조회)
                dt_list = Query.fn_createDataTable(pcmLabelQuery, q => ((PCMLabelQuery)q).FindProductQry(null, null));

                prevRowIndexDgvSub = e.RowIndex;
                prevColIndexDgvSub = e.ColumnIndex;

                DataGridViewButtonCell buttonCell = (DataGridViewButtonCell)this.dgv_subItem.Rows[e.RowIndex].Cells[e.ColumnIndex];
                var cellData = (Dictionary<string, object>)buttonCell.Tag;
                item_cd = cellData["ITEM_CD"].ToString();

                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("TEMP_DATE", temp_date);
                dic.Add("ITEM_CD", item_cd);
                dt_yukgagongTraceInfo = Query.fn_createDataTable(pcmLabelQuery, q => ((PCMLabelQuery)q).GetTraceInfoQry(dic, null));
                // TODO -> 지금은 이해하기가 어려우니 그냥 이 로직은 없다면 그냥 빼고 진행하자
                // 지금 로직도 문제가 발생하는 부분이 라벨 발행 시 작업날짜에 라벨발행을 할 때, 과거 정보도 받아오니까 발생하는 문제인데
                // 과거정보도 가져오면서 생기는 크랙은 이 로직을 확실히 이해했을 때, 해결할 수 있다.
                dt_subItemDetail = Query.fn_createDataTable(pcmLabelQuery, q => ((PCMLabelQuery)q).GetSubItemDetailQry(dic, null));
                Grid_CellFormat2(dt_subItemDetail, this.dgv_traceInfo, "재고 라벨발행", null);

                this.mtb_itemCd.Text = item_cd;
                this.mtb_traceNo.Text = dt_yukgagongTraceInfo.Rows.Count > 0 ? dt_yukgagongTraceInfo.Rows[0]["TRACE_NO"]?.ToString() : "";
                this.mtb_printCnt.Focus();

                DataRow[] foundRows = dt_list.Select($"ITEM_CD = '{item_cd}'");
                if (foundRows.Length < 1)
                {
                    this.mtb_itemCd.Text = "";
                    return;
                }
                else
                {
                    this.mtb_boxWt.Text = string.Format("{0:0.00}", foundRows[0]["BASE_WT_COOL"].ToString()); // 기준 중량
                    this.mtb_weight.Text = string.Format("{0:0.00}", foundRows[0]["BASE_WT_COOL"].ToString()); // 중량
                }

                dic = new Dictionary<string, object>();
                dic.Add("ORDER_DATE", order_date);
                dic.Add("ITEM_CD", item_cd);

                dt_subItemOrderQtyEvery = Query.fn_createDataTable(pcmLabelQuery, q => ((PCMLabelQuery)q).GetOrderQtyEveryQry(dic, null));
                dt_subItemOrderQtyNotEvery = Query.fn_createDataTable(pcmLabelQuery, q => ((PCMLabelQuery)q).GetOrderQtyNotEveryQry(dic, null));
                this.mtb_orderQtyNotEvery.Text = dt_subItemOrderQtyNotEvery.Rows[0]["ORDER_QTY"].ToString();
                this.mtb_orderQtyEvery.Text = dt_subItemOrderQtyEvery.Rows[0]["ORDER_QTY"].ToString();

                int cnt = 0;
                if (this.cb_7day.Checked)
                {
                    cnt = Convert.ToInt32(dt_subItemOrderQtyEvery.Rows[0]["ORDER_QTY"]);
                    if (cnt > 0)
                    {
                        if (dt_subItemDetail.Rows.Count > 0)
                        {
                            cnt -= Convert.ToInt32(dt_subItemDetail.Rows[0]["WORK_FRZ2"]);
                        }
                    }
                }
                else
                {
                    cnt = Convert.ToInt32(dt_subItemOrderQtyNotEvery.Rows[0]["ORDER_QTY"]);
                    if (cnt > 0)
                    {
                        if (dt_subItemDetail.Rows.Count > 0)
                        {
                            cnt -= Convert.ToInt32(dt_subItemDetail.Rows[0]["WORK_FRZ2"]);
                        }
                    }
                }
                this.mtb_printCnt.Text = cnt.ToString();
            }
            else // 버튼 셀이 아닐 때,
            {
                this.dgv_subItem.CurrentCell = this.dgv_subItem.Rows[prevRowIndexDgvSub].Cells[prevColIndexDgvSub];
            }
        }

        private void dgv_subItem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // 클릭한 셀이 버튼 셀인지 확인
            if (this.dgv_subItem.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewButtonCell)
            {
            }
            else
            {
                this.dgv_subItem.CurrentCell = this.dgv_subItem.Rows[prevRowIndexDgvSub].Cells[prevColIndexDgvSub];
            }
        }
        // Value가 변경될 때,
        private void dtp_workDate_ValueChanged(object sender, EventArgs e)
        {
            temp_date = mySelfLibrary.DateTimeFormat((DateTimePicker)sender);
        }

        private void dtp_orderDate_ValueChanged(object sender, EventArgs e)
        {
            order_date = mySelfLibrary.DateTimeFormat((DateTimePicker)sender);

            // 주문일자를 변경 시키면, 에브리데이 라벨 발주량이 변경되고...
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("ORDER_DATE", order_date);
            dic.Add("ITEM_CD", item_cd);
            dt_subItemOrderQtyEvery = Query.fn_createDataTable(pcmLabelQuery, q => ((PCMLabelQuery)q).GetOrderQtyEveryQry(dic, null));
            this.mtb_orderQtyEvery.Text = dt_subItemOrderQtyEvery.Rows[0]["ORDER_QTY"]?.ToString();
        }

        private void btn_frzDiv1_Click(object sender, EventArgs e)
        {
            this.btn_frzDiv1.BackColor = Color.Blue;
            this.btn_frzDiv1.ForeColor = Color.White;
            this.btn_frzDiv2.BackColor = DefaultBackColor;
            this.btn_frzDiv2.ForeColor = DefaultForeColor;
            frz_div = 1;
            this.mtb_count.Focus();

            fn_itemView(item_kind_cd);
        }

        private void btn_frzDiv2_Click(object sender, EventArgs e)
        {
            this.btn_frzDiv1.BackColor = DefaultBackColor;
            this.btn_frzDiv1.ForeColor = DefaultForeColor;
            this.btn_frzDiv2.BackColor = Color.HotPink;
            this.btn_frzDiv2.ForeColor = Color.White;
            frz_div = 2;
            this.mtb_count.Focus();

            fn_itemView(item_kind_cd);
        }

        private void dgv_traceInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 2)
            {
                // 재고 라벨발행 버튼을 클릭하면,
                this.mtb_traceNo.Text = dt_subItemDetail.Rows[e.RowIndex]["TRACE_NO"]?.ToString();
                InventoryLabelPrint();
            }
        }

        // TODO - 여기서 .Print()만 호출해도 바로 호출 // 그리고 출력할 때는 반드시 발행개수에 맞춰서 발행할 수 있도록 수정해야함
        private void pd_printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            string trace_no = this.mtb_traceNo.Text;
            string change_bui = dt_yukgagongItem.Rows[0]["CHANGE_BUI"]?.ToString();
            string sub_bui = dt_yukgagongItem.Rows[0]["SUB_BUI"]?.ToString();
            string bui;
            string yongdo = dt_yukgagongItem.Rows[0]["YONGDO"]?.ToString();
            string item_name = dt_yukgagongItem.Rows[0]["ITEM_NAME"]?.ToString();
            string kill_area = dt_yukgagongKillArea.Rows[0]["KILL_AREA"]?.ToString();
            string sale_wt = dt_yukgagongItem.Rows[0]["SALE_WT"]?.ToString();
            string circul_date = dt_yukgagongItem.Rows[0]["CIRCUL_DATE"]?.ToString();
            string barcode = dt_yukgagongItem.Rows[0]["BARCODE"]?.ToString();
            string utong = mySelfDate.SubtractDaysToString(this.dtp_workDate.Text, Convert.ToInt32(circul_date) - 1);
            utong = utong.Substring(0, 4) + "." + utong.Substring(5, 2) + "." + utong.Substring(8, 2) + " 까지";

            if (Convert.ToDecimal(sale_wt) < 1)
            {
                sale_wt = Math.Round((Double)Convert.ToDecimal(sale_wt) * 1000, 0) + " g";
            }
            else
            {
                sale_wt += " kg";
            }

            if (this.cb_7day.Checked)
            {
                if (this.rdb_07.Checked)
                {
                    circul_date = "7";
                }
                else if (this.rdb_08.Checked)
                {
                    circul_date = "8";
                }
                else if (this.rdb_09.Checked)
                {
                    circul_date = "9";
                }
                else if (this.rdb_10.Checked)
                {
                    circul_date = "10";
                }
            }

            // 폰트 설정
            Font font1 = new Font("굴림체", 12, FontStyle.Regular);
            Font font2 = new Font("HYHeadLine", 14, FontStyle.Bold);
            Font font3 = new Font("HYHeadLine", 22, FontStyle.Regular);
            Font font4 = new Font("굴림체", 10, FontStyle.Regular);
            Font font5 = new Font("HYHeadLine", 10, FontStyle.Bold); // HY헤드라인M
            Font font6 = new Font("굴림체", 8); // Zebra 바코드용
            Font font7 = new Font("Code 128", 30); // Zebra 바코드용
            Font font8 = new Font("HYHeadLine", 16, FontStyle.Regular);

            // 좌표 - 프린트 설정
            long h_size = 1800 + 120; // PowerBuilder 기준
            long w_size = 300; // PowerBuilder 기준

            e.Graphics.PageUnit = GraphicsUnit.Millimeter; // 단위 mm로 수정

            // 제품명
            if (this.cb_longSize.Checked)
            {
                if (trace_no.Substring(0, 2).Equals("L0"))
                {
                    e.Graphics.DrawString("맑은고기 한우", font2, Brushes.Black, DpiToMM(w_size, h_size));
                }
                else
                {
                    e.Graphics.DrawString("포크밸리", font2, Brushes.Black, DpiToMM(w_size, h_size));
                }
            }
            else
            {
                if (trace_no.Substring(0, 2).Equals("L0"))
                {
                    e.Graphics.DrawString("맑은고기 한우", font2, Brushes.Black, DpiToMM(w_size, h_size - 120));
                }
                else
                {
                    e.Graphics.DrawString("포크밸리", font2, Brushes.Black, DpiToMM(w_size + 80, h_size - 120));
                }
            }

            // 부위명
            if (string.IsNullOrEmpty(change_bui))
            {
                bui = dt_yukgagongItem.Rows[0]["ITEM_MAIN"]?.ToString();
            }
            else
            {
                bui = change_bui;
            }

            // 서브부위명
            if (sub_bui != null)
            {
                bui += sub_bui;
            }

            // 긴라벨용
            if (this.cb_longSize.Checked)
            {
                // 부위명 대체가 있으면 내용이 길어짐으로 폰트조정
                if (change_bui == null)
                {
                    e.Graphics.DrawString(bui, font2, Brushes.Black, DpiToMM(w_size - 150, h_size + 550));
                }
                else
                {
                    e.Graphics.DrawString(bui, font5, Brushes.Black, DpiToMM(w_size - 200, h_size + 650));
                }

                int yongdoNecessaryIndex = yongdo.IndexOf(" ");
                // 용도
                if (yongdoNecessaryIndex > 0)
                {
                    e.Graphics.DrawString(yongdo.Substring(0, yongdoNecessaryIndex), font8, Brushes.Black, DpiToMM(w_size + 1250, h_size + 350));
                    e.Graphics.DrawString(yongdo.Substring(yongdoNecessaryIndex), font4, Brushes.Black, DpiToMM(w_size + 1150, h_size + 570));
                }
                else
                {
                    e.Graphics.DrawString(yongdo, font8, Brushes.Black, DpiToMM(w_size + 1250, h_size + 350));
                }

                if (item_name.IndexOf("무항생") > 0)
                {
                    e.Graphics.DrawString("(무항생제)", font5, Brushes.Black, DpiToMM(w_size + 450, h_size + 350));
                }

                // 중량
                e.Graphics.DrawString(sale_wt, font3, Brushes.Black, DpiToMM(w_size + 1400, h_size + 830));
                // 소비기한
                e.Graphics.DrawString(utong, font1, Brushes.Black, DpiToMM(w_size + 1100, h_size + 1430));
                // 도축장
                int killAreaNecessaryIndex = kill_area.IndexOf(",");
                if (killAreaNecessaryIndex > 0)
                {
                    e.Graphics.DrawString(kill_area.Substring(0, killAreaNecessaryIndex), font1, Brushes.Black, DpiToMM(w_size + 1100, h_size + 1700));
                    e.Graphics.DrawString(kill_area.Substring(killAreaNecessaryIndex), font1, Brushes.Black, DpiToMM(w_size + 1100, h_size + 1900));
                }
                else
                {
                    e.Graphics.DrawString(kill_area, font1, Brushes.Black, DpiToMM(w_size + 1100, h_size + 1900));
                }

                if (trace_no.Substring(0, 2).Equals("L0"))
                {
                    e.Graphics.DrawString("201706086472", font1, Brushes.Black, DpiToMM(w_size - 150, h_size + 2380));
                }
                else
                {
                    e.Graphics.DrawString("201706086471", font1, Brushes.Black, DpiToMM(w_size - 150, h_size + 2380));
                }

                // 생산이력번호
                e.Graphics.DrawString(trace_no, font1, Brushes.Black, DpiToMM(w_size + 1100, h_size + 2380));
            }
            else // 짧은 라벨용
            {
                // 부위명 대체가 있으면 내용이 길어짐으로 폰트조정
                if (change_bui == null)
                {
                    e.Graphics.DrawString(bui, font2, Brushes.Black, DpiToMM(w_size - 150, h_size + 300));
                }
                else
                {
                    e.Graphics.DrawString(bui, font5, Brushes.Black, DpiToMM(w_size - 200, h_size + 300));
                }

                // 용도
                int yongdoNecessaryIndex = yongdo.IndexOf(" ");
                if (yongdoNecessaryIndex > 0)
                {
                    e.Graphics.DrawString(yongdo.Substring(0, yongdoNecessaryIndex), font8, Brushes.Black, DpiToMM(w_size + 1250, h_size + 200));
                    e.Graphics.DrawString(yongdo.Substring(yongdoNecessaryIndex), font4, Brushes.Black, DpiToMM(w_size + 1150, h_size + 420));
                }
                else
                {
                    e.Graphics.DrawString(yongdo, font8, Brushes.Black, DpiToMM(w_size + 1250, h_size + 150));
                }

                // 중량
                e.Graphics.DrawString(sale_wt, font3, Brushes.Black, DpiToMM(w_size + 1400, h_size + 530));
                // 소비기한
                e.Graphics.DrawString(utong, font1, Brushes.Black, DpiToMM(w_size + 1100, h_size + 1000));
                // 도축장
                int killAreaNecessaryIndex = kill_area.IndexOf(",");
                if (killAreaNecessaryIndex > 0)
                {
                    e.Graphics.DrawString(kill_area.Substring(0, killAreaNecessaryIndex), font1, Brushes.Black, DpiToMM(w_size + 1100, h_size + 1250));
                    e.Graphics.DrawString(kill_area.Substring(killAreaNecessaryIndex), font1, Brushes.Black, DpiToMM(w_size + 1100, h_size + 1450));
                }
                else
                {
                    e.Graphics.DrawString(kill_area, font1, Brushes.Black, DpiToMM(w_size + 1100, h_size + 1400));
                }

                if (trace_no.Substring(0, 2).Equals("L0"))
                {
                    e.Graphics.DrawString("201706086472", font1, Brushes.Black, DpiToMM(w_size - 150, h_size + 1750));
                }
                else
                {
                    e.Graphics.DrawString("201706086471", font1, Brushes.Black, DpiToMM(w_size - 150, h_size + 1750));
                }

                // 생산이력번호
                e.Graphics.DrawString(trace_no, font1, Brushes.Black, DpiToMM(w_size + 1000, h_size + 1750));
            }

            if (trace_no.Substring(0, 2).Equals("L0"))
            {
                // 88코드
                e.Graphics.DrawString(printerManage.Fn_Barcode128(barcode), font7, Brushes.Black, DpiToMM(w_size, h_size + 3360));
                e.Graphics.DrawString(new string(' ', 30), font4, Brushes.Black, DpiToMM(w_size, h_size + 3780));
                SizeF sizeBar = e.Graphics.MeasureString(barcode, font6).ToSize();
                PointF pointBar = DpiToMM(w_size + 400, h_size + 3680);
                e.Graphics.FillRectangle(Brushes.White, new RectangleF(pointBar.X, pointBar.Y, sizeBar.Width, sizeBar.Height));
                e.Graphics.DrawString(barcode, font6, Brushes.Black, DpiToMM(w_size + 400, h_size + 3680));

                // 등급
                if (sub_bui.Equals("(1+등급)"))
                {
                    e.Graphics.DrawString("등급: 1++        1   2   등외", font1, Brushes.Black, DpiToMM(w_size - 150, h_size + 3230));
                    SizeF size = e.Graphics.MeasureString("○", font3).ToSize();
                    PointF point = DpiToMM(w_size + 840, h_size + 3160);
                    e.Graphics.FillRectangle(Brushes.White, new RectangleF(point.X, point.Y, size.Width - 6, size.Height - 1));
                    e.Graphics.DrawString("○", font3, Brushes.Black, DpiToMM(w_size + 840, h_size + 3160));
                    e.Graphics.DrawString("1+", font1, Brushes.Black, DpiToMM(w_size + 900, h_size + 3230));
                }
                else
                {
                    e.Graphics.DrawString("등급: 1++   1+       2   등외", font1, Brushes.Black, DpiToMM(w_size - 150, h_size + 3230));
                    SizeF size = e.Graphics.MeasureString("○", font3).ToSize();
                    PointF point = DpiToMM(w_size + 1230, h_size + 3160);
                    e.Graphics.FillRectangle(Brushes.White, new RectangleF(point.X + 1.5f, point.Y - 1f, size.Width - 1f, size.Height));
                    e.Graphics.DrawString("○", font3, Brushes.Black, DpiToMM(w_size + 1230, h_size + 3160));
                    e.Graphics.DrawString("1", font1, Brushes.Black, DpiToMM(w_size + 1320, h_size + 3230));
                }
            }
            else
            {
                if (this.cb_88.Checked)
                {
                    // 긴 라벨 88 코드
                    if (this.cb_longSize.Checked)
                    {
                        e.Graphics.DrawString(printerManage.Fn_Barcode128(barcode), font7, Brushes.Black, DpiToMM(w_size + 200, h_size + 4400));
                        SizeF sizeBar = e.Graphics.MeasureString(barcode, font1).ToSize();
                        PointF pointBar = DpiToMM(w_size + 400, h_size + 4850);
                        e.Graphics.FillRectangle(Brushes.White, new RectangleF(pointBar.X, pointBar.Y, sizeBar.Width, sizeBar.Height));
                        e.Graphics.DrawString(barcode, font1, Brushes.Black, DpiToMM(w_size + 400, h_size + 4850));
                    }
                    else // 짧은 라벨 88 코드
                    {
                        e.Graphics.DrawString(printerManage.Fn_Barcode128(barcode), font7, Brushes.Black, DpiToMM(w_size, h_size + 3300));
                        e.Graphics.DrawString(new string(' ', 30), font4, Brushes.Black, DpiToMM(w_size, h_size + 3640));
                        SizeF sizeBar = e.Graphics.MeasureString(barcode, font6).ToSize();
                        PointF pointBar = DpiToMM(w_size + 400, h_size + 3540);
                        e.Graphics.FillRectangle(Brushes.White, new RectangleF(pointBar.X, pointBar.Y, sizeBar.Width, sizeBar.Height));
                        e.Graphics.DrawString(barcode, font6, Brushes.Black, DpiToMM(w_size + 400, h_size + 3540));
                    }
                }
            }

            // 마지막 페이지 명시
            e.HasMorePages = false;
        }

        // 대용기 라벨 클릭 시 (색깔 변경)
        private void cb_longSize_Click(object sender, EventArgs e)
        {
            if (this.cb_longSize.Checked)
            {
                this.cb_longSize.BackColor = Color.FromArgb(000, 255, 000);
            }
            else
            {
                this.cb_longSize.BackColor = Color.FromArgb(204, 204, 204);
            }
        }

        // 에브리데이 라벨 클릭시 발행수량 초기화 혹은 생성
        private void cb_7day_Click(object sender, EventArgs e)
        {
            int cnt = 0;
            if (this.cb_7day.Checked)
            {
                this.cb_7day.BackColor = Color.FromArgb(000, 102, 255);

                cnt = Convert.ToInt32(dt_subItemOrderQtyEvery.Rows[0]["ORDER_QTY"]);
                if (cnt > 0)
                {
                    if (dt_subItemDetail.Rows.Count > 0)
                    {
                        cnt -= Convert.ToInt32(dt_subItemDetail.Rows[0]["WORK_FRZ2"]);
                    }
                }
            }
            else
            {
                this.cb_7day.BackColor = Color.FromArgb(204, 204, 204);

                cnt = Convert.ToInt32(dt_subItemOrderQtyNotEvery.Rows[0]["ORDER_QTY"]);
                if (cnt > 0)
                {
                    if (dt_subItemDetail.Rows.Count > 0)
                    {
                        cnt -= Convert.ToInt32(dt_subItemDetail.Rows[0]["WORK_FRZ2"]);
                    }
                }
            }
            this.mtb_printCnt.Text = cnt.ToString();
        }

        // 공용 포커스 On
        private void mtb_selectAll(object sender, EventArgs e)
        {
            if (sender is MaskedTextBox mtb)
            {
                mtb.SelectAll();
            }
        }

        // Printer 팝업 설정 창 오픈
        private void btn_popupPrint_Click(object sender, EventArgs e)
        {
            using (PCMLabelForm_P1 popup = new PCMLabelForm_P1(printerSettings, pageSettings))
            {
                var result = popup.ShowDialog(); // 이 시점부터 모달 창이라 부모창 클릭 안됨
                if (result == DialogResult.OK)
                {
                    printerSettings = popup.printerSettings;
                    pageSettings = popup.pageSettings;
                }
            }
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            // 라벨 발행이 클릭되었을 때, 조건 추가
            /*
             * PCM묶음번호관리 > 재묶음번호별 생산제품 > 존재하지 않으면 재묶음구성에 추가할 수 없는데
             * 일부로 재묶음번호를 생성하고자하는 게 존재함 (미리 출력)
             * 따라서 작성할 때, 재묶음번호를 생성하고 
             */
            // 프린트
            InventoryLabelPrint();
        }
        // 종료
        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }
    }
}