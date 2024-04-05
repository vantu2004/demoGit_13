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

namespace Project_Windows_04
{
    public partial class UngVien_DangKy : Form
    {
        UngVien_DAO UV_DAO = new UngVien_DAO();
        private string gioiTinh;

        public UngVien_DangKy()
        {
            InitializeComponent();
        }

        private void UngVien_DangKy_Load(object sender, EventArgs e)
        {

        }

        private void btn_hoanTat_Click(object sender, EventArgs e)
        {
            //  phải xác định giới tính trước để dùng cho hàm kiemTra_null
            if (rbn_nam_UV.Checked)
                this.gioiTinh = rbn_nam_UV.Text;
            else
                this.gioiTinh = rbn_nu_UV.Text;

            if (kiemTra_null())
            {
                if (tbx_matKhau_UV.Text == tbx_nhapLaiMatKhau_UV.Text)
                {
                    Guid g = Guid.NewGuid();

                    UngVien uv = new UngVien(g.ToString(), "Candidate", tbx_ten_UV.Text, tbx_sdt_UV.Text, dtpr_ngaySinh_UV.Value.ToShortDateString(), tbx_mangXaHoi_UV.Text, tbx_email_UV.Text, cbx_diaChi_UV.Text, gioiTinh);
                    TaiKhoan tk = new TaiKhoan(g.ToString(), "Candidate", tbx_tenDangNhap_UV.Text, tbx_matKhau_UV.Text);
                    if (cbx_dongYDieuKhoan.Checked == true)
                    {
                        UV_DAO.dangKy(uv, tk);
                        this.Close();
                    }    
                    else
                        MessageBox.Show("You must accept all terms!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("You must re-enter the correct password!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("You must fill in all information!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool kiemTra_null()
        {
            if (string.IsNullOrEmpty(tbx_tenDangNhap_UV.Text) || string.IsNullOrEmpty(tbx_matKhau_UV.Text) || string.IsNullOrEmpty(tbx_nhapLaiMatKhau_UV.Text)
                || string.IsNullOrEmpty(tbx_ten_UV.Text) || string.IsNullOrEmpty(tbx_sdt_UV.Text) || string.IsNullOrEmpty(tbx_email_UV.Text)
                || string.IsNullOrEmpty(cbx_diaChi_UV.Text) || string.IsNullOrEmpty(tbx_mangXaHoi_UV.Text) || string.IsNullOrEmpty(this.gioiTinh))
                return false;
            return true;
        }
    }
}
