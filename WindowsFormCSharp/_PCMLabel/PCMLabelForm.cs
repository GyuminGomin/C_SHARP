using System.Data;
using System.Drawing.Printing;
using System.Reflection.Metadata.Ecma335;

namespace WindowsFormCSharp._PCMLabel
{
    public partial class PCMLabelForm : Form
    {
        // 이거는 제일 위에 둔 이유 : 폼이 열릴 때 초기에 셋팅할 수 있기 때문 (가시적이어야 한다.)
        private void PCMLabelForm_Load_1(object sender, EventArgs e)
        {
            // 시작 시 돈육 버튼 강제 클릭
            this.btn_kindCd2.PerformClick();
        }

        /* ********************---------------------------------------- */
        // Region : Global Variables 전역 변수
        /* ********************---------------------------------------- */
        PCMLabelQuery pcmLabelQuery = new PCMLabelQuery();
        MySelfLibrary mySelfLibrary = new MySelfLibrary();
        MySelfStyle mySelfStyle = new MySelfStyle();
        private PrinterSettings printerSettings;
        private PageSettings pageSettings;

        private string tmp_box; // 현 box에 부여할 box no
        private string temp_date; // 정보 처리를 위한 일자 (작업일자)
        private string order_date; // 정보 처리를 위한 일자 (주문일자)
        private int kind_cd = 7; // 사업구분
        private int item_kind_cd; // 제품구분 (1: 한우, 2: 돈육)
        private string item_main; // 대표품목코드
        private string item_cd; // 제품코드
        private int frz_div = 2; // 냉장구분(1: 냉동, 2: 냉장)
        private string last_grd; // 등급
        private int box_flag = 1; // 묶음발행 구분
        private int sum_cnt; // 묶음번호에 합산된 BOX_NO count
        private int sum_wt; // 묶음번호에 합산된 BOX_WT
        private long m_PortNumber = 1; // 1~2 : Serial Port, 3 : USB Port

        private bool btn_toggleKindCd = false;


        /* ********************---------------------------------------- */
        // Region : Local Variables 지역 변수 ( DataTable )
        /* ********************---------------------------------------- */
        private DataTable dt_list;
        private DataTable dt_subItem;
        private DataTable dt_subItemEngName;
        private DataTable dt_subItemDetail;
        private DataTable dt_subItemOrderQtyEvery;
        private DataTable dt_subItemOrderQtyNotEvery;
        /* ********************---------------------------------------- */
        // Region : Functions 직접만든 함수
        /* ********************---------------------------------------- */
        public PCMLabelForm(PrinterSettings ps, PageSettings ps2)
        {
            InitializeComponent();
            // 프린트 설정
            printerSettings = ps;
            pageSettings = ps2;

            fn_init();
        }

        private void PCMLabelForm_Load(object sender, EventArgs e)
        {
            // 처음 시작 시 돈육 클릭 상태 (강제로 부여)
            // 반드시 Form_Load에서만 작동 가능함
            this.btn_kindCd2.PerformClick();
        }

        private void fn_init()
        {
            // temp_date, order_date 초기 값 가져오기
            temp_date = mySelfLibrary.DateTimeFormat(this.dtp_workDate);
            order_date = mySelfLibrary.DateTimeFormat(this.dtp_orderDate);

            long ll_ret1; // 조건형 변수
            string ls_group_code; // 그룹코드
            // 품목정보 조회 (내수인것만 조회)
            dt_list = Query.fn_createDataTable(pcmLabelQuery, q => ((PCMLabelQuery)q).FindProductQry(null, null));

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
            // TODO - 아직 이 위는 필요한 곳을 찾질 못함


            mySelfStyle.DataGridViewRectangle(this.dgv_item);
            mySelfStyle.DataGridViewRectangle(this.dgv_subItem);

            // 초기 버튼 설정
            this.btn_kindCd2.FlatStyle = FlatStyle.Flat;
            this.btn_kindCd2.FlatAppearance.BorderSize = 0;
            this.btn_kindCd2.BackColor = Color.SkyBlue;
            this.btn_kindCd2.ForeColor = Color.White;
            this.btn_kindCd1.FlatStyle = FlatStyle.Flat;
            this.btn_kindCd1.FlatAppearance.BorderSize = 0;
            this.btn_kindCd1.BackColor = DefaultBackColor;
            this.btn_kindCd1.ForeColor = DefaultForeColor;
            this.btn_frzDiv2.BackColor = Color.HotPink;
            this.btn_frzDiv2.ForeColor = Color.White;
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
                } else 
                {
                    this.btn_kindCd2.PerformClick();
                    return;
                }
                    this.tb_status.Text = "3";
            }

