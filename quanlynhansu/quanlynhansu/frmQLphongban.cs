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
    public partial class frmQLphongban : Form
    {
        public frmQLphongban()
        {
            InitializeComponent();
        }


        string constr = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=QLNHANSU;Integrated Security=True";
        void load()
        {
            using (SqlConnection sqlcon = new SqlConnection(constr))
            {
                sqlcon.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("Select mapb as N'Mã Phòng Ban', tenpb as N'Tên Phòng Ban' from phongban", sqlcon);
                DataTable dataTable = new DataTable();
                sqlData.Fill(dataTable);
                //dataGridView_khachhang.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.Fill);
                dataGridView1.DataSource = dataTable;
                
            }
        }

                private void frmQLphongban_Load(object sender, EventArgs e)
        {
            load();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlcon = new SqlConnection(constr))
            {
                sqlcon.Open();
                SqlCommand command = new SqlCommand("exec thempb N'"+txtMaPB.Text+"',N'"+txtTenPB.Text+"'", sqlcon);
                sqlcon.InfoMessage += new SqlInfoMessageEventHandler(InfoMessageHandler);
                command.ExecuteNonQuery();

            }
            load();
        }
        public static void InfoMessageHandler(object mySender, SqlInfoMessageEventArgs myEvent)
        {
            MessageBox.Show(myEvent.Message);
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                txtMaPB.Text = row.Cells[0].Value.ToString();
                macu= row.Cells[0].Value.ToString();
                txtTenPB.Text = row.Cells[1].Value.ToString();
            }
            
        }
        string macu;
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (macu == "")
                MessageBox.Show("Chưa chọn mã phòng ban, mời chọn lại bằng click chuột từ danh sách", "Cảnh báo");
            else
            {
                using (SqlConnection sqlcon = new SqlConnection(constr))
                {
                    sqlcon.Open();
                    SqlCommand command = new SqlCommand("exec suapb N'" + txtMaPB.Text + "',N'" + txtTenPB.Text + "',N'"+macu + "'", sqlcon);
                    sqlcon.InfoMessage += new SqlInfoMessageEventHandler(InfoMessageHandler);
                    command.ExecuteNonQuery();

                }
                load();
                macu = "";
            }    
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            
            using (SqlConnection sqlcon = new SqlConnection(constr))
            {
                sqlcon.Open();
                SqlCommand command = new SqlCommand("exec xoapb N'" + txtMaPB.Text + "',N'" + txtTenPB.Text + "'", sqlcon);
                sqlcon.InfoMessage += new SqlInfoMessageEventHandler(InfoMessageHandler);
                command.ExecuteNonQuery();

            }
            load();
        }
    }
}
