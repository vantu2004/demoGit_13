using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using static DevExpress.Skins.SolidColorHelper;

namespace Project_Windows_04
{
    public class Xuat_ThongTin
    {
        Xuat_ThongTin_DAO xuatTT_DAO = new Xuat_ThongTin_DAO();
        private string IdCompany;
        private string IdJobPostings;
        private string userType;

        public Xuat_ThongTin() { }

        //  up tin lên trang chủ
        public UC_TinTuyenDung them_tinTuyenDung(TuyenDung_Tin t, string userType)
        {
            UC_TinTuyenDung UC_tinTuyenDung = new UC_TinTuyenDung();

            //  dán t cho UC_tinTuyenDung để dùng khi gọi sự kiện Click
            UC_tinTuyenDung.Tag = t;

            UC_tinTuyenDung.lbl_tenCongViec.Text = t.TenCongViec;
            UC_tinTuyenDung.pbx_logoCongTy.Image = Image.FromFile(t.LogoCongTy);
            UC_tinTuyenDung.lbl_tenCongTy.Text = t.TenCongTy;
            UC_tinTuyenDung.lbl_luong.Text = t.Luong.ToString();
            UC_tinTuyenDung.lbl_nganhNghe.Text = t.NganhNghe;
            UC_tinTuyenDung.lbl_kinhNghiem.Text = t.KinhNghiem;
            UC_tinTuyenDung.lbl_hinhThucLamViec.Text = t.HinhThucLamViec;
            UC_tinTuyenDung.lbl_diaChi.Text = t.DiaChi;

            //  lấy userType của tài khoản đang đăng nhập
            this.userType = userType;

            //  ẩn checkbox theo dõi tin nếu chưa đăng nhập hoặc là NTD
            if (this.userType == "Employer" || this.userType == "null")
            {
                UC_tinTuyenDung.cbx_theoDoi.Hide();
            }

            UC_tinTuyenDung.Click += UC_tinTuyenDung_Click;

            //  phải return UC_tinTuyenDung vì cần add 1 control vào flowlayoutpanel
            return UC_tinTuyenDung;
        }

        //  xem chi tiết tin tuyển dụng
        private void UC_tinTuyenDung_Click(object sender, EventArgs e)
        {
            UC_TinTuyenDung myObject = sender as UC_TinTuyenDung;
            TuyenDung_Tin t = myObject.Tag as TuyenDung_Tin;

            //  lấy Id của công ty đã đăng tin này và Id của tin đó
            this.IdCompany = t.IdCompany;
            this.IdJobPostings = t.IdJobPostings;

            ChiTietTinTuyenDung chiTiet_tin = new ChiTietTinTuyenDung();

            if (this.userType == "Employer" || this.userType == "null")
            {
                chiTiet_tin.btn_ungTuyen.Hide();
            }       
            else
            {
                chiTiet_tin.btn_ungTuyen.Click += Btn_ungTuyen_Click;
            }   
            
            //  xuất dữ liệu lên controls trong ChiTietTinTuyenDung
            chiTiet_tin.xuatDuLieu(t);

            chiTiet_tin.ShowDialog();
        }

        //  ứng viên nộp CV
        private void Btn_ungTuyen_Click(object sender, EventArgs e)
        {
            xuatTT_DAO.ungTuyen(this.userType, this.IdCompany, this.IdJobPostings);
        }

        //  thêm tin vừa đăng vào danh sách tin đã đăng bên nhà tuyển dụng
        public UC_TinDaDang them_tinDaDang(string IdCompany, string IdJobPostings, string tenCongViec, string ngayDang)
        {
            UC_TinDaDang UC_tinDaDang = new UC_TinDaDang();

            UC_tinDaDang.lbl_ngayDang.Text = ngayDang;
            UC_tinDaDang.lbl_tenCongViec.Text = tenCongViec;

            UC_tinDaDang.Click += (sender, e) => UC_tinDaDang_Click1(sender, e, IdCompany, IdJobPostings);
            // Truyền trực tiếp biến vào phương thức xử lý sự kiện
            UC_tinDaDang.btn_xoaTin.Click += (sender, e) => Btn_xoaTin_Click(IdCompany, IdJobPostings);
            UC_tinDaDang.btn_suaTin.Click += (sender, e) => Btn_suaTin_Click(IdCompany, IdJobPostings);

            return UC_tinDaDang;
        }

        //  load toàn bộ danh sách CV đã nộp vào 1 tin tuyên dụng
        private void UC_tinDaDang_Click1(object sender, EventArgs e, string IdCompany, string IdJobPostings)
        {
            TuyenDung_DS_CVs DSCV = new TuyenDung_DS_CVs();

            xuatTT_DAO.load_DS_CV(DSCV.flpl_danhSachCV, IdCompany, IdJobPostings);

            DSCV.ShowDialog();
        }

        //  xóa 1 tin tuyển dụng trong danh sách tin đã đăng
        private void Btn_xoaTin_Click(string IdCompany, string IdJobPostings)
        {
            xuatTT_DAO.xoa_tinTuyenDung(IdCompany, IdJobPostings);
        }

