using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Windows_04
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main_TrangChu());
            //Application.Run(new TuyenDung_UngVien());
            //Application.Run(new DangKy_DangNhap());
            //Application.Run(new TuyenDung_DangKy());
            //Application.Run(new UngVien_DangKy());
            //Application.Run(new TuyenDung_TrangChu());
            //Application.Run(new UngVien_TrangChu());
            //Application.Run(new ChiTietTinTuyenDung());
            //Application.Run(new ChiTietCV());
            //Application.Run(new DanhSach_CV_DaNop());

        }
    }
}
