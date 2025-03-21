using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormCSharp;

namespace WindowsFormCSharp.PrinterManage
{
    class PrintManage
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
    }

    
}
