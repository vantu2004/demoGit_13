using DevExpress.ClipboardSource.SpreadsheetML;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Project_Windows_04
{
    public class Xuat_ThongTin_DAO
    {
        dbConnection db = new dbConnection();

        public Xuat_ThongTin_DAO() { }

        public void ungTuyen(string idCandidate, string idCompany, string idJobPostings)
        {
            using (var context = new DeTai_02_Entities())
            {
                try
                {
                    var application = new Applications
                    {
                        IdCompany = idCompany,
                        IdJobPostings = idJobPostings,
                        IdCandidate = idCandidate
                    };

                    context.Applications.Add(application);
                    context.SaveChanges();

                    MessageBox.Show("Success!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Applyed! \n" , "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public void xoaTinTuyenDung(string idCompany, string idJobPostings)
        {
            using (var context = new DeTai_02_Entities())
            {
                try
                {
                    // Delete Applications records
                    var applicationsToDelete = context.Applications.Where(a => a.IdCompany == idCompany && a.IdJobPostings == idJobPostings);
                    context.Applications.RemoveRange(applicationsToDelete);

                    // Delete DinhDang_rtbx_NTD records
                    var dinhDangRecordsToDelete = context.DinhDang_rtbx_NTD.Where(d => d.IdCompany == idCompany && d.IdJobPostings == idJobPostings);
                    context.DinhDang_rtbx_NTD.RemoveRange(dinhDangRecordsToDelete);

                    // Delete LuuCV records
                    var luuCvRecordsToDelete = context.LuuCV.Where(l => l.IdCompany == idCompany && l.IdJobPostings == idJobPostings);
                    context.LuuCV.RemoveRange(luuCvRecordsToDelete);

                    // Delete LuuTin records
                    var luuTinRecordsToDelete = context.LuuTin.Where(l => l.IdCompany == idCompany && l.IdJobPostings == idJobPostings);
                    context.LuuTin.RemoveRange(luuTinRecordsToDelete);

                    // Delete JobPostings record
                    var jobPostingsToDelete = context.JobPostings.SingleOrDefault(j => j.IdJobPostings == idJobPostings);
                    if (jobPostingsToDelete != null)
                        context.JobPostings.Remove(jobPostingsToDelete);

                    context.SaveChanges();
                    MessageBox.Show("Success!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error! \n" + ex.Message, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public TuyenDung_Tin chiTietTin(string IdCompany, string IdJobPostings)
        {
            using (var context = new DeTai_02_Entities()) // Thay DeTai_02_Entities bằng tên DbContext thực tế của bạn
            {
                var chiTietTin = (from nhaTuyenDung in context.NHATUYENDUNG
                                  join jobPostings in context.JobPostings on nhaTuyenDung.Id equals jobPostings.IdCompany
                                  where jobPostings.IdCompany == IdCompany && jobPostings.IdJobPostings == IdJobPostings
                                  select new
                                  {
                                      NhaTuyenDung = nhaTuyenDung,
                                      JobPosting = jobPostings
                                  }).FirstOrDefault();

                if (chiTietTin != null)
                {
                    var t = new TuyenDung_Tin
                    {
                        IdCompany = chiTietTin.NhaTuyenDung.Id,
                        IdJobPostings = chiTietTin.JobPosting.IdJobPostings,
                        UserType = chiTietTin.NhaTuyenDung.UserType,
                        LogoCongTy = chiTietTin.JobPosting.IconCompany,
                        TenCongTy = chiTietTin.NhaTuyenDung.Company,
                        MangXaHoi = chiTietTin.NhaTuyenDung.SocialNetwork,
                        DiaChi = chiTietTin.NhaTuyenDung.JobLocation,
                        NganhNghe = chiTietTin.JobPosting.Job,
                        TenCongViec = chiTietTin.JobPosting.JobName,
                        Luong = Convert.ToDouble(chiTietTin.JobPosting.Salary),
                        KinhNghiem = chiTietTin.JobPosting.Experience,
                        HinhThucLamViec = chiTietTin.JobPosting.WorkFormat,
                        TenHR = chiTietTin.NhaTuyenDung.Fname,
                        EmailHR = chiTietTin.NhaTuyenDung.Email,
                        SdtHR = chiTietTin.NhaTuyenDung.PhoneNTD,
                        ViTriCongTacHR = chiTietTin.NhaTuyenDung.JobPos,
                        NgayDang = chiTietTin.JobPosting.DatePosted,
                        HanChot = chiTietTin.JobPosting.Deadline,
                        MoTaCongViec = chiTietTin.JobPosting.JobDescription,
                        YeuCau = chiTietTin.JobPosting.Requirements,
                        LoiIch = chiTietTin.JobPosting.Benefit,
                        HoatDong = chiTietTin.JobPosting.Activity,
                        GiaiThuong = chiTietTin.JobPosting.Award,
                        GiayPhep = chiTietTin.JobPosting.License
                    };

                    return t;
                }
                else
                {
                    MessageBox.Show("Not found!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
        }

        public void load_DS_CV(FlowLayoutPanel flpl, Panel pnl, string idCompany, string idJobPostings)
        {
            using (var context = new DeTai_02_Entities())
            {
                var applications = (from application in context.Applications
                                    join candidate in context.UNGVIEN on application.IdCandidate equals candidate.Id
                                    where application.IdCompany == idCompany && application.IdJobPostings == idJobPostings
                                    select new
                                    {
                                        Application = application,
                                        Candidate = candidate
                                    }).ToList();

                Xuat_ThongTin xuat_TT = new Xuat_ThongTin();

                //  cập nhật ngày nộp là ngày hiện tại
                DateTime dt = DateTime.Now;

                foreach (var item in applications)
                {
                    flpl.Controls.Add(xuat_TT.them_CV(pnl, item.Application.IdCompany, item.Application.IdJobPostings, item.Application.IdCandidate, item.Candidate.Fname, dt.ToString("dd/MM/yyyy")));
                }   
            }
        }


        public UngVien_Tin chiTiet_CV(string IdCandidate)
        {
            return db.thucThi_chiTietCV(IdCandidate);
        }

        public void xoaCV(string IdCompany, string IdJobPostings, string IdCandidate)
        {
            using (var context = new DeTai_02_Entities())
            {
                try
                {
                    var applicationToDelete = context.Applications.FirstOrDefault(a => a.IdCompany == IdCompany && a.IdJobPostings == IdJobPostings && a.IdCandidate == IdCandidate);
                    if (applicationToDelete != null)
                    {
                        context.Applications.Remove(applicationToDelete);
                        context.SaveChanges();
                        MessageBox.Show("Success!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Application not found!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error! \n" + ex.Message, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //  trả true false để biết là có lưu thư thành công hay ko, nếu có thì hiện pbx_daGuiThu
        public bool luuThu(Thu t)
        {
            using (var context = new DeTai_02_Entities())
            {
                string time = Convert.ToDateTime(t.NgayPhongVan).ToShortDateString() + " " + Convert.ToDateTime(t.ThoiGianPhongVan).ToShortTimeString();
;
                try
                {
                    if (kiemTraTrungLichHen(time, t.IdCompany, t.IdJobPostings))
                    {
                        // Lưu thư
                        context.Letter.Add(new Letter
                        {
                            IdCompany = t.IdCompany,
                            IdJobPostings = t.IdJobPostings,
                            IdCandidate = t.IdCandidate,
                            Sender = t.NguoiGui,
                            Receiver = t.NguoiNhan,
                            Title = t.ChuDe,
                            Content = t.NoiDung,
                            DateSent = t.NgayGui,
                            InterviewDate = t.NgayPhongVan,
                            InterViewTime = t.ThoiGianPhongVan
                        });

                        context.SaveChanges();

                        // Lấy thông tin về công việc
                        var jobDetails = chiTietTin(t.IdCompany, t.IdJobPostings);

                        // Lấy thông tin về ứng viên
                        var candidateDetails = chiTiet_CV(t.IdCandidate);

                        // Lưu lịch phỏng vấn
                        context.LichPhongVan.Add(new LichPhongVan
                        {
                            IdCompany = t.IdCompany,
                            IdJobPostings = t.IdJobPostings,
                            IdCandidate = t.IdCandidate,
                            LinkAvatar = candidateDetails.AnhDaiDien,
                            UpdateDate = jobDetails.NgayDang,
                            InterviewDate = t.NgayPhongVan,
                            InterviewTime = t.ThoiGianPhongVan,
                            JobName = jobDetails.TenCongViec,
                            CandidateName = candidateDetails.TenUV
                        });
                        context.SaveChanges();
                        MessageBox.Show("Success!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Appointment schedule overlapped!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("You have made an appointment with this employee. \n" , "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
        }

        private bool kiemTraTrungLichHen(string time, string IdCompany, string IdJobPostings)
        {
            using (var context = new DeTai_02_Entities())
            {
                try
                {
                    var allLetters = context.Letter
                                            .Where(l => l.IdCompany == IdCompany && l.IdJobPostings == IdJobPostings)
                                            .ToList();

                    foreach (var l in allLetters)
                    {
                        string time1 = Convert.ToDateTime(l.InterviewDate).ToShortDateString() + " " + Convert.ToDateTime(l.InterViewTime).ToShortTimeString();

                        if (time == time1)
                            return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error! \n" + ex.Message, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return true;
        }


        public void luuTin(string tableName, string IdCompany, string IdJobPostings, string IdCandidate)
        {
            string sqlQuery_xoaTinDaLuu = string.Format("DELETE FROM {0} WHERE IdCompany = '{1}' AND IdJobPostings = '{2}' AND IdCandidate = '{3}'", tableName, IdCompany, IdJobPostings, IdCandidate);
            db.thucThi_taoTin_chinhSuaTin_koMessageBox(sqlQuery_xoaTinDaLuu);

            string sqlQuery_ungTuyen = string.Format("INSERT INTO {0} (IdCompany, IdJobPostings, IdCandidate, Follow) VALUES ('{1}', '{2}', '{3}', '{4}')", tableName, IdCompany, IdJobPostings, IdCandidate, "flw");
            db.thucThi_taoTin_chinhSuaTin_koMessageBox(sqlQuery_ungTuyen);
        }

        public void xoaTinDaLuu(string tableName, string IdCompany, string IdJobPostings, string IdCandidate)
        {
            string sqlQuery_xoaTinDaLuu = string.Format("DELETE FROM {0} WHERE IdCompany = '{1}' AND IdJobPostings = '{2}' AND IdCandidate = '{3}'", tableName, IdCompany, IdJobPostings, IdCandidate);
            db.thucThi_taoTin_chinhSuaTin_koMessageBox(sqlQuery_xoaTinDaLuu);
        }

        public string trangThai_checkChanged(string tableName, string IdCompany, string IdJobPostings, string IdCandidate)
        {
            string sqlQuery_trangThai_checkChanged = string.Format("SELECT * FROM {0} WHERE IdCompany = '{1}' AND IdJobPostings = '{2}' AND IdCandidate = '{3}'", tableName, IdCompany, IdJobPostings, IdCandidate);

            return db.thucThi_trangThai_checkChanged(sqlQuery_trangThai_checkChanged);
        }

        public bool kiemTra_daGuiThu(string IdCompany, string IdJobPostings, string IdCandidate)
        {
            using (var context = new DeTai_02_Entities())
            {
                try
                {
                    // Kiểm tra xem có thư từ nào tồn tại trong cơ sở dữ liệu với các Id đã cung cấp không
                    var letterExists = context.Letter
                                            .Any(l => l.IdCompany == IdCompany &&
                                                      l.IdJobPostings == IdJobPostings &&
                                                      l.IdCandidate == IdCandidate);

                    return letterExists;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi! \n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        public int demSoUV(string IdCompany, string IdJobPostings)
        {
            using (var dbContext = new DeTai_02_Entities()) // Thay YourDbContext bằng tên của DbContext của bạn
            {
                // Sử dụng LINQ để đếm số lượng bản ghi phù hợp
                var count = dbContext.Applications
                                     .Where(app => app.IdCompany == IdCompany && app.IdJobPostings == IdJobPostings)
                                     .Count();
                return count;
            }
        }

        //public bool KiemTraBoMoiThemVao(string IdCompany, string IdJobPostings)
        //{
        //    using (var context = new DeTai_02_Entities())
        //    {
        //        // Lấy ra tất cả các bản ghi được thêm mới vào context và thuộc bảng "Applications"
        //        var addedApplications = context.ChangeTracker.Entries<Applications>()
        //                                    .Where(e => e.State == EntityState.Added &&
        //                                                e.Entity.IdCompany == IdCompany &&
        //                                                e.Entity.IdJobPostings == IdJobPostings)
        //                                    .Select(e => e.Entity) // Chọn thực thể từ các bản ghi
        //                                    .ToList();

        //        // Kiểm tra xem có bản ghi nào thỏa mãn điều kiện được thêm mới không
        //        return addedApplications.Any();
        //    }
        //}


    }
}
