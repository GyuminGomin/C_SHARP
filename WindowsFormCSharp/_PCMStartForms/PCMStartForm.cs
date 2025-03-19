using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArrayExtensions;
using ImageManage;
using PrinterManage;
using WindowsFormCSharp._PCMLabel;

namespace WindowsFormCSharp._PCMStartForms
{
    public partial class PCMStartForm : Form
    {
        private PrinterSettings printerSettings = new PrinterSettings();
        private PageSettings pageSettings;
        public PCMStartForm()
        {
            InitializeComponent();

            // 부경양돈농협 로고 설정
            string[] images = new string[1];
            images[0] = "logo.png";
            Bitmap[] bmps = ImgManage.ImgtoBitmap(images);
            this.pb_logo.Image = bmps[0];

            // comboBox 프린트 설정
            PrintManage printManage = new PrintManage();
            printManage.PrintSetting(this.cbm_01, this.rtb_02, this.btn_01, printerSettings, pageSettings);
        }

        // TODO tab index 이동 할 때, 프린트 설정은 이동하지 않도록 설정할 필요가 있음

        private void btn_bowl_Click(object sender, EventArgs e)
        {
            new PCMLabelForm().Show();
        }

        private void PCMStartForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (MessageBox.Show("PCMStartForm 창을 닫겠습니까?", "창 닫기", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    // 현재 창 닫기
                    this.FindForm().Close();
                }
            }
        }
    }
}
