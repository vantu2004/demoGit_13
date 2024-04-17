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
            string sqlQuery_layDinhDang = string.Format("SELECT * FROM DinhDang_rtbx_NTD WHERE IdCompany = '{0}' AND IdJobPostings = '{1}' AND RtbxStyle = '{2}'",
                IdCompany, IdJobPostings, tenRtbx);
            return db.thucThi_layDinhDang(sqlQuery_layDinhDang);
        }
    }
}
