using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace doannhom.Models
{
    public partial class Cthd
    {
        public int MaHd { get; set; }
        public string MaMonAn { get; set; }
        public int? SoLuong { get; set; }
        public int? DonGia { get; set; }

        public virtual HoaDon MaHdNavigation { get; set; }
        public virtual MonAn MaMonAnNavigation { get; set; }
    }
}
