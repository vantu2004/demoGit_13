﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void xoa_tinTuyenDung(string IdJobPostings)
        {
            string sqlQuery_xoa_tinTuyenDung = string.Format("DELETE FROM JobPostings WHERE IdJobPostings = '{0}'", IdJobPostings);

            //db.thucThi_xoa_tinTuyenDung(sqlQuery_xoa_tinTuyenDung);
        }

        public void capNhat_IdJobPostings(string IdJobPostings, string IdJobPostings_hienTai)
        {
            string sqlQuery_xoa_tinTuyenDung = string.Format("UPDATE Applications SET IdJobPostings = '{0}' WHERE IdJobPostings = '{1}'", IdJobPostings, IdJobPostings_hienTai);

            //db.thucThi_capNhat_IdJobPostings(sqlQuery_xoa_tinTuyenDung);
        }
    }
}
