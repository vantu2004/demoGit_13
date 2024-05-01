using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Windows_04
{
    public class Xuat_ThongTin_DAO
    {
        dbConnection db = new dbConnection();

        public Xuat_ThongTin_DAO() { }

        public void ungTuyen(string IdCandidate, string IdCompany, string IdJobPostings)
        {
            string sqlQuery_ungTuyen = string.Format("INSERT INTO Applications(IdCompany, IdJobPostings, IdCandidate) VALUES ('{0}', '{1}', '{2}')", IdCompany, IdJobPostings, IdCandidate);

            db.thucThi_taoTin_chinhSuaTin(sqlQuery_ungTuyen);
        }

        public void xoa_tinTuyenDung(string IdCompany, string IdJobPostings)
        {
            //  vì Applications tham chiếu đến JobPostings nên phải xóa nó trước
            //  gọi hàm này để thực thi sqlQuery mà ko xuất messagebox
            string sqlQuery_xoa_DSUngVien = string.Format("DELETE FROM Applications WHERE IdCompany = '{0}' AND IdJobPostings = '{1}'", IdCompany, IdJobPostings);
            db.thucThi_taoTin_chinhSuaTin_koMessageBox(sqlQuery_xoa_DSUngVien);

            //  vì DinhDang_rtbx_NTD tham chiếu đến JobPostings nên phải xóa nó trước
            //  gọi hàm này để thực thi sqlQuery mà ko xuất messagebox
            string sqlQuery_xoa_dinhDang_rtbx = string.Format("DELETE FROM DinhDang_rtbx_NTD WHERE IdCompany = '{0}' AND IdJobPostings = '{1}'", IdCompany, IdJobPostings);
            db.thucThi_taoTin_chinhSuaTin_koMessageBox(sqlQuery_xoa_dinhDang_rtbx);

            string sqlQuery_xoa_tinTuyenDung = string.Format("DELETE FROM JobPostings WHERE IdJobPostings = '{0}'", IdJobPostings);
            db.thucThi_taoTin_chinhSuaTin(sqlQuery_xoa_tinTuyenDung);
        }

        public TuyenDung_Tin chiTietTin(string IdCompany, string IdJobPostings)
        {
            string sqlQuery_chiTietTin = string.Format("SELECT * FROM NHATUYENDUNG INNER JOIN JobPostings ON NHATUYENDUNG.Id = JobPostings.IdCompany WHERE JobPostings.IdCompany = '{0}' AND JobPostings.IdJobPostings = '{1}'", IdCompany, IdJobPostings);

            return db.thucThi_chiTietTin(sqlQuery_chiTietTin);
        }

        public void load_DS_CV(FlowLayoutPanel flpl, string IdCompany, string IdJobPostings)
        {
            string sqlQuery_load_DS_CV = string.Format("SELECT * FROM Applications INNER JOIN UNGVIEN ON Applications.IdCandidate = UNGVIEN.Id WHERE Applications.IdCompany = '{0}' AND Applications.IdJobPostings = '{1}'", IdCompany, IdJobPostings);

            db.thucThi_load_DS_CV(flpl, sqlQuery_load_DS_CV);
        }

        public UngVien_Tin chiTiet_CV(string IdCandidate)
        {
            string sqlQuery_chiTietCV = string.Format("SELECT * FROM UNGVIEN INNER JOIN CVs ON UNGVIEN.Id = CVs.Id WHERE UNGVIEN.Id = '{0}'", IdCandidate);

            return db.thucThi_chiTietCV(sqlQuery_chiTietCV);
        }

        public void xoaCV(string IdCompany, string IdJobPostings, string IdCandidate)
        {
            string sqlQuery_xoaCV = string.Format("DELETE FROM Applications WHERE IdCompany = '{0}' AND IdJobPostings = '{1}' AND IdCandidate = '{2}'", IdCompany, IdJobPostings, IdCandidate);
            db.thucThi_taoTin_chinhSuaTin(sqlQuery_xoaCV);
        }
 
        public void luuThu(Thu t)
        {
            string sqlQuery_luuThu = string.Format("INSERT INTO Letter(IdCompany, IdJobPostings, IdCandidate, Sender, Receiver, Title, Content, DateSent, InterviewDate, InterviewTime) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}')", 
                t.IdCompany, t.IdJobPostings, t.IdCandidate, t.NguoiGui, t.NguoiNhan, t.ChuDe, t.NoiDung, t.NgayGui, t.NgayPhongVan, t.ThoiGianPhongVan);
            db.thucThi_taoTin_chinhSuaTin(sqlQuery_luuThu);

            //  tận dụng hàm thucThi_chiTietTin bên dbConnection để lấy UpdateDate, JobName
            TuyenDung_Tin tt = chiTietTin(t.IdCompany, t.IdJobPostings);

            //  tận dụng hàm thucThi_chiTietCV bên dbConnection để lấy LinkAvatar, CandidateName
            UngVien_Tin u = chiTiet_CV(t.IdCandidate);

            //  lưu lịch phỏng vấn
            string sqlQuery_luuLichPhongVan = string.Format("INSERT INTO LichPhongVan(IdCompany, IdJobPostings, IdCandidate, LinkAvatar, UpdateDate, InterviewDate, InterviewTime, JobName, CandidateName) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}')",
                t.IdCompany, t.IdJobPostings, t.IdCandidate, u.AnhDaiDien, tt.NgayDang, t.NgayPhongVan, t.ThoiGianPhongVan, tt.TenCongViec, u.TenUV);
            db.thucThi_taoTin_chinhSuaTin_koMessageBox(sqlQuery_luuLichPhongVan);
        }

        public void luuTin(string tableName, string IdCompany, string IdJobPostings, string IdCandidate)
        {
            string sqlQuery_xoaTinDaLuu = string.Format("DELETE FROM {0} WHERE IdCompany = '{1}' AND IdJobPostings = '{2}' AND IdCandidate = '{3}'", tableName, IdCompany, IdJobPostings, IdCandidate);
            db.thucThi_taoTin_chinhSuaTin_koMessageBox(sqlQuery_xoaTinDaLuu);

            string sqlQuery_ungTuyen = string.Format("INSERT INTO {0} (IdCompany, IdJobPostings, IdCandidate, Follow) VALUES ('{1}', '{2}', '{3}', '{4}')", tableName, IdCompany, IdJobPostings, IdCandidate, "flw");
            db.thucThi_taoTin_chinhSuaTin_koMessageBox(sqlQuery_ungTuyen);
        }

        public void xoaTinDaLuu(string tableName, string IdCompany, string IdJobPostings, string IdCandidate)
        {
            string sqlQuery_xoaTinDaLuu = string.Format("DELETE FROM {0} WHERE IdCompany = '{1}' AND IdJobPostings = '{2}' AND IdCandidate = '{3}'", tableName, IdCompany, IdJobPostings, IdCandidate);
            db.thucThi_taoTin_chinhSuaTin_koMessageBox(sqlQuery_xoaTinDaLuu);
        }

        public string trangThai_checkChanged(string tableName, string IdCompany, string IdJobPostings, string IdCandidate)
        {
            string sqlQuery_trangThai_checkChanged = string.Format("SELECT * FROM {0} WHERE IdCompany = '{1}' AND IdJobPostings = '{2}' AND IdCandidate = '{3}'", tableName, IdCompany, IdJobPostings, IdCandidate);

            return db.thucThi_trangThai_checkChanged(sqlQuery_trangThai_checkChanged);
        }
    }
}
