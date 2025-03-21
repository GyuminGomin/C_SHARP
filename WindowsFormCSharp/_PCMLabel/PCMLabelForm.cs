using System.Data;
using System.Drawing.Printing;
using System.Windows.Forms.VisualStyles;
using WindowsFormCSharp._PCMLabel.Query;
using WindowsFormCSharp.Query;

namespace WindowsFormCSharp._PCMLabel
{
    public partial class PCMLabelForm : Form
    {

        /* ********************---------------------------------------- */
        // Region : Local Variables 지역 변수
        /* ********************---------------------------------------- */
        PCMLabelQuery pcmLabelQuery = new PCMLabelQuery();
        private PrinterSettings printerSettings;
        private PageSettings pageSettings;

        private int rowno;
        private string tmp_box; // 현 box에 부여할 box no
        private string temp_date; // 정보 처리를 위한 일자
        private string trace_date; // 정보 처리를 위한 일자
        private int kind_cd = 7; // 사업구분
        private string item_cd; // 제품코드
        private int frz_div = 2; // 냉장구분(1: 냉동, 2: 냉장)
        private string item_main; // 대표품목코드
        private string last_grd; // 등급
        private int box_flag = 1; // 묶음발행 구분
        private int sum_cnt; // 묶음번호에 합산된 BOX_NO count
        private int sum_wt; // 묶음번호에 합산된 BOX_WT
        private long m_PortNumber = 1; // 1~2 : Serial Port, 3 : USB Port
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

        private void fn_init()
        {
            long ll_ret1; // 조건형 변수
            string ls_group_code; // 그룹코드
            string dtp_workDate = this.dtp_workDate.Value.ToString();
            temp_date = dtp_workDate.Substring(0, 4) + dtp_workDate.Substring(5, 2) + dtp_workDate.Substring(8, 2); // 작업일자
            // 품목정보 조회 (내수인것만 조회)
            var result = pcmLabelQuery.FindProductQry(null);

            // 수량
            this.mtb_sleCount.Text = "1";
            // 발행수량
            this.mtb_printCnt.Text = "1";

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

            // 초기 데이터 그리드 뷰 설정
            this.dgv_item.ColumnHeadersVisible = false;
            this.dgv_item.RowHeadersVisible = false;
            this.dgv_item.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_item.AllowUserToAddRows = false;
            this.dgv_item.AllowUserToResizeRows = false;
            this.dgv_item.AllowUserToResizeColumns = false;
            //this.dgv_kindCd.CellBorderStyle = DataGridViewCellBorderStyle.None;
            //this.dgv_kindCd.DefaultCellStyle.SelectionBackColor = this.dgv_kindCd.DefaultCellStyle.BackColor;
            //this.dgv_kindCd.DefaultCellStyle.SelectionForeColor = this.dgv_kindCd.DefaultCellStyle.ForeColor;
            this.dgv_item.RowTemplate.Height = 70;

            fn_openDwList(2);

        }

        private void fn_openDwList(int kind_cd_tmp)
        {
            DataTable dataTable;
            Dictionary<string, object> dict;
            if (kind_cd_tmp == 2)
            {
                if (frz_div == 2)
                {
                    dict = new Dictionary<string, object>();
                    dict.Add("KIND_CD", "7150__");
                    dataTable = Qry.fn_createDataTable(pcmLabelQuery, q => ((PCMLabelQuery)q).GetItemCdKindQry(dict));

                    this.btn_kindCd1.Enabled = true;

                    Grid_CellFormat(dataTable, this.dgv_item);
                }
                else
                {
                    dict = new Dictionary<string, object>();
                    dict.Add("KIND_CD", "710155");
                    dataTable = Qry.fn_createDataTable(pcmLabelQuery, q => ((PCMLabelQuery)q).GetItemCdKindQry(dict));

                    this.btn_kindCd1.Enabled = false;

                    Grid_CellFormat(dataTable, this.dgv_item);
                }
                this.tb_status.Text = "";

            }
            else if (kind_cd_tmp == 1)
            {
                if (frz_div == 2)
                {

                }
                else
                {

                }
                this.tb_status.Text = "3";
            }
        }

        /*
         * DataGridView에 dataTable (1열) 데이터 바인딩 (5열로 나누어서)
         */
        private void Grid_CellFormat(DataTable dt, DataGridView dgv)
        {
            // 각 열에 버튼 추가
            for (int i = 0; i < 5; i++)
            {
                DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                buttonColumn.FlatStyle = FlatStyle.Popup;
                buttonColumn.DefaultCellStyle.BackColor = Color.White;
                buttonColumn.DefaultCellStyle.ForeColor = Color.Black;
                buttonColumn.DefaultCellStyle.SelectionBackColor = Color.Blue;
                buttonColumn.DefaultCellStyle.SelectionForeColor = Color.White;
                buttonColumn.FillWeight = 0.15f;
                dgv.Columns.Add(buttonColumn);
            }
            // 데이터 바인딩
            int count = 0;
            foreach (DataRow row in dt.Rows)
            {
                if (count % 5 == 0)
                {
                    dgv.Rows.Add();
                }
                int rowIndex = count / 5;
                int colIndex = count % 5;
                dgv.Rows[rowIndex].Cells[colIndex].Value = row[0].ToString();
                count++;
            }
        }

    }
}
