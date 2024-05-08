using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Windows_04
{
    public class ChiTietTinTuyenDung_DAO
    {
        dbConnection db = new dbConnection();

        public ChiTietTinTuyenDung_DAO() { }

        public TuyenDung_DinhDang_rtbx layDinhDang(string IdCompany, string IdJobPostings, string tenRtbx)
        {
            return db.thucThi_layDinhDang_NTD(IdCompany, IdJobPostings, tenRtbx);
        }
    }
}
