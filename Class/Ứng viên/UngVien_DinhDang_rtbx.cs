using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Windows_04
{
    public class UngVien_DinhDang_rtbx
    {
        private string id;
        private string kieu_rtbx;
        private string mauSac;
        private string kieuChu;
        private string hieuUng;
        private double kichCo;

        public UngVien_DinhDang_rtbx(string id, string kieu_rtbx, string mauSac, string kieuChu, string hieuUng, double kichCo)
        {
            Id = id;
            Kieu_rtbx = kieu_rtbx;
            MauSac = mauSac;
            KieuChu = kieuChu;
            HieuUng = hieuUng;
            KichCo = kichCo;
        }

        public string MauSac { get => mauSac; set => mauSac = value; }
        public string KieuChu { get => kieuChu; set => kieuChu = value; }
        public string HieuUng { get => hieuUng; set => hieuUng = value; }
        public double KichCo { get => kichCo; set => kichCo = value; }
        public string Kieu_rtbx { get => kieu_rtbx; set => kieu_rtbx = value; }
        public string Id { get => id; set => id = value; }
    }
}
