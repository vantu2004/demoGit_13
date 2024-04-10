using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Windows_04
{
    public partial class UC_BangTin : UserControl
    {
        public UC_BangTin()
        {
            InitializeComponent();
        }

        public void cbx_loc_Luong_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedRange = cbx_loc_Luong.SelectedItem.ToString();
            foreach (Control control in flpl_danhSachTinTuyenDung.Controls)
            {
                if (control is UC_TinTuyenDung userControl)
                {
                    decimal price = decimal.Parse(userControl.lbl_luong.Text);

                    // Kiểm tra xem giá tiền của UserControl có nằm trong khoảng được chọn không
                    if (kiemTra_luong(price, selectedRange))
                    {
                        // Hiển thị UserControl
                        control.Visible = true;
                    }
                    else
                    {
                        // Ẩn UserControl nếu không nằm trong khoảng
                        control.Visible = false;
                    }
                }
            }
        }

        private bool kiemTra_luong(decimal price, string selectedRange)
        {
            // Phân tích chuỗi của ComboBox để xác định khoảng giá tiền
            switch (selectedRange)
            {
                case "<10m":
                    return price < 10000000; // 10m = 10,000,000
                case "10m - 20m":
                    return price > 10000000 && price <= 20000000;
                case "20m - 30m":
                    return price > 20000000 && price <= 30000000;
                case ">30m":
                    return price > 30000000;
                default:
                    return false;
            }
        }

        public void cbx_loc_nganhNghe_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedRange = cbx_loc_nganhNghe.SelectedItem.ToString();
            foreach (Control control in flpl_danhSachTinTuyenDung.Controls)
            {
                if (control is UC_TinTuyenDung cbx)
                {
                    if (kiemTra_nganhNghe_kinhNghiem_diaChi(cbx.lbl_nganhNghe.Text, selectedRange))
                    {
                        // Hiển thị UserControl
                        control.Visible = true;
                    }
                    else
                    {
                        // Ẩn UserControl nếu không nằm trong khoảng
                        control.Visible = false;
                    }
                }
            }
        }

        public void cbx_loc_kinhNghiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedRange = cbx_loc_kinhNghiem.SelectedItem.ToString();
            foreach (Control control in flpl_danhSachTinTuyenDung.Controls)
            {
                if (control is UC_TinTuyenDung cbx)
                {
                    if (kiemTra_nganhNghe_kinhNghiem_diaChi(cbx.lbl_kinhNghiem.Text, selectedRange))
                    {
                        // Hiển thị UserControl
                        control.Visible = true;
                    }
                    else
                    {
                        // Ẩn UserControl nếu không nằm trong khoảng
                        control.Visible = false;
                    }
                }
            }
        }

        public void cbx_loc_diaChi_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedRange = cbx_loc_diaChi.SelectedItem.ToString();
            foreach (Control control in flpl_danhSachTinTuyenDung.Controls)
            {
                if (control is UC_TinTuyenDung cbx)
                {
                    if (kiemTra_nganhNghe_kinhNghiem_diaChi(cbx.lbl_diaChi.Text, selectedRange))
                    {
                        // Hiển thị UserControl
                        control.Visible = true;
                    }
                    else
                    {
                        // Ẩn UserControl nếu không nằm trong khoảng
                        control.Visible = false;
                    }
                }
            }
        }

        private bool kiemTra_nganhNghe_kinhNghiem_diaChi(string nganhNghe, string selectedRange)
        {
            if (nganhNghe == selectedRange)
                return true;
            return false;
        }

        public void cbx_loc_sapXep_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedRange = cbx_loc_sapXep.SelectedItem.ToString();
            //if ()
            selectedRange = "Salary";
            {
                UserControl[] userControls = flpl_danhSachTinTuyenDung.Controls.OfType<UserControl>().ToArray();

                Array.Sort(userControls, (uc1, uc2) =>
                {
                    // Sử dụng thuộc tính lương của mỗi UserControl để so sánh
                    decimal salary1 = decimal.Parse((uc1 as UC_TinTuyenDung).lbl_luong.Text);
                    decimal salary2 = decimal.Parse((uc2 as UC_TinTuyenDung).lbl_luong.Text);

                    // Sắp xếp tăng dần theo lương
                    return salary1.CompareTo(salary2);
                });

                // Xóa tất cả các UserControl khỏi panel
                flpl_danhSachTinTuyenDung.Controls.Clear();

                // Thêm UserControl đã sắp xếp vào panel
                foreach (UserControl uc in userControls)
                {
                    flpl_danhSachTinTuyenDung.Controls.Add(uc);
                }
            }    
        }
    }
}
