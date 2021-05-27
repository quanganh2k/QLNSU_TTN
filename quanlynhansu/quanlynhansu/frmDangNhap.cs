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
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();

        }
        

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            //string connectionStr = @"Data Source=DESKTOP-53IQ0S1\SQLEXPRESS;Initial Catalog=QLNHANSU;Integrated Security=True";
            string connectionStr = DataProvider.connectionSTR;
            SqlConnection connection = new SqlConnection(connectionStr);
            connection.Open();
            string tk = txtTenDangNhap.Text;
            string mk = txtMatKhau.Text;
            string query = "select * from TAIKHOAN where Username = '" + tk + "' and PW = '" + mk + "'";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader data = command.ExecuteReader();
            if(data.Read() == true)
            {
                txtTenDangNhap.Text = "";
                txtMatKhau.Text = "";
                frmTrangChu f = new frmTrangChu();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác");
            }
            connection.Close();

        }
    }
}
