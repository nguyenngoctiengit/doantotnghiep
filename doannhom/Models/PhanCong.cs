﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace doannhom.Models
{
    public partial class PhanCong
    {
        public string MaCa { get; set; }
        public string MaNv { get; set; }
        public string MaBan { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }

        public virtual Ban MaBanNavigation { get; set; }
        public virtual Ca MaCaNavigation { get; set; }
        public virtual NhanVien MaNvNavigation { get; set; }
    }
}
