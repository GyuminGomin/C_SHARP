using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormCSharp._PCMLabel
{
    public partial class PCMLabelForm: Form
    {

        /* ********************---------------------------------------- */
        // Region : Local Variables 지역 변수
        /* ********************---------------------------------------- */



        /* ********************---------------------------------------- */
        // Region : Functions 직접만든 함수
        /* ********************---------------------------------------- */
        public PCMLabelForm()
        {
            InitializeComponent();

            string temp_date = this.dtp_workDate.Text.Substring(0, 4) + this.dtp_workDate.Text.Substring(4, 2) + this.dtp_workDate.Text.Substring(6, 2); // 작업일자

            Console.WriteLine(temp_date);

        }

        private void open()
        {
            long ll_ret1; // 조건형 변수
            string ls_group_code; // 그룹코드

            int kind_cd = 7; // 사업구분
            
        }
    }
}
