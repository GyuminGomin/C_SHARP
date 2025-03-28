using System.Drawing.Printing;

namespace WindowsFormCSharp._PCMLabel
{
    public partial class PCMLabelForm_P1 : Form
    {
        public PCMLabelForm_P1(PrinterSettings ps, PageSettings ps2)
        {
            InitializeComponent();
            printerSettings = ps;
            pageSettings = ps2;

            printerSet();
        }
        /* ********************---------------------------------------- */
        // Region : Global Variables 전역 변수
        /* ********************---------------------------------------- */
        public PrinterSettings printerSettings;
        public PageSettings pageSettings;

        /* ********************---------------------------------------- */
        // Region : Functions 직접만든 함수
        /* ********************---------------------------------------- */
        private void printerSet()
        {
            // comboBox 프린트 설정
            PrinterManage printManage = new PrinterManage();
            printManage.PrintSetting(this.cbm_01, this.rtb_02, this.btn_01, printerSettings, pageSettings);
        }

        private void PCMLabelForm_P1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "설정을 완료하시겠습니까?",
                "확인",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Cancel )
            {
                e.Cancel = true; // 닫기 취소
            } else
            {
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
