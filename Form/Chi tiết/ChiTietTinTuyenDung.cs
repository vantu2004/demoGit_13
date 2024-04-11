using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Project_Windows_04
{
    public partial class ChiTietTinTuyenDung : Form
    {
        public ChiTietTinTuyenDung()
        {
            InitializeComponent();
        }

        public void xuatDuLieu(TuyenDung_Tin t)
        {
            pbx_logoCongTy.Image = Image.FromFile(t.LogoCongTy);
            pbx_giayPhep.Image = Image.FromFile(t.GiayPhep);
            lbl_tenCongTy.Text = t.TenCongTy;
            lbl_mangXaHoi.Text = t.MangXaHoi;
            lbl_DiaChi.Text = t.DiaChi;
            lbl_nganhNghe.Text = t.NganhNghe;
            lbl_tenCongViec.Text = t.TenCongViec;
            lbl_luong.Text = t.Luong.ToString();
            lbl_kinhNghiem.Text = t.KinhNghiem;
            lbl_hinhThucLamViec.Text = t.HinhThucLamViec;
            lbl_tenHR.Text = t.TenHR;
            lbl_emailHR.Text = t.EmailHR;
            lbl_sdtHR.Text = t.SdtHR;
            lbl_viTriCongTacHR.Text = t.ViTriCongTacHR;
            lbl_ngayDang.Text = t.NgayDang;
            lbl_hanChot.Text = t.HanChot;
            rtbx_moTaCongViec.Text = t.MoTaCongViec;
            rtbx_yeuCauUngVien.Text = t.YeuCau;
            rtbx_quyenLoi.Text = t.LoiIch;
            rtbx_hoatDong.Text = t.HoatDong;
            rtbx_giaiThuong.Text = t.GiaiThuong;

            //  chỉnh kích thước rtbx
            ChinhKichThuoc_rtbx.chinhKichThuoc(rtbx_moTaCongViec);
            ChinhKichThuoc_rtbx.chinhKichThuoc(rtbx_yeuCauUngVien);
            ChinhKichThuoc_rtbx.chinhKichThuoc(rtbx_quyenLoi);
            ChinhKichThuoc_rtbx.chinhKichThuoc(rtbx_hoatDong);
            ChinhKichThuoc_rtbx.chinhKichThuoc(rtbx_giaiThuong);
        }
    }
}
