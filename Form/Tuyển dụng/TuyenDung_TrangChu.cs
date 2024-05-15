using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Project_Windows_04
{
    public partial class TuyenDung_TrangChu : Form
    {
        private TuyenDung_DAO NTD_DAO = new TuyenDung_DAO();
        private Xuat_ThongTin xuat_TT = new Xuat_ThongTin();
        private List<TuyenDung_DinhDang_rtbx> list_TD_dinhDang = new List<TuyenDung_DinhDang_rtbx>();
        private string linkLogo;
        private string linkGiayPhep;
        private string IdCompany;
        private string IdJobPostings;

        public TuyenDung_TrangChu()
        {
            InitializeComponent();
        }

        public void TuyenDung_TrangChu_Load(object sender, EventArgs e)
        {
            UC_BangTin_NTD.btn_dangTinTuyenDung.Hide();
            UC_BangTin_NTD.btn_dangNhap.Hide();
            UC_BangTin_NTD.btn_dangKy.Hide();
           

            //  load toàn bộ dữ liệu của NHATUYENDUNG và JobPostings lên flowlayoutpanel, click vào để xem chi tiết tin, truyền IdCompany và Employer để xác định mỗi tin đc đăng
            NTD_DAO.load_tinTuyenDung(UC_BangTin_NTD.flpl_danhSachTinTuyenDung, "Employer", IdCompany);

            //  load toàn bộ tin đã đăng của 1 NTD lên flowlayoutpanel, click vào để xem danh sách ứng viên đã nộp CV, truyền IdCompany để xác định mỗi tin đc đăng
            NTD_DAO.load_tinDaDang(flpl_tinDaDang, IdCompany);

            //  load cụ thể 1 vài thông tin về CV đã gửi mail, đồng thời hiện lịch phỏng vấn
            NTD_DAO.load_lichPhongVan(flpl_lichPhongVan, IdCompany);

            // load toàn bộ tin xin việc lên flpl_tinXinViecDaDang
            NTD_DAO.load_tinXinViec(flpl_tinDaDang01, flpl_chiTietTinXinViec, flpl_tinNhan, pnl_chatBox, IdCompany);

            //  tạo IdJobPostings để dùng cho các hàm định dạng rtbx và hàm hoàn tất
            tao_IdJobPostings();

            //  sắp tin trong bảng tin, mặc định tin hết hạn bị đẩy xuống dưới
            UC_BangTin_NTD.sapXep();

            // load biểu đồ hình tròn, cột
            load_BieuDoTron();
            load_BieuDoCot();

            //  load biểu đồ tròn, cột cho bảng tin
            ThongKe.thucThi_load_BieuDoTron_BangTin(UC_BangTin_NTD.chart_soCV_theoNganh);
            ThongKe.thucThi_load_BieuDoCot_BangTin(UC_BangTin_NTD.chart_soCongViec_soUV_theoThang);
        }

        private void tao_IdJobPostings()
        {
            //  tự động tạo IdJobPostings cho tin tuyển dụng
            Guid g = Guid.NewGuid();

            //  lấy IdJobPostings hiện tại để dùng cho hàm Btn_sua_tinTuyenDung
            this.IdJobPostings = g.ToString();
        }

        private void UC_taoTin_Load(object sender, EventArgs e)
        {
            //  gọi sự kiện thêm ảnh
            UC_taoTin.pbx_logoCongTy.Click += Pbx_logoCongTy_Click;
            UC_taoTin.pbx_giayPhep.Click += Pbx_giayPhep_Click;

            //  gọi sự kiện định dạng rtbx
            //  không thể ép sender về rtbx rồi dùng rtbx.Name nên buộc phải truyền vậy để lấy thuộc tính khóa RtbxStyle
            UC_taoTin.btn_dinhDang_motaCongViec.Click += (s, ev) => TuyenDung_ApDung_DinhDang_rtbx.Btn_dinhDang_rtbx_Click(s, ev, UC_taoTin.rtbx_moTaCongViec.Name, UC_taoTin.rtbx_moTaCongViec, this.IdCompany, this.IdJobPostings, list_TD_dinhDang);
            UC_taoTin.btn_dinhDang_yeuCauUngVien.Click += (s, ev) => TuyenDung_ApDung_DinhDang_rtbx.Btn_dinhDang_rtbx_Click(s, ev, UC_taoTin.rtbx_yeuCauUngVien.Name, UC_taoTin.rtbx_yeuCauUngVien, this.IdCompany, this.IdJobPostings, list_TD_dinhDang);
            UC_taoTin.btn_dinhDang_loiIch.Click += (s, ev) => TuyenDung_ApDung_DinhDang_rtbx.Btn_dinhDang_rtbx_Click(s, ev, UC_taoTin.rtbx_quyenLoi.Name, UC_taoTin.rtbx_quyenLoi, this.IdCompany, this.IdJobPostings, list_TD_dinhDang);
            UC_taoTin.btn_dinhDang_hoatDong.Click += (s, ev) => TuyenDung_ApDung_DinhDang_rtbx.Btn_dinhDang_rtbx_Click(s, ev, UC_taoTin.rtbx_hoatDong.Name, UC_taoTin.rtbx_hoatDong, this.IdCompany, this.IdJobPostings, list_TD_dinhDang);
            UC_taoTin.btn_dinhDang_giaiThuong.Click += (s, ev) => TuyenDung_ApDung_DinhDang_rtbx.Btn_dinhDang_rtbx_Click(s, ev, UC_taoTin.rtbx_giaiThuong.Name, UC_taoTin.rtbx_giaiThuong, this.IdCompany, this.IdJobPostings, list_TD_dinhDang);

            //  gọi sự kiện reload tạo IdJobPostings mới để tạo nhiều tin cùng lúc
            UC_taoTin.btn_taiLaiTrang.Click += Btn_taiLaiTrang_Click;

            //  gọi sự kiện hoàn tất tạo tin
            UC_taoTin.btn_hoanTat.Click += Btn_hoanTat_Click1;
        }

        private void Btn_taiLaiTrang_Click(object sender, EventArgs e)
        {
            tao_IdJobPostings();

            //  reset lại list để tránh trùng IdJobPostings sau mỗi lần tạo tin mới
            list_TD_dinhDang.Clear();
        }

        //  load chức năng của bảng tin
        private void UC_BangTin_NTD_Load(object sender, EventArgs e)
        {
            UC_BangTin_NTD.cbx_loc_Luong.SelectedIndexChanged += UC_BangTin_NTD.cbx_loc_Luong_SelectedIndexChanged;
            UC_BangTin_NTD.cbx_loc_nganhNghe.SelectedIndexChanged += UC_BangTin_NTD.locTheoDieuKien;
            UC_BangTin_NTD.cbx_loc_sapXep.SelectedIndexChanged += UC_BangTin_NTD.cbx_loc_sapXep_SelectedIndexChanged;
            UC_BangTin_NTD.cbx_loc_kinhNghiem.SelectedIndexChanged += UC_BangTin_NTD.locTheoDieuKien;
            UC_BangTin_NTD.cbx_loc_diaChi.SelectedIndexChanged += UC_BangTin_NTD.locTheoDieuKien;

            //  đăng xuất
            UC_BangTin_NTD.btn_dangXuat.Click += Btn_dangXuat_Click;
        }

        private void Btn_dangXuat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Pbx_giayPhep_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // Tạo một đối tượng hình ảnh từ tệp được chọn
                Image image = Image.FromFile(ofd.FileName);

                // Thiết lập hình ảnh cho PictureBox và điều chỉnh SizeMode
                UC_taoTin.pbx_giayPhep.Image = image;
                UC_taoTin.pbx_giayPhep.SizeMode = PictureBoxSizeMode.StretchImage;
                this.linkGiayPhep = ofd.FileName;
            }
        }

        private void Pbx_logoCongTy_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // Tạo một đối tượng hình ảnh từ tệp được chọn
                Image image = Image.FromFile(ofd.FileName);

                // Thiết lập hình ảnh cho PictureBox và điều chỉnh SizeMode
                UC_taoTin.pbx_logoCongTy.Image = image;
                UC_taoTin.pbx_logoCongTy.SizeMode = PictureBoxSizeMode.StretchImage;
                this.linkLogo = ofd.FileName;
            }
        }

        public void layDuLieu(NHATUYENDUNG NTD)
        {
            //  lấy Id tài khoản hiện tại đang đăng nhập
            this.IdCompany = NTD.Id;
            //  xuất toàn bộ thông tin của NTD đã đăng ký trước đó lên form
            UC_taoTin.tbx_tenCongTy.Text = NTD.Company;
            UC_taoTin.tbx_mangXaHoi.Text = NTD.SocialNetwork;
            UC_taoTin.tbx_diaChi.Text = NTD.JobLocation;
            UC_taoTin.tbx_tenHR.Text = NTD.Fname;
            UC_taoTin.tbx_emailHR.Text = NTD.Email;
            UC_taoTin.tbx_sdtHR.Text = NTD.PhoneNTD;
            UC_taoTin.tbx_viTriCongTacHR.Text = NTD.JobPos;
        }

        //  mặc định thông tin của 1 NTD sẽ không đổi và chỉ thay đổi đc tin tuyển dụng
        public void Btn_hoanTat_Click1(object sender, EventArgs e)
        {
            //  mặc định tất cả thông tin ko đc null
            if (kiemTra_null())
            {
                //  dùng TuyenDung_Tin vì TuyenDung chỉ lưu thông tin cơ bản của NTD
                TuyenDung_Tin t = new TuyenDung_Tin(this.IdCompany, this.IdJobPostings, "Employer", this.linkLogo, UC_taoTin.tbx_tenCongTy.Text, UC_taoTin.tbx_mangXaHoi.Text, UC_taoTin.tbx_diaChi.Text, UC_taoTin.cbx_nganhNghe.Text, UC_taoTin.tbx_tenCongViec.Text,
                    Convert.ToDouble(UC_taoTin.tbx_luong.Text), UC_taoTin.cbx_kinhNghiem.Text, UC_taoTin.cbx_hinhThucLamViec.Text, UC_taoTin.tbx_tenHR.Text, UC_taoTin.tbx_emailHR.Text, UC_taoTin.tbx_sdtHR.Text, UC_taoTin.tbx_viTriCongTacHR.Text, UC_taoTin.dtpr_ngayDang.Value.ToShortDateString(),
                    UC_taoTin.dtpr_hanChot.Value.ToShortDateString(), UC_taoTin.rtbx_moTaCongViec.Text, UC_taoTin.rtbx_yeuCauUngVien.Text, UC_taoTin.rtbx_quyenLoi.Text, UC_taoTin.rtbx_hoatDong.Text, UC_taoTin.rtbx_giaiThuong.Text, this.linkGiayPhep);

                //  mặc định khi tạo tin thì cũng add 1 UC_tinTuyenDung và 1 UC_tinDaDang vào flowlayoupanel
                UC_BangTin_NTD.flpl_danhSachTinTuyenDung.Controls.Add(xuat_TT.them_tinTuyenDung(t, t.UserType, "null"));
                flpl_tinDaDang.Controls.Add(xuat_TT.them_tinDaDang(t.IdCompany, t.IdJobPostings, t.TenCongViec, t.NgayDang, t.HanChot));

                NTD_DAO.taoTin(t);

                //  buộc phải tạo tin trước mới được tạo định dạng cho rtbx
                taoDinhDang();
            }
            else
                MessageBox.Show("You must fill in all information!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool kiemTra_null()
        {
            if (string.IsNullOrEmpty(linkLogo) || string.IsNullOrEmpty(UC_taoTin.cbx_nganhNghe.Text) || string.IsNullOrEmpty(UC_taoTin.tbx_tenCongViec.Text)
                || string.IsNullOrEmpty(UC_taoTin.tbx_luong.Text) || string.IsNullOrEmpty(UC_taoTin.cbx_kinhNghiem.Text) || string.IsNullOrEmpty(UC_taoTin.cbx_hinhThucLamViec.Text)
                || string.IsNullOrEmpty(UC_taoTin.rtbx_moTaCongViec.Text) || string.IsNullOrEmpty(UC_taoTin.rtbx_yeuCauUngVien.Text) || string.IsNullOrEmpty(UC_taoTin.rtbx_quyenLoi.Text) || string.IsNullOrEmpty(UC_taoTin.rtbx_hoatDong.Text) || string.IsNullOrEmpty(UC_taoTin.rtbx_giaiThuong.Text) || string.IsNullOrEmpty(this.linkGiayPhep))
                return false;
            return true;
        }

        private void taoDinhDang()
        {
            foreach (var i in list_TD_dinhDang)
            {
                NTD_DAO.dinhDang_rtbx_NTD(i);
            }
        }

        //  lọc ngày trong lịch phỏng vấn
        private void btn_locTheoNgay_Click(object sender, EventArgs e)
        {
            hienFullLichPV();

            foreach (Control ctl in flpl_lichPhongVan.Controls)
            {
                if (ctl is UC_LichPhongVan uc)
                {
                    if (Convert.ToDateTime(uc.lbl_ngayPhongVan.Text).ToShortDateString() != dtpr_locTheoNgay.Value.ToShortDateString())
                        uc.Visible = false;
                }   
            }    
        }

        private void btn_reload_lichPV_Click(object sender, EventArgs e)
        {
            NTD_DAO.sapXepLichPV(hienFullLichPV());
        }

        //  vì sự kiện click lọc theo ngày đã ẩn đi 1 số UC_lichPhongVan nên hàm này giúp hiện lại toàn bộ lịch phỏng vấn
        private FlowLayoutPanel hienFullLichPV()
        {
            foreach (Control ctl in flpl_lichPhongVan.Controls)
            {
                if (ctl is UC_LichPhongVan uc)
                {
                    uc.Visible = true;
                }
            }
            return flpl_lichPhongVan;
        }
        
        private void load_BieuDoTron()
        {
            ThongKe.thucThi_load_BieuDoTron(chart_soCV_theoNganh, this.IdCompany);
        }

        private void load_BieuDoCot()
        {
            ThongKe.thucThi_load_BieuDoCot(chart_soCongViec_soUV_theoThang, this.IdCompany);
        }

        private void btn_newChat_Click(object sender, EventArgs e)
        {
            //  khi click nút reset thì xóa hết trong 3 flpl, pnl bên dưới và gọi hàm load để load lại tin
            flpl_chiTietTinXinViec.Controls.Clear();
            flpl_tinNhan.Controls.Clear();
            pnl_chatBox.Controls.Clear();

            NTD_DAO.load_tinXinViec(flpl_tinDaDang, flpl_chiTietTinXinViec, flpl_tinNhan, pnl_chatBox, this.IdCompany);
        }
    }
}
