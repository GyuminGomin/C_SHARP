using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormCSharp._PCMLabelProdStdForms
{
    public partial class PCMLabelProdStdForm_P1 : Form
    {
        OzReport ozReport = new OzReport();
        MyselfDate myselfDate = new MyselfDate();
        public PCMLabelProdStdForm_P1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("SDATE", $"{myselfDate.DateToChar(this.dtp_sDate.Text)}");
            map.Add("EDATE", $"{myselfDate.DateToChar(this.dtp_eDate.Text)}");
            string url = ozReport.SearchOzReport(map);

            this.wv_01.Source = new Uri($"{url}");
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }
    }
}
