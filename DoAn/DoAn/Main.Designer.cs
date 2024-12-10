namespace DoAn
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnNhanvien = new System.Windows.Forms.Button();
            this.btnMathang = new System.Windows.Forms.Button();
            this.btnKhachang = new System.Windows.Forms.Button();
            this.btnThanhtoan = new System.Windows.Forms.Button();
            this.btnThuchi = new System.Windows.Forms.Button();
            this.vaitro = new System.Windows.Forms.Label();
            this.btnDangxuat = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNhanvien
            // 
            this.btnNhanvien.Location = new System.Drawing.Point(52, 38);
            this.btnNhanvien.Name = "btnNhanvien";
            this.btnNhanvien.Size = new System.Drawing.Size(108, 68);
            this.btnNhanvien.TabIndex = 0;
            this.btnNhanvien.Text = "QL Nhan Vien";
            this.btnNhanvien.UseVisualStyleBackColor = true;
            this.btnNhanvien.Click += new System.EventHandler(this.btnNhanvien_Click);
            // 
            // btnMathang
            // 
            this.btnMathang.Location = new System.Drawing.Point(209, 38);
            this.btnMathang.Name = "btnMathang";
            this.btnMathang.Size = new System.Drawing.Size(108, 68);
            this.btnMathang.TabIndex = 0;
            this.btnMathang.Text = "QL Mat Hang";
            this.btnMathang.UseVisualStyleBackColor = true;
            this.btnMathang.Click += new System.EventHandler(this.btnMathang_Click);
            // 
            // btnKhachang
            // 
            this.btnKhachang.Location = new System.Drawing.Point(366, 38);
            this.btnKhachang.Name = "btnKhachang";
            this.btnKhachang.Size = new System.Drawing.Size(108, 68);
            this.btnKhachang.TabIndex = 0;
            this.btnKhachang.Text = "QL Khach Hang";
            this.btnKhachang.UseVisualStyleBackColor = true;
            this.btnKhachang.Click += new System.EventHandler(this.btnKhachang_Click);
            // 
            // btnThanhtoan
            // 
            this.btnThanhtoan.Location = new System.Drawing.Point(523, 38);
            this.btnThanhtoan.Name = "btnThanhtoan";
            this.btnThanhtoan.Size = new System.Drawing.Size(108, 68);
            this.btnThanhtoan.TabIndex = 0;
            this.btnThanhtoan.Text = "Thanh Toan";
            this.btnThanhtoan.UseVisualStyleBackColor = true;
            this.btnThanhtoan.Click += new System.EventHandler(this.btnThanhtoan_Click);
            // 
            // btnThuchi
            // 
            this.btnThuchi.Location = new System.Drawing.Point(680, 38);
            this.btnThuchi.Name = "btnThuchi";
            this.btnThuchi.Size = new System.Drawing.Size(108, 68);
            this.btnThuchi.TabIndex = 0;
            this.btnThuchi.Text = "Thu chi";
            this.btnThuchi.UseVisualStyleBackColor = true;
            this.btnThuchi.Click += new System.EventHandler(this.btnThuchi_Click);
            // 
            // vaitro
            // 
            this.vaitro.AutoSize = true;
            this.vaitro.Location = new System.Drawing.Point(3, 9);
            this.vaitro.Name = "vaitro";
            this.vaitro.Size = new System.Drawing.Size(0, 16);
            this.vaitro.TabIndex = 1;
            // 
            // btnDangxuat
            // 
            this.btnDangxuat.Location = new System.Drawing.Point(818, 38);
            this.btnDangxuat.Name = "btnDangxuat";
            this.btnDangxuat.Size = new System.Drawing.Size(99, 39);
            this.btnDangxuat.TabIndex = 2;
            this.btnDangxuat.Text = "Dang xuat";
            this.btnDangxuat.UseVisualStyleBackColor = true;
            this.btnDangxuat.Click += new System.EventHandler(this.btnDangxuat_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(818, 83);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(99, 23);
            this.btnThoat.TabIndex = 2;
            this.btnThoat.Text = "Thoat";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 591);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnDangxuat);
            this.Controls.Add(this.vaitro);
            this.Controls.Add(this.btnThuchi);
            this.Controls.Add(this.btnThanhtoan);
            this.Controls.Add(this.btnKhachang);
            this.Controls.Add(this.btnMathang);
            this.Controls.Add(this.btnNhanvien);
            this.Name = "Main";
            this.Text = "Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNhanvien;
        private System.Windows.Forms.Button btnMathang;
        private System.Windows.Forms.Button btnKhachang;
        private System.Windows.Forms.Button btnThanhtoan;
        private System.Windows.Forms.Button btnThuchi;
        private System.Windows.Forms.Label vaitro;
        private System.Windows.Forms.Button btnDangxuat;
        private System.Windows.Forms.Button btnThoat;
    }
}