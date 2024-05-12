using DevExpress.Data.ODataLinq.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
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

        public void load_tinXinViec(FlowLayoutPanel flpl, Panel pnl_chiTietTinXinViec, FlowLayoutPanel flpl_danhSachTinNhan, Panel pnl_chatBox, string Id)
        {
            using (var context = new DeTai_02_Entities())
            {
                try
                {
                    var tinXinViec = context.TinXinViec
                                            .Where(t => t.Id == Id)
                                            .ToList();

                    foreach (var i in tinXinViec)
                    {
                        //  thiết lập và add tin xin việc đã đăng vào flpl_tinDaDang
                        UC_TInXinViec_DaDang uc_TinXinViec_DaDang = new UC_TInXinViec_DaDang();
                        
                        uc_TinXinViec_DaDang.pbx_avatar.Image = Image.FromFile(i.Avatar);
                        uc_TinXinViec_DaDang.lbl_tenUV.Text = i.Name;
                        uc_TinXinViec_DaDang.lbl_thoiGian.Text = i.DatePosted;

                        uc_TinXinViec_DaDang.Click += (s, ev) => Uc_TinXinViec_DaDang_Click(s, ev, pnl_chiTietTinXinViec, flpl_danhSachTinNhan, pnl_chatBox, i.Id, i.DatePosted);
                        uc_TinXinViec_DaDang.btn_xoaTin.Click += (s, ev) => Btn_xoaTin_Click(s, ev, i.Id, i.DatePosted);

                        flpl.Controls.Add(uc_TinXinViec_DaDang);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error! \n" + ex.Message, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

        public void Btn_gui_Click(object sender, EventArgs e, FlowLayoutPanel flpl_tinDaDang, Panel pnl_chiTietTinXinViec, FlowLayoutPanel flpl_danhSachTinNhan, Panel pnl_chatBox, UngVien_Tin uv, UC_TinXinViec uc)
        {
            using (var dbContext = new DeTai_02_Entities())
            {
                try
                {
                    string thoiGian = DateTime.Now.ToString();

                    if (!string.IsNullOrEmpty(uc.rtbx_noiDung.Text))
                    {
                        dbContext.TinXinViec.Add(new TinXinViec
                        {
                            Id = uv.Id,
                            Avatar = uv.AnhDaiDien,
                            DatePosted = thoiGian,
                            Name = uv.TenUV,
                            Content = uc.rtbx_noiDung.Text
                        });

                        dbContext.SaveChanges();

                        //  thiết lập và add tin xin việc đã đăng vào flpl_tinDaDang
                        UC_TInXinViec_DaDang uc_TinXinViec_DaDang = new UC_TInXinViec_DaDang();

                        uc_TinXinViec_DaDang.pbx_avatar.Image = Image.FromFile(uv.AnhDaiDien);
                        uc_TinXinViec_DaDang.lbl_tenUV.Text = uv.TenUV;
                        uc_TinXinViec_DaDang.lbl_thoiGian.Text = thoiGian;

                        uc_TinXinViec_DaDang.Click += (s, ev) => Uc_TinXinViec_DaDang_Click(s, ev, pnl_chiTietTinXinViec, flpl_danhSachTinNhan, pnl_chatBox, uv.Id, thoiGian);
                        uc_TinXinViec_DaDang.btn_xoaTin.Click += (s, ev) => Btn_xoaTin_Click(s, ev, uv.Id, thoiGian);

                        flpl_tinDaDang.Controls.Add(uc_TinXinViec_DaDang);

                        MessageBox.Show("Success!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("You must fill in all information!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("The article was posted previously!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void Btn_xoaTin_Click(object sender, EventArgs e, string Id, string thoiGian)
        {
            using (var context = new DeTai_02_Entities())
            {
                var tinCanXoa = context.TinXinViec.Where(a => a.Id == Id && a.DatePosted == thoiGian).ToList();
                var tinNhanCanXoa = context.TinNhan.Where(a => a.IdCandidate == Id && a.DatePosted_up == thoiGian).ToList();

                if (tinCanXoa.Any())
                {
                    context.TinXinViec.RemoveRange(tinCanXoa);
                    context.SaveChanges();

                    context.TinNhan.RemoveRange(tinNhanCanXoa);
                    context.SaveChanges();

                    MessageBox.Show("Success!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No records found to delete.", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void Uc_TinXinViec_DaDang_Click(object sender, EventArgs e, Panel pnl_chiTietXinViec, FlowLayoutPanel flpl_danhSachTinNhan, Panel pnl_chatBox, string Id, string thoiGian)
        {
            pnl_chiTietXinViec.Controls.Clear();

            using (var context = new DeTai_02_Entities())
            {
                var t = (from tin in context.TinXinViec
                         where tin.Id == Id && tin.DatePosted == thoiGian
                         select tin).FirstOrDefault();

                if (t == null)
                {
                    MessageBox.Show("Not found!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                UC_TinXinViec uc = new UC_TinXinViec();

                uc.pbx_avatar.Image = Image.FromFile(t.Avatar);
                uc.lbl_tenUV.Text = t.Name;
                uc.lbl_thoiGianDang.Text = t.DatePosted;
                uc.rtbx_noiDung.Text = t.Content;
                //  phải gọi hàm này để tùy chỉnh lại kích thước cho phù hợp, nếu ko gọi hàm này thì khi gõ chữ thì sự kiện textchange mới xảy ra
                uc.loadRtbx(uc.rtbx_noiDung);

                uc.Dock = DockStyle.Top;

                uc.btn_gui.Enabled = true;
                uc.btn_chinhSua.Click += (s, ev) => Btn_chinhSua_Click(s, ev, Id, thoiGian, uc);
                uc.btn_binhLuan.Click += (s, ev) => Btn_binhLuan_Click(s, ev, Id, thoiGian, flpl_danhSachTinNhan, pnl_chatBox);

                flpl_danhSachTinNhan.Controls.Clear();
                pnl_chatBox.Controls.Clear();
                pnl_chiTietXinViec.Controls.Add(uc);
            }
        }

        private void Btn_binhLuan_Click(object sender, EventArgs e, string Id, string thoiGian, FlowLayoutPanel flpl_danhSachTinNhan, Panel pnl_chatBox)
        {
            flpl_danhSachTinNhan.Controls.Clear();

            UC_ChatBox uc_chatBox = new UC_ChatBox();

            uc_chatBox.btn_gui.Click += (s, ev) => Btn_guiTinNhan_Click(s, ev, Id, thoiGian, uc_chatBox.rtbx_boxChat, flpl_danhSachTinNhan, pnl_chatBox);

            pnl_chatBox.Controls.Add(uc_chatBox);

            load_danhSachTinNhan(Id, thoiGian, flpl_danhSachTinNhan);
        }

        private void Btn_guiTinNhan_Click(object sender, EventArgs e, string Id, string thoiGian, RichTextBox rtbx, FlowLayoutPanel flpl_danhSachTinNhan, Panel pnl_chatBox)
        {
            using (var context = new DeTai_02_Entities())
            {
                var t = (from tin in context.TinXinViec
                         where tin.Id == Id && tin.DatePosted == thoiGian
                         select tin).FirstOrDefault();

                string time = DateTime.Now.ToString();

                context.TinNhan.Add(new TinNhan
                {
                    IdCandidate = Id,
                    DatePosted_up = thoiGian,
                    DateSent = time,
                    Avatar = t.Avatar,
                    Name = t.Name,
                    Content = rtbx.Text
                });

                context.SaveChanges();

                UC_TinNhan uc_tinNhan = new UC_TinNhan();
                uc_tinNhan.pbx_avatar.Image = Image.FromFile(t.Avatar);
                uc_tinNhan.lbl_tenUV.Text = t.Name;
                uc_tinNhan.lbl_thoiGianDang.Text = time;
                uc_tinNhan.rtbx_noiDung.Text = rtbx.Text;

                uc_tinNhan.loadRtbx(uc_tinNhan.rtbx_noiDung);

                flpl_danhSachTinNhan.Controls.Add(uc_tinNhan);

                rtbx.Text = "";
            }
        }

        private void load_danhSachTinNhan(string Id, string thoiGian, FlowLayoutPanel flpl_danhSachTinNhan)
        {
            using (var context = new DeTai_02_Entities())
            {
                var t = (from tin in context.TinNhan
                         where tin.IdCandidate == Id && tin.DatePosted_up == thoiGian
                         select tin).ToList();

                foreach (var i in t)
                {
                    UC_TinNhan uc_tinNhan = new UC_TinNhan();
                    uc_tinNhan.pbx_avatar.Image = Image.FromFile(i.Avatar);
                    uc_tinNhan.lbl_tenUV.Text = i.Name;
                    uc_tinNhan.lbl_thoiGianDang.Text = i.DateSent;
                    uc_tinNhan.rtbx_noiDung.Text = i.Content;

                    uc_tinNhan.loadRtbx(uc_tinNhan.rtbx_noiDung);

                    flpl_danhSachTinNhan.Controls.Add(uc_tinNhan);
                }
            }
        }

        public void Btn_chinhSua_Click(object sender, EventArgs e, string Id, string thoiGian, UC_TinXinViec uc)
        {
            using (var context = new DeTai_02_Entities())
            {
                try
                {
                    var t = (from tin in context.TinXinViec
                             where tin.Id == Id && tin.DatePosted == thoiGian
                             select tin).FirstOrDefault();

                    if (t != null)
                    {
                        t.Content = uc.rtbx_noiDung.Text;

                        context.SaveChanges();

                        MessageBox.Show("Success!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Not found!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
