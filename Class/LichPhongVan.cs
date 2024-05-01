using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Windows_04
{
    public class LichPhongVan
    {
        private string linkAvatar;
        private string ngayDang;
        private string ngayPhongVan;
        private string tenCongViec;
        private string tenUngVien;

        public LichPhongVan(string linkAvatar, string ngayDang, string ngayPhongVan, string tenCongViec, string tenUngVien)
        {
            LinkAvatar = linkAvatar;
            NgayDang = ngayDang;
            NgayPhongVan = ngayPhongVan;
            TenCongViec = tenCongViec;
            TenUngVien = tenUngVien;
        }

        public string LinkAvatar { get => linkAvatar; set => linkAvatar = value; }
        public string NgayDang { get => ngayDang; set => ngayDang = value; }
        public string NgayPhongVan { get => ngayPhongVan; set => ngayPhongVan = value; }
        public string TenCongViec { get => tenCongViec; set => tenCongViec = value; }
        public string TenUngVien { get => tenUngVien; set => tenUngVien = value; }
    }
}
