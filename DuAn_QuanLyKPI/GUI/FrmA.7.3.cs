﻿using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessCommon;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid;
using System.Windows.Controls;
using DevExpress.XtraGrid.Views.Grid;

namespace DuAn_QuanLyKPI.GUI
{
    public partial class FrmA73 : DevExpress.XtraEditors.XtraForm
    {
        //lấy dữ liệu từu frm login
        public static string MaNV= Frm_Login.MaNV;
        public static string MaPhongKhoa = Frm_Login.MaPhongKhoa;
        public static string MaChucDanh = Frm_Login.MaChucDanh;
        public static string TenNV = Frm_Login.TenNV;
        public static string TenChucDanh = Frm_Login.TenChucDanh;
        public static string TenPhongKhoa = Frm_Login.TenPhongKhoa;

        private static string mconnectstring = Frm_Chinh_GUI.mconnectstring;
        private clsCommonMethod comm = new clsCommonMethod();
        private clsEventArgs ev = new clsEventArgs("");
        private string msql;

        private int CurrentTab = 0;
        public FrmA73()
        {
            InitializeComponent();
            LoadData();
            LoadThongTinNhanVien();           
        }
        GridHitInfo downHitInfor = null;

        #region Code của Phúc 
        private void gridmuctieubv_DragDrop(object sender, DragEventArgs e)
        {
            GridControl grid = sender as GridControl;
            DataTable table = grid.DataSource as DataTable;
            DataRow row = e.Data.GetData(typeof(DataRow)) as DataRow;
            if (row != null && table != null && row.Table != table)
            {
                table.ImportRow(row);
                row.Delete();
            }
        }

        private void gridmuctieubv_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(DataRow)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void gridnhapmuctieu_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void gridnhapmuctieu_DragOver(object sender, DragEventArgs e)
        {

        }

        private void dgrTaiChinh_MouseDown(object sender, MouseEventArgs e)
        {
            //GridView view = sender as GridView;
            //downHitInfor = null;
            //GridHitInfo hitInfor = view.CalcHitInfo(new Point(e.X, e.Y));
            //if (Control.ModifierKeys != Keys.None) return;
            //if (e.Button == MouseButtons.Left && hitInfor.RowHandle >= 0)
            //{
            //    downHitInfor = hitInfor;
            //}
        }

        private void dgrTaiChinh_MouseMove(object sender, MouseEventArgs e)
        {
            //GridView view = sender as GridView;
            //if (e.Button == MouseButtons.Left && downHitInfor != null)
            //{
            //    Size dragSize = SystemInformation.DragSize;
            //    Rectangle dragRect = new Rectangle(new Point(downHitInfor.HitPoint.X - dragSize.Width / 2, downHitInfor.HitPoint.Y - dragSize.Height / 2), dragSize);
            //    if (!dragRect.Contains(new Point(e.X, e.Y)))
            //    {
            //        DataRow row = view.GetDataRow(downHitInfor.RowHandle);
            //        view.GridControl.DoDragDrop(row, DragDropEffects.Move);
            //        downHitInfor = null;
            //        DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = true;
            //    }
            //}
        }

        #endregion




        private void LoadData()
        {
            msql = "select * from BangTamMucTieuKhoaPhong";
            DataTable tb = comm.GetDataTable(mconnectstring, msql, "BangTamMucTieuKhoaPhong");
            //dgrTaiChinh.AutoGenerateColumns = false;
            //dgrTaiChinh.DataSource = tb;
        }
        private void LoadThongTinNhanVien()
        {
            txtTenNV.Text = TenNV;
            txtTenNV1.Text = TenNV;
            txtTenNV2.Text = TenNV;
            txtTenNV3.Text = TenNV;
            txtTenNV4.Text = TenNV;

            txtViTriCV.Text = TenChucDanh;
            txtViTriCV1.Text = TenChucDanh;
            txtViTriCV2.Text = TenChucDanh;
            txtViTriCV3.Text = TenChucDanh;
            txtViTriCV4.Text = TenChucDanh;

            txtKhoaPhong.Text = TenPhongKhoa;
            txtKhoaPhong1.Text = TenPhongKhoa;
            txtKhoaPhong2.Text = TenPhongKhoa;
            txtKhoaPhong3.Text = TenPhongKhoa;
            txtKhoaPhong4.Text = TenPhongKhoa;
        }
        private void btnTiepTucTaiChinh_Click(object sender, EventArgs e)
        {
            //KiemTraTyTrong();
        }

        private void btnQuayLaiKhachHang_Click(object sender, EventArgs e)
        {
            ChuyenTrangThai(0);
        }

        private void btnTiepTucKhachHang_Click(object sender, EventArgs e)
        {
            ChuyenTrangThai(2);
        }

        private void btnQuayLaiVanHanh_Click(object sender, EventArgs e)
        {
            ChuyenTrangThai(1);
        }

