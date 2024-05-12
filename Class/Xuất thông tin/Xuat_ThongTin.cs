using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using static DevExpress.Skins.SolidColorHelper;
using Guna.UI2.WinForms;
using System.Drawing.Imaging;
using TheArtOfDevHtmlRenderer.Adapters;

namespace Project_Windows_04
{
    public class Xuat_ThongTin
    {
        Xuat_ThongTin_DAO xuatTT_DAO = new Xuat_ThongTin_DAO();
        private string IdCompany;
        private string IdJobPostings;
        private string userType;

        public Xuat_ThongTin() { }

        //  up tin lên trang chủ
        public UC_TinTuyenDung them_tinTuyenDung(TuyenDung_Tin t, string userType)
        {
            UC_TinTuyenDung UC_tinTuyenDung = new UC_TinTuyenDung();

            UC_tinTuyenDung.lbl_tenCongViec.Text = t.TenCongViec;
            UC_tinTuyenDung.pbx_logoCongTy.Image = Image.FromFile(t.LogoCongTy);
            UC_tinTuyenDung.lbl_tenCongTy.Text = t.TenCongTy;
            UC_tinTuyenDung.lbl_luong.Text = t.Luong.ToString();
            UC_tinTuyenDung.lbl_nganhNghe.Text = t.NganhNghe;
            UC_tinTuyenDung.lbl_kinhNghiem.Text = t.KinhNghiem;
            UC_tinTuyenDung.lbl_hinhThucLamViec.Text = t.HinhThucLamViec;
            UC_tinTuyenDung.lbl_diaChi.Text = t.DiaChi;

            //  lấy userType của tài khoản đang đăng nhập
            this.userType = userType;

            //  ẩn checkbox theo dõi tin nếu chưa đăng nhập hoặc là NTD
            if (this.userType == "Employer" || this.userType == "null")
            {
                UC_tinTuyenDung.cbx_theoDoi.Hide();
            }
            else
            {
                //  lấy dữ liệu từ table LuuTin rồi load trạng thái đã check vào checkbox
                //  truyền tableName "LuuTin" để 2 sự kiện checkchanged của 2 cbx tận dụng các hàm truy vấn 
                if (xuatTT_DAO.trangThai_checkChanged("LuuTin", t.IdCompany, t.IdJobPostings, userType) == "flw")
                    UC_tinTuyenDung.cbx_theoDoi.Checked = true;
            }    
           
            //  truyền IdCompany, IdJobPostings, và userType(nếu đăng nhập bằng acc ứng viên thì userType lúc này là IdCandidate) để lưu vào table lưu tin
            UC_tinTuyenDung.cbx_theoDoi.CheckedChanged += (sender, e) => Cbx_theoDoi_CheckedChanged1(sender, e, "LuuTin", t.IdCompany, t.IdJobPostings, userType);
            UC_tinTuyenDung.Click += (sender, e) => UC_tinTuyenDung_Click(sender, e, t);

            //  mặc định quá hạn bài đăng là đánh dấu
            if (Convert.ToDateTime(t.HanChot) < DateTime.Now)
                UC_tinTuyenDung.pbx_hanChot.Visible = true;

            //  phải return UC_tinTuyenDung vì cần add 1 control vào flowlayoutpanel
            return UC_tinTuyenDung;
        }

        private void Cbx_theoDoi_CheckedChanged1(object sender, EventArgs e, string tableName, string IdCompany, string IdJobPostings, string IdCandidate)
        {
            //  vì dùng checkbox trong guna nên phải ép nó theo guna
            Guna2ImageCheckBox cbx = sender as Guna2ImageCheckBox;

            if (cbx.Checked)
                xuatTT_DAO.luuTin(tableName, IdCompany, IdJobPostings, IdCandidate);
            else
                xuatTT_DAO.xoaTinDaLuu(tableName, IdCompany, IdJobPostings, IdCandidate);
        }