            // 처음에 있는 Cell 강제 클릭
            int rowIndex = 0;
            int colIndex = 0;
            this.dgv_item.CurrentCell = this.dgv_item.Rows[rowIndex].Cells[colIndex];
            // CellClick 이벤트 강제 호출
            DataGridViewCellEventArgs args = new DataGridViewCellEventArgs(colIndex, rowIndex);
            dgv_item_CellClick(dgv_item, args);
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
            int totalCells = ((dt.Rows.Count-1) / 5 + 1) * 5; // 전체 버튼 셀 개수
            for (int i = dt.Rows.Count; i < totalCells; i++)
            {
                int rowIndex = i / 5;
                int colIndex = i % 5;
                dgv.Rows[rowIndex].Cells[colIndex] = new DataGridViewTextBoxCell();
                dgv.Rows[rowIndex].Cells[colIndex].ReadOnly = true;
            }
        }

        private void IsCoupangCheck()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("ITEM_MAIN", item_main);
            if (this.cb_coupang.Checked) // 체크 상태일 때 1등급이상 필터링 필요
            {
                if (frz_div == 1)
                {
                    // 냉동일 때, 필터링 추가
                    this.dgv_subItem.Columns.Clear();
                    dt_subItemEngName = Query.fn_createDataTable(pcmLabelQuery, q => ((PCMLabelQuery)q).GetSubItemFilterEngNameQry(dic, null));
                    DataTable filteredDataTable = dt_subItemEngName.Clone();
                    DataRow[] filteredRow = dt_subItemEngName.Select("FRZ_DIV3 = 1");
                    foreach (DataRow row in filteredRow)
                    {
                        filteredDataTable.ImportRow(row);
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
                    DataRow[] filteredRow = dt_subItem.Select("FRZ_DIV3 = 1");
                    foreach (DataRow row in filteredRow)
                    {
                        filteredDataTable.ImportRow(row);
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
        }

        /* ********************---------------------------------------- */
        // Region : Event Functions 이벤트 함수
        /* ********************---------------------------------------- */
        private void btn_kindCd2_Click(object sender, EventArgs e)
        {
            this.btn_kindCd2.BackColor = Color.SkyBlue;
            this.btn_kindCd2.ForeColor = Color.White;

            this.btn_kindCd1.BackColor = DefaultBackColor;
            this.btn_kindCd1.ForeColor = DefaultForeColor;

            item_kind_cd = 2;
            fn_itemView(item_kind_cd);
        }

        private void btn_kindCd1_Click(object sender, EventArgs e)
        {
            this.btn_kindCd1.BackColor = Color.SkyBlue;
            this.btn_kindCd1.ForeColor = Color.White;

            this.btn_kindCd2.BackColor = DefaultBackColor;
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
                this.mtb_printCnt.Focus();
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
                DataGridViewButtonCell buttonCell = (DataGridViewButtonCell)this.dgv_subItem.Rows[e.RowIndex].Cells[e.ColumnIndex];
                var cellData = (Dictionary<string, object>)buttonCell.Tag;
                item_cd = cellData["ITEM_CD"].ToString();

                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("TEMP_DATE", temp_date);
                dic.Add("ITEM_CD", item_cd);
                var info = pcmLabelQuery.GetTraceInfo(dic, null);
                dt_subItemDetail = Query.fn_createDataTable(pcmLabelQuery, q => ((PCMLabelQuery)q).GetSubItemDetail(dic, null));
                this.dgv_traceInfo.DataSource = dt_subItemDetail;

                this.mtb_itemCd.Text = item_cd;
                this.mtb_traceNo.Text = info.Count == 0 ? "" : (string)info[0]["TRACE_NO"];
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

                dt_subItemOrderQtyEvery = Query.fn_createDataTable(pcmLabelQuery, q => ((PCMLabelQuery)q).GetOrderQtyEvery(dic, null));
                dt_subItemOrderQtyNotEvery = Query.fn_createDataTable(pcmLabelQuery, q => ((PCMLabelQuery)q).GetOrderQtyNotEvery(dic, null));
                this.mtb_orderQtyNotEvery.Text = dt_subItemOrderQtyNotEvery.Rows[0]["ORDER_QTY"].ToString();
                this.mtb_orderQtyEvery.Text = dt_subItemOrderQtyEvery.Rows[0]["ORDER_QTY"].ToString();

                int cnt = 0;
                if (this.cb_7day.Checked)
                {
                    if (dt_subItemOrderQtyEvery.Rows.Count > 0)
                    {
                        cnt = dt_subItemOrderQtyEvery.Rows[0]["ORDER_QTY"] == DBNull.Value ? 0 : Convert.ToInt32(dt_subItemOrderQtyEvery.Rows[0]["ORDER_QTY"]);
                        if (dt_subItemDetail.Rows.Count > 0)
                        {
                            cnt -= dt_subItemDetail.Rows[0]["WORK_FRZ2"] == DBNull.Value ? 0 : Convert.ToInt32(dt_subItemDetail.Rows[0]["WORK_FRZ2"]);
                        }
                    }
                }
                else
                {
                    if (dt_subItemOrderQtyNotEvery.Rows.Count > 0)
                    {
                        cnt = dt_subItemOrderQtyNotEvery.Rows[0]["ORDER_QTY"] == DBNull.Value ? 0 : Convert.ToInt32(dt_subItemOrderQtyNotEvery.Rows[0]["ORDER_QTY"]);
                        if (dt_subItemDetail.Rows.Count > 0)
                        {
                            cnt -= dt_subItemDetail.Rows[0]["WORK_FRZ2"] == DBNull.Value ? 0 : Convert.ToInt32(dt_subItemDetail.Rows[0]["WORK_FRZ2"]);
                        }
                    }
                }
                this.mtb_printCnt.Text = cnt.ToString();
            }
        }

        // Value가 변경될 때,
        private void dtp_workDate_ValueChanged(object sender, EventArgs e)
        {
            temp_date = mySelfLibrary.DateTimeFormat(this.dtp_workDate);
        }

        private void dtp_orderDate_ValueChanged(object sender, EventArgs e)
        {
            order_date = mySelfLibrary.DateTimeFormat(this.dtp_orderDate);
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
    }
}
