using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Project_Windows_04
{
    public partial class UngVien_TrangChu : Form
    {
        UngVien_DAO UV_DAO = new UngVien_DAO();
        public string Id;
        private string linkAnh;
        private string gioiTinh;

        public UngVien_TrangChu()
        {
            InitializeComponent();
        }

        private void UngVien_TrangChu_Load(object sender, EventArgs e)
        {
            UC_BangTin_UV.btn_dangTinTuyenDung.Hide();
            UC_BangTin_UV.btn_dangNhap.Hide();
            UC_BangTin_UV.btn_dangKy.Hide();

            //  thay vì truyền userType thì truyền Id để dùng cho hàm Btn_ungTuyen_Click bên Xuat_ThongTin
            UV_DAO.load_tinTuyenDung(UC_BangTin_UV.flpl_danhSachTinTuyenDung, this.Id);
        }

        public void layDuLieu()
        {
            UngVien_Tin u = UV_DAO.chiTiet_CV(this.Id);

            if (u != null)
            {
                pbx_avatar.Image = Image.FromFile(u.AnhDaiDien);
                tbx_tenUV.Text = u.TenUV;
                dtpr_ngaySinhUV.Value = Convert.ToDateTime(u.NgaySinhUV);
                if (u.GioiTinhUV == "Male")
                    rbn_nam.Checked = true;
                else
                    rbn_nu.Checked = true;
                cbx_diaChiUV.Text = u.DiaChi;
                tbx_mangXaHoi.Text = u.MangXaHoi;
                tbx_sdtUV.Text = u.SdtUV;
                tbx_emaiUV.Text = u.EmailUV;
                cbx_viTriUngTuyen.Text = u.ViTriUngTuyen;
                rtbx_mucTIeuNgheNghiep.Text = u.MucTieuNgheNghiep;
                rtbx_hocVan.Text = u.HocVan;
                rtbx_kinhNghiem.Text = u.KinhNghiem;

                //  giả sử ko tương tác gì với avatar thì mặc định sẽ lấy avatar cũ
                this.linkAnh = u.AnhDaiDien;
            }
        }

        private void pbx_avatar_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // Tạo một đối tượng hình ảnh từ tệp được chọn
                Image image = Image.FromFile(ofd.FileName);

                // Thiết lập hình ảnh cho PictureBox và điều chỉnh SizeMode
                pbx_avatar.Image = image;
                pbx_avatar.SizeMode = PictureBoxSizeMode.StretchImage;
                this.linkAnh = ofd.FileName;
            }
        }

        public UngVien_Tin taoUngVien()
        {
            //  phải xác định giới tính trước để dùng cho hàm kiemTra_null
            if (rbn_nam.Checked)
                this.gioiTinh = rbn_nam.Text;
            else
                this.gioiTinh = rbn_nu.Text;

            if (kiemTra_null())
            {
                // thời gian cập nhật CV
                DateTime dt = DateTime.Now;

                UngVien_Tin u = new UngVien_Tin(this.Id, this.linkAnh, tbx_tenUV.Text, dtpr_ngaySinhUV.Value.ToShortDateString(), gioiTinh,
                    cbx_diaChiUV.Text, tbx_mangXaHoi.Text, tbx_sdtUV.Text, tbx_emaiUV.Text, cbx_viTriUngTuyen.Text,
                    dt.ToString("dd/MM/yyyy"), rtbx_mucTIeuNgheNghiep.Text, rtbx_hocVan.Text, rtbx_kinhNghiem.Text);

                return u;
            }
            else
            {
                MessageBox.Show("You must fill in all information!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
        }

        private bool kiemTra_null()
        {
            if (string.IsNullOrEmpty(this.linkAnh) || string.IsNullOrEmpty(tbx_tenUV.Text) || string.IsNullOrEmpty(this.gioiTinh) || string.IsNullOrEmpty(cbx_diaChiUV.Text) 
                || string.IsNullOrEmpty(tbx_mangXaHoi.Text) || string.IsNullOrEmpty(tbx_sdtUV.Text) || string.IsNullOrEmpty(tbx_emaiUV.Text) || string.IsNullOrEmpty(cbx_viTriUngTuyen.Text) 
                || string.IsNullOrEmpty(rtbx_mucTIeuNgheNghiep.Text) || string.IsNullOrEmpty(rtbx_hocVan.Text) || string.IsNullOrEmpty(rtbx_kinhNghiem.Text))
                return false;
            return true;
        }

        public void btn_hoanTat_Click(object sender, EventArgs e)
        {
            UV_DAO.taoTin(taoUngVien());
        }

        public void btn_luuChinhSua_Click(object sender, EventArgs e)
        {
            UV_DAO.chinhSuaTin(taoUngVien());
        }
    }
}
