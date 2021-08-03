using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace doannhom.Models
{
    public partial class KhuVuc
    {
        public KhuVuc()
        {
            PhanCong = new HashSet<PhanCong>();
        }

        public int MaKhuVuc { get; set; }
        public string TenKhuVuc { get; set; }

        public virtual ICollection<PhanCong> PhanCong { get; set; }
    }
}
