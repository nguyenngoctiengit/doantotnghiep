using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace doannhom.Models
{
    public partial class MonAn
    {
        public MonAn()
        {
            Cthd = new HashSet<Cthd>();
        }

        public string MaMonAn { get; set; }
        public string MaLoai { get; set; }
        public string TenMon { get; set; }
        public string Dvt { get; set; }
        public int DonGia { get; set; }

        public virtual LoaiMonAn MaLoaiNavigation { get; set; }
        public virtual ICollection<Cthd> Cthd { get; set; }
    }
}
