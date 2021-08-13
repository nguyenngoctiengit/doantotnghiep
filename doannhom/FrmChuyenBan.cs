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
    public partial class FrmChuyenBan : Form
    {
        public NhaHangContext _context = new NhaHangContext();
        fmMenuMainAdmin fmMenuMain;
        FrMenuNV FrMenunv;
        public FrmChuyenBan(fmMenuMainAdmin fmMenuMainAdmin,FrMenuNV frMenuNV)
        {
            InitializeComponent();
            this.fmMenuMain = fmMenuMainAdmin;
            this.FrMenunv = frMenuNV;
            
        }

        private void FrmChuyenBan_Load(object sender, EventArgs e)
        {
            LoadCbbBanconguoi();
            LoadCbbBantrong();
        }

        public void LoadCbbBanconguoi()
        {
            cbbBanconguoi.DataSource = (from a in _context.Ban where a.TinhTrang == 1 select a.MaBan).ToList();
        }
        public void LoadCbbBantrong()
        {
            cbbBantrong.DataSource = (from a in _context.Ban where a.TinhTrang == 0 select a.MaBan).ToList();
        }
        private void btnChuyen_Click(object sender, EventArgs e)
        {
            if (FrMenuNV.MaHoadon == 0)
            {
                var mahoadon = fmMenuMainAdmin.MaHoadon.ToString();
                var MaBanChuyen = cbbBanconguoi.SelectedValue.ToString();
                var MaHoadon = (from a in _context.HoaDon where a.MaBan == MaBanChuyen select a).Max(a => a.MaHd);
                var HoaDon = _context.HoaDon.Where(a => a.MaHd == MaHoadon).FirstOrDefault();
                var MaBanTrong = cbbBantrong.SelectedValue.ToString();
                HoaDon.MaBan = MaBanTrong;
                _context.HoaDon.Update(HoaDon);
                var banchuyen = _context.Ban.Where(a => a.MaBan == MaBanChuyen).FirstOrDefault();
                var bantrong = _context.Ban.Where(a => a.MaBan == MaBanTrong).FirstOrDefault();
                banchuyen.TinhTrang = 0;
                bantrong.TinhTrang = 1;
                _context.Ban.Update(banchuyen);
                _context.Ban.Update(bantrong);
                _context.SaveChanges();
                fmMenuMain.LoaddsBantrong();
                fmMenuMain.LoaddsBanconguoi();
                fmMenuMain.LoadThanhToan();
                fmMenuMain.LoaddgvBan();
                fmMenuMain.loadTinhTrangBan();
                fmMenuMain.loadTinhTrangHD();

            }
            else if(FrMenuNV.MaHoadon  != 0)
            {
                var mahoadon = FrMenuNV.MaHoadon.ToString();
                var MaBanChuyen = cbbBanconguoi.SelectedValue.ToString();
                var MaHoadon = (from a in _context.HoaDon where a.MaBan == MaBanChuyen select a).Max(a => a.MaHd);
                var HoaDon = _context.HoaDon.Where(a => a.MaHd == MaHoadon).FirstOrDefault();
                var MaBanTrong = cbbBantrong.SelectedValue.ToString();

                HoaDon.MaBan = MaBanTrong;
                _context.HoaDon.Update(HoaDon);
                var banchuyen = _context.Ban.Where(a => a.MaBan == MaBanChuyen).FirstOrDefault();
                var bantrong = _context.Ban.Where(a => a.MaBan == MaBanTrong).FirstOrDefault();
                banchuyen.TinhTrang = 0;
                bantrong.TinhTrang = 1;
                _context.Ban.Update(banchuyen);
                _context.Ban.Update(bantrong);
                _context.SaveChanges();
                fmMenuMain.LoaddsBantrong();
                fmMenuMain.LoaddsBanconguoi();
                fmMenuMain.LoadThanhToan();
                fmMenuMain.LoaddgvBan();
                
            }

            MessageBox.Show("Chuyển bàn thành công", "Thông Báo");
            this.Close();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
    }
}