        private void btnTiepTucVanHanh_Click(object sender, EventArgs e)
        {
            ChuyenTrangThai(3);
        }

        private void btnQuayLaiPhatTrien_Click(object sender, EventArgs e)
        {
            ChuyenTrangThai(2);
        }

        private void btnTiepTucPhatTrien_Click(object sender, EventArgs e)
        {
            ChuyenTrangThai(4);
        }

        private void btnQuayLaiHoanThanh_Click(object sender, EventArgs e)
        {
            ChuyenTrangThai(3);
        }

        private void btnHoanThanh_Click(object sender, EventArgs e)
        {
            
        }
        private void FrmA73_Load(object sender, EventArgs e)
        {
            TrangThai();
            TrangThai1();
            TrangThai2();
            TrangThai3();
            TrangThai4();
            //InVisible(tabTaiChinh);
            //InVisible(tabVanHanh);
            //InVisible(tabKhachHang);
            //InVisible(tabPhatTrien);
            //InVisible(tabHoanThanh);


        }
        //void InVisible(TabPage tab)
        //{
        //    tab.Text = "";
            
        //}
        private void TrangThai()
        {
            FrmSPTrangThai.ItemOptions.Indicator.Width = 50; // độ dài item
            FrmSPTrangThai.ConnectorLineThickness = 2; // viền đường kết nối
            FrmSPTrangThai.IndicatorLineThickness = 2; // viền đường tròn
            FrmSPTrangThai.ItemOptions.ConnectorOffset = -20; // điểm bắt đầu, kết thúc
            FrmSPTrangThai.ItemOptions.Indicator.ActiveStateDrawMode = IndicatorDrawMode.Outline; //click xanh viền tròn
            FrmSPTrangThai.ItemOptions.Indicator.InactiveStateDrawMode = IndicatorDrawMode.Outline; // chưa click viền tròn
        }
        private void TrangThai1()
        {
            FrmSPTrangThai1.ItemOptions.Indicator.Width = 50; // độ dài item
            FrmSPTrangThai1.ConnectorLineThickness = 2; // viền đường kết nối
            FrmSPTrangThai1.IndicatorLineThickness = 2; // viền đường tròn
            FrmSPTrangThai1.ItemOptions.ConnectorOffset = -20; // điểm bắt đầu, kết thúc
            FrmSPTrangThai1.ItemOptions.Indicator.ActiveStateDrawMode = IndicatorDrawMode.Outline; //click xanh viền tròn
            FrmSPTrangThai1.ItemOptions.Indicator.InactiveStateDrawMode = IndicatorDrawMode.Outline; // chưa click viền tròn

        }
        private void TrangThai2()
        {
            FrmSPTrangThai2.ItemOptions.Indicator.Width = 50; // độ dài item
            FrmSPTrangThai2.ConnectorLineThickness = 2; // viền đường kết nối
            FrmSPTrangThai2.IndicatorLineThickness = 2; // viền đường tròn
            FrmSPTrangThai2.ItemOptions.ConnectorOffset = -20; // điểm bắt đầu, kết thúc
            FrmSPTrangThai2.ItemOptions.Indicator.ActiveStateDrawMode = IndicatorDrawMode.Outline; //click xanh viền tròn
            FrmSPTrangThai2.ItemOptions.Indicator.InactiveStateDrawMode = IndicatorDrawMode.Outline; // chưa click viền tròn
            spTaiChinh2.State = StepProgressBarItemState.Active;
        }
        private void TrangThai3()
        {
            FrmSPTrangThai3.ItemOptions.Indicator.Width = 50; // độ dài item
            FrmSPTrangThai3.ConnectorLineThickness = 2; // viền đường kết nối
            FrmSPTrangThai3.IndicatorLineThickness = 2; // viền đường tròn
            FrmSPTrangThai3.ItemOptions.ConnectorOffset = -20; // điểm bắt đầu, kết thúc
            FrmSPTrangThai3.ItemOptions.Indicator.ActiveStateDrawMode = IndicatorDrawMode.Outline; //click xanh viền tròn
            FrmSPTrangThai3.ItemOptions.Indicator.InactiveStateDrawMode = IndicatorDrawMode.Outline; // chưa click viền tròn
            spTaiChinh3.State = StepProgressBarItemState.Active;
            spKhachHang3.State = StepProgressBarItemState.Active;
        }
        private void TrangThai4()
        {
            FrmSPTrangThai4.ItemOptions.Indicator.Width = 50; // độ dài item
            FrmSPTrangThai4.ConnectorLineThickness = 2; // viền đường kết nối
            FrmSPTrangThai4.IndicatorLineThickness = 2; // viền đường tròn
            FrmSPTrangThai4.ItemOptions.ConnectorOffset = -20; // điểm bắt đầu, kết thúc
            FrmSPTrangThai4.ItemOptions.Indicator.ActiveStateDrawMode = IndicatorDrawMode.Outline; //click xanh viền tròn
            FrmSPTrangThai4.ItemOptions.Indicator.InactiveStateDrawMode = IndicatorDrawMode.Outline; // chưa click viền tròn
            spTaiChinh4.State = StepProgressBarItemState.Active;
            spKhachHang4.State = StepProgressBarItemState.Active;
            spVanHanh4.State = StepProgressBarItemState.Active;
        }
        void ChuyenTrangThai(int step)
        {
            CurrentTab = step;
            switch (step)
            {
                case 0:
                    tabMucTieuKhoaPhong.SelectTab(step);
                    break;
                case 1:
                    tabMucTieuKhoaPhong.SelectTab(step);
                    // Thiết lập Trạng thái khi nhất nút
                    spTaiChinh1.State = StepProgressBarItemState.Active;
                    FrmSPTrangThai1.ItemOptions.Indicator.ActiveStateImageOptions.SvgImage = svgImageCollection1[0];
                    FrmSPTrangThai1.Appearances.CommonActiveColor = Color.Green;
                    FrmSPTrangThai1.Items[step-1].ContentBlock2.Caption = "Đã xong Tài Chính";
                    break;
                case 2:
                    tabMucTieuKhoaPhong.SelectTab(step);
                    // Thiết lập Trạng thái khi nhất nút
                    spKhachHang2.State = StepProgressBarItemState.Active;
                    FrmSPTrangThai2.ItemOptions.Indicator.ActiveStateImageOptions.SvgImage = svgImageCollection1[0];
                    FrmSPTrangThai2.Appearances.CommonActiveColor = Color.Green;
                    FrmSPTrangThai2.Items[step - 1].ContentBlock2.Caption = "Đã xong Khách Hàng";
                    break;
                case 3:
                    tabMucTieuKhoaPhong.SelectTab(step);
                    // Thiết lập Trạng thái khi nhất nút
                    spVanHanh3.State = StepProgressBarItemState.Active;
                    FrmSPTrangThai3.ItemOptions.Indicator.ActiveStateImageOptions.SvgImage = svgImageCollection1[0];
                    FrmSPTrangThai3.Appearances.CommonActiveColor = Color.Green;
                    FrmSPTrangThai3.Items[step - 1].ContentBlock2.Caption = "Đã xong Vận Hành";
                    break;
                case 4:
                    tabMucTieuKhoaPhong.SelectTab(step);
                    spPhatTrien4.State = StepProgressBarItemState.Active;
                    FrmSPTrangThai4.ItemOptions.Indicator.ActiveStateImageOptions.SvgImage = svgImageCollection1[0];
                    FrmSPTrangThai4.Appearances.CommonActiveColor = Color.Green;
                    FrmSPTrangThai4.Items[step - 1].ContentBlock2.Caption = "Đã xong Phát Triển";
                    break;
            }
        }
        private void tabMucTieuKhoaPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            //chặn click vào tab
            tabMucTieuKhoaPhong.SelectedIndex = CurrentTab;
        }

