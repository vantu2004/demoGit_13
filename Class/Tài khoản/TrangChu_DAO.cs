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

        public void load_tinTuyenDung(FlowLayoutPanel flpl, string userType)
        {
            db.thucThi_load_tinTuyenDung(flpl, userType);
        }
    }
}
