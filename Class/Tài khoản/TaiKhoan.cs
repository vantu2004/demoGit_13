using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Windows_04
{
    internal class TaiKhoan
    {
        private string id;
        private string userType;
        private string tenDangNhap;
        private string matKhau;

        public TaiKhoan() { }
        public TaiKhoan (string id, string userType, string tenDangNhap, string matKhau)
        { 
            Id = id;
            UserType = userType;
            TenDangNhap = tenDangNhap;
            MatKhau = matKhau;
        }

        public string TenDangNhap { get => tenDangNhap; set => tenDangNhap = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public string Id { get => id; set => id = value; }
        public string UserType { get => userType; set => userType = value; }
    }
}
