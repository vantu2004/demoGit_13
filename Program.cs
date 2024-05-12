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
            //global::System.Windows.Forms.Application.EnableVisualStyles();
            //global::System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            //global::System.Windows.Forms.Application.Run(new Main_TrangChu());
        }
    }
}
