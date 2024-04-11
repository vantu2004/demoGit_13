using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Windows_04
{
    public class TuyenDung_ChinhSuaTin_DAO
    {
        dbConnection db = new dbConnection();

        public TuyenDung_ChinhSuaTin_DAO() { }

        public void chinhSuaTin(TuyenDung_Tin t)
        {
            string sqlQuery_chinhSuaTin = string.Format("UPDATE JobPosTings SET IconCompany = '{0}', Job = '{1}', JobName = '{2}', Salary = '{3}', Experience = '{4}', " +
                "WorkFormat = '{5}', DatePosted = '{6}', Deadline = '{7}', JobDescription = '{8}', Requirements = '{9}', Benefit = '{10}', Activity = '{11}', Award = '{12}', License = '{13}' WHERE IdCompany = '{14}' AND IdJobPostings = '{15}'",
                t.LogoCongTy, t.NganhNghe, t.TenCongViec, t.Luong, t.KinhNghiem, t.HinhThucLamViec, t.NgayDang, t.HanChot, t.MoTaCongViec, t.YeuCau, t.LoiIch, t.HoatDong, t.GiaiThuong, t.GiayPhep, t.IdCompany, t.IdJobPostings);

            db.thucThi_taoTin_chinhSuaTin(sqlQuery_chinhSuaTin);
        }
    }
}
