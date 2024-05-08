using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Windows_04
{
    public class DangKy_DangNhap_DAO
    {
        public DangKy_DangNhap_DAO() { }

        public void DangNhap(string tenDanhNhap, string matKhau)
        {
            using (var dbContext = new DeTai_02_Entities())
            {
                var taiKhoan = dbContext.TAIKHOAN.FirstOrDefault(tk => tk.UserName == tenDanhNhap && tk.UserPassword == matKhau);

                if (taiKhoan != null)
                {
                    if (taiKhoan.UserType == "Employer")
                    {
                        var nhaTuyenDung = dbContext.NHATUYENDUNG.FirstOrDefault(ntd => ntd.Id == taiKhoan.Id);
                        // Xử lý thông tin nhà tuyển dụng
                        thucThi_layDuLieu_NTD(nhaTuyenDung);
                    }
                    else
                    {
                        var ungVien = dbContext.UNGVIEN.FirstOrDefault(uv => uv.Id == taiKhoan.Id);
                        // Xử lý thông tin ứng viên
                        thucThi_layDuLieu_UV(ungVien);
                    }
                }
                else
                {
                    MessageBox.Show("Not found!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void thucThi_layDuLieu_NTD(NHATUYENDUNG nhaTuyenDung)
        {
            if (nhaTuyenDung != null)
            {
                TuyenDung_TrangChu TD_TC = new TuyenDung_TrangChu();
                TD_TC.layDuLieu(nhaTuyenDung);
                TD_TC.ShowDialog();
                TD_TC.UC_taoTin.btn_hoanTat.Click += TD_TC.Btn_hoanTat_Click1;
            }
            else
            {
                MessageBox.Show("Not found!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void thucThi_layDuLieu_UV(UNGVIEN ungVien)
        {
            if (ungVien != null)
            {
                UngVien_TrangChu UV_TC = new UngVien_TrangChu();
                UV_TC.Id = ungVien.Id;
                UV_TC.layDuLieu();
                UV_TC.ShowDialog();
                UV_TC.btn_hoanTat.Click += UV_TC.btn_hoanTat_Click;
                UV_TC.btn_luuChinhSua.Click += UV_TC.btn_luuChinhSua_Click;
            }
            else
            {
                MessageBox.Show("Not found!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
