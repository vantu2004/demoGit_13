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
    public partial class UC_TinNhan : UserControl
    {
        public UC_TinNhan()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            RichTextBox rtbx = sender as RichTextBox;
            ChinhKichThuoc_rtbx.chinhKichThuoc(rtbx);
            this.Size = new Size(this.Width, rtbx.Bottom + this.Margin.Bottom);
        }

        public void loadRtbx(RichTextBox rtbx)
        {
            ChinhKichThuoc_rtbx.chinhKichThuoc(rtbx);
            this.Size = new Size(this.Width, rtbx.Bottom + this.Margin.Bottom);
        }
    }
}
