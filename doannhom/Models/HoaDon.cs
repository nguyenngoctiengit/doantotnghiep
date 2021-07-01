using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace doannhom.Models
{
    public partial class HoaDon
    {
        public HoaDon()
        {
            Cthd = new HashSet<Cthd>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int MaHd { get; set; }
        public string MaBan { get; set; }
        public string MaNv { get; set; }
        public DateTime? NgayLap { get; set; }
        public int? TongTien { get; set; }

        public virtual Ban MaBanNavigation { get; set; }
        public virtual NhanVien MaNvNavigation { get; set; }
        public virtual ICollection<Cthd> Cthd { get; set; }
    }
}
