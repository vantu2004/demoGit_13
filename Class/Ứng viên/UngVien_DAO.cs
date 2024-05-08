using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Windows_04
{
    internal class UngVien_DAO
    {
        dbConnection db = new dbConnection();

        public UngVien_DAO() { }

        public void dangKy(UngVien uv, TaiKhoan tk)
        {
            using (var context = new DeTai_02_Entities())
            {
                try
                {
                    context.UNGVIEN.Add(new UNGVIEN
                    {
                        Id = uv.Id,
                        UserType = uv.UserType,
                        Fname = uv.Ten,
                        Phone = uv.Sdt,
                        BirthDate = uv.NgaySinh,
                        Link = uv.MangXaHoi,
                        Email = uv.Email,
                        Address_C = uv.DiaChi,
                        Gender = uv.GioiTinh
                    });

                    context.TAIKHOAN.Add(new TAIKHOAN
                    {
                        Id = tk.Id,
                        UserType = tk.UserType,
                        UserName = tk.TenDangNhap,
                        UserPassword = tk.MatKhau
                    });

                    context.SaveChanges();

                    MessageBox.Show("Success!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error! \n" + ex.Message, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void taoTin(UngVien_Tin u)
        {
            using (var dbContext = new DeTai_02_Entities())
            {
                try
                {
                    dbContext.CVs.Add(new CVs
                    {
                        Id = u.Id,
                        Avatar = u.AnhDaiDien,
                        JobPos = u.ViTriUngTuyen,
                        CareerGoal = u.MucTieuNgheNghiep,
                        Education = u.HocVan,
                        Experience = u.KinhNghiem,
                        Activity = u.HoatDong,
                        Award = u.GiaiThuong,
                        Certificate = u.ChungChi,
                        UploadDate = u.NgayCapNhatCV
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

        public void chinhSuaTin(UngVien_Tin u)
        {
            using (var dbContext = new DeTai_02_Entities())
            {
                try
                {
                    var cv = dbContext.CVs.FirstOrDefault(c => c.Id == u.Id);
                    var ungVien = dbContext.UNGVIEN.FirstOrDefault(uv => uv.Id == u.Id);

                    if (cv != null && ungVien != null)
                    {
                        cv.Avatar = u.AnhDaiDien;
                        cv.JobPos = u.ViTriUngTuyen;
                        cv.CareerGoal = u.MucTieuNgheNghiep;
                        cv.Education = u.HocVan;
                        cv.Experience = u.KinhNghiem;
                        cv.Activity = u.HoatDong;
                        cv.Award = u.GiaiThuong;
                        cv.Certificate = u.ChungChi;
                        cv.UploadDate = u.NgayCapNhatCV;

                        ungVien.Fname = u.TenUV;
                        ungVien.Phone = u.SdtUV;
                        ungVien.BirthDate = u.NgaySinhUV;
                        ungVien.Link = u.MangXaHoi;
                        ungVien.Email = u.EmailUV;
                        ungVien.Address_C = u.DiaChi;
                        ungVien.Gender = u.GioiTinhUV;

                        dbContext.SaveChanges();
                        MessageBox.Show("Success!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("CV not found!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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

        public void load_thuXacNhan(FlowLayoutPanel flpl, string Id)
        {
            using (var dbContext = new DeTai_02_Entities())
            {
                try
                {
                    var thuXacNhanList = (from letter in dbContext.Letter
                                          join jobPosting in dbContext.JobPostings on new { letter.IdCompany, letter.IdJobPostings } equals new { jobPosting.IdCompany, jobPosting.IdJobPostings }
                                          where letter.IdCandidate == Id
                                          select new
                                          {
                                              Letter = letter,
                                              JobPosting = jobPosting
                                          }).ToList();

                    Xuat_ThongTin xuat_TT = new Xuat_ThongTin();

                    foreach (var lt in thuXacNhanList)
                    {
                        Thu t = new Thu(lt.Letter.IdCompany, lt.Letter.IdJobPostings, lt.Letter.IdCandidate, lt.Letter.Sender, lt.Letter.Receiver, lt.Letter.Title, lt.Letter.Content, lt.Letter.DateSent, lt.Letter.InterviewDate, lt.Letter.InterViewTime);
                        flpl.Controls.Add(xuat_TT.them_thuXacNhan(lt.JobPosting.JobName, lt.JobPosting.DatePosted, t));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error! \n" + ex.Message, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public UngVien_Tin chiTiet_CV(string IdCandidate)
        {
            return db.thucThi_chiTietCV(IdCandidate);
        }

        public void dinhDang_rtbx_UV(UngVien_DinhDang_rtbx UV_dinhDang)
        {
            using (var context = new DeTai_02_Entities())
            {
                // Xóa các bản ghi tồn tại trước đó
                var existingRecords = context.DinhDang_rtbx_UV
                                             .Where(d => d.Id == UV_dinhDang.Id && d.RtbxStyle == UV_dinhDang.Kieu_rtbx)
                                             .ToList();
                context.DinhDang_rtbx_UV.RemoveRange(existingRecords);

                // Thêm bản ghi mới
                var newRecord = new DinhDang_rtbx_UV
                {
                    Id = UV_dinhDang.Id,
                    RtbxStyle = UV_dinhDang.Kieu_rtbx,
                    Color = UV_dinhDang.MauSac,
                    Font = UV_dinhDang.KieuChu,
                    FontStyle = UV_dinhDang.HieuUng,
                    Size = Convert.ToDecimal(UV_dinhDang.KichCo)
                };
                context.DinhDang_rtbx_UV.Add(newRecord);

                context.SaveChanges();
            }
        }

        public UngVien_DinhDang_rtbx layDinhDang(string Id, string tenRtbx)
        {
            return db.thucThi_layDinhDang_UV(Id, tenRtbx);
        }

    }
}
