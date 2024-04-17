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

        public void dinhDang_rtbx_NTD(TuyenDung_DinhDang_rtbx TD_dinhDang)
        {
            //  vxóa bộ đã tồn tại trước đó để thêm bộ mới đã chỉnh sửa vào
            //  gọi hàm này để thực thi sqlQuery mà ko xuất messagebox
            string sqlQuery_xoa_dinhDang_rtbx = string.Format("DELETE FROM DinhDang_rtbx_NTD WHERE IdCompany = '{0}' AND IdJobPostings = '{1}' AND RtbxStyle = '{2}'", TD_dinhDang.IdCompany, TD_dinhDang.IdJobPostings, TD_dinhDang.Kieu_rtbx);
            db.thucThi_taoTin_chinhSuaTin_koMessageBox(sqlQuery_xoa_dinhDang_rtbx);

            string sqlQuery_taoDinhDang = string.Format("INSERT INTO DinhDang_rtbx_NTD(IdCompany, IdJobPostings, RtbxStyle, Color, Font, FontStyle, Size) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')"
                , TD_dinhDang.IdCompany, TD_dinhDang.IdJobPostings, TD_dinhDang.Kieu_rtbx, TD_dinhDang.MauSac, TD_dinhDang.KieuChu, TD_dinhDang.HieuUng, TD_dinhDang.KichCo);
            //  gọi hàm này để thực thi sqlQuery mà ko xuất messagebox
            db.thucThi_taoTin_chinhSuaTin_koMessageBox(sqlQuery_taoDinhDang);
        }

        public TuyenDung_DinhDang_rtbx layDinhDang(string IdCompany, string IdJobPostings, string tenRtbx)
        {
            string sqlQuery_layDinhDang = string.Format("SELECT * FROM DinhDang_rtbx_NTD WHERE IdCompany = '{0}' AND IdJobPostings = '{1}' AND RtbxStyle = '{2}'",
                IdCompany, IdJobPostings, tenRtbx);
            return db.thucThi_layDinhDang(sqlQuery_layDinhDang);
        }
    }
}
