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
    public partial class Dangki : Form
    {
        public Dangki()
        {
            InitializeComponent();
        }
        SqlConnection cnn;
        SqlCommand cmd;
        void dinhdangday()
        {
            if (cnn.State == ConnectionState.Closed)
                cnn.Open();
            string lenhsql = "set dateformat dmy";
            cmd = new SqlCommand(lenhsql, cnn);
            cmd.ExecuteNonQuery();
        }
        void ConnectDB()
        {
            string strDB = @"Data Source=.;Initial Catalog=doan;Integrated Security=True";
            //"Data Source=LAPTOP-MLQE6E90\\SQLEXPRESS;Initial Catalog=QuanLyNH;Integrated Security=True";   
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
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.ToString() == textBox3.Text.ToString())
            {
                try
                {
                    ConnectDB();
                    dinhdangday();
                    string strSQL = System.String.Concat("Insert Into TaiKhoan Values (N'" +
                    this.textBox1.Text.ToString() + "',N'" +
                    this.textBox2.Text.ToString() + "',N'" +
                    this.comboBox1.Text.ToString() + "','" +
                    this.dateTimePicker1.Text.ToString() + "')");

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cnn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    DisconnectDB();

                    MessageBox.Show(" Đăng ký thành công \n\n Vui lòng Reload lại dữ liệu ", "Thông Báo");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Tài khoản đã tồn tại", "Thông Báo");
                }
            }
            else
            {
                MessageBox.Show("Nhập lại mật khẩu chưa đúng", "Thông Báo");
            }
        }
        private void Dangki_Load(object sender, EventArgs e)
        {

        }
    }
}
