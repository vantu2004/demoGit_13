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

        private void pbx_logoCongTy_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // Tạo một đối tượng hình ảnh từ tệp được chọn
                Image image = Image.FromFile(ofd.FileName);

                // Thiết lập hình ảnh cho PictureBox và điều chỉnh SizeMode
                pbx_logoCongTy.Image = image;
                pbx_logoCongTy.SizeMode = PictureBoxSizeMode.StretchImage;
                this.linkAnh = ofd.FileName;
            }
        }

        public void layDuLieu(TuyenDung NTD)
        {
            //  lấy Id tài khoản hiện tại đang đăng nhập
            this.IdCompany = NTD.Id;
            //  xuất toàn bộ thông tin của NTD đã đăng ký trước đó lên form
            tbx_tenCongTy.Text = NTD.TenCongTy;
            tbx_mangXaHoi.Text = NTD.MangXaHoi;
            tbx_diaChi.Text = NTD.DiaChiCongTy;
            tbx_tenHR.Text = NTD.TenHR;
            tbx_emailHR.Text = NTD.EmailHR;
            tbx_sdtHR.Text = NTD.SdtHR;
            tbx_viTriCongTacHR.Text = NTD.ViTriCongTacHR;
        }

        //  mặc định thông tin của 1 NTD sẽ không đổi và chỉ thay đổi đc tin tuyển dụng
        public void Btn_hoanTat_Click(object sender, EventArgs e)
        {
            //  tự động tạo IdJobPostings cho tin tuyển dụng
            Guid g = Guid.NewGuid();

            //  lấy IdJobPostings hiện tại để dùng cho hàm Btn_sua_tinTuyenDung
            this.IdJobPostings = g.ToString();

            //  mặc định tất cả thông tin ko đc null
            if (kiemTra_null())
            {
                //  dùng TuyenDung_Tin vì TuyenDung chỉ lưu thông tin cơ bản của NTD
                TuyenDung_Tin t = new TuyenDung_Tin(IdCompany, g.ToString(), "Employer", linkAnh, tbx_tenCongTy.Text, tbx_mangXaHoi.Text, tbx_diaChi.Text,
                cbx_nganhNghe.Text, tbx_tenCongViec.Text, Convert.ToDouble(tbx_luong.Text), cbx_kinhNghiem.Text, cbx_hinhThucLamViec.Text,
                tbx_tenHR.Text, tbx_emailHR.Text, tbx_sdtHR.Text, tbx_viTriCongTacHR.Text, dtpr_ngayDang.Value.ToShortDateString(),
                dtpr_hanChot.Value.ToShortDateString(), rtbx_moTaCongViec.Text, rtbx_yeuCauUngVien.Text, rtbx_quyenLoi.Text);

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
            if (string.IsNullOrEmpty(linkAnh) || string.IsNullOrEmpty(cbx_nganhNghe.Text) || string.IsNullOrEmpty(tbx_tenCongViec.Text)
                || string.IsNullOrEmpty(tbx_luong.Text) || string.IsNullOrEmpty(cbx_kinhNghiem.Text) || string.IsNullOrEmpty(cbx_hinhThucLamViec.Text)
                || string.IsNullOrEmpty(rtbx_moTaCongViec.Text) || string.IsNullOrEmpty(rtbx_yeuCauUngVien.Text) || string.IsNullOrEmpty(rtbx_quyenLoi.Text))
                return false;
            return true;
        }
    }
}
