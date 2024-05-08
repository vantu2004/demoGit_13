using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Windows_04
{
    public class TuyenDung_DinhDang_rtbx
    {
        private string idCompany;
        private string idJobPostings;
        private string kieu_rtbx;
        private string mauSac;
        private string kieuChu;
        private string hieuUng;
        private double kichCo;

        public TuyenDung_DinhDang_rtbx() { }

        public TuyenDung_DinhDang_rtbx(string idCompany, string idJobPostings, string kieu_rtbx, string mauSac, string kieuChu, string hieuUng, double kichCo)
        {
            IdCompany = idCompany;
            IdJobPostings = idJobPostings;
            Kieu_rtbx = kieu_rtbx;
            MauSac = mauSac;
            KieuChu = kieuChu;
            HieuUng = hieuUng;
            KichCo = kichCo;
        }

        public string IdCompany { get => idCompany; set => idCompany = value; }
        public string MauSac { get => mauSac; set => mauSac = value; }
        public string KieuChu { get => kieuChu; set => kieuChu = value; }
        public string HieuUng { get => hieuUng; set => hieuUng = value; }
        public double KichCo { get => kichCo; set => kichCo = value; }
        public string Kieu_rtbx { get => kieu_rtbx; set => kieu_rtbx = value; }
        public string IdJobPostings { get => idJobPostings; set => idJobPostings = value; }
    }
}
