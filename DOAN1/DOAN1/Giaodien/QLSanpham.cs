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
    public partial class QLSanpham : Form
    {
        public QLSanpham()
        {
            InitializeComponent();
        }

        private void Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new Model1())
                {
                    // Lấy các giá trị từ các trường nhập liệu
                    var sanPham = new SanPham
                    {
                        MaSP = int.Parse(txtMaSP.Text),  // Mã sản phẩm
                        TenSP = txtTenSP.Text,  // Tên sản phẩm
                        Gia = decimal.TryParse(txtGia.Text, out decimal gia) ? gia : (decimal?)null, // Giá sản phẩm
                        SoLuongTon = int.TryParse(txtSLT.Text, out int soLuongTon) ? soLuongTon : (int?)null, // Số lượng tồn
                        MaLoaiSP = (int)cbLoaiSP.SelectedValue,  // Loại sản phẩm
                    };

                    context.SanPhams.Add(sanPham);  // Thêm sản phẩm vào cơ sở dữ liệu
                    context.SaveChanges();  // Lưu thay đổi

                    MessageBox.Show("Thêm sản phẩm thành công!");
                    LoadData();  // Tải lại danh sách sản phẩm
                    ClearInputFields();  // Xóa các trường nhập liệu
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        private void QLSanpham_Load(object sender, EventArgs e)
        {
            try
            {
                var context = new Model1();

                var listSanPhams = context.SanPhams.Select(sp => new
                {
                    sp.MaSP,
                    sp.TenSP,
                    sp.Gia,
                    sp.SoLuongTon,
                    TenLoaiSP = sp.LoaiSP.TenLoaiSP
                }).ToList();

                dgvQLsp.DataSource = listSanPhams;

                var listLoaiSPs = context.LoaiSPs.ToList();
                FillLoaiSPCombobox(listLoaiSPs);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải form QLSanpham: " + ex.Message);
            }
        }
        private void FillLoaiSPCombobox(List<LoaiSP> listLoaiSPs)
        {
            cbLoaiSP.DataSource = listLoaiSPs;
            cbLoaiSP.DisplayMember = "TenLoaiSP";
            cbLoaiSP.ValueMember = "MaLoaiSP";
        }

        private void dgvQLsp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0) 
                {
                    DataGridViewRow row = dgvQLsp.Rows[e.RowIndex];
                    txtMaSP.Text = row.Cells["MaSP"].Value?.ToString();
                    txtTenSP.Text = row.Cells["TenSP"].Value?.ToString();
                    txtGia.Text = row.Cells["Gia"].Value?.ToString();
                    txtSLT.Text = row.Cells["SoLuongTon"].Value?.ToString();

                    string tenLoaiSP = row.Cells["TenLoaiSP"].Value?.ToString();
                    cbLoaiSP.SelectedIndex = cbLoaiSP.FindStringExact(tenLoaiSP);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvQLsp.CurrentRow != null)  // Kiểm tra nếu có dòng sản phẩm được chọn trong DataGridView
                {
                    int maSP = Convert.ToInt32(dgvQLsp.CurrentRow.Cells["MaSP"].Value);  // Lấy mã sản phẩm từ DataGridView

                    using (var context = new Model1())
                    {
                        var sanPham = context.SanPhams.FirstOrDefault(sp => sp.MaSP == maSP);  // Tìm sản phẩm theo mã sản phẩm

                        if (sanPham != null)
                        {
                            // Cập nhật thông tin sản phẩm
                            sanPham.TenSP = txtTenSP.Text;
                            sanPham.Gia = decimal.TryParse(txtGia.Text, out decimal gia) ? gia : sanPham.Gia;
                            sanPham.SoLuongTon = int.TryParse(txtSLT.Text, out int soLuongTon) ? soLuongTon : sanPham.SoLuongTon;
                            sanPham.MaLoaiSP = (int)cbLoaiSP.SelectedValue;

                            context.SaveChanges();  // Lưu thay đổi vào cơ sở dữ liệu

                            MessageBox.Show("Cập nhật thông tin sản phẩm thành công!");
                            LoadData();  // Tải lại danh sách sản phẩm

                            ClearInputFields();  // Xóa các trường nhập liệu
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy sản phẩm để sửa.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một sản phẩm để sửa.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }

        }

        private void Del_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvQLsp.CurrentRow != null)
                {
                    int maSP = Convert.ToInt32(dgvQLsp.CurrentRow.Cells["MaSP"].Value); 

                    using (var context = new Model1())
                    {
                        var sanPham = context.SanPhams.FirstOrDefault(sp => sp.MaSP == maSP);

                        if (sanPham != null)
                        {
                            context.SanPhams.Remove(sanPham);

                            context.SaveChanges();

                            MessageBox.Show("Xóa sản phẩm thành công!");
                            LoadData(); 
                            ClearInputFields(); 
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy sản phẩm để xóa.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một sản phẩm để xóa.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }
        private void LoadData()
        {
            using (var context = new Model1())
            {
                var listSanPhams = context.SanPhams
                    .Select(sp => new
                    {
                        sp.MaSP,            
                        sp.TenSP,          
                        sp.Gia,            
                        sp.SoLuongTon,      
                        TenLoaiSP = sp.LoaiSP.TenLoaiSP 
                    })
                    .ToList();

                dgvQLsp.DataSource = listSanPhams;
            }
        }
        private void ClearInputFields()
        {
            txtMaSP.Clear(); 
            txtTenSP.Clear();
            txtGia.Clear();  
            txtSLT.Clear(); 
            cbLoaiSP.SelectedIndex = -1; 
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();  // Lấy văn bản tìm kiếm và chuyển thành chữ thường

            try
            {
                using (var context = new Model1())
                {
                    var filteredList = context.SanPhams
                        .Where(sp => sp.TenSP.ToLower().Contains(searchText) ||  // Tìm kiếm theo tên sản phẩm
                                     sp.MaSP.ToString().Contains(searchText) ||  // Tìm kiếm theo mã sản phẩm
                                     sp.Gia.ToString().Contains(searchText) ||   // Tìm kiếm theo giá sản phẩm
                                     sp.SoLuongTon.ToString().Contains(searchText)) // Tìm kiếm theo số lượng tồn
                        .Select(sp => new
                        {
                            sp.MaSP,
                            sp.TenSP,
                            sp.Gia,
                            sp.SoLuongTon,
                            TenLoaiSP = sp.LoaiSP.TenLoaiSP // Thêm tên loại sản phẩm
                        }).ToList();

                    dgvQLsp.DataSource = filteredList;  // Cập nhật dữ liệu vào DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");  // Hiển thị thông báo lỗi nếu có
            }

        }

        private void QLSanpham_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
