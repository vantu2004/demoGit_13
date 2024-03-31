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

        public UngVien_DangKy()
        {
            InitializeComponent();
        }

        private void UngVien_DangKy_Load(object sender, EventArgs e)
        {

        }

        private void btn_hoanTat_Click(object sender, EventArgs e)
        {
            if (tbx_matKhau_UV.Text == tbx_nhapLaiMatKhau_UV.Text)
            {
                Guid g = Guid.NewGuid();

                string gioiTinh;
                if (rbn_nam_UV.Checked)
                    gioiTinh = rbn_nam_UV.Text;
                else
                    gioiTinh = rbn_nu_UV.Text;

                UngVien uv = new UngVien(g.ToString(), "Candidate", tbx_ten_UV.Text, tbx_sdt_UV.Text, dtpr_ngaySinh_UV.Value.ToShortDateString(), tbx_mangXaHoi_UV.Text, tbx_email_UV.Text, cbx_diaChi_UV.Text, gioiTinh);
                TaiKhoan tk = new TaiKhoan(g.ToString(), "Candidate", tbx_tenDangNhap_UV.Text, tbx_matKhau_UV.Text);
                if (cbx_dongYDieuKhoan.Checked == true)
                    UV_DAO.dangKy(uv, tk);
                else
                    MessageBox.Show("Bạn phải đồng ý điều khoản được đưa ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Bạn phải nhập lại đúng mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
