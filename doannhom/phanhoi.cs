using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace doannhom
{
    public partial class phanhoi : Form
    {
        public phanhoi()
        {
            InitializeComponent();
        }
        SqlCommand cmd;
        SqlConnection cnn;
        void ConnectDB()
        {
            string strDB = @"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=doan;Integrated Security=True";
            cnn = new SqlConnection(strDB);
            cnn.Open();
        }
        void DisconnectDB()
        {
            cnn.Close();
        }
        DataTable FillDataTable(string strQuery)
        {
            ConnectDB();
            DataTable dataTable = new DataTable();
            try
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(strQuery, cnn);
                sqlDataAdapter.Fill(dataTable);
                sqlDataAdapter.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            DisconnectDB();
            return dataTable;
        }
        void dinhdangday()
        {
            if (cnn.State == ConnectionState.Closed)
                cnn.Open();
            string lenhsql = "set dateformat dmy";
            cmd = new SqlCommand(lenhsql, cnn);
            cmd.ExecuteNonQuery();
        }
        public void reload()
        {
            txthoten.ResetText();
            txthoten.Focus();
            txthinhthuc.ResetText();
            txtsdt.ResetText();
            txtnoidung.ResetText();
            txtemail.ResetText();
            cbmnv.ResetText();
            cbmkh.ResetText();
        }
        public void loadnhanvien()
        {
            string strSQL = "select * from NhanVien";
            cbmnv.DataSource = FillDataTable(strSQL);
            cbmnv.DisplayMember = "MaNV";
            cbmnv.ValueMember = "MaNV";
            cnn.Close();
        }
        public void loadkhachhang()
        {
            string strSQL = "select * from KhachHang";
            cbmkh.DataSource = FillDataTable(strSQL);
            cbmkh.DisplayMember = "MaKH";
            cbmkh.ValueMember = "MaKH";
            cnn.Close();
        }
        private void khiếuNạiNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txthinhthuc.Text = "Khiếu nại nhân viên";
            panel1.Show();
            cbmkh.Enabled = false;
            cbmnv.Enabled = true;
        }
        private void khiếuNạiKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txthinhthuc.Text = "Khiếu nại khách hàng";
            panel1.Show();
            cbmnv.Enabled = false;
            cbmkh.Enabled = true;
        }
        private void đánhGiáNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txthinhthuc.Text = "Đánh giá nhân viên";
            panel1.Show();
            cbmkh.Enabled = false;
            cbmnv.Enabled = true;
        }
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            txthinhthuc.Text = "Góp ý";
            panel1.Hide();
        }
        private void phanhoi_Load(object sender, EventArgs e)
        {
            loadnhanvien();
            loadkhachhang(); reload();
        }
        private void btnphanhoi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txthoten.Text))
            {
                MessageBox.Show("Vui lòng nhập tên của bạn", "Thông Báo");
            }
            if (string.IsNullOrEmpty(txtemail.Text))
            {
                MessageBox.Show("Vui lòng nhập email của bạn", "Thông Báo");
            }
            if (string.IsNullOrEmpty(txtsdt.Text))
            {
                MessageBox.Show("Vui lòng nhập sdt của bạn", "Thông Báo");
            }
            else
            {
                if (string.IsNullOrEmpty(txthinhthuc.Text))
                {
                    MessageBox.Show("Vui lòng chọn hình thức", "Thông Báo");
                }
                else
                {
                    if (txthinhthuc.Text == "Khiếu nại nhân viên")
                    {
                        ConnectDB();
                        try
                        {
                            dinhdangday();
                            DateTime ngaylap = Convert.ToDateTime(dateTimePicker1.Value.ToString("dd/MM/yyyy"));
                            string strSQL = System.String.Concat("INSERT INTO [doanchuyennganh].[dbo].[phanhoi]([HoTen],[SDT],[Email],[MaNV],[Hinhthuc],[NoiDung],[NgayLap],[TinhTrang])VALUES(N'" +
                                txthoten.Text.ToString() + "'," + txtsdt.Text.ToString() + ",N'" +
                                txtemail.Text.ToString() + "',N'" + cbmnv.Text.ToString() + "',N'" +
                                txthinhthuc.Text.ToString() + "',N'" + txtnoidung.Text.ToString() +
                                "','" + dateTimePicker1.Text.ToString() + "',N'chưa xử lý')");

                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = cnn;
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = strSQL;
                            cmd.ExecuteNonQuery();

                            reload();
                            DisconnectDB();
                            MessageBox.Show("Hệ thống tiếp nhận yêu cầu của bạn và sẻ thông báo cho bạn khi đã xử lý xong", "Thông Báo");
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                    if (txthinhthuc.Text == "Khiếu nại khách hàng")
                    {
                        ConnectDB();
                        try
                        {
                            dinhdangday();
                            DateTime ngaylap = Convert.ToDateTime(dateTimePicker1.Value.ToString("dd/MM/yyyy"));
                            string strSQL = System.String.Concat("INSERT INTO [doanchuyennganh].[dbo].[phanhoi]([HoTen],[SDT],[Email],[MaKH],[Hinhthuc],[NoiDung],[NgayLap],[TinhTrang])VALUES(N'" +
                                txthoten.Text.ToString() + "'," + txtsdt.Text.ToString() + ",N'" +
                                txtemail.Text.ToString() + "',N'" + cbmkh.Text.ToString() + "',N'" +
                                txthinhthuc.Text.ToString() + "',N'" + txtnoidung.Text.ToString() +
                                "','" + dateTimePicker1.Text.ToString() + "',N'chưa xử lý')");

                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = cnn;
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = strSQL;
                            cmd.ExecuteNonQuery();

                            reload();
                            DisconnectDB();
                            MessageBox.Show("Hệ thống tiếp nhận yêu cầu của bạn và sẻ thông báo cho bạn khi đã xử lý xong", "Thông Báo");
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                    if (txthinhthuc.Text == "Đánh giá nhân viên")
                    {
                        ConnectDB();
                        try
                        {
                            dinhdangday();
                            DateTime ngaylap = Convert.ToDateTime(dateTimePicker1.Value.ToString("dd/MM/yyyy"));
                            string strSQL = System.String.Concat("INSERT INTO [doanchuyennganh].[dbo].[phanhoi]([HoTen],[SDT],[Email],[MaNV],[Hinhthuc],[NoiDung],[NgayLap],[TinhTrang])VALUES(N'" +
                                txthoten.Text.ToString() + "'," + txtsdt.Text.ToString() + ",N'" +
                                txtemail.Text.ToString() + "',N'" + cbmnv.Text.ToString() + "',N'" +
                                txthinhthuc.Text.ToString() + "',N'" + txtnoidung.Text.ToString() +
                                "','" + dateTimePicker1.Text.ToString() + "',N'chưa xử lý')");

                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = cnn;
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = strSQL;
                            cmd.ExecuteNonQuery();

                            reload();
                            DisconnectDB();
                            MessageBox.Show("Hệ thống tiếp nhận yêu cầu của bạn và sẻ thông báo cho bạn khi đã xử lý xong", "Thông Báo");
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                    if (txthinhthuc.Text == "Góp ý")
                    {
                        ConnectDB();
                        try
                        {
                            dinhdangday();
                            DateTime ngaylap = Convert.ToDateTime(dateTimePicker1.Value.ToString("dd/MM/yyyy"));
                            string strSQL = System.String.Concat("INSERT INTO [doanchuyennganh].[dbo].[phanhoi]([HoTen],[SDT],[Email],[Hinhthuc],[NoiDung],[NgayLap],[TinhTrang])VALUES(N'" +
                                txthoten.Text.ToString() + "'," + txtsdt.Text.ToString() + ",N'" +
                                txtemail.Text.ToString() + "',N'" +
                                txthinhthuc.Text.ToString() + "',N'" + txtnoidung.Text.ToString() +
                                "','" + dateTimePicker1.Text.ToString() + "',N'chưa xử lý')");

                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = cnn;
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = strSQL;
                            cmd.ExecuteNonQuery();

                            reload();
                            DisconnectDB();
                            MessageBox.Show("Hệ thống tiếp nhận yêu cầu của bạn và sẻ thông báo cho bạn khi đã xử lý xong", "Thông Báo");
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                }                
            }
        }
    }
}
