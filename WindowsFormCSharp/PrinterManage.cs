using System.Drawing.Printing;
using System.Text;
using WindowsFormCSharp.Exceptions;

namespace WindowsFormCSharp
{
    class PrinterManage
    {
        private PrinterSettings printerSettings;
        private PageSettings pageSettings;
        private PageSetupDialog pageSetupDialog;
        private ComboBox comboBox;
        private RichTextBox richTextBox;
        private Button button;
        /*
         * 반드시 현재 폼을 가리키는 this.를 넣어주어야 한다. (매개변수를 받을 때)
         * private PrinterSettings printerSettings = new PrinterSettings();
         * private PageSettings pageSettings;
         * 사용시 위 정의 해서 매개변수로 넣을 것
         */
        public void PrintSetting(ComboBox cb, RichTextBox rtb, Button btn, PrinterSettings ps, PageSettings ps2)
        {
            comboBox = cb; // ComboBox의 주소를 저장
            richTextBox = rtb; // Label의 주소를 저장
            button = btn; // Button의 주소를 저장
            printerSettings = ps; // PrinterSettings의 주소를 저장
            pageSettings = ps2; // PageSettings의 주소를 저장

            // richTextBox 설정
            richTextBox.BackColor = Color.LightGray;
            richTextBox.ReadOnly = true;
            richTextBox.ForeColor = Color.Black;
            richTextBox.ScrollBars = RichTextBoxScrollBars.Horizontal;
            richTextBox.WordWrap = false;

            // 프린트 종류 설정
            pageSettings = new PageSettings(printerSettings);
            pageSetupDialog = new PageSetupDialog();
            pageSetupDialog.PageSettings = pageSettings;
            pageSetupDialog.PrinterSettings = printerSettings;

            comboBox.SelectedValueChanged += cb_SelectedValueChanged;
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                comboBox.Items.Add(printer);
            }
            comboBox.SelectedIndex = 0;
            
            // 프린트 설정 버튼 클릭
            button.Click += btn_Click;
        }

        private void cb_SelectedValueChanged(object sender, EventArgs e)
        {
            printerSettings.PrinterName = comboBox.SelectedItem.ToString();
            
            UpdateRichTextBox();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            
            if (pageSetupDialog.ShowDialog() == DialogResult.OK)
            {
                UpdateRichTextBox();
            }
        }

        private void UpdateRichTextBox()
        {
            richTextBox.Clear();

            // 첫 번째 줄: Bold, 크기 1 증가
            richTextBox.SelectionFont = new Font(richTextBox.Font.FontFamily, richTextBox.Font.Size + 2, FontStyle.Bold);
            richTextBox.SelectionColor = Color.Blue;
            richTextBox.AppendText($"선택한 프린터\t: {printerSettings.PrinterName}\n");

            // 나머지 줄: Regular, 기본 크기
            richTextBox.SelectionFont = new Font(richTextBox.Font.FontFamily, richTextBox.Font.Size + 1, FontStyle.Regular);

            // 프린터가 지원하는 용지 크기 목록 가져오기
            var supportedPaperSizes = printerSettings.PaperSizes.Cast<PaperSize>().ToList();
            // 현재 설정된 용지 크기가 지원되는지 확인
            // 현재 설정된 용지 크기가 지원되지 않는 경우
            if (!supportedPaperSizes.Any(p => p.PaperName == pageSettings.PaperSize.PaperName))
            {
                // A4 용지가 있는지 확인
                var a4Paper = supportedPaperSizes.FirstOrDefault(p => p.PaperName.Contains("A4"));

                if (a4Paper != null)
                {
                    pageSettings.PaperSize = a4Paper;
                }
                else if (supportedPaperSizes.Any())  // A4도 없고 지원되는 용지 목록이 있을 경우
                {
                    pageSettings.PaperSize = supportedPaperSizes.First();  // 가장 첫 번째 지원되는 용지 사용
                }
            }

            // 여백 값을 밀리미터 단위로 변환
            float leftMarginInMillimeters = pageSettings.Margins.Left / 10f;
            float rightMarginInMillimeters = pageSettings.Margins.Right / 10f;
            float topMarginInMillimeters = pageSettings.Margins.Top / 10f;
            float bottomMarginInMillimeters = pageSettings.Margins.Bottom / 10f;

            richTextBox.AppendText($"용지 크기\t: {pageSettings.PaperSize}\n");
            richTextBox.AppendText($"해상도\t\t: {pageSettings.PrinterResolution}\n");
            richTextBox.AppendText($"인쇄 방향\t: {(pageSettings.Landscape ? "가로" : "세로")}\n");
            richTextBox.AppendText($"여백\t\t: Left={leftMarginInMillimeters}mm, Right={rightMarginInMillimeters}mm, Top={topMarginInMillimeters}mm, Bottom={bottomMarginInMillimeters}mm\n");
            richTextBox.AppendText($"공급\t\t: {printerSettings.DefaultPageSettings.PaperSource.SourceName}");
        }


