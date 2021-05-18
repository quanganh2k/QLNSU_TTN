using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlynhansu
{
    public partial class frmTimKiem : Form
    {
        String ConnectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=QLNHANSU;Integrated Security=True";
        public frmTimKiem()
        {
            InitializeComponent();
            load();
        }
        DataTable ExecuteQuery(string query, object[] parameter = null)
        {

            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {

                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] temp = query.Split(' ');
                    List<string> listPara = new List<string>();
                    foreach (string item in temp)
                    {
                        if (item[0] == '@')
                            listPara.Add(item);
                    }
                    for (int i = 0; i < parameter.Length; i++)
                    {
                        command.Parameters.AddWithValue(listPara[i], parameter[i]);
                    }
                }
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(data);
                }
                catch { }

                connection.Close();
            }
            return data;
        }
        // trả về 1 data table  gọi trong phương thức xem, lấy dữ liệu qua câu truy vấn
        int ExecuteNonQuery(string query, object[] parameter = null)
        {

            int acceptedRows = 0;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {

                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    if (parameter != null)
                    {
                        string[] temp = query.Split(' ');
                        List<string> listPara = new List<string>();
                        foreach (string item in temp)
                        {
                            if (item[0] == '@')
                                listPara.Add(item);
                        }
                        for (int i = 0; i < parameter.Length; i++)
                        {
                            command.Parameters.AddWithValue(listPara[i], parameter[i]);
                        }
                    }
                    //thực thi câu query chả về số dòng câu truy vấn thực hiện được
                    acceptedRows = -1;

                    acceptedRows = command.ExecuteNonQuery();
                }
                catch { MessageBox.Show("Nhập Sai!!!"); }
                connection.Close();
            }

            return acceptedRows;
        }
        // trả về kiểu int, gọi trong phương thức thêm và xoá, kiểu int là số dòng  thực thi thay dổi database
        public void load()
        {
            string que = "Select * from NHANVIEN";
            dataGridView1.DataSource = ExecuteQuery(que);
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            //tim kiem
            string que = "";
            if(rdbtnMaNV.Checked == false && rdbtnTenNV.Checked == false)
            {
                MessageBox.Show("Chọn Trường Cần Tìm Kiếm");
                return;
            }
            if(rdbtnMaNV.Checked == true)
            {
                que = "select * from NHANVIEN where MaNV like N'%" + txtTimKiemNV.Text + "%'";
                dataGridView1.DataSource = ExecuteQuery(que);
            }
            if (rdbtnTenNV.Checked == true)
            {
                que = "select * from NHANVIEN where TenNV like N'%" + txtTimKiemNV.Text + "%'";
                dataGridView1.DataSource = ExecuteQuery(que);
            }
            if (dataGridView1.RowCount == 1) MessageBox.Show("Không Có Tìm Kiếm Phù Hợp");
        }
    }
}
