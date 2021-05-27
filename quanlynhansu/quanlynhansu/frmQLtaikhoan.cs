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
    public partial class frmQLtaikhoan : Form
    {
        public frmQLtaikhoan()
        {
            InitializeComponent();
            LoadInformation();
        }
        //string connectionStr = @"Data Source=DESKTOP-53IQ0S1\SQLEXPRESS;Initial Catalog=QLNHANSU;Integrated Security=True";
        string connectionStr = DataProvider.connectionSTR;


       
        

        private void ClearDL()
        {
            txtTenDangNhap.Text = "";
            txtMatKhau.Text = "";
        }


        DataTable ExecuteQuery(string query, object[] parameter = null)
        {

            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionStr))
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

            using (SqlConnection connection = new SqlConnection(connectionStr))
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
                catch { MessageBox.Show("Lỗi Dữ Liệu"); }
                connection.Close();
            }

            return acceptedRows;
        }
        // trả về kiểu int, gọi trong phương thức thêm và xoá, kiểu int là số dòng  thực thi thay dổi database




        private void LoadInformation()
        {
            SqlConnection connection = new SqlConnection(connectionStr);
            string query = "select * from TAIKHOAN";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connection.Close();
            datagridTk.DataSource = data;



        }
        private void TK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = datagridTk.CurrentRow.Index;
            txtTenDangNhap.Text = datagridTk.Rows[i].Cells[0].Value.ToString();
            txtMatKhau.Text = datagridTk.Rows[i].Cells[1].Value.ToString();
            


           


        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(txtTenDangNhap.Text != "")
            {
                if(txtMatKhau.Text != "")
                {
                    string tdn = txtTenDangNhap.Text;
                    string mk = txtMatKhau.Text;
                    string query = @"insert into TAIKHOAN values ('"+tdn.ToString()+"', '"+mk.ToString()+"')";
                    int i = -1;
                    i = ExecuteNonQuery(query);
                    if (i != -1)
                    {
                        MessageBox.Show("Đã Thêm Thành Công!");


                        LoadInformation();
                        ClearDL();
                    }
                    else
                    {
                        MessageBox.Show("Thêm Không Thành Công!");
                    }

                }
                else
                {
                    MessageBox.Show("Bạn chưa nhập mật khẩu");
                }    
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập tên đăng nhập");
            }    
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            if (txtTenDangNhap.Text != "")
            {
                if (txtMatKhau.Text != "")
                {
                    string tdn = txtTenDangNhap.Text;
                    string mk = txtMatKhau.Text;
                    string query = @"update  TAIKHOAN set username ='" + tdn.ToString() + "',pw = '" + mk.ToString() + "'where username = '" + tdn.ToString() + "'";
                    int i = -1;
                    i = ExecuteNonQuery(query);
                    if (i != -1)
                    {
                        MessageBox.Show("Đã Sửa Thành Công!");


                        LoadInformation();
                        ClearDL();
                    }
                    else
                    {
                        MessageBox.Show("Sửa Không Thành Công!");
                    }

                }
                else
                {
                    MessageBox.Show("Bạn chưa nhập mật khẩu");
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập tên đăng nhập");
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string tdn = txtTenDangNhap.Text;
                string mk = txtMatKhau.Text;
                string query = @"delete from  TAIKHOAN   where username =  '" + tdn.ToString() + "'";
                    int i = -1;
                    i = ExecuteNonQuery(query);
                    if (i != -1)
                    {
                        MessageBox.Show("Đã Xóa Thành Công!");


                        LoadInformation();
                        ClearDL();
                    }


                }
                else
                {
                    MessageBox.Show(" Xóa Không Thành Công!");
                }
            }
        }
    }

