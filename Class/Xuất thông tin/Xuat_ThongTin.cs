using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using static DevExpress.Skins.SolidColorHelper;

namespace Project_Windows_04
{
    public class Xuat_ThongTin
    {
        Xuat_ThongTin_DAO xuatTT_DAO = new Xuat_ThongTin_DAO();
        private string IdCompany;
        private string IdJobPostings;
        private string userType;

        public Xuat_ThongTin() { }

        public UC_TinTuyenDung them_tinTuyenDung(TuyenDung_Tin t, string userType)
        {
            UC_TinTuyenDung UC_tinTuyenDung = new UC_TinTuyenDung();

            //  dán t cho UC_tinTuyenDung để dùng khi gọi sự kiện Click
            UC_tinTuyenDung.Tag = t;

            UC_tinTuyenDung.lbl_tenCongViec.Text = t.TenCongViec;
            UC_tinTuyenDung.pbx_logoCongTy.Image = Image.FromFile(t.LogoCongTy);
            UC_tinTuyenDung.lbl_tenCongTy.Text = t.TenCongTy;
            UC_tinTuyenDung.lbl_luong.Text = t.Luong.ToString();
            UC_tinTuyenDung.lbl_nganhNghe.Text = t.NganhNghe;
            UC_tinTuyenDung.lbl_kinhNghiem.Text = t.KinhNghiem;
            UC_tinTuyenDung.lbl_hinhThucLamViec.Text = t.HinhThucLamViec;
            UC_tinTuyenDung.lbl_diaChi.Text = t.DiaChi;

            //  lấy userType của tài khoản đang đăng nhập
            this.userType = userType;

            UC_tinTuyenDung.Click += UC_tinTuyenDung_Click;

            //  phải return UC_tinTuyenDung vì cần add 1 control vào flowlayoutpanel
            return UC_tinTuyenDung;
        }

        private void UC_tinTuyenDung_Click(object sender, EventArgs e)
        {
            UC_TinTuyenDung myObject = sender as UC_TinTuyenDung;
            TuyenDung_Tin t = myObject.Tag as TuyenDung_Tin;

            //  lấy Id của công ty đã đăng tin này và Id của tin đó
            this.IdCompany = t.IdCompany;
            this.IdJobPostings = t.IdJobPostings;

            ChiTietTinTuyenDung chiTiet_tin = new ChiTietTinTuyenDung();

            if (this.userType == "Employer" || this.userType == "null")
            {
                chiTiet_tin.btn_ungTuyen.Hide();
            }       
            else
            {
                chiTiet_tin.btn_ungTuyen.Click += Btn_ungTuyen_Click;
            }    
            //  xuất dữ liệu lên controls trong ChiTietTinTuyenDung
            chiTiet_tin.xuatDuLieu(t);

            chiTiet_tin.ShowDialog();
        }

        private void Btn_ungTuyen_Click(object sender, EventArgs e)
        {
            xuatTT_DAO.ungTuyen(this.userType, this.IdCompany, this.IdJobPostings);
        }

        private void Btn_sua_tinTuyenDung(object sender, EventArgs e)
        {
            TuyenDung_TrangChu TD_TC = new TuyenDung_TrangChu();
            TD_TC.btn_hoanTat_Click(sender, e);

            //  xóa tin đã đăng và cập nhật tin mới dựa vào IdJobPostings mới và IdJobPostings cũ
            xuatTT_DAO.xoa_tinTuyenDung(this.IdJobPostings);
            xuatTT_DAO.capNhat_IdJobPostings(TD_TC.IdJobPostings, this.IdJobPostings);

            //load lại form
            TD_TC.TuyenDung_TrangChu_Load(sender, e);
        }

        public UC_TinDaDang them_tinDaDang(string IdCompany, string IdJobPostings, string tenCongViec, string ngayDang)
        {
            UC_TinDaDang UC_tinDaDang = new UC_TinDaDang();

            UC_tinDaDang.lbl_ngayDang.Text = ngayDang;
            UC_tinDaDang.lbl_tenCongViec.Text = tenCongViec;

            // Lưu trữ thông tin vào thuộc tính Tag của nút btn_xoaTin
            UC_tinDaDang.Tag = new Tuple<string, string>(IdCompany, IdJobPostings);
            UC_tinDaDang.btn_xoaTin.Click += Btn_xoaTin_Click;

            return UC_tinDaDang;
        }

        private void Btn_xoaTin_Click(object sender, EventArgs e)
        {
            Button btnXoaTin = sender as Button;
            UC_TinDaDang myObject = btnXoaTin.Parent as UC_TinDaDang;

            // Lấy thông tin từ thuộc tính Tag của nút
            Tuple<string, string> tagData = myObject.btn_xoaTin.Tag as Tuple<string, string>;

            // Truy cập vào các phần tử trong Tuple để lấy giá trị IdCompany và IdJobPostings
            string IdCompany = tagData.Item1;
            string IdJobPostings = tagData.Item2;

            MessageBox.Show(IdCompany + " " + IdJobPostings);

            //xuatTT_DAO.xoa_tinTuyenDung()
        }

        private void UC_tinDaDang_Click(object sender, EventArgs e)
        {
            //UC_TinDaDang myObject = sender as UC_TinDaDang;
            //DanhSach_CV_DaNop danhSach_CV_DaNop = new DanhSach_CV_DaNop();

            //danhSach_CV_DaNop.ShowDialog();
        }
    }
}
