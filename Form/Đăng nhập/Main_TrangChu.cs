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
    public partial class Main_TrangChu : Form
    {
        TrangChu_DAO TC_DAO = new TrangChu_DAO();

        public Main_TrangChu()
        {
            InitializeComponent();
        }

        public void Btn_dangKy_Click(object sender, EventArgs e)
        {
            TuyenDung_UngVien TD_UV = new TuyenDung_UngVien();
            TD_UV.ShowDialog();
        }

        public void Btn_dangNhap_Click(object sender, EventArgs e)
        {
            DangKy_DangNhap DK_DN = new DangKy_DangNhap();
            DK_DN.ShowDialog();
        }

        private void Main_TrangChu_Load(object sender, EventArgs e)
        {
            UC_Main_TrangChu.btn_dangKy.Click += Btn_dangKy_Click;
            UC_Main_TrangChu.btn_dangNhap.Click += Btn_dangNhap_Click;
            UC_Main_TrangChu.btn_dangTinTuyenDung.Click += Btn_dangNhap_Click;

            UC_Main_TrangChu.cbx_loc_Luong.SelectedIndexChanged += UC_Main_TrangChu.cbx_loc_Luong_SelectedIndexChanged;
            UC_Main_TrangChu.cbx_loc_nganhNghe.SelectedIndexChanged += UC_Main_TrangChu.cbx_loc_nganhNghe_SelectedIndexChanged;
            UC_Main_TrangChu.cbx_loc_sapXep.SelectedIndexChanged += UC_Main_TrangChu.cbx_loc_sapXep_SelectedIndexChanged;
            UC_Main_TrangChu.cbx_loc_kinhNghiem.SelectedIndexChanged += UC_Main_TrangChu.cbx_loc_kinhNghiem_SelectedIndexChanged;
            UC_Main_TrangChu.cbx_loc_diaChi.SelectedIndexChanged += UC_Main_TrangChu.cbx_loc_diaChi_SelectedIndexChanged;

            TC_DAO.load_tinTuyenDung(UC_Main_TrangChu.flpl_danhSachTinTuyenDung, "null");
        }
    }
}
