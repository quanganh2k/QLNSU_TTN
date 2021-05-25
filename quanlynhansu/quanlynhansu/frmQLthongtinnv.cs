using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace quanlynhansu
{
    public partial class frmQLthongtinnv : Form
    {
        string conn = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=QLNHANSU;Integrated Security=True";
        public frmQLthongtinnv()
        {
            InitializeComponent();
        }

        void Hienthi()
        {
            using (SqlConnection con = new SqlConnection(conn))
            {
                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT MaNV as N'Mã nhân viên', TenNV as N'Tên nhân viên', NgaySinh as N'Ngày sinh', " +
                            "GioiTinh as N'Giới tính', QueQuan as N'Quê quán', DiaChi as N'Địa chỉ', MaPB as N'Mã phòng ban', " +
                            "MaCV as N'Mã chức vụ', MaLuong as N'Mã lương' FROM NHANVIEN";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable table = new DataTable();
                    table.Load(reader);
                    dataGridView1.DataSource = table;
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text == "" || txtTenNV.Text == "" || dtpickerNS.Text == "" || cbGioiTinh.Text == "" || txtQueQuan.Text == ""
               || txtDiaChi.Text == "" || txtMaPB.Text == "" || txtMaCV.Text == "" || txtMaLuong.Text == "")
            {
                MessageBox.Show("Cần điền đầy đủ thông tin", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có muốn thêm nhân viên", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    using (SqlConnection con = new SqlConnection(conn))
                    {
                        try
                        {
                            if (con.State == ConnectionState.Closed)
                                con.Open();
                            string query = "INSERT INTO NHANVIEN(MaNV, TenNV, NgaySinh, GioiTinh, QueQuan, DiaChi, MaPB, MaCV, MaLuong) " +
                                "VALUES (@manv, @tennv, @ngaysinh, @gioitinh, @quequan, @diachi, @mapb, @macv, @maluong)";
                            SqlCommand cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@manv", txtMaNV.Text);
                            cmd.Parameters.AddWithValue("@tennv", txtTenNV.Text);
                            cmd.Parameters.AddWithValue("@ngaysinh", dtpickerNS.Text);
                            cmd.Parameters.AddWithValue("@gioitinh", cbGioiTinh.Text);
                            cmd.Parameters.AddWithValue("@quequan", txtQueQuan.Text);
                            cmd.Parameters.AddWithValue("@diachi", txtDiaChi.Text);
                            cmd.Parameters.AddWithValue("@mapb", txtMaPB.Text);
                            cmd.Parameters.AddWithValue("@macv", txtMaCV.Text);
                            cmd.Parameters.AddWithValue("@maluong", txtMaLuong.Text);
                            SqlDataReader reader = cmd.ExecuteReader();
                            DataTable table = new DataTable();
                            table.Load(reader);
                            dataGridView1.DataSource = table;
                            Hienthi();
                            if (con.State == ConnectionState.Open)
                                con.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn sửa nhân viên", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection(conn))
                {
                    try
                    {
                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        string query = "UPDATE NHANVIEN SET TenNV = @tennv, NgaySinh = @ngaysinh, GioiTinh = @gioitinh, " +
                            "QueQuan = @quequan, DiaChi = @diachi, MaPB = @mapb, MaCV = @macv, MaLuong = @maluong WHERE MaNV = @manv";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@manv", txtMaNV.Text);
                        cmd.Parameters.AddWithValue("@tennv", txtTenNV.Text);
                        cmd.Parameters.AddWithValue("@ngaysinh", dtpickerNS.Text);
                        cmd.Parameters.AddWithValue("@gioitinh", cbGioiTinh.Text);
                        cmd.Parameters.AddWithValue("@quequan", txtQueQuan.Text);
                        cmd.Parameters.AddWithValue("@diachi", txtDiaChi.Text);
                        cmd.Parameters.AddWithValue("@mapb", txtMaPB.Text);
                        cmd.Parameters.AddWithValue("@macv", txtMaCV.Text);
                        cmd.Parameters.AddWithValue("@maluong", txtMaLuong.Text);
                        SqlDataReader reader = cmd.ExecuteReader();
                        DataTable table = new DataTable();
                        table.Load(reader);
                        dataGridView1.DataSource = table;
                        Hienthi();
                        if (con.State == ConnectionState.Open)
                            con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn xóa nhân viên", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection(conn))
                {
                    try
                    {
                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        SqlCommand cmd = new SqlCommand("DELETE NHANVIEN WHERE MaNV = @manv", con);
                        cmd.Parameters.AddWithValue("@manv", txtMaNV.Text);
                        SqlDataReader reader = cmd.ExecuteReader();
                        DataTable table = new DataTable();
                        table.Load(reader);
                        dataGridView1.DataSource = table;
                        Hienthi();
                        if (con.State == ConnectionState.Open)
                            con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            txtMaNV.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtTenNV.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            dtpickerNS.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            cbGioiTinh.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            txtQueQuan.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            txtDiaChi.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            txtMaPB.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
            txtMaCV.Text = dataGridView1.Rows[i].Cells[7].Value.ToString();
            txtMaLuong.Text = dataGridView1.Rows[i].Cells[8].Value.ToString();
        }

        private void frmQLthongtinnv_Load(object sender, EventArgs e)
        {
            Hienthi();
        }
    }
}
