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
                    //MessageBox.Show("Success!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (data.GetString(1) == "Employer")
                    {
                        //  lấy toàn bộ thông tin NTD thông qua Id cua tài khoản đăng nhập vào
                        string sqlQuery_NTD = string.Format("SELECT * FROM NHATUYENDUNG WHERE Id = '{0}'", data.GetString(0));
                        conn.Close();
                        thucThi_layDuLieu_NTD(sqlQuery_NTD);
                    }
                    else
                    {
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
                    TD_TC.UC_taoTin.btn_hoanTat.Click += TD_TC.Btn_hoanTat_Click1;
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
                    UngVien u = new UngVien(data.GetString(0), data.GetString(1), data.GetString(2), data.GetString(3), data.GetString(4), data.GetString(5), data.GetString(6), data.GetString(7), data.GetString(8));
                    UngVien_TrangChu UV_TC = new UngVien_TrangChu();
                    UV_TC.Id = u.Id;
                    UV_TC.layDuLieu();
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

        //  hàm thực hiện chỉ với 1 lệnh truy vấn nhưng ko xuất messagebox
        public void thucThi_taoTin_chinhSuaTin_koMessageBox(string sqlQuery_taoTin_chinhSuaTin)
        {
            try
            {
                {
                    conn.Open();

                    SqlCommand cmd_TT = new SqlCommand(sqlQuery_taoTin_chinhSuaTin, conn);
                    cmd_TT.ExecuteNonQuery();
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
                        data.GetString(3), data.GetString(4), data.GetString(5), data.GetString(17), data.GetString(18), data.GetString(19), data.GetString(20), data.GetString(21), data.GetString(22), data.GetString(23), data.GetString(24));

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

        public TuyenDung_Tin thucThi_chiTietTin(string sqlQuery_chiTietTin)
        {
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlQuery_chiTietTin, conn);
                SqlDataReader data = cmd.ExecuteReader();

                if (data.Read() == true)
                {
                    TuyenDung_Tin t = new TuyenDung_Tin(data.GetString(0), data.GetString(10), data.GetString(1), data.GetString(11), data.GetString(6), data.GetString(8),
                        data.GetString(7), data.GetString(12), data.GetString(13), Convert.ToDouble(data.GetDecimal(14)), data.GetString(15), data.GetString(16), data.GetString(2),
                        data.GetString(3), data.GetString(4), data.GetString(5), data.GetString(17), data.GetString(18), data.GetString(19), data.GetString(20), data.GetString(21), data.GetString(22), data.GetString(23), data.GetString(24));

                    return t;
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
            return null;
        }

        public void thucThi_load_DS_CV(FlowLayoutPanel flpl, string sqlQuery_load_DS_CV)
        {
            try
            {
                conn.Open();

                Xuat_ThongTin xuat_TT = new Xuat_ThongTin();

                SqlCommand cmd = new SqlCommand(sqlQuery_load_DS_CV, conn);
                SqlDataReader data = cmd.ExecuteReader();

                //  cập nhật ngày nộp là ngày hiện tại
                DateTime dt = DateTime.Now;

                while (data.Read() == true)
                {
                    //  cứ 1 vòng lặp thì add 1 UC_CVs_daNop vào flowlayoutpanel
                    //  truyền IdCompany, IdJobPostings, IdCandidate để dùng cho event xóa, phản hồi CV
                    //  truyền tên, ngày cập nhật CV để dùng cho giao diện CV đã nộp
                    flpl.Controls.Add(xuat_TT.them_CV(data.GetString(0), data.GetString(1), data.GetString(2), data.GetString(5), dt.ToString("dd/MM/yyyy")));
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

        public UngVien_Tin thucThi_chiTietCV(string sqlQuery_chiTietCV)
        {
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlQuery_chiTietCV, conn);
                SqlDataReader data = cmd.ExecuteReader();

                if (data.Read() == true)
                {
                    UngVien_Tin u = new UngVien_Tin(data.GetString(0), data.GetString(10), data.GetString(2), data.GetString(4), data.GetString(8), data.GetString(7),
                        data.GetString(5), data.GetString(3), data.GetString(6), data.GetString(11), data.GetString(18), data.GetString(12), data.GetString(13), data.GetString(14), data.GetString(15), data.GetString(16), data.GetString(17));

                    return u;
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
            return null;
        }

        public TuyenDung_DinhDang_rtbx thucThi_layDinhDang_NTD(string sqlQuery_layDinhDang)
        {
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlQuery_layDinhDang, conn);
                SqlDataReader data = cmd.ExecuteReader();

                if (data.Read() == true)
                {
                    TuyenDung_DinhDang_rtbx dd = new TuyenDung_DinhDang_rtbx(data.GetString(0), data.GetString(1), data.GetString(2), data.GetString(3), data.GetString(4), data.GetString(5), Convert.ToDouble(data.GetDecimal(6)));

                    return dd;
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
            return null;
        }

        public UngVien_DinhDang_rtbx thucThi_layDinhDang_UV(string sqlQuery_layDinhDang)
        {
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlQuery_layDinhDang, conn);
                SqlDataReader data = cmd.ExecuteReader();

                if (data.Read() == true)
                {
                    UngVien_DinhDang_rtbx dd = new UngVien_DinhDang_rtbx(data.GetString(0), data.GetString(1), data.GetString(2), data.GetString(3), data.GetString(4), Convert.ToDouble(data.GetDecimal(5)));

                    return dd;
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
            return null;
        }

        public void thucThi_load_thuXacNhan(string sqlQuery_xuat_thuXacNhan, FlowLayoutPanel flpl)
        {
            try
            {
                conn.Open();

                Xuat_ThongTin xuat_TT = new Xuat_ThongTin();

                SqlCommand cmd = new SqlCommand(sqlQuery_xuat_thuXacNhan, conn);
                SqlDataReader data = cmd.ExecuteReader();

                while (data.Read() == true)
                {
                    Thu t = new Thu(data.GetString(0), data.GetString(1), data.GetString(2), data.GetString(3), data.GetString(4), data.GetString(5), data.GetString(6), data.GetString(7), data.GetString(8), data.GetString(9));

                    //  cứ 1 vòng lặp thì add 1 UC_tinDaDang vào flowlayoutpanel
                    //  truyền DatePosted, JobName, t
                    flpl.Controls.Add(xuat_TT.them_thuXacNhan(data.GetString(13), data.GetString(18), t));
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

        public string thucThi_trangThai_checkChanged(string sqlQuery_trangThai_checkChanged)
        {
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlQuery_trangThai_checkChanged, conn);
                SqlDataReader data = cmd.ExecuteReader();

                if (data.Read() == true)
                {
                    return data.GetString(3);
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
            return null;
        }

        public void thucThi_load_lichPhongVan(string sqlQuery_xuat_thuXacNhan, FlowLayoutPanel flpl)
        {
            try
            {
                conn.Open();

                Xuat_ThongTin xuat_TT = new Xuat_ThongTin();

                SqlCommand cmd = new SqlCommand(sqlQuery_xuat_thuXacNhan, conn);
                SqlDataReader data = cmd.ExecuteReader();

                while (data.Read() == true)
                {

                    LichPhongVan lichPV = new LichPhongVan(data.GetString(3), data.GetString(4), Convert.ToDateTime(data.GetString(5)).ToShortDateString() + " " + Convert.ToDateTime(data.GetString(6)).ToShortTimeString(), data.GetString(7), data.GetString(8));
                    //  cứ 1 vòng lặp thì add 1 UC_LichPhongVan vào flowlayoutpanel
                    //  truyền DatePosted, JobName, t
                    flpl.Controls.Add(xuat_TT.them_lichPhongVan(lichPV));
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
