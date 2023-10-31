
namespace DuAn_QuanLyKPI
{
    partial class Frm_Chinh_GUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Chinh_GUI));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnDMCaNhan = new DevExpress.XtraBars.BarSubItem();
            this.btnThongTinCaNhan = new DevExpress.XtraBars.BarButtonItem();
            this.btnDanhMucKPI = new DevExpress.XtraBars.BarSubItem();
            this.btnDanhSachKPI = new DevExpress.XtraBars.BarButtonItem();
            this.btnLanhDao = new DevExpress.XtraBars.BarButtonItem();
            this.btnPhongBan = new DevExpress.XtraBars.BarButtonItem();
            this.btnCaNhan = new DevExpress.XtraBars.BarButtonItem();
            this.btnCaiDat = new DevExpress.XtraBars.BarSubItem();
            this.btnQuanLyPhongBan = new DevExpress.XtraBars.BarButtonItem();
            this.btnPhanQuyen = new DevExpress.XtraBars.BarButtonItem();
            this.btnCauHinhHeThong = new DevExpress.XtraBars.BarButtonItem();
            this.btnCongCu = new DevExpress.XtraBars.BarButtonItem();
            this.btnThongTinHeThong = new DevExpress.XtraBars.BarButtonItem();
            this.btnThoat = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem5 = new DevExpress.XtraBars.BarSubItem();
            this.btnNganHangKPI = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.btnKiemDuyet = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.rbTrangChu = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbCaNhan = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.btnDMCaNhan,
            this.btnDanhMucKPI,
            this.btnCaiDat,
            this.barSubItem5,
            this.btnDanhSachKPI,
            this.btnPhongBan,
            this.btnLanhDao,
            this.btnCaNhan,
            this.btnNganHangKPI,
            this.btnQuanLyPhongBan,
            this.btnPhanQuyen,
            this.btnCauHinhHeThong,
            this.btnCongCu,
            this.btnThongTinHeThong,
            this.btnThoat,
            this.btnThongTinCaNhan,
            this.btnKiemDuyet,
            this.barButtonItem2,
            this.barButtonItem3});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 29;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rbTrangChu});
            this.ribbon.Size = new System.Drawing.Size(1364, 158);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // btnDMCaNhan
            // 
            this.btnDMCaNhan.Caption = "Danh mục cá nhân";
            this.btnDMCaNhan.Id = 2;
            this.btnDMCaNhan.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDMCaNhan.ImageOptions.Image")));
            this.btnDMCaNhan.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDMCaNhan.ImageOptions.LargeImage")));
            this.btnDMCaNhan.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnThongTinCaNhan)});
            this.btnDMCaNhan.Name = "btnDMCaNhan";
            // 
            // btnThongTinCaNhan
            // 
            this.btnThongTinCaNhan.Caption = "Thông tin cá nhân";
            this.btnThongTinCaNhan.Id = 24;
            this.btnThongTinCaNhan.Name = "btnThongTinCaNhan";
            this.btnThongTinCaNhan.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThongTinCaNhan_ItemClick);
            // 
            // btnDanhMucKPI
            // 
            this.btnDanhMucKPI.Caption = "Danh mục KPI";
            this.btnDanhMucKPI.Id = 3;
            this.btnDanhMucKPI.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDanhMucKPI.ImageOptions.Image")));
            this.btnDanhMucKPI.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDanhMucKPI.ImageOptions.LargeImage")));
            this.btnDanhMucKPI.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDanhSachKPI),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnLanhDao),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPhongBan),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCaNhan)});
            this.btnDanhMucKPI.Name = "btnDanhMucKPI";
            // 
            // btnDanhSachKPI
            // 
            this.btnDanhSachKPI.Caption = "Danh sách KPI";
            this.btnDanhSachKPI.Id = 7;
            this.btnDanhSachKPI.Name = "btnDanhSachKPI";
            // 
            // btnLanhDao
            // 
            this.btnLanhDao.Caption = "Lãnh đạo";
            this.btnLanhDao.Id = 15;
            this.btnLanhDao.Name = "btnLanhDao";
            // 
            // btnPhongBan
            // 
            this.btnPhongBan.Caption = "Phòng Ban";
            this.btnPhongBan.Id = 8;
            this.btnPhongBan.Name = "btnPhongBan";
            // 
            // btnCaNhan
            // 
            this.btnCaNhan.Caption = "Cá nhân";
            this.btnCaNhan.Id = 16;
            this.btnCaNhan.Name = "btnCaNhan";
            // 
            // btnCaiDat
            // 
            this.btnCaiDat.Caption = "Danh mục cài đặt ";
            this.btnCaiDat.Id = 5;
            this.btnCaiDat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCaiDat.ImageOptions.Image")));
            this.btnCaiDat.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnCaiDat.ImageOptions.LargeImage")));
            this.btnCaiDat.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnQuanLyPhongBan),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPhanQuyen),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCauHinhHeThong),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCongCu),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnThongTinHeThong),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnThoat)});
            this.btnCaiDat.Name = "btnCaiDat";
            // 
            // btnQuanLyPhongBan
            // 
            this.btnQuanLyPhongBan.Caption = "Quản lý Phòng ban ";
            this.btnQuanLyPhongBan.Id = 18;
            this.btnQuanLyPhongBan.Name = "btnQuanLyPhongBan";
            // 
            // btnPhanQuyen
            // 
            this.btnPhanQuyen.Caption = "Phân quyền";
            this.btnPhanQuyen.Id = 19;
            this.btnPhanQuyen.Name = "btnPhanQuyen";
            // 
            // btnCauHinhHeThong
            // 
            this.btnCauHinhHeThong.Caption = "Cấu hình hệ thống";
            this.btnCauHinhHeThong.Id = 20;
            this.btnCauHinhHeThong.Name = "btnCauHinhHeThong";
            // 
            // btnCongCu
            // 
            this.btnCongCu.Caption = "Công cụ";
            this.btnCongCu.Id = 21;
            this.btnCongCu.Name = "btnCongCu";
            // 
            // btnThongTinHeThong
            // 
            this.btnThongTinHeThong.Caption = "Thông tin hệ thống ";
            this.btnThongTinHeThong.Id = 22;
            this.btnThongTinHeThong.Name = "btnThongTinHeThong";
            this.btnThongTinHeThong.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThongTinHeThong_ItemClick);
            // 
            // btnThoat
            // 
            this.btnThoat.Caption = "Thoát chương trình";
            this.btnThoat.Id = 23;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThoat_ItemClick);
            // 
            // barSubItem5
            // 
            this.barSubItem5.Caption = "Ngân hàng KPI ";
            this.barSubItem5.Id = 6;
            this.barSubItem5.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barSubItem5.ImageOptions.Image")));
            this.barSubItem5.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barSubItem5.ImageOptions.LargeImage")));
            this.barSubItem5.Name = "barSubItem5";
            // 
            // btnNganHangKPI
            // 
            this.btnNganHangKPI.Caption = "Ngân hàng KPI";
            this.btnNganHangKPI.Id = 17;
            this.btnNganHangKPI.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNganHangKPI.ImageOptions.Image")));
            this.btnNganHangKPI.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnNganHangKPI.ImageOptions.LargeImage")));
            this.btnNganHangKPI.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem2)});
            this.btnNganHangKPI.Name = "btnNganHangKPI";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Danh sách KPI";
            this.barButtonItem2.Id = 27;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // btnKiemDuyet
            // 
            this.btnKiemDuyet.Caption = "Kiểm duyệt biểu mẫu";
            this.btnKiemDuyet.Id = 26;
            this.btnKiemDuyet.ImageOptions.Image = global::DuAn_QuanLyKPI.Properties.Resources.task_32x32;
            this.btnKiemDuyet.ImageOptions.LargeImage = global::DuAn_QuanLyKPI.Properties.Resources.task_32x32;
            this.btnKiemDuyet.Name = "btnKiemDuyet";
            this.btnKiemDuyet.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnKiemDuyet_ItemClick);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Quản lý Người dùng ";
            this.barButtonItem3.Id = 28;
            this.barButtonItem3.ImageOptions.Image = global::DuAn_QuanLyKPI.Properties.Resources.publicfix_32x32;
            this.barButtonItem3.ImageOptions.LargeImage = global::DuAn_QuanLyKPI.Properties.Resources.publicfix_32x32;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // rbTrangChu
            // 
            this.rbTrangChu.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rbCaNhan,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3,
            this.ribbonPageGroup4});
            this.rbTrangChu.Name = "rbTrangChu";
            this.rbTrangChu.Text = "Trang chủ ";
            // 
            // rbCaNhan
            // 
            this.rbCaNhan.ItemLinks.Add(this.btnDMCaNhan);
            this.rbCaNhan.Name = "rbCaNhan";
            this.rbCaNhan.Text = "Cá nhân ";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnDanhMucKPI);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnNganHangKPI);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnKiemDuyet);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "KPI";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem3);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "User";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.btnCaiDat);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "Cài đặt hệ thống ";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 743);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1364, 24);
            // 
            // documentManager1
            // 
            this.documentManager1.MdiParent = this;
            this.documentManager1.MenuManager = this.ribbon;
            this.documentManager1.View = this.tabbedView1;
            this.documentManager1.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabbedView1});
            // 
            // Frm_Chinh_GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 767);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.IsMdiContainer = true;
            this.Name = "Frm_Chinh_GUI";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbTrangChu;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbCaNhan;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.BarSubItem btnDMCaNhan;
        private DevExpress.XtraBars.BarSubItem btnDanhMucKPI;
        private DevExpress.XtraBars.BarSubItem btnCaiDat;
        private DevExpress.XtraBars.BarSubItem barSubItem5;
        private DevExpress.XtraBars.BarButtonItem btnDanhSachKPI;
        private DevExpress.XtraBars.BarButtonItem btnPhongBan;
        private DevExpress.XtraBars.BarButtonItem btnLanhDao;
        private DevExpress.XtraBars.BarButtonItem btnCaNhan;
        private DevExpress.XtraBars.BarSubItem btnNganHangKPI;
        private DevExpress.XtraBars.BarButtonItem btnQuanLyPhongBan;
        private DevExpress.XtraBars.BarButtonItem btnPhanQuyen;
        private DevExpress.XtraBars.BarButtonItem btnCauHinhHeThong;
        private DevExpress.XtraBars.BarButtonItem btnCongCu;
        private DevExpress.XtraBars.BarButtonItem btnThongTinHeThong;
        private DevExpress.XtraBars.BarButtonItem btnThoat;
        private DevExpress.XtraBars.BarButtonItem btnThongTinCaNhan;
        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView1;
        private DevExpress.XtraBars.BarButtonItem btnKiemDuyet;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
    }
}