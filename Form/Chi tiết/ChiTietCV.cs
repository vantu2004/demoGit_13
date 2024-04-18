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
    public partial class ChiTietCV : Form
    {
        ChiTietCV_DAO chiTietCV_DAO = new ChiTietCV_DAO();
        private string Id;

        public ChiTietCV()
        {
            InitializeComponent();
        }

        private void ChiTietCV_Load(object sender, EventArgs e)
        {
            //  load định dạng từ csdl lên cho các rtbx
            dinhDang_rtbx(rtbx_mucTieuNgheNghiep);
            dinhDang_rtbx(rtbx_hocVan);
            dinhDang_rtbx(rtbx_kinhNghiem);
            dinhDang_rtbx(rtbx_hoatDong);
            dinhDang_rtbx(rtbx_giaiThuong);
            dinhDang_rtbx(rtbx_chungChi);
        }

        private void dinhDang_rtbx(RichTextBox rtbx)
        {
            UngVien_DinhDang_rtbx dd = chiTietCV_DAO.layDinhDang(this.Id, rtbx.Name);
            if (dd != null)
                UngVien_ApDung_DinhDang_rtbx.apDungDinhDang(rtbx, dd);
        }

        public void layDuLieu(UngVien_Tin u)
        {
            //  lấy Id ứng viên dùng cho hàm dinhDang_rtbx
            this.Id = u.Id;

            pbx_avatar.Image = Image.FromFile(u.AnhDaiDien);
            lbl_ten.Text = u.TenUV;
            lbl_ngaySinh.Text = u.NgaySinhUV;
            lbl_gioiTinh.Text = u.GioiTinhUV;
            lbl_diaChi.Text = u.DiaChi;
            lbl_mangXaHoi.Text = u.MangXaHoi;
            lbl_sdt.Text = u.SdtUV;
            lbl_email.Text = u.EmailUV;
            lbl_viTriUngTuyen.Text = u.ViTriUngTuyen;
            lbl_ngayCapNhat.Text = u.NgayCapNhatCV;
            rtbx_mucTieuNgheNghiep.Text = u.MucTieuNgheNghiep;
            rtbx_hocVan.Text = u.HocVan;
            rtbx_kinhNghiem.Text = u.KinhNghiem;
            rtbx_hoatDong.Text = u.HoatDong;
            rtbx_giaiThuong.Text = u.GiaiThuong;
            rtbx_chungChi.Text = u.ChungChi;

            //  chỉnh kích cỡ các richtextbox
            ChinhKichThuoc_rtbx.chinhKichThuoc(rtbx_mucTieuNgheNghiep);
            ChinhKichThuoc_rtbx.chinhKichThuoc(rtbx_hocVan);
            ChinhKichThuoc_rtbx.chinhKichThuoc(rtbx_kinhNghiem);
            ChinhKichThuoc_rtbx.chinhKichThuoc(rtbx_hoatDong);
            ChinhKichThuoc_rtbx.chinhKichThuoc(rtbx_giaiThuong);
            ChinhKichThuoc_rtbx.chinhKichThuoc(rtbx_chungChi);
        }
    }
}
