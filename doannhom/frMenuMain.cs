using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace doannhom
{
    public partial class frMenuMain : Form
    {
        SqlCommand cmd;
        public frMenuMain()
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
        void dinhdangday()
        {
            if (cnn.State == ConnectionState.Closed)
                cnn.Open();
            string lenhsql = "set dateformat dmy";
            cmd = new SqlCommand(lenhsql, cnn);
            cmd.ExecuteNonQuery();
        }
        void deleleban()
        {
            ConnectDB();
            int r = dgvban.CurrentCell.RowIndex;

            string strMaThucDon = dgvban.Rows[r].Cells[0].Value.ToString();

            string strSQL = System.String.Concat("Delete From bonhodem Where MaBan='" + comboBox3.Text.ToString() + "'");

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSQL;
            cmd.ExecuteNonQuery();

            ban();

            DisconnectDB();
        }
        void capnhatbantrong()
        {
            ConnectDB();

            string strSQL = System.String.Concat("Update Ban Set TinhTrang=N'TRỐNG' Where MaBan='" + comboBox3.Text.ToString() + "'");

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSQL;
            cmd.ExecuteNonQuery();

            ban();

            DisconnectDB();
        }
        private void dgvphancong_SelectionChanged_1(object sender, EventArgs e)
        {
            cbmaca.Text = Convert.ToString(dgvphancong.CurrentRow.Cells[0].Value);
            cbmanv.Text = Convert.ToString(dgvphancong.CurrentRow.Cells[1].Value);
            cbmaban.Text = Convert.ToString(dgvphancong.CurrentRow.Cells[2].Value);
            pcdaybd.Text = Convert.ToString(dgvphancong.CurrentRow.Cells[3].Value);
            pcdaykt.Text = Convert.ToString(dgvphancong.CurrentRow.Cells[4].Value);
        }
        private void button20_Click_1(object sender, EventArgs e)
        {
            Loadpc();
            Loadca();
            cbmaca.Focus();
            txtmaca.ResetText();
            txttenca.ResetText();
            txtluuy.ResetText();
            cbmaca.ResetText();
            cbmanv.ResetText();
            cbmaban.ResetText();
            pcdaybd.ResetText();
            pcdaykt.ResetText();
            txttkpcmc.ResetText();
            txttkpcmnv.ResetText();
        }
        private void dgvca_SelectionChanged_1(object sender, EventArgs e)
        {
            txtmaca.Text = Convert.ToString(dgvca.CurrentRow.Cells[0].Value);
            txttenca.Text = Convert.ToString(dgvca.CurrentRow.Cells[1].Value);
            txtluuy.Text = Convert.ToString(dgvca.CurrentRow.Cells[2].Value);
        }
        private void dgvban_SelectionChanged_1(object sender, EventArgs e)
        {
            txtmabangm.Text = Convert.ToString(dgvban.CurrentRow.Cells[0].Value);
            txttentdgm.Text = Convert.ToString(dgvban.CurrentRow.Cells[1].Value);
            txtsltdgm.Text = Convert.ToString(dgvban.CurrentRow.Cells[2].Value);
        }
        private void dgvmonan_SelectionChanged(object sender, EventArgs e)
        {
            tenthucdon.Text = Convert.ToString(dgvmonan.CurrentRow.Cells[1].Value);
            dongia.Text = Convert.ToString(dgvmonan.CurrentRow.Cells[2].Value);
        }
        private void dgvtongtien_SelectionChanged(object sender, EventArgs e)
        {
            txttongtienban.Text = Convert.ToString(dgvtongtien.CurrentRow.Cells[0].Value);
        }
        //Load Data từng tab
        public void Loadpc()
        {
            string strSQL = "select * from PhanCong";
            dgvphancong.DataSource = FillDataTable(strSQL);
            gbtkpc.Hide();
        }
        public void Loadca()
        {
            string strSQL = "select * from Ca";
            dgvca.DataSource = FillDataTable(strSQL);
        }
        public void loadmacaphancongtuca()
        {
            string strSQL = "select * from Ca";
            cbmaca.DataSource = FillDataTable(strSQL);
            cbmaca.DisplayMember = "MaCa";
            cbmaca.ValueMember = "MaCa";
            cnn.Close();
        }
        public void loadmanvphancongtunhanvien()
        {
            string strSQL = "select * from NhanVien";
            cbmanv.DataSource = FillDataTable(strSQL);
            cbmanv.DisplayMember = "MaNV";
            cbmanv.ValueMember = "MaNV";
            cnn.Close();
        }
        public void loadmabanphancongtuban()
        {
            string strSQL = "select * from Ban";
            cbmaban.DataSource = FillDataTable(strSQL);
            cbmaban.DisplayMember = "MaBan";
            cbmaban.ValueMember = "MaBan";
            cnn.Close();
        }
        public void loadloaithucdonlenmonan()
        {
            string strSQL = "select * from LoaiThucDon";
            comboBox1.DataSource = FillDataTable(strSQL);
            comboBox1.DisplayMember = "TenLoai";
            comboBox1.ValueMember = "MaLoai";
            cnn.Close();
        }
        public void loadmabanvaocb()
        {
            string strSQL = "select * from Ban";
            comboBox3.DataSource = FillDataTable(strSQL);
            comboBox3.DisplayMember = "MaBan";
            comboBox3.ValueMember = "MaBan";
            cnn.Close();
        }
        public void loadnhanvienohd()
        {
            string strSQL = "select * from NhanVien";
            comboBox4.DataSource = FillDataTable(strSQL);
            comboBox4.DisplayMember = "MaNV";
            comboBox4.ValueMember = "MaNV";
            cnn.Close();
        }
        public void loadkhachhangnohd()
        {
            string strSQL = "select * from KhachHang";
            comboBox5.DataSource = FillDataTable(strSQL);
            comboBox5.DisplayMember = "MaKH";
            comboBox5.ValueMember = "MaKH";
            cnn.Close();
        }
        public void ban()
        {
            string strSQL = "select MaBan as 'Mã Bàn',TenTD as 'Tên Món',SUM(SoLuong) as 'Số lượng',DonGia as 'Đơn Giá' from bonhodem Where MaBan='" + comboBox3.Text.ToString() + "' GROUP BY MaBan,TenTD,DonGia";
            dgvban.DataSource = FillDataTable(strSQL);
        }
        public void loadthucdongoimon()
        {
            string strSQL = "select ThucDon.MaTD, ThucDon.TenTD, ThucDon.DonGia, LoaiThucDon.TenLoai from ThucDon, LoaiThucDon where ThucDon.MaLoai = LoaiThucDon.MaLoai";
            dgvmonan.DataSource = FillDataTable(strSQL);
        }
        public void LoadData2()
        {
            string strSQL = "select sum(DonGia) as 'Tổng thành tiền' from bonhodem";
            dgvtongtien.DataSource = FillDataTable(strSQL);
        }
        public void LoadData3()
        {
            string strMaBan = "select MaBan as 'BànTrống' from Ban Where TinhTrang=N'Trống'";
            dataGridView1.DataSource = FillDataTable(strMaBan);
        }
        public void LoadData4()
        {
            string strMaBan = "select MaBan as 'CóNgười' from Ban Where TinhTrang=N'Có Người'";
            dataGridView2.DataSource = FillDataTable(strMaBan);
        }
        private void frMenuMain_Load(object sender, EventArgs e)
        {
            Loadpc(); Loadca(); ban(); LoadData2(); LoadData3(); LoadData4();
            loadmabanphancongtuban();
            loadmacaphancongtuca();
            loadmanvphancongtunhanvien();
            loadloaithucdonlenmonan();
            loadmabanvaocb();
            loadthucdongoimon();
            loadnhanvienohd();
            loadkhachhangnohd();
            dinhdangday();
            timer1.Enabled = true;
        }//Load Data
        private void button18_Click_1(object sender, EventArgs e)
        {
            try
            {
                ConnectDB();
                dinhdangday();
                string strSQL = System.String.Concat("Insert Into PhanCong Values ('" +
                this.cbmaca.Text.ToString() + "','" +
                this.cbmanv.Text.ToString() + "','" +
                this.cbmaban.Text.ToString() + "','" +
                this.pcdaybd.Text.ToString() + "','" +
                this.pcdaykt.Text.ToString() + "')");

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL;
                cmd.ExecuteNonQuery();

                Loadpc();

                DisconnectDB();

                MessageBox.Show("Thêm thành công phân công", "Thông Báo");
            }
            catch (SqlException)
            {
                MessageBox.Show("Lỗi, vui lòng kiểm tra lại ", "Thông Báo");
            }
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            gbtkpc.Show();
        }
        private void btntkpc_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txttkpcmnv.Text + txttkpcmc.Text))
            {
                MessageBox.Show("Tìm kiếm trống", "Thông Báo");
            }
            if (string.IsNullOrEmpty(txttkpcmnv.Text) && txttkpcmc.Text != "")
            {
                string strMaTD = Convert.ToString(txttkpcmc.Text);

                string strSQL = "select * from PhanCong Where MaCa like N'%" + strMaTD + "%'";
                dgvphancong.DataSource = FillDataTable(strSQL);
            }
            if (string.IsNullOrEmpty(txttkpcmc.Text) && txttkpcmnv.Text != "")
            {
                string strMaTD = Convert.ToString(txttkpcmnv.Text);

                string strSQL = "select * from PhanCong Where MaNV=N'" + strMaTD + "'";
                dgvphancong.DataSource = FillDataTable(strSQL);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Xác nhận xóa phân công", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
            {
                ConnectDB();
                try
                {
                    int r = dgvphancong.CurrentCell.RowIndex;

                    string strManv = dgvphancong.Rows[r].Cells[1].Value.ToString();
                    string strMaca = dgvphancong.Rows[r].Cells[0].Value.ToString();
                    string strMaban = dgvphancong.Rows[r].Cells[2].Value.ToString();
                    string strSQL = System.String.Concat("Delete From PhanCong Where MaCa='" + strMaca + "' and MaNV='" + strManv + "' and MaBan='" + strMaban + "'");

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cnn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    Loadpc();

                    DisconnectDB();

                    MessageBox.Show("Xóa phân công thành công ", "Thông Báo");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Lỗi, vui lòng kiểm tra lại ", "Thông Báo");
                }

                DisconnectDB();
            }
        }
        //=======================================================================
        //hãy thở cái rồi làm//
        private void button37_Click(object sender, EventArgs e)
        {
            string strTen = Convert.ToString(comboBox1.Text);
            string strSQL = "select ThucDon.MaTD, ThucDon.TenTD, ThucDon.DonGia, LoaiThucDon.TenLoai from ThucDon, LoaiThucDon where ThucDon.MaLoai = LoaiThucDon.MaLoai and TenLoai = N'" + strTen + "'";
            dgvmonan.DataSource = FillDataTable(strSQL);
        }
        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectDB();

                string strSQL = System.String.Concat("Insert Into bonhodem Values ('" +
                this.comboBox3.Text.ToString() + "',N'" +
                this.tenthucdon.Text.ToString() + "',1,'" +
                this.dongia.Text.ToString() + "')");

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL;
                cmd.ExecuteNonQuery();

                string strSQL1 = "select MaBan as 'Mã Bàn',TenTD as 'Tên Món',SUM(SoLuong) as 'Số lượng',DonGia as 'Đơn Giá' from bonhodem Where MaBan=" + comboBox3.Text.ToString() + " GROUP BY MaBan,TenTD,DonGia";
                dgvban.DataSource = FillDataTable(strSQL1);

                string strSQL2 = "select sum(DonGia) as 'Tổng thành tiền' from bonhodem Where MaBan=" + comboBox3.Text.ToString() + "GROUP BY MaBan,SoLuong";
                dgvtongtien.DataSource = FillDataTable(strSQL2);

                string strSQL3 = "Update Ban Set TinhTrang=N'Có Người' Where MaBan='" + comboBox3.Text.ToString() + "'";
                dataGridView3.DataSource = FillDataTable(strSQL3);
                //123
                LoadData3();
                LoadData4();
                DisconnectDB();
            }
            catch (SqlException)
            {
                MessageBox.Show("Lỗi, vui lòng kiểm tra lại", "Thông Báo");
            }
        }
        private void button30_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txttentdgm.Text))
            {
                MessageBox.Show("Thực đơn đã chọn trống", "Thông báo");
            }
            else
            {
                ConnectDB();
                try
                {
                    string strSQL = System.String.Concat("Delete From bonhodem Where MaBan ='" + txtmabangm.Text.ToString() + "' and TenTD=N'" + txttentdgm.Text.ToString() + "'");

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cnn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    ban();
                    LoadData3();
                    LoadData4();

                    txtmabangm.ResetText();
                    txttentdgm.ResetText();

                    DisconnectDB();

                    MessageBox.Show("Xóa thành công", "Thông Báo");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Lỗi, vui lòng kiểm tra lại", "Thông Báo");
                }

                DisconnectDB();
            }
        }
        private void button12_Click(object sender, EventArgs e)
        {
            ConnectDB();
            try
            {
                dinhdangday();
                DateTime ngaylap = Convert.ToDateTime(dateTimePicker1.Value.ToString("dd/MM/yyyy"));
                string strSQL = System.String.Concat("Insert Into HoaDon Values ('" + comboBox3.Text.ToString() + "','" + comboBox4.Text.ToString() + "','" + comboBox5.Text.ToString() + "','" + dateTimePicker1.Text.ToString() + "','" + txttongtienban.Text.ToString() + "')");

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL;
                cmd.ExecuteNonQuery();

                DisconnectDB();
                MessageBox.Show("Thanh toán thành công", "Thông Báo");
                deleleban();
                capnhatbantrong();
                LoadData3();
                LoadData4();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        //load btn bàn------------------------
        private void ban1_Click_1(object sender, EventArgs e)
        {
            string strMaBan = "select * from Ban Where MaBan=1";
            dgvloadban.DataSource = FillDataTable(strMaBan);
            comboBox3.Text = Convert.ToString(dgvloadban.CurrentRow.Cells[0].Value);
            comboBox2.Text = Convert.ToString(dgvloadban.CurrentRow.Cells[1].Value);
            string strmonancuaban = "select MaBan as 'Mã Bàn',TenTD as 'Tên Món',SUM(SoLuong) as 'Số lượng',DonGia as 'Đơn Giá' from bonhodem Where MaBan=1 GROUP BY MaBan,TenTD,DonGia";
            dgvban.DataSource = FillDataTable(strmonancuaban);
        }
        private void ban2_Click_1(object sender, EventArgs e)
        {
            string strMaBan = "select * from Ban Where MaBan=2";
            dgvloadban.DataSource = FillDataTable(strMaBan);
            comboBox3.Text = Convert.ToString(dgvloadban.CurrentRow.Cells[0].Value);
            comboBox2.Text = Convert.ToString(dgvloadban.CurrentRow.Cells[1].Value);
            string strmonancuaban = "select MaBan as 'Mã Bàn',TenTD as 'Tên Món',SUM(SoLuong) as 'Số lượng',DonGia as 'Đơn Giá' from bonhodem Where MaBan=2 GROUP BY MaBan,TenTD,DonGia";
            dgvban.DataSource = FillDataTable(strmonancuaban);
        }
        private void ban3_Click_1(object sender, EventArgs e)
        {
            string strMaBan = "select * from Ban Where MaBan=3";
            dgvloadban.DataSource = FillDataTable(strMaBan);
            comboBox3.Text = Convert.ToString(dgvloadban.CurrentRow.Cells[0].Value);
            comboBox2.Text = Convert.ToString(dgvloadban.CurrentRow.Cells[1].Value);
            string strmonancuaban = "select MaBan as 'Mã Bàn',TenTD as 'Tên Món',SUM(SoLuong) as 'Số lượng',DonGia as 'Đơn Giá' from bonhodem Where MaBan=3 GROUP BY MaBan,TenTD,DonGia";
            dgvban.DataSource = FillDataTable(strmonancuaban);
        }
        private void ban4_Click(object sender, EventArgs e)
        {
            string strMaBan = "select * from Ban Where MaBan=4";
            dgvloadban.DataSource = FillDataTable(strMaBan);
            comboBox3.Text = Convert.ToString(dgvloadban.CurrentRow.Cells[0].Value);
            comboBox2.Text = Convert.ToString(dgvloadban.CurrentRow.Cells[1].Value);
            string strmonancuaban = "select MaBan as 'Mã Bàn',TenTD as 'Tên Món',SUM(SoLuong) as 'Số lượng',DonGia as 'Đơn Giá' from bonhodem Where MaBan=4 GROUP BY MaBan,TenTD,DonGia";
            dgvban.DataSource = FillDataTable(strmonancuaban);
        }
        private void ban5_Click(object sender, EventArgs e)
        {
            string strMaBan = "select * from Ban Where MaBan=5";
            dgvloadban.DataSource = FillDataTable(strMaBan);
            comboBox3.Text = Convert.ToString(dgvloadban.CurrentRow.Cells[0].Value);
            comboBox2.Text = Convert.ToString(dgvloadban.CurrentRow.Cells[1].Value);
            string strmonancuaban = "select MaBan as 'Mã Bàn',TenTD as 'Tên Món',SUM(SoLuong) as 'Số lượng',DonGia as 'Đơn Giá' from bonhodem Where MaBan=5 GROUP BY MaBan,TenTD,DonGia";
            dgvban.DataSource = FillDataTable(strmonancuaban);
        }
        private void ban6_Click(object sender, EventArgs e)
        {
            string strMaBan = "select * from Ban Where MaBan=6";
            dgvloadban.DataSource = FillDataTable(strMaBan);
            comboBox3.Text = Convert.ToString(dgvloadban.CurrentRow.Cells[0].Value);
            comboBox2.Text = Convert.ToString(dgvloadban.CurrentRow.Cells[1].Value);
            string strmonancuaban = "select MaBan as 'Mã Bàn',TenTD as 'Tên Món',SUM(SoLuong) as 'Số lượng',DonGia as 'Đơn Giá' from bonhodem Where MaBan=6 GROUP BY MaBan,TenTD,DonGia";
            dgvban.DataSource = FillDataTable(strmonancuaban);
        }
        private void ban7_Click(object sender, EventArgs e)
        {
            string strMaBan = "select * from Ban Where MaBan=7";
            dgvloadban.DataSource = FillDataTable(strMaBan);
            comboBox3.Text = Convert.ToString(dgvloadban.CurrentRow.Cells[0].Value);
            comboBox2.Text = Convert.ToString(dgvloadban.CurrentRow.Cells[1].Value);
            string strmonancuaban = "select MaBan as 'Mã Bàn',TenTD as 'Tên Món',SUM(SoLuong) as 'Số lượng',DonGia as 'Đơn Giá' from bonhodem Where MaBan=7 GROUP BY MaBan,TenTD,DonGia";
            dgvban.DataSource = FillDataTable(strmonancuaban);
        }
        private void ban8_Click(object sender, EventArgs e)
        {
            string strMaBan = "select * from Ban Where MaBan=8";
            dgvloadban.DataSource = FillDataTable(strMaBan);
            comboBox3.Text = Convert.ToString(dgvloadban.CurrentRow.Cells[0].Value);
            comboBox2.Text = Convert.ToString(dgvloadban.CurrentRow.Cells[1].Value);
            string strmonancuaban = "select MaBan as 'Mã Bàn',TenTD as 'Tên Món',SUM(SoLuong) as 'Số lượng',DonGia as 'Đơn Giá' from bonhodem Where MaBan=8 GROUP BY MaBan,TenTD,DonGia";
            dgvban.DataSource = FillDataTable(strmonancuaban);
        }
        private void ban9_Click(object sender, EventArgs e)
        {
            string strMaBan = "select * from Ban Where MaBan=9";
            dgvloadban.DataSource = FillDataTable(strMaBan);
            comboBox3.Text = Convert.ToString(dgvloadban.CurrentRow.Cells[0].Value);
            comboBox2.Text = Convert.ToString(dgvloadban.CurrentRow.Cells[1].Value);
            string strmonancuaban = "select MaBan as 'Mã Bàn',TenTD as 'Tên Món',SUM(SoLuong) as 'Số lượng',DonGia as 'Đơn Giá' from bonhodem Where MaBan=9 GROUP BY MaBan,TenTD,DonGia";
            dgvban.DataSource = FillDataTable(strmonancuaban);
        }
        private void ban10_Click(object sender, EventArgs e)
        {
            string strMaBan = "select * from Ban Where MaBan=10";
            dgvloadban.DataSource = FillDataTable(strMaBan);
            comboBox3.Text = Convert.ToString(dgvloadban.CurrentRow.Cells[0].Value);
            comboBox2.Text = Convert.ToString(dgvloadban.CurrentRow.Cells[1].Value);
            string strmonancuaban = "select MaBan as 'Mã Bàn',TenTD as 'Tên Món',SUM(SoLuong) as 'Số lượng',DonGia as 'Đơn Giá' from bonhodem Where MaBan=10 GROUP BY MaBan,TenTD,DonGia";
            dgvban.DataSource = FillDataTable(strmonancuaban);
        }
        private void ban11_Click(object sender, EventArgs e)
        {
            string strMaBan = "select * from Ban Where MaBan=11";
            dgvloadban.DataSource = FillDataTable(strMaBan);
            comboBox3.Text = Convert.ToString(dgvloadban.CurrentRow.Cells[0].Value);
            comboBox2.Text = Convert.ToString(dgvloadban.CurrentRow.Cells[1].Value);
            string strmonancuaban = "select MaBan as 'Mã Bàn',TenTD as 'Tên Món',SUM(SoLuong) as 'Số lượng',DonGia as 'Đơn Giá' from bonhodem Where MaBan=11 GROUP BY MaBan,TenTD,DonGia";
            dgvban.DataSource = FillDataTable(strmonancuaban);
        }
        private void ban12_Click(object sender, EventArgs e)
        {
            string strMaBan = "select * from Ban Where MaBan=12";
            dgvloadban.DataSource = FillDataTable(strMaBan);
            comboBox3.Text = Convert.ToString(dgvloadban.CurrentRow.Cells[0].Value);
            comboBox2.Text = Convert.ToString(dgvloadban.CurrentRow.Cells[1].Value);
            string strmonancuaban = "select MaBan as 'Mã Bàn',TenTD as 'Tên Món',SUM(SoLuong) as 'Số lượng',DonGia as 'Đơn Giá' from bonhodem Where MaBan=12 GROUP BY MaBan,TenTD,DonGia";
            dgvban.DataSource = FillDataTable(strmonancuaban);
        }
        private void ban13_Click(object sender, EventArgs e)
        {
            string strMaBan = "select * from Ban Where MaBan=13";
            dgvloadban.DataSource = FillDataTable(strMaBan);
            comboBox3.Text = Convert.ToString(dgvloadban.CurrentRow.Cells[0].Value);
            comboBox2.Text = Convert.ToString(dgvloadban.CurrentRow.Cells[1].Value);
            string strmonancuaban = "select MaBan as 'Mã Bàn',TenTD as 'Tên Món',SUM(SoLuong) as 'Số lượng',DonGia as 'Đơn Giá' from bonhodem Where MaBan=13 GROUP BY MaBan,TenTD,DonGia";
            dgvban.DataSource = FillDataTable(strmonancuaban);
        }
        private void ban14_Click(object sender, EventArgs e)
        {
            string strMaBan = "select * from Ban Where MaBan=14";
            dgvloadban.DataSource = FillDataTable(strMaBan);
            comboBox3.Text = Convert.ToString(dgvloadban.CurrentRow.Cells[0].Value);
            comboBox2.Text = Convert.ToString(dgvloadban.CurrentRow.Cells[1].Value);
            string strmonancuaban = "select MaBan as 'Mã Bàn',TenTD as 'Tên Món',SUM(SoLuong) as 'Số lượng',DonGia as 'Đơn Giá' from bonhodem Where MaBan=14 GROUP BY MaBan,TenTD,DonGia";
            dgvban.DataSource = FillDataTable(strmonancuaban);
        }
        private void ban15_Click(object sender, EventArgs e)
        {
            string strMaBan = "select * from Ban Where MaBan=15";
            dgvloadban.DataSource = FillDataTable(strMaBan);
            comboBox3.Text = Convert.ToString(dgvloadban.CurrentRow.Cells[0].Value);
            comboBox2.Text = Convert.ToString(dgvloadban.CurrentRow.Cells[1].Value);
            string strmonancuaban = "select MaBan as 'Mã Bàn',TenTD as 'Tên Món',SUM(SoLuong) as 'Số lượng',DonGia as 'Đơn Giá' from bonhodem Where MaBan=15 GROUP BY MaBan,TenTD,DonGia";
            dgvban.DataSource = FillDataTable(strmonancuaban);
        }
        private void ban16_Click(object sender, EventArgs e)
        {
            string strMaBan = "select * from Ban Where MaBan=16";
            dgvloadban.DataSource = FillDataTable(strMaBan);
            comboBox3.Text = Convert.ToString(dgvloadban.CurrentRow.Cells[0].Value);
            comboBox2.Text = Convert.ToString(dgvloadban.CurrentRow.Cells[1].Value);
            string strmonancuaban = "select MaBan as 'Mã Bàn',TenTD as 'Tên Món',SUM(SoLuong) as 'Số lượng',DonGia as 'Đơn Giá' from bonhodem Where MaBan=16 GROUP BY MaBan,TenTD,DonGia";
            dgvban.DataSource = FillDataTable(strmonancuaban);
        }
        private void ban17_Click(object sender, EventArgs e)
        {
            string strMaBan = "select * from Ban Where MaBan=17";
            dgvloadban.DataSource = FillDataTable(strMaBan);
            comboBox3.Text = Convert.ToString(dgvloadban.CurrentRow.Cells[0].Value);
            comboBox2.Text = Convert.ToString(dgvloadban.CurrentRow.Cells[1].Value);
            string strmonancuaban = "select MaBan as 'Mã Bàn',TenTD as 'Tên Món',SUM(SoLuong) as 'Số lượng',DonGia as 'Đơn Giá' from bonhodem Where MaBan=17 GROUP BY MaBan,TenTD,DonGia";
            dgvban.DataSource = FillDataTable(strmonancuaban);
        }
        private void ban18_Click(object sender, EventArgs e)
        {
            string strMaBan = "select * from Ban Where MaBan=18";
            dgvloadban.DataSource = FillDataTable(strMaBan);
            comboBox3.Text = Convert.ToString(dgvloadban.CurrentRow.Cells[0].Value);
            comboBox2.Text = Convert.ToString(dgvloadban.CurrentRow.Cells[1].Value);
            string strmonancuaban = "select MaBan as 'Mã Bàn',TenTD as 'Tên Món',SUM(SoLuong) as 'Số lượng',DonGia as 'Đơn Giá' from bonhodem Where MaBan=18 GROUP BY MaBan,TenTD,DonGia";
            dgvban.DataSource = FillDataTable(strmonancuaban);
        }
        private void ban19_Click(object sender, EventArgs e)
        {
            string strMaBan = "select * from Ban Where MaBan=19";
            dgvloadban.DataSource = FillDataTable(strMaBan);
            comboBox3.Text = Convert.ToString(dgvloadban.CurrentRow.Cells[0].Value);
            comboBox2.Text = Convert.ToString(dgvloadban.CurrentRow.Cells[1].Value);
            string strmonancuaban = "select MaBan as 'Mã Bàn',TenTD as 'Tên Món',SUM(SoLuong) as 'Số lượng',DonGia as 'Đơn Giá' from bonhodem Where MaBan=19 GROUP BY MaBan,TenTD,DonGia";
            dgvban.DataSource = FillDataTable(strmonancuaban);
        }
        private void ban20_Click(object sender, EventArgs e)
        {
            string strMaBan = "select * from Ban Where MaBan=20";
            dgvloadban.DataSource = FillDataTable(strMaBan);
            comboBox3.Text = Convert.ToString(dgvloadban.CurrentRow.Cells[0].Value);
            comboBox2.Text = Convert.ToString(dgvloadban.CurrentRow.Cells[1].Value);
            string strmonancuaban = "select MaBan as 'Mã Bàn',TenTD as 'Tên Món',SUM(SoLuong) as 'Số lượng',DonGia as 'Đơn Giá' from bonhodem Where MaBan=20 GROUP BY MaBan,TenTD,DonGia";
            dgvban.DataSource = FillDataTable(strmonancuaban);
        }
        private void ban21_Click(object sender, EventArgs e)
        {
            string strMaBan = "select * from Ban Where MaBan=21";
            dgvloadban.DataSource = FillDataTable(strMaBan);
            comboBox3.Text = Convert.ToString(dgvloadban.CurrentRow.Cells[0].Value);
            comboBox2.Text = Convert.ToString(dgvloadban.CurrentRow.Cells[1].Value);
            string strmonancuaban = "select MaBan as 'Mã Bàn',TenTD as 'Tên Món',SUM(SoLuong) as 'Số lượng',DonGia as 'Đơn Giá' from bonhodem Where MaBan=21 GROUP BY MaBan,TenTD,DonGia";
            dgvban.DataSource = FillDataTable(strmonancuaban);
        }
        private void ban22_Click(object sender, EventArgs e)
        {
            string strMaBan = "select * from Ban Where MaBan=22";
            dgvloadban.DataSource = FillDataTable(strMaBan);
            comboBox3.Text = Convert.ToString(dgvloadban.CurrentRow.Cells[0].Value);
            comboBox2.Text = Convert.ToString(dgvloadban.CurrentRow.Cells[1].Value);
            string strmonancuaban = "select MaBan as 'Mã Bàn',TenTD as 'Tên Món',SUM(SoLuong) as 'Số lượng',DonGia as 'Đơn Giá' from bonhodem Where MaBan=22 GROUP BY MaBan,TenTD,DonGia";
            dgvban.DataSource = FillDataTable(strmonancuaban);
        }
        private void ban23_Click(object sender, EventArgs e)
        {
            string strMaBan = "select * from Ban Where MaBan=23";
            dgvloadban.DataSource = FillDataTable(strMaBan);
            comboBox3.Text = Convert.ToString(dgvloadban.CurrentRow.Cells[0].Value);
            comboBox2.Text = Convert.ToString(dgvloadban.CurrentRow.Cells[1].Value);
            string strmonancuaban = "select MaBan as 'Mã Bàn',TenTD as 'Tên Món',SUM(SoLuong) as 'Số lượng',DonGia as 'Đơn Giá' from bonhodem Where MaBan=23 GROUP BY MaBan,TenTD,DonGia";
            dgvban.DataSource = FillDataTable(strmonancuaban);
        }
        private void ban24_Click(object sender, EventArgs e)
        {
            string strMaBan = "select * from Ban Where MaBan=24";
            dgvloadban.DataSource = FillDataTable(strMaBan);
            comboBox3.Text = Convert.ToString(dgvloadban.CurrentRow.Cells[0].Value);
            comboBox2.Text = Convert.ToString(dgvloadban.CurrentRow.Cells[1].Value);
            string strmonancuaban = "select MaBan as 'Mã Bàn',TenTD as 'Tên Món',SUM(SoLuong) as 'Số lượng',DonGia as 'Đơn Giá' from bonhodem Where MaBan=24 GROUP BY MaBan,TenTD,DonGia";
            dgvban.DataSource = FillDataTable(strmonancuaban);
        }
        private void ban25_Click(object sender, EventArgs e)
        {
            string strMaBan = "select * from Ban Where MaBan=25";
            dgvloadban.DataSource = FillDataTable(strMaBan);
            comboBox3.Text = Convert.ToString(dgvloadban.CurrentRow.Cells[0].Value);
            comboBox2.Text = Convert.ToString(dgvloadban.CurrentRow.Cells[1].Value);
            string strmonancuaban = "select MaBan as 'Mã Bàn',TenTD as 'Tên Món',SUM(SoLuong) as 'Số lượng',DonGia as 'Đơn Giá' from bonhodem Where MaBan=25 GROUP BY MaBan,TenTD,DonGia";
            dgvban.DataSource = FillDataTable(strmonancuaban);
        }
        private void button41_Click(object sender, EventArgs e)
        {
            //Form frm = new tatmay();
            //frm.ShowDialog();
        }
        private void button42_Click(object sender, EventArgs e)
        {
            Form frm = new Form1();
            frm.ShowDialog();
        }
        private void button40_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Xác nhận đăng xuất hệ thống?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
            {
                this.Hide();
                Form frm = new Dangnhap();
                frm.ShowDialog();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form frm = new phanhoi();
            frm.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("HH:mm:ss");
            timelbl.Text = DateTime.Now.ToString("HH:mm:ss");
        }
       
    }
}
