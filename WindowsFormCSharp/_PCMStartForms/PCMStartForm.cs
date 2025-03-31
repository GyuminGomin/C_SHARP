using System.Drawing.Printing;
using WindowsFormCSharp._PCMLabel;
using WindowsFormCSharp._PCMLabelProdStdForms;

namespace WindowsFormCSharp._PCMStartForms
{
    public partial class PCMStartForm : Form
    {
        private PrinterSettings printerSettings = new PrinterSettings();
        private PageSettings pageSettings;

        public PCMStartForm(PrinterSettings ps1, PageSettings ps2)
        {
            InitializeComponent();

            // 부경양돈농협 로고 설정
            string[] images = new string[1];
            images[0] = "logo.png";
            Bitmap[] bmps = ImageManage.ImgtoBitmap(images);
            this.pb_logo.Image = bmps[0];

            if (ps1 == null) { }
            else
            {
                printerSettings = ps1;
                pageSettings = ps2;
            }
            // comboBox 프린트 설정
            PrinterManage printManage = new PrinterManage();
            printManage.PrintSetting(this.cbm_01, this.rtb_02, this.btn_01, printerSettings, pageSettings);
        }

        // TODO tab index 이동 할 때, 프린트 설정은 이동하지 않도록 설정할 필요가 있음

        

        private void PCMStartForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (MessageBox.Show("앱을 종료하시겠습니까?", "종료", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    // 앱 종료
                    Application.Exit();
                }
            }
        }
        // 기본라벨발행
        private void btn_bowl_Click(object sender, EventArgs e)
        {
            new PCMLabelForm(printerSettings, pageSettings).Show();
            this.Close(); // 기존 창 닫기
        }
        // 일반냉장라벨발행
        private void btn_refrigeration_Click(object sender, EventArgs e)
        {
            new PCMLabelProdStdForm(printerSettings, pageSettings).Show();
            this.Close();
        }
    }
}
