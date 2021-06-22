using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace doannhom.Models
{
    public partial class PhanHoi
    {
        public int Stt { get; set; }
        public string HoTenKh { get; set; }
        public int Sdt { get; set; }
        public string Email { get; set; }
        public string MaNv { get; set; }
        public string Hinhthuc { get; set; }
        public string NoiDung { get; set; }
        public DateTime? NgayLap { get; set; }
        public string TinhTrang { get; set; }

        public virtual NhanVien MaNvNavigation { get; set; }
    }
}
