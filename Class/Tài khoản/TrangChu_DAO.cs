using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Windows_04
{
    internal class TrangChu_DAO
    {
        dbConnection db = new dbConnection();

        public TrangChu_DAO() { }

        //public void load_tinTuyenDung(FlowLayoutPanel flowLayoutPanel, string userType)
        //{
        //    string sqlQuery_xuat_tinTuyenDung = string.Format("SELECT * FROM NHATUYENDUNG INNER JOIN JobPostings ON NHATUYENDUNG.Id = JobPostings.IdCompany");

        //    db.thucThi_load_tinTuyenDung(sqlQuery_xuat_tinTuyenDung, flowLayoutPanel, userType);
        //}

        public void load_tinTuyenDung(FlowLayoutPanel flpl, string userType)
        {
            db.thucThi_load_tinTuyenDung(flpl, userType);
        }
    }
}
