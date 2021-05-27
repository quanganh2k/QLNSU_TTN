using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlynhansu
{
    public partial class frmHuongdan : Form
    {
        public frmHuongdan()
        {
            InitializeComponent();
        }

        private void frmHuongdan_Load(object sender, EventArgs e)
        {
            treeview_ItemList.Nodes.Add("Mana Manag", "Quản lý thông tin");
            treeview_ItemList.Nodes["Mana Manag"].Nodes.Add("Quản lý nhân viên");
            treeview_ItemList.Nodes["Mana Manag"].Nodes.Add("Quản lý phòng ban");
            treeview_ItemList.Nodes["Mana Manag"].Nodes.Add("Quản lý chức vụ");
            treeview_ItemList.Nodes["Mana Manag"].Nodes.Add("Quản lý lương");
            

            treeview_ItemList.Nodes.Add("Search Manag", "Tìm kiếm");
            treeview_ItemList.Nodes["Search Manag"].Nodes.Add("Thông tin nhân viên");


            treeview_ItemList.Nodes.Add("Security", "Tài khoản và bảo mật");
            treeview_ItemList.Nodes["Security"].Nodes.Add("Quản lý tài khoản");
        }

        private void treeview_ItemList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            switch (e.Node.Text)
            {
                case "Quản lý nhân viên":                     
                    {
                        richtextbox_Display.ReadOnly = false;
                        richtextbox_Display.Text = File.ReadAllText(@"help\nhanvien.txt")+"\r\n";
                        Clipboard.SetImage(Image.FromFile(@"help\nhanvien.jpg"));
                        richtextbox_Display.AppendText("\n");
                        richtextbox_Display.Paste();
                        richtextbox_Display.ReadOnly = true;
                        break;
                    }
                case "Quản lý phòng ban":
                    {
                        richtextbox_Display.ReadOnly = false;
                        richtextbox_Display.Text = File.ReadAllText(@"help\phongban.txt") + "\r\n";
                        Clipboard.SetImage(Image.FromFile(@"help\phongban.jpg"));
                        richtextbox_Display.AppendText("\n");
                        richtextbox_Display.Paste();
                        richtextbox_Display.ReadOnly = true;
                        break;
                    }
                case "Quản lý chức vụ":
                    {
                        richtextbox_Display.ReadOnly = false;
                        richtextbox_Display.Text = File.ReadAllText(@"help\chucvu.txt") + "\r\n";
                        Clipboard.SetImage(Image.FromFile(@"help\chucvu.jpg"));
                        richtextbox_Display.AppendText("\n");
                        richtextbox_Display.Paste();
                        richtextbox_Display.ReadOnly = true;
                        break;
                    }
                case "Quản lý lương":
                    {
                        richtextbox_Display.ReadOnly = false;
                        richtextbox_Display.Text = File.ReadAllText(@"help\luong.txt") + "\r\n";
                        Clipboard.SetImage(Image.FromFile(@"help\luong.jpg"));
                        richtextbox_Display.AppendText("\n");
                        richtextbox_Display.Paste();
                        richtextbox_Display.ReadOnly = true;
                        break;
                    }
                case "Thông tin nhân viên":
                    {
                        richtextbox_Display.ReadOnly = false;
                        richtextbox_Display.Text = File.ReadAllText(@"help\tknhanvien.txt") + "\r\n";
                        Clipboard.SetImage(Image.FromFile(@"help\tknhanvien.jpg"));
                        richtextbox_Display.AppendText("\n");
                        richtextbox_Display.Paste();
                        richtextbox_Display.ReadOnly = true;
                        break;
                    }
                case "Quản lý tài khoản":
                    {
                        richtextbox_Display.ReadOnly = false;
                        richtextbox_Display.Text = File.ReadAllText(@"help\quanlytkhoan.txt") + "\r\n";
                        Clipboard.SetImage(Image.FromFile(@"help\quanlytkhoan.jpg"));
                        richtextbox_Display.AppendText("\n");
                        richtextbox_Display.Paste();
                        richtextbox_Display.ReadOnly = true;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
    }
}
