using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace doannhom.Models
{
    public partial class NhanVien
    {
        public NhanVien()
        {
            HoaDon = new HashSet<HoaDon>();
            PhanCong = new HashSet<PhanCong>();
            PhanHoi = new HashSet<PhanHoi>();
            TaiKhoan = new HashSet<TaiKhoan>();
        }

        public string MaNv { get; set; }
        public string TenNv { get; set; }
        public string GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        public int? Sdt { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public DateTime? NgayVaoLam { get; set; }
        public string ChucVu { get; set; }
        public int? PhuCap { get; set; }

        public virtual ICollection<HoaDon> HoaDon { get; set; }
        public virtual ICollection<PhanCong> PhanCong { get; set; }
        public virtual ICollection<PhanHoi> PhanHoi { get; set; }
        public virtual ICollection<TaiKhoan> TaiKhoan { get; set; }
    }
}
