using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Windows_04
{
    public class TuyenDung_ApDung_DinhDang_rtbx
    {
        public static void Btn_dinhDang_rtbx_Click(object sender, EventArgs e, string rtbxName, RichTextBox rtbx, string IdCompany, string IdJobPostings, List<TuyenDung_DinhDang_rtbx> list_TD_dinhDang)
        {
            DinhDangChu dd = new DinhDangChu();

            // Truyền thêm btn.Name khi gán sự kiện Click
            dd.UC_DinhDang_rtbx.btn_hoanTat.Click += (s, ev) => Btn_hoanTat_Click2(s, ev, dd, rtbxName, rtbx, IdCompany, IdJobPostings, list_TD_dinhDang);

            dd.ShowDialog();
        }

        public static void Btn_hoanTat_Click2(object sender, EventArgs e, DinhDangChu dd, string rtbxName, RichTextBox rtbx, string IdCompany, string IdJobPostings, List<TuyenDung_DinhDang_rtbx> list_TD_dinhDang)
        {
            //  mặc định là phải điền tất cả thuộc tính
            if (string.IsNullOrEmpty(dd.UC_DinhDang_rtbx.cbx_mauChu.Text) || string.IsNullOrEmpty(dd.UC_DinhDang_rtbx.cbx_phongChu.Text) || string.IsNullOrEmpty(dd.UC_DinhDang_rtbx.cbx_kieuChu.Text) || string.IsNullOrEmpty(dd.UC_DinhDang_rtbx.cbx_coChu.Text))
            {
                MessageBox.Show("You must fill in all information!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            TuyenDung_DinhDang_rtbx TD_dinhDang = new TuyenDung_DinhDang_rtbx(IdCompany, IdJobPostings, rtbxName, dd.UC_DinhDang_rtbx.cbx_mauChu.Text,
                dd.UC_DinhDang_rtbx.cbx_phongChu.Text, dd.UC_DinhDang_rtbx.cbx_kieuChu.Text, Convert.ToDouble(dd.UC_DinhDang_rtbx.cbx_coChu.Text));

            //  xử lý trùng khi thay đổi lựa chọn định dạng cho 1 rtbx nhiều lần
            bool kiemTra = false;
            int j = 0;
            foreach (var i in list_TD_dinhDang)
            {
                if (TD_dinhDang.IdCompany == i.IdCompany && TD_dinhDang.IdJobPostings == i.IdJobPostings && TD_dinhDang.Kieu_rtbx == i.Kieu_rtbx)
                {
                    list_TD_dinhDang[j] = TD_dinhDang;
                    kiemTra = true;
                    break;
                }
                j++;
            }

            apDungDinhDang(rtbx, TD_dinhDang);

            if (kiemTra != true)
                list_TD_dinhDang.Add(TD_dinhDang);
            dd.Close();
        }

        public static void apDungDinhDang(RichTextBox rtbx, TuyenDung_DinhDang_rtbx TD_dinhDang)
        {
            FontStyle fontStyle = ParseFontStyle(TD_dinhDang.HieuUng);
            FontFamily font = new FontFamily(TD_dinhDang.KieuChu);
            float size = Convert.ToInt32(TD_dinhDang.KichCo);
            Font f = new Font(font, size, fontStyle);

            // Thiết lập kiểu font cho toàn bộ văn bản trong RichTextBox
            rtbx.SelectAll(); // Chọn toàn bộ văn bản
            rtbx.SelectionFont = f; // Đặt kiểu font mới cho văn bản được chọn

            Color clr = Color.FromName(TD_dinhDang.MauSac);
            rtbx.ForeColor = clr;
        }

        public static FontStyle ParseFontStyle(string hieuUng)
        {
            return (FontStyle)Enum.Parse(typeof(FontStyle), hieuUng, true);
        }
    }
}
