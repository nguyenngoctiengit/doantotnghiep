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
        public Dangnhap()
        {
            InitializeComponent();
        }
        int counter = 0;
        int len = 0;
        string txt;
        private void button6_Click(object sender, EventArgs e)
        {
            Form frm = new Dangki();
            frm.ShowDialog();
        }
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
                
                SqlConnection conn = new SqlConnection(@"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=NhaHang;Integrated Security=True");
                string sqlselect = "Select * from TaiKhoan where TenTK = '" + txtUser.Text
                    + "' and MatKhau = '" + txtPass.Text
                    + "' and ChucVu = N'Nhân Viên'";
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlselect, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read() == true)
                {
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
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-GJ6UCAT;Initial Catalog=NhaHang;Integrated Security=True");
                string sqlselect = "Select * from TaiKhoan where TenTK = '" + txtUser.Text
                    + "' and MatKhau = '" + txtPass.Text
                    + "' and ChucVu = N'Quản Lý'";
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlselect, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read() == true)
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
