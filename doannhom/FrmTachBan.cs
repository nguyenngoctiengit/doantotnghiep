using doannhom.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace doannhom
{
    public partial class FrmTachBan : Form
    {
       
        public FrmTachBan()
        {
            InitializeComponent();
        }
        public NhaHangContext _context = new NhaHangContext();
        public void LoadNV()
        {
            cbbNVTach.DataSource = (from a in _context.NhanVien select new { a.MaNv, a.TenNv }).ToList();
            cbbNVTach.DisplayMember = "TenNv";
            cbbNVTach.ValueMember = "MaNV";
        }
        public void LoadBanCanTach()
        {
            var maBan = (from a in _context.HoaDon where a.Cthd.Count() > 1 && a.TinhTrang == 0 select new { a.MaBan, a.MaHd }).ToList();
            cbbBanTach.DataSource = maBan;
            cbbBanTach.DisplayMember = "MaBan";
            cbbBanTach.ValueMember = "MaHd";
        }
        private void FrmTachBan_Load(object sender, EventArgs e)
        {
            LoadBanTrong();
            LoadNV();
            LoadBanCanTach();
        }
        public void LoadBanTrong()
        {
            cbbBanDen.DataSource = _context.Ban.Where(a => a.TinhTrang == 0).Select(a => a.MaBan).ToList();
        }
        private void cbbBanTach_SelectedValueChanged(object sender, EventArgs e)
        {
            clbMonAn.Items.Clear();
            var maHD = cbbBanTach.SelectedValue.ToString();
            var monan = (from a in _context.Cthd
                         join b in _context.MonAn on a.MaMonAn equals b.MaMonAn
                         where a.MaHd == int.Parse(maHD)
                         select b.TenMon).ToArray();
            clbMonAn.Items.AddRange(monan); 

        }
        private void btnTach_Click(object sender, EventArgs e)
        {

        }
        private void cbbBanDen_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
    }
}
