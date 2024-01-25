
namespace DuAn_QuanLyKPI.GUI
{
    partial class FrmPhanQuyen
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbQuanLyNguoiDung = new System.Windows.Forms.CheckBox();
            this.cbNganHangKPI = new System.Windows.Forms.CheckBox();
            this.cbKiemDuyetBieuMau = new System.Windows.Forms.CheckBox();
            this.cbDanhMucKPI = new System.Windows.Forms.CheckBox();
            this.cbCaNhan = new System.Windows.Forms.CheckBox();
            this.cbCaiDatHethong = new System.Windows.Forms.CheckBox();
            this.cbBieuMauKPI = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgrDanhSachNguoiDung = new System.Windows.Forms.DataGridView();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cHoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMaNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTenDanhNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMaQuyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cChiTiet = new System.Windows.Forms.DataGridViewImageColumn();
            this.cboChucDanh = new ControlProject1510.ComboBoxSearch();
            this.cbChonTatCa = new System.Windows.Forms.CheckBox();
            this.cbBoChonTatCa = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrDanhSachNguoiDung)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgrDanhSachNguoiDung);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(440, 499);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbBoChonTatCa);
            this.panel2.Controls.Add(this.cbChonTatCa);
            this.panel2.Controls.Add(this.btnSua);
            this.panel2.Controls.Add(this.btnLuu);
            this.panel2.Controls.Add(this.cbQuanLyNguoiDung);
            this.panel2.Controls.Add(this.cbNganHangKPI);
            this.panel2.Controls.Add(this.cbKiemDuyetBieuMau);
            this.panel2.Controls.Add(this.cbDanhMucKPI);
            this.panel2.Controls.Add(this.cbCaNhan);
            this.panel2.Controls.Add(this.cbCaiDatHethong);
            this.panel2.Controls.Add(this.cbBieuMauKPI);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(440, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(383, 499);
            this.panel2.TabIndex = 28;
            this.panel2.Visible = false;
            // 
            // cbQuanLyNguoiDung
            // 
            this.cbQuanLyNguoiDung.AutoSize = true;
            this.cbQuanLyNguoiDung.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbQuanLyNguoiDung.Location = new System.Drawing.Point(78, 257);
            this.cbQuanLyNguoiDung.Name = "cbQuanLyNguoiDung";
            this.cbQuanLyNguoiDung.Size = new System.Drawing.Size(250, 35);
            this.cbQuanLyNguoiDung.TabIndex = 22;
            this.cbQuanLyNguoiDung.Text = "Quản lý người dùng";
            this.cbQuanLyNguoiDung.UseVisualStyleBackColor = true;
            // 
            // cbNganHangKPI
            // 
            this.cbNganHangKPI.AutoSize = true;
            this.cbNganHangKPI.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNganHangKPI.Location = new System.Drawing.Point(78, 134);
            this.cbNganHangKPI.Name = "cbNganHangKPI";
            this.cbNganHangKPI.Size = new System.Drawing.Size(198, 35);
            this.cbNganHangKPI.TabIndex = 21;
            this.cbNganHangKPI.Text = "Ngân hàng KPI";
            this.cbNganHangKPI.UseVisualStyleBackColor = true;
            // 
            // cbKiemDuyetBieuMau
            // 
            this.cbKiemDuyetBieuMau.AutoSize = true;
            this.cbKiemDuyetBieuMau.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbKiemDuyetBieuMau.Location = new System.Drawing.Point(78, 216);
            this.cbKiemDuyetBieuMau.Name = "cbKiemDuyetBieuMau";
            this.cbKiemDuyetBieuMau.Size = new System.Drawing.Size(266, 35);
            this.cbKiemDuyetBieuMau.TabIndex = 20;
            this.cbKiemDuyetBieuMau.Text = "Kiểm duyệt biểu mẫu";
            this.cbKiemDuyetBieuMau.UseVisualStyleBackColor = true;
            // 
            // cbDanhMucKPI
            // 
            this.cbDanhMucKPI.AutoSize = true;
            this.cbDanhMucKPI.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDanhMucKPI.Location = new System.Drawing.Point(78, 93);
            this.cbDanhMucKPI.Name = "cbDanhMucKPI";
            this.cbDanhMucKPI.Size = new System.Drawing.Size(194, 35);
            this.cbDanhMucKPI.TabIndex = 19;
            this.cbDanhMucKPI.Text = "Danh mục KPI";
            this.cbDanhMucKPI.UseVisualStyleBackColor = true;
            // 
            // cbCaNhan
            // 
            this.cbCaNhan.AutoSize = true;
            this.cbCaNhan.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCaNhan.Location = new System.Drawing.Point(78, 52);
            this.cbCaNhan.Name = "cbCaNhan";
            this.cbCaNhan.Size = new System.Drawing.Size(124, 35);
            this.cbCaNhan.TabIndex = 18;
            this.cbCaNhan.Text = "Cá nhân";
            this.cbCaNhan.UseVisualStyleBackColor = true;
            // 
            // cbCaiDatHethong
            // 
            this.cbCaiDatHethong.AutoSize = true;
            this.cbCaiDatHethong.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCaiDatHethong.Location = new System.Drawing.Point(78, 298);
            this.cbCaiDatHethong.Name = "cbCaiDatHethong";
            this.cbCaiDatHethong.Size = new System.Drawing.Size(213, 35);
            this.cbCaiDatHethong.TabIndex = 17;
            this.cbCaiDatHethong.Text = "Cài đặt hệ thống";
            this.cbCaiDatHethong.UseVisualStyleBackColor = true;
            // 
            // cbBieuMauKPI
            // 
            this.cbBieuMauKPI.AutoSize = true;
            this.cbBieuMauKPI.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBieuMauKPI.Location = new System.Drawing.Point(78, 175);
            this.cbBieuMauKPI.Name = "cbBieuMauKPI";
            this.cbBieuMauKPI.Size = new System.Drawing.Size(186, 35);
            this.cbBieuMauKPI.TabIndex = 16;
            this.cbBieuMauKPI.Text = "Biểu mẫu KPI";
            this.cbBieuMauKPI.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(34, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(225, 36);
            this.label4.TabIndex = 15;
            this.label4.Text = "Tên chức năng ";
            // 
            // btnLuu
            // 
            this.btnLuu.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Location = new System.Drawing.Point(95, 428);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 43);
            this.btnLuu.TabIndex = 23;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click_1);
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(176, 428);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 43);
            this.btnSua.TabIndex = 24;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cboChucDanh);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.btnTimKiem);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(440, 45);
            this.panel3.TabIndex = 0;
            // 
            // dgrDanhSachNguoiDung
            // 
            this.dgrDanhSachNguoiDung.AllowUserToAddRows = false;
            this.dgrDanhSachNguoiDung.AllowUserToDeleteRows = false;
            this.dgrDanhSachNguoiDung.AllowUserToOrderColumns = true;
            this.dgrDanhSachNguoiDung.AllowUserToResizeColumns = false;
            this.dgrDanhSachNguoiDung.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.dgrDanhSachNguoiDung.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgrDanhSachNguoiDung.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgrDanhSachNguoiDung.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrDanhSachNguoiDung.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgrDanhSachNguoiDung.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrDanhSachNguoiDung.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cHoTen,
            this.cMaNV,
            this.cTenDanhNhap,
            this.cMaQuyen,
            this.cChiTiet});
            this.dgrDanhSachNguoiDung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrDanhSachNguoiDung.Location = new System.Drawing.Point(0, 45);
            this.dgrDanhSachNguoiDung.Name = "dgrDanhSachNguoiDung";
            this.dgrDanhSachNguoiDung.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrDanhSachNguoiDung.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgrDanhSachNguoiDung.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgrDanhSachNguoiDung.RowTemplate.Height = 40;
            this.dgrDanhSachNguoiDung.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrDanhSachNguoiDung.Size = new System.Drawing.Size(440, 454);
            this.dgrDanhSachNguoiDung.TabIndex = 12;
            this.dgrDanhSachNguoiDung.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgrDanhSachNguoiDung_CellMouseClick);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.Location = new System.Drawing.Point(296, 8);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(127, 30);
            this.btnTimKiem.TabIndex = 1;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Chức danh";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // cHoTen
            // 
            this.cHoTen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cHoTen.DataPropertyName = "TenNV";
            this.cHoTen.HeaderText = "Họ tên";
            this.cHoTen.Name = "cHoTen";
            this.cHoTen.ReadOnly = true;
            // 
            // cMaNV
            // 
            this.cMaNV.DataPropertyName = "MaNV";
            this.cMaNV.HeaderText = "Mã NV";
            this.cMaNV.Name = "cMaNV";
            this.cMaNV.ReadOnly = true;
            this.cMaNV.Visible = false;
            // 
            // cTenDanhNhap
            // 
            this.cTenDanhNhap.DataPropertyName = "TenTaiKhoan";
            this.cTenDanhNhap.HeaderText = "Tên đăng nhập";
            this.cTenDanhNhap.Name = "cTenDanhNhap";
            this.cTenDanhNhap.ReadOnly = true;
            this.cTenDanhNhap.Width = 150;
            // 
            // cMaQuyen
            // 
            this.cMaQuyen.DataPropertyName = "MaQuyen";
            this.cMaQuyen.HeaderText = "Mã quyền";
            this.cMaQuyen.Name = "cMaQuyen";
            this.cMaQuyen.ReadOnly = true;
            this.cMaQuyen.Visible = false;
            // 
            // cChiTiet
            // 
            this.cChiTiet.HeaderText = "Chi tiết";
            this.cChiTiet.Name = "cChiTiet";
            this.cChiTiet.ReadOnly = true;
            this.cChiTiet.Width = 50;
            // 
            // cboChucDanh
            // 
            this.cboChucDanh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboChucDanh.AutoComplete = false;
            this.cboChucDanh.AutoDropdown = false;
            this.cboChucDanh.BackColorEven = System.Drawing.Color.White;
            this.cboChucDanh.BackColorOdd = System.Drawing.Color.White;
            this.cboChucDanh.ColumnNames = "TenQuyen";
            this.cboChucDanh.ColumnWidthDefault = 150;
            this.cboChucDanh.ColumnWidths = "";
            this.cboChucDanh.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboChucDanh.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboChucDanh.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboChucDanh.FormattingEnabled = true;
            this.cboChucDanh.LinkedColumnIndex = 0;
            this.cboChucDanh.LinkedTextBox = null;
            this.cboChucDanh.Location = new System.Drawing.Point(102, 6);
            this.cboChucDanh.Name = "cboChucDanh";
            this.cboChucDanh.Size = new System.Drawing.Size(174, 33);
            this.cboChucDanh.TabIndex = 25;
            // 
            // cbChonTatCa
            // 
            this.cbChonTatCa.AutoSize = true;
            this.cbChonTatCa.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbChonTatCa.Location = new System.Drawing.Point(78, 339);
            this.cbChonTatCa.Name = "cbChonTatCa";
            this.cbChonTatCa.Size = new System.Drawing.Size(166, 35);
            this.cbChonTatCa.TabIndex = 25;
            this.cbChonTatCa.Text = "Chọn tất cả ";
            this.cbChonTatCa.UseVisualStyleBackColor = true;
            this.cbChonTatCa.CheckedChanged += new System.EventHandler(this.cbChonTatCa_CheckedChanged);
            // 
            // cbBoChonTatCa
            // 
            this.cbBoChonTatCa.AutoSize = true;
            this.cbBoChonTatCa.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBoChonTatCa.Location = new System.Drawing.Point(78, 380);
            this.cbBoChonTatCa.Name = "cbBoChonTatCa";
            this.cbBoChonTatCa.Size = new System.Drawing.Size(199, 35);
            this.cbBoChonTatCa.TabIndex = 26;
            this.cbBoChonTatCa.Text = "Bỏ chọn tất cả ";
            this.cbBoChonTatCa.UseVisualStyleBackColor = true;
            this.cbBoChonTatCa.CheckedChanged += new System.EventHandler(this.cbBoChonTatCa_CheckedChanged);
            // 
            // FrmPhanQuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 499);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmPhanQuyen";
            this.Text = "FrmPhanQuyen";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrDanhSachNguoiDung)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox cbQuanLyNguoiDung;
        private System.Windows.Forms.CheckBox cbNganHangKPI;
        private System.Windows.Forms.CheckBox cbKiemDuyetBieuMau;
        private System.Windows.Forms.CheckBox cbDanhMucKPI;
        private System.Windows.Forms.CheckBox cbCaNhan;
        private System.Windows.Forms.CheckBox cbCaiDatHethong;
        private System.Windows.Forms.CheckBox cbBieuMauKPI;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.DataGridView dgrDanhSachNguoiDung;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cHoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMaNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTenDanhNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMaQuyen;
        private System.Windows.Forms.DataGridViewImageColumn cChiTiet;
        private ControlProject1510.ComboBoxSearch cboChucDanh;
        private System.Windows.Forms.CheckBox cbBoChonTatCa;
        private System.Windows.Forms.CheckBox cbChonTatCa;
    }
}