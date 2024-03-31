using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Windows_04
{
    public class TuyenDung
    {
        private string id;
        private string userType;
        private string tenHR;
        private string emailHR;
        private string sdtHR;
        private string viTriCongTacHR;
        private string tenCongTy;
        private string diaChiCongTy;
        private string mangXaHoi;

        public TuyenDung() { }
        public TuyenDung(string id, string userType, string tenHR, string emailHR, string sdtHR, string viTriCongTacHR, string tenCongTy, string diaChiCongTy, string mangXaHoi)
        {
            Id = id;
            UserType = userType;
            TenHR = tenHR;
            EmailHR = emailHR;
            SdtHR = sdtHR;
            ViTriCongTacHR = viTriCongTacHR;
            TenCongTy = tenCongTy;
            DiaChiCongTy = diaChiCongTy;
            MangXaHoi = mangXaHoi;
        }

        public string TenHR { get => tenHR; set => tenHR = value; }
        public string EmailHR { get => emailHR; set => emailHR = value; }
        public string SdtHR { get => sdtHR; set => sdtHR = value; }
        public string ViTriCongTacHR { get => viTriCongTacHR; set => viTriCongTacHR = value; }
        public string TenCongTy { get => tenCongTy; set => tenCongTy = value; }
        public string DiaChiCongTy { get => diaChiCongTy; set => diaChiCongTy = value; }
        public string MangXaHoi { get => mangXaHoi; set => mangXaHoi = value; }
        public string Id { get => id; set => id = value; }
        public string UserType { get => userType; set => userType = value; }
    }
}
