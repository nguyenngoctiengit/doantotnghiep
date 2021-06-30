using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using doannhom.Models;

namespace doannhom
{
    public partial class fmMenuMainAdmin : Form
    {
        public fmMenuMainAdmin()
        {
            InitializeComponent();
        }
        public NhaHangContext _context = new NhaHangContext();

        SqlConnection cnn;
        SqlCommand cmd;
        void ConnectDB()
        {
            string strDB = @"Data Source=DESKTOP-GJ6UCAT;Initial Catalog=NhaHang;Integrated Security=True";
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
        private void FillChart()
        {
            string strSQL = "Select TenNV as 'hoten',luong from nhanvien";
            try
            {
                ConnectDB();
                DataTable dt = FillDataTable(strSQL);
                chart1.DataSource = dt;
                chart1.Series["Lương"].XValueMember = "hoten";
                chart1.Series["Lương"].YValueMembers = "luong";
                DisconnectDB();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không vẽ được biểu đồ bởi: " + ex.Message);
            }
        }
        //Load Data từng tab
        public void Loadtk()
        {
            var db = new NhaHangContext();
            dgvtaikhoan.DataSource = (from c in db.TaiKhoan select c).ToList();
        }
        public void Loadnv()
        {
            dgvnhanvien.DataSource = (from a in _context.NhanVien
                                     select new
                                     {
                                         a.MaNv,
                                         a.TenNv,
                                         a.GioiTinh,
                                         a.NgaySinh,
                                         a.Sdt,
                                         a.DiaChi,
                                         a.Email,
                                         a.NgayVaoLam,
                                         a.ChucVu,
                                         a.PhuCap
                                     }).ToList();
            gbtknv.Hide();
        }
        public void Loadpc()
        {
            dgvphancong.DataSource = (from a in _context.PhanCong
                                     select new
                                     {
                                         a.MaPC,
                                         a.MaBan,
                                         a.MaCa,
                                         a.MaNv,
                                         a.NgayBatDau,
                                         a.NgayKetThuc
                                     }).ToList();            
            gbtkpc.Hide();
        }
        public void Loadca()
        {
            dgvca.DataSource = (from a in _context.Ca select new { a.MaCa, a.TenCa, a.LuuY, a.NgayBd, a.NgayKt }).ToList();
        }
        public void Loadtd()
        {
            dgvthucdon.DataSource = (from a in _context.MonAn
                                    select new
                                    {
                                        a.MaMonAn,
                                        a.MaLoai,
                                        a.TenMon,
                                        a.Dvt,
                                        a.DonGia
                                    }).ToList();
            gbtktd.Hide();
        }
        public void Loadltd()
        {
            dgvloaitd.DataSource = (from a in _context.LoaiMonAn
                                   select new
                                   {
                                       a.MaLoai,
                                       a.TenLoai,
                                   }).ToList();
            gbtktd.Hide();

        }
        public void Loadhd()
        {
            string strSQL = "select MaHD as 'Mã HĐ',MaBan as ' MÃ Bàn',NgayLap as 'Ngày Lập',TongTien as 'Tổng Tiền' from HoaDon";
            dgvhoadon.DataSource = FillDataTable(strSQL);
        }
        public void loadmacaphancongtuca()
        {
            cbmaca.DataSource = (from a in _context.Ca select a.MaCa).ToList();
/*            cbmaca.DisplayMember = "MaCa";
            cbmaca.ValueMember = "MaCa";*/
        }
        public void loadmanvphancongtunhanvien()
        {
            cbmanv.DataSource = (from a in _context.NhanVien select new { a.MaNv, a.TenNv }).ToList();
            cbmanv.DisplayMember = "TenNv";
            cbmanv.ValueMember = "MaNv";
        }
        public void loadmabanphancongtuban()
        {
            string strSQL = "select * from Ban";
            cbmaban.DataSource = FillDataTable(strSQL);
            cbmaban.DisplayMember = "MaBan";
            cbmaban.ValueMember = "MaBan";
            cnn.Close();
        }
        public void loadloaithucdontuloai()
        {
            txtmaloai.DataSource = (from a in _context.LoaiMonAn select new { a.MaLoai, a.TenLoai }).ToList();
            txtmaloai.DisplayMember = "TenLoai";
            txtmaloai.ValueMember = "MaLoai";
        }
        public void loadloaithucdonlenmonan()
        {
            comboBox1.DataSource = (from a in _context.LoaiMonAn select new { a.MaLoai, a.TenLoai }).ToList();
            comboBox1.DisplayMember = "TenLoai";
            comboBox1.ValueMember = "MaLoai";
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
        void loadkh()
        {
            string strSQL = "select * from khachhang";
            dgvhoadon.DataSource = FillDataTable(strSQL);
        }
        void loadnv()
        {
            string strSQL = "select * from nhanvien";
            dgvhoadon.DataSource = FillDataTable(strSQL);
        }
        void loadpc()
        {
            string strSQL = "select * from phancong";
            dgvhoadon.DataSource = FillDataTable(strSQL);
        }
        void loadtd()
        {
            string strSQL = "select * from thucdon";
            dgvhoadon.DataSource = FillDataTable(strSQL);
        }
        void loadltd()
        {
            string strSQL = "select * from loaithucdon";
            dgvhoadon.DataSource = FillDataTable(strSQL);
        }
        void loadhd()
        {
            string strSQL = "select * from hoadon";
            dgvhoadon.DataSource = FillDataTable(strSQL);
        }
        void loadhd1()
        {
            string strSQL = "select * from hoadon";
            dataGridView4.DataSource = FillDataTable(strSQL);
        }
        void loadtk()
        {
            string strSQL = "select * from taikhoan";
            dgvhoadon.DataSource = FillDataTable(strSQL);
        }
        void loadnvtc()
        {
            string strSQL = "select TenNV,Luong,PhuCap from nhanvien";
            dgvhoadon.DataSource = FillDataTable(strSQL);
        }
        void loadhdtc()
        {
            string strSQL = "select * from hoadon";
            dgvhoadon.DataSource = FillDataTable(strSQL);
        }
        string SaveFile()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.DefaultExt = "xlsx";
            saveFileDialog1.Filter = "Excel file (*.xlsx)|*.xlsx|ALL files (*.*)|*.*";
            saveFileDialog1.InitialDirectory = @"C:";
            saveFileDialog1.ShowDialog();
            return Convert.ToString(saveFileDialog1.FileName);
        }
        void ExportExcel(string path)
        {
            try
            {
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                app.Visible = true;
                worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "Ket Xuat Du Lieu";
                for (int i = 1; i < dgvhoadon.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = dgvhoadon.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dgvhoadon.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dgvhoadon.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dgvhoadon.Rows[i].Cells[j].Value.ToString();
                    }
                }
                workbook.SaveAs(path, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                app.Quit();
                MessageBox.Show("Kết xuất dữ liệu thành công\n Đường dẫn lưu file: \n" + path, "Kết quả kết xuất file");
            }
            catch
            {
                MessageBox.Show("Lỗi kết xuất dữ liệu");
            }
        }
        // ***************load data từ gridview**************
        private void dgvtaikhoan_SelectionChanged(object sender, EventArgs e)
        {
            tktk.Text = Convert.ToString(dgvtaikhoan.CurrentRow.Cells[0].Value);
            tkmk.Text = Convert.ToString(dgvtaikhoan.CurrentRow.Cells[1].Value);
            tkcv.Text = Convert.ToString(dgvtaikhoan.CurrentRow.Cells[3].Value);
            tkdaydk.Text = Convert.ToString(dgvtaikhoan.CurrentRow.Cells[4].Value);
        }
        private void dgvnhanvien_SelectionChanged(object sender, EventArgs e)
        {
            nvmanv.Text = Convert.ToString(dgvnhanvien.CurrentRow.Cells[0].Value);
            nvten.Text = Convert.ToString(dgvnhanvien.CurrentRow.Cells[1].Value);
            nvgt.Text = Convert.ToString(dgvnhanvien.CurrentRow.Cells[2].Value);
            nvngaysinh.Text = Convert.ToString(dgvnhanvien.CurrentRow.Cells[3].Value);
            nvsdt.Text = Convert.ToString(dgvnhanvien.CurrentRow.Cells[4].Value);
            nvdiachi.Text = Convert.ToString(dgvnhanvien.CurrentRow.Cells[5].Value);
            nvemail.Text = Convert.ToString(dgvnhanvien.CurrentRow.Cells[6].Value);
            nvdaylam.Text = Convert.ToString(dgvnhanvien.CurrentRow.Cells[7].Value);
            nvcv.Text = Convert.ToString(dgvnhanvien.CurrentRow.Cells[8].Value);
            nvpc.Text = Convert.ToString(dgvnhanvien.CurrentRow.Cells[9].Value);
        }
        private void dgvphancong_SelectionChanged(object sender, EventArgs e)
        {
            cbmaca.Text = Convert.ToString(dgvphancong.CurrentRow.Cells[2].Value);
            cbmanv.SelectedValue = Convert.ToString(dgvphancong.CurrentRow.Cells[3].Value);
            cbmaban.Text = Convert.ToString(dgvphancong.CurrentRow.Cells[1].Value);
            pcdaybd.Text = Convert.ToString(dgvphancong.CurrentRow.Cells[4].Value);
            pcdaykt.Text = Convert.ToString(dgvphancong.CurrentRow.Cells[5].Value);
        }
        private void dgvca_SelectionChanged(object sender, EventArgs e)
        {
            txtmaca.Text = Convert.ToString(dgvca.CurrentRow.Cells[0].Value);
            txttenca.Text = Convert.ToString(dgvca.CurrentRow.Cells[1].Value);
            txtluuy.Text = Convert.ToString(dgvca.CurrentRow.Cells[2].Value);
        }

        private void dgvthucdon_SelectionChanged(object sender, EventArgs e)
        {
            txtmatd.Text = Convert.ToString(dgvthucdon.CurrentRow.Cells[0].Value);
            txtmaloai.Text = Convert.ToString(dgvthucdon.CurrentRow.Cells[1].Value);
            txttentd.Text = Convert.ToString(dgvthucdon.CurrentRow.Cells[2].Value);
            txtdvt.Text = Convert.ToString(dgvthucdon.CurrentRow.Cells[3].Value);
            txtdongia.Text = Convert.ToString(dgvthucdon.CurrentRow.Cells[4].Value);
        }
        private void dgvloaitd_SelectionChanged_1(object sender, EventArgs e)
        {
            txtltdmaloai.Text = Convert.ToString(dgvloaitd.CurrentRow.Cells[0].Value);
            txtltdtenloai.Text = Convert.ToString(dgvloaitd.CurrentRow.Cells[1].Value);
        }
        private void dgvban_SelectionChanged(object sender, EventArgs e)
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
        private void dataGridView4_SelectionChanged(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(dataGridView4.CurrentRow.Cells[0].Value);
        }
        //----------*************************************---------------------------------
        private void fmMenuMain_Load(object sender, EventArgs e)
        {
            Loadtk(); Loadnv(); Loadpc(); Loadca(); Loadtd(); Loadltd(); Loadhd(); ban(); LoadData2(); LoadData3(); LoadData4();
            loadmabanphancongtuban();
            loadmacaphancongtuca();
            loadmanvphancongtunhanvien();
            loadloaithucdontuloai();
            loadloaithucdonlenmonan();
            loadmabanvaocb();
            loadthucdongoimon();
            loadnhanvienohd();
            dinhdangday();
            FillChart();
            chart1.Hide();
            dgvthuchi.Hide();
            //timer1.Interval = 1000;
            timer1.Enabled = true;
        } //Load Data
        //----*********************Reload data********-------------------
        private void tkbtnreload_Click(object sender, EventArgs e)
        {
            Loadtk();
            tktk.Focus();
            tktk.ResetText();
            tkmk.ResetText();
            tkdaydk.ResetText();
            tkdaycn.ResetText();
            tkcv.ResetText();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Loadnv();
            nvmanv.Focus();
            nvmanv.ResetText();
            nvten.ResetText();
            nvgt.ResetText();
            nvcv.ResetText();
            nvdaylam.ResetText();
            nvdiachi.ResetText();
            nvemail.ResetText();
            nvngaysinh.ResetText();
            nvpc.ResetText();
            nvsdt.ResetText();
            txttkmnv.ResetText();
            txttktnv.ResetText();
        }
        private void button20_Click(object sender, EventArgs e)
        {
            Loadpc();
            Loadca();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            Loadltd();
            Loadtd();
        }
        //----------**************sự kiện update tài khoản***************---------------------------------     
        private void tkbtnsua_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = dgvtaikhoan.CurrentCell.RowIndex;
                string tenTK = dgvtaikhoan.Rows[rowIndex].Cells[0].Value.ToString();
                var item_change = (from a in _context.TaiKhoan where a.TenTk == tenTK select a).FirstOrDefault();
                item_change.MatKhau = this.tkmk.Text;
                _context.TaiKhoan.Update(item_change);
                _context.SaveChanges();
                Loadtk();
                MessageBox.Show("Đổi mật khẩu thành công", "Thông Báo");
            }
            catch (SqlException)
            {
                MessageBox.Show("Lỗi, vui lòng kiểm tra lại", "Thông Báo");
            }
        }
        //----------**************sự kiện nhân viên**********************---------------------------------
        private void new_save_NV_Click(object sender, EventArgs e)
        {
            switch (new_save_NV.Text)
            {
                case "&NEW":
                    new_save_NV.Text = "&SAVE";
                    nvmanv.Enabled = true; nvmanv.ResetText();
                    nvten.Enabled = true; nvten.ResetText();
                    nvpc.Enabled = true; nvpc.ResetText();
                    nvgt.Enabled = true; nvgt.ResetText();
                    nvngaysinh.Enabled = true; nvngaysinh.ResetText();
                    nvsdt.Enabled = true; nvsdt.ResetText();
                    nvdiachi.Enabled = true; nvdiachi.ResetText();
                    nvemail.Enabled = true; nvemail.ResetText();
                    nvdaylam.Enabled = true; nvdaylam.ResetText();
                    nvcv.Enabled = true; nvcv.ResetText();
                    break;
                case "&SAVE":
                    try
                    {
                        var nv = new NhanVien();
                        if (_context.NhanVien.Any(a => a.MaNv == this.nvmanv.Text.ToString())){
                            MessageBox.Show("Mã nhân viên bị trùng, vui lòng nhập lại", "Thông Báo");
                        } else if (!this.nvmanv.Text.StartsWith("NV"))
                        {
                            MessageBox.Show("Vui lòng nhập mã nhân viên NV + stt nhân viên", "Thông Báo");
                        }
                        else
                        {
                            nv.MaNv = this.nvmanv.Text.ToString();
                            nv.TenNv = this.nvten.Text.ToString();
                            nv.GioiTinh = this.nvgt.Text.ToString();
                            nv.NgaySinh = this.nvngaysinh.Value;
                            nv.Sdt = int.Parse(this.nvsdt.Text);
                            nv.DiaChi = this.nvdiachi.Text.ToString();
                            nv.Email = this.nvemail.Text.ToString();
                            nv.NgayVaoLam = this.nvdaylam.Value;
                            nv.ChucVu = this.nvcv.Text.ToString();
                            nv.PhuCap = int.Parse(this.nvpc.Text.ToString());
                            _context.NhanVien.Add(nv);
                            _context.SaveChanges();
                            new_save_NV.Text = "&NEW";
                            button1.Text = "&EDIT";
                            Loadnv();
                            MessageBox.Show("Thêm nhân viên thành công", "Thông Báo");
                        } 
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Lỗi, vui lòng kiểm tra lại ", "Thông Báo");
                    }
                    break;
            }
            
        }
        private void button16_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Xác nhận xóa nhân viên", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
            {
                try
                {
                    bool flag = false;
                    int r = dgvnhanvien.CurrentCell.RowIndex;
                    string strMaThucDon = dgvnhanvien.Rows[r].Cells[0].Value.ToString();
                    if (_context.PhanCong.Any(a => a.MaNv == strMaThucDon)){
                        flag = true;
                    };
                    if (flag == true)
                    {
                        MessageBox.Show("Không thể xóa nhân viên, nhân viên đang được phân công", "Thông Báo");
                    }
                    else
                    {
                        var delete_item = _context.NhanVien.Where(a => a.MaNv == strMaThucDon).FirstOrDefault();
                        _context.Remove(delete_item);
                        _context.SaveChanges();
                        Loadnv();
                        MessageBox.Show("Xóa nhân viên thành công ", "Thông Báo");
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Lỗi, vui lòng kiểm tra lại ", "Thông Báo");
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            switch (button1.Text)
            {
                case "&EDIT":
                    button1.Text = "&SAVE";
                    nvten.Enabled = true;
                    nvpc.Enabled = true;
                    nvgt.Enabled = true;
                    nvngaysinh.Enabled = true;
                    nvsdt.Enabled = true;
                    nvdiachi.Enabled = true;
                    nvemail.Enabled = true;
                    nvdaylam.Enabled = true;
                    nvcv.Enabled = true;
                    break;
                case "&SAVE":
                    try
                    {
                        int r = dgvnhanvien.CurrentCell.RowIndex;
                        string strMaNV = dgvnhanvien.Rows[r].Cells[0].Value.ToString();
                        var nv = (from a in _context.NhanVien where a.MaNv == strMaNV select a).FirstOrDefault();
                        nv.MaNv = this.nvmanv.Text.ToString();
                        nv.TenNv = this.nvten.Text.ToString();
                        nv.GioiTinh = this.nvgt.Text.ToString();
                        nv.NgaySinh = this.nvngaysinh.Value;
                        nv.Sdt = int.Parse(this.nvsdt.Text);
                        nv.DiaChi = this.nvdiachi.Text.ToString();
                        nv.Email = this.nvemail.Text.ToString();
                        nv.NgayVaoLam = this.nvdaylam.Value;
                        nv.ChucVu = this.nvcv.Text.ToString();
                        nv.PhuCap = int.Parse(this.nvpc.Text.ToString());
                        _context.NhanVien.Update(nv);
                        _context.SaveChanges();
                        button1.Text = "&EDIT";
                        Loadnv();
                        MessageBox.Show("Sửa nhân viên thành công", "Thông Báo");
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Lỗi, vui lòng kiểm tra lại ", "Thông Báo");
                    }
                    break;
            }
        }
        private void btnReload_nv_Click(object sender, EventArgs e)
        {
            Loadnv();
        }
        private void button17_Click(object sender, EventArgs e)
        {
            gbtknv.Show();
        }
        private void btntknv_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txttkmnv.Text + txttktnv.Text))
            {
                MessageBox.Show("Tìm kiếm trống", "Thông Báo");
            }
            if (cbSearchNv.Text == "Mã nhân viên")
            {
                if (txttkmnv.Text == null || txttkmnv.Text == "")
                {
                    MessageBox.Show("Tìm kiếm trống", "Thông Báo");
                }
                else
                {
                    string maNv = Convert.ToString(txttkmnv.Text);
                    dgvnhanvien.DataSource = (from a in _context.NhanVien
                                                            where a.MaNv == maNv
                                                            select new
                                                            {
                                                                a.MaNv,
                                                                a.TenNv,
                                                                a.GioiTinh,
                                                                a.NgaySinh,
                                                                a.Sdt,
                                                                a.DiaChi,
                                                                a.Email,
                                                                a.NgayVaoLam,
                                                                a.ChucVu,
                                                                a.PhuCap
                                                            }).ToList();
                }
            }
            else if (cbSearchNv.Text == "Tên nhân viên")
            {
                if (txttktnv.Text == null || txttktnv.Text == "")
                {
                    MessageBox.Show("Tìm kiếm trống", "Thông Báo");
                }
                else
                {
                    string TenNv = Convert.ToString(txttktnv.Text);
                    dgvnhanvien.DataSource = (from a in _context.NhanVien
                                              where a.TenNv == TenNv
                                              select new
                                              {
                                                  a.MaNv,
                                                  a.TenNv,
                                                  a.GioiTinh,
                                                  a.NgaySinh,
                                                  a.Sdt,
                                                  a.DiaChi,
                                                  a.Email,
                                                  a.NgayVaoLam,
                                                  a.ChucVu,
                                                  a.PhuCap
                                              }).ToList();
                }
            }
        }
        //----------**************sự kiện phân công nhân viên************---------------------------------
        private void Enable_and_ResetText_Phancong()
        {
            cbmaca.Focus();
            cbmaca.ResetText();cbmaca.Enabled = true;
            cbmanv.ResetText();cbmanv.Enabled = true;
            pcdaybd.ResetText();pcdaybd.Enabled = true;
            pcdaykt.ResetText();pcdaykt.Enabled = true;
            cbmaban.ResetText();cbmaban.Enabled = true;
        }
        private void Enable_Phancong()
        {
            cbmaca.Focus();
            cbmaca.Enabled = true;
            cbmanv.Enabled = true;
            pcdaybd.Enabled = true;
            pcdaykt.Enabled = true;
            cbmaban.Enabled = true;
        }
        private void Disnable_Phancong()
        {
            cbmaca.Focus();
            cbmaca.Enabled = false;
            cbmanv.Enabled = false;
            pcdaybd.Enabled = false;
            pcdaykt.Enabled = false;
            cbmaban.Enabled = false;
        }
        private void button18_Click(object sender, EventArgs e)
        {
            switch (button18.Text)
            {
                case "&NEW":
                    button18.Text = "&SAVE";
                    btnEdit_pc.Text = "&EDIT";
                    Enable_and_ResetText_Phancong();
                    break;
                case "&SAVE":
                    try
                    {
                        var pc = new PhanCong();
                        pc.MaCa = this.cbmaca.SelectedValue.ToString();
                        pc.MaNv = this.cbmanv.SelectedValue.ToString();
                        pc.MaBan = this.cbmaban.SelectedValue.ToString();
                        pc.NgayBatDau = this.pcdaybd.Value;
                        pc.NgayKetThuc = this.pcdaykt.Value;
                        _context.PhanCong.Add(pc);
                        _context.SaveChanges();
                        button18.Text = "&NEW";
                        btnEdit_pc.Text = "&EDIT";
                        Disnable_Phancong();

                        Loadpc();
                        MessageBox.Show("Thêm nhân viên thành công", "Thông Báo");
                        
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Lỗi, vui lòng kiểm tra lại ", "Thông Báo");
                    }
                    break;
            }
        }
        private void btnEdit_pc_Click(object sender, EventArgs e)
        {
            switch (btnEdit_pc.Text)
            {
                case "&EDIT":
                    btnEdit_pc.Text = "&SAVE";
                    button18.Text = "&NEW";
                    Enable_Phancong();
                    break;
                case "&SAVE":
                    try
                    {
                        int r = dgvphancong.CurrentCell.RowIndex;
                        var maPc = dgvphancong.Rows[r].Cells[0];
                        int MaPc = (int)maPc.Value;
                        var item_return = (from a in _context.PhanCong where a.MaPC == MaPc select a).FirstOrDefault();
                        item_return.MaCa = this.cbmaca.SelectedValue.ToString();
                        item_return.MaNv = this.cbmanv.SelectedValue.ToString();
                        item_return.MaBan = this.cbmaban.SelectedValue.ToString();
                        item_return.NgayBatDau = this.pcdaybd.Value;
                        item_return.NgayKetThuc = this.pcdaykt.Value;
                        _context.PhanCong.Update(item_return);
                        _context.SaveChanges();
                        Disnable_Phancong();
                        btnEdit_pc.Text = "&EDIT";
                        button18.Text = "&NEW";
                        Loadpc();
                        MessageBox.Show("Chỉnh sửa nhân viên thành công", "Thông Báo");

                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Lỗi, vui lòng kiểm tra lại ", "Thông Báo");
                    }
                    break;
            }
        }
        private void button3_Click(object sender, EventArgs e)
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
                    var maPc = dgvphancong.Rows[r].Cells[0];
                    int MaPc = (int)maPc.Value;
                    var item_return = (from a in _context.PhanCong where a.MaPC == MaPc select a).FirstOrDefault();
                    _context.PhanCong.Remove(item_return);
                    _context.SaveChanges();
                    Loadpc();
                    MessageBox.Show("Xóa phân công thành công ", "Thông Báo");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Lỗi, vui lòng kiểm tra lại ", "Thông Báo");
                }
            }
        }
        //----------**************sự kiện khách hàng*********************---------------------------------

        //----------**************sự kiện show hide thực đơn*************---------------------------------
        private void btnsualoaitd_Click(object sender, EventArgs e)
        {
            switch (btnsualoaitd.Text)
            {
                case "Sửa":
                    btnsualoaitd.Text = "Save";
                    btnthemloaitd.Text = "Thêm";
                    txtltdtenloai.Enabled = true;
                    break;
                case "Save":
                    try
                    {
                        int r = dgvloaitd.CurrentCell.RowIndex;
                        string MaLoaiTD = dgvloaitd.Rows[r].Cells[0].Value.ToString();
                        var item_return = (from a in _context.LoaiMonAn where a.MaLoai == MaLoaiTD select a).FirstOrDefault();
                        item_return.TenLoai = this.txtltdtenloai.Text.ToString();
                        _context.LoaiMonAn.Update(item_return);
                        _context.SaveChanges();
                        txtltdtenloai.Enabled = false;
                        btnsualoaitd.Text = "Sửa";
                        btnthemloaitd.Text = "Thêm";
                        loadloaithucdontuloai();
                        Loadltd();
                        MessageBox.Show("Chỉnh sửa loại món ăn thành công", "Thông Báo");

                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Lỗi, vui lòng kiểm tra lại ", "Thông Báo");
                    }
                    break;
            }
            gbtktd.Hide();
        }
        private void btnxoaloaitd_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Xác nhận xóa loại món ăn", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
            {
                ConnectDB();
                try
                {
                    int r = dgvloaitd.CurrentCell.RowIndex;
                    string MaLoaiTD = dgvloaitd.Rows[r].Cells[0].Value.ToString();
                    var item_return = (from a in _context.LoaiMonAn where a.MaLoai == MaLoaiTD select a).FirstOrDefault();
                    if (_context.MonAn.Any(a => a.MaLoai == item_return.MaLoai))
                    {
                        MessageBox.Show("Loại món ăn chứa món ăn, không thể xóa", "Thông Báo");
                    }
                    else
                    {
                        _context.LoaiMonAn.Remove(item_return);
                        _context.SaveChanges();
                        loadloaithucdontuloai();
                        Loadltd();
                        MessageBox.Show("Xóa loại món ăn thành công ", "Thông Báo");
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Lỗi, vui lòng kiểm tra lại ", "Thông Báo");
                }
            }
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            switch (btnthemloaitd.Text)
            {
                case "Thêm":
                    btnthemloaitd.Text = "Save";
                    btnsualoaitd.Text = "Sửa";
                    txtltdmaloai.Enabled = true;
                    txtltdtenloai.Enabled = true;
                    txtltdmaloai.ResetText();
                    txtltdtenloai.ResetText();
                    break;
                case "Save":
                    try
                    {
                        var item = new LoaiMonAn();
                        if (_context.LoaiMonAn.Any(a => a.MaLoai == this.txtltdmaloai.Text.ToString()))
                        {
                            MessageBox.Show("Mã loại món ăn bị trùng, vui lòng nhập lại", "Thông Báo");
                        }
                        else if (!this.txtltdmaloai.Text.StartsWith("ML"))
                        {
                            MessageBox.Show("Vui lòng nhập mã loại món ăn ML + stt món ăn", "Thông Báo");
                        }
                        else
                        {
                            item.MaLoai = this.txtltdmaloai.Text.ToString();
                            item.TenLoai = this.txtltdtenloai.Text.ToString();
                            _context.LoaiMonAn.Add(item);
                            _context.SaveChanges();
                            btnthemloaitd.Text = "Thêm";
                            btnsualoaitd.Text = "Sửa";
                            loadloaithucdontuloai();
                            Loadltd();
                            MessageBox.Show("Thêm loại món ăn thành công", "Thông Báo");
                        }

                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Lỗi, vui lòng kiểm tra lại ", "Thông Báo");
                    }
                    break;
            }
        }
        private void enable_resetText_td()
        {
            txtmatd.Focus();
            txtmatd.ResetText();txtmatd.Enabled = true;
            txttentd.ResetText();txttentd.Enabled = true;
            txtmaloai.ResetText();txtmaloai.Enabled = true;
            txtdongia.ResetText();txtdongia.Enabled = true;
            txtdvt.ResetText();txtdvt.Enabled = true;
        }
        private void disable_td()
        {
            txtmatd.Enabled = false;
            txttentd.Enabled = false;
            txtmaloai.Enabled = false;
            txtdongia.Enabled = false;
            txtdvt.Enabled = false;
        }
        private void enable_td()
        {
            txtmatd.Enabled = true;
            txttentd.Enabled = true;
            txtmaloai.Enabled = true;
            txtdongia.Enabled = true;
            txtdvt.Enabled = true;
        }
        private void button24_Click(object sender, EventArgs e)
        {
            switch (button24.Text)
            {
                case "&NEW":
                    button24.Text = "&SAVE";
                    button25.Text = "&EDIT";
                    enable_resetText_td();
                    break;
                case "&SAVE":
                    try
                    {
                        var mn = new MonAn();
                        if (_context.MonAn.Any(a => a.MaMonAn == this.txtmatd.Text.ToString()))
                        {
                            MessageBox.Show("Mã món ăn bị trùng, vui lòng nhập lại", "Thông Báo");
                        }
                        else if (!this.txtmatd.Text.StartsWith("TD"))
                        {
                            MessageBox.Show("Vui lòng nhập mã món ăn TD + stt món ăn", "Thông Báo");
                        }
                        else
                        {
                            mn.MaMonAn = this.txtmatd.Text.ToString();
                            mn.TenMon = this.txttentd.Text.ToString();
                            mn.DonGia = int.Parse(this.txtdongia.Text.ToString());
                            mn.Dvt = this.txtdvt.Text.ToString();
                            mn.MaLoai = this.txtmaloai.SelectedValue.ToString();
                            _context.MonAn.Add(mn);
                            _context.SaveChanges();
                            button24.Text = "&NEW";
                            button25.Text = "&EDIT";
                            disable_td();
                            Loadtd();
                            MessageBox.Show("Thêm món ăn thành công", "Thông Báo");
                        }

                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Lỗi, vui lòng kiểm tra lại ", "Thông Báo");
                    }
                    break;
            }
            gbtktd.Hide();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Xác nhận xóa thực đơn", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
            {
                ConnectDB();
                try
                {
                    int r = dgvthucdon.CurrentCell.RowIndex;
                    string MaTd = dgvthucdon.Rows[r].Cells[0].Value.ToString();
                    var item_return = (from a in _context.MonAn where a.MaMonAn == MaTd select a).FirstOrDefault();
                    _context.MonAn.Remove(item_return);
                    _context.SaveChanges();
                    Loadtd();
                    MessageBox.Show("Xóa thực đơn thành công ", "Thông Báo");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Lỗi, vui lòng kiểm tra lại ", "Thông Báo");
                }
            }
        }
        private void button25_Click(object sender, EventArgs e)
        {
            switch (button25.Text)
            {
                case "&EDIT":
                    button25.Text = "&SAVE";
                    button24.Text = "&NEW";
                    enable_td();
                    break;
                case "&SAVE":
                    try
                    {
                        int r = dgvthucdon.CurrentCell.RowIndex;
                        var MaTD = dgvthucdon.Rows[r].Cells[0];
                        var maMonAn = (string)MaTD.Value;
                        var item_return = (from a in _context.MonAn where a.MaMonAn == maMonAn select a).FirstOrDefault();
                        item_return.MaMonAn = this.txtmatd.Text.ToString();
                        item_return.TenMon = this.txttentd.Text.ToString();
                        item_return.DonGia = int.Parse(this.txtdongia.Text.ToString());
                        item_return.Dvt = this.txtdvt.Text.ToString();
                        item_return.MaLoai = this.txtmaloai.SelectedValue.ToString();
                        _context.MonAn.Update(item_return);
                        _context.SaveChanges();
                        disable_td();
                        button25.Text = "&EDIT";
                        button24.Text = "&NEW";
                        Loadtd();
                        MessageBox.Show("Chỉnh sửa món ăn thành công", "Thông Báo");

                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Lỗi, vui lòng kiểm tra lại ", "Thông Báo");
                    }
                    break;
            }
            gbtktd.Hide();
        }
        private void button7_Click(object sender, EventArgs e)
        {

            gbtktd.Show();
        }
        private void button10_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tkmtd.Text + tkttd.Text))
            {
                MessageBox.Show("Tìm kiếm trống", "Thông Báo");
            }
            if (string.IsNullOrEmpty(tkmtd.Text) && tkttd.Text != "")
            {
                string strMaTD = Convert.ToString(tkttd.Text);

                string strSQL = "select * from MonAn Where TenMon like N'%" + strMaTD + "%'";
                dgvthucdon.DataSource = FillDataTable(strSQL);
            }
            if (string.IsNullOrEmpty(tkttd.Text) && tkmtd.Text != "")
            {
                string strMaTD = Convert.ToString(tkmtd.Text);

                string strSQL = "select * from MonAn Where MaMonAN=N'" + strMaTD + "'";
                dgvthucdon.DataSource = FillDataTable(strSQL);
            }
        }
        //=================================================================================================
        //hãy thở cái rồi làm//
        private void button37_Click(object sender, EventArgs e)
        {
            string strTen = comboBox1.SelectedValue.ToString();
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
        }//tim kiem loai thuc don goi mon
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

                string strSQL2 = "select sum(DonGia) as 'Tổng thành tiền' from bonhodem Where MaBan="+ comboBox3.Text.ToString() + "GROUP BY MaBan,SoLuong";
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
        }//goi mon
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
        }//xoa thuc don da chon goi mon
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
        }//thanh toan goi mon
        //load btn bàn------------------------
        private void ban1_Click(object sender, EventArgs e)
        {
            string strMaBan = "select * from Ban Where MaBan=1";
            dgvloadban.DataSource = FillDataTable(strMaBan);
            comboBox3.Text = Convert.ToString(dgvloadban.CurrentRow.Cells[0].Value);
            comboBox2.Text = Convert.ToString(dgvloadban.CurrentRow.Cells[1].Value);
            string strmonancuaban = "select MaBan as 'Mã Bàn',TenTD as 'Tên Món',SUM(SoLuong) as 'Số lượng',DonGia as 'Đơn Giá' from bonhodem Where MaBan=1 GROUP BY MaBan,TenTD,DonGia";
            dgvban.DataSource = FillDataTable(strmonancuaban);
        }
        private void ban2_Click(object sender, EventArgs e)
        {
            string strMaBan = "select * from Ban Where MaBan=2";
            dgvloadban.DataSource = FillDataTable(strMaBan);
            comboBox3.Text = Convert.ToString(dgvloadban.CurrentRow.Cells[0].Value);
            comboBox2.Text = Convert.ToString(dgvloadban.CurrentRow.Cells[1].Value);
            string strmonancuaban = "select MaBan as 'Mã Bàn',TenTD as 'Tên Món',SUM(SoLuong) as 'Số lượng',DonGia as 'Đơn Giá' from bonhodem Where MaBan=2 GROUP BY MaBan,TenTD,DonGia";
            dgvban.DataSource = FillDataTable(strmonancuaban);
        }
        private void ban3_Click(object sender, EventArgs e)
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
        //////------------------------------------------------------------------------//////////////
        //////-------------xu ly su kien thu chi--------------------------------------//////////////
        private void button19_Click(object sender, EventArgs e)
        {
            dataGridView4.Show();
            label32.Show();
            textBox1.Show();
            string strSQL = "select MaHD as 'Mã HĐ',MaBan as ' MÃ Bàn',NgayLap as 'Ngày Lập',TongTien as 'Tổng Tiền' from HoaDon";
            dataGridView4.DataSource = FillDataTable(strSQL);
        }//xem hoa don
        private void button32_Click(object sender, EventArgs e)
        {
            dataGridView4.Hide();
            string strSQL = "select * from HoaDon";
            dgvhoadon.DataSource = FillDataTable(strSQL);
        }//xem chi tiet hoa don
        private void button13_Click(object sender, EventArgs e)
        {
            dataGridView4.Show();
            string strMaTD = Convert.ToString(textBox1.Text);
            string strSQL = "select MaHD as 'Mã HĐ',MaBan as ' MÃ Bàn',NgayLap as 'Ngày Lập',TongTien as 'Tổng Tiền' from HoaDon Where MaHD='" + strMaTD + "'";
            dataGridView4.DataSource = FillDataTable(strSQL);
        }//tim kiem hoa don
        private void button35_Click(object sender, EventArgs e)
        {
            comboBox7.ResetText();
            comboBox6.ResetText();
            textBox1.ResetText();
            textBox1.Focus();
            chart1.Hide();
            dgvthuchi.Hide();
            pictureBox5.Show();
            Loadhd();
        }//reload
        private void button43_Click(object sender, EventArgs e)
        {
            dataGridView4.Hide();
            if (string.IsNullOrEmpty(comboBox7.Text))
            {
                MessageBox.Show("Vui lòng chọn dữ liệu cần xuất", "Thông Báo");
            }
            if (comboBox7.Text == "Nhân viên")
            {
                loadnv();
            }
            if (comboBox7.Text == "Phân công")
            {
                loadpc();
            }
            if (comboBox7.Text == "Thực đơn")
            {
                loadtd();
            }
            if (comboBox7.Text == "Loại thực đơn")
            {
                loadltd();
            }
            if (comboBox7.Text == "Hóa đơn")
            {
                loadhd();
            }
            if (comboBox7.Text == "Khách hàng")
            {
                loadkh();
            }
            if (comboBox7.Text == "Tài khoản")
            {
                loadtk();
            }
        }//load ra bang xem truoc
        private void button33_Click(object sender, EventArgs e)
        {
            dataGridView4.Hide();
            if (string.IsNullOrEmpty(comboBox7.Text))
            {
                MessageBox.Show("Vui lòng chọn dữ liệu cần xuất", "Thông Báo");
            }
            if (comboBox7.Text == "Nhân viên")
            {
                loadnv();
                string path = SaveFile();
                ExportExcel(path);
            }
            if (comboBox7.Text == "Phân công")
            {
                loadpc();
                string path = SaveFile();
                ExportExcel(path);
            }
            if (comboBox7.Text == "Thực đơn")
            {
                loadtd();
                string path = SaveFile();
                ExportExcel(path);
            }
            if (comboBox7.Text == "Loại thực đơn")
            {
                loadltd();
                string path = SaveFile();
                ExportExcel(path);
            }
            if (comboBox7.Text == "Hóa đơn")
            {
                loadhd();
                string path = SaveFile();
                ExportExcel(path);
            }
            if (comboBox7.Text == "Khách hàng")
            {
                loadkh();
                string path = SaveFile();
                ExportExcel(path);
            }
            if (comboBox7.Text == "Tài khoản")
            {
                loadtk();
                string path = SaveFile();
                ExportExcel(path);
            }
        }//export      
        private void button38_Click(object sender, EventArgs e)
        {
            pictureBox5.Hide();
            dataGridView4.Hide();
            if (string.IsNullOrEmpty(comboBox6.Text))
            {
                MessageBox.Show("Vui lòng chọn dữ liệu cần xuất", "Thông Báo");
                pictureBox5.Show();
            }
            if (comboBox6.Text == "Lương nhân viên")
            {
                loadnvtc();
                FillChart();
                chart1.Show();
                dgvthuchi.Hide();
            }
            if (comboBox6.Text == "Lương trung bình của nhân viên")
            {
                loadnvtc();
                chart1.Hide();
                string strSQL = "SELECT avg(luong) AS 'Lương trung bình của nhân viên' FROM nhanvien";
                dgvthuchi.DataSource = FillDataTable(strSQL);
                dgvthuchi.Show();
            }
            if (comboBox6.Text == "Lương nhân viên cao nhất")
            {
                loadnvtc();
                chart1.Hide();
                string strSQL = "SELECT Max(luong) AS 'Lương cao nhất của nhân viên' FROM nhanvien";
                dgvthuchi.DataSource = FillDataTable(strSQL);
                dgvthuchi.Show();
            }
            if (comboBox6.Text == "Lương nhân viên thấp nhất")
            {
                loadnvtc();
                chart1.Hide();
                string strSQL = "SELECT Min(luong) AS 'Lương thấp nhất của nhân viên' FROM nhanvien";
                dgvthuchi.DataSource = FillDataTable(strSQL);
                dgvthuchi.Show();
            }
            if (comboBox6.Text == "Thu nhập trong tháng")
            {
                chart1.Hide();
                loadhdtc();
                string strSQL = "SELECT Sum(tongtien) AS 'Tổng thu nhập trong tháng' FROM hoadon";
                dgvthuchi.DataSource = FillDataTable(strSQL);
                dgvthuchi.Show();
            }
        }
        private void button14_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Vui lòng nhập mã hóa đơn", "Thông báo");
            }
            else
            {
                ConnectDB();
                try
                {
                    string strSQL = System.String.Concat("Delete From hoadon Where MaHD ='" + textBox1.Text.ToString() + "'");

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cnn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    loadhd1();
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
        //------------xuly su kien he thong-------------------------------------------///////////////
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
        
        
        private void button42_Click(object sender, EventArgs e)
        {
            Form frm = new Form1();
            frm.ShowDialog();
        }

        private void button44_Click(object sender, EventArgs e)
        {
            Form frm = new phanhoiadmin();
            frm.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timelbl.Text = DateTime.Now.ToString("HH:mm:ss");
            label48.Text = DateTime.Now.ToString("HH:mm:ss");
            label60.Text = DateTime.Now.ToString("HH:mm:ss");
            label62.Text = DateTime.Now.ToString("HH:mm:ss");
            
        }

        private void dgvtaikhoan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tkgbthongtin_Enter(object sender, EventArgs e)
        {

        }

        private void dgvnhanvien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void nvmanv_TextChanged(object sender, EventArgs e)
        {

        }

        private void txttkmnv_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void cbSearchNv_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txttktnv_TextChanged(object sender, EventArgs e)
        {
            string db = "Data Source=DESKTOP-GJ6UCAT;Initial Catalog=NhaHang;Integrated Security=true;";
            SqlConnection con = new SqlConnection(db);
            con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("select * from NhanVien where TenNV like '" + txttktnv.Text + "%'", con);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dgvnhanvien.DataSource = dt;
            con.Close();
        }

        private void nvgt_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvphancong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbmaca_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbmanv_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pcdaybd_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dgvthucdon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvloaitd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtmatd_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtmaloai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox11_Enter(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void txtltdmaloai_TextChanged(object sender, EventArgs e)
        {

        }

        private void pnban_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvmonan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvban_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
