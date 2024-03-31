using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Windows_04
{
    public class UngVien_Tin
    {
        private string id;
        private string anhDaiDien;
        private string tenUV;
        private string ngaySinhUV;
        private string gioiTinhUV;
        private string diaChi;
        private string mangXaHoi;
        private string sdtUV;
        private string emailUV;
        private string viTriUngTuyen;
        private string ngayCapNhatCV;
        private string mucTieuNgheNghiep;
        private string hocVan;
        private string kinhNghiem;

        public UngVien_Tin(string id, string anhDaiDien, string tenUV, string ngaySinhUV, string gioiTinhUV, string diaChi, string mangXaHoi, string sdtUV, string emailUV, string viTriUngTuyen, string ngayCapNhatCV, string mucTieuNgheNghiep, string hocVan, string kinhNghiem)
        {
            Id = id;
            AnhDaiDien = anhDaiDien;
            TenUV = tenUV;
            NgaySinhUV = ngaySinhUV;
            GioiTinhUV = gioiTinhUV;
            DiaChi = diaChi;
            MangXaHoi = mangXaHoi;
            SdtUV = sdtUV;
            EmailUV = emailUV;
            ViTriUngTuyen = viTriUngTuyen;
            NgayCapNhatCV = ngayCapNhatCV;
            MucTieuNgheNghiep = mucTieuNgheNghiep;
            HocVan = hocVan;
            KinhNghiem = kinhNghiem;
        }

        public string Id { get => id; set => id = value; }
        public string TenUV { get => tenUV; set => tenUV = value; }
        public string NgaySinhUV { get => ngaySinhUV; set => ngaySinhUV = value; }
        public string GioiTinhUV { get => gioiTinhUV; set => gioiTinhUV = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string MangXaHoi { get => mangXaHoi; set => mangXaHoi = value; }
        public string SdtUV { get => sdtUV; set => sdtUV = value; }
        public string EmailUV { get => emailUV; set => emailUV = value; }
        public string ViTriUngTuyen { get => viTriUngTuyen; set => viTriUngTuyen = value; }
        public string NgayCapNhatCV { get => ngayCapNhatCV; set => ngayCapNhatCV = value; }
        public string MucTieuNgheNghiep { get => mucTieuNgheNghiep; set => mucTieuNgheNghiep = value; }
        public string HocVan { get => hocVan; set => hocVan = value; }
        public string KinhNghiem { get => kinhNghiem; set => kinhNghiem = value; }
        public string AnhDaiDien { get => anhDaiDien; set => anhDaiDien = value; }
    }
}
