using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Windows_04
{
    public class DangKy_DangNhap_DAO
    {
        dbConnection db = new dbConnection();

        public DangKy_DangNhap_DAO() { }

        public void dangNhap(string tenDanhNhap, string matKhau)
        {
            string sqlQuery_dangNhap = string.Format("SELECT * FROM TAIKHOAN WHERE UserName = '{0}' AND UserPassword = '{1}'", tenDanhNhap, matKhau);

            db.thucThi_dangNhap(sqlQuery_dangNhap);
        }
    }
}
