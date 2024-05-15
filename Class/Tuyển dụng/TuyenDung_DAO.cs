using DevExpress.Drawing.Internal.Fonts.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.Entity;
using DevExpress.Internal.WinApi.Windows.UI.Notifications;

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
                        IdJobPostings = t.IdJobPostings,
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
                    }) ;

                    dbContext.SaveChanges();

                    MessageBox.Show("Success!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error! \n" + ex.Message, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void load_tinTuyenDung(FlowLayoutPanel flpl, string kieuNguoiDung, string IdCompany)
        {
            db.thucThi_load_tinTuyenDung(flpl, kieuNguoiDung, IdCompany);
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
                        flpl.Controls.Add(xuat_TT.them_tinDaDang(jobPosting.IdCompany, jobPosting.IdJobPostings, jobPosting.JobName, jobPosting.DatePosted, jobPosting.Deadline));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error! \n" + ex.Message, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void load_tinXinViec(FlowLayoutPanel flpl_tinDaDang, FlowLayoutPanel flpl_chiTietTin, FlowLayoutPanel flpl_danhSachTinNhan, Panel pnl_chatBox, string IdCompany)
        {
            using (var context = new DeTai_02_Entities())
            {
                try
                {
                    var tinXinViec = context.TinXinViec
                                            .ToList();

                    foreach (var i in tinXinViec)
                    {
                        //  thiết lập và add tin xin việc đã đăng vào flpl_tinDaDang
                        UC_TInXinViec_DaDang uc_TinXinViec_DaDang = new UC_TInXinViec_DaDang();

                        uc_TinXinViec_DaDang.pbx_avatar.Image = Image.FromFile(i.Avatar);
                        uc_TinXinViec_DaDang.lbl_tenUV.Text = i.Name;
                        uc_TinXinViec_DaDang.lbl_thoiGian.Text = i.DatePosted;

                        uc_TinXinViec_DaDang.Click += (s, ev) => Uc_TinXinViec_DaDang_Click(s, ev, flpl_chiTietTin, flpl_danhSachTinNhan, pnl_chatBox, i.DatePosted);
                        uc_TinXinViec_DaDang.btn_xoaTin.Hide();

                        flpl_tinDaDang.Controls.Add(uc_TinXinViec_DaDang);
                        flpl_chiTietTin.Controls.Add(chiTiet_tinXinViec(i.Id, i.DatePosted, flpl_danhSachTinNhan, pnl_chatBox, IdCompany));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error! \n" + ex.Message, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Uc_TinXinViec_DaDang_Click(object sender, EventArgs e, FlowLayoutPanel flpl, FlowLayoutPanel flpl_danhSachTinNhan, Panel pnl_chatBox, string thoiGian)
        {
            flpl_danhSachTinNhan.Controls.Clear();
            pnl_chatBox.Controls.Clear();

            foreach (var i in flpl.Controls)
            {
                if (i is UC_TinXinViec uc)
                {
                    if (uc.lbl_thoiGianDang.Text != thoiGian)
                        uc.Visible = false;
                    else
                        uc.Visible = true;
                }    
            }    
        }

        private UC_TinXinViec chiTiet_tinXinViec(string Id, string thoiGian, FlowLayoutPanel flpl_danhSachTinNhan, Panel pnl_chatBox, string IdCompany)
        {
            using (var context = new DeTai_02_Entities())
            {
                var t = (from tin in context.TinXinViec
                         where tin.Id == Id && tin.DatePosted == thoiGian
                         select tin).FirstOrDefault();

                if (t == null)
                {
                    MessageBox.Show("Not found!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

                UC_TinXinViec uc = new UC_TinXinViec();

                uc.pbx_avatar.Image = Image.FromFile(t.Avatar);
                uc.lbl_tenUV.Text = t.Name;
                uc.lbl_thoiGianDang.Text = t.DatePosted;
                uc.rtbx_noiDung.Text = t.Content;
                //  phải gọi hàm này để tùy chỉnh lại kích thước cho phù hợp, nếu ko gọi hàm này thì khi gõ chữ thì sự kiện textchange mới xảy ra
                uc.loadRtbx(uc.rtbx_noiDung);

                uc.Dock = DockStyle.Top;

                uc.btn_gui.Hide();
                uc.btn_chinhSua.Hide();
                uc.btn_binhLuan.Click += (sender, e) => Btn_binhLuan_Click(sender, e, Id, t.Name, thoiGian, flpl_danhSachTinNhan, pnl_chatBox, IdCompany);

                return uc;
            }
        }

        private void Btn_binhLuan_Click(object sender, EventArgs e, string Id, string ten, string thoiGian, FlowLayoutPanel flpl_danhSachTinNhan, Panel pnl_chatBox, string IdCompany)
        {
            flpl_danhSachTinNhan.Controls.Clear();

            UC_ChatBox uc_chatBox = new UC_ChatBox();

            uc_chatBox.btn_gui.Click += (s, ev) => Btn_gui_Click(s, ev, Id, thoiGian, uc_chatBox.rtbx_boxChat, flpl_danhSachTinNhan, IdCompany);

            pnl_chatBox.Controls.Add(uc_chatBox);

            load_danhSachTinNhan(Id, IdCompany, ten, thoiGian, flpl_danhSachTinNhan);
        }

        private void load_danhSachTinNhan(string Id, string IdCompany, string ten, string thoiGian, FlowLayoutPanel flpl_danhSachTinNhan)
        {
            using (var context = new DeTai_02_Entities())
            {
                var t = (from tin in context.TinNhan
                         where tin.IdCandidate == Id && tin.DatePosted_up == thoiGian
                         select tin).ToList();

                foreach(var i in t)
                {
                    UC_TinNhan uc_tinNhan = new UC_TinNhan();
                    uc_tinNhan.pbx_avatar.Image = Image.FromFile(i.Avatar);

                    //  tên chủ bài viết đc chuyển màu đỏ
                    if (i.Name == ten && i.DatePosted_up == thoiGian)
                    {
                        uc_tinNhan.lbl_tenUV.Text = i.Name + " (Writer)";
                        uc_tinNhan.lbl_tenUV.ForeColor = Color.Red;
                    }

                    uc_tinNhan.lbl_thoiGianDang.Text = i.DateSent;
                    uc_tinNhan.rtbx_noiDung.Text = i.Content;

                    uc_tinNhan.loadRtbx(uc_tinNhan.rtbx_noiDung);

                    flpl_danhSachTinNhan.Controls.Add(uc_tinNhan);
                }    
            }
        }

        private void Btn_gui_Click(object sender, EventArgs e, string Id, string thoiGian, RichTextBox rtbx, FlowLayoutPanel flpl_danhSachTinNhan, string IdCompany)
        {
            using (var context = new DeTai_02_Entities())
            {
                //  lấy logo công ty và tên công ty
                var result = (from jobPosting in context.JobPostings
                              join company in context.NHATUYENDUNG on jobPosting.IdCompany equals company.Id
                              where jobPosting.IdCompany == IdCompany
                              select new
                              {
                                  IconCompany = jobPosting.IconCompany,
                                  Company = company.Company
                              }).FirstOrDefault();

                //  thời gian gửi là hiện tại
                string time = DateTime.Now.ToString();

                context.TinNhan.Add(new TinNhan
                {
                    IdCandidate = Id,
                    DatePosted_up = thoiGian,
                    DateSent = time,
                    Avatar = result.IconCompany,
                    Name = result.Company,
                    Content = rtbx.Text
                });

                context.SaveChanges();

                UC_TinNhan uc_tinNhan = new UC_TinNhan();
                uc_tinNhan.pbx_avatar.Image = Image.FromFile(result.IconCompany);
                uc_tinNhan.lbl_tenUV.Text = result.Company;
                uc_tinNhan.lbl_thoiGianDang.Text = time;
                uc_tinNhan.rtbx_noiDung.Text = rtbx.Text;

                uc_tinNhan.loadRtbx(uc_tinNhan.rtbx_noiDung);

                flpl_danhSachTinNhan.Controls.Add(uc_tinNhan);

                rtbx.Text = "";
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
                        LichPV lichPV = new LichPV(lichPhongVan.LinkAvatar, lichPhongVan.UpdateDate, Convert.ToDateTime(lichPhongVan.InterviewDate).ToShortDateString() + " " + Convert.ToDateTime(lichPhongVan.InterviewTime).ToShortTimeString(), lichPhongVan.JobName, lichPhongVan.CandidateName);
                        flpl.Controls.Add(xuat_TT.them_lichPhongVan(lichPV));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error! \n" + ex.Message, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            sapXepLichPV(flpl);
        }

        public void sapXepLichPV(FlowLayoutPanel flpl)
        {
            UserControl[] userControls = flpl.Controls.OfType<UserControl>().ToArray();

            Array.Sort(userControls, (uc1, uc2) =>
            {
                DateTime t1 = Convert.ToDateTime((uc1 as UC_LichPhongVan).lbl_ngayPhongVan.Text);
                DateTime t2 = Convert.ToDateTime((uc2 as UC_LichPhongVan).lbl_ngayPhongVan.Text);

                return t1.CompareTo(t2);
            });

            // Xóa tất cả các UserControl khỏi panel
            flpl.Controls.Clear();

            // Thêm UserControl đã sắp xếp vào panel
            foreach (UserControl uc in userControls)
            {
                flpl.Controls.Add(uc);
            }
        }
    }
}