        //  xem chi tiết tin tuyển dụng
        private void UC_tinTuyenDung_Click(object sender, EventArgs e, TuyenDung_Tin t)
        {
            //  lấy Id của công ty đã đăng tin này và Id của tin đó
            this.IdCompany = t.IdCompany;
            this.IdJobPostings = t.IdJobPostings;

            ChiTietTinTuyenDung chiTiet_tin = new ChiTietTinTuyenDung();

            if (this.userType == "Employer" || this.userType == "null")
            {
                chiTiet_tin.btn_ungTuyen.Hide();
            }       
            else
            {
                chiTiet_tin.btn_ungTuyen.Click += Btn_ungTuyen_Click;
            }

            load_tinLienQuan(t, chiTiet_tin.flpl_tinLienQuan);

            //  xuất dữ liệu lên controls trong ChiTietTinTuyenDung
            chiTiet_tin.xuatDuLieu(t);

            chiTiet_tin.Show();
        }

        private void load_tinLienQuan(TuyenDung_Tin t, FlowLayoutPanel flpl)
        {
            using (var dbContext = new DeTai_02_Entities())
            {
                var tinTuyenDungs = dbContext.NHATUYENDUNG
                    .Join(dbContext.JobPostings,
                          ntd => ntd.Id,
                          jp => jp.IdCompany,
                          (ntd, jp) => new { NhaTuyenDung = ntd, JobPosting = jp })
                    .Where(jp => jp.JobPosting.Job == t.NganhNghe && jp.JobPosting.IdJobPostings != t.IdJobPostings)
                    .ToList();

                foreach (var tinTD in tinTuyenDungs)
                {
                    TuyenDung_Tin tt = new TuyenDung_Tin
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

                    UC_TinLienQuan uc = new UC_TinLienQuan();

                    uc.lbl_tenCongViec.Text     = tt.TenCongViec;
                    uc.pbx_logoCongTy.Image     = Image.FromFile(tt.LogoCongTy);
                    uc.lbl_tenCongTy.Text       = tt.TenCongTy;
                    uc.lbl_luong.Text           = tt.Luong.ToString();
                    uc.lbl_nganhNghe.Text       = tt.NganhNghe;
                    uc.lbl_kinhNghiem.Text      = tt.KinhNghiem;
                    uc.lbl_hinhThucLamViec.Text = tt.HinhThucLamViec;
                    uc.lbl_diaChi.Text          = tt.DiaChi;

                    //  mặc định quá hạn bài đăng là đánh dấu
                    if (Convert.ToDateTime(tt.HanChot) < DateTime.Now)
                        uc.pbx_hanChot.Visible = true;

                    uc.Click += (sender, e) => UC_tinTuyenDung_Click(sender, e, tt);

                    flpl.Controls.Add(uc);
                }
            }
        }

        //  ứng viên nộp CV
        private void Btn_ungTuyen_Click(object sender, EventArgs e)
        {
            xuatTT_DAO.ungTuyen(this.userType, this.IdCompany, this.IdJobPostings);
        }

        //  thêm tin vừa đăng vào danh sách tin đã đăng bên nhà tuyển dụng
        public UC_TinDaDang them_tinDaDang(string IdCompany, string IdJobPostings, string tenCongViec, string ngayDang, string HanChot)
        {
            UC_TinDaDang UC_tinDaDang = new UC_TinDaDang();

            UC_tinDaDang.lbl_ngayDang.Text = ngayDang;
            UC_tinDaDang.lbl_tenCongViec.Text = tenCongViec;

            ////  kiểm tra có UV nào ứng tuyển vào ko, nếu có thì hiện chuông thông báo
            //if (xuatTT_DAO.KiemTraBoMoiThemVao(IdCompany, IdJobPostings))
            //    UC_tinDaDang.pbx_thongBao.Visible = true;

            UC_tinDaDang.Click += (sender, e) => UC_tinDaDang_Click1(sender, e, IdCompany, IdJobPostings);
            // Truyền trực tiếp biến vào phương thức xử lý sự kiện
            UC_tinDaDang.btn_xoaTin.Click += (sender, e) => Btn_xoaTin_Click(IdCompany, IdJobPostings);
            UC_tinDaDang.btn_suaTin.Click += (sender, e) => Btn_suaTin_Click(IdCompany, IdJobPostings);

            //  mặc định quá hạn bài đăng là đánh dấu
            if (Convert.ToDateTime(HanChot) < DateTime.Now)
                UC_tinDaDang.pbx_hanChot.Visible = true;

            UC_tinDaDang.lbl_soLuongUV.Text = xuatTT_DAO.demSoUV(IdCompany, IdJobPostings).ToString();

            return UC_tinDaDang;
        }

