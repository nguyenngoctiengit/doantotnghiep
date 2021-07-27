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
    public partial class FrMenuNV : Form
    {
        fmMenuMainAdmin fmMenuMainAdmin;
        public static int MaHoadon;
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
/*        public void loadthucdongoimon()
        {
            string strSQL = "select ThucDon.MaTD, ThucDon.TenTD, ThucDon.DonGia, LoaiThucDon.TenLoai from ThucDon, LoaiThucDon where ThucDon.MaLoai = LoaiThucDon.MaLoai";
            dgvmonan.DataSource = fill
        }*/
        


        public void loadnhanvienohd()
        {
            cbbmanv.DataSource = (from a in _context.NhanVien select new { a.MaNv, a.TenNv }).ToList();
            cbbmanv.DisplayMember = "TenNv";
            cbbmanv.ValueMember = "MaNV";
        }
        public void LoaddsBanconguoi()
        {
            dgvBanconguoi.DataSource = (from a in _context.Ban where a.TinhTrang == 1 select new { a.MaBan, Trangthai = (a.TinhTrang == 0) ? "Trống" : "Có người" }).ToList();
        }
        public void LoaddsBantrong()
        {
            dgvBantrong.DataSource = (from a in _context.Ban where a.TinhTrang == 0 select new { a.MaBan, Trangthai = (a.TinhTrang == 0) ? "Trống" : "Có người" }).ToList();
        }

      //  DataTable FillDataTable(string strQuery)


        private void cbbloaithucdon_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnChuyenban_Click(object sender, EventArgs e)
        {
            FrmChuyenBan frmChuyenBan = new FrmChuyenBan(fmMenuMainAdmin ,this);
            frmChuyenBan.Show();
        }

        private void btnThanhtoan_Click(object sender, EventArgs e)
        {
            MaHoadon = (from a in _context.HoaDon where a.MaBan == this.txtban.Text && a.TinhTrang == 0 select a.MaHd).FirstOrDefault();
            FrmThanhtoan form2 = new FrmThanhtoan(fmMenuMainAdmin,this);
            var l = 0;
            form2.Show();
        }

        private void txtban_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvmonan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrMenuNV_Load(object sender, EventArgs e)
        {
            loadnhanvienohd();
            LoaddsBanconguoi();
            LoaddsBantrong();
            loadloaithucdonlenmonan();


        }

        private void cbbmanv_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e) //goi mon
        {
            try
            {

                var maBan = this.txtban.Text;
                var Ban = (from a in _context.Ban where a.MaBan == maBan select a).FirstOrDefault();
                /*               var mahd = (from a in _context.HoaDon where a.MaBan == maBan select a.MaHd).FirstOrDefault();*/
                var maHD = _context.HoaDon.OrderByDescending(a => a.MaHd).Where(a => a.MaBan == maBan).Select(a => a.MaHd).FirstOrDefault();
                var HD = (from a in _context.HoaDon where a.MaHd == maHD select a).FirstOrDefault();
                int r = dgvmonan.CurrentCell.RowIndex;

                if (r == 0)
                {
                    MessageBox.Show("Vui lòng chọn món ăn", "Thông Báo");
                }
                else
                {
                    var MaTD = dgvmonan.Rows[r].Cells[0];
                    var dongia = dgvmonan.Rows[r].Cells[2];
                    if (Ban.TinhTrang == 1 && _context.HoaDon.Any(a => a.MaBan == maBan) && HD.TinhTrang == 0)
                    {
                        var maHoadon = (from a in _context.HoaDon where a.MaBan == maBan select a).Max(a => a.MaHd);
                        var hoadon = (from a in _context.HoaDon where a.MaHd == maHoadon select a).FirstOrDefault();
                        var cthd = new Cthd();
                        cthd.MaHd = maHoadon;
                        var DonGia = (int)dongia.Value;
                        var mamonan = MaTD.Value.ToString();
                        cthd.MaMonAn = mamonan;
                        cthd.SoLuong = 1;
                        cthd.DonGia = DonGia;
                        var giatien = (from a in _context.HoaDon join b in _context.Cthd on a.MaHd equals b.MaHd where a.MaBan == maBan select b.DonGia).ToList();
                        hoadon.TongTien = giatien.Sum() + DonGia;
                        _context.HoaDon.Update(hoadon);
                        _context.Cthd.Add(cthd);
                        _context.SaveChanges();
                        LoaddsBantrong();
                        LoaddsBanconguoi();
                        LoaddgvBan();

                    }
                    else
                    {
                        var update_ban = (from a in _context.Ban where a.MaBan == this.txtban.Text select a).FirstOrDefault();
                        var mahoadonmax = _context.HoaDon.OrderByDescending(a => a.MaHd).Select(a => a.MaHd).FirstOrDefault();
                        var hoadon = new HoaDon();
                        var cthd = new Cthd();
                        hoadon.MaHd = mahoadonmax + 1;
                        var DonGia = (int)dongia.Value;
                        var mamonan = MaTD.Value.ToString();
                        hoadon.TinhTrang = 0;
                        hoadon.MaBan = this.txtban.Text.ToString();
                        hoadon.MaNv = this.cbbmanv.SelectedValue.ToString();
                        hoadon.NgayLap = DateTime.Now;
                        hoadon.TongTien = DonGia;
                        cthd.MaMonAn = mamonan;
                        cthd.SoLuong = 1;
                        cthd.DonGia = DonGia;
                        cthd.MaHd = hoadon.MaHd;
                        update_ban.TinhTrang = 1;
                        _context.Ban.Update(update_ban);
                        _context.HoaDon.Add(hoadon);
                        _context.Cthd.Add(cthd);
                        _context.SaveChanges();
                        btnThanhtoan.Visible = true;
                        LoaddsBantrong();
                        LoaddsBanconguoi();
                        LoaddgvBan();
                        MessageBox.Show("Gọi món thành công", "Thông Báo");
                    }
                }

            }
            catch (SqlException)
            {
                MessageBox.Show("Lỗi, vui lòng kiểm tra lại", "Thông Báo");
            }
        }

        private void button30_Click(object sender, EventArgs e)
        {
            var maBan = this.txtban.Text;
            var ban = (from a in _context.Ban where a.MaBan == maBan select a).FirstOrDefault();
            int mahoadon = (from a in _context.HoaDon where a.MaBan == maBan && a.TinhTrang == 0 select a).Max(a => a.MaHd);
            var hoadon = (from a in _context.HoaDon where a.MaHd == mahoadon select a).FirstOrDefault();
            if (maBan == "" || maBan == null)
            {
                MessageBox.Show("Vui lòng chọn bàn", "Thông Báo");
            }
            else if (ban.TinhTrang == 0)
            {
                MessageBox.Show("Bàn trống, không thể xóa", "Thông Báo");
            }
            else
            {

                int r = dgvban.CurrentCell.RowIndex;
                var MaTD = dgvban.Rows[r].Cells[0];
                var dongia = dgvban.Rows[r].Cells[2];
                var DonGia = (int)dongia.Value;

                hoadon.TongTien = hoadon.TongTien - DonGia;
                var mamonan = MaTD.Value.ToString();
                var item_delete = (from a in _context.Cthd where a.MaHd == hoadon.MaHd && a.MaMonAn == mamonan select a).FirstOrDefault();
                _context.Cthd.Remove(item_delete);
                _context.HoaDon.Update(hoadon);
                _context.SaveChanges();
                var count_cthd = _context.Cthd.Where(a => a.MaHd == hoadon.MaHd).Count();
                if (count_cthd == 0)
                {
                    var delete_hd = _context.HoaDon.Where(a => a.MaHd == hoadon.MaHd).FirstOrDefault();
                    ban.TinhTrang = 0;
                    _context.Ban.Update(ban);
                    _context.HoaDon.Remove(delete_hd);
                    _context.SaveChanges();
                    LoaddsBantrong();
                    LoaddsBanconguoi();
                    LoaddgvBan();
                }
                LoaddsBantrong();
                LoaddsBanconguoi();
                LoaddgvBan();
                MessageBox.Show("Xóa món ăn thành công", "Thông Báo");
            }
        }

        private void btnGhepban_Click(object sender, EventArgs e)
        {
            FrmGhepBan frmGhepBan = new FrmGhepBan(fmMenuMainAdmin,this);
            frmGhepBan.Show();
        }
    }
}
