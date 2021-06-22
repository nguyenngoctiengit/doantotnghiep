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
    public partial class phanhoiadmin : Form
    {
        public phanhoiadmin()
        {
            InitializeComponent();
        }
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
        public void LoadData()
        {
            string strSQL = "select * from phanhoi";
            dataGridView1.DataSource = FillDataTable(strSQL);
        }
        private void phanhoiadmin_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Đã xử lý")
            {
                string strSQL = "select * from phanhoi where tinhtrang= N'Đã xử lý'";
                dataGridView1.DataSource = FillDataTable(strSQL);
            }
            if (comboBox1.Text == "Chưa xử lý")
            {
                string strSQL = "select * from phanhoi where tinhtrang= N'Chưa xử lý'";
                dataGridView1.DataSource = FillDataTable(strSQL);
            }
            if (comboBox1.Text == "Góp ý")
            {
                string strSQL = "select * from phanhoi where hinhthuc= N'Góp ý'";
                dataGridView1.DataSource = FillDataTable(strSQL);
            }
            if (comboBox1.Text == "Khiếu nại nhân viên")
            {
                string strSQL = "select * from phanhoi where hinhthuc= N'Khiếu nại nhân viên'";
                dataGridView1.DataSource = FillDataTable(strSQL);
            }
            if (comboBox1.Text == "Khiếu nại khách hàng")
            {
                string strSQL = "select * from phanhoi where hinhthuc= N'Khiếu nại khách hàng'";
                dataGridView1.DataSource = FillDataTable(strSQL);
            }
            if (comboBox1.Text == "Đánh giá nhân viên")
            {
                string strSQL = "select * from phanhoi where hinhthuc= N'Đánh giá nhân viên'";
                dataGridView1.DataSource = FillDataTable(strSQL);
            }
            
        }
        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.ResetText();
            comboBox1.ResetText();
            LoadData();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ConnectDB();
            try
            {
                int r = dataGridView1.CurrentCell.RowIndex;

                string strMaKH = dataGridView1.Rows[r].Cells[0].Value.ToString();

                string strSQL = System.String.Concat("Update phanhoi Set tinhtrang=N'đã xử lý' Where stt='" + strMaKH + "'");

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL;
                cmd.ExecuteNonQuery();

                LoadData();

                DisconnectDB();

                MessageBox.Show("Xử lý thành công", "Thông Báo");
            }
            catch (SqlException)
            {
                MessageBox.Show("Lỗi, vui lòng kiểm tra lại", "Thông Báo");
            }
        }
    }
}
