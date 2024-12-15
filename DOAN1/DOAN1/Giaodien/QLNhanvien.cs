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
    public partial class QLNhanvien : Form
    {
        public QLNhanvien()
        {
            InitializeComponent();
        }

        private void QLNhanvien_Load(object sender, EventArgs e)
        {
            try {
                var context = new Model1();

                var listNhanviens = context.NhanViens.Select(nv => new { 
                    nv.MaNV,
                    nv.TenNV,
                    nv.GioiTinh,
                    nv.NgaySinh,
                    nv.SDT,
                    nv.DiaChi,
                    nv.NgayVaoLam,
                    nv.TaiKhoan,
                    nv.MatKhau,
                    Tenchucvu = nv.ChucVu1.TenChucVu
                }).ToList();
                dgvQLnv.DataSource = listNhanviens;
                var listChucvus = context.ChucVus.ToList();
                FillChucvuCombobox(listChucvus);
            } catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FillChucvuCombobox(List<ChucVu> listChucvus)
        {
            cbchucvu.DataSource = listChucvus;
            cbchucvu.DisplayMember = "TenChucvu";
            cbchucvu.ValueMember = "MaChucvu";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0) 
                {
                    DataGridViewRow row = dgvQLnv.Rows[e.RowIndex];

                    txtManv.Text = row.Cells["MaNV"].Value?.ToString();
                    txtTennv.Text = row.Cells["TenNV"].Value?.ToString();
                    txtDC.Text = row.Cells["DiaChi"].Value?.ToString();
                    txttk.Text = row.Cells["TaiKhoan"].Value?.ToString();
                    txtmk.Text = row.Cells["MatKhau"].Value?.ToString();

                    maskedSDT.Text = row.Cells["SDT"].Value?.ToString();

                    datebirth.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);
                    dateworking.Value = Convert.ToDateTime(row.Cells["NgayVaoLam"].Value);

                    string gioiTinh = row.Cells["GioiTinh"].Value?.ToString();
                    if (gioiTinh == "Nam")
                    {
                        radnam.Checked = true;
                        radnu.Checked = false;
                    }
                    else if (gioiTinh == "Nữ")
                    {
                        radnu.Checked = true;
                        radnam  .Checked = false;
                    }

                    string tenChucVu = row.Cells["TenChucVu"].Value?.ToString();
                    cbchucvu.SelectedIndex = cbchucvu.FindStringExact(tenChucVu);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new Model1())
                {
                    string gioiTinh = radnam.Checked ? "Nam" : "Nữ";

                    var nhanVien = new NhanVien
                    {
                        MaNV = int.Parse(txtManv.Text), 
                        TenNV = txtTennv.Text,
                        GioiTinh = gioiTinh, 
                        NgaySinh = datebirth.Value, 
                        SDT = maskedSDT.Text, 
                        DiaChi = txtDC.Text, 
                        NgayVaoLam = dateworking.Value, 
                        TaiKhoan = txttk.Text, 
                        MatKhau = txtmk.Text, 
                        ChucVu = (int)cbchucvu.SelectedValue 
                    };

                    context.NhanViens.Add(nhanVien);
                    context.SaveChanges();

                    MessageBox.Show("Thêm nhân viên thành công!");
                    LoadData(); 
                    ClearInputFields();
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
                var listNhanviens = context.NhanViens
                    .Select(nv => new
                    {
                        nv.MaNV,
                        nv.TenNV,
                        nv.GioiTinh,
                        nv.NgaySinh,
                        nv.SDT,
                        nv.DiaChi,
                        nv.NgayVaoLam,
                        nv.TaiKhoan,
                        nv.MatKhau,
                        Tenchucvu = nv.ChucVu1.TenChucVu
                    }).ToList();

                dgvQLnv.DataSource = listNhanviens;
            }
        }

        private void Del_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvQLnv.CurrentRow != null) 
                {
                    int maNV = Convert.ToInt32(dgvQLnv.CurrentRow.Cells["MaNV"].Value);

                    using (var context = new Model1())
                    {
                        var nhanVien = context.NhanViens.FirstOrDefault(nv => nv.MaNV == maNV);

                        if (nhanVien != null)
                        {
                            context.NhanViens.Remove(nhanVien);
                            context.SaveChanges();

                            MessageBox.Show("Xóa nhân viên thành công!");
                            LoadData();

                            ClearInputFields();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy nhân viên để xóa.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một nhân viên để xóa.");
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
                if (dgvQLnv.CurrentRow != null) 
                {
                    int maNV = Convert.ToInt32(dgvQLnv.CurrentRow.Cells["MaNV"].Value);

                    using (var context = new Model1())
                    {
                        var nhanVien = context.NhanViens.FirstOrDefault(nv => nv.MaNV == maNV);

                        if (nhanVien != null)
                        {
                            nhanVien.TenNV = txtTennv.Text;
                            nhanVien.GioiTinh = radnam.Checked ? "Nam" : "Nữ"; 
                            nhanVien.NgaySinh = datebirth.Value;
                            nhanVien.SDT = maskedSDT.Text; 
                            nhanVien.DiaChi = txtDC.Text; 
                            nhanVien.NgayVaoLam = dateworking.Value;
                            nhanVien.TaiKhoan = txttk.Text; 
                            nhanVien.MatKhau = txtmk.Text; 
                            nhanVien.ChucVu = (int)cbchucvu.SelectedValue;

                            context.SaveChanges();

                            MessageBox.Show("Cập nhật thông tin nhân viên thành công!");
                            LoadData();

                            ClearInputFields();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy nhân viên để sửa.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một nhân viên để sửa.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }
        private void ClearInputFields()
        {   
            txtManv.Clear();
            txtTennv.Clear();
            radnam.Checked = false;
            radnu.Checked = false;
            datebirth.Value = DateTime.Now;
            maskedSDT.Clear();
            txtDC.Clear();
            dateworking.Value = DateTime.Now;
            txttk.Clear();
            txtmk.Clear();
            cbchucvu.SelectedIndex = -1; 
        }

        private void dgvQLnv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0) 
                {
                    DataGridViewRow row = dgvQLnv.Rows[e.RowIndex];

                    txtManv.Text = row.Cells["MaNV"].Value?.ToString();
                    txtTennv.Text = row.Cells["TenNV"].Value?.ToString();
                    txtDC.Text = row.Cells["DiaChi"].Value?.ToString();
                    txttk.Text = row.Cells["TaiKhoan"].Value?.ToString();
                    txtmk.Text = row.Cells["MatKhau"].Value?.ToString();
                    maskedSDT.Text = row.Cells["SDT"].Value?.ToString();
                    datebirth.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);
                    dateworking.Value = Convert.ToDateTime(row.Cells["NgayVaoLam"].Value);

                    string gioiTinh = row.Cells["GioiTinh"].Value?.ToString();
                    if (gioiTinh == "Nam")
                    {
                        radnam.Checked = true;
                        radnu.Checked = false;
                    }
                    else if (gioiTinh == "Nữ")
                    {
                        radnu.Checked = true;
                        radnam.Checked = false;
                    }
                    string tenChucVu = row.Cells["TenChucVu"].Value?.ToString();
                    cbchucvu.SelectedIndex = cbchucvu.FindStringExact(tenChucVu);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        private void QLNhanvien_Click(object sender, EventArgs e)
        {
            ClearInputFields();
        }

        private void txtSeacrh_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower(); 

            try
            {
                using (var context = new Model1())
                {
                    var filteredList = context.NhanViens
                        .Where(nv => nv.TenNV.ToLower().Contains(searchText) ||
                                     nv.MaNV.ToString().Contains(searchText) ||
                                     nv.SDT.ToLower().Contains(searchText) ||
                                     nv.DiaChi.ToLower().Contains(searchText))
                        .Select(nv => new
                        {
                            nv.MaNV,
                            nv.TenNV,
                            nv.GioiTinh,
                            nv.NgaySinh,
                            nv.SDT,
                            nv.DiaChi,
                            nv.NgayVaoLam,
                            nv.TaiKhoan,
                            nv.MatKhau,
                            Tenchucvu = nv.ChucVu1.TenChucVu
                        }).ToList();

                    dgvQLnv.DataSource = filteredList;
                }
            }
            catch (Exception ex)
            {
            }
        }


        private void QLNhanvien_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
