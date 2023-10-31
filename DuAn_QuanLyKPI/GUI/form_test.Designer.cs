
namespace DuAn_QuanLyKPI.GUI
{
    partial class form_test
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
            this.gridChonTaiChinh = new DevExpress.XtraGrid.GridControl();
            this.dsMTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsMT = new DuAn_QuanLyKPI.dsMT();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaKPI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMucTieu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTrongSo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTieuChiDanhGia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPhuongPhapDo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colChungMinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colĐVT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKeHoach = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThucHien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHoanThanh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dsMucTieuBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cboMucTieu = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.vMucTieu = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridChonTaiChinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMucTieuBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMucTieu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vMucTieu)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gridChonTaiChinh);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1350, 386);
            this.panel1.TabIndex = 0;
            // 
            // gridChonTaiChinh
            // 
            this.gridChonTaiChinh.DataMember = "dsMucTieu";
            this.gridChonTaiChinh.DataSource = this.dsMTBindingSource;
            this.gridChonTaiChinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridChonTaiChinh.Location = new System.Drawing.Point(0, 0);
            this.gridChonTaiChinh.MainView = this.gridView1;
            this.gridChonTaiChinh.Name = "gridChonTaiChinh";
            this.gridChonTaiChinh.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cboMucTieu});
            this.gridChonTaiChinh.Size = new System.Drawing.Size(1350, 386);
            this.gridChonTaiChinh.TabIndex = 0;
            this.gridChonTaiChinh.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // dsMTBindingSource
            // 
            this.dsMTBindingSource.DataSource = this.dsMT;
            this.dsMTBindingSource.Position = 0;
            // 
            // dsMT
            // 
            this.dsMT.DataSetName = "dsMT";
            this.dsMT.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaKPI,
            this.colMucTieu,
            this.colTrongSo,
            this.colTieuChiDanhGia,
            this.colPhuongPhapDo,
            this.colChungMinh,
            this.colĐVT,
            this.colKeHoach,
            this.colThucHien,
            this.colHoanThanh});
            this.gridView1.GridControl = this.gridChonTaiChinh;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsCustomization.AllowColumnResizing = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colMaKPI
            // 
            this.colMaKPI.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colMaKPI.AppearanceHeader.Options.UseFont = true;
            this.colMaKPI.AppearanceHeader.Options.UseTextOptions = true;
            this.colMaKPI.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaKPI.Caption = "Mã KPI";
            this.colMaKPI.FieldName = "MaKPI";
            this.colMaKPI.Name = "colMaKPI";
            this.colMaKPI.OptionsColumn.AllowEdit = false;
            this.colMaKPI.OptionsColumn.AllowFocus = false;
            this.colMaKPI.Visible = true;
            this.colMaKPI.VisibleIndex = 0;
            this.colMaKPI.Width = 50;
            // 
            // colMucTieu
            // 
            this.colMucTieu.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colMucTieu.AppearanceHeader.Options.UseFont = true;
            this.colMucTieu.Caption = "Mục tiêu";
            this.colMucTieu.ColumnEdit = this.cboMucTieu;
            this.colMucTieu.FieldName = "Mục tiêu";
            this.colMucTieu.Name = "colMucTieu";
            this.colMucTieu.Visible = true;
            this.colMucTieu.VisibleIndex = 1;
            this.colMucTieu.Width = 300;
            // 
            // colTrongSo
            // 
            this.colTrongSo.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colTrongSo.AppearanceHeader.Options.UseFont = true;
            this.colTrongSo.AppearanceHeader.Options.UseTextOptions = true;
            this.colTrongSo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTrongSo.Caption = "Trọng số (%)";
            this.colTrongSo.FieldName = "Trọng số";
            this.colTrongSo.Name = "colTrongSo";
            this.colTrongSo.Visible = true;
            this.colTrongSo.VisibleIndex = 2;
            this.colTrongSo.Width = 100;
            // 
            // colTieuChiDanhGia
            // 
            this.colTieuChiDanhGia.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colTieuChiDanhGia.AppearanceHeader.Options.UseFont = true;
            this.colTieuChiDanhGia.Caption = "Tiêu chí đánh giá";
            this.colTieuChiDanhGia.FieldName = "Tiêu chí đánh giá";
            this.colTieuChiDanhGia.Name = "colTieuChiDanhGia";
            this.colTieuChiDanhGia.Visible = true;
            this.colTieuChiDanhGia.VisibleIndex = 3;
            this.colTieuChiDanhGia.Width = 300;
            // 
            // colPhuongPhapDo
            // 
            this.colPhuongPhapDo.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colPhuongPhapDo.AppearanceHeader.Options.UseFont = true;
            this.colPhuongPhapDo.Caption = "Phương pháp đo";
            this.colPhuongPhapDo.FieldName = "Phương pháp đo";
            this.colPhuongPhapDo.Name = "colPhuongPhapDo";
            this.colPhuongPhapDo.Visible = true;
            this.colPhuongPhapDo.VisibleIndex = 4;
            this.colPhuongPhapDo.Width = 200;
            // 
            // colChungMinh
            // 
            this.colChungMinh.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colChungMinh.AppearanceHeader.Options.UseFont = true;
            this.colChungMinh.Caption = "Chứng minh";
            this.colChungMinh.FieldName = "Chứng minh";
            this.colChungMinh.Name = "colChungMinh";
            this.colChungMinh.Visible = true;
            this.colChungMinh.VisibleIndex = 5;
            // 
            // colĐVT
            // 
            this.colĐVT.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colĐVT.AppearanceHeader.Options.UseFont = true;
            this.colĐVT.Caption = "ĐVT";
            this.colĐVT.FieldName = "ĐVT";
            this.colĐVT.Name = "colĐVT";
            this.colĐVT.Visible = true;
            this.colĐVT.VisibleIndex = 6;
            // 
            // colKeHoach
            // 
            this.colKeHoach.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colKeHoach.AppearanceHeader.Options.UseFont = true;
            this.colKeHoach.Caption = "Kế hoạch";
            this.colKeHoach.FieldName = "Kế hoạch";
            this.colKeHoach.Name = "colKeHoach";
            this.colKeHoach.Visible = true;
            this.colKeHoach.VisibleIndex = 7;
            // 
            // colThucHien
            // 
            this.colThucHien.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colThucHien.AppearanceHeader.Options.UseFont = true;
            this.colThucHien.Caption = "Thực hiện";
            this.colThucHien.FieldName = "Thực hiện";
            this.colThucHien.Name = "colThucHien";
            this.colThucHien.Visible = true;
            this.colThucHien.VisibleIndex = 8;
            // 
            // colHoanThanh
            // 
            this.colHoanThanh.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colHoanThanh.AppearanceHeader.Options.UseFont = true;
            this.colHoanThanh.AppearanceHeader.Options.UseTextOptions = true;
            this.colHoanThanh.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHoanThanh.Caption = "Hoàn thành";
            this.colHoanThanh.FieldName = "Hoàn thành";
            this.colHoanThanh.Name = "colHoanThanh";
            this.colHoanThanh.Visible = true;
            this.colHoanThanh.VisibleIndex = 9;
            // 
            // dsMucTieuBindingSource
            // 
            this.dsMucTieuBindingSource.DataMember = "dsMucTieu";
            this.dsMucTieuBindingSource.DataSource = this.dsMT;
            // 
            // cboMucTieu
            // 
            this.cboMucTieu.AutoHeight = false;
            this.cboMucTieu.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMucTieu.Name = "cboMucTieu";
            this.cboMucTieu.NullText = "";
            this.cboMucTieu.PopupView = this.vMucTieu;
            // 
            // vMucTieu
            // 
            this.vMucTieu.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.vMucTieu.Name = "vMucTieu";
            this.vMucTieu.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.vMucTieu.OptionsView.ShowGroupPanel = false;
            // 
            // form_test
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "form_test";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "form_test";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridChonTaiChinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMucTieuBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMucTieu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vMucTieu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.GridControl gridChonTaiChinh;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource dsMTBindingSource;
        private dsMT dsMT;
        private DevExpress.XtraGrid.Columns.GridColumn colMaKPI;
        private DevExpress.XtraGrid.Columns.GridColumn colMucTieu;
        private DevExpress.XtraGrid.Columns.GridColumn colTrongSo;
        private DevExpress.XtraGrid.Columns.GridColumn colTieuChiDanhGia;
        private DevExpress.XtraGrid.Columns.GridColumn colPhuongPhapDo;
        private DevExpress.XtraGrid.Columns.GridColumn colChungMinh;
        private DevExpress.XtraGrid.Columns.GridColumn colĐVT;
        private DevExpress.XtraGrid.Columns.GridColumn colKeHoach;
        private DevExpress.XtraGrid.Columns.GridColumn colThucHien;
        private DevExpress.XtraGrid.Columns.GridColumn colHoanThanh;
        private System.Windows.Forms.BindingSource dsMucTieuBindingSource;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit cboMucTieu;
        private DevExpress.XtraGrid.Views.Grid.GridView vMucTieu;
    }
}