        //  load toàn bộ danh sách CV đã nộp vào 1 tin tuyển dụng
        private void UC_tinDaDang_Click1(object sender, EventArgs e, string IdCompany, string IdJobPostings)
        {
            TuyenDung_DS_CVs DSCV = new TuyenDung_DS_CVs();

            xuatTT_DAO.load_DS_CV(DSCV.flpl_danhSachCV, DSCV.pnl_chiTietCV, IdCompany, IdJobPostings);

            DSCV.ShowDialog();
        }

        //  xóa 1 tin tuyển dụng trong danh sách tin đã đăng
        private void Btn_xoaTin_Click(string IdCompany, string IdJobPostings)
        {
            xuatTT_DAO.xoaTinTuyenDung(IdCompany, IdJobPostings);
        }

        //  sửa 1 tin tuyển dụng trong danh sách tin đã đăng
        private void Btn_suaTin_Click(string IdCompany, string IdJobPostings)
        {
            TuyenDung_ChinhSuaTin TD_CST = new TuyenDung_ChinhSuaTin();

            TD_CST.layDuLieu(xuatTT_DAO.chiTietTin(IdCompany, IdJobPostings));

            TD_CST.ShowDialog();
        }

        //  add 1 CV vào flpl, được dùng bên dbConnection
        public UC_CVs_daNop them_CV(Panel pnl, string IdCompany, string IdJobPostings, string IdCandidate, string tenCongViec, string ngayDang)
        {
            UC_CVs_daNop UC_CV = new UC_CVs_daNop();

            UC_CV.lbl_ngayDang.Text = ngayDang;
            UC_CV.lbl_fullName.Text = tenCongViec;

            //  lấy dữ liệu từ table LuuTin rồi load trạng thái đã check vào checkbox
            //  truyền tableName "LuuCV" để 2 sự kiện checkchanged của 2 cbx tận dụng các hàm truy vấn 
            if (xuatTT_DAO.trangThai_checkChanged("LuuCV", IdCompany, IdJobPostings, IdCandidate) == "flw")
                UC_CV.cbx_theoDoi.Checked = true;

            //  truyền đủ IdCompany, IdJobPostings, IdCandidate để dùng cho Btn_phanHoi_Click giúp khởi tạo đối tượng Thu
            //  truyền UC_CV để dùng cho sự kiện click feedback, nếu feedback thành công thì hiện pbx_daGuiThu
            //  truyền pnl để dùng cho sự kiện khi click vào 1 CV thì hiện chi tiết CV đó, pnl đc dùng để add UC chứa CV đó vào
            UC_CV.Click += (sender, e) => UC_CV_Click(sender, e, UC_CV, pnl, IdCompany, IdJobPostings, IdCandidate);

            //  truyền đủ IdCompany, IdJobPostings, IdCandidate để tìm và xóa 1 CV
            UC_CV.btn_xoaCV.Click += (sender, e) => Btn_xoaCV_Click(sender, e, IdCompany, IdJobPostings, IdCandidate);
            //  tận dụng hàm checkchanged của cbx trong phần lưu tin của ứng viên
            UC_CV.cbx_theoDoi.CheckedChanged += (sender, e) => Cbx_theoDoi_CheckedChanged1(sender, e, "LuuCV", IdCompany, IdJobPostings, IdCandidate);

            //  kiểm tra đã gửi thu hay chưa, nếu gửi r thì hiện pbx
            if (xuatTT_DAO.kiemTra_daGuiThu(IdCompany, IdJobPostings, IdCandidate))
                UC_CV.pbx_daGuiThu.Visible = true;

            return UC_CV;
        }

        //  xóa CV của 1 ứng viên ra khỏi danh sách CV đã nộp
        private void Btn_xoaCV_Click(object sender, EventArgs e, string IdCompany, string IdJobPostings, string IdCandidate)
        {
            xuatTT_DAO.xoaCV(IdCompany, IdJobPostings, IdCandidate);
        }

        //  xem chi tiết thông tin 1 CV của 1 ứng viên
        private void UC_CV_Click(object sender, EventArgs e, UC_CVs_daNop UC_CV, Panel pnl, string IdCompany, string IdJobPostings, string IdCandidate)
        {
            UC_ChiTietCV uc = new UC_ChiTietCV();

            uc.layDuLieu(xuatTT_DAO.chiTiet_CV(IdCandidate));
            //  gọi sự kiện cho nút feedback
            uc.btn_phanHoi.Click += (s, ev) => Btn_phanHoi_Click(s, ev, UC_CV, IdCompany, IdJobPostings, IdCandidate);
            uc.Dock = DockStyle.Fill;

            //  xóa sạch uc hiện tại trong pnl và add uc mới vào pnl
            pnl.Controls.Clear();
            pnl.Controls.Add(uc);
        }

