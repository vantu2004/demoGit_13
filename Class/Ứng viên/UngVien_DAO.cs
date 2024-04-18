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
            string sqlQuery_taoTin = string.Format("INSERT INTO CVs(Id, Avatar, JobPos, CareerGoal, Education, Experience, Activity, Award, Certificate, UploadDate) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}')",
                u.Id, u.AnhDaiDien, u.ViTriUngTuyen, u.MucTieuNgheNghiep, u.HocVan, u.KinhNghiem, u.HoatDong, u.GiaiThuong, u.ChungChi, u.NgayCapNhatCV);

            db.thucThi_taoTin_chinhSuaTin(sqlQuery_taoTin);
        }

        public void chinhSuaTin(UngVien_Tin u)
        {
            string sqlQuery_chinhSuaTin_CVs = string.Format("UPDATE CVs SET Avatar = '{0}', JobPos = '{1}', CareerGoal = '{2}', Education = '{3}', Experience = '{4}', Activity = '{5}', Award = '{6}', Certificate = '{7}', UploadDate = '{8}' WHERE Id = '{9}'",
                u.AnhDaiDien, u.ViTriUngTuyen, u.MucTieuNgheNghiep, u.HocVan, u.KinhNghiem, u.HoatDong, u.GiaiThuong, u.ChungChi, u.NgayCapNhatCV, u.Id);

            db.thucThi_taoTin_chinhSuaTin(sqlQuery_chinhSuaTin_CVs);

            string sqlQuery_chinhSuaTin_UNGVIEN = string.Format("UPDATE UNGVIEN SET Fname = '{0}', Phone = '{1}', BirthDate = '{2}', Link = '{3}', Email = '{4}', Address_C = '{5}', Gender = '{6}' WHERE Id = '{7}'",
                u.TenUV, u.SdtUV, u.NgaySinhUV, u.MangXaHoi, u.EmailUV, u.DiaChi, u.GioiTinhUV, u.Id);

            db.thucThi_taoTin_chinhSuaTin_koMessageBox(sqlQuery_chinhSuaTin_UNGVIEN);
        }

        public void load_tinTuyenDung(FlowLayoutPanel flowLayoutPanel, string kieuNguoiDung)
        {
            string sqlQuery_xuat_tinTuyenDung = string.Format("SELECT * FROM NHATUYENDUNG INNER JOIN JobPostings ON NHATUYENDUNG.Id = JobPostings.IdCompany");

            db.thucThi_load_tinTuyenDung(sqlQuery_xuat_tinTuyenDung, flowLayoutPanel, kieuNguoiDung);
        }

        public UngVien_Tin chiTiet_CV(string IdCandidate)
        {
            string sqlQuery_chiTietCV = string.Format("SELECT * FROM UNGVIEN INNER JOIN CVs ON UNGVIEN.Id = CVs.Id WHERE UNGVIEN.Id = '{0}'", IdCandidate);

            return db.thucThi_chiTietCV(sqlQuery_chiTietCV);
        }

        public void dinhDang_rtbx_UV(UngVien_DinhDang_rtbx UV_dinhDang)
        {
            //  xóa bộ đã tồn tại trước đó để thêm bộ mới đã chỉnh sửa vào
            //  gọi hàm này để thực thi sqlQuery mà ko xuất messagebox
            string sqlQuery_xoa_dinhDang_rtbx = string.Format("DELETE FROM DinhDang_rtbx_UV WHERE Id = '{0}' AND RtbxStyle = '{1}'", UV_dinhDang.Id, UV_dinhDang.Kieu_rtbx);
            db.thucThi_taoTin_chinhSuaTin_koMessageBox(sqlQuery_xoa_dinhDang_rtbx);

            string sqlQuery_taoDinhDang = string.Format("INSERT INTO DinhDang_rtbx_UV(Id, RtbxStyle, Color, Font, FontStyle, Size) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')"
                , UV_dinhDang.Id, UV_dinhDang.Kieu_rtbx, UV_dinhDang.MauSac, UV_dinhDang.KieuChu, UV_dinhDang.HieuUng, UV_dinhDang.KichCo);
            //  gọi hàm này để thực thi sqlQuery mà ko xuất messagebox
            db.thucThi_taoTin_chinhSuaTin_koMessageBox(sqlQuery_taoDinhDang);
        }

        public UngVien_DinhDang_rtbx layDinhDang(string Id, string tenRtbx)
        {
            string sqlQuery_layDinhDang = string.Format("SELECT * FROM DinhDang_rtbx_UV WHERE Id = '{0}' AND RtbxStyle = '{1}'",
                Id, tenRtbx);
            return db.thucThi_layDinhDang_UV(sqlQuery_layDinhDang);
        }
    }
}
