using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DOAN1.Database;

namespace DOAN1.Giaodien
{
    public partial class Dangnhap : Form
    {
        public Dangnhap()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Dangnhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void DN_Click(object sender, EventArgs e)
        {

            string username = txtUser.Text.Trim(); // Tài khoản
            string password = txtPass.Text.Trim(); // Mật khẩu

            using (var context = new Model1()) // Khởi tạo context để kết nối với cơ sở dữ liệu
            {
                // Truy vấn nhân viên trong cơ sở dữ liệu để kiểm tra tài khoản và mật khẩu
                var user = context.NhanViens
                    .Where(nv => nv.TaiKhoan == username && nv.MatKhau == password)
                    .FirstOrDefault(); // Lấy nhân viên có tài khoản và mật khẩu khớp

                if (user != null) // Nếu tài khoản và mật khẩu hợp lệ
                {
                    // Lấy thông tin chức vụ của nhân viên từ bảng ChucVu
                    var chucVu = user.ChucVu1; // ChucVu1 là đối tượng chứa thông tin chức vụ

                    if (chucVu != null)
                    {
                        string role = chucVu.TenChucVu; // Lấy tên chức vụ

                        if (role == "Admin")
                        {
                            MessageBox.Show("Đăng nhập thành công với quyền Admin!");
                            // Mở Form Main với quyền Admin
                            MainForm mainForm = new MainForm("Admin");
                            mainForm.Show();
                            this.Hide(); // Ẩn form đăng nhập
                        }
                        else if (role == "Nhân viên bán hàng")
                        {
                            MessageBox.Show("Đăng nhập thành công với quyền Nhân viên bán hàng!");
                            // Mở Form Main với quyền Nhân viên bán hàng
                            MainForm mainForm = new MainForm("Nhân viên bán hàng");
                            mainForm.Show();
                            this.Hide(); // Ẩn form đăng nhập
                        }
                        else
                        {
                            lblMess.Text = "Chức vụ không xác định!";
                        }
                    }
                    else
                    {
                        lblMess.Text = "Không tìm thấy chức vụ của người dùng.";
                    }
                }
                else
                {
                    lblMess.Text = "Tài khoản hoặc mật khẩu không đúng!";
                }
            }
        }
    }
}
