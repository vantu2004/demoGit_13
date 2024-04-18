using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Windows_04
{
    public class UngVien_ApDung_DinhDang_rtbx
    {
        public static void Btn_dinhDang_rtbx_Click(object sender, EventArgs e, RichTextBox rtbx, string Id, List<UngVien_DinhDang_rtbx> list_UV_dinhDang)
        {
            DinhDangChu dd = new DinhDangChu();

            // Truyền thêm btn.Name khi gán sự kiện Click
            dd.UC_DinhDang_rtbx.btn_hoanTat.Click += (s, ev) => Btn_hoanTat_Click2(s, ev, dd, rtbx, Id, list_UV_dinhDang);

            dd.ShowDialog();
        }

        public static void Btn_hoanTat_Click2(object sender, EventArgs e, DinhDangChu dd, RichTextBox rtbx, string Id, List<UngVien_DinhDang_rtbx> list_UV_dinhDang)
        {
            //  mặc định là phải điền tất cả thuộc tính
            if (string.IsNullOrEmpty(dd.UC_DinhDang_rtbx.cbx_mauChu.Text) || string.IsNullOrEmpty(dd.UC_DinhDang_rtbx.cbx_phongChu.Text) || string.IsNullOrEmpty(dd.UC_DinhDang_rtbx.cbx_kieuChu.Text) || string.IsNullOrEmpty(dd.UC_DinhDang_rtbx.cbx_coChu.Text))
            {
                MessageBox.Show("You must fill in all information!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            UngVien_DinhDang_rtbx UV_dinhDang = new UngVien_DinhDang_rtbx(Id, rtbx.Name, dd.UC_DinhDang_rtbx.cbx_mauChu.Text,
                dd.UC_DinhDang_rtbx.cbx_phongChu.Text, dd.UC_DinhDang_rtbx.cbx_kieuChu.Text, Convert.ToDouble(dd.UC_DinhDang_rtbx.cbx_coChu.Text));

            //  xử lý trùng khi thay đổi lựa chọn định dạng cho 1 rtbx nhiều lần
            bool kiemTra = false;
            int j = 0;
            foreach (var i in list_UV_dinhDang)
            {
                if (UV_dinhDang.Id == i.Id && UV_dinhDang.Kieu_rtbx == i.Kieu_rtbx)
                {
                    list_UV_dinhDang[j] = UV_dinhDang;
                    kiemTra = true;
                    break;
                }
                j++;
            }

            apDungDinhDang(rtbx, UV_dinhDang);

            if (kiemTra != true)
                list_UV_dinhDang.Add(UV_dinhDang);
            dd.Close();
        }

        public static void apDungDinhDang(RichTextBox rtbx, UngVien_DinhDang_rtbx UV_dinhDang)
        {
            FontStyle fontStyle = ParseFontStyle(UV_dinhDang.HieuUng);
            FontFamily font = new FontFamily(UV_dinhDang.KieuChu);
            float size = Convert.ToInt32(UV_dinhDang.KichCo);
            Font f = new Font(font, size, fontStyle);

            // Thiết lập kiểu font cho toàn bộ văn bản trong RichTextBox
            rtbx.SelectAll(); // Chọn toàn bộ văn bản
            rtbx.SelectionFont = f; // Đặt kiểu font mới cho văn bản được chọn

            Color clr = Color.FromName(UV_dinhDang.MauSac);
            rtbx.ForeColor = clr;
        }

        public static FontStyle ParseFontStyle(string hieuUng)
        {
            return (FontStyle)Enum.Parse(typeof(FontStyle), hieuUng, true);
        }
    }
}
