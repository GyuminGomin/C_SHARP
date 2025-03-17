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
using ArrayExtensions;
using Microsoft.EntityFrameworkCore.Storage;

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
                        var result = loginQuery.SelectMemberInfo(memberInfoDict);
                        string gs_usr_grp = Convert.ToString(result[0]["NO_MEMBER_SEQ"]);
                        string gs_userid = id;
                        string gl_no_member_seq = Convert.ToString(result[0]["NO_MEMBER_SEQ"]);

                        // ip ���ϱ� ( ���⼭ null ó�� ����� ���ؼ� �н��ؾ��� �� )
                        var result2 = loginQuery.GetIp(null);

                        var result3 = loginQuery.GetMemberInfo(null);
                    }
                    else
                    {
                        MessageBox.Show("����� ID �Ǵ� ��й�ȣ�� ��ġ���� �ʽ��ϴ�.", "����");
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
}
