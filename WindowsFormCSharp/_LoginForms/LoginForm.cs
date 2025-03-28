using Microsoft.EntityFrameworkCore.Storage;
using WindowsFormCSharp._PCMStartForms;

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
        using (IDbContextTransaction transaction = loginQuery.BeginTransaction())
        {
            try
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

                    Dictionary<string, object> memberInfoDict = new Dictionary<string, object>();
                    memberInfoDict.Add("MEMBER_ID", id);
                    memberInfoDict.Add("PASSWORD", pwd);
                    if (pwd.Equals("0"))
                    {
                        var result = loginQuery.SelectMemberInfoQry(memberInfoDict, null);
                        var gs_usr_grp = result[0]["NO_MEMBER_SEQ"];
                        var gs_userid = id;
                        var gl_no_member_seq = result[0]["NO_MEMBER_SEQ"];

                        // ip 구하기
                        var result2 = loginQuery.GetIpQry(null, null);
                        // 업체코드 정보
                        var result3 = loginQuery.GetWorksInfoQry(null, null);
                        // 날짜 설정
                        var result4 = loginQuery.GetSysDateQry(null, null);
                        var gs_work_date = result4[0]["GS_SYS_DATE"];

                        // 시작 페이지 오픈
                        var pcmStartForm = new PCMStartForm(null, null);
                        pcmStartForm.Show();
                        this.Hide(); // 숨기기라서 다른 창을 닫을 때 앱을 종료하는 과정이 필요함
                    }
                    else
                    {
                        MessageBox.Show("비밀번호 오류입니다. 다시 입력하세요.", "오류");
                        this.tb_StaffPwd.Text = String.Empty;
                        this.tb_StaffPwd.Focus();
                    }
                    // Cursor를 기본으로 되돌림
                    Cursor.Current = Cursors.Default;
                }

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Console.WriteLine(ex.ToString());
            }
        }
    }

    private void LoginForm_Shown(object sender, EventArgs e)
    {
        this.tb_StaffCode.Focus();
    }
}
