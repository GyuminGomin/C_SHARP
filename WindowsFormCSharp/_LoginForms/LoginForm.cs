using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormCSharp._LoginForms.Query;
using WindowsFormCSharp.Config;
using WindowsFormCSharp._PCMStartForms;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace WindowsFormCSharp._LoginForms;
public partial class LoginForm : Form
{

    /* 지역변수 */
    /* ********************---------------------------------------- */
    // Region : Local Variables 지역 변수
    /* ********************---------------------------------------- */
    LoginQuery loginQuery = new LoginQuery();

    /* ********************---------------------------------------- */
    // Region : Event Functions 이벤트 함수
    /* ********************---------------------------------------- */
    public LoginForm()
    {
        InitializeComponent();
    }

    private void LoginForm_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Escape)
        {
            if (MessageBox.Show("종료하시겠습니까?", "종료", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }

    private void tb_StaffCode_Leave(object sender, EventArgs e)
    {
        if (this.tb_StaffCode.Text.Equals("0"))
        {
            this.tb_TeamNm.Text = "급식일반";
            this.tb_Nm.Text = "급식일반";
            this.tb_StaffPwd.Focus();
        }
        else
        {
            MessageBox.Show("해당 직번을 찾을 수 없습니다. 직번을 확인하십시오.", "오류");
            this.tb_StaffCode.Text = String.Empty;
            this.tb_TeamNm.Text = String.Empty;
            this.tb_Nm.Text = String.Empty;
            this.tb_StaffCode.Focus();
        }
    }

    private void tb_StaffPwd_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            // Cursor를 모래시계로 설정
            Cursor.Current = Cursors.WaitCursor;

            string id = this.tb_StaffCode.Text;
            if (id == string.Empty || id == null)
            {
                MessageBox.Show("사용자 ID를 입력하십시오.", "오류");
                this.tb_StaffCode.Focus();
                Cursor.Current = Cursors.Default;
                return;
            }
            string pwd = this.tb_StaffPwd.Text == null | this.tb_StaffPwd.Text == string.Empty ? "0" : this.tb_StaffPwd.Text;
            if (pwd == string.Empty || pwd == null)
            {
                MessageBox.Show("사용자 비밀번호를 입력하십시오.", "오류");
                this.tb_StaffPwd.Focus();
                Cursor.Current = Cursors.Default;
                return;
            }

            if (id.Equals("0") && pwd.Equals("0"))
            {
                var result = loginQuery.selectMemberInfo(id, pwd);

                foreach (var item in result)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                MessageBox.Show("사용자 ID 또는 비밀번호가 일치하지 않습니다.", "오류");
                this.tb_StaffPwd.Text = String.Empty;
                this.tb_StaffPwd.Focus();
            }

            // Cursor를 기본으로 되돌림
            Cursor.Current = Cursors.Default;
        }
    }
}
