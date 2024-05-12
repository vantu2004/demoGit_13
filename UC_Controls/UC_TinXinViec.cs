using Guna.UI2.WinForms;
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
    public partial class UC_TinXinViec : UserControl
    {
        public UC_TinXinViec()
        {
            InitializeComponent();
        }

        public void rtbx_noiDung_TextChanged(object sender, EventArgs e)
        {
            RichTextBox rtbx = sender as RichTextBox;
            ChinhKichThuoc_rtbx.chinhKichThuoc(rtbx);
            pnl_btn.Location = new Point(rtbx.Left, rtbx.Bottom + 5);
            this.Size = new Size(this.Width, pnl_btn.Bottom + 15 + this.Margin.Bottom);
        }

        public void loadRtbx(RichTextBox rtbx)
        {
            ChinhKichThuoc_rtbx.chinhKichThuoc(rtbx);
            pnl_btn.Location = new Point(rtbx.Left, rtbx.Bottom + 5);
            this.Size = new Size(this.Width, pnl_btn.Bottom + 15 + this.Margin.Bottom);
        }
    }
}