        public string Fn_Barcode128(string barcode)
        {
            if (string.IsNullOrWhiteSpace(barcode))
            {
                throw new BarcodeEncodingException("바코드가 존재하지 않습니다.");
            }
            // 입력 유효성 검사: ASCII 32~126 또는 203만 허용
            /*
             32 : 0
            126 : z
            즉 0 ~ z 에 해당하는 바코드 값(키보드에 존재하는 키들)을 허용하며,
            StartA 코드인 203을 넣은 이유
                -> 자세히 해석되지 않지만(내 판단기준 없어도 될것 같지만), 바코드에 임의적으로 StartA가 들어가 있을 수 도 있기 때문인 것 같다..(해석할 때 Bar로 해석되도록)
             */
            foreach (char c in barcode)
            {
                int code = (int)c;
                if (!((code >= 32 && code <= 126) || code == 203))
                {
                    throw new BarcodeEncodingException("올바른 바코드 형식이 아닙니다.");
                }
            }

            StringBuilder encoded = new StringBuilder();
            bool useTableB = true;
            int i = 0;

            while (i < barcode.Length)
            {
                if (useTableB)
                {
                    // 첫번째는 바코드 최소 여백(2), 스타트코드A,B,C(2)
                    // 마지막 CheckSum(2), 오차확인(2), 끝을 알리는 것(2)
                    int lookAhead = (i == 0 || (i + 3) == barcode.Length) ? 4 : 6;
                    lookAhead--;

                    if (i + lookAhead < barcode.Length)
                    {
                        bool isNumeric = true;
                        for (int j = 0; j <= lookAhead; j++)
                        {
                            char ch = barcode[i + j];
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
                    else if (i == 0)
                    {
                        encoded.Append((char)209); // Start Code B - 숫자 구간이 짧아 Table C 사용 불가 시 기본 B 시작
                    }
                }

                if (!useTableB)
                {
                    bool canUseCodeC = false;
                    // Table C에서 숫자 쌍이 가능한지 확인
                    if (i + 1 < barcode.Length && char.IsDigit(barcode[i]) && char.IsDigit(barcode[i + 1]))
                    {
                        canUseCodeC = true;
                    }

                    if (canUseCodeC)
                    {
                        // 두 자리 숫자 인코딩 -> Code128에서는 00~99를 한 문자로 표현 가능
                        int val = int.Parse(barcode.Substring(i, 2));
                        int code = val < 95 ? val + 32 : val + 105; // Code128 ASCII 변환 규칙 적용
                        encoded.Append((char)code); // 인코딩된 문자 추가
                        i += 2;
                    }
                    else // 숫자쌍이 아닌경우 다시 Table B로 전환
                    {
                        encoded.Append((char)205); // Code B switch
                        useTableB = true;
                    }
                }
                // TableB에서는 문자를 그대로 추가
                if (useTableB && i < barcode.Length)
                {
                    encoded.Append(barcode[i]);
                    i++;
                }
            }

            // 체크섬 계산: 첫 문자는 weight 1, 그 다음부터 위치 x 값 누적
            int checksum = 0;
            for (i = 0; i < encoded.Length; i++)
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
}
