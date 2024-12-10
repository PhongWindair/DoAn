using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn
{
    public partial class Main : Form
    {
        private string Roles;
        public Main(string roles)
        {
            InitializeComponent();
            Roles = roles;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            vaitro.Text = Roles;
            if (Roles == "Nhân viên")
            {
                btnNhanvien.Visible = false;  
                btnThuchi.Visible = false; 
            }
        }

        private void btnThuchi_Click(object sender, EventArgs e)
        {

        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void btnThanhtoan_Click(object sender, EventArgs e)
        {

        }

        private void btnNhanvien_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Nhanvien"] != null)
            {
                MessageBox.Show("Form Nhân viên đang mở!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Nhanvien nhanVienForm = new Nhanvien();
            btnNhanvien.Enabled = false;
            nhanVienForm.Show();
            nhanVienForm.FormClosed += (s, args) => btnNhanvien.Enabled = true;
        }

        private void btnMathang_Click(object sender, EventArgs e)
        {

        }

        private void btnKhachang_Click(object sender, EventArgs e)
        {

        }

        private void btnDangxuat_Click(object sender, EventArgs e)
        {
            Dangnhap dangnhap = new Dangnhap();
            dangnhap.Show();
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
