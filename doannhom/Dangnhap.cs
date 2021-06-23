using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using doannhom.Models;

namespace doannhom
{
    public partial class Dangnhap : Form
    {
        NhaHangContext _context = new NhaHangContext();
        public Dangnhap()
        {
            InitializeComponent();
        }
        int counter = 0;
        int len = 0;
        string txt;
        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có muốn thoát không? ", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
            {
                Application.Exit();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Vui lòng chọn chức vụ", "Thông Báo");
            }
            if (comboBox1.Text == "Nhân Viên")
            {
                var taikhoan = (from a in _context.TaiKhoan where a.ChucVu == "Nhân Viên" select a.TenTk).FirstOrDefault();
                var matkhau = (from a in _context.TaiKhoan where a.ChucVu == "Nhân Viên" select a.MatKhau).FirstOrDefault();
                if (taikhoan == txtUser.Text && matkhau == txtPass.Text){ 
                     this.Hide();
                    Form frm = new frMenuMain();
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Sai tên tài khoản và mật khẩu", "Thông Báo");
                }
            }
            if (comboBox1.Text == "Quản Lý")
            {
                var taikhoan = (from a in _context.TaiKhoan where a.ChucVu == "Quản Lý" select a.TenTk).FirstOrDefault();
                var matkhau = (from a in _context.TaiKhoan where a.ChucVu == "Quản Lý" select a.MatKhau).FirstOrDefault();
                if (taikhoan == txtUser.Text && matkhau == txtPass.Text)
                {
                    this.Hide();
                    Form frm = new fmMenuMainAdmin();
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Sai tên tài khoản và mật khẩu", "Thông Báo");
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            counter++;

            if (counter > len)
            {
                counter = 0;
                label31.Text = "";
            }

            else
            {

                label31.Text = txt.Substring(0, counter);

                if (label31.ForeColor == Color.Red)
                    label31.ForeColor = Color.DarkRed;
                else
                    label31.ForeColor = Color.Red;
            }
        }
        private void Dangnhap_Load(object sender, EventArgs e)
        {
            txt = label31.Text;
            len = txt.Length;
            label31.Text = "";
            timer1.Start();
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
