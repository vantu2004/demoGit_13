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
    public partial class TuyenDung_UngVien : Form
    {
        public TuyenDung_UngVien()
        {
            InitializeComponent();
        }

        private void btn_tuyenDung_Click(object sender, EventArgs e)
        {
            TuyenDung_DangKy TD_dangKy = new TuyenDung_DangKy();
            this.Close();
            TD_dangKy.ShowDialog();
        }

        private void btn_ungVien_Click(object sender, EventArgs e)
        {
            UngVien_DangKy UV_dangKy = new UngVien_DangKy();
            this.Close();
            UV_dangKy.ShowDialog();
        }

        private void TuyenDung_UngVien_Load(object sender, EventArgs e)
        {

        }
    }
}
