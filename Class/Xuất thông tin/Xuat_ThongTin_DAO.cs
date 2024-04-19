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
            string sqlQuery_ungTuyen = string.Format("INSERT INTO Letter(IdCompany, IdJobPostings, IdCandidate, Sender, Receiver, Title, Content, DateSent) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')", 
                t.IdCompany, t.IdJobPostings, t.IdCandidate, t.NguoiGui, t.NguoiNhan, t.ChuDe, t.NoiDung, t.NgayGui);

            db.thucThi_taoTin_chinhSuaTin(sqlQuery_ungTuyen);
        }
    }
}
