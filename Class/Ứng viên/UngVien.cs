using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Windows_04
{
    public class UngVien
    {
        private string id;
        private string userType;
        private string ten;
        private string sdt;
        private string ngaySinh;
        private string mangXaHoi;
        private string email;
        private string diaChi;
        private string gioiTinh;

        public UngVien() { }
        public UngVien(string id, string userType, string ten, string sdt, string ngaySinh, string mangXaHoi, string email, string diaChi, string gioiTinh)
        {
            Id = id;
            UserType = userType;
            Ten = ten;
            Sdt = sdt;
            NgaySinh = ngaySinh;
            MangXaHoi = mangXaHoi;
            Email = email;
            DiaChi = diaChi;
            GioiTinh = gioiTinh;
        }

        public string Ten { get => ten; set => ten = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string MangXaHoi { get => mangXaHoi; set => mangXaHoi = value; }
        public string Email { get => email; set => email = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string Id { get => id; set => id = value; }
        public string UserType { get => userType; set => userType = value; }
    }
}
