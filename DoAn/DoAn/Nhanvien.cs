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
    public partial class Nhanvien : Form
    {
        public Nhanvien()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtTen_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (DGVQuanLyNV.Columns.Count == 0)
            {
                DGVQuanLyNV.Columns.Add("colMaNv", "Mã NV");
                DGVQuanLyNV.Columns.Add("colTen", "Tên");
                DGVQuanLyNV.Columns.Add("colGioiTinh", "Giới Tính");
                DGVQuanLyNV.Columns.Add("colDiaChi", "Địa Chỉ");
                DGVQuanLyNV.Columns.Add("colNgaySinh", "Ngày Sinh");
                DGVQuanLyNV.Columns.Add("colSDT", "Số Điện Thoại");
            }

            DGVQuanLyNV.DataSource = null;      
        }
        private int GetSelectedRow(string maNv)
        {
            for (int i = 0; i < DGVQuanLyNV.Rows.Count; i++)
            {
                if (DGVQuanLyNV.Rows[i].Cells[0].Value != null && DGVQuanLyNV.Rows[i].Cells[0].Value.ToString() == maNv)
                {
                    return i;
                }
            }
            return -1;
        }
        private void InsertUpdate(int selectedRow)
        {
            DGVQuanLyNV.Rows[selectedRow].Cells[0].Value = txtMaNv.Text;
            DGVQuanLyNV.Rows[selectedRow].Cells[1].Value = txtTen.Text;
            DGVQuanLyNV.Rows[selectedRow].Cells[2].Value = radNam.Checked ? "Nam" : "Nữ";
            DGVQuanLyNV.Rows[selectedRow].Cells[3].Value = txtDiachi.Text;
            DGVQuanLyNV.Rows[selectedRow].Cells[4].Value = Ngaysinh.Value.ToString("dd/MM/yyyy");
            DGVQuanLyNV.Rows[selectedRow].Cells[5].Value = SDT.Text;
        }

        private void DGVQuanLyNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaNv.Text == "" || txtTen.Text == "" || string.IsNullOrWhiteSpace(SDT.Text))
                    throw new Exception("Vui lòng nhập đầy đủ thông tin nhân viên");

                // Kiểm tra mã nhân viên có tồn tại chưa
                if (GetSelectedRow(txtMaNv.Text) != -1)
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại! Vui lòng nhập mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int selectedRow = GetSelectedRow(txtMaNv.Text);
                if (selectedRow == -1)
                {
                    int newRow = DGVQuanLyNV.Rows.Add();
                    InsertUpdate(newRow);
                    MessageBox.Show("Thêm mới dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    InsertUpdate(selectedRow);
                    MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtMaNv.Clear();
            txtTen.Clear();
            txtDiachi.Clear();
            SDT.Clear();
            radNam.Checked = false;
            radNu.Checked = false;
            Ngaysinh.Value = DateTime.Now;
        }

      

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedRow = GetSelectedRow(txtMaNv.Text);
                if (selectedRow == -1)
                {
                    MessageBox.Show("Không tìm thấy MaNV cần xóa!", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    DialogResult dr = MessageBox.Show("Bạn có muốn xóa?", "YES/NO", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        DGVQuanLyNV.Rows.RemoveAt(selectedRow);
                        MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DGVQuanLyNV_SelectionChanged(object sender, EventArgs e)
        {
            if (DGVQuanLyNV.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = DGVQuanLyNV.SelectedRows[0];

                txtMaNv.Text = selectedRow.Cells[0].Value?.ToString() ?? ""; 
                txtTen.Text = selectedRow.Cells[1].Value?.ToString() ?? ""; 
                txtDiachi.Text = selectedRow.Cells[3].Value?.ToString() ?? ""; 
                SDT.Text = selectedRow.Cells[5].Value?.ToString() ?? ""; 

                string gender = selectedRow.Cells[2].Value?.ToString() ?? "";
                radNam.Checked = gender == "Nam";
                radNu.Checked = gender == "Nữ";

                if (DateTime.TryParse(selectedRow.Cells[4].Value?.ToString(), out DateTime ngaySinh))
                {
                    Ngaysinh.Value = ngaySinh;
                }
                else
                {
                    Ngaysinh.Value = DateTime.Now; 
                }
            }
        }

        private void txtMaNv_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            // Lấy từ khóa tìm kiếm
            string keyword = txtFind.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(keyword))
            {
                return; // Không làm gì nếu từ khóa trống
            }

            // Duyệt qua từng hàng trong DataGridView
            foreach (DataGridViewRow row in DGVQuanLyNV.Rows)
            {
                // Bỏ qua dòng mới (uncommitted new row)
                if (row.IsNewRow)
                    continue;

                // Kiểm tra hàng có giá trị hay không
                if (row.Cells[0].Value != null && row.Cells[1].Value != null)
                {
                    // Lấy giá trị của cột Mã NV và Tên NV
                    string maNv = row.Cells[0].Value.ToString().ToLower();
                    string tenNv = row.Cells[1].Value.ToString().ToLower();

                    // Kiểm tra từ khóa có xuất hiện trong Mã NV hoặc Tên NV
                    row.Visible = maNv.Contains(keyword) || tenNv.Contains(keyword);
                }
                else
                {
                    row.Visible = false; // Ẩn hàng nếu ô dữ liệu null
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Hiển thị lại tất cả các hàng trong DataGridView
            foreach (DataGridViewRow row in DGVQuanLyNV.Rows)
            {
                row.Visible = true;
            }

            // Xóa nội dung trong ô tìm kiếm
            txtFind.Clear();
        }
    }

}