        //  sửa 1 tin tuyển dụng trong danh sách tin đã đăng
        private void Btn_suaTin_Click(string IdCompany, string IdJobPostings)
        {
            TuyenDung_ChinhSuaTin TD_CST = new TuyenDung_ChinhSuaTin();

            TD_CST.layDuLieu(xuatTT_DAO.chiTietTin(IdCompany, IdJobPostings));

            TD_CST.ShowDialog();
        }

        //  add 1 CV vào flpl, được dùng bên dbConnection
        public UC_CVs_daNop them_CV(string IdCompany, string IdJobPostings, string IdCandidate, string tenCongViec, string ngayDang)
        {
            UC_CVs_daNop UC_CV = new UC_CVs_daNop();

            UC_CV.lbl_ngayDang.Text = ngayDang;
            UC_CV.lbl_fullName.Text = tenCongViec;

            //  truyền đủ IdCompany, IdJobPostings, IdCandidate để dùng cho Btn_phanHoi_Click giúp khởi tạo đối tượng Thu
            UC_CV.Click += (sender, e) => UC_CV_Click(sender, e, IdCompany, IdJobPostings, IdCandidate);
            //  truyền đủ IdCompany, IdJobPostings, IdCandidate để tìm và xóa 1 CV
            UC_CV.btn_xoaCV.Click += (sender, e) => Btn_xoaCV_Click(sender, e, IdCompany, IdJobPostings, IdCandidate);

            return UC_CV;
        }

        //  xóa CV của 1 ứng viên ra khỏi danh sách CV đã nộp
        private void Btn_xoaCV_Click(object sender, EventArgs e, string IdCompany, string IdJobPostings, string IdCandidate)
        {
            xuatTT_DAO.xoaCV(IdCompany, IdJobPostings, IdCandidate);
        }

        //  xem chi tiết thông tin 1 CV của 1 ứng viên
        private void UC_CV_Click(object sender, EventArgs e, string IdCompany, string IdJobPostings, string IdCandidate)
        {
            ChiTietCV CV = new ChiTietCV();

            CV.layDuLieu(xuatTT_DAO.chiTiet_CV(IdCandidate));

            //  gọi sự kiện cho nút feedback
            CV.btn_phanHoi.Click += (s, ev) => Btn_phanHoi_Click(s, ev, IdCompany, IdJobPostings, IdCandidate);

            CV.ShowDialog();
        }

        //  phản hồi về CV cho 1 ứng viên
        private void Btn_phanHoi_Click(object sender, EventArgs e, string IdCompany, string IdJobPostings, string IdCandidate)
        {
            ChiTietThu thu = new ChiTietThu();

            //  tìm mail của HR đã tạo tin, tìm mail người nộp CV sau đó đổ thông tin vào ChiTetThu
            thu.xuatDuLieu_khiGui(xuatTT_DAO.chiTietTin(IdCompany, IdJobPostings), xuatTT_DAO.chiTiet_CV(IdCandidate));

            thu.UC_Thu.btn_gui.Click += (s, ev) => Btn_gui_Click(s, ev, thu, IdCompany, IdJobPostings, IdCandidate);

            thu.ShowDialog();
        }

        private void Btn_gui_Click(object sender, EventArgs e, ChiTietThu thu, string IdCompany, string IdJobPostings, string IdCandidate)
        {
            //  mặc định ko được bỏ trống nội dung thư
            if (thu.kiemTraNull())
            {

                Thu t = new Thu(IdCompany, IdJobPostings, IdCandidate, thu.UC_Thu.tbx_nguoiGui.Text, thu.UC_Thu.tbx_nguoiNhan.Text, thu.UC_Thu.tbx_chuDe.Text, thu.UC_Thu.rtbx_noiDung.Text, thu.UC_Thu.lbl_ngayGui.Text);
                xuatTT_DAO.luuThu(t);
            }
            else
                MessageBox.Show("You must fill in all information!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //  thêm 1 thư xác nhận vào danh sách bên ứng viên
        public UC_TinDaDang them_thuXacNhan(string tenCongViec, string ngayDang, Thu t)
        {
            UC_TinDaDang UC_tinDaDang = new UC_TinDaDang();

            UC_tinDaDang.lbl_ngayDang.Text = ngayDang;
            UC_tinDaDang.lbl_tenCongViec.Text = tenCongViec;

            UC_tinDaDang.Click += (sender, e) => UC_tinDaDang_Click(sender, e, t);

            //  ẩn nút chỉnh sửa và xóa
            UC_tinDaDang.btn_xoaTin.Hide();
            UC_tinDaDang.btn_suaTin.Hide();

            return UC_tinDaDang;
        }

        //  sự kiện khi click vào thì hiện chi tiết thư
        private void UC_tinDaDang_Click(object sender, EventArgs e, Thu t)
        {
            ChiTietThu chiTiet_thu = new ChiTietThu();

            chiTiet_thu.xuatDuLieu_khiNhan(t);

            chiTiet_thu.ShowDialog();
        }
    }
}
