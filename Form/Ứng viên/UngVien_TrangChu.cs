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
        private List<UngVien_DinhDang_rtbx> list_UV_dinhDang = new List<UngVien_DinhDang_rtbx>();

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
            
            //  gọi sự kiện định dạng rtbx
            //  không thể ép sender về rtbx rồi dùng rtbx.Name nên buộc phải truyền vậy để lấy thuộc tính khóa RtbxStyle
            btn_mucTieuNgheNghiep.Click += (s, ev) => UngVien_ApDung_DinhDang_rtbx.Btn_dinhDang_rtbx_Click(s, ev, rtbx_mucTieuNgheNghiep, this.Id, list_UV_dinhDang);
            btn_hocVan.Click += (s, ev) => UngVien_ApDung_DinhDang_rtbx.Btn_dinhDang_rtbx_Click(s, ev, rtbx_hocVan, this.Id, list_UV_dinhDang);
            btn_kinhNghiem.Click += (s, ev) => UngVien_ApDung_DinhDang_rtbx.Btn_dinhDang_rtbx_Click(s, ev, rtbx_kinhNghiem, this.Id, list_UV_dinhDang);
            btn_hoatDong.Click += (s, ev) => UngVien_ApDung_DinhDang_rtbx.Btn_dinhDang_rtbx_Click(s, ev, rtbx_hoatDong, this.Id, list_UV_dinhDang);
            btn_giaiThuong.Click += (s, ev) => UngVien_ApDung_DinhDang_rtbx.Btn_dinhDang_rtbx_Click(s, ev, rtbx_giaiThuong, this.Id, list_UV_dinhDang);
            btn_chungChi.Click += (s, ev) => UngVien_ApDung_DinhDang_rtbx.Btn_dinhDang_rtbx_Click(s, ev, rtbx_chungChi, this.Id, list_UV_dinhDang);

            //  load định dạng từ csdl lên cho các rtbx
            dinhDang_rtbx(rtbx_mucTieuNgheNghiep);
            dinhDang_rtbx(rtbx_hocVan);
            dinhDang_rtbx(rtbx_kinhNghiem);
            dinhDang_rtbx(rtbx_hoatDong);
            dinhDang_rtbx(rtbx_giaiThuong);
            dinhDang_rtbx(rtbx_chungChi);

            //  thay vì truyền userType thì truyền Id để dùng cho hàm Btn_ungTuyen_Click bên Xuat_ThongTin
            UV_DAO.load_tinTuyenDung(UC_BangTin_UV.flpl_danhSachTinTuyenDung, this.Id);
            UV_DAO.load_thuXacNhan(flpl_thuXacNhan, this.Id);
            UV_DAO.load_tinXinViec(flpl_tinDaDang, pnl_chiTietTin, flpl_tinNhan, pnl_chatBox, this.Id);

            //  sắp xếp các tin trong bảng tin, đẩy các tin hết hạn xuống dưới
            UC_BangTin_UV.sapXep();

            //  load biểu đồ cột, tròn cho bảng tin
            ThongKe.thucThi_load_BieuDoTron_BangTin(UC_BangTin_UV.chart_soCV_theoNganh);
            ThongKe.thucThi_load_BieuDoCot_BangTin(UC_BangTin_UV.chart_soCongViec_soUV_theoThang);
        }

        //  load hàm chức năng của phần lọc trong bảng tin
        private void UC_BangTin_UV_Load(object sender, EventArgs e)
        {
            UC_BangTin_UV.cbx_loc_Luong.SelectedIndexChanged += UC_BangTin_UV.cbx_loc_Luong_SelectedIndexChanged;
            UC_BangTin_UV.cbx_loc_nganhNghe.SelectedIndexChanged += UC_BangTin_UV.locTheoDieuKien;
            UC_BangTin_UV.cbx_loc_sapXep.SelectedIndexChanged += UC_BangTin_UV.cbx_loc_sapXep_SelectedIndexChanged;
            UC_BangTin_UV.cbx_loc_kinhNghiem.SelectedIndexChanged += UC_BangTin_UV.locTheoDieuKien;
            UC_BangTin_UV.cbx_loc_diaChi.SelectedIndexChanged += UC_BangTin_UV.locTheoDieuKien;

            UC_BangTin_UV.btn_dangXuat.Click += Btn_dangXuat_Click;
        }

        private void Btn_dangXuat_Click(object sender, EventArgs e)
        {
            this.Close();
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
                rtbx_mucTieuNgheNghiep.Text = u.MucTieuNgheNghiep;
                rtbx_hocVan.Text = u.HocVan;
                rtbx_kinhNghiem.Text = u.KinhNghiem;
                rtbx_hoatDong.Text = u.HoatDong;
                rtbx_giaiThuong.Text = u.GiaiThuong;
                rtbx_chungChi.Text = u.ChungChi;

                //  chỉnh kích cỡ các richtextbox
                ChinhKichThuoc_rtbx.chinhKichThuoc(rtbx_mucTieuNgheNghiep);
                ChinhKichThuoc_rtbx.chinhKichThuoc(rtbx_hocVan);
                ChinhKichThuoc_rtbx.chinhKichThuoc(rtbx_kinhNghiem);
                ChinhKichThuoc_rtbx.chinhKichThuoc(rtbx_hoatDong);
                ChinhKichThuoc_rtbx.chinhKichThuoc(rtbx_giaiThuong);
                ChinhKichThuoc_rtbx.chinhKichThuoc(rtbx_chungChi);

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
                    dt.ToString("dd/MM/yyyy"), rtbx_mucTieuNgheNghiep.Text, rtbx_hocVan.Text, rtbx_kinhNghiem.Text, rtbx_hoatDong.Text, rtbx_giaiThuong.Text, rtbx_chungChi.Text);

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
                || string.IsNullOrEmpty(tbx_mangXaHoi.Text) || string.IsNullOrEmpty(tbx_sdtUV.Text) || string.IsNullOrEmpty(tbx_emaiUV.Text) || string.IsNullOrEmpty(cbx_viTriUngTuyen.Text) || string.IsNullOrEmpty(rtbx_mucTieuNgheNghiep.Text)
                || string.IsNullOrEmpty(rtbx_hocVan.Text) || string.IsNullOrEmpty(rtbx_kinhNghiem.Text) || string.IsNullOrEmpty(rtbx_hoatDong.Text) || string.IsNullOrEmpty(rtbx_giaiThuong.Text) || string.IsNullOrEmpty(rtbx_chungChi.Text))
                return false;
            return true;
        }

        private void taoDinhDang()
        {
            foreach (var i in list_UV_dinhDang)
            {
                UV_DAO.dinhDang_rtbx_UV(i);
            }
        }

        public void btn_hoanTat_Click(object sender, EventArgs e)
        {
            UV_DAO.taoTin(taoUngVien());

            //  buộc phải tạo tin trước mới được tạo định dạng cho rtbx
            taoDinhDang();
        }

        public void btn_luuChinhSua_Click(object sender, EventArgs e)
        {
            UV_DAO.chinhSuaTin(taoUngVien());

            //  buộc phải sửa tin trước mới được tạo định dạng cho rtbx
            taoDinhDang();

            //  reset lại list để tránh trùng Id và RtbxStyle sau mỗi lần chỉnh sửa CV
            list_UV_dinhDang.Clear();
        }

        private void rtbx_mucTieuNgheNghiep_TextChanged_1(object sender, EventArgs e)
        {
            // Tính toán lại chiều cao của RichTextBox khi văn bản thay đổi
            RichTextBox rtbx = (RichTextBox)sender;
            ChinhKichThuoc_rtbx.chinhKichThuoc(rtbx);
        }

        private void dinhDang_rtbx(RichTextBox rtbx)
        {
            UngVien_DinhDang_rtbx dd = UV_DAO.layDinhDang(Id, rtbx.Name);
            if (dd != null)
                UngVien_ApDung_DinhDang_rtbx.apDungDinhDang(rtbx, dd);
        }

        private void btn_newChat_Click(object sender, EventArgs e)
        {
            pnl_chiTietTin.Controls.Clear();

            //  lấy link avatar
            UngVien_Tin uv = UV_DAO.chiTiet_CV(this.Id);

            //  thiết lập và add chi tiết tin xin việc vào pnl_chiTietTin
            UC_TinXinViec uc = new UC_TinXinViec();

            uc.pbx_avatar.Image = Image.FromFile(uv.AnhDaiDien);
            uc.lbl_tenUV.Text = uv.TenUV;
            uc.Dock = DockStyle.Top;

            uc.btn_gui.Click += (s, ev) => UV_DAO.Btn_gui_Click(s, ev, flpl_tinDaDang, pnl_chiTietTin, flpl_tinNhan, pnl_chatBox, uv, uc);
            uc.btn_chinhSua.Enabled = true;

            pnl_chiTietTin.Controls.Add(uc);

        }


    }
}
