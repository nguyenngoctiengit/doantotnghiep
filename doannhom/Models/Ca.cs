using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace doannhom.Models
{
    public partial class Ca
    {
        public Ca()
        {
            PhanCong = new HashSet<PhanCong>();
        }

        public string MaCa { get; set; }
        public string TenCa { get; set; }
        public string LuuY { get; set; }
        public DateTime? NgayBd { get; set; }
        public DateTime? NgayKt { get; set; }

        public virtual ICollection<PhanCong> PhanCong { get; set; }
    }
}