        //  phản hồi về CV cho 1 ứng viên
        private void Btn_phanHoi_Click(object sender, EventArgs e, UC_CVs_daNop UC_CV, string IdCompany, string IdJobPostings, string IdCandidate)
        {
            ChiTietThu thu = new ChiTietThu();

            //  tìm mail của HR đã tạo tin, tìm mail người nộp CV sau đó đổ thông tin vào ChiTetThu
            thu.xuatDuLieu_khiGui(xuatTT_DAO.chiTietTin(IdCompany, IdJobPostings), xuatTT_DAO.chiTiet_CV(IdCandidate));

            thu.UC_Thu.btn_gui.Click += (s, ev) => Btn_gui_Click(s, ev, UC_CV, thu, IdCompany, IdJobPostings, IdCandidate);

            thu.ShowDialog();
        }

        private void Btn_gui_Click(object sender, EventArgs e, UC_CVs_daNop UC_CV, ChiTietThu thu, string IdCompany, string IdJobPostings, string IdCandidate)
        {
            //  mặc định ko được bỏ trống nội dung thư
            if (thu.kiemTraNull())
            {
                Thu t = new Thu(IdCompany, IdJobPostings, IdCandidate, thu.UC_Thu.tbx_nguoiGui.Text, thu.UC_Thu.tbx_nguoiNhan.Text, thu.UC_Thu.tbx_chuDe.Text, 
                    thu.UC_Thu.rtbx_noiDung.Text, thu.UC_Thu.lbl_ngayGui.Text, thu.UC_Thu.dtpr_ngayPhongVan.Value.ToString(), thu.UC_Thu.dtpr_thoiGIanPhongVan.Value.ToString());

                //  nếu gửi thư thành công thì hiện pbx_daGuiThu
                if (xuatTT_DAO.luuThu(t))
                {
                    UC_CV.pbx_daGuiThu.Visible = true;
                    thu.Close();
                }
            }
            else
                MessageBox.Show("You must fill in all information!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //  thêm 1 thư xác nhận vào danh sách bên ứng viên
        public UC_TinDaDang them_thuXacNhan(string tenCongViec, string ngayDang, Thu t)
        {
            UC_TinDaDang UC_tinDaDang = new UC_TinDaDang();

            UC_tinDaDang.lbl_ngayDang.Text = ngayDang;
            UC_tinDaDang.lbl_tenCongViec.Text = tenCongViec;

            UC_tinDaDang.Click += (sender, e) => UC_tinDaDang_Click(sender, e, t);

            //  ẩn nút chỉnh sửa và xóa
            UC_tinDaDang.btn_xoaTin.Hide();
            UC_tinDaDang.btn_suaTin.Hide();
            UC_tinDaDang.pbx_soLuongUV.Hide();
            UC_tinDaDang.lbl_soLuongUV.Hide();

            return UC_tinDaDang;
        }

        //  sự kiện khi click vào thì hiện chi tiết thư
        private void UC_tinDaDang_Click(object sender, EventArgs e, Thu t)
        {
            ChiTietThu chiTiet_thu = new ChiTietThu();

            chiTiet_thu.xuatDuLieu_khiNhan(t);

            chiTiet_thu.ShowDialog();
        }

        public UC_LichPhongVan them_lichPhongVan(LichPV lichPV)
        {
            UC_LichPhongVan uc_lichPV = new UC_LichPhongVan();

            uc_lichPV.pbx_avatar.Image = Image.FromFile(lichPV.LinkAvatar);
            uc_lichPV.lbl_ngayDang.Text = lichPV.NgayDang;
            uc_lichPV.lbl_ngayPhongVan.Text = lichPV.NgayPhongVan;
            uc_lichPV.lbl_tenCongViec.Text = lichPV.TenCongViec;
            uc_lichPV.lbl_tenUngVien.Text = lichPV.TenUngVien;

            if (Convert.ToDateTime(lichPV.NgayPhongVan) < DateTime.Now)
                uc_lichPV.BackColor = Color.Gray;

            return uc_lichPV;
        }
    }
}
