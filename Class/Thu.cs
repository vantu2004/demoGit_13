using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Windows_04
{
    public class Thu
    {
        private string idCompany;
        private string idJobPostings;
        private string idCandidate;
        private string nguoiGui;
        private string nguoiNhan;
        private string chuDe;
        private string noiDung;
        private string ngayGui;

        public Thu(string idCompany, string idJobPostings, string idCandidate, string nguoiGui, string nguoiNhan, string chuDe, string noiDung, string ngayGui)
        {
            IdCompany = idCompany;
            IdJobPostings = idJobPostings;
            IdCandidate = idCandidate;
            NguoiGui = nguoiGui;
            NguoiNhan = nguoiNhan;
            ChuDe = chuDe;
            NoiDung = noiDung;
            NgayGui = ngayGui;
        }

        public string IdCompany { get => idCompany; set => idCompany = value; }
        public string IdJobPostings { get => idJobPostings; set => idJobPostings = value; }
        public string IdCandidate { get => idCandidate; set => idCandidate = value; }
        public string NguoiGui { get => nguoiGui; set => nguoiGui = value; }
        public string NguoiNhan { get => nguoiNhan; set => nguoiNhan = value; }
        public string ChuDe { get => chuDe; set => chuDe = value; }
        public string NoiDung { get => noiDung; set => noiDung = value; }
        public string NgayGui { get => ngayGui; set => ngayGui = value; }
    }
}
