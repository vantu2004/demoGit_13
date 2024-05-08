using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Windows_04
{
    internal class TuyenDung_DAO
    {
        dbConnection db = new dbConnection();

        public TuyenDung_DAO() { }

        public void dangKy(TuyenDung t, TaiKhoan tk)
        {
            using (var dbContext = new DeTai_02_Entities())
            {
                try
                {
                    dbContext.NHATUYENDUNG.Add(new NHATUYENDUNG
                    {
                        Id = t.Id,
                        UserType = t.UserType,
                        Fname = t.TenHR,
                        Email = t.EmailHR,
                        PhoneNTD = t.SdtHR,
                        JobPos = t.ViTriCongTacHR,
                        Company = t.TenCongTy,
                        JobLocation = t.DiaChiCongTy,
                        SocialNetwork = t.MangXaHoi
                    });

                    dbContext.TAIKHOAN.Add(new TAIKHOAN
                    {
                        Id = tk.Id,
                        UserType = tk.UserType,
                        UserName = tk.TenDangNhap,
                        UserPassword = tk.MatKhau
                    });

                    dbContext.SaveChanges();

                    MessageBox.Show("Success!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error! \n" + ex.Message, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void taoTin(TuyenDung_Tin t)
        {
            using (var dbContext = new DeTai_02_Entities())
            {
                try
                {
                    dbContext.JobPostings.Add(new JobPostings
                    {
                        IdCompany = t.IdCompany,
                        IconCompany = t.LogoCongTy,
                        Job = t.NganhNghe,
                        JobName = t.TenCongViec,
                        Salary = Convert.ToDecimal(t.Luong),
                        Experience = t.KinhNghiem,
                        WorkFormat = t.HinhThucLamViec,
                        DatePosted = t.NgayDang,
                        Deadline = t.HanChot,
                        JobDescription = t.MoTaCongViec,
                        Requirements = t.YeuCau,
                        Benefit = t.LoiIch,
                        Activity = t.HoatDong,
                        Award = t.GiaiThuong,
                        License = t.GiayPhep
                    });

                    dbContext.SaveChanges();

                    MessageBox.Show("Success!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error! \n" + ex.Message, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void load_tinTuyenDung(FlowLayoutPanel flpl, string kieuNguoiDung)
        {
            db.thucThi_load_tinTuyenDung(flpl, kieuNguoiDung);
        }

        public void load_tinDaDang(FlowLayoutPanel flpl, string Id)
        {
            using (var dbContext = new DeTai_02_Entities())
            {
                try
                {
                    var jobPostings = dbContext.JobPostings.Where(j => j.IdCompany == Id).ToList();

                    Xuat_ThongTin xuat_TT = new Xuat_ThongTin();

                    foreach (var jobPosting in jobPostings)
                    {
                        flpl.Controls.Add(xuat_TT.them_tinDaDang(jobPosting.IdCompany, jobPosting.IdJobPostings, jobPosting.JobName, jobPosting.DatePosted));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error! \n" + ex.Message, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void dinhDang_rtbx_NTD(TuyenDung_DinhDang_rtbx TD_dinhDang)
        {
            using (var dbContext = new DeTai_02_Entities())
            {
                try
                {
                    dbContext.DinhDang_rtbx_NTD.Add(new DinhDang_rtbx_NTD
                    {
                        IdCompany = TD_dinhDang.IdCompany,
                        IdJobPostings = TD_dinhDang.IdJobPostings,
                        RtbxStyle = TD_dinhDang.Kieu_rtbx,
                        Color = TD_dinhDang.MauSac,
                        Font = TD_dinhDang.KieuChu,
                        FontStyle = TD_dinhDang.HieuUng,
                        Size = Convert.ToDecimal(TD_dinhDang.KichCo)
                    });

                    dbContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error! \n" + ex.Message, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void load_lichPhongVan(FlowLayoutPanel flpl, string IdCompany)
        {
            using (var dbContext = new DeTai_02_Entities())
            {
                try
                {
                    var lichPhongVanList = dbContext.LichPhongVan.Where(l => l.IdCompany == IdCompany).ToList();

                    Xuat_ThongTin xuat_TT = new Xuat_ThongTin();

                    foreach (var lichPhongVan in lichPhongVanList)
                    {
                        LichPV lichPV = new LichPV(lichPhongVan.LinkAvatar, lichPhongVan.UpdateDate, lichPhongVan.InterviewDate + " " + lichPhongVan.InterviewTime, lichPhongVan.JobName, lichPhongVan.CandidateName);
                        flpl.Controls.Add(xuat_TT.them_lichPhongVan(lichPV));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error! \n" + ex.Message, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