        private void txtMucTieu_Click(object sender, EventArgs e)
        {
        }

        private void txtMucTieu_Enter(object sender, EventArgs e)
        {
            LoadDataMucTieu();
            //dgrChonMucTieu.Visible = true;

        }

        private void LoadDataMucTieu()
        {
            msql = "select * from [KPITrongNganHang] as A, [NganHangKPI] as B, [KPI] as C where A.MaKPI = C.MaKPI and A.MaNganHangKPI = B.MaNganHangKPI and B.MaPK='" + MaPhongKhoa + "' and B.MaChucDanh='" + MaChucDanh + "'";
            DataTable tb = comm.GetDataTable(mconnectstring, msql, "KPITrongNganHang");
            //dgrChonMucTieu.AutoGenerateColumns = false;
            //dgrChonMucTieu.DataSource = tb;
            //var list = DataProvider.Ins.DB.KPI.Where(x => x.NganHangKPI.Any(a => a.MaPK == MaPhongKhoa)).ToList();
            //dgrChonMucTieu.AutoGenerateColumns = false;
            //dgrChonMucTieu.DataSource = list;
        }

        //private void dgrChonMucTieu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        //{
        //    ev.Qdgr_RowPostPaint(sender, e, dgrChonMucTieu);
        //}
        //private void dgrTaiChinh_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        //{
        //    ev.Qdgr_RowPostPaint(sender, e, dgrTaiChinh);
        //}
        //private void txtTrongSoTC_Click(object sender, EventArgs e)
        //{
        //    dgrChonMucTieu.Visible = false;
        //}

        //private void txtTieuChiDanhGiaTC_Click(object sender, EventArgs e)
        //{
        //    dgrChonMucTieu.Visible = false;
        //}

