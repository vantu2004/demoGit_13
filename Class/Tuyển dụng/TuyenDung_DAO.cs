using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Windows_04
{
    internal class TuyenDung_DAO
    {
        dbConnection db = new dbConnection();

        public TuyenDung_DAO() { }

        public void dangKy(TuyenDung t, TaiKhoan tk)
        {
            string sqlQuery_NTD = string.Format("INSERT INTO NHATUYENDUNG(Id, UserType, Fname, Email, PhoneNTD, JobPos, Company, JobLocation, SocialNetwork) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}')"
                , t.Id, t.UserType, t.TenHR, t.EmailHR, t.SdtHR, t.ViTriCongTacHR, t.TenCongTy, t.DiaChiCongTy, t.MangXaHoi);
            string sqlQuery_TK = string.Format("INSERT INTO TAIKHOAN(Id, UserType, UserName, UserPassword) VALUES ('{0}', '{1}', '{2}', '{3}')"
                , tk.Id, tk.UserType, tk.TenDangNhap, tk.MatKhau);

            db.thucThi_dangKy(sqlQuery_NTD, sqlQuery_TK);
        }

        public void taoTin(TuyenDung_Tin t)
        {
            string sqlQuery_taoTin = string.Format("INSERT INTO JobPostings(IdCompany, IdJobPostings, IconCompany, Job, JobName, Salary, Experience, WorkFormat, DatePosted, Deadline, JobDescription, Requirements, Benefit, Activity, Award, License) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}')",
                t.IdCompany, t.IdJobPostings, t.LogoCongTy, t.NganhNghe, t.TenCongViec, t.Luong, t.KinhNghiem, t.HinhThucLamViec, t.NgayDang, t.HanChot, t.MoTaCongViec, t.YeuCau, t.LoiIch, t.HoatDong, t.GiaiThuong, t.GiayPhep);
            db.thucThi_taoTin_chinhSuaTin(sqlQuery_taoTin);
        }

        public void load_tinTuyenDung(FlowLayoutPanel flowLayoutPanel, string kieuNguoiDung)
        {
            string sqlQuery_xuat_tinTuyenDung = string.Format("SELECT * FROM NHATUYENDUNG INNER JOIN JobPostings ON NHATUYENDUNG.Id = JobPostings.IdCompany");

            db.thucThi_load_tinTuyenDung(sqlQuery_xuat_tinTuyenDung, flowLayoutPanel, kieuNguoiDung);
        }

        public void load_tinDaDang(FlowLayoutPanel flowLayoutPanel, string Id)
        {
            string sqlQuery_xuat_tinDaDang = string.Format("SELECT * FROM JobPostings WHERE IdCompany = '{0}'", Id);

            db.thucThi_load_tinDaDang(sqlQuery_xuat_tinDaDang, flowLayoutPanel);
        }

        public void dinhDang_rtbx_NTD(TuyenDung_DinhDang_rtbx TD_dinhDang)
        {
            string sqlQuery_taoDinhDang = string.Format("INSERT INTO DinhDang_rtbx_NTD(IdCompany, IdJobPostings, RtbxStyle, Color, Font, FontStyle, Size) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')"
                , TD_dinhDang.IdCompany, TD_dinhDang.IdJobPostings, TD_dinhDang.Kieu_rtbx, TD_dinhDang.MauSac, TD_dinhDang.KieuChu, TD_dinhDang.HieuUng, TD_dinhDang.KichCo);
            //  gọi hàm này để thực thi sqlQuery mà ko xuất messagebox
            db.thucThi_taoTin_chinhSuaTin_koMessageBox(sqlQuery_taoDinhDang);
        }

        public void load_lichPhongVan(FlowLayoutPanel flpl, string IdCompany)
        {
            string sqlQuery_lichPhongVan = string.Format("SELECT * FROM LichPhongVan WHERE IdCompany = '{0}'", IdCompany);

            db.thucThi_load_lichPhongVan(sqlQuery_lichPhongVan, flpl);
        }
    }
}
