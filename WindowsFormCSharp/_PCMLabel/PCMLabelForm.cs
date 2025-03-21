using System.Data;
using System.Drawing.Printing;

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

        private int rowno;
        private string tmp_box; // 현 box에 부여할 box no
        private string temp_date; // 정보 처리를 위한 일자
        private string trace_date; // 정보 처리를 위한 일자
        private int kind_cd = 7; // 사업구분
        private int item_kind_cd; // 제품구분 (1: 한우, 2: 돈육)
        private int item_cd; // 제품코드
        private int frz_div = 2; // 냉장구분(1: 냉동, 2: 냉장)
        private string item_main; // 대표품목코드
        private string last_grd; // 등급
        private int box_flag = 1; // 묶음발행 구분
        private int sum_cnt; // 묶음번호에 합산된 BOX_NO count
        private int sum_wt; // 묶음번호에 합산된 BOX_WT
        private long m_PortNumber = 1; // 1~2 : Serial Port, 3 : USB Port

        private bool btn_toggleKindCd = false;
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
            long ll_ret1; // 조건형 변수
            string ls_group_code; // 그룹코드
            string dtp_workDate = this.dtp_workDate.Value.ToString();
            temp_date = dtp_workDate.Substring(0, 4) + dtp_workDate.Substring(5, 2) + dtp_workDate.Substring(8, 2); // 작업일자
            // 품목정보 조회 (내수인것만 조회)
            var result = pcmLabelQuery.FindProductQry(null);

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
            this.btn_kindCd1.BackColor = DefaultBackColor;
            this.btn_kindCd1.ForeColor = DefaultForeColor;
        }

        private void fn_openDwList(int item_kind_cd)
        {
            DataTable dataTable;
            Dictionary<string, object> dict;
            if (item_kind_cd == 2)
            {
                if (frz_div == 2) // 냉장
                {
                    dict = new Dictionary<string, object>();
                    dict.Add("KIND_CD", "7150__");
                    dataTable = Query.fn_createDataTable(pcmLabelQuery, q => ((PCMLabelQuery)q).GetItemCdKindQry(dict));

                    this.btn_kindCd1.Enabled = true;

                    Grid_CellFormat(dataTable, this.dgv_item, "ITEM_NAME", null);
                }
                else // 냉동
                {
                    dict = new Dictionary<string, object>();
                    dict.Add("KIND_CD", "710155");
                    dataTable = Query.fn_createDataTable(pcmLabelQuery, q => ((PCMLabelQuery)q).GetItemCdKindQry(dict));

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
                    dataTable = Query.fn_createDataTable(pcmLabelQuery, q => ((PCMLabelQuery)q).GetItemCdKindQry(dict));

                    Grid_CellFormat(dataTable, this.dgv_item, "ITEM_NAME", null);
                }
                this.tb_status.Text = "3";
            }
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
            fn_openDwList(item_kind_cd);
            // 돈육 클릭 시 처음에 있는 Cell 강제 클릭
            int rowIndex = 0;
            int colIndex = 0;
            this.dgv_item.CurrentCell = this.dgv_item.Rows[rowIndex].Cells[colIndex];
            // CellClick 이벤트 강제 호출
            DataGridViewCellEventArgs args = new DataGridViewCellEventArgs(colIndex, rowIndex);
            dgv_item_CellClick(dgv_item, args);
        }

        private void btn_kindCd1_Click(object sender, EventArgs e)
        {
            this.btn_kindCd1.BackColor = Color.SkyBlue;
            this.btn_kindCd1.ForeColor = Color.White;

            this.btn_kindCd2.BackColor = DefaultBackColor;
            this.btn_kindCd2.ForeColor = DefaultForeColor;

            // 한우 클릭
            item_kind_cd = 1;
            fn_openDwList(item_kind_cd);
            // 한우 클릭 시 처음에 있는 Cell 강제 클릭
            int rowIndex = 0;
            int colIndex = 0;
            this.dgv_item.CurrentCell = this.dgv_item.Rows[rowIndex].Cells[colIndex];
            // CellClick 이벤트 강제 호출
            DataGridViewCellEventArgs args = new DataGridViewCellEventArgs(colIndex, rowIndex);
            dgv_item_CellClick(dgv_item, args);
        }

        private void dgv_item_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 데이터 초기화
            this.dgv_subItem.Columns.Clear();
            // 클릭된 셀의 행 인덱스를 사용하여 ITEM_CD 열 값을 가져옴
            DataGridViewButtonCell buttonCell = (DataGridViewButtonCell)dgv_item.Rows[e.RowIndex].Cells[e.ColumnIndex];
            var cellData = (Dictionary<string, object>)buttonCell.Tag;
            item_main = cellData["ITEM_CD"].ToString();

            Dictionary<string, object> dict = new Dictionary<string, object>();
            DataTable dataTable = new DataTable();
            dict.Add("ITEM_MAIN", item_main);
            dataTable = Query.fn_createDataTable(pcmLabelQuery, q => ((PCMLabelQuery)q).GetSubItemCdKindQry(dict));

            Grid_CellFormat(dataTable, this.dgv_subItem, "ITEM_NAME", new Font("맑은 고딕", 10, FontStyle.Bold));

            this.mtb_itemCd.Text = "";
            this.mtb_boxWt.Text = mySelfLibrary.NumberFormatIntToString(1);
            this.mtb_count.Text = mySelfLibrary.NumberFormatIntToString(1);
            this.mtb_printCnt.Focus();
        }

        // TODO - subDataTable 필터링 필요
        private void cb_coupang_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cb_coupang.Checked)
            {
                string filterEngName = "1등급이상";

                DataGridView dgv = this.dgv_subItem;

                for (int rowIndex = 0; rowIndex < dgv.Rows.Count; rowIndex++)
                {
                    for (int colIndex = 0; colIndex < dgv.Columns.Count; colIndex++)
                    {
                        // 각 셀의 Tag에서 Dictionary<string, object> 가져오기
                        var cellData = dgv.Rows[rowIndex].Cells[colIndex].Tag;
                    }
                }
            } else
            {

            }
        }
    }
}
