using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace Project_Windows_04
{
    internal class dbConnection
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);

        public dbConnection() { }

        //  hàm thực hiện chỉ với 1 lệnh truy vấn nhưng ko xuất messagebox
        public void thucThi_taoTin_chinhSuaTin_koMessageBox(string sqlQuery_taoTin_chinhSuaTin)
        {
            try
            {
                {
                    conn.Open();

                    SqlCommand cmd_TT = new SqlCommand(sqlQuery_taoTin_chinhSuaTin, conn);
                    cmd_TT.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! \n" + ex.Message, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                conn.Close();
            }
        }

        public void thucThi_load_tinTuyenDung(FlowLayoutPanel flowLayoutPanel, string kieuNguoiDung)
        {
            using (var dbContext = new DeTai_02_Entities())
            {
                Xuat_ThongTin xuat_TT = new Xuat_ThongTin();

                var tinTuyenDungs = dbContext.NHATUYENDUNG
                    .Join(dbContext.JobPostings,
                          ntd => ntd.Id,
                          jp => jp.IdCompany,
                          (ntd, jp) => new { NhaTuyenDung = ntd, JobPosting = jp })
                    .ToList();

                foreach (var tinTD in tinTuyenDungs)
                {
                    TuyenDung_Tin t = new TuyenDung_Tin
                    {
                        IdCompany       = tinTD.NhaTuyenDung.Id,
                        IdJobPostings   = tinTD.JobPosting.IdJobPostings,
                        UserType        = tinTD.NhaTuyenDung.UserType,
                        LogoCongTy      = tinTD.JobPosting.IconCompany,
                        TenCongTy       = tinTD.NhaTuyenDung.Company,
                        MangXaHoi       = tinTD.NhaTuyenDung.SocialNetwork,
                        DiaChi          = tinTD.NhaTuyenDung.JobLocation,
                        NganhNghe       = tinTD.JobPosting.Job,
                        TenCongViec     = tinTD.JobPosting.JobName,
                        Luong           = Convert.ToDouble(tinTD.JobPosting.Salary),
                        KinhNghiem      = tinTD.JobPosting.Experience,
                        HinhThucLamViec = tinTD.JobPosting.WorkFormat,
                        TenHR           = tinTD.NhaTuyenDung.Fname,
                        EmailHR         = tinTD.NhaTuyenDung.Email,
                        SdtHR           = tinTD.NhaTuyenDung.PhoneNTD,
                        ViTriCongTacHR  = tinTD.NhaTuyenDung.JobPos,
                        NgayDang        = tinTD.JobPosting.DatePosted,
                        HanChot         = tinTD.JobPosting.Deadline,
                        MoTaCongViec    = tinTD.JobPosting.JobDescription,
                        YeuCau          = tinTD.JobPosting.Requirements,
                        LoiIch          = tinTD.JobPosting.Benefit,
                        HoatDong        = tinTD.JobPosting.Activity,
                        GiaiThuong      = tinTD.JobPosting.Award,
                        GiayPhep        = tinTD.JobPosting.License
                    };

                    flowLayoutPanel.Controls.Add(xuat_TT.them_tinTuyenDung(t, kieuNguoiDung));
                }
            }
        }

        public UngVien_Tin thucThi_chiTietCV(string IdCandidate)
        {
            using (var context = new DeTai_02_Entities())
            {
                var ungVienTin = (from ungVien in context.UNGVIEN
                                  join cv in context.CVs on ungVien.Id equals cv.Id
                                  where ungVien.Id == IdCandidate
                                  select new UngVien_Tin
                                  {
                                      Id = ungVien.Id,
                                      TenUV = ungVien.Fname,
                                      NgaySinhUV = ungVien.BirthDate,
                                      GioiTinhUV = ungVien.Gender,
                                      DiaChi = ungVien.Address_C,
                                      MangXaHoi = ungVien.Link,
                                      SdtUV = ungVien.Phone,
                                      EmailUV = ungVien.Email,
                                      ViTriUngTuyen = cv.JobPos,
                                      NgayCapNhatCV = cv.UploadDate,
                                      MucTieuNgheNghiep = cv.CareerGoal,
                                      HocVan = cv.Education,
                                      KinhNghiem = cv.Experience,
                                      AnhDaiDien = cv.Avatar,
                                      HoatDong = cv.Activity,
                                      GiaiThuong = cv.Award,
                                      ChungChi = cv.Certificate
                                  }).FirstOrDefault();

                if (ungVienTin == null)
                {
                    MessageBox.Show("Not found!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return ungVienTin;
            }
        }

        public TuyenDung_DinhDang_rtbx thucThi_layDinhDang_NTD(string IdCompany, string IdJobPostings, string tenRtbx)
        {
            using (var dbContext = new DeTai_02_Entities())
            {
                var dinhDang = dbContext.DinhDang_rtbx_NTD.FirstOrDefault(d => d.IdCompany == IdCompany && d.IdJobPostings == IdJobPostings && d.RtbxStyle == tenRtbx);

                if (dinhDang != null)
                {
                    TuyenDung_DinhDang_rtbx dd = new TuyenDung_DinhDang_rtbx
                    {
                        IdCompany = dinhDang.IdCompany,
                        IdJobPostings = dinhDang.IdJobPostings,
                        Kieu_rtbx = dinhDang.RtbxStyle,
                        MauSac = dinhDang.Color,
                        KieuChu = dinhDang.Font,
                        HieuUng = dinhDang.FontStyle,
                        KichCo = Convert.ToDouble(dinhDang.Size)
                    };

                    return dd;
                }
            }

            return null;
        }

        public UngVien_DinhDang_rtbx thucThi_layDinhDang_UV(string Id, string kieuRtbx)
        {
            using (var context = new DeTai_02_Entities())
            {
                try
                {
                    var dinhDangEntity = context.DinhDang_rtbx_UV.FirstOrDefault(d => d.Id == Id && d.RtbxStyle == kieuRtbx);

                    if (dinhDangEntity != null)
                    {
                        var dd = new UngVien_DinhDang_rtbx
                        {
                            Id = dinhDangEntity.Id,
                            Kieu_rtbx = dinhDangEntity.RtbxStyle,
                            MauSac = dinhDangEntity.Color,
                            KieuChu = dinhDangEntity.Font,
                            HieuUng = dinhDangEntity.FontStyle,
                            KichCo = Convert.ToDouble(dinhDangEntity.Size)
                        };

                        return dd;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error! '\n" + ex, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return null;
            }
        }

        public string thucThi_trangThai_checkChanged(string sqlQuery_trangThai_checkChanged)
        {
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlQuery_trangThai_checkChanged, conn);
                SqlDataReader data = cmd.ExecuteReader();

                if (data.Read() == true)
                {
                    return data.GetString(3);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! '\n" + ex, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
            return null;
        }
    }
}
