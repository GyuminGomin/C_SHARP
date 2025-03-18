using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageManage;

namespace WindowsFormCSharp._PCMStartForms
{
    public partial class PCMStartForm: Form
    {
        public PCMStartForm()
        {
            InitializeComponent();


            ImageManage.ImgListMangement();
        }
    }
}
