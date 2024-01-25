
namespace DuAn_QuanLyKPI.GUI
{
    partial class Frm_User
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_User));
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgrDanhSach = new System.Windows.Forms.DataGridView();
            this.cMaNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cHoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTenTaiKhoan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPhongKhoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTenChucDanh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cHinhAnh = new System.Windows.Forms.DataGridViewImageColumn();
            this.cSua = new System.Windows.Forms.DataGridViewImageColumn();
            this.Xóa = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnUpImage = new System.Windows.Forms.Button();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.cXoa = new System.Windows.Forms.DataGridViewImageColumn();
            this.txtMaNV = new ControlProject1510.XFilteg();
            this.txtHoten = new ControlProject1510.XFilteg();
            this.txtEmail = new ControlProject1510.XFilteg();
            this.txtSDT = new ControlProject1510.XFilteg();
            this.pbUser = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMatKhau = new ControlProject1510.XFilteg();
            this.pnThongTinNhanVien = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLuuSua = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnclear = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboPhanQuyen = new ControlProject1510.ComboBoxSearch();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cboChucDanh = new ControlProject1510.ComboBoxSearch();
            this.cboPhongKhoa = new ControlProject1510.ComboBoxSearch();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTenTaiKhoan = new ControlProject1510.XFilteg();
            this.lab = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnTaiHinh = new System.Windows.Forms.Button();
            this.Upload = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolbarFormManager1 = new DevExpress.XtraBars.ToolbarForm.ToolbarFormManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.fluentDesignFormContainer1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUser)).BeginInit();
            this.pnThongTinNhanVien.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toolbarFormManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgrDanhSach);
            this.panel3.Controls.Add(this.btnUpImage);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(395, 131);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(969, 728);
            this.panel3.TabIndex = 5;
            // 
            // dgrDanhSach
            // 
            this.dgrDanhSach.AllowUserToAddRows = false;
            this.dgrDanhSach.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgrDanhSach.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgrDanhSach.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrDanhSach.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgrDanhSach.ColumnHeadersHeight = 60;
            this.dgrDanhSach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cMaNV,
            this.cHoTen,
            this.cTenTaiKhoan,
            this.cPhongKhoa,
            this.cTenChucDanh,
            this.cHinhAnh,
            this.cSua,
            this.Xóa});
            this.dgrDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrDanhSach.EnableHeadersVisualStyles = false;
            this.dgrDanhSach.Location = new System.Drawing.Point(0, 0);
            this.dgrDanhSach.Name = "dgrDanhSach";
            this.dgrDanhSach.ReadOnly = true;
            this.dgrDanhSach.RowHeadersWidth = 40;
            this.dgrDanhSach.RowTemplate.Height = 40;
            this.dgrDanhSach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrDanhSach.Size = new System.Drawing.Size(969, 728);
            this.dgrDanhSach.TabIndex = 0;
            this.dgrDanhSach.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgrDanhSach_CellMouseClick);
            this.dgrDanhSach.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgrDanhSach_RowPostPaint);
            this.dgrDanhSach.Click += new System.EventHandler(this.dgrDanhSach_Click_1);
            // 
            // cMaNV
            // 
            this.cMaNV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cMaNV.DataPropertyName = "MANV";
            this.cMaNV.FillWeight = 200F;
            this.cMaNV.HeaderText = "Mã NV";
            this.cMaNV.Name = "cMaNV";
            this.cMaNV.ReadOnly = true;
            this.cMaNV.Width = 76;
            // 
            // cHoTen
            // 
            this.cHoTen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cHoTen.DataPropertyName = "TenNV";
            this.cHoTen.HeaderText = "Họ tên";
            this.cHoTen.Name = "cHoTen";
            this.cHoTen.ReadOnly = true;
            // 
            // cTenTaiKhoan
            // 
            this.cTenTaiKhoan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cTenTaiKhoan.DataPropertyName = "TenTaiKhoan";
            this.cTenTaiKhoan.HeaderText = "Tên tài khoản";
            this.cTenTaiKhoan.Name = "cTenTaiKhoan";
            this.cTenTaiKhoan.ReadOnly = true;
            this.cTenTaiKhoan.Width = 106;
            // 
            // cPhongKhoa
            // 
            this.cPhongKhoa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cPhongKhoa.DataPropertyName = "TenPK";
            this.cPhongKhoa.HeaderText = "Phòng khoa";
            this.cPhongKhoa.Name = "cPhongKhoa";
            this.cPhongKhoa.ReadOnly = true;
            this.cPhongKhoa.Width = 97;
            // 
            // cTenChucDanh
            // 
            this.cTenChucDanh.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cTenChucDanh.DataPropertyName = "TenChucDanh";
            this.cTenChucDanh.HeaderText = "Tên chức danh";
            this.cTenChucDanh.Name = "cTenChucDanh";
            this.cTenChucDanh.ReadOnly = true;
            this.cTenChucDanh.Width = 114;
            // 
            // cHinhAnh
            // 
            this.cHinhAnh.DataPropertyName = "HinhAnhNV";
            this.cHinhAnh.HeaderText = "Hình ảnh";
            this.cHinhAnh.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.cHinhAnh.MinimumWidth = 30;
            this.cHinhAnh.Name = "cHinhAnh";
            this.cHinhAnh.ReadOnly = true;
            // 
            // cSua
            // 
            this.cSua.HeaderText = "Sửa";
            this.cSua.Image = ((System.Drawing.Image)(resources.GetObject("cSua.Image")));
            this.cSua.Name = "cSua";
            this.cSua.ReadOnly = true;
            this.cSua.Width = 50;
            // 
            // Xóa
            // 
            this.Xóa.HeaderText = "Xóa";
            this.Xóa.Image = ((System.Drawing.Image)(resources.GetObject("Xóa.Image")));
            this.Xóa.Name = "Xóa";
            this.Xóa.ReadOnly = true;
            this.Xóa.Width = 50;
            // 
            // btnUpImage
            // 
            this.btnUpImage.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpImage.Location = new System.Drawing.Point(-62, 456);
            this.btnUpImage.Name = "btnUpImage";
            this.btnUpImage.Size = new System.Drawing.Size(122, 42);
            this.btnUpImage.TabIndex = 4;
            this.btnUpImage.Text = "Tải hình lên";
            this.btnUpImage.UseVisualStyleBackColor = true;
            this.btnUpImage.Click += new System.EventHandler(this.btnUpImage_Click_1);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Xóa";
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 50;
            // 
            // cXoa
            // 
            this.cXoa.HeaderText = "Xóa";
            this.cXoa.Name = "cXoa";
            this.cXoa.ReadOnly = true;
            this.cXoa.Width = 50;
            // 
            // txtMaNV
            // 
            this.txtMaNV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaNV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMaNV.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaNV.Location = new System.Drawing.Point(141, 8);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(245, 25);
            this.txtMaNV.TabIndex = 0;
            this.txtMaNV.xCoTimMoRong = false;
            this.txtMaNV.xDataGrid = null;
            this.txtMaNV.xField_Key = "";
            this.txtMaNV.xKeep_Old_Value = false;
            this.txtMaNV.xTimChinhXac = false;
            this.txtMaNV.xTimMoRong = "";
            this.txtMaNV.xTimTrenField = "";
            // 
            // txtHoten
            // 
            this.txtHoten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHoten.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtHoten.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoten.Location = new System.Drawing.Point(141, 52);
            this.txtHoten.Name = "txtHoten";
            this.txtHoten.Size = new System.Drawing.Size(245, 25);
            this.txtHoten.TabIndex = 1;
            this.txtHoten.xCoTimMoRong = false;
            this.txtHoten.xDataGrid = null;
            this.txtHoten.xField_Key = "";
            this.txtHoten.xKeep_Old_Value = false;
            this.txtHoten.xTimChinhXac = false;
            this.txtHoten.xTimMoRong = "";
            this.txtHoten.xTimTrenField = "";
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEmail.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(141, 96);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(245, 25);
            this.txtEmail.TabIndex = 2;
            this.txtEmail.xCoTimMoRong = false;
            this.txtEmail.xDataGrid = null;
            this.txtEmail.xField_Key = "";
            this.txtEmail.xKeep_Old_Value = false;
            this.txtEmail.xTimChinhXac = false;
            this.txtEmail.xTimMoRong = "";
            this.txtEmail.xTimTrenField = "";
            // 
            // txtSDT
            // 
            this.txtSDT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSDT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSDT.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSDT.Location = new System.Drawing.Point(141, 140);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(245, 25);
            this.txtSDT.TabIndex = 3;
            this.txtSDT.xCoTimMoRong = false;
            this.txtSDT.xDataGrid = null;
            this.txtSDT.xField_Key = "";
            this.txtSDT.xKeep_Old_Value = false;
            this.txtSDT.xTimChinhXac = false;
            this.txtSDT.xTimMoRong = "";
            this.txtSDT.xTimTrenField = "";
            // 
            // pbUser
            // 
            this.pbUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbUser.Image = global::DuAn_QuanLyKPI.Properties.Resources.noimage;
            this.pbUser.Location = new System.Drawing.Point(67, 4);
            this.pbUser.Name = "pbUser";
            this.pbUser.Size = new System.Drawing.Size(256, 222);
            this.pbUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbUser.TabIndex = 5;
            this.pbUser.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 24);
            this.label2.TabIndex = 9;
            this.label2.Text = "Mã NV:";
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMatKhau.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMatKhau.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatKhau.Location = new System.Drawing.Point(141, 228);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(245, 25);
            this.txtMatKhau.TabIndex = 14;
            this.txtMatKhau.xCoTimMoRong = false;
            this.txtMatKhau.xDataGrid = null;
            this.txtMatKhau.xField_Key = "";
            this.txtMatKhau.xKeep_Old_Value = false;
            this.txtMatKhau.xTimChinhXac = false;
            this.txtMatKhau.xTimMoRong = "";
            this.txtMatKhau.xTimTrenField = "";
            // 
            // pnThongTinNhanVien
            // 
            this.pnThongTinNhanVien.BackColor = System.Drawing.Color.White;
            this.pnThongTinNhanVien.Controls.Add(this.panel1);
            this.pnThongTinNhanVien.Controls.Add(this.panel6);
            this.pnThongTinNhanVien.Controls.Add(this.panel4);
            this.pnThongTinNhanVien.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnThongTinNhanVien.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnThongTinNhanVien.Location = new System.Drawing.Point(0, 0);
            this.pnThongTinNhanVien.Name = "pnThongTinNhanVien";
            this.pnThongTinNhanVien.Size = new System.Drawing.Size(395, 859);
            this.pnThongTinNhanVien.TabIndex = 3;
            this.pnThongTinNhanVien.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnLuuSua);
            this.panel1.Controls.Add(this.btnView);
            this.panel1.Controls.Add(this.btnclear);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 680);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(395, 179);
            this.panel1.TabIndex = 30;
            // 
            // btnLuuSua
            // 
            this.btnLuuSua.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuSua.Location = new System.Drawing.Point(95, 12);
            this.btnLuuSua.Name = "btnLuuSua";
            this.btnLuuSua.Size = new System.Drawing.Size(90, 41);
            this.btnLuuSua.TabIndex = 30;
            this.btnLuuSua.Text = "Lưu";
            this.btnLuuSua.UseVisualStyleBackColor = true;
            this.btnLuuSua.Visible = false;
            this.btnLuuSua.Click += new System.EventHandler(this.btnLuuSua_Click_1);
            // 
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.Location = new System.Drawing.Point(126, 59);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(134, 42);
            this.btnView.TabIndex = 28;
            this.btnView.Text = "Làm mới";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click_1);
            // 
            // btnclear
            // 
            this.btnclear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnclear.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclear.Location = new System.Drawing.Point(191, 12);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(93, 42);
            this.btnclear.TabIndex = 29;
            this.btnclear.Text = "Clear";
            this.btnclear.UseVisualStyleBackColor = true;
            this.btnclear.Click += new System.EventHandler(this.btnclear_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Controls.Add(this.panel12);
            this.panel6.Controls.Add(this.panel11);
            this.panel6.Controls.Add(this.panel10);
            this.panel6.Controls.Add(this.panel9);
            this.panel6.Controls.Add(this.panel8);
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Controls.Add(this.label9);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Controls.Add(this.txtMaNV);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Controls.Add(this.cboPhanQuyen);
            this.panel6.Controls.Add(this.txtHoten);
            this.panel6.Controls.Add(this.label8);
            this.panel6.Controls.Add(this.txtEmail);
            this.panel6.Controls.Add(this.label7);
            this.panel6.Controls.Add(this.txtSDT);
            this.panel6.Controls.Add(this.cboChucDanh);
            this.panel6.Controls.Add(this.label2);
            this.panel6.Controls.Add(this.cboPhongKhoa);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Controls.Add(this.txtTenTaiKhoan);
            this.panel6.Controls.Add(this.lab);
            this.panel6.Controls.Add(this.txtMatKhau);
            this.panel6.Location = new System.Drawing.Point(3, 276);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(389, 398);
            this.panel6.TabIndex = 29;
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.Black;
            this.panel12.Location = new System.Drawing.Point(141, 252);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(249, 1);
            this.panel12.TabIndex = 97;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.Black;
            this.panel11.Location = new System.Drawing.Point(141, 209);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(249, 1);
            this.panel11.TabIndex = 96;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.Black;
            this.panel10.Location = new System.Drawing.Point(141, 164);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(249, 1);
            this.panel10.TabIndex = 95;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.Black;
            this.panel9.Location = new System.Drawing.Point(141, 121);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(249, 1);
            this.panel9.TabIndex = 94;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Black;
            this.panel8.Location = new System.Drawing.Point(141, 76);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(249, 1);
            this.panel8.TabIndex = 93;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Black;
            this.panel7.Location = new System.Drawing.Point(141, 34);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(249, 1);
            this.panel7.TabIndex = 92;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(3, 362);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(122, 24);
            this.label9.TabIndex = 27;
            this.label9.Text = "Phân quyền:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 24);
            this.label5.TabIndex = 12;
            this.label5.Text = "SĐT:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 24);
            this.label4.TabIndex = 11;
            this.label4.Text = "Email:";
            // 
            // cboPhanQuyen
            // 
            this.cboPhanQuyen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPhanQuyen.AutoComplete = false;
            this.cboPhanQuyen.AutoDropdown = false;
            this.cboPhanQuyen.BackColorEven = System.Drawing.Color.White;
            this.cboPhanQuyen.BackColorOdd = System.Drawing.Color.White;
            this.cboPhanQuyen.ColumnNames = "TenQuyen";
            this.cboPhanQuyen.ColumnWidthDefault = 150;
            this.cboPhanQuyen.ColumnWidths = "";
            this.cboPhanQuyen.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboPhanQuyen.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboPhanQuyen.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPhanQuyen.FormattingEnabled = true;
            this.cboPhanQuyen.LinkedColumnIndex = 0;
            this.cboPhanQuyen.LinkedTextBox = null;
            this.cboPhanQuyen.Location = new System.Drawing.Point(141, 358);
            this.cboPhanQuyen.Name = "cboPhanQuyen";
            this.cboPhanQuyen.Size = new System.Drawing.Size(245, 33);
            this.cboPhanQuyen.TabIndex = 26;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 317);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 24);
            this.label8.TabIndex = 21;
            this.label8.Text = "Chức danh:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 272);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 24);
            this.label7.TabIndex = 20;
            this.label7.Text = "Phòng khoa:";
            // 
            // cboChucDanh
            // 
            this.cboChucDanh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboChucDanh.AutoComplete = false;
            this.cboChucDanh.AutoDropdown = false;
            this.cboChucDanh.BackColorEven = System.Drawing.Color.White;
            this.cboChucDanh.BackColorOdd = System.Drawing.Color.White;
            this.cboChucDanh.ColumnNames = "TenChucDanh";
            this.cboChucDanh.ColumnWidthDefault = 150;
            this.cboChucDanh.ColumnWidths = "";
            this.cboChucDanh.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboChucDanh.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboChucDanh.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboChucDanh.FormattingEnabled = true;
            this.cboChucDanh.LinkedColumnIndex = 0;
            this.cboChucDanh.LinkedTextBox = null;
            this.cboChucDanh.Location = new System.Drawing.Point(141, 313);
            this.cboChucDanh.Name = "cboChucDanh";
            this.cboChucDanh.Size = new System.Drawing.Size(245, 33);
            this.cboChucDanh.TabIndex = 19;
            // 
            // cboPhongKhoa
            // 
            this.cboPhongKhoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPhongKhoa.AutoComplete = false;
            this.cboPhongKhoa.AutoDropdown = false;
            this.cboPhongKhoa.BackColorEven = System.Drawing.Color.White;
            this.cboPhongKhoa.BackColorOdd = System.Drawing.Color.White;
            this.cboPhongKhoa.ColumnNames = "TenPK";
            this.cboPhongKhoa.ColumnWidthDefault = 150;
            this.cboPhongKhoa.ColumnWidths = "";
            this.cboPhongKhoa.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboPhongKhoa.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboPhongKhoa.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPhongKhoa.FormattingEnabled = true;
            this.cboPhongKhoa.LinkedColumnIndex = 0;
            this.cboPhongKhoa.LinkedTextBox = null;
            this.cboPhongKhoa.Location = new System.Drawing.Point(141, 268);
            this.cboPhongKhoa.Name = "cboPhongKhoa";
            this.cboPhongKhoa.Size = new System.Drawing.Size(245, 33);
            this.cboPhongKhoa.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 24);
            this.label3.TabIndex = 10;
            this.label3.Text = "Họ tên:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 228);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 24);
            this.label6.TabIndex = 16;
            this.label6.Text = "Mật khẩu:";
            // 
            // txtTenTaiKhoan
            // 
            this.txtTenTaiKhoan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenTaiKhoan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTenTaiKhoan.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenTaiKhoan.Location = new System.Drawing.Point(141, 184);
            this.txtTenTaiKhoan.Name = "txtTenTaiKhoan";
            this.txtTenTaiKhoan.Size = new System.Drawing.Size(245, 25);
            this.txtTenTaiKhoan.TabIndex = 13;
            this.txtTenTaiKhoan.xCoTimMoRong = false;
            this.txtTenTaiKhoan.xDataGrid = null;
            this.txtTenTaiKhoan.xField_Key = "";
            this.txtTenTaiKhoan.xKeep_Old_Value = false;
            this.txtTenTaiKhoan.xTimChinhXac = false;
            this.txtTenTaiKhoan.xTimMoRong = "";
            this.txtTenTaiKhoan.xTimTrenField = "";
            // 
            // lab
            // 
            this.lab.AutoSize = true;
            this.lab.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab.Location = new System.Drawing.Point(3, 184);
            this.lab.Name = "lab";
            this.lab.Size = new System.Drawing.Size(139, 24);
            this.lab.TabIndex = 15;
            this.lab.Text = "Tên tài khoản:";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.btnTaiHinh);
            this.panel4.Controls.Add(this.pbUser);
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(389, 275);
            this.panel4.TabIndex = 28;
            // 
            // btnTaiHinh
            // 
            this.btnTaiHinh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTaiHinh.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaiHinh.Location = new System.Drawing.Point(129, 229);
            this.btnTaiHinh.Name = "btnTaiHinh";
            this.btnTaiHinh.Size = new System.Drawing.Size(134, 42);
            this.btnTaiHinh.TabIndex = 31;
            this.btnTaiHinh.Text = "Tải hình";
            this.btnTaiHinh.UseVisualStyleBackColor = true;
            this.btnTaiHinh.Click += new System.EventHandler(this.btnTaiHinh_Click);
            // 
            // Upload
            // 
            this.Upload.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(97, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(578, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ NGƯỜI DÙNG";
            // 
            // panel5
            // 
            this.panel5.BackgroundImage = global::DuAn_QuanLyKPI.Properties.Resources.Tiêu_đề_Website_BV_16__removebg_preview;
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(760, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(209, 131);
            this.panel5.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(395, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(969, 131);
            this.panel2.TabIndex = 4;
            // 
            // toolbarFormManager1
            // 
            this.toolbarFormManager1.DockControls.Add(this.barDockControlTop);
            this.toolbarFormManager1.DockControls.Add(this.barDockControlBottom);
            this.toolbarFormManager1.DockControls.Add(this.barDockControlLeft);
            this.toolbarFormManager1.DockControls.Add(this.barDockControlRight);
            this.toolbarFormManager1.Form = this;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.toolbarFormManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1364, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 859);
            this.barDockControlBottom.Manager = this.toolbarFormManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1364, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.toolbarFormManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 859);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1364, 0);
            this.barDockControlRight.Manager = this.toolbarFormManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 859);
            // 
            // fluentDesignFormContainer1
            // 
            this.fluentDesignFormContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fluentDesignFormContainer1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormContainer1.Name = "fluentDesignFormContainer1";
            this.fluentDesignFormContainer1.Size = new System.Drawing.Size(1364, 859);
            this.fluentDesignFormContainer1.TabIndex = 10;
            // 
            // Frm_User
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1364, 859);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnThongTinNhanVien);
            this.Controls.Add(this.fluentDesignFormContainer1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("Frm_User.IconOptions.Image")));
            this.Name = "Frm_User";
            this.Text = "Quản lý người dùng";
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUser)).EndInit();
            this.pnThongTinNhanVien.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toolbarFormManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn cXoa;
        private ControlProject1510.XFilteg txtMaNV;
        private ControlProject1510.XFilteg txtHoten;
        private ControlProject1510.XFilteg txtEmail;
        private ControlProject1510.XFilteg txtSDT;
        private System.Windows.Forms.Button btnUpImage;
        private System.Windows.Forms.PictureBox pbUser;
        private System.Windows.Forms.Label label2;
        private ControlProject1510.XFilteg txtMatKhau;
        private System.Windows.Forms.Panel pnThongTinNhanVien;
        private System.Windows.Forms.Label label9;
        private ControlProject1510.ComboBoxSearch cboPhanQuyen;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private ControlProject1510.ComboBoxSearch cboChucDanh;
        private ControlProject1510.ComboBoxSearch cboPhongKhoa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lab;
        private ControlProject1510.XFilteg txtTenTaiKhoan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.OpenFileDialog Upload;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel4;
        private DevExpress.XtraBars.ToolbarForm.ToolbarFormManager toolbarFormManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer fluentDesignFormContainer1;
        private System.Windows.Forms.DataGridView dgrDanhSach;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLuuSua;
        private System.Windows.Forms.Button btnclear;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnTaiHinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMaNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn cHoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTenTaiKhoan;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPhongKhoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTenChucDanh;
        private System.Windows.Forms.DataGridViewImageColumn cHinhAnh;
        private System.Windows.Forms.DataGridViewImageColumn cSua;
        private System.Windows.Forms.DataGridViewImageColumn Xóa;
    }
}