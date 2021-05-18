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
    public partial class frmQLluong : Form
    {
        void init()
        {
            string query =  "Select MaLuong as 'Mã Lương', BacLuong as 'Bậc Lương', LuongCB as 'Lương Cơ Bản'" +
                            " From LUONG" +
                            " Order by CONVERT(int, right(MaLuong, len(MaLuong)-2)) asc";
            dgv_List.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }
        public frmQLluong()
        {
            InitializeComponent();
        }

        private void frmQLluong_Load(object sender, EventArgs e)
        {
            init();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaLuong.Text != "")
            {
                string query = "Insert into LUONG(MaLuong, BacLuong, LuongCB)" +
                                "Values('" + txtMaLuong.Text +
                                "'," + Int32.Parse(txtBacLuong.Text) +
                                "," + double.Parse(txtLuongCB.Text) + ")";
                if (DataProvider.Instance.ExecuteNonQuery(query) > 0)
                {
                    MessageBox.Show("Thêm lương thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    init();
                }
                else
                    MessageBox.Show("Đã xảy ra lỗi", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Bạn chưa điền mã lương", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaLuong.Text != "")
            {
                string query = "Update LUONG " +
                                "Set BacLuong = " + Int32.Parse(txtBacLuong.Text) + "," +
                                "LuongCB = " + double.Parse(txtLuongCB.Text) +
                                "Where MaLuong = '" + txtMaLuong.Text + "'";
                if (DataProvider.Instance.ExecuteNonQuery(query) > 0)
                {
                    MessageBox.Show("Cập nhật lương thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    init();
                }
                else
                    MessageBox.Show("Đã xảy ra lỗi", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Bạn chưa chọn đối tượng để sửa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaLuong.Text != "")
            {
                string query = "Delete From LUONG " +
                                "Where MaLuong = '" + txtMaLuong.Text + "'";
                string info = txtMaLuong.Text + "  |  " + txtBacLuong.Text + "  |  " + txtLuongCB.Text;
                DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa thông tin này ?\n" + info, "Xóa Lương", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    if (DataProvider.Instance.ExecuteNonQuery(query) > 0)
                    {
                        MessageBox.Show("Xóa lương thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        init();
                    }
                    else
                        MessageBox.Show("Đã xảy ra lỗi", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }    
            }
            else
                MessageBox.Show("Bạn chưa chọn đối tượng để xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgv_List_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaLuong.Text = dgv_List.CurrentRow.Cells[0].Value.ToString();
            txtBacLuong.Text = dgv_List.CurrentRow.Cells[1].Value.ToString();
            txtLuongCB.Text = dgv_List.CurrentRow.Cells[2].Value.ToString();
        }
    }
}
