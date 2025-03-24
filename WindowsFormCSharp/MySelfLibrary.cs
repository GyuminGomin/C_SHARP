using System.Data;
using System.Text;

namespace WindowsFormCSharp
{
    class MySelfLibrary
    {
        // TODO 생각해보니 이 포맷 사용하려면 조건이 1000 같이 소수점이 없어야 한다.
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

        // TODO 생각해보니 이 포맷 사용하려면 조건이 1000 같이 소수점이 없어야 한다.
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

        // DataGridView 안 값 확인
        public void DataGridViewTagValueCheck(DataGridView dgv, int row, int col)
        {
            Dictionary<string, object> cellData = (Dictionary<string, object>)dgv.Rows[row].Cells[col].Tag;

            // 각 키와 값의 실제 화면 표시 너비를 측정하여 최대 길이 찾기
            int maxKeyWidth = cellData.Keys.Max(k => GetTextWidth(k));
            int maxValueWidth = cellData.Values.Max(v => GetTextWidth(v.ToString()));
            int columnWidth = Math.Max(maxKeyWidth, maxValueWidth) + 2; // 여유 공간 추가

            // 컬럼명 출력
            foreach (var key in cellData.Keys)
            {
                Console.Write(PadRightUnicode(key, columnWidth) + "|");
            }
            Console.WriteLine();

            // 구분선 출력
            Console.WriteLine(string.Concat(Enumerable.Repeat(new string('-', columnWidth) + "|", cellData.Count)));

            // 값 출력
            foreach (var key in cellData.Keys)
            {
                Console.Write(PadRightUnicode(cellData[key].ToString(), columnWidth) + "|");
            }
            Console.WriteLine();
        }

        // 한글 문자 길이 보정 함수 (한글은 2칸 차지한다고 가정)
        private int GetTextWidth(string text)
        {
            int koreanCount = text.Count(c => c >= 0xAC00 && c <= 0xD7A3); // 한글 개수 세기
            return text.Length + koreanCount; // 한글은 2칸 차지하므로 보정
        }

        // 한글 포함된 문자열 정렬 보정 함수
        private string PadRightUnicode(string text, int totalWidth)
        {
            int textWidth = GetTextWidth(text);
            int padding = totalWidth - textWidth + text.Length; // 추가 패딩 계산
            return text.PadRight(padding);
        }

        // DataTable
        public void DataTableTotalValue(DataTable dt)
        {
            int columnCount = dt.Columns.Count;
            int rowCount = dt.Rows.Count;

            if (rowCount > 0 && columnCount > 0)
            {
                // 각 열의 최대 너비 계산 (각각의 값과 컬럼명을 기준으로)
                int[] columnWidths = new int[columnCount];
                for (int col = 0; col < columnCount; col++)
                {
                    int maxKeyWidth = GetTextWidth(dt.Columns[col].ColumnName); // 열 이름의 길이
                    int maxValueWidth = 0;

                    for (int row = 0; row < rowCount; row++)
                    {
                        var cellValue = dt.Rows[row][col]?.ToString() ?? string.Empty;
                        maxValueWidth = Math.Max(maxValueWidth, GetTextWidth(cellValue));
                    }
                    columnWidths[col] = Math.Max(maxKeyWidth, maxValueWidth) + 2; // 여유 공간 추가
                }

                // 컬럼명 출력 (열 제목)
                for (int col = 0; col < columnCount; col++)
                {
                    Console.Write(PadRightUnicode(dt.Columns[col].ColumnName, columnWidths[col]) + "|");
                }
                Console.WriteLine();

                // 구분선 출력
                Console.WriteLine(string.Concat(Enumerable.Repeat(new string('-', columnWidths.Max()) + "|", columnCount)));

                // 모든 값 출력 (각 행에 대해)
                for (int row = 0; row < rowCount; row++)
                {
                    for (int col = 0; col < columnCount; col++)
                    {
                        var cellValue = dt.Rows[row][col]?.ToString() ?? string.Empty;
                        Console.Write(PadRightUnicode(cellValue, columnWidths[col]) + "|");
                    }
                    Console.WriteLine();
                }
            }
        }

        // DateTimePicker에서 DateTime 가져오기
        public string DateTimeFormat(DateTimePicker dtp)
        {
            string dtp_workDate = dtp.Value.ToString();
            return dtp_workDate.Substring(0, 4) + dtp_workDate.Substring(5, 2) + dtp_workDate.Substring(8, 2);
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
            // -> Enter 이벤트가 생길 때 CurrentCell = null로 설정하면 포커스를 해제할 수 있지만
            // 다시 Enter 이벤트가 발생하여 재귀적 문제가 발생한다는 에러만 뜨고 로직에는 문제 없음 (하지만 불편해서 사용 x)
            //dgv.CellEnter += new DataGridViewCellEventHandler(DataGridViewSetEnter);
        }

        //private void DataGridViewSetEnter(object sender, DataGridViewCellEventArgs e)
        //{
        //    DataGridView dgv = sender as DataGridView;

        //    if (dgv.CurrentCell != null)
        //    {
        //        if (dgv.Rows[e.RowIndex].Cells[e.ColumnIndex] is not DataGridViewButtonCell)
        //        {
        //            dgv.CurrentCell = null;
        //        }
        //    }
        //}
    }
}
