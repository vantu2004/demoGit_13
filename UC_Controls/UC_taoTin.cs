using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Windows_04
{
    public partial class UC_taoTin : UserControl
    {
        public UC_taoTin()
        {
            InitializeComponent();
        }

        //  phải gọi sự kiện textchange trong UCControls đề dùng cho 2 form TuyenDung_TrangChu và TuyenDung_ChinhSuaTin
        private void rtbx_moTaCongViec_TextChanged_1(object sender, EventArgs e)
        {
            // Tính toán lại chiều cao của RichTextBox khi văn bản thay đổi
            RichTextBox rtbx = (RichTextBox)sender;
            ChinhKichThuoc_rtbx.chinhKichThuoc(rtbx);
        }
    }
}
