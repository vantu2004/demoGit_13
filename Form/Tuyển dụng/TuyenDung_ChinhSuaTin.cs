﻿using System;
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
    public partial class TuyenDung_ChinhSuaTin : Form
    {
        TuyenDung_ChinhSuaTin_DAO TD_CST_DAO = new TuyenDung_ChinhSuaTin_DAO();

        private string IdCompany;
        private string IdJobPostings;
        private string linkLogo;
        private string linkGiayPhep;

        public TuyenDung_ChinhSuaTin()
        {
            InitializeComponent();
        }

        private void UC_taoTin_Load_1(object sender, EventArgs e)
        {
            //  gọi sự kiện thêm ảnh
            UC_taoTin.pbx_logoCongTy.Click += Pbx_logoCongTy_Click;
            UC_taoTin.pbx_giayPhep.Click += Pbx_giayPhep_Click;
            //  gọi sự kiện hoàn tất chỉnh sửa
            UC_taoTin.btn_hoanTat.Click += Btn_hoanTat_Click1;
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
                this.linkLogo = ofd.FileName;
            }
        }

        private void Pbx_giayPhep_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // Tạo một đối tượng hình ảnh từ tệp được chọn
                Image image = Image.FromFile(ofd.FileName);

                // Thiết lập hình ảnh cho PictureBox và điều chỉnh SizeMode
                UC_taoTin.pbx_giayPhep.Image = image;
                UC_taoTin.pbx_giayPhep.SizeMode = PictureBoxSizeMode.StretchImage;
                this.linkGiayPhep = ofd.FileName;
            }
        }

        public void layDuLieu(TuyenDung_Tin t)
        {
            //  lấy IdCompany và IdJobPstings hiện tại
            this.IdCompany = t.IdCompany;
            this.IdJobPostings = t.IdJobPostings;

            //  lấy link ảnh ban đầu vì khi tạo đối tượng t dưới hàm Btn_hoanTat_Click1 thì link ảnh sẽ null nếu không thao tác gì với picturebox
            this.linkLogo = t.LogoCongTy;
            this.linkGiayPhep = t.GiayPhep;

            //  xuất toàn bộ thông tin của NTD đã đăng ký trước đó lên form
            UC_taoTin.pbx_logoCongTy.Image = Image.FromFile(t.LogoCongTy);
            UC_taoTin.pbx_giayPhep.Image = Image.FromFile(t.GiayPhep);
            UC_taoTin.tbx_tenCongTy.Text = t.TenCongTy;
            UC_taoTin.tbx_mangXaHoi.Text = t.MangXaHoi;
            UC_taoTin.tbx_diaChi.Text = t.DiaChi;
            UC_taoTin.cbx_nganhNghe.Text = t.NganhNghe;
            UC_taoTin.tbx_tenCongViec.Text = t.TenCongViec;
            UC_taoTin.tbx_luong.Text = t.Luong.ToString();
            UC_taoTin.cbx_kinhNghiem.Text = t.KinhNghiem;
            UC_taoTin.cbx_hinhThucLamViec.Text = t.HinhThucLamViec;
            UC_taoTin.dtpr_ngayDang.Value = Convert.ToDateTime(t.NgayDang);
            UC_taoTin.dtpr_hanChot.Value = Convert.ToDateTime(t.HanChot);
            UC_taoTin.tbx_tenHR.Text = t.TenHR;
            UC_taoTin.tbx_emailHR.Text = t.EmailHR;
            UC_taoTin.tbx_sdtHR.Text = t.SdtHR;
            UC_taoTin.tbx_viTriCongTacHR.Text = t.ViTriCongTacHR;
            UC_taoTin.rtbx_moTaCongViec.Text = t.MoTaCongViec;
            UC_taoTin.rtbx_yeuCauUngVien.Text = t.YeuCau;
            UC_taoTin.rtbx_quyenLoi.Text = t.LoiIch;
            UC_taoTin.rtbx_hoatDong.Text = t.HoatDong;
            UC_taoTin.rtbx_giaiThuong.Text = t.GiaiThuong;

            //  chỉnh kích thước rtbx
            ChinhKichThuoc_rtbx.chinhKichThuoc(UC_taoTin.rtbx_moTaCongViec);
            ChinhKichThuoc_rtbx.chinhKichThuoc(UC_taoTin.rtbx_yeuCauUngVien);
            ChinhKichThuoc_rtbx.chinhKichThuoc(UC_taoTin.rtbx_quyenLoi);
            ChinhKichThuoc_rtbx.chinhKichThuoc(UC_taoTin.rtbx_hoatDong);
            ChinhKichThuoc_rtbx.chinhKichThuoc(UC_taoTin.rtbx_giaiThuong);

        }

        //  mặc định thông tin của 1 NTD sẽ không đổi và chỉ thay đổi đc tin tuyển dụng
        public void Btn_hoanTat_Click1(object sender, EventArgs e)
        {
            //  mặc định tất cả thông tin ko đc null
            if (kiemTra_null())
            {
                //  dùng TuyenDung_Tin vì TuyenDung chỉ lưu thông tin cơ bản của NTD
                TuyenDung_Tin t = new TuyenDung_Tin(this.IdCompany, this.IdJobPostings, "Employer", this.linkLogo, UC_taoTin.tbx_tenCongTy.Text, UC_taoTin.tbx_mangXaHoi.Text, UC_taoTin.tbx_diaChi.Text,
                    UC_taoTin.cbx_nganhNghe.Text, UC_taoTin.tbx_tenCongViec.Text, Convert.ToDouble(UC_taoTin.tbx_luong.Text), UC_taoTin.cbx_kinhNghiem.Text, UC_taoTin.cbx_hinhThucLamViec.Text,
                    UC_taoTin.tbx_tenHR.Text, UC_taoTin.tbx_emailHR.Text, UC_taoTin.tbx_sdtHR.Text, UC_taoTin.tbx_viTriCongTacHR.Text, UC_taoTin.dtpr_ngayDang.Value.ToShortDateString(),
                    UC_taoTin.dtpr_hanChot.Value.ToShortDateString(), UC_taoTin.rtbx_moTaCongViec.Text, UC_taoTin.rtbx_yeuCauUngVien.Text, UC_taoTin.rtbx_quyenLoi.Text, UC_taoTin.rtbx_hoatDong.Text, UC_taoTin.rtbx_giaiThuong.Text, this.linkGiayPhep);

                TD_CST_DAO.chinhSuaTin(t);
            }
            else
                MessageBox.Show("You must fill in all information!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool kiemTra_null()
        {
            if (string.IsNullOrEmpty(this.linkLogo) || string.IsNullOrEmpty(UC_taoTin.cbx_nganhNghe.Text) || string.IsNullOrEmpty(UC_taoTin.tbx_tenCongViec.Text)
                || string.IsNullOrEmpty(UC_taoTin.tbx_luong.Text) || string.IsNullOrEmpty(UC_taoTin.cbx_kinhNghiem.Text) || string.IsNullOrEmpty(UC_taoTin.cbx_hinhThucLamViec.Text)
                || string.IsNullOrEmpty(UC_taoTin.rtbx_moTaCongViec.Text) || string.IsNullOrEmpty(UC_taoTin.rtbx_yeuCauUngVien.Text) || string.IsNullOrEmpty(UC_taoTin.rtbx_quyenLoi.Text) || string.IsNullOrEmpty(UC_taoTin.rtbx_hoatDong.Text) || string.IsNullOrEmpty(UC_taoTin.rtbx_giaiThuong.Text) || string.IsNullOrEmpty(this.linkGiayPhep))
                return false;
            return true;
        }
    }
}
