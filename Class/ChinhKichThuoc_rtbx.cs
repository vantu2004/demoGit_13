using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Windows_04
{
    public class ChinhKichThuoc_rtbx
    {
        // Hàm tính toán chiều cao dựa trên số lượng dòng
        private static int CalculateTextBoxHeight(int numberOfLines, RichTextBox rtbx)
        {
            // Đo chiều cao của một dòng văn bản
            int lineHeight = TextRenderer.MeasureText("Test", rtbx.Font).Height;
            return lineHeight * numberOfLines;
        }

        // Hàm lấy số lượng dòng của RichTextBox
        private static int GetNumberOfLines(RichTextBox richTextBox)
        {
            //  GetLineFromCharIndex() trả về index dòng chứa kí tự đầu tiên
            //  GetFirstCharIndexFromLine() trả về index của kí tự đầu tiên trong dòng đó
            int firstCharIndex = richTextBox.GetFirstCharIndexFromLine(richTextBox.GetLineFromCharIndex(0));

            //  richTextBox.Text.Length - 1 trả về số lượng kí tự trong rtbx
            //  richTextBox.GetLineFromCharIndex(richTextBox.Text.Length - 1) trả về index của dòng chứa kí tự cuối
            //  GetFirstCharIndexFromLine trả về chỉ mục của kí tự đầu trong dòng cuối
            int lastCharIndex = richTextBox.GetFirstCharIndexFromLine(richTextBox.GetLineFromCharIndex(richTextBox.Text.Length - 1));
            int totalLines = richTextBox.GetLineFromCharIndex(lastCharIndex - firstCharIndex) + 2;
            return totalLines;
        }

        //  tạo riêng 1 hàm để khi load dữ liệu nó tự động chỉnh kích cỡ
        public static void chinhKichThuoc(RichTextBox rtbx)
        {
            rtbx.Height = CalculateTextBoxHeight(GetNumberOfLines(rtbx), rtbx);
        }
    }
}
