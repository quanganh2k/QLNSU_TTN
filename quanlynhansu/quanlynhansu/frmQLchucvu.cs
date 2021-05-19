using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlynhansu
{
    public partial class frmQLchucvu : Form
    {
        BindingSource CV = new BindingSource();
        public frmQLchucvu()
        {
            InitializeComponent();
            load();
            BindingCV();

        }



        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaCV.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập thông tin để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string macv = txtMaCV.Text;
                string query = string.Format("exec XoaCV '{0}'", macv);
                if (DataProvider.Instance.ExecuteNonQuery(query) > 0)
                {
                    MessageBox.Show("Xóa chức vụ thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    load();
                }
                else
                {
                    MessageBox.Show("Xóa chức vụ không thành công", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        void load()
        {
            string query = "Select MaCV as [Mã chức vụ],TenCV as [Tên chức vụ] from dbo.CHUCVU";
            dtgvChucVu.DataSource = CV;
            CV.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }


        void BindingCV()
        {
            txtMaCV.DataBindings.Add(new Binding("Text", dtgvChucVu.DataSource, "Mã chức vụ", true, DataSourceUpdateMode.Never));
            txtTenCV.DataBindings.Add(new Binding("Text", dtgvChucVu.DataSource, "Tên chức vụ", true, DataSourceUpdateMode.Never));
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaCV.Text == "" || txtTenCV.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try {
                    string tencv = txtTenCV.Text;
                    string macv = txtMaCV.Text;
                    string query = string.Format("insert into CHUCVU (MaCV,TenCV) values ('{0}',N'{1}')", macv, tencv);
                    if (DataProvider.Instance.ExecuteNonQuery(query) > 0)
                    {
                        MessageBox.Show("Thêm chức vụ thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        load();
                    }
                    else
                    {
                        MessageBox.Show("Thêm chức vụ không thành công", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                
                catch { MessageBox.Show("Trùng lặp mã chức vụ","Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error); }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtMaCV.Enabled = false;
            if (txtMaCV.Text == "" || txtTenCV.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                string tencv = txtTenCV.Text;
                string macv = txtMaCV.Text;
                string query = string.Format("update CHUCVU set TenCV = N'{0}' where MaCV = '{1}'",tencv,macv);
                if (DataProvider.Instance.ExecuteNonQuery(query) > 0)
                {
                    MessageBox.Show("Sửa chức vụ thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    load();
                }
                else
                {
                    MessageBox.Show("Sửa chức vụ không thành công", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
