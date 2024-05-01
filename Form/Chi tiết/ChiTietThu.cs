using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Windows_04
{
    public partial class ChiTietThu : Form
    {
        public ChiTietThu()
        {
            InitializeComponent();
        }

        private void ChiTietThu_Load(object sender, EventArgs e)
        {
            UC_Thu.btn_dong.Click += Btn_dong_Click;
        }

        private void Btn_dong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool kiemTraNull()
        {
            if (string.IsNullOrEmpty(UC_Thu.tbx_nguoiGui.Text) || string.IsNullOrEmpty(UC_Thu.tbx_nguoiNhan.Text) || string.IsNullOrEmpty(UC_Thu.tbx_chuDe.Text) || string.IsNullOrEmpty(UC_Thu.rtbx_noiDung.Text))
                return false;
            return true;
        }

        public void xuatDuLieu_khiGui(TuyenDung_Tin t, UngVien_Tin u)
        {
            UC_Thu.tbx_nguoiGui.Text = t.EmailHR;
            UC_Thu.tbx_nguoiNhan.Text = u.EmailUV;
            UC_Thu.lbl_ngayGui.Text = DateTime.Now.ToString();
        }

        public void xuatDuLieu_khiNhan(Thu t)
        {
            UC_Thu.tbx_nguoiGui.Text = t.NguoiGui;
            UC_Thu.tbx_nguoiNhan.Text = t.NguoiNhan;
            UC_Thu.tbx_chuDe.Text = t.ChuDe;
            UC_Thu.rtbx_noiDung.Text = t.NoiDung;
            UC_Thu.lbl_ngayGui.Text = t.NgayGui;
            UC_Thu.dtpr_ngayPhongVan.Value = Convert.ToDateTime(t.NgayPhongVan);
            UC_Thu.dtpr_thoiGIanPhongVan.Value = Convert.ToDateTime(t.ThoiGianPhongVan);

            //  mặc định chỉ đọc ko đc tương tác
            UC_Thu.tbx_nguoiGui.ReadOnly = true;
            UC_Thu.tbx_nguoiNhan.ReadOnly = true;
            UC_Thu.tbx_chuDe.ReadOnly = true;
            UC_Thu.rtbx_noiDung.ReadOnly = true;
            UC_Thu.dtpr_ngayPhongVan.Enabled = false;
            UC_Thu.dtpr_thoiGIanPhongVan.Enabled = false;

            UC_Thu.btn_gui.Hide();
        }
    }
}
