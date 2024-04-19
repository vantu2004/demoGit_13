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

        public void xuatDuLieu(TuyenDung_Tin t, UngVien_Tin u)
        {
            UC_Thu.tbx_nguoiGui.Text = t.EmailHR;
            UC_Thu.tbx_nguoiNhan.Text = u.EmailUV;
            UC_Thu.lbl_ngayGui.Text = DateTime.Now.ToString();
        }
    }
}
