using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Windows_04
{
    public class ChiTietCV_DAO
    {
        dbConnection db = new dbConnection();

        public ChiTietCV_DAO() { }

        public UngVien_DinhDang_rtbx layDinhDang(string Id, string tenRtbx)
        {
            string sqlQuery_layDinhDang = string.Format("SELECT * FROM DinhDang_rtbx_UV WHERE Id = '{0}' AND RtbxStyle = '{1}'",
                Id, tenRtbx);
            return db.thucThi_layDinhDang_UV(sqlQuery_layDinhDang);
        }
    }
}
