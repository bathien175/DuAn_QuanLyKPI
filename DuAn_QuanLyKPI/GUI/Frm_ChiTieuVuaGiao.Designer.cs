﻿
namespace DuAn_QuanLyKPI.GUI
{
    partial class Frm_ChiTieuVuaGiao
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_MaPhieu2 = new System.Windows.Forms.TextBox();
            this.txt_MaPhieu1 = new System.Windows.Forms.TextBox();
            this.txt_MaKhoa = new System.Windows.Forms.TextBox();
            this.ck_TruongPhong = new DevExpress.XtraEditors.CheckEdit();
            this.txt_MaPhieu = new System.Windows.Forms.TextBox();
            this.dt_NgayTaoMaPhieu = new System.Windows.Forms.DateTimePicker();
            this.btn_TaoMaPhieu = new System.Windows.Forms.Button();
            this.btn_Luu = new System.Windows.Forms.Button();
            this.txt_ChucDanh = new System.Windows.Forms.TextBox();
            this.txt_KhoaPhong = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dtgv_ChiTietKPI = new System.Windows.Forms.DataGridView();
            this.clMaKPI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clNoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDonViTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clPhuongPhapDo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clCongViecCaNhan = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clChiTieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clTieuChiID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clTenTieuChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clChiTieuBV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clTrongSoTCBV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTrongSoKPIBV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cMaKPI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cNoiDung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cDonViTinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cPhuongPhapDo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cCongViecCaNhan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cChiTieu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_LoaiPhieu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_MauPhieu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_TrangThai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MaKhoa = new System.Windows.Forms.Label();
            this.Nam = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TieuChi = new System.Windows.Forms.Label();
            this.cbo_BieuMau = new System.Windows.Forms.ComboBox();
            this.danhsachBieuMauBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ck_TruongPhong.Properties)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_ChiTietKPI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.danhsachBieuMauBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1467, 64);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(391, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(576, 55);
            this.label1.TabIndex = 1;
            this.label1.Text = "CHI TIẾT KPI ĐÃ CHỌN";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbo_BieuMau);
            this.panel2.Controls.Add(this.TieuChi);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.Nam);
            this.panel2.Controls.Add(this.MaKhoa);
            this.panel2.Controls.Add(this.txt_MaPhieu2);
            this.panel2.Controls.Add(this.txt_MaPhieu1);
            this.panel2.Controls.Add(this.txt_MaKhoa);
            this.panel2.Controls.Add(this.ck_TruongPhong);
            this.panel2.Controls.Add(this.txt_MaPhieu);
            this.panel2.Controls.Add(this.dt_NgayTaoMaPhieu);
            this.panel2.Controls.Add(this.btn_TaoMaPhieu);
            this.panel2.Controls.Add(this.btn_Luu);
            this.panel2.Controls.Add(this.txt_ChucDanh);
            this.panel2.Controls.Add(this.txt_KhoaPhong);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 64);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1467, 180);
            this.panel2.TabIndex = 1;
            // 
            // txt_MaPhieu2
            // 
            this.txt_MaPhieu2.Location = new System.Drawing.Point(1335, 99);
            this.txt_MaPhieu2.Name = "txt_MaPhieu2";
            this.txt_MaPhieu2.Size = new System.Drawing.Size(129, 32);
            this.txt_MaPhieu2.TabIndex = 16;
            // 
            // txt_MaPhieu1
            // 
            this.txt_MaPhieu1.Location = new System.Drawing.Point(1335, 61);
            this.txt_MaPhieu1.Name = "txt_MaPhieu1";
            this.txt_MaPhieu1.Size = new System.Drawing.Size(129, 32);
            this.txt_MaPhieu1.TabIndex = 15;
            // 
            // txt_MaKhoa
            // 
            this.txt_MaKhoa.Location = new System.Drawing.Point(285, 127);
            this.txt_MaKhoa.Name = "txt_MaKhoa";
            this.txt_MaKhoa.Size = new System.Drawing.Size(129, 32);
            this.txt_MaKhoa.TabIndex = 14;
            // 
            // ck_TruongPhong
            // 
            this.ck_TruongPhong.Location = new System.Drawing.Point(439, 139);
            this.ck_TruongPhong.Name = "ck_TruongPhong";
            this.ck_TruongPhong.Properties.Caption = "Trưởng phòng";
            this.ck_TruongPhong.Size = new System.Drawing.Size(126, 20);
            this.ck_TruongPhong.TabIndex = 13;
            // 
            // txt_MaPhieu
            // 
            this.txt_MaPhieu.Enabled = false;
            this.txt_MaPhieu.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_MaPhieu.Location = new System.Drawing.Point(19, 71);
            this.txt_MaPhieu.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txt_MaPhieu.Name = "txt_MaPhieu";
            this.txt_MaPhieu.ReadOnly = true;
            this.txt_MaPhieu.Size = new System.Drawing.Size(266, 32);
            this.txt_MaPhieu.TabIndex = 12;
            // 
            // dt_NgayTaoMaPhieu
            // 
            this.dt_NgayTaoMaPhieu.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt_NgayTaoMaPhieu.Location = new System.Drawing.Point(294, 71);
            this.dt_NgayTaoMaPhieu.Name = "dt_NgayTaoMaPhieu";
            this.dt_NgayTaoMaPhieu.Size = new System.Drawing.Size(120, 32);
            this.dt_NgayTaoMaPhieu.TabIndex = 11;
            this.dt_NgayTaoMaPhieu.ValueChanged += new System.EventHandler(this.dt_NgayTaoMaPhieu_ValueChanged);
            // 
            // btn_TaoMaPhieu
            // 
            this.btn_TaoMaPhieu.Location = new System.Drawing.Point(430, 71);
            this.btn_TaoMaPhieu.Name = "btn_TaoMaPhieu";
            this.btn_TaoMaPhieu.Size = new System.Drawing.Size(135, 36);
            this.btn_TaoMaPhieu.TabIndex = 10;
            this.btn_TaoMaPhieu.Text = "Tạo mã phiếu";
            this.btn_TaoMaPhieu.UseVisualStyleBackColor = true;
            this.btn_TaoMaPhieu.Click += new System.EventHandler(this.btn_TaoMaPhieu_Click);
            // 
            // btn_Luu
            // 
            this.btn_Luu.Location = new System.Drawing.Point(1358, 142);
            this.btn_Luu.Name = "btn_Luu";
            this.btn_Luu.Size = new System.Drawing.Size(97, 36);
            this.btn_Luu.TabIndex = 9;
            this.btn_Luu.Text = "Lưu";
            this.btn_Luu.UseVisualStyleBackColor = true;
            this.btn_Luu.Click += new System.EventHandler(this.btn_Luu_Click);
            // 
            // txt_ChucDanh
            // 
            this.txt_ChucDanh.Enabled = false;
            this.txt_ChucDanh.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ChucDanh.Location = new System.Drawing.Point(836, 16);
            this.txt_ChucDanh.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txt_ChucDanh.Name = "txt_ChucDanh";
            this.txt_ChucDanh.ReadOnly = true;
            this.txt_ChucDanh.Size = new System.Drawing.Size(513, 32);
            this.txt_ChucDanh.TabIndex = 8;
            // 
            // txt_KhoaPhong
            // 
            this.txt_KhoaPhong.Enabled = false;
            this.txt_KhoaPhong.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_KhoaPhong.Location = new System.Drawing.Point(156, 16);
            this.txt_KhoaPhong.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txt_KhoaPhong.Name = "txt_KhoaPhong";
            this.txt_KhoaPhong.ReadOnly = true;
            this.txt_KhoaPhong.Size = new System.Drawing.Size(513, 32);
            this.txt_KhoaPhong.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(716, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "Chức danh";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Khoa/ Phòng";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dtgv_ChiTietKPI);
            this.panel3.Controls.Add(this.gridControl2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 244);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1467, 492);
            this.panel3.TabIndex = 2;
            // 
            // dtgv_ChiTietKPI
            // 
            this.dtgv_ChiTietKPI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_ChiTietKPI.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clMaKPI,
            this.clNoiDung,
            this.clDonViTinh,
            this.clPhuongPhapDo,
            this.clCongViecCaNhan,
            this.clChiTieu,
            this.clTieuChiID,
            this.clTenTieuChi,
            this.clChiTieuBV,
            this.clTrongSoTCBV,
            this.cTrongSoKPIBV});
            this.dtgv_ChiTietKPI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgv_ChiTietKPI.Location = new System.Drawing.Point(0, 0);
            this.dtgv_ChiTietKPI.Name = "dtgv_ChiTietKPI";
            this.dtgv_ChiTietKPI.Size = new System.Drawing.Size(1467, 492);
            this.dtgv_ChiTietKPI.TabIndex = 6;
            // 
            // clMaKPI
            // 
            this.clMaKPI.DataPropertyName = "MaKPI";
            this.clMaKPI.HeaderText = "Mã KPI";
            this.clMaKPI.Name = "clMaKPI";
            this.clMaKPI.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clMaKPI.Width = 150;
            // 
            // clNoiDung
            // 
            this.clNoiDung.DataPropertyName = "NoiDung";
            this.clNoiDung.HeaderText = "Nội dung";
            this.clNoiDung.Name = "clNoiDung";
            this.clNoiDung.Width = 180;
            // 
            // clDonViTinh
            // 
            this.clDonViTinh.DataPropertyName = "DonViTinh";
            this.clDonViTinh.HeaderText = "Đơn vị tính";
            this.clDonViTinh.Name = "clDonViTinh";
            this.clDonViTinh.Width = 120;
            // 
            // clPhuongPhapDo
            // 
            this.clPhuongPhapDo.DataPropertyName = "PhuongPhapDo";
            this.clPhuongPhapDo.HeaderText = "Phương pháp đo";
            this.clPhuongPhapDo.Name = "clPhuongPhapDo";
            this.clPhuongPhapDo.Width = 150;
            // 
            // clCongViecCaNhan
            // 
            this.clCongViecCaNhan.DataPropertyName = "CongViecCaNhan";
            this.clCongViecCaNhan.HeaderText = "Công việc cá nhân";
            this.clCongViecCaNhan.Name = "clCongViecCaNhan";
            this.clCongViecCaNhan.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clCongViecCaNhan.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clCongViecCaNhan.Width = 150;
            // 
            // clChiTieu
            // 
            this.clChiTieu.DataPropertyName = "ChiTieu";
            this.clChiTieu.HeaderText = "Chỉ tiêu";
            this.clChiTieu.Name = "clChiTieu";
            // 
            // clTieuChiID
            // 
            this.clTieuChiID.DataPropertyName = "TieuChiID";
            this.clTieuChiID.HeaderText = "Tiêu chí ID";
            this.clTieuChiID.Name = "clTieuChiID";
            this.clTieuChiID.Width = 180;
            // 
            // clTenTieuChi
            // 
            this.clTenTieuChi.DataPropertyName = "TenTieuChi";
            this.clTenTieuChi.HeaderText = "Tên tiêu chí";
            this.clTenTieuChi.Name = "clTenTieuChi";
            // 
            // clChiTieuBV
            // 
            this.clChiTieuBV.HeaderText = "Chỉ tiêu BV";
            this.clChiTieuBV.Name = "clChiTieuBV";
            // 
            // clTrongSoTCBV
            // 
            this.clTrongSoTCBV.HeaderText = "Trọng số tiêu chỉ BV";
            this.clTrongSoTCBV.Name = "clTrongSoTCBV";
            // 
            // cTrongSoKPIBV
            // 
            this.cTrongSoKPIBV.HeaderText = "Trọng số KPI BV";
            this.cTrongSoKPIBV.Name = "cTrongSoKPIBV";
            // 
            // gridControl2
            // 
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.EmbeddedNavigator.Appearance.Options.UseBackColor = true;
            this.gridControl2.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.gridControl2.Location = new System.Drawing.Point(0, 0);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(1467, 492);
            this.gridControl2.TabIndex = 5;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.gridView2.Appearance.HeaderPanel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView2.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView2.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView2.Appearance.Row.BackColor = System.Drawing.Color.White;
            this.gridView2.Appearance.Row.Options.UseBackColor = true;
            this.gridView2.Appearance.RowSeparator.BackColor = System.Drawing.Color.White;
            this.gridView2.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gridView2.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridView2.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.cMaKPI,
            this.cNoiDung,
            this.cDonViTinh,
            this.cPhuongPhapDo,
            this.cCongViecCaNhan,
            this.cChiTieu,
            this.c_LoaiPhieu,
            this.c_MauPhieu,
            this.c_TrangThai});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView2.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsBehavior.ReadOnly = true;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.RowHeight = 30;
            // 
            // cMaKPI
            // 
            this.cMaKPI.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cMaKPI.AppearanceHeader.Options.UseBackColor = true;
            this.cMaKPI.Caption = "Mã KPI";
            this.cMaKPI.FieldName = "MaKPI";
            this.cMaKPI.Name = "cMaKPI";
            this.cMaKPI.Visible = true;
            this.cMaKPI.VisibleIndex = 0;
            // 
            // cNoiDung
            // 
            this.cNoiDung.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cNoiDung.AppearanceHeader.Options.UseBackColor = true;
            this.cNoiDung.Caption = "Nội dung";
            this.cNoiDung.FieldName = "NoiDung";
            this.cNoiDung.Name = "cNoiDung";
            this.cNoiDung.Visible = true;
            this.cNoiDung.VisibleIndex = 1;
            // 
            // cDonViTinh
            // 
            this.cDonViTinh.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cDonViTinh.AppearanceHeader.Options.UseBackColor = true;
            this.cDonViTinh.Caption = "Đơn vị tính";
            this.cDonViTinh.FieldName = "DonViTinh";
            this.cDonViTinh.Name = "cDonViTinh";
            this.cDonViTinh.Visible = true;
            this.cDonViTinh.VisibleIndex = 2;
            // 
            // cPhuongPhapDo
            // 
            this.cPhuongPhapDo.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cPhuongPhapDo.AppearanceHeader.Options.UseBackColor = true;
            this.cPhuongPhapDo.Caption = "Phương pháp đo";
            this.cPhuongPhapDo.FieldName = "PhuongPhapDo";
            this.cPhuongPhapDo.Name = "cPhuongPhapDo";
            this.cPhuongPhapDo.Visible = true;
            this.cPhuongPhapDo.VisibleIndex = 3;
            // 
            // cCongViecCaNhan
            // 
            this.cCongViecCaNhan.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cCongViecCaNhan.AppearanceHeader.Options.UseBackColor = true;
            this.cCongViecCaNhan.Caption = "Công việc cá nhân";
            this.cCongViecCaNhan.FieldName = "CongViecCaNhan";
            this.cCongViecCaNhan.Name = "cCongViecCaNhan";
            this.cCongViecCaNhan.Visible = true;
            this.cCongViecCaNhan.VisibleIndex = 4;
            // 
            // cChiTieu
            // 
            this.cChiTieu.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cChiTieu.AppearanceHeader.Options.UseBackColor = true;
            this.cChiTieu.Caption = "Chỉ tiêu";
            this.cChiTieu.FieldName = "ChiTieu";
            this.cChiTieu.Name = "cChiTieu";
            this.cChiTieu.Visible = true;
            this.cChiTieu.VisibleIndex = 5;
            // 
            // c_LoaiPhieu
            // 
            this.c_LoaiPhieu.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.c_LoaiPhieu.AppearanceHeader.Options.UseBackColor = true;
            this.c_LoaiPhieu.Caption = "Loại phiếu";
            this.c_LoaiPhieu.FieldName = "LoaiPhieu";
            this.c_LoaiPhieu.Name = "c_LoaiPhieu";
            this.c_LoaiPhieu.Visible = true;
            this.c_LoaiPhieu.VisibleIndex = 6;
            // 
            // c_MauPhieu
            // 
            this.c_MauPhieu.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.c_MauPhieu.AppearanceHeader.Options.UseBackColor = true;
            this.c_MauPhieu.Caption = "Mẫu phiếu";
            this.c_MauPhieu.FieldName = "MauPhieu";
            this.c_MauPhieu.Name = "c_MauPhieu";
            this.c_MauPhieu.Visible = true;
            this.c_MauPhieu.VisibleIndex = 8;
            // 
            // c_TrangThai
            // 
            this.c_TrangThai.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.c_TrangThai.AppearanceHeader.Options.UseBackColor = true;
            this.c_TrangThai.Caption = "Trạng thái";
            this.c_TrangThai.FieldName = "Trangthai";
            this.c_TrangThai.Name = "c_TrangThai";
            this.c_TrangThai.Visible = true;
            this.c_TrangThai.VisibleIndex = 7;
            // 
            // MaKhoa
            // 
            this.MaKhoa.AutoSize = true;
            this.MaKhoa.Location = new System.Drawing.Point(197, 130);
            this.MaKhoa.Name = "MaKhoa";
            this.MaKhoa.Size = new System.Drawing.Size(82, 23);
            this.MaKhoa.TabIndex = 17;
            this.MaKhoa.Text = "Mã khoa";
            // 
            // Nam
            // 
            this.Nam.AutoSize = true;
            this.Nam.Location = new System.Drawing.Point(1236, 64);
            this.Nam.Name = "Nam";
            this.Nam.Size = new System.Drawing.Size(56, 23);
            this.Nam.TabIndex = 18;
            this.Nam.Text = "Năm:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1236, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 23);
            this.label5.TabIndex = 19;
            this.label5.Text = "Quý: ";
            // 
            // TieuChi
            // 
            this.TieuChi.AutoSize = true;
            this.TieuChi.Location = new System.Drawing.Point(680, 74);
            this.TieuChi.Name = "TieuChi";
            this.TieuChi.Size = new System.Drawing.Size(91, 23);
            this.TieuChi.TabIndex = 20;
            this.TieuChi.Text = "Biểu mẫu";
            // 
            // cbo_BieuMau
            // 
            this.cbo_BieuMau.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.danhsachBieuMauBindingSource, "IDBieuMau", true));
            this.cbo_BieuMau.DataSource = this.danhsachBieuMauBindingSource;
            this.cbo_BieuMau.DisplayMember = "TenBieuMau";
            this.cbo_BieuMau.FormattingEnabled = true;
            this.cbo_BieuMau.Location = new System.Drawing.Point(778, 71);
            this.cbo_BieuMau.Name = "cbo_BieuMau";
            this.cbo_BieuMau.Size = new System.Drawing.Size(201, 31);
            this.cbo_BieuMau.TabIndex = 22;
            this.cbo_BieuMau.ValueMember = "IDBieuMau";
            // 
            // 
            // Frm_ChiTieuVuaGiao
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1467, 736);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Frm_ChiTieuVuaGiao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chỉ tiêu vừa giao";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_ChiTieuVuaGiao_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ck_TruongPhong.Properties)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_ChiTietKPI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.danhsachBieuMauBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txt_ChucDanh;
        private System.Windows.Forms.TextBox txt_KhoaPhong;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn cMaKPI;
        private DevExpress.XtraGrid.Columns.GridColumn cNoiDung;
        private DevExpress.XtraGrid.Columns.GridColumn cDonViTinh;
        private DevExpress.XtraGrid.Columns.GridColumn cPhuongPhapDo;
        private DevExpress.XtraGrid.Columns.GridColumn cCongViecCaNhan;
        private DevExpress.XtraGrid.Columns.GridColumn cChiTieu;
        private DevExpress.XtraGrid.Columns.GridColumn c_LoaiPhieu;
        private DevExpress.XtraGrid.Columns.GridColumn c_MauPhieu;
        private DevExpress.XtraGrid.Columns.GridColumn c_TrangThai;
        private System.Windows.Forms.DataGridView dtgv_ChiTietKPI;
        private System.Windows.Forms.Button btn_TaoMaPhieu;
        private System.Windows.Forms.Button btn_Luu;
        private System.Windows.Forms.DateTimePicker dt_NgayTaoMaPhieu;
        private System.Windows.Forms.TextBox txt_MaPhieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn clMaKPI;
        private System.Windows.Forms.DataGridViewTextBoxColumn clNoiDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDonViTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn clPhuongPhapDo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clCongViecCaNhan;
        private System.Windows.Forms.DataGridViewTextBoxColumn clChiTieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn clTieuChiID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clTenTieuChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn clChiTieuBV;
        private System.Windows.Forms.DataGridViewTextBoxColumn clTrongSoTCBV;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTrongSoKPIBV;
        private DevExpress.XtraEditors.CheckEdit ck_TruongPhong;
        private System.Windows.Forms.TextBox txt_MaKhoa;
        private System.Windows.Forms.TextBox txt_MaPhieu1;
        private System.Windows.Forms.TextBox txt_MaPhieu2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label Nam;
        private System.Windows.Forms.Label MaKhoa;
        private System.Windows.Forms.Label TieuChi;
        private System.Windows.Forms.ComboBox cbo_BieuMau;
        private System.Windows.Forms.BindingSource danhsachBieuMauBindingSource;
    }
}