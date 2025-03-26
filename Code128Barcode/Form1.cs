using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Code128Barcode
{
    public class Code128Barcoder
    {
        public static string Encoder(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return "ERR";

            // 입력 유효성 검사: ASCII 32~126 또는 203만 허용
            /*
             32 : 0
            126 : z
            즉 0 ~ z 에 해당하는 바코드 값(키보드에 존재하는 키들)을 허용하며,
            StartA 코드인 203을 넣은 이유
                -> 자세히 해석되지 않지만(내 판단기준 없어도 될것 같지만), 바코드에 임의적으로 StartA가 들어가 있을 수 도 있기 때문인 것 같다..(해석할 때 Bar로 해석되도록)
             */
            foreach (char c in input)
            {
                int code = (int)c;
                if (!((code >= 32 && code <= 126) || code == 203))
                {
                    return "ERR";
                }
            }

            StringBuilder encoded = new StringBuilder();
            bool useTableB = true;
            int i = 0;

            while (i < input.Length)
            {
                if (useTableB)
                {
                    // 첫번째는 바코드 최소 여백(2), 스타트코드A,B,C(2)
                    // 마지막 CheckSum(2), 오차확인(2), 끝을 알리는 것(2)
                    int lookAhead = (i == 0 || (i + 3) == input.Length) ? 4 : 6; 
                    lookAhead--;

                    if (i + lookAhead < input.Length)
                    {
                        bool isNumeric = true;
                        for (int j = 0; j <= lookAhead; j++)
                        {
                            char ch = input[i + j];
                            if (ch < '0' || ch > '9')
                            {
                                isNumeric = false;
                                break;
                            }
                        }

                        if (isNumeric) // 숫자로만 이루어질 경우 Code C로 시작
                        {
                            if (i == 0) encoded.Append((char)210); // Start Code C
                            else encoded.Append((char)204); // Code C switch

                            useTableB = false;
                        }
                        else if (i == 0) // Numeric이 아닐 경우 Code B로 시작
                        {
                            encoded.Append((char)209); // Start Code B
                        }
                    }
                    else if (i == 0) // 이 조건이 나올 리는 없지만, 숫자 구간이 짧으면 Table C를 사용 불가하므로 그냥 ChatGpt로 추가
                    {
                        encoded.Append((char)209); // Start Code B - 숫자 구간이 짧아 Table C 사용 불가 시 기본 B 시작
                    }
                }

                if (!useTableB)
                {
                    bool canUseCodeC = false;
                    // Table C에서 숫자 쌍이 가능한지 확인
                    if (i + 1 < input.Length && char.IsDigit(input[i]) && char.IsDigit(input[i+1]))
                    {
                        canUseCodeC = true;
                    }

                    if (canUseCodeC)
                    {
                        // 두 자리 숫자 인코딩 -> Code128에서는 00~99를 한 문자로 표현 가능
                        int val = int.Parse(input.Substring(i, 2));
                        int code = val < 95 ? val + 32 : val + 105; // Code128 ASCII 변환 규칙 적용
                        encoded.Append((char)code); // 인코딩된 문자 추가
                        i += 2;
                    } else // 숫자쌍이 아닌경우 다시 Table B로 전환
                    {
                        encoded.Append((char)205); // Code B switch
                        useTableB = true;
                    }
                }
                // TableB에서는 문자를 그대로 추가
                if (useTableB && i < input.Length)
                {
                    encoded.Append(input[i]);
                    i++;
                }
            }

            // 체크섬 계산: 첫 문자는 weight 1, 그 다음부터 위치 x 값 누적
            int checksum = 0;
            for (i = 0; i< encoded.Length; i++)
            {
                int val = (int)encoded[i];
                val = val < 127 ? val - 32 : val - 105; // Code128 내부 인코딩 값 추출

                if (i == 0) checksum = val;
                else checksum += val * i; // 가중치 적용
            }

            checksum %= 103; // Code128 체크섬은 103으로 나눈 나머지
            checksum = checksum < 95 ? checksum + 32 : checksum + 105; // 다시 문자로 변환
            encoded.Append((char)checksum); // 체크섬 문자 추가
            encoded.Append((char)211); // Stop Code 추가

            return encoded.ToString(); // 최종 인코딩된 바코드 문자열 반환
        }
    }

    public partial class Form1: Form
    {
        private TextBox inputBox;
        private Button previewButton;
        private PrintDocument printDoc;
        private string barcodeText;
        private string encodedBarcode;

        public Form1()
        {
            InitializeComponent();

            this.Text = "Code128 바코드 미리보기";
            this.Width = 400;
            this.Height = 200;

            inputBox = new TextBox { Left = 20, Top = 20, Width = 300 };
            previewButton = new Button { Left = 20, Top = 60, Width = 100, Text = "미리보기" };

            previewButton.Click += PreviewButton_Click;

            this.Controls.Add(inputBox);
            this.Controls.Add(previewButton);
        }

        private void PreviewButton_Click(object sender, EventArgs e)
        {
            barcodeText = inputBox.Text.Trim();
            encodedBarcode = Code128Barcoder.Encoder(barcodeText);

            if (string.IsNullOrEmpty(encodedBarcode) )
            {
                MessageBox.Show("올바른 문자열 입력");
                return;
            }

            printDoc = new PrintDocument();
            printDoc.PrintPage += PrintDoc_PrintPage;

            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = printDoc;
            preview.Width = 800;
            preview.Height = 600;
            preview.ShowDialog();
        }

        private void PrintDoc_PrintPage(object sneder, PrintPageEventArgs e)
        {
            Font barcodeFont = new Font("Code 128", 48); // 반드시 시스템에 설치된 Code 128 폰트여야 함.
            Font textFont = new Font("Arial", 12);

            float x = 100f;
            float y = 100f;

            e.Graphics.DrawString("[원본문자] " + barcodeText, textFont, Brushes.Black, x, y);
            y += 40;
            e.Graphics.DrawString(encodedBarcode, barcodeFont, Brushes.Black, x, y);
            y += 60;
            e.Graphics.DrawString("[바코드 문자열] " + encodedBarcode, textFont, Brushes.Gray, x, y);
        }
    }
}