        //private void txtHoanThanhTC_Click(object sender, EventArgs e)
        //{
        //    dgrChonMucTieu.Visible = false;
        //}
        //private void dgrChonMucTieu_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    txtMucTieuTC.Text = dgrChonMucTieu.CurrentRow.Cells["cNoiDung"].Value.ToString();
        //    dgrChonMucTieu.Visible = false;
        //}

        //private void txtMucTieu_Leave(object sender, EventArgs e)
        //{
        //    //txtMucTieu.Text = dgrChonMucTieu.CurrentRow.Cells["cNoiDung"].Value.ToString();
            
        //}
        //private void txtMucTieu_TextChanged(object sender, EventArgs e)
        //{
        //    dgrChonMucTieu.Visible = false;
        //}

        private void btnThem_Click(object sender, EventArgs e)
        {
            //ThemDuLieu();
            LoadData();
            XoaThongTin();
        }
        //private void ThemDuLieu()
        //{
        //    //// Lấy tổng các giá trị trong các cột
        //    //int total = 0;
        //    //for (int i = 0; i < dgrTaiChinh.Rows.Count; i++)
        //    //{
        //    //    total += int.Parse(dgrTaiChinh.CurrentRow.Cells["cTrongSo"].Value.ToString());
        //    //}

        //    //int value = int.Parse(txtTrongSoTC.Text);
        //    //int tytrong = total + value;
        //    //// Kiểm tra giá trị
        //    //if (tytrong > 100)
        //    //{
        //    //    ev.QFrmThongBao("Lưu ý: Tỷ trọng vượt quá 100%");
        //    //}
        //    //else 
        //    //{
        //    //    msql = "INSERT INTO [dbo].[BangTamMucTieuKhoaPhong]([MaKPI],[MucTieu],[TrongSo],[TieuChiDanhGia],[HoanThanh])" +
        //    //    "VALUES ('" + txtMaKPITC.Text + "', N'" + txtMucTieuTC.Text + "', '" + txtTrongSoTC.Text + "', N'" + txtTieuChiDanhGiaTC.Text + "', '" + txtHoanThanhTC.Text + "')";
        //    //    comm.RunSQL(mconnectstring, msql);
        //    //    ev.QFrmThongBao("Đã thêm thành công");
        //    //}
        //    {
        //        // Khai báo biến tổng và biến đếm
        //        int total = 0;
        //        int count = 0;

        //        // Vòng lặp duyệt qua tất cả các hàng trong bảng
        //        for (int i = 0; i < dgrTaiChinh.Rows.Count; i++)
        //        {
        //            // Lấy giá trị trong cột tỷ trọng của hàng hiện tại
        //            int trongSo = int.Parse(dgrTaiChinh.CurrentRow.Cells["cTrongSo"].Value.ToString());

        //            // Thêm giá trị này vào biến tổng
        //            total += trongSo;

        //            // Tăng biến đếm lên 1
        //            count++;
                    
        //        }
        //        if (total > 100)
        //        {
        //            ev.QFrmThongBao("Lưu ý: Tỷ trọng vượt quá 100%");
        //        }
        //        else
        //        {
        //            msql = "INSERT INTO [dbo].[BangTamMucTieuKhoaPhong]([MaKPI],[MucTieu],[TrongSo],[TieuChiDanhGia],[HoanThanh])" +
        //            "VALUES ('" + txtMaKPITC.Text + "', N'" + txtMucTieuTC.Text + "', '" + txtTrongSoTC.Text + "', N'" + txtTieuChiDanhGiaTC.Text + "', '" + txtHoanThanhTC.Text + "')";
        //            comm.RunSQL(mconnectstring, msql);
        //            ev.QFrmThongBao("Đã thêm thành công");
        //        }
        //    }
        //}
        //private void KiemTraTyTrong()
        //{
        //    // Lấy tổng các giá trị trong các cột
        //    int total = 0;
        //    for (int i = 1; i < dgrTaiChinh.Rows.Count; i++)
        //    {
        //        total += int.Parse(dgrTaiChinh.CurrentRow.Cells["cTrongSo"].Value.ToString());
        //    }

        //    // Kiểm tra tổng các giá trị
        //    if (total > 100)
        //    {
        //        ev.QFrmThongBao("Lưu ý: Kiểm tra tỷ trọng vượt quá 100%");
                
        //    }
        //    else 
        //    {
        //        // Thông báo
        //        ChuyenTrangThai(1);
        //    }
            
        //}
        private void XoaThongTin()
        {
            txtMaKPITC.Text = "";
            txtMucTieuTC.Text = "";
            txtTrongSoTC.Text = "";
            txtTieuChiDanhGiaTC.Text = "";
            txtHoanThanhTC.Text = "";
        }

        
    }
}