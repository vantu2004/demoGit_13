using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using static DevExpress.Xpo.Helpers.CommandChannelHelper;

namespace Project_Windows_04
{
    internal class dbConnection
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);

        public dbConnection() { }

        public void thucThi_dangKy(string sqlQuery_NTD_UV, string sqlQuery_TK)
        {
            try
            {
                conn.Open();
                SqlCommand cmd_TK = new SqlCommand(sqlQuery_TK, conn);

                if (cmd_TK.ExecuteNonQuery() > 0)
                {
                    SqlCommand cmd_NTD_UV = new SqlCommand(sqlQuery_NTD_UV, conn);

                    if (cmd_NTD_UV.ExecuteNonQuery() > 0)
                        MessageBox.Show("Success!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! \n" + ex, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        public void thucThi_dangNhap(string sqlQuery)
        {
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                SqlDataReader data = cmd.ExecuteReader();

                if (data.Read() == true)
                {
                    MessageBox.Show("Success!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    if (data.GetString(1) == "Employer")
                    {
                        //  lấy toàn bộ thông tin NTD thông qua Id cua tài khoản đăng nhập vào
                        string sqlQuery_NTD = string.Format("SELECT * FROM NHATUYENDUNG WHERE Id = '{0}'", data.GetString(0));
                        conn.Close();
                        thucThi_layDuLieu_NTD(sqlQuery_NTD);
                    }
                    else
                    {
                        //string sqlQuery_UV = string.Format("SELECT * FROM UNGVIEN INNER JOIN CVs ON UNGVIEN.Id = CVs.Id WHERE UNGVIEN.Id = '{0}'", data.GetString(0));
                        //  lấy toàn bộ thông tin của UV thông qua Id của tài khoản đăng nhập vào
                        string sqlQuery_UV = string.Format("SELECT * FROM UNGVIEN  WHERE Id = '{0}'", data.GetString(0));
                        conn.Close();
                        thucThi_layDuLieu_UV(sqlQuery_UV);
                    }    
                }
                else
                {
                    MessageBox.Show("Not found!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! \n" + ex, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        public void thucThi_layDuLieu_NTD(string sqlQuery_NTD)
        {
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlQuery_NTD, conn);
                SqlDataReader data = cmd.ExecuteReader();

                if (data.Read() == true)
                {
                    //  tạo 1 đối tương TuyenDung chứa thông tin tài khoản hiện tại đang đăng nhập để truyền Id + thông tin tài khoản hiện tại cho form TuyenDung_TrangChu
                    TuyenDung t = new TuyenDung(data.GetString(0), data.GetString(1), data.GetString(2), data.GetString(3), data.GetString(4), data.GetString(5), data.GetString(6), data.GetString(7), data.GetString(8));
                    TuyenDung_TrangChu TD_TC = new TuyenDung_TrangChu();

                    //  đổ thông tin vào form
                    TD_TC.layDuLieu(t);
                    TD_TC.ShowDialog();
                    //  gọi event click để thực thi chức năng nút btn_hoanTat để tạo tin tuyển dụng
                    TD_TC.btn_hoanTat.Click += TD_TC.Btn_hoanTat_Click;
                }
                else
                    MessageBox.Show("Not found!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! \n" + ex, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        public void thucThi_layDuLieu_UV(string sqlQuery_UV)
        {
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlQuery_UV, conn);
                SqlDataReader data = cmd.ExecuteReader();

                if (data.Read() == true)
                {
                    //UngVien_Tin u = new UngVien_Tin(data.GetString(0), data.GetString(10), data.GetString(2), data.GetString(4), data.GetString(8), data.GetString(7), data.GetString(5), data.GetString(3), data.GetString(6), data.GetString(11), data.GetString(15), data.GetString(12), data.GetString(13), data.GetString(14));
                    UngVien u = new UngVien(data.GetString(0), data.GetString(1), data.GetString(2), data.GetString(3), data.GetString(4), data.GetString(5), data.GetString(6), data.GetString(7), data.GetString(8));
                    UngVien_TrangChu UV_TC = new UngVien_TrangChu();
                    UV_TC.layDuLieu(u);
                    UV_TC.Id = u.Id;
                    UV_TC.ShowDialog();
                    UV_TC.btn_hoanTat.Click += UV_TC.btn_hoanTat_Click;
                    UV_TC.btn_luuChinhSua.Click += UV_TC.btn_luuChinhSua_Click;
                }
                else
                    MessageBox.Show("Not found!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! '\n" + ex, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        //  hàm thực hiện chỉ với 1 lệnh truy vấn
        public void thucThi_taoTin_chinhSuaTin(string sqlQuery_taoTin_chinhSuaTin)
        {
            try
            {
                {
                    conn.Open();

                    SqlCommand cmd_TT = new SqlCommand(sqlQuery_taoTin_chinhSuaTin, conn);

                    if (cmd_TT.ExecuteNonQuery() > 0)
                        MessageBox.Show("Success!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! \n" + ex.Message, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                conn.Close();
            }
        }

        public void thucThi_load_tinTuyenDung(string sqlQuery_xuat_tinTuyenDung, FlowLayoutPanel flowLayoutPanel, string kieuNguoiDung)
        {
            try
            {
                conn.Open();

                Xuat_ThongTin xuat_TT = new Xuat_ThongTin();

                SqlCommand cmd = new SqlCommand(sqlQuery_xuat_tinTuyenDung, conn);
                SqlDataReader data = cmd.ExecuteReader();

                while (data.Read() == true)
                {
                    //  cứ 1 vòng lặp là tạo 1 đối tượng t để truyền vào sử cho lớp Xuat_ThongTin
                    TuyenDung_Tin t = new TuyenDung_Tin(data.GetString(0), data.GetString(10), data.GetString(1), data.GetString(11), data.GetString(6), data.GetString(8), 
                        data.GetString(7), data.GetString(12), data.GetString(13), Convert.ToDouble(data.GetDecimal(14)), data.GetString(15), data.GetString(16), data.GetString(2), 
                        data.GetString(3), data.GetString(4), data.GetString(5), data.GetString(17), data.GetString(18), data.GetString(19), data.GetString(20), data.GetString(21));

                    flowLayoutPanel.Controls.Add(xuat_TT.them_tinTuyenDung(t, kieuNguoiDung));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! '\n" + ex, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }


        public void thucThi_load_tinDaDang(string sqlQuery_xuat_tinDaDang, FlowLayoutPanel flowLayoutPanel)
        {
            try
            {
                conn.Open();

                Xuat_ThongTin xuat_TT = new Xuat_ThongTin();

                SqlCommand cmd = new SqlCommand(sqlQuery_xuat_tinDaDang, conn);
                SqlDataReader data = cmd.ExecuteReader();

                while (data.Read() == true)
                {
                    //  cứ 1 vòng lặp thì add 1 UC_daDang vào flowlayoutpanel
                    //  truyền IdCompany, IdJobPostings, DatePosted, JobName
                    flowLayoutPanel.Controls.Add(xuat_TT.them_tinDaDang(data.GetString(0), data.GetString(1), data.GetString(4), data.GetString(8)));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! '\n" + ex, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
