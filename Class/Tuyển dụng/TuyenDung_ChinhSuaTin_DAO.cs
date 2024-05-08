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

        public void chinhSuaTinTuyenDung(TuyenDung_Tin tinTuyenDung)
        {
            using (var dbContext = new DeTai_02_Entities())
            {
                // Tìm tin tuyển dụng cần chỉnh sửa
                var tinTuyenDungCanChinhSua = dbContext.JobPostings.FirstOrDefault(jp => jp.IdCompany == tinTuyenDung.IdCompany && jp.IdJobPostings == tinTuyenDung.IdJobPostings);

                if (tinTuyenDungCanChinhSua != null)
                {
                    // Cập nhật thông tin tin tuyển dụng
                    tinTuyenDungCanChinhSua.IconCompany = tinTuyenDung.LogoCongTy;
                    tinTuyenDungCanChinhSua.Job = tinTuyenDung.NganhNghe;
                    tinTuyenDungCanChinhSua.JobName = tinTuyenDung.TenCongViec;
                    tinTuyenDungCanChinhSua.Salary = Convert.ToDecimal(tinTuyenDung.Luong);
                    tinTuyenDungCanChinhSua.Experience = tinTuyenDung.KinhNghiem;
                    tinTuyenDungCanChinhSua.WorkFormat = tinTuyenDung.HinhThucLamViec;
                    tinTuyenDungCanChinhSua.DatePosted = tinTuyenDung.NgayDang;
                    tinTuyenDungCanChinhSua.Deadline = tinTuyenDung.HanChot;
                    tinTuyenDungCanChinhSua.JobDescription = tinTuyenDung.MoTaCongViec;
                    tinTuyenDungCanChinhSua.Requirements = tinTuyenDung.YeuCau;
                    tinTuyenDungCanChinhSua.Benefit = tinTuyenDung.LoiIch;
                    tinTuyenDungCanChinhSua.Activity = tinTuyenDung.HoatDong;
                    tinTuyenDungCanChinhSua.Award = tinTuyenDung.GiaiThuong;
                    tinTuyenDungCanChinhSua.License = tinTuyenDung.GiayPhep;

                    dbContext.SaveChanges();
                    MessageBox.Show("Success!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Job posting not found!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void dinhDang_rtbx_NTD(TuyenDung_DinhDang_rtbx TD_dinhDang)
        {
            using (var dbContext = new DeTai_02_Entities())
            {
                // Xóa các bản ghi đã tồn tại trước đó
                var dinhDangCu = dbContext.DinhDang_rtbx_NTD
                    .Where(d => d.IdCompany == TD_dinhDang.IdCompany && d.IdJobPostings == TD_dinhDang.IdJobPostings && d.RtbxStyle == TD_dinhDang.Kieu_rtbx)
                    .ToList();
                dbContext.DinhDang_rtbx_NTD.RemoveRange(dinhDangCu);
                dbContext.SaveChanges();

                // Thêm bản ghi mới
                var dinhDangMoi = new DinhDang_rtbx_NTD
                {
                    IdCompany = TD_dinhDang.IdCompany,
                    IdJobPostings = TD_dinhDang.IdJobPostings,
                    RtbxStyle = TD_dinhDang.Kieu_rtbx,
                    Color = TD_dinhDang.MauSac,
                    Font = TD_dinhDang.KieuChu,
                    FontStyle = TD_dinhDang.HieuUng,
                    Size = Convert.ToDecimal(TD_dinhDang.KichCo)
                };
                dbContext.DinhDang_rtbx_NTD.Add(dinhDangMoi);
                dbContext.SaveChanges();
            }
        }

        public TuyenDung_DinhDang_rtbx layDinhDang(string IdCompany, string IdJobPostings, string tenRtbx)
        {
            return db.thucThi_layDinhDang_NTD(IdCompany, IdJobPostings, tenRtbx);
        }
    }
}
