using System;
using System.Drawing;
using System.Windows.Forms;

namespace Project_Windows_04
{
    public partial class TuyenDung_TrangChu : Form
    {
        private TuyenDung_DAO NTD_DAO = new TuyenDung_DAO();
        private Xuat_ThongTin xuat_TT = new Xuat_ThongTin();
        private string linkAnh;
        private string IdCompany;
        public string IdJobPostings;

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
            NTD_DAO.load_tinTuyenDung(UC_BangTin_NTD.flpl_danhSachTinTuyenDung, "Employer");

            //  load toàn bộ tin đã đăng của 1 NTD lên flowlayoutpanel, click vào để xem danh sách ứng viên đã nộp CV, truyền IdCompany để xác định mỗi tin đc đăng
            NTD_DAO.load_tinDaDang(flpl_tinDaDang, IdCompany);
        }

        private void UC_taoTin_Load(object sender, EventArgs e)
        {
            UC_taoTin.pbx_logoCongTy.Click += Pbx_logoCongTy_Click;
            UC_taoTin.btn_hoanTat.Click += Btn_hoanTat_Click1;

            UC_BangTin_NTD.cbx_loc_Luong.SelectedIndexChanged += UC_BangTin_NTD.cbx_loc_Luong_SelectedIndexChanged;
            UC_BangTin_NTD.cbx_loc_nganhNghe.SelectedIndexChanged += UC_BangTin_NTD.cbx_loc_nganhNghe_SelectedIndexChanged;
            UC_BangTin_NTD.cbx_loc_sapXep.SelectedIndexChanged += UC_BangTin_NTD.cbx_loc_sapXep_SelectedIndexChanged;
            UC_BangTin_NTD.cbx_loc_kinhNghiem.SelectedIndexChanged += UC_BangTin_NTD.cbx_loc_kinhNghiem_SelectedIndexChanged;
            UC_BangTin_NTD.cbx_loc_diaChi.SelectedIndexChanged += UC_BangTin_NTD.cbx_loc_diaChi_SelectedIndexChanged;
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
                this.linkAnh = ofd.FileName;
            }
        }

        public void layDuLieu(TuyenDung NTD)
        {
            //  lấy Id tài khoản hiện tại đang đăng nhập
            this.IdCompany = NTD.Id;
            //  xuất toàn bộ thông tin của NTD đã đăng ký trước đó lên form
            UC_taoTin.tbx_tenCongTy.Text = NTD.TenCongTy;
            UC_taoTin.tbx_mangXaHoi.Text = NTD.MangXaHoi;
            UC_taoTin.tbx_diaChi.Text = NTD.DiaChiCongTy;
            UC_taoTin.tbx_tenHR.Text = NTD.TenHR;
            UC_taoTin.tbx_emailHR.Text = NTD.EmailHR;
            UC_taoTin.tbx_sdtHR.Text = NTD.SdtHR;
            UC_taoTin.tbx_viTriCongTacHR.Text = NTD.ViTriCongTacHR;
        }

        //  mặc định thông tin của 1 NTD sẽ không đổi và chỉ thay đổi đc tin tuyển dụng
        public void Btn_hoanTat_Click1(object sender, EventArgs e)
        {
            //  tự động tạo IdJobPostings cho tin tuyển dụng
            Guid g = Guid.NewGuid();

            //  lấy IdJobPostings hiện tại để dùng cho hàm Btn_sua_tinTuyenDung
            this.IdJobPostings = g.ToString();

            //  mặc định tất cả thông tin ko đc null
            if (kiemTra_null())
            {
                //  dùng TuyenDung_Tin vì TuyenDung chỉ lưu thông tin cơ bản của NTD
                TuyenDung_Tin t = new TuyenDung_Tin(IdCompany, g.ToString(), "Employer", linkAnh, UC_taoTin.tbx_tenCongTy.Text, UC_taoTin.tbx_mangXaHoi.Text, UC_taoTin.tbx_diaChi.Text,
                UC_taoTin.cbx_nganhNghe.Text, UC_taoTin.tbx_tenCongViec.Text, Convert.ToDouble(UC_taoTin.tbx_luong.Text), UC_taoTin.cbx_kinhNghiem.Text, UC_taoTin.cbx_hinhThucLamViec.Text,
                UC_taoTin.tbx_tenHR.Text, UC_taoTin.tbx_emailHR.Text, UC_taoTin.tbx_sdtHR.Text, UC_taoTin.tbx_viTriCongTacHR.Text, UC_taoTin.dtpr_ngayDang.Value.ToShortDateString(),
                UC_taoTin.dtpr_hanChot.Value.ToShortDateString(), UC_taoTin.rtbx_moTaCongViec.Text, UC_taoTin.rtbx_yeuCauUngVien.Text, UC_taoTin.rtbx_quyenLoi.Text);

                //  mặc định khi tạo tin thì cũng add 1 UC_tinTuyenDung và 1 UC_tinDaDang vào flowlayoupanel
                UC_BangTin_NTD.flpl_danhSachTinTuyenDung.Controls.Add(xuat_TT.them_tinTuyenDung(t, t.UserType));
                flpl_tinDaDang.Controls.Add(xuat_TT.them_tinDaDang(t.IdCompany, t.IdJobPostings, t.TenCongViec, t.NgayDang));

                NTD_DAO.taoTin(t);
            }
            else
                MessageBox.Show("You must fill in all information!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool kiemTra_null()
        {
            if (string.IsNullOrEmpty(linkAnh) || string.IsNullOrEmpty(UC_taoTin.cbx_nganhNghe.Text) || string.IsNullOrEmpty(UC_taoTin.tbx_tenCongViec.Text)
                || string.IsNullOrEmpty(UC_taoTin.tbx_luong.Text) || string.IsNullOrEmpty(UC_taoTin.cbx_kinhNghiem.Text) || string.IsNullOrEmpty(UC_taoTin.cbx_hinhThucLamViec.Text)
                || string.IsNullOrEmpty(UC_taoTin.rtbx_moTaCongViec.Text) || string.IsNullOrEmpty(UC_taoTin.rtbx_yeuCauUngVien.Text) || string.IsNullOrEmpty(UC_taoTin.rtbx_quyenLoi.Text))
                return false;
            return true;
        }
    }
}
