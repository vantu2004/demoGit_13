using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Windows_04
{
    internal class UngVien_DAO
    {
        dbConnection db = new dbConnection();

        public UngVien_DAO() { }

        public void dangKy(UngVien uv, TaiKhoan tk)
        {
            string sqlQuery_UV = string.Format("INSERT INTO UNGVIEN(Id, UserType, Fname, Phone, BirthDate, Link, Email, Address_C, Gender) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}')"
                , uv.Id, uv.UserType, uv.Ten, uv.Sdt, uv.NgaySinh, uv.MangXaHoi, uv.Email, uv.DiaChi, uv.GioiTinh);
            string sqlQuery_TK = string.Format("INSERT INTO TAIKHOAN(Id, UserType, UserName, UserPassword) VALUES ('{0}', '{1}', '{2}', '{3}')"
                , tk.Id, tk.UserType, tk.TenDangNhap, tk.MatKhau);

            db.thucThi_dangKy(sqlQuery_UV, sqlQuery_TK);
        }

        public void taoTin(UngVien_Tin u)
        {
            string sqlQuery_taoTin = string.Format("INSERT INTO CVs(Id, Avatar, JobPos, CareerGoal, Education, Experience, UploadDate) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')",
                u.Id, u.AnhDaiDien, u.ViTriUngTuyen, u.MucTieuNgheNghiep, u.HocVan, u.KinhNghiem, u.NgayCapNhatCV);

            db.thucThi_taoTin_chinhSuaTin(sqlQuery_taoTin);
        }

        public void chinhSuaTin(UngVien_Tin u)
        {
            string sqlQuery_chinhSuaTin_CVs = string.Format("UPDATE CVs SET Avatar = '{0}', JobPos = '{1}', CareerGoal = '{2}', Education = '{3}', Experience = '{4}', UploadDate = '{5}' WHERE Id = '{6}'",
                u.AnhDaiDien, u.ViTriUngTuyen, u.MucTieuNgheNghiep, u.HocVan, u.KinhNghiem, u.NgayCapNhatCV, u.Id);

            db.thucThi_taoTin_chinhSuaTin(sqlQuery_chinhSuaTin_CVs);

            string sqlQuery_chinhSuaTin_UNGVIEN = string.Format("UPDATE UNGVIEN SET Fname = '{0}', Phone = '{1}', BirthDate = '{2}', Link = '{3}', Email = '{4}', Address_C = '{5}', Gender = '{6}' WHERE Id = '{7}'",
                u.TenUV, u.SdtUV, u.NgaySinhUV, u.MangXaHoi, u.EmailUV, u.DiaChi, u.GioiTinhUV, u.Id);

            db.thucThi_taoTin_chinhSuaTin(sqlQuery_chinhSuaTin_UNGVIEN);
        }

        public void load_tinTuyenDung(FlowLayoutPanel flowLayoutPanel, string kieuNguoiDung)
        {
            string sqlQuery_xuat_tinTuyenDung = string.Format("SELECT * FROM NHATUYENDUNG INNER JOIN JobPostings ON NHATUYENDUNG.Id = JobPostings.IdCompany");

            db.thucThi_load_tinTuyenDung(sqlQuery_xuat_tinTuyenDung, flowLayoutPanel, kieuNguoiDung);
        }
    }
}
