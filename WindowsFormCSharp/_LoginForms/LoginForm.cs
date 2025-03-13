using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WindowsFormCSharp._PCMStartForms;

namespace WindowsFormCSharp._LoginForms;
public partial class LoginForm : Form
{
    public LoginForm()
    {
        InitializeComponent();
    }

    private void LoginForm_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            Console.WriteLine("Enter Key Pressed");
            PCMStartForm pCMStartForm = new _PCMStartForms.PCMStartForm();
            pCMStartForm.Show();
        }
    }
}
