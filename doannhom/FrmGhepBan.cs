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
    public partial class FrmGhepBan : Form
    {
        public NhaHangContext _context = new NhaHangContext();
   
        fmMenuMainAdmin fmMenuMain;
        FrMenuNV FrMenunv;
        public FrmGhepBan(fmMenuMainAdmin fmMenuMainAdmin, FrMenuNV frMenuNV)
        {
            InitializeComponent();
            this.fmMenuMain = fmMenuMainAdmin;
            this.FrMenunv = frMenuNV;



        }
        private void FrmGhepBan_Load(object sender, EventArgs e)
        {
            Loadban1();
            Loadban2();
            LoadbanTrong();
            LoadNV();
        }
        public void LoadNV()
        {
            cbbNV.DataSource = (from a in _context.NhanVien select new { a.MaNv, a.TenNv }).ToList();
            cbbNV.ValueMember = "MaNv";
            cbbNV.DisplayMember = "TenNv";
        }
        public void Loadban1()
        {
            cbbBan1.DataSource = _context.Ban.Where(a => a.TinhTrang == 1).Select(a => a.MaBan).ToList();
        }
        public void Loadban2()
        {
            cbbBan2.DataSource = _context.Ban.Where(a => a.TinhTrang == 1).Select(a => a.MaBan).ToList();
        }
        public void LoadbanTrong()
        {
            cbbBanTrong.DataSource = _context.Ban.Where(a => a.TinhTrang == 0).Select(a => a.MaBan).ToList();
        }
        private void btnGopBan_Click(object sender, EventArgs e)
        {
            var maBan1 = cbbBan1.SelectedValue.ToString();
            var maBan2 = cbbBan2.SelectedValue.ToString();
            if (maBan1 == maBan2)
            {
                MessageBox.Show("Vui lòng chọn bàn cần ghép khác nhau", "Thông Báo");
            }
            else
            {
                if (FrMenuNV.MaHoadon == 0)
                {
                    var mahoadon = fmMenuMainAdmin.MaHoadon.ToString();
                    var maBanTrong = cbbBanTrong.SelectedValue.ToString();
                    var MahoaDonBan1 = _context.HoaDon.Where(a => a.MaBan == maBan1 && a.TinhTrang == 0).Max(a => a.MaHd);
                    var HoadonBan1 = _context.HoaDon.Where(a => a.MaHd == MahoaDonBan1).FirstOrDefault();
                    var CthdBan1 = _context.Cthd.Where(a => a.MaHd == HoadonBan1.MaHd).FirstOrDefault();
                    var MahoaDonBan2 = _context.HoaDon.Where(a => a.MaBan == maBan2 && a.TinhTrang == 0).Max(a => a.MaHd);
                    var HoadonBan2 = _context.HoaDon.Where(a => a.MaHd == MahoaDonBan2).FirstOrDefault();
                    var CthdBan2 = _context.Cthd.Where(a => a.MaHd == HoadonBan2.MaHd).FirstOrDefault();
                    HoaDon hd = new HoaDon();
                    var mahoadonmax = _context.HoaDon.OrderByDescending(a => a.MaHd).Select(a => a.MaHd).FirstOrDefault();
                    hd.MaHd = mahoadonmax + 1;
                    hd.MaBan = maBanTrong;
                    hd.NgayLap = DateTime.Now;
                    hd.TinhTrang = 0;
                    hd.MaNv = cbbNV.SelectedValue.ToString();
                    var bantrong = _context.Ban.Where(a => a.MaBan == maBanTrong).FirstOrDefault();
                    var ban1 = _context.Ban.Where(a => a.MaBan == maBan1).FirstOrDefault();
                    var ban2 = _context.Ban.Where(a => a.MaBan == maBan2).FirstOrDefault();
                    bantrong.TinhTrang = 1;
                    ban1.TinhTrang = 0;
                    ban2.TinhTrang = 0;
                    CthdBan1.MaHd = mahoadonmax + 1;
                    CthdBan2.MaHd = mahoadonmax + 1;
                    HoadonBan1.TinhTrang = 2;
                    HoadonBan2.TinhTrang = 2;
                    _context.Ban.Update(ban1);
                    _context.Ban.Update(ban2);
                    _context.Ban.Update(bantrong);
                    _context.HoaDon.Add(hd);
                    _context.Cthd.Update(CthdBan1);
                    _context.Cthd.Update(CthdBan2);
                    _context.HoaDon.Update(HoadonBan1);
                    _context.HoaDon.Update(HoadonBan2);
                    _context.SaveChanges();
                    FrMenunv.LoaddsBantrong();
                    FrMenunv.LoaddsBanconguoi();
                    FrMenunv.LoaddgvBan();

                }
                else if (FrMenuNV.MaHoadon != 0)
                {
                    var mahoadon = FrMenuNV.MaHoadon.ToString();
                    var maBanTrong = cbbBanTrong.SelectedValue.ToString();
                    var MahoaDonBan1 = _context.HoaDon.Where(a => a.MaBan == maBan1 && a.TinhTrang == 0).Max(a => a.MaHd);
                    var HoadonBan1 = _context.HoaDon.Where(a => a.MaHd == MahoaDonBan1).FirstOrDefault();
                    var CthdBan1 = _context.Cthd.Where(a => a.MaHd == HoadonBan1.MaHd).FirstOrDefault();
                    var MahoaDonBan2 = _context.HoaDon.Where(a => a.MaBan == maBan2 && a.TinhTrang == 0).Max(a => a.MaHd);
                    var HoadonBan2 = _context.HoaDon.Where(a => a.MaHd == MahoaDonBan2).FirstOrDefault();
                    var CthdBan2 = _context.Cthd.Where(a => a.MaHd == HoadonBan2.MaHd).FirstOrDefault();
                    HoaDon hd = new HoaDon();
                    var mahoadonmax = _context.HoaDon.OrderByDescending(a => a.MaHd).Select(a => a.MaHd).FirstOrDefault();
                    hd.MaHd = mahoadonmax + 1;
                    hd.MaBan = maBanTrong;
                    hd.NgayLap = DateTime.Now;
                    hd.TinhTrang = 0;
                    hd.MaNv = cbbNV.SelectedValue.ToString();
                    var bantrong = _context.Ban.Where(a => a.MaBan == maBanTrong).FirstOrDefault();
                    var ban1 = _context.Ban.Where(a => a.MaBan == maBan1).FirstOrDefault();
                    var ban2 = _context.Ban.Where(a => a.MaBan == maBan2).FirstOrDefault();
                    bantrong.TinhTrang = 1;
                    ban1.TinhTrang = 0;
                    ban2.TinhTrang = 0;
                    CthdBan1.MaHd = mahoadonmax + 1;
                    CthdBan2.MaHd = mahoadonmax + 1;
                    HoadonBan1.TinhTrang = 2;
                    HoadonBan2.TinhTrang = 2;
                    _context.Ban.Update(ban1);
                    _context.Ban.Update(ban2);
                    _context.Ban.Update(bantrong);
                    _context.HoaDon.Add(hd);
                    _context.Cthd.Update(CthdBan1);
                    _context.Cthd.Update(CthdBan2);
                    _context.HoaDon.Update(HoadonBan1);
                    _context.HoaDon.Update(HoadonBan2);
                    _context.SaveChanges();
                    fmMenuMain.LoaddsBantrong();
                    fmMenuMain.LoaddsBanconguoi();
                    fmMenuMain.LoadThanhToan();
                    fmMenuMain.LoaddgvBan();
                  
                    
                }
                MessageBox.Show("Ghép bàn thành công", "Thông Báo");

                this.Close();
            }
        }
        private void cbbBan1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
    }
}
