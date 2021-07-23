using doannhom.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace doannhom
{
    public partial class FrMenuNV : Form
    {
        public FrMenuNV()
        {
            InitializeComponent();
        }
        public NhaHangContext _context = new NhaHangContext();
        private void ban1_Click(object sender, EventArgs e)
        {
            var Ban = _context.Ban.Where(a => a.MaBan == "1").FirstOrDefault();
            txtban.Text = Ban.MaBan;
            dgvban.DataSource = (from a in _context.HoaDon
                                 join b in _context.Ban on a.MaBan equals b.MaBan
                                 join c in _context.Cthd on a.MaHd equals c.MaHd
                                 where b.MaBan == Ban.MaBan && b.TinhTrang == 1 && a.TinhTrang == 0
                                 select new
                                 {
                                     c.MaMonAn,
                                     c.SoLuong,
                                     c.DonGia
                                 }).ToList();
            if (Ban.TinhTrang == 0)
            {
                btnThanhtoan.Visible = false;
            }
            else
            {
                btnThanhtoan.Visible = true;
            }
        }

        private void ban2_Click(object sender, EventArgs e)
        {
            var Ban = _context.Ban.Where(a => a.MaBan == "2").FirstOrDefault();
            txtban.Text = Ban.MaBan;
            dgvban.DataSource = (from a in _context.HoaDon
                                 join b in _context.Ban on a.MaBan equals b.MaBan
                                 join c in _context.Cthd on a.MaHd equals c.MaHd
                                 where b.MaBan == Ban.MaBan && b.TinhTrang == 1 && a.TinhTrang == 0
                                 select new
                                 {
                                     c.MaMonAn,
                                     c.SoLuong,
                                     c.DonGia
                                 }).ToList();
            if (Ban.TinhTrang == 0)
            {
                btnThanhtoan.Visible = false;
            }
            else
            {
                btnThanhtoan.Visible = true;
            }
        }

        private void ban3_Click(object sender, EventArgs e)
        {
            var Ban = _context.Ban.Where(a => a.MaBan == "3").FirstOrDefault();
            txtban.Text = Ban.MaBan;
            dgvban.DataSource = (from a in _context.HoaDon
                                 join b in _context.Ban on a.MaBan equals b.MaBan
                                 join c in _context.Cthd on a.MaHd equals c.MaHd
                                 where b.MaBan == Ban.MaBan && b.TinhTrang == 1 && a.TinhTrang == 0
                                 select new
                                 {
                                     c.MaMonAn,
                                     c.SoLuong,
                                     c.DonGia
                                 }).ToList();
            if (Ban.TinhTrang == 0)
            {
                btnThanhtoan.Visible = false;
            }
            else
            {
                btnThanhtoan.Visible = true;
            }
        }

        private void ban4_Click(object sender, EventArgs e)
        {
            var Ban = _context.Ban.Where(a => a.MaBan == "4").FirstOrDefault();
            txtban.Text = Ban.MaBan;
            dgvban.DataSource = (from a in _context.HoaDon
                                 join b in _context.Ban on a.MaBan equals b.MaBan
                                 join c in _context.Cthd on a.MaHd equals c.MaHd
                                 where b.MaBan == Ban.MaBan && b.TinhTrang == 1 && a.TinhTrang == 0
                                 select new
                                 {
                                     c.MaMonAn,
                                     c.SoLuong,
                                     c.DonGia
                                 }).ToList();
            if (Ban.TinhTrang == 0)
            {
                btnThanhtoan.Visible = false;
            }
            else
            {
                btnThanhtoan.Visible = true;
            }
        }

        private void ban5_Click(object sender, EventArgs e)
        {
            var Ban = _context.Ban.Where(a => a.MaBan == "5").FirstOrDefault();
            txtban.Text = Ban.MaBan;
            dgvban.DataSource = (from a in _context.HoaDon
                                 join b in _context.Ban on a.MaBan equals b.MaBan
                                 join c in _context.Cthd on a.MaHd equals c.MaHd
                                 where b.MaBan == Ban.MaBan && b.TinhTrang == 1 && a.TinhTrang == 0
                                 select new
                                 {
                                     c.MaMonAn,
                                     c.SoLuong,
                                     c.DonGia
                                 }).ToList();
            if (Ban.TinhTrang == 0)
            {
                btnThanhtoan.Visible = false;
            }
            else
            {
                btnThanhtoan.Visible = true;
            }
        }

        private void ban6_Click(object sender, EventArgs e)
        {
            var Ban = _context.Ban.Where(a => a.MaBan == "6").FirstOrDefault();
            txtban.Text = Ban.MaBan;
            dgvban.DataSource = (from a in _context.HoaDon
                                 join b in _context.Ban on a.MaBan equals b.MaBan
                                 join c in _context.Cthd on a.MaHd equals c.MaHd
                                 where b.MaBan == Ban.MaBan && b.TinhTrang == 1 && a.TinhTrang == 0
                                 select new
                                 {
                                     c.MaMonAn,
                                     c.SoLuong,
                                     c.DonGia
                                 }).ToList();
            if (Ban.TinhTrang == 0)
            {
                btnThanhtoan.Visible = false;
            }
            else
            {
                btnThanhtoan.Visible = true;
            }
        }

        private void ban7_Click(object sender, EventArgs e)
        {
            var Ban = _context.Ban.Where(a => a.MaBan == "7").FirstOrDefault();
            txtban.Text = Ban.MaBan;
            dgvban.DataSource = (from a in _context.HoaDon
                                 join b in _context.Ban on a.MaBan equals b.MaBan
                                 join c in _context.Cthd on a.MaHd equals c.MaHd
                                 where b.MaBan == Ban.MaBan && b.TinhTrang == 1 && a.TinhTrang == 0
                                 select new
                                 {
                                     c.MaMonAn,
                                     c.SoLuong,
                                     c.DonGia
                                 }).ToList();
            if (Ban.TinhTrang == 0)
            {
                btnThanhtoan.Visible = false;
            }
            else
            {
                btnThanhtoan.Visible = true;
            }
        }

        private void ban8_Click(object sender, EventArgs e)
        {
            var Ban = _context.Ban.Where(a => a.MaBan == "8").FirstOrDefault();
            txtban.Text = Ban.MaBan;
            dgvban.DataSource = (from a in _context.HoaDon
                                 join b in _context.Ban on a.MaBan equals b.MaBan
                                 join c in _context.Cthd on a.MaHd equals c.MaHd
                                 where b.MaBan == Ban.MaBan && b.TinhTrang == 1 && a.TinhTrang == 0
                                 select new
                                 {
                                     c.MaMonAn,
                                     c.SoLuong,
                                     c.DonGia
                                 }).ToList();
            if (Ban.TinhTrang == 0)
            {
                btnThanhtoan.Visible = false;
            }
            else
            {
                btnThanhtoan.Visible = true;
            }
        }

        private void ban9_Click(object sender, EventArgs e)
        {
            var Ban = _context.Ban.Where(a => a.MaBan == "9").FirstOrDefault();
            txtban.Text = Ban.MaBan;
            dgvban.DataSource = (from a in _context.HoaDon
                                 join b in _context.Ban on a.MaBan equals b.MaBan
                                 join c in _context.Cthd on a.MaHd equals c.MaHd
                                 where b.MaBan == Ban.MaBan && b.TinhTrang == 1 && a.TinhTrang == 0
                                 select new
                                 {
                                     c.MaMonAn,
                                     c.SoLuong,
                                     c.DonGia
                                 }).ToList();
            if (Ban.TinhTrang == 0)
            {
                btnThanhtoan.Visible = false;
            }
            else
            {
                btnThanhtoan.Visible = true;
            }
        }

        private void ban10_Click(object sender, EventArgs e)
        {
            var Ban = _context.Ban.Where(a => a.MaBan == "10").FirstOrDefault();
            txtban.Text = Ban.MaBan;
            dgvban.DataSource = (from a in _context.HoaDon
                                 join b in _context.Ban on a.MaBan equals b.MaBan
                                 join c in _context.Cthd on a.MaHd equals c.MaHd
                                 where b.MaBan == Ban.MaBan && b.TinhTrang == 1 && a.TinhTrang == 0
                                 select new
                                 {
                                     c.MaMonAn,
                                     c.SoLuong,
                                     c.DonGia
                                 }).ToList();
            if (Ban.TinhTrang == 0)
            {
                btnThanhtoan.Visible = false;
            }
            else
            {
                btnThanhtoan.Visible = true;
            }
        }

        private void ban11_Click(object sender, EventArgs e)
        {
            var Ban = _context.Ban.Where(a => a.MaBan == "11").FirstOrDefault();
            txtban.Text = Ban.MaBan;
            dgvban.DataSource = (from a in _context.HoaDon
                                 join b in _context.Ban on a.MaBan equals b.MaBan
                                 join c in _context.Cthd on a.MaHd equals c.MaHd
                                 where b.MaBan == Ban.MaBan && b.TinhTrang == 1 && a.TinhTrang == 0
                                 select new
                                 {
                                     c.MaMonAn,
                                     c.SoLuong,
                                     c.DonGia
                                 }).ToList();
            if (Ban.TinhTrang == 0)
            {
                btnThanhtoan.Visible = false;
            }
            else
            {
                btnThanhtoan.Visible = true;
            }
        }

        private void ban12_Click(object sender, EventArgs e)
        {
            var Ban = _context.Ban.Where(a => a.MaBan == "12").FirstOrDefault();
            txtban.Text = Ban.MaBan;
            dgvban.DataSource = (from a in _context.HoaDon
                                 join b in _context.Ban on a.MaBan equals b.MaBan
                                 join c in _context.Cthd on a.MaHd equals c.MaHd
                                 where b.MaBan == Ban.MaBan && b.TinhTrang == 1 && a.TinhTrang == 0
                                 select new
                                 {
                                     c.MaMonAn,
                                     c.SoLuong,
                                     c.DonGia
                                 }).ToList();
            if (Ban.TinhTrang == 0)
            {
                btnThanhtoan.Visible = false;
            }
            else
            {
                btnThanhtoan.Visible = true;
            }
        }

        private void ban13_Click(object sender, EventArgs e)
        {
            var Ban = _context.Ban.Where(a => a.MaBan == "13").FirstOrDefault();
            txtban.Text = Ban.MaBan;
            dgvban.DataSource = (from a in _context.HoaDon
                                 join b in _context.Ban on a.MaBan equals b.MaBan
                                 join c in _context.Cthd on a.MaHd equals c.MaHd
                                 where b.MaBan == Ban.MaBan && b.TinhTrang == 1 && a.TinhTrang == 0
                                 select new
                                 {
                                     c.MaMonAn,
                                     c.SoLuong,
                                     c.DonGia
                                 }).ToList();
            if (Ban.TinhTrang == 0)
            {
                btnThanhtoan.Visible = false;
            }
            else
            {
                btnThanhtoan.Visible = true;
            }
        }

        private void ban14_Click(object sender, EventArgs e)
        {
            var Ban = _context.Ban.Where(a => a.MaBan == "14").FirstOrDefault();
            txtban.Text = Ban.MaBan;
            dgvban.DataSource = (from a in _context.HoaDon
                                 join b in _context.Ban on a.MaBan equals b.MaBan
                                 join c in _context.Cthd on a.MaHd equals c.MaHd
                                 where b.MaBan == Ban.MaBan && b.TinhTrang == 1 && a.TinhTrang == 0
                                 select new
                                 {
                                     c.MaMonAn,
                                     c.SoLuong,
                                     c.DonGia
                                 }).ToList();
            if (Ban.TinhTrang == 0)
            {
                btnThanhtoan.Visible = false;
            }
            else
            {
                btnThanhtoan.Visible = true;
            }
        }

        private void ban15_Click(object sender, EventArgs e)
        {
            var Ban = _context.Ban.Where(a => a.MaBan == "15").FirstOrDefault();
            txtban.Text = Ban.MaBan;
            dgvban.DataSource = (from a in _context.HoaDon
                                 join b in _context.Ban on a.MaBan equals b.MaBan
                                 join c in _context.Cthd on a.MaHd equals c.MaHd
                                 where b.MaBan == Ban.MaBan && b.TinhTrang == 1 && a.TinhTrang == 0
                                 select new
                                 {
                                     c.MaMonAn,
                                     c.SoLuong,
                                     c.DonGia
                                 }).ToList();
            if (Ban.TinhTrang == 0)
            {
                btnThanhtoan.Visible = false;
            }
            else
            {
                btnThanhtoan.Visible = true;
            }
        }

        private void ban16_Click(object sender, EventArgs e)
        {

            var Ban = _context.Ban.Where(a => a.MaBan == "16").FirstOrDefault();
            txtban.Text = Ban.MaBan;
            dgvban.DataSource = (from a in _context.HoaDon
                                 join b in _context.Ban on a.MaBan equals b.MaBan
                                 join c in _context.Cthd on a.MaHd equals c.MaHd
                                 where b.MaBan == Ban.MaBan && b.TinhTrang == 1 && a.TinhTrang == 0
                                 select new
                                 {
                                     c.MaMonAn,
                                     c.SoLuong,
                                     c.DonGia
                                 }).ToList();
            if (Ban.TinhTrang == 0)
            {
                btnThanhtoan.Visible = false;
            }
            else
            {
                btnThanhtoan.Visible = true;
            }
        }

        private void ban17_Click(object sender, EventArgs e)
        {
            var Ban = _context.Ban.Where(a => a.MaBan == "17").FirstOrDefault();
            txtban.Text = Ban.MaBan;
            dgvban.DataSource = (from a in _context.HoaDon
                                 join b in _context.Ban on a.MaBan equals b.MaBan
                                 join c in _context.Cthd on a.MaHd equals c.MaHd
                                 where b.MaBan == Ban.MaBan && b.TinhTrang == 1 && a.TinhTrang == 0
                                 select new
                                 {
                                     c.MaMonAn,
                                     c.SoLuong,
                                     c.DonGia
                                 }).ToList();
            if (Ban.TinhTrang == 0)
            {
                btnThanhtoan.Visible = false;
            }
            else
            {
                btnThanhtoan.Visible = true;
            }
        }

        private void ban18_Click(object sender, EventArgs e)
        {
            var Ban = _context.Ban.Where(a => a.MaBan == "18").FirstOrDefault();
            txtban.Text = Ban.MaBan;
            dgvban.DataSource = (from a in _context.HoaDon
                                 join b in _context.Ban on a.MaBan equals b.MaBan
                                 join c in _context.Cthd on a.MaHd equals c.MaHd
                                 where b.MaBan == Ban.MaBan && b.TinhTrang == 1 && a.TinhTrang == 0
                                 select new
                                 {
                                     c.MaMonAn,
                                     c.SoLuong,
                                     c.DonGia
                                 }).ToList();
            if (Ban.TinhTrang == 0)
            {
                btnThanhtoan.Visible = false;
            }
            else
            {
                btnThanhtoan.Visible = true;
            }
        }

        private void ban19_Click(object sender, EventArgs e)
        {
            var Ban = _context.Ban.Where(a => a.MaBan == "19").FirstOrDefault();
            txtban.Text = Ban.MaBan;
            dgvban.DataSource = (from a in _context.HoaDon
                                 join b in _context.Ban on a.MaBan equals b.MaBan
                                 join c in _context.Cthd on a.MaHd equals c.MaHd
                                 where b.MaBan == Ban.MaBan && b.TinhTrang == 1 && a.TinhTrang == 0
                                 select new
                                 {
                                     c.MaMonAn,
                                     c.SoLuong,
                                     c.DonGia
                                 }).ToList();
            if (Ban.TinhTrang == 0)
            {
                btnThanhtoan.Visible = false;
            }
            else
            {
                btnThanhtoan.Visible = true;
            }
        }

        private void ban20_Click(object sender, EventArgs e)
        {
            var Ban = _context.Ban.Where(a => a.MaBan == "20").FirstOrDefault();
            txtban.Text = Ban.MaBan;
            dgvban.DataSource = (from a in _context.HoaDon
                                 join b in _context.Ban on a.MaBan equals b.MaBan
                                 join c in _context.Cthd on a.MaHd equals c.MaHd
                                 where b.MaBan == Ban.MaBan && b.TinhTrang == 1 && a.TinhTrang == 0
                                 select new
                                 {
                                     c.MaMonAn,
                                     c.SoLuong,
                                     c.DonGia
                                 }).ToList();
            if (Ban.TinhTrang == 0)
            {
                btnThanhtoan.Visible = false;
            }
            else
            {
                btnThanhtoan.Visible = true;
            }
        }

        private void ban21_Click(object sender, EventArgs e)
        {
            var Ban = _context.Ban.Where(a => a.MaBan == "21").FirstOrDefault();
            txtban.Text = Ban.MaBan;
            dgvban.DataSource = (from a in _context.HoaDon
                                 join b in _context.Ban on a.MaBan equals b.MaBan
                                 join c in _context.Cthd on a.MaHd equals c.MaHd
                                 where b.MaBan == Ban.MaBan && b.TinhTrang == 1 && a.TinhTrang == 0
                                 select new
                                 {
                                     c.MaMonAn,
                                     c.SoLuong,
                                     c.DonGia
                                 }).ToList();
            if (Ban.TinhTrang == 0)
            {
                btnThanhtoan.Visible = false;
            }
            else
            {
                btnThanhtoan.Visible = true;
            }
        }

        private void ban22_Click(object sender, EventArgs e)
        {
            var Ban = _context.Ban.Where(a => a.MaBan == "22").FirstOrDefault();
            txtban.Text = Ban.MaBan;
            dgvban.DataSource = (from a in _context.HoaDon
                                 join b in _context.Ban on a.MaBan equals b.MaBan
                                 join c in _context.Cthd on a.MaHd equals c.MaHd
                                 where b.MaBan == Ban.MaBan && b.TinhTrang == 1 && a.TinhTrang == 0
                                 select new
                                 {
                                     c.MaMonAn,
                                     c.SoLuong,
                                     c.DonGia
                                 }).ToList();
            if (Ban.TinhTrang == 0)
            {
                btnThanhtoan.Visible = false;
            }
            else
            {
                btnThanhtoan.Visible = true;
            }
        }

        private void ban23_Click(object sender, EventArgs e)
        {
            var Ban = _context.Ban.Where(a => a.MaBan == "23").FirstOrDefault();
            txtban.Text = Ban.MaBan;
            dgvban.DataSource = (from a in _context.HoaDon
                                 join b in _context.Ban on a.MaBan equals b.MaBan
                                 join c in _context.Cthd on a.MaHd equals c.MaHd
                                 where b.MaBan == Ban.MaBan && b.TinhTrang == 1 && a.TinhTrang == 0
                                 select new
                                 {
                                     c.MaMonAn,
                                     c.SoLuong,
                                     c.DonGia
                                 }).ToList();
            if (Ban.TinhTrang == 0)
            {
                btnThanhtoan.Visible = false;
            }
            else
            {
                btnThanhtoan.Visible = true;
            }
        }

        private void ban24_Click(object sender, EventArgs e)
        {
            var Ban = _context.Ban.Where(a => a.MaBan == "24").FirstOrDefault();
            txtban.Text = Ban.MaBan;
            dgvban.DataSource = (from a in _context.HoaDon
                                 join b in _context.Ban on a.MaBan equals b.MaBan
                                 join c in _context.Cthd on a.MaHd equals c.MaHd
                                 where b.MaBan == Ban.MaBan && b.TinhTrang == 1 && a.TinhTrang == 0
                                 select new
                                 {
                                     c.MaMonAn,
                                     c.SoLuong,
                                     c.DonGia
                                 }).ToList();
            if (Ban.TinhTrang == 0)
            {
                btnThanhtoan.Visible = false;
            }
            else
            {
                btnThanhtoan.Visible = true;
            }
        }

        private void ban25_Click(object sender, EventArgs e)
        {
            var Ban = _context.Ban.Where(a => a.MaBan == "25").FirstOrDefault();
            txtban.Text = Ban.MaBan;
            dgvban.DataSource = (from a in _context.HoaDon
                                 join b in _context.Ban on a.MaBan equals b.MaBan
                                 join c in _context.Cthd on a.MaHd equals c.MaHd
                                 where b.MaBan == Ban.MaBan && b.TinhTrang == 1 && a.TinhTrang == 0
                                 select new
                                 {
                                     c.MaMonAn,
                                     c.SoLuong,
                                     c.DonGia
                                 }).ToList();
            if (Ban.TinhTrang == 0)
            {
                btnThanhtoan.Visible = false;
            }
            else
            {
                btnThanhtoan.Visible = true;
            }
        }
        public void LoaddgvBan()
        {
            var maBan = txtban.Text;
            dgvban.DataSource = (from a in _context.HoaDon
                                 join b in _context.Ban on a.MaBan equals b.MaBan
                                 join c in _context.Cthd on a.MaHd equals c.MaHd
                                 where b.MaBan == maBan && b.TinhTrang == 1 && a.TinhTrang == 0
                                 select new
                                 {
                                     c.MaMonAn,
                                     c.SoLuong,
                                     c.DonGia
                                 }).ToList();
        }
        private void btntimkiem_Click(object sender, EventArgs e)
        {
            string strTen = cbbloaithucdon.SelectedValue.ToString();
            dgvmonan.DataSource = (from a in _context.MonAn
                                   join b in _context.LoaiMonAn on a.MaLoai equals b.MaLoai
                                   where b.MaLoai == strTen
                                   select new
                                   {
                                       a.MaMonAn,
                                       a.TenMon,
                                       a.DonGia,
                                       a.Dvt,
                                       b.TenLoai
                                   }).ToList();
        }

        public void loadloaithucdonlenmonan()
        {
            cbbloaithucdon.DataSource = (from a in _context.LoaiMonAn select new { a.MaLoai, a.TenLoai }).ToList();
            cbbloaithucdon.DisplayMember = "TenLoai";
            cbbloaithucdon.ValueMember = "MaLoai";
        }
        public void loadthucdongoimon()
        {
            string strSQL = "select ThucDon.MaTD, ThucDon.TenTD, ThucDon.DonGia, LoaiThucDon.TenLoai from ThucDon, LoaiThucDon where ThucDon.MaLoai = LoaiThucDon.MaLoai";
            dgvmonan.DataSource = FillDataTable(strSQL);
        }

        private object FillDataTable(string strSQL)
        {
            throw new NotImplementedException();
        }

        private void cbbloaithucdon_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnChuyenban_Click(object sender, EventArgs e)
        {

        }

        private void btnThanhtoan_Click(object sender, EventArgs e)
        {

        }

        private void txtban_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
