using System.Text;

namespace WindowsFormCSharp
{
    class MySelfLibrary
    {
        public string NumberFormatIntToString (int no)
        {
            string numberString = no.ToString();
            StringBuilder formattedNumber = new StringBuilder();

            int digitCount = 0;
            for (int i = numberString.Length - 1; i >= 0; i--)
            {
                formattedNumber.Insert(0, numberString[i]);
                digitCount++;

                if (digitCount % 3 == 0 && i != 0)
                {
                    formattedNumber.Insert(0, ",");
                }
            }
            return formattedNumber.ToString();
        }

        public int NumberFormatStringToInt (string numberString)
        {
            numberString = numberString.Replace(",", "");
            try
            {
                int num = int.Parse(numberString);
                return num;
            } catch (Exception e)
            {
                throw;
            }
        }
    }
    

    class MySelfStyle
    {
        public void DataGridViewRectangle(DataGridView dgv)
        {
            // 초기 데이터 그리드 뷰 설정
            dgv.ColumnHeadersVisible = false;
            dgv.RowHeadersVisible = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.AllowUserToResizeColumns = false;
            dgv.BackgroundColor = Color.SkyBlue;
            dgv.GridColor = Color.SkyBlue;
            //this.dgv_kindCd.CellBorderStyle = DataGridViewCellBorderStyle.None;
            //this.dgv_kindCd.DefaultCellStyle.SelectionBackColor = this.dgv_kindCd.DefaultCellStyle.BackColor;
            //this.dgv_kindCd.DefaultCellStyle.SelectionForeColor = this.dgv_kindCd.DefaultCellStyle.ForeColor;
            dgv.RowTemplate.Height = 60;
        }
    }
}
