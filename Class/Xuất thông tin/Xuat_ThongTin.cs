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

            //  ẩn checkbox theo dõi tin nếu chưa đăng nhập hoặc là NTD
            if (this.userType == "Employer" || this.userType == "null")
            {
                UC_tinTuyenDung.cbx_theoDoi.Hide();
            }

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

        public UC_TinDaDang them_tinDaDang(string IdCompany, string IdJobPostings, string tenCongViec, string ngayDang)
        {
            UC_TinDaDang UC_tinDaDang = new UC_TinDaDang();

            UC_tinDaDang.lbl_ngayDang.Text = ngayDang;
            UC_tinDaDang.lbl_tenCongViec.Text = tenCongViec;

            UC_tinDaDang.Click += (sender, e) => UC_tinDaDang_Click1(sender, e, IdCompany, IdJobPostings);
            // Truyền trực tiếp biến vào phương thức xử lý sự kiện
            UC_tinDaDang.btn_xoaTin.Click += (sender, e) => Btn_xoaTin_Click(IdCompany, IdJobPostings);
            UC_tinDaDang.btn_suaTin.Click += (sender, e) => Btn_suaTin_Click(IdCompany, IdJobPostings);

            return UC_tinDaDang;
        }

        private void UC_tinDaDang_Click1(object sender, EventArgs e, string IdCompany, string IdJobPostings)
        {
            UC_TinDaDang myObject = sender as UC_TinDaDang;
            TuyenDung_DS_CVs DSCV = new TuyenDung_DS_CVs();

            xuatTT_DAO.load_DS_CV(DSCV.flpl_danhSachCV, IdCompany, IdJobPostings);

            DSCV.ShowDialog();
        }

        private void Btn_xoaTin_Click(string IdCompany, string IdJobPostings)
        {
            xuatTT_DAO.xoa_tinTuyenDung(IdCompany, IdJobPostings);
        }

        private void Btn_suaTin_Click(string IdCompany, string IdJobPostings)
        {
            TuyenDung_ChinhSuaTin TD_CST = new TuyenDung_ChinhSuaTin();

            TD_CST.layDuLieu(xuatTT_DAO.chiTietTin(IdCompany, IdJobPostings));

            TD_CST.ShowDialog();
        }

        public UC_CVs_daNop them_CV(string IdCompany, string IdJobPostings, string IdCandidate, string tenCongViec, string ngayDang)
        {
            UC_CVs_daNop UC_CV = new UC_CVs_daNop();

            UC_CV.lbl_ngayDang.Text = ngayDang;
            UC_CV.lbl_fullName.Text = tenCongViec;

            UC_CV.Click += (sender, e) => UC_CV_Click(sender, e, IdCandidate);
            UC_CV.btn_xoaCV.Click += (sender, e) => Btn_xoaCV_Click(sender, e, IdCompany, IdJobPostings, IdCandidate);

            return UC_CV;
        }

        private void Btn_xoaCV_Click(object sender, EventArgs e, string IdCompany, string IdJobPostings, string IdCandidate)
        {
            xuatTT_DAO.xoaCV(IdCompany, IdJobPostings, IdCandidate);
        }

        private void UC_CV_Click(object sender, EventArgs e, string IdCandidate)
        {
            ChiTietCV CV = new ChiTietCV();

            CV.layDuLieu(xuatTT_DAO.chiTiet_CV(IdCandidate));
            
            CV.ShowDialog();
        }
    }
}
