using Microsoft.EntityFrameworkCore.Storage;
using WindowsFormCSharp._PCMStartForms;

namespace WindowsFormCSharp._LoginForms;
public partial class LoginForm : Form
{

    /* �������� */
    /* ********************---------------------------------------- */
    // Region : Local Variables ���� ����
    /* ********************---------------------------------------- */
    LoginQuery loginQuery = new LoginQuery();

    /* ********************---------------------------------------- */
    // Region : Event Functions �̺�Ʈ �Լ�
    /* ********************---------------------------------------- */
    public LoginForm()
    {
        InitializeComponent();
    }

    private void LoginForm_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Escape)
        {
            if (MessageBox.Show("�����Ͻðڽ��ϱ�?", "����", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }

    private void tb_StaffCode_Leave(object sender, EventArgs e)
    {
        if (this.tb_StaffCode.Text.Equals("0"))
        {
            this.tb_TeamNm.Text = "�޽��Ϲ�";
            this.tb_Nm.Text = "�޽��Ϲ�";
            this.tb_StaffPwd.Focus();
        }
        else
        {
            MessageBox.Show("�ش� ������ ã�� �� �����ϴ�. ������ Ȯ���Ͻʽÿ�.", "����");
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
                    // Cursor�� �𷡽ð�� ����
                    Cursor.Current = Cursors.WaitCursor;
                    string id = this.tb_StaffCode.Text;
                    if (id == string.Empty || id == null)
                    {
                        MessageBox.Show("����� ID�� �Է��Ͻʽÿ�.", "����");
                        this.tb_StaffCode.Focus();
                        Cursor.Current = Cursors.Default;
                        return;
                    }
                    string pwd = this.tb_StaffPwd.Text == null | this.tb_StaffPwd.Text == string.Empty ? "0" : this.tb_StaffPwd.Text;
                    if (pwd == string.Empty || pwd == null)
                    {
                        MessageBox.Show("����� ��й�ȣ�� �Է��Ͻʽÿ�.", "����");
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

                        // ip ���ϱ�
                        var result2 = loginQuery.GetIpQry(null, null);
                        // ��ü�ڵ� ����
                        var result3 = loginQuery.GetWorksInfoQry(null, null);
                        // ��¥ ����
                        var result4 = loginQuery.GetSysDateQry(null, null);
                        var gs_work_date = result4[0]["GS_SYS_DATE"];

                        // ���� ������ ����
                        var pcmStartForm = new PCMStartForm(null, null);
                        pcmStartForm.Show();
                        this.Hide(); // ������ �ٸ� â�� ���� �� ���� �����ϴ� ������ �ʿ���
                    }
                    else
                    {
                        MessageBox.Show("��й�ȣ �����Դϴ�. �ٽ� �Է��ϼ���.", "����");
                        this.tb_StaffPwd.Text = String.Empty;
                        this.tb_StaffPwd.Focus();
                    }
                    // Cursor�� �⺻���� �ǵ���
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
