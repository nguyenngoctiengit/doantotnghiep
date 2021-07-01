using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace doannhom.Models
{
    public partial class Ban
    {
        public Ban()
        {
            HoaDon = new HashSet<HoaDon>();
            PhanCong = new HashSet<PhanCong>();
        }

        public string MaBan { get; set; }
        public int TinhTrang { get; set; }

        public virtual ICollection<HoaDon> HoaDon { get; set; }
        public virtual ICollection<PhanCong> PhanCong { get; set; }
    }
}
