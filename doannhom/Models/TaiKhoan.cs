using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace doannhom.Models
{
    public partial class TaiKhoan
    {
        public string TenTk { get; set; }
        public string MaNv { get; set; }
        public string MatKhau { get; set; }
        public string ChucVu { get; set; }
        public DateTime? NgayDk { get; set; }

        public virtual NhanVien MaNvNavigation { get; set; }
    }
}
