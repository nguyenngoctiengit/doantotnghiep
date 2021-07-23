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
    public partial class FrmThanhtoan : Form
    {
        public NhaHangContext _context = new NhaHangContext();
        fmMenuMainAdmin fmMenuMain;
        public FrmThanhtoan(fmMenuMainAdmin fmMenuMainAdmin)
        {
            InitializeComponent();
            this.fmMenuMain = fmMenuMainAdmin;
        }

        public void Loadlb()
        {
            var mahoadon = fmMenuMainAdmin.MaHoadon.ToString();
            var MaHD = int.Parse(mahoadon);
            this.lbMaBan.Text = (from a in _context.HoaDon where a.MaHd == MaHD select a.MaBan).FirstOrDefault();
        }
        public void LoadPTT()
        {
            var mahoadon = fmMenuMainAdmin.MaHoadon.ToString();
            var MaHD = int.Parse(mahoadon);
            var hoadon = (from a in _context.HoaDon where a.MaHd == MaHD select a).FirstOrDefault();
            this.txtMaBan.Text = hoadon.MaBan;
            this.txtMaHD.Text = hoadon.MaHd.ToString();
            this.txtMaNV.Text = (from a in _context.NhanVien where a.MaNv == hoadon.MaNv select a.TenNv).FirstOrDefault();
            this.txtTongTien.Text = hoadon.TongTien.ToString();
            this.dtpNgaytao.Text = hoadon.NgayLap.ToString();
        }
        public void LoadDgvMonAn()
        {
            var mahoadon = fmMenuMainAdmin.MaHoadon.ToString();
            var MaHD = int.Parse(mahoadon);
            var hoadon = (from a in _context.HoaDon where a.MaHd == MaHD select a).FirstOrDefault();
            dgvMonAn.DataSource = (from a in _context.Cthd
                                   where a.MaHd == hoadon.MaHd
                                   select new
                                   {
                                       a.MaCTHD,
                                       a.MaMonAn,
                                       a.DonGia
                                   }).ToList();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            Loadlb();
            LoadPTT();
            LoadDgvMonAn();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var mahoadon = fmMenuMainAdmin.MaHoadon.ToString();
            var MaHD = int.Parse(mahoadon);
            var hoadon = (from a in _context.HoaDon where a.MaHd == MaHD select a).FirstOrDefault();
            hoadon.TinhTrang = 1;
            var ban = (from a in _context.Ban where a.MaBan == hoadon.MaBan select a).FirstOrDefault();
            ban.TinhTrang = 0;
            _context.HoaDon.Update(hoadon);
            _context.Ban.Update(ban);
            _context.SaveChanges();
            fmMenuMain.LoaddsBantrong();

            fmMenuMain.LoaddsBanconguoi();
            MessageBox.Show("Thanh toán thành công", "Thông Báo");
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }
        Bitmap bitmap;
        private void btnPrint_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            bitmap = new Bitmap(this.Size.Width, this.Size.Height, g);
            Graphics mg = Graphics.FromImage(bitmap);
            mg.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, this.Size);
            printPreviewDialog1.ShowDialog();
        }
    }
}
