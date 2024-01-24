using BusinessCommon;
using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace DuAn_QuanLyKPI.GUI
{
    public partial class FrmA73 : DevExpress.XtraEditors.XtraForm
    {
        //lấy dữ liệu từu frm login
        private static string MaNV = Frm_Login.MaNV;
        private static string MaPhongKhoa = Frm_Login.MaPhongKhoa;
        private static string MaChucDanh = Frm_Login.MaChucDanh;
        private static string TenNV = Frm_Login.TenNV;
        private static string TenChucDanh = Frm_Login.TenChucDanh;
        private static string TenPhongKhoa = Frm_Login.TenPhongKhoa;
        private static string QuyNamPhieu = FrmChonBieuMau.QuyNam;

        //coneect & event
        private static string mconnectstring = Frm_A78.mconnectstring;
        private clsCommonMethod comm = new clsCommonMethod();
        private clsEventArgs ev = new clsEventArgs(string.Empty);
        private string msql;

        Timer updateTimer;
        DataTable tc = new DataTable();
        DataTable kh = new DataTable();
        DataTable vh = new DataTable();
        DataTable pt = new DataTable();

        private int CurrentTab = 0;

        private DataGridView[] dataGridViews;
        private TextBox[] textBoxes;
        public FrmA73()
        {
            InitializeComponent();
            InitializeDataGridViews();
            LoadThongTinNhanVien();
            LoadDataBVTaiChinh();
            
            CreateTableCopyTC();

            updateTimer = new Timer { Interval = 100 };
            updateTimer.Tick += UpdateTimer_Tick;
        }
        private void FrmA73_Load(object sender, EventArgs e)
        {
            TrangThai();
            TrangThai1();
            TrangThai2();
            TrangThai3();
            TrangThai4();
        }
        private void InitializeDataGridViews()
        {
            // Khởi tạo mảng DataGridView
            dataGridViews = new DataGridView[] { dgrHTMucTieuTaiChinh, dgrHTMucTieuKhachHang, dgrHTMucTieuVanHanh, dgrHTMucTieuPhatTrien };

            // Code khởi tạo và hiển thị dữ liệu trong các DataGridView ở đây...

            // Ví dụ:
            for (int i = 0; i < dataGridViews.Length; i++)
            {
                dataGridViews[i].Rows.Add($"Row {i + 1}, Column 1", $"Row {i + 1}, Column 2", $"Row {i + 1}, Column 3");
            }
        }

        #region LoadDataGrid
        //Load thông tin nhân viên 
        private void LoadThongTinNhanVien()
        {
            txtTenNVTC.Text = TenNV;
            txtTenNVKH.Text = TenNV;
            txtTenNVVH.Text = TenNV;
            txtTenNVPT.Text = TenNV;
            txtTenNVHT.Text = TenNV;

            txtViTriCVTC.Text = TenChucDanh;
            txtViTriCVKH.Text = TenChucDanh;
            txtViTriCVVH.Text = TenChucDanh;
            txtViTriCVPT.Text = TenChucDanh;
            txtViTriCVHT.Text = TenChucDanh; 

            lbKhoaPhongTC.Text = TenPhongKhoa;
            lbKhoaPhongKH.Text = TenPhongKhoa;
            lbKhoaPhongVH.Text = TenPhongKhoa;
            lbKhoaPhongPT.Text = TenPhongKhoa;
            lbKhoaPhongHT.Text = TenPhongKhoa;
        }
        //Load DataGridview Tài chính
        private void LoadDataBVTaiChinh()
        {
            msql = "SELECT * FROM dbo.KPI INNER JOIN dbo.ChiTietTieuChiMucTieuBV ON dbo.KPI.MaKPI = dbo.ChiTietTieuChiMucTieuBV.MaKPI INNER JOIN dbo.KPI_BenhVien ON dbo.ChiTietTieuChiMucTieuBV.MaPhieuKPIBV = dbo.KPI_BenhVien.MaPhieuKPIBV WHERE dbo.KPI.TieuChiID = 'F' AND dbo.KPI_BenhVien.NamPhieu = '" + QuyNamPhieu + "' ";
            DataTable tb = comm.GetDataTable(mconnectstring, msql, "Taichinh");
            dgrBVMucTieuTaiChinh.AutoGenerateColumns = false;
            dgrBVMucTieuTaiChinh.DataSource = tb;
            lbYearTC.Text = dgrBVMucTieuTaiChinh.Rows[0].Cells["cNamBVTC"].Value.ToString();
        }
        private void LoadDataBVKhachHang()
        {
            msql = "SELECT * FROM dbo.KPI INNER JOIN dbo.ChiTietTieuChiMucTieuBV ON dbo.KPI.MaKPI = dbo.ChiTietTieuChiMucTieuBV.MaKPI INNER JOIN dbo.KPI_BenhVien ON dbo.ChiTietTieuChiMucTieuBV.MaPhieuKPIBV = dbo.KPI_BenhVien.MaPhieuKPIBV WHERE dbo.KPI.TieuChiID = 'C' AND dbo.KPI_BenhVien.NamPhieu = '" + QuyNamPhieu + "'";
            DataTable tb = comm.GetDataTable(mconnectstring, msql, "KhachHang");
            dgrBVMucTieuKhachHang.AutoGenerateColumns = false;
            dgrBVMucTieuKhachHang.DataSource = tb;

            lbYearKH.Text = dgrBVMucTieuKhachHang.Rows[0].Cells["cNamBVKH"].Value.ToString();
        }
        private void LoadDataBVVanHanh()
        {
            msql = "SELECT * FROM dbo.KPI INNER JOIN dbo.ChiTietTieuChiMucTieuBV ON dbo.KPI.MaKPI = dbo.ChiTietTieuChiMucTieuBV.MaKPI INNER JOIN dbo.KPI_BenhVien ON dbo.ChiTietTieuChiMucTieuBV.MaPhieuKPIBV = dbo.KPI_BenhVien.MaPhieuKPIBV WHERE dbo.KPI.TieuChiID = 'B' AND dbo.KPI_BenhVien.NamPhieu = '" + QuyNamPhieu + "'";
            DataTable tb = comm.GetDataTable(mconnectstring, msql, "VanHanh");
            dgrBVMucTieuVanHanh.AutoGenerateColumns = false;
            dgrBVMucTieuVanHanh.DataSource = tb;

            lbYearVH.Text = dgrBVMucTieuVanHanh.Rows[0].Cells["cNamBVVH"].Value.ToString();

        }
        private void LoadDataBVPhatTrien()
        {
            msql = "SELECT * FROM dbo.KPI INNER JOIN dbo.ChiTietTieuChiMucTieuBV ON dbo.KPI.MaKPI = dbo.ChiTietTieuChiMucTieuBV.MaKPI INNER JOIN dbo.KPI_BenhVien ON dbo.ChiTietTieuChiMucTieuBV.MaPhieuKPIBV = dbo.KPI_BenhVien.MaPhieuKPIBV WHERE dbo.KPI.TieuChiID = 'L' AND dbo.KPI_BenhVien.NamPhieu = '" + QuyNamPhieu + "'";
            DataTable tb = comm.GetDataTable(mconnectstring, msql, "PhatTrien");
            dgrBVMucTieuPhatTrien.AutoGenerateColumns = false;
            dgrBVMucTieuPhatTrien.DataSource = tb;

            lbYearPT.Text = dgrBVMucTieuPhatTrien.Rows[0].Cells["cNamBVPT"].Value.ToString();
        }
        #endregion
        #region Method Chuyển Tab


        private void TrangThai()
        {
            FrmSPTrangThaiTC.ItemOptions.Indicator.Width = 50; // độ dài item
            FrmSPTrangThaiTC.ConnectorLineThickness = 2; // viền đường kết nối
            FrmSPTrangThaiTC.IndicatorLineThickness = 2; // viền đường tròn
            FrmSPTrangThaiTC.ItemOptions.ConnectorOffset = 20; // điểm bắt đầu, kết thúc
            FrmSPTrangThaiTC.ItemOptions.Indicator.ActiveStateDrawMode = IndicatorDrawMode.Outline; //click xanh viền tròn
            FrmSPTrangThaiTC.ItemOptions.Indicator.InactiveStateDrawMode = IndicatorDrawMode.Outline; // chưa click viền tròn
        }
        private void TrangThai1()
        {
            FrmSPTrangThaiKH.ItemOptions.Indicator.Width = 50; // độ dài item
            FrmSPTrangThaiKH.ConnectorLineThickness = 2; // viền đường kết nối
            FrmSPTrangThaiKH.IndicatorLineThickness = 2; // viền đường tròn
            FrmSPTrangThaiKH.ItemOptions.ConnectorOffset = 20; // điểm bắt đầu, kết thúc
            FrmSPTrangThaiKH.ItemOptions.Indicator.ActiveStateDrawMode = IndicatorDrawMode.Outline; //click xanh viền tròn
            FrmSPTrangThaiKH.ItemOptions.Indicator.InactiveStateDrawMode = IndicatorDrawMode.Outline; // chưa click viền tròn
        }
        private void TrangThai2()
        {
            FrmSPTrangThaiVH.ItemOptions.Indicator.Width = 50; // độ dài item
            FrmSPTrangThaiVH.ConnectorLineThickness = 2; // viền đường kết nối
            FrmSPTrangThaiVH.IndicatorLineThickness = 2; // viền đường tròn
            FrmSPTrangThaiVH.ItemOptions.ConnectorOffset = -20; // điểm bắt đầu, kết thúc
            FrmSPTrangThaiVH.ItemOptions.Indicator.ActiveStateDrawMode = IndicatorDrawMode.Outline; //click xanh viền tròn
            FrmSPTrangThaiVH.ItemOptions.Indicator.InactiveStateDrawMode = IndicatorDrawMode.Outline; // chưa click viền tròn
            spTaiChinhVH.State = StepProgressBarItemState.Active;
        }
        private void TrangThai3()
        {
            FrmSPTrangThaiPT.ItemOptions.Indicator.Width = 50; // độ dài item
            FrmSPTrangThaiPT.ConnectorLineThickness = 2; // viền đường kết nối
            FrmSPTrangThaiPT.IndicatorLineThickness = 2; // viền đường tròn
            FrmSPTrangThaiPT.ItemOptions.ConnectorOffset = -20; // điểm bắt đầu, kết thúc
            FrmSPTrangThaiPT.ItemOptions.Indicator.ActiveStateDrawMode = IndicatorDrawMode.Outline; //click xanh viền tròn
            FrmSPTrangThaiPT.ItemOptions.Indicator.InactiveStateDrawMode = IndicatorDrawMode.Outline; // chưa click viền tròn
            spTaiChinhPT.State = StepProgressBarItemState.Active;
            spKhachHangPT.State = StepProgressBarItemState.Active;
        }
        private void TrangThai4()
        {
            FrmSPTrangThaiHT.ItemOptions.Indicator.Width = 50; // độ dài item
            FrmSPTrangThaiHT.ConnectorLineThickness = 2; // viền đường kết nối
            FrmSPTrangThaiHT.IndicatorLineThickness = 2; // viền đường tròn
            FrmSPTrangThaiHT.ItemOptions.ConnectorOffset = -20; // điểm bắt đầu, kết thúc
            FrmSPTrangThaiHT.ItemOptions.Indicator.ActiveStateDrawMode = IndicatorDrawMode.Outline; //click xanh viền tròn
            FrmSPTrangThaiHT.ItemOptions.Indicator.InactiveStateDrawMode = IndicatorDrawMode.Outline; // chưa click viền tròn
            spTaiChinhHT.State = StepProgressBarItemState.Active;
            spKhachHangHT.State = StepProgressBarItemState.Active;
            spVanHanhHT.State = StepProgressBarItemState.Active;
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
                    spTaiChinhKH.State = StepProgressBarItemState.Active;
                    FrmSPTrangThaiKH.ItemOptions.Indicator.ActiveStateImageOptions.SvgImage = svgImageCollection1[0];
                    FrmSPTrangThaiKH.Appearances.CommonActiveColor = Color.Green;
                    FrmSPTrangThaiKH.Items[step - 1].ContentBlock2.Caption = "Đã xong Tài Chính";
                    LoadDataBVKhachHang();
                    break;
                case 2:
                    tabMucTieuKhoaPhong.SelectTab(step);
                    //Thiết lập Trạng thái khi nhất nút
                    spKhachHangVH.State = StepProgressBarItemState.Active;
                    FrmSPTrangThaiVH.ItemOptions.Indicator.ActiveStateImageOptions.SvgImage = svgImageCollection1[0];
                    FrmSPTrangThaiVH.Appearances.CommonActiveColor = Color.Green;
                    FrmSPTrangThaiVH.Items[step - 1].ContentBlock2.Caption = "Đã xong Khách Hàng";
                    LoadDataBVVanHanh();
                    break;
                case 3:
                    tabMucTieuKhoaPhong.SelectTab(step);
                    //Thiết lập Trạng thái khi nhất nút
                    spVanHanhPT.State = StepProgressBarItemState.Active;
                    FrmSPTrangThaiPT.ItemOptions.Indicator.ActiveStateImageOptions.SvgImage = svgImageCollection1[0];
                    FrmSPTrangThaiPT.Appearances.CommonActiveColor = Color.Green;
                    FrmSPTrangThaiPT.Items[step - 1].ContentBlock2.Caption = "Đã xong Vận Hành";
                    LoadDataBVPhatTrien();
                    break;
                case 4:
                    tabMucTieuKhoaPhong.SelectTab(step);
                    spPhatTrienHT.State = StepProgressBarItemState.Active;
                    FrmSPTrangThaiHT.ItemOptions.Indicator.ActiveStateImageOptions.SvgImage = svgImageCollection1[0];
                    FrmSPTrangThaiHT.Appearances.CommonActiveColor = Color.Green;
                    FrmSPTrangThaiHT.Items[step - 1].ContentBlock2.Caption = "Đã xong Phát Triển";
                    break;
            }
        }
        private void KiemTraTyTrong(int step)
        {
            // Lấy tổng các giá trị trong các cột
            if (dgrNhapMucTieuTaiChinh.Rows.Count > 0)
            {
                switch (step)
                {
                    case 1:
                        int rowdgrtc = dgrNhapMucTieuTaiChinh.Rows.Count;
                        int totaltc = 0;
                        for (int i = 0; i < rowdgrtc; ++i)
                            totaltc += int.Parse(dgrNhapMucTieuTaiChinh.Rows[i].Cells["cTrongSoKPINTC"].Value.ToString());

                        if (totaltc == 0 && totaltc == 0 || totaltc == null && totaltc == null)
                        {
                            ev.QFrmThongBao("Lưu ý: Chưa nhập tỷ trọng");
                        }
                        else if (totaltc > 100 && int.Parse(txtTongTrongSoTC.Text) > 100)
                        {
                            ev.QFrmThongBaoError("Trọng số đã vượt quá 100%");
                        }
                        else if (totaltc > 0 && totaltc < 100 && int.Parse(txtTongTrongSoTC.Text) > 0 && int.Parse(txtTongTrongSoTC.Text) < 100)
                        {
                            ev.QFrmThongBaoError("Trọng số chưa được 100%");
                        }
                        else if (totaltc == 100 && int.Parse(txtTongTrongSoTC.Text) == 100)
                        {
                            LoadDataBVKhachHang();
                            CopyTCtoHT();
                            ChuyenTrangThai(1);
                            if (txtTongTrongSoKH.Text == string.Empty)
                            {
                                CreateTableCopyKH();
                            }
                            else
                            {

                            }
                        }
                        else if (totaltc == null && int.Parse(txtTongTrongSoTC.Text) == null)
                        {
                            ev.QFrmThongBaoError("Lỗi không có dữ liệu");
                        }
                        break;
                    case 2:
                        int rowdgrkh = dgrNhapMucTieuKhachHang.Rows.Count;
                        int totalkh = 0;
                        for (int i = 0; i < rowdgrkh; ++i)
                            totalkh += int.Parse(dgrNhapMucTieuKhachHang.Rows[i].Cells["cTrongSoKPINKH"].Value.ToString());
                        if (totalkh == 0 && totalkh == 0 || totalkh == null && totalkh == null)
                        {
                            ev.QFrmThongBao("Lưu ý: Chưa nhập tỷ trọng");
                        }
                        else if (totalkh > 100 && int.Parse(txtTongTrongSoKH.Text) > 100)
                        {
                            ev.QFrmThongBaoError("Trọng số đã vượt quá 100%");
                        }
                        else if (totalkh > 0 && totalkh < 100 && int.Parse(txtTongTrongSoKH.Text) > 0 && int.Parse(txtTongTrongSoKH.Text) < 100)
                        {
                            ev.QFrmThongBaoError("Trọng số chưa được 100%");
                        }
                        else if (totalkh == 100 && int.Parse(txtTongTrongSoKH.Text) == 100)
                        {
                            CopyKHtoHT();
                            LoadDataBVVanHanh();
                            ChuyenTrangThai(2);
                            if (txtTongTrongSoVH.Text == string.Empty)
                            {
                                CreateTableCopyVH();
                            }
                            else
                            {

                            }
                        }
                        else if (totalkh == null && int.Parse(txtTongTrongSoKH.Text) == null)
                        {
                            ev.QFrmThongBaoError("Lỗi không có dữ liệu");
                        }
                        break;
                    case 3:
                        int rowdgrvh = dgrNhapMucTieuVanHanh.Rows.Count;
                        int totalvh = 0;
                        for (int i = 0; i < rowdgrvh; ++i)
                            totalvh += int.Parse(dgrNhapMucTieuVanHanh.Rows[i].Cells["cTrongSoKPINVH"].Value.ToString());
                        if (totalvh == 0 && totalvh == 0 || totalvh == null && totalvh == null)
                        {
                            ev.QFrmThongBao("Lưu ý: Chưa nhập tỷ trọng");
                        }
                        else if (totalvh > 100 && int.Parse(txtTongTrongSoVH.Text) > 100)
                        {
                            ev.QFrmThongBaoError("Trọng số đã vượt quá 100%");
                        }
                        else if (totalvh > 0 && totalvh < 100 && int.Parse(txtTongTrongSoVH.Text) > 0 && int.Parse(txtTongTrongSoVH.Text) < 100)
                        {
                            ev.QFrmThongBaoError("Trọng số chưa được 100%");
                        }
                        else if (totalvh == 100 && int.Parse(txtTongTrongSoVH.Text) == 100)
                        {
                            CopyVHtoHT();
                            LoadDataBVPhatTrien();
                            ChuyenTrangThai(3);
                            if (txtTongTrongSoPT.Text == string.Empty)
                            {
                                CreateTableCopyPT();
                            }
                            else
                            {

                            }
                        }
                        else if (totalvh == null && int.Parse(txtTongTrongSoVH.Text) == null)
                        {
                            ev.QFrmThongBaoError("Lỗi không có dữ liệu");
                        }
                        break;
                    case 4:
                        int rowdgrpt = dgrNhapMucTieuPhatTrien.Rows.Count;
                        int totalpt = 0;
                        for (int i = 0; i < rowdgrpt; ++i)
                            totalpt += int.Parse(dgrNhapMucTieuPhatTrien.Rows[i].Cells["cTrongSoKPINPT"].Value.ToString());
                        if (totalpt == 0 && totalpt == 0 || totalpt == null && totalpt == null)
                        {
                            ev.QFrmThongBao("Lưu ý: Chưa nhập tỷ trọng");
                        }
                        else if (totalpt > 100)
                        {
                            ev.QFrmThongBaoError("Trọng số đã vượt quá 100%");
                        }
                        else if (totalpt > 0 && totalpt < 100 && int.Parse(txtTongTrongSoPT.Text) > 0 && int.Parse(txtTongTrongSoPT.Text) < 100)
                        {
                            ev.QFrmThongBaoError("Trọng số chưa được 100%");
                        }
                        else if (totalpt == 100 && int.Parse(txtTongTrongSoPT.Text) == 100)
                        {
                            CopyPTtoHT();
                            ChuyenTrangThai(4);
                        }
                        else if (totalpt == null && int.Parse(txtTongTrongSoPT.Text) == null)
                        {
                            ev.QFrmThongBaoError("Lỗi không có dữ liệu");
                        }
                        break;
                }
            }
            else
            {
                ev.QFrmThongBaoError("Chưa có dữ liệu! Vui lòng kiểm tra lại");
            }
        }
        #endregion
        #region Method
        private void TinhTongTrongSoPhuongDien()
        {
            try
            {
                int tc = int.Parse(txtTCHT.Text);
                int kh = int.Parse(txtKHHT.Text);
                int vh = int.Parse(txtVHHT.Text);
                int pt = int.Parse(txtPTHT.Text);
                int sum = tc + kh + vh + pt;
                txtTongTrongSoMucTieu.Text = sum.ToString();
            }
            catch (Exception)
            {
                ev.QFrmThongBaoError("Lỗi nhập sai định dạng hoặc thiếu dữ liệu");
            }

        }
        #endregion
        #region Event
        //chặn click vào ta b
        private void tabMucTieuKhoaPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabMucTieuKhoaPhong.SelectedIndex = CurrentTab;
        }
        private void dgrNhapMucTieuTaiChinh_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            ev.Qdgr_RowPostPaint(sender, e, dgrNhapMucTieuTaiChinh);
        }
        private void btnTTKH_Click(object sender, EventArgs e)
        {
            dgrHTMucTieuTaiChinh.Rows.Clear();
            KiemTraTyTrong(1);
        }
        private void btnQLTC_Click(object sender, EventArgs e)
        {
            ChuyenTrangThai(0);
        }
        private void btnTTVH_Click(object sender, EventArgs e)
        {
            dgrHTMucTieuKhachHang.Rows.Clear();
            KiemTraTyTrong(2);
        }

        private void btnQLKH_Click(object sender, EventArgs e)
        {
            ChuyenTrangThai(1);
        }
        private void btnTTPT_Click(object sender, EventArgs e)
        {
            dgrHTMucTieuVanHanh.Rows.Clear();
            KiemTraTyTrong(3);
        }
        private void btnQLVH_Click(object sender, EventArgs e)
        {
            ChuyenTrangThai(2);
        }
        private void btnTTHT_Click(object sender, EventArgs e)
        {
            dgrHTMucTieuPhatTrien.Rows.Clear();
            KiemTraTyTrong(4);
        }
        private void btnQLPT_Click(object sender, EventArgs e)
        {
            ChuyenTrangThai(3);
        }
        private void txtTCHT_Enter(object sender, EventArgs e)
        {
            txtTCHT.xActive = true;
            ev.Qtxt_Enter(sender, e);
        }

        private void txtTCHT_KeyPress(object sender, KeyPressEventArgs e)
        {
            ev.Qtxt_KeyPress_To_TextBox_Focus(sender, e, txtKHHT);
        }

        private void txtTCHT_Leave(object sender, EventArgs e)
        {
            txtTCHT.xActive = false;
            ev.Qtxt_Leave(sender, e);
        }
        private void txtKHHT_Enter(object sender, EventArgs e)
        {
            txtKHHT.xActive = true;
            ev.Qtxt_Enter(sender, e);
        }
        private void txtKHHT_KeyPress(object sender, KeyPressEventArgs e)
        {
            ev.Qtxt_KeyPress_To_TextBox_Focus(sender, e, txtVHHT);
        }
        private void txtKHHT_Leave(object sender, EventArgs e)
        {
            TinhTongTrongSoPhuongDien();
            txtKHHT.xActive = false;
            ev.Qtxt_Leave(sender, e);
        }
        private void txtVHHT_Enter(object sender, EventArgs e)
        {
            txtVHHT.xActive = true;
            ev.Qtxt_Enter(sender, e);
        }

        private void txtVHHT_KeyPress(object sender, KeyPressEventArgs e)
        {
            ev.Qtxt_KeyPress_To_TextBox_Focus(sender, e, txtPTHT);
        }

        private void txtVHHT_Leave(object sender, EventArgs e)
        {
            TinhTongTrongSoPhuongDien();
            txtVHHT.xActive = false;
            ev.Qtxt_Leave(sender, e);
        }

        private void txtPTVH_Enter(object sender, EventArgs e)
        {
            txtPTHT.xActive = true;
            ev.Qtxt_Enter(sender, e);
        }

        private void txtPTVH_KeyPress(object sender, KeyPressEventArgs e)
        {
            ev.Qtxt_KeyPress_To_Button_Focus(sender, e, btnHoanThanh);
        }

        private void txtPTVH_Leave(object sender, EventArgs e)
        {
            TinhTongTrongSoPhuongDien();
            txtPTHT.xActive = false;
            ev.Qtxt_Leave(sender, e);
        }
        private void txtTCHT_Validating(object sender, CancelEventArgs e)
        {
            string userInput = txtTCHT.Text.ToString();
            int parsedValue;
            if (!int.TryParse(userInput, out parsedValue))
            {
                ev.QFrmThongBaoError("Chỉ được nhập số không nhận chữ cái");
                txtTCHT.Text = "0";
            }
            else
            {
                if (parsedValue < 0 || parsedValue > 100)
                {
                    ev.QFrmThongBaoError("Số nhập vào phải nằm trong khoảng từ 0 đến 100");
                    dgrHTMucTieuPhatTrien.CancelEdit();
                    txtTCHT.Text = "0";
                }
            }

            TinhTongTrongSoPhuongDien();
            int sum = int.Parse(txtTongTrongSoMucTieu.Text);
            if (sum > 100)
            {
                ev.QFrmThongBaoError("Tổng trọng số mục tiêu vượt quá 100%.Vui lòng nhập lại!");
                txtTCHT.Text = "0";
                TinhTongTrongSoPhuongDien();
                txtTCHT.Focus();
            }
        }

        private void txtKHHT_Validating(object sender, CancelEventArgs e)
        {
            string userInput = txtKHHT.Text.ToString();
            int parsedValue;

            if (!int.TryParse(userInput, out parsedValue))
            {
                ev.QFrmThongBaoError("Chỉ được nhập số không nhận chữ cái");
                txtKHHT.Text = "0";
            }
            else
            {
                if (parsedValue < 0 || parsedValue > 100)
                {
                    ev.QFrmThongBaoError("Số nhập vào phải nằm trong khoảng từ 0 đến 100");
                    dgrHTMucTieuPhatTrien.CancelEdit();
                    txtKHHT.Text = "0";
                }
            }

            TinhTongTrongSoPhuongDien();
            int sum = int.Parse(txtTongTrongSoMucTieu.Text);
            if (sum > 100)
            {
                ev.QFrmThongBaoError("Tổng trọng số mục tiêu vượt quá 100%.Vui lòng nhập lại!");
                txtKHHT.Text = "0";
                TinhTongTrongSoPhuongDien();
                txtKHHT.Focus();
            }
        }
        private void txtVHHT_Validating(object sender, CancelEventArgs e)
        {
            string userInput = txtVHHT.Text.ToString();
            int parsedValue;

            if (!int.TryParse(userInput, out parsedValue))
            {
                ev.QFrmThongBaoError("Chỉ được nhập số không nhận chữ cái");
                txtVHHT.Text = "0";
            }
            else
            {
                if (parsedValue < 0 || parsedValue > 100)
                {
                    ev.QFrmThongBaoError("Số nhập vào phải nằm trong khoảng từ 0 đến 100");
                    dgrHTMucTieuPhatTrien.CancelEdit();
                    txtVHHT.Text = "0";
                }
            }

            TinhTongTrongSoPhuongDien();
            int sum = int.Parse(txtTongTrongSoMucTieu.Text);
            if (sum > 100)
            {
                ev.QFrmThongBaoError("Tổng trọng số mục tiêu vượt quá 100%.Vui lòng nhập lại!");
                txtVHHT.Text = "0";
                TinhTongTrongSoPhuongDien();
                txtVHHT.Focus();
            }
        }

        private void txtPTHT_Validating(object sender, CancelEventArgs e)
        {
            string userInput = txtPTHT.Text.ToString();
            int parsedValue;

            if (!int.TryParse(userInput, out parsedValue))
            {
                ev.QFrmThongBaoError("Chỉ được nhập số không nhận chữ cái");
                txtPTHT.Text = "0";
            }
            else
            {
                if (parsedValue < 0 || parsedValue > 100)
                {
                    ev.QFrmThongBaoError("Số nhập vào phải nằm trong khoảng từ 0 đến 100");
                    dgrHTMucTieuPhatTrien.CancelEdit();
                    txtPTHT.Text = "0";
                }
            }

            TinhTongTrongSoPhuongDien();
            int sum = int.Parse(txtTongTrongSoMucTieu.Text);
            if (sum > 100)
            {
                ev.QFrmThongBaoError("Tổng trọng số mục tiêu vượt quá 100%. Vui lòng nhập lại!");
                txtPTHT.Text = "0";
                TinhTongTrongSoPhuongDien();
                txtPTHT.Focus();
            }
        }
        private void FrmA73_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ev.QFrmThongBao_YesNo("Bạn có thật sự muốn đóng Form này không?"))
            {
                FrmA73 a73 = new FrmA73();
                a73.Close();
            }
            else
            {
                e.Cancel = true;
            }
        }
        private void btnHoanThanh_Click(object sender, EventArgs e)
        {
            TinhTongTrongSoPhuongDien();
            int sum = int.Parse(txtTongTrongSoMucTieu.Text);
            if (sum < 100 && sum > 100)
            {
                ev.QFrmThongBaoError("Trọng số chưa đạt đủ hoặc vượt quá 100%");
            }
            else if (sum == 100)
            {
                if (ev.QFrmThongBao_YesNo("Bạn có chắc muốn tiếp tục không? Hãy kiểm tra thật kĩ thông tin trước khi Hoàn thành nhé!"))
                {
                    // Lấy đường dẫn của thư mục bin-debug
                    string binDebugPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Documents");

                    // Tên tệp tin
                    string fileName = "A73.xlsx";

                    // Tạo đường dẫn đầy đủ
                    ev.QFrmThongBao("Nếu cần chỉnh sửa. Vui lòng chỉnh sửa trên Form, KHÔNG ĐƯỢC chỉnh sửa trên Excel. Mọi sự chỉnh sửa trên Excel phải tự chịu trách nhiệm!");
                    string existingFilePath = Path.Combine(binDebugPath, fileName);
                    AddDataGridViewsToExistingExcelSheet(dataGridViews, existingFilePath, txtTCHT.Text, txtKHHT.Text, txtVHHT.Text, txtPTHT.Text, TenNV, dtNgayLap.Value.ToString("dd/MM/yyyy"));
                }
                else
                {

                }
            }
            else
            {
            
            }
        }
        private void AddDataGridViewsToExistingExcelSheet(DataGridView[] dataGridViews, string existingFilePath, string tc, string kh, string vh, string pt, string tennv, string ngaylap)
        {
            string documentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string kpiFolderPath = Path.Combine(documentPath, "KPI");
            if (!Directory.Exists(kpiFolderPath))
            {                
                Directory.CreateDirectory(kpiFolderPath);
            }

            // Tạo đường dẫn cho file mới trong thư mục KPI
            //string newFolderPath = Path.Combine(kpiFolderPath, "KPI");

            // Tạo đường dẫn cho file copy mới trong thư mục Document ổ C
            
            string newFilePath = Path.Combine(kpiFolderPath, "A73_Biểu mẫu Mục tiêu Khoa Phòng.xlsx");

            // Kiểm tra xem file copy đã tồn tại hay chưa
            if (File.Exists(newFilePath))
            {
                // Nếu tồn tại, xóa file cũ
                File.Delete(newFilePath);
            }

            // Copy file gốc vào file mới
            File.Copy(existingFilePath, newFilePath);

            // Mở workbook Excel mới
            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = true;
            Excel.Workbook workbook = excelApp.Workbooks.Open(newFilePath);

            // Tìm và sử dụng một worksheet đã có trong workbook
            Excel.Worksheet worksheet = null;
            foreach (Excel.Worksheet sheet in workbook.Sheets)
            {
                if (sheet.Name == "A7.3.Muc tieu khoa.phong")
                {
                    worksheet = sheet;
                    break;
                }
            }

            if (worksheet == null)
            {
                ev.QFrmThongBaoError("Không tìm thấy worksheet có tên A7.3.Muc tieu khoa.phong trong file Excel.");
                workbook.Close();
                excelApp.Quit();
                return;
            }
            worksheet.Cells[6, 6] = tc;  // TextBox1 vào F6
            worksheet.Cells[12, 6] = kh; // TextBox2 vào F12
            worksheet.Cells[18, 6] = vh; // TextBox3 vào F18
            worksheet.Cells[24, 6] = pt; // TextBox4 vào F18
            worksheet.Cells[38, 2] = tennv; // TextBox4 vào F18
            worksheet.Cells[39, 2] = "Ngày(Date) " + ngaylap;
            // Vị trí bắt đầu cho từng group
            int[] startRows = { 7, 13, 19, 25 };
            int startCol = 5;  // Bắt đầu từ cột E

            // Sao chép dữ liệu từ mỗi DataGridView sang worksheet
            for (int groupIndex = 0; groupIndex < dataGridViews.Length; groupIndex++)
            {
                DataGridView dataGridView = dataGridViews[groupIndex];

                int startRow = startRows[groupIndex];

                // Sao chép dữ liệu từ cột 2 và cột 4 của DataGridView sang worksheet
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    // Kiểm tra xem dữ liệu đã tồn tại trong sheet chưa
                    bool dataExists = false;
                    for (int row = 1; row <= worksheet.UsedRange.Rows.Count; row++)
                    {
                        if (worksheet.Cells[row, startCol].Value == dataGridView[2, i].Value &&
                            worksheet.Cells[row, startCol + 1].Value == dataGridView[4, i].Value)
                        {
                            dataExists = true;
                            break;
                        }
                    }
                    // Nếu dữ liệu chưa tồn tại, thêm vào sheet
                    if (!dataExists)
                    {
                        worksheet.Cells[startRow, startCol] = dataGridView[2, i].Value;  // Cột 2
                        worksheet.Cells[startRow, startCol + 1] = dataGridView[4, i].Value;  // Cột 4
                        startRow++;
                    }
                }

                // Tạo khoảng trống giữa các nhóm (nếu không phải nhóm cuối cùng)
                if (groupIndex != dataGridViews.Length - 1)
                {
                    startRow += 2;  // Dùng 2 dòng trống
                }
                else
                {
                    startRow++;  // Dùng 1 dòng trống cho nhóm cuối cùng
                }
            }

            // Lưu workbook
            try
            {
                if (dgrHTMucTieuTaiChinh.Rows.Count > 0 && dgrHTMucTieuKhachHang.Rows.Count > 0 && dgrHTMucTieuVanHanh.Rows.Count > 0 && dgrHTMucTieuPhatTrien.Rows.Count > 0)
                {
                    //workbook.SaveAs("A73.xlsx");
                }
            }
            catch (Exception)
            {
                ev.QFrmThongBaoError("Không có dữ liệu nào để xuất ra");
            }
        }
        private void dgrHTMucTieuTaiChinh_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == dgrHTMucTieuTaiChinh.Columns["cTrongSoKPIHTTC"]?.Index)
            {
                string userInput = e.FormattedValue.ToString();
                int parsedValue;

                if (!int.TryParse(userInput, out parsedValue))
                {
                    ev.QFrmThongBaoError("Chỉ được nhập số không nhận chữ cái");

                    if (dgrHTMucTieuTaiChinh.CurrentRow != null)
                    {
                        var targetCell = dgrHTMucTieuTaiChinh.CurrentRow.Cells["cTrongSoKPIHTTC"];
                        if (targetCell != null)
                        {
                            targetCell.Value = 0;
                        }
                    }

                    dgrHTMucTieuTaiChinh.CancelEdit();
                }
                else
                {
                    if (parsedValue < 0 || parsedValue > 100)
                    {
                        ev.QFrmThongBaoError("Số nhập vào phải nằm trong khoảng từ 0 đến 100");

                        if (dgrHTMucTieuTaiChinh.CurrentRow != null)
                        {
                            var targetCell = dgrHTMucTieuTaiChinh.CurrentRow.Cells["cTrongSoKPIHTTC"];
                            if (targetCell != null)
                            {
                                targetCell.Value = 0;
                            }
                        }

                        dgrHTMucTieuTaiChinh.CancelEdit();
                    }
                }
            }
        }

        private void dgrHTMucTieuKhachHang_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == dgrHTMucTieuKhachHang.Columns["cTrongSoKPIHTTC"]?.Index)
            {
                string userInput = e.FormattedValue.ToString();
                int parsedValue;

                if (!int.TryParse(userInput, out parsedValue))
                {
                    ev.QFrmThongBaoError("Chỉ được nhập số không nhận chữ cái");

                    if (dgrHTMucTieuKhachHang.CurrentRow != null)
                    {
                        var targetCell = dgrHTMucTieuKhachHang.CurrentRow.Cells["cTrongSoKPIHTTC"];
                        if (targetCell != null)
                        {
                            targetCell.Value = 0;
                        }
                    }

                    dgrHTMucTieuKhachHang.CancelEdit();
                }
                else
                {
                    if (parsedValue < 0 || parsedValue > 100)
                    {
                        ev.QFrmThongBaoError("Số nhập vào phải nằm trong khoảng từ 0 đến 100");

                        if (dgrHTMucTieuKhachHang.CurrentRow != null)
                        {
                            var targetCell = dgrHTMucTieuKhachHang.CurrentRow.Cells["cTrongSoKPIHTTC"];
                            if (targetCell != null)
                            {
                                targetCell.Value = 0;
                            }
                        }

                        dgrHTMucTieuKhachHang.CancelEdit();
                    }
                }
            }
        }

        private void dgrHTMucTieuVanHanh_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == dgrHTMucTieuVanHanh.Columns["cTrongSoKPIVH"]?.Index)
            {
                string userInput = e.FormattedValue.ToString();
                int parsedValue;

                if (!int.TryParse(userInput, out parsedValue))
                {
                    ev.QFrmThongBaoError("Chỉ được nhập số không nhận chữ cái");

                    if (dgrHTMucTieuVanHanh.CurrentRow != null)
                    {
                        var targetCell = dgrHTMucTieuVanHanh.CurrentRow.Cells["cTrongSoKPIVH"];
                        if (targetCell != null)
                        {
                            targetCell.Value = 0;
                        }
                    }

                    dgrHTMucTieuVanHanh.CancelEdit();
                }
                else
                {
                    if (parsedValue < 0 || parsedValue > 100)
                    {
                        ev.QFrmThongBaoError("Số nhập vào phải nằm trong khoảng từ 0 đến 100");

                        if (dgrHTMucTieuVanHanh.CurrentRow != null)
                        {
                            var targetCell = dgrHTMucTieuVanHanh.CurrentRow.Cells["cTrongSoKPIVH"];
                            if (targetCell != null)
                            {
                                targetCell.Value = 0;
                            }
                        }

                        dgrHTMucTieuVanHanh.CancelEdit();
                    }
                }
            }
        }

        private void dgrHTMucTieuPhatTrien_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == dgrHTMucTieuPhatTrien.Columns["cTrongSoKPIPT"]?.Index)
            {
                string userInput = e.FormattedValue.ToString();
                int parsedValue;

                if (!int.TryParse(userInput, out parsedValue))
                {
                    ev.QFrmThongBaoError("Chỉ được nhập số không nhận chữ cái");

                    if (dgrHTMucTieuPhatTrien.CurrentRow != null)
                    {
                        var targetCell = dgrHTMucTieuPhatTrien.CurrentRow.Cells["cTrongSoKPIPT"];
                        if (targetCell != null)
                        {
                            targetCell.Value = 0;
                        }
                    }

                    dgrHTMucTieuPhatTrien.CancelEdit();
                }
                else
                {
                    if (parsedValue < 0 || parsedValue > 100)
                    {
                        ev.QFrmThongBaoError("Số nhập vào phải nằm trong khoảng từ 0 đến 100");

                        if (dgrHTMucTieuPhatTrien.CurrentRow != null)
                        {
                            var targetCell = dgrHTMucTieuPhatTrien.CurrentRow.Cells["cTrongSoKPIPT"];
                            if (targetCell != null)
                            {
                                targetCell.Value = 0;
                            }
                        }

                        dgrHTMucTieuPhatTrien.CancelEdit();
                    }
                }
            }
        }

        #endregion

        #region Copy GridView
        #region Method
        private void CreateTableCopyTC()
        {
            tc.Columns.Add("cMaKPIcpTC", typeof(string));
            tc.Columns.Add("cNoiDungcpTC", typeof(string));
            tc.Columns.Add("cNamcpTC", typeof(int));
            tc.Columns.Add("TrongSocpTC", typeof(int));
            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = tc.Columns["cMaKPIcpTC"];
            tc.PrimaryKey = PrimaryKeyColumns;
        }
        private void CreateTableCopyKH()
        {
            DataColumn existingColumn = kh.Columns["cMaKPIcpKH"];
            if (existingColumn == null)
            {
                // Column doesn't exist, so add it
                kh.Columns.Add("cMaKPIcpKH", typeof(string));
                kh.Columns.Add("cNoiDungcpKH", typeof(string));
                kh.Columns.Add("cNamcpKH", typeof(int));
                kh.Columns.Add("TrongSocpKH", typeof(int));

                DataColumn[] primaryKeyColumns = new DataColumn[1];
                primaryKeyColumns[0] = kh.Columns["cMaKPIcpKH"];
                kh.PrimaryKey = primaryKeyColumns;
            }
            else
            {

            }
        }

        private void CreateTableCopyVH()
        {
            if (vh.Columns["cMaKPIcpVH"] == null)
            {
                vh.Columns.Add("cMaKPIcpVH", typeof(string));
                vh.Columns.Add("cNoiDungcpVH", typeof(string));
                vh.Columns.Add("cNamcpVH", typeof(int));
                vh.Columns.Add("TrongSocpVH", typeof(int));
                DataColumn[] PrimaryKeyColumns = new DataColumn[1];
                PrimaryKeyColumns[0] = vh.Columns["cMaKPIcpVH"];
                vh.PrimaryKey = PrimaryKeyColumns;
            }
            else
            {

            }
        }
        private void CreateTableCopyPT()
        {
            if (pt.Columns["cMaKPIcpPT"] == null)
            {
                pt.Columns.Add("cMaKPIcpPT", typeof(string));
                pt.Columns.Add("cNoiDungcpPT", typeof(string));
                pt.Columns.Add("cNamcpPT", typeof(int));
                pt.Columns.Add("TrongSocpPT", typeof(int));
                DataColumn[] PrimaryKeyColumns = new DataColumn[1];
                PrimaryKeyColumns[0] = pt.Columns["cMaKPIcpPT"];
                pt.PrimaryKey = PrimaryKeyColumns;
            }
            else
            {

            }
        }
        private void LoadDataTableTC()
        {
            tc.Rows.Clear();
            for (int i = 0; i < dgrBVMucTieuTaiChinh.Rows.Count; i++)
            {
                if (dgrBVMucTieuTaiChinh.Rows[i].Cells["cChonTatCaBVTC"].Value != null && (bool)dgrBVMucTieuTaiChinh.Rows[i].Cells["cChonTatCaBVTC"].Value == true)
                {
                    DataRow newRow = tc.NewRow();
                    newRow["cMaKPIcpTC"] = dgrBVMucTieuTaiChinh.Rows[i].Cells["cMaKPIBVTC"].Value;
                    newRow["cNoiDungcpTC"] = dgrBVMucTieuTaiChinh.Rows[i].Cells["cNoiDungBVTC"].Value.ToString();
                    newRow["cNamcpTC"] = dgrBVMucTieuTaiChinh.Rows[i].Cells["cNamBVTC"].Value.ToString();
                    if (dgrBVMucTieuTaiChinh.Rows[i].Cells["cTrongSocpTC"].Value == null)
                    {
                        dgrBVMucTieuTaiChinh.Rows[i].Cells["cTrongSocpTC"].Value = "0";
                        newRow["TrongSocpTC"] = dgrBVMucTieuTaiChinh.Rows[i].Cells["cTrongSocpTC"].Value.ToString();
                    }
                    else
                        newRow["TrongSocpTC"] = dgrBVMucTieuTaiChinh.Rows[i].Cells["cTrongSocpTC"].Value.ToString();
                    tc.Rows.Add(newRow);
                }
            }
            dgrNhapMucTieuTaiChinh.DataSource = tc;
        }
        private void LoadDataTableKH()
        {
            kh.Rows.Clear();
            for (int i = 0; i < dgrBVMucTieuKhachHang.Rows.Count; i++)
            {
                if (dgrBVMucTieuKhachHang.Rows[i].Cells["cChonTatCaBVKH"].Value != null && (bool)dgrBVMucTieuKhachHang.Rows[i].Cells["cChonTatCaBVKH"].Value == true)
                {
                    DataRow newRow = kh.NewRow();
                    newRow["cMaKPIcpKH"] = dgrBVMucTieuKhachHang.Rows[i].Cells["cMaKPIBVKH"].Value;
                    newRow["cNoiDungcpKH"] = dgrBVMucTieuKhachHang.Rows[i].Cells["cNoiDungBVKH"].Value.ToString();
                    newRow["cNamcpKH"] = dgrBVMucTieuKhachHang.Rows[i].Cells["cNamBVKH"].Value.ToString();
                    if (dgrBVMucTieuKhachHang.Rows[i].Cells["cTrongSocpKH"].Value == null)
                    {
                        dgrBVMucTieuKhachHang.Rows[i].Cells["cTrongSocpKH"].Value = "0";
                        newRow["TrongSocpKH"] = dgrBVMucTieuKhachHang.Rows[i].Cells["cTrongSocpKH"].Value.ToString();
                    }
                    else
                        newRow["TrongSocpKH"] = dgrBVMucTieuKhachHang.Rows[i].Cells["cTrongSocpKH"].Value.ToString();
                    kh.Rows.Add(newRow);
                }
            }
            dgrNhapMucTieuKhachHang.DataSource = kh;
        }
        private void LoadDataTableVH()
        {
            vh.Rows.Clear();
            for (int i = 0; i < dgrBVMucTieuVanHanh.Rows.Count; i++)
            {
                if (dgrBVMucTieuVanHanh.Rows[i].Cells["cChonTatCaBVVH"].Value != null && (bool)dgrBVMucTieuVanHanh.Rows[i].Cells["cChonTatCaBVVH"].Value == true)
                {
                    DataRow newRow = vh.NewRow();
                    newRow["cMaKPIcpVH"] = dgrBVMucTieuVanHanh.Rows[i].Cells["cMaKPIBVVH"].Value;
                    newRow["cNoiDungcpVH"] = dgrBVMucTieuVanHanh.Rows[i].Cells["cNoiDungBVVH"].Value.ToString();
                    newRow["cNamcpVH"] = dgrBVMucTieuVanHanh.Rows[i].Cells["cNamBVVH"].Value.ToString();
                    if (dgrBVMucTieuVanHanh.Rows[i].Cells["cTrongSocpVH"].Value == null)
                    {
                        dgrBVMucTieuVanHanh.Rows[i].Cells["cTrongSocpVH"].Value = "0";
                        newRow["TrongSocpVH"] = dgrBVMucTieuVanHanh.Rows[i].Cells["cTrongSocpVH"].Value.ToString();
                    }
                    else
                        newRow["TrongSocpVH"] = dgrBVMucTieuVanHanh.Rows[i].Cells["cTrongSocpVH"].Value.ToString();
                    vh.Rows.Add(newRow);
                }
            }
            dgrNhapMucTieuVanHanh.DataSource = vh;
        }
        private void LoadDataTablePT()
        {
            pt.Rows.Clear();
            for (int i = 0; i < dgrBVMucTieuPhatTrien.Rows.Count; i++)
            {
                if (dgrBVMucTieuPhatTrien.Rows[i].Cells["cChonTatCaBVPT"].Value != null && (bool)dgrBVMucTieuPhatTrien.Rows[i].Cells["cChonTatCaBVPT"].Value == true)
                {
                    DataRow newRow = pt.NewRow();
                    newRow["cMaKPIcpPT"] = dgrBVMucTieuPhatTrien.Rows[i].Cells["cMaKPIBVPT"].Value;
                    newRow["cNoiDungcpPT"] = dgrBVMucTieuPhatTrien.Rows[i].Cells["cNoiDungBVPT"].Value.ToString();
                    newRow["cNamcpPT"] = dgrBVMucTieuPhatTrien.Rows[i].Cells["cNamBVPT"].Value.ToString();
                    if (dgrBVMucTieuPhatTrien.Rows[i].Cells["cTrongSocpPT"].Value == null)
                    {
                        dgrBVMucTieuPhatTrien.Rows[i].Cells["cTrongSocpPT"].Value = "0";
                        newRow["TrongSocpPT"] = dgrBVMucTieuPhatTrien.Rows[i].Cells["cTrongSocpPT"].Value.ToString();
                    }
                    else
                        newRow["TrongSocpPT"] = dgrBVMucTieuPhatTrien.Rows[i].Cells["cTrongSocpPT"].Value.ToString();
                    pt.Rows.Add(newRow);
                }
            }
            dgrNhapMucTieuPhatTrien.DataSource = pt;
        }

        private void ReturnDataTableTC()
        {
            for (int i = 0; i < dgrNhapMucTieuTaiChinh.Rows.Count; i++)
            {
                string value = dgrNhapMucTieuTaiChinh.Rows[i].Cells["cTrongSoKPINTC"].Value.ToString().Trim();
                foreach (DataRow row in tc.Rows)
                {
                    String id = Convert.ToString(row["cMaKPIcpTC"]);
                    if (id == Convert.ToString(dgrNhapMucTieuTaiChinh.Rows[i].Cells["cMaKPINTC"].Value))
                    {
                        row["TrongSocpTC"] = value;
                    }
                }
            }
            dgrNhapMucTieuTaiChinh.DataSource = tc;
            for (int j = 0; j < dgrBVMucTieuTaiChinh.Rows.Count; j++)
            {
                foreach (DataRow row in tc.Rows)
                {
                    String id = Convert.ToString(row["cMaKPIcpTC"]);
                    if (id == Convert.ToString(dgrBVMucTieuTaiChinh.Rows[j].Cells["cMaKPIBVTC"].Value))
                    {
                        dgrBVMucTieuTaiChinh.Rows[j].Cells["cTrongSocpTC"].Value = row["TrongSocpTC"].ToString();
                    }
                }
            }
        }
        private void ReturnDataTableKH()
        {
            for (int i = 0; i < dgrNhapMucTieuKhachHang.Rows.Count; i++)
            {
                string value = dgrNhapMucTieuKhachHang.Rows[i].Cells["cTrongSoKPINKH"].Value.ToString().Trim();
                foreach (DataRow row in kh.Rows)
                {
                    String id = Convert.ToString(row["cMaKPIcpKH"]);
                    if (id == Convert.ToString(dgrNhapMucTieuKhachHang.Rows[i].Cells["cMaKPINKH"].Value))
                    {
                        row["TrongSocpKH"] = value;
                    }
                }
            }
            dgrNhapMucTieuKhachHang.DataSource = kh;
            for (int j = 0; j < dgrBVMucTieuKhachHang.Rows.Count; j++)
            {
                foreach (DataRow row in kh.Rows)
                {
                    String id = Convert.ToString(row["cMaKPIcpKH"]);
                    if (id == Convert.ToString(dgrBVMucTieuKhachHang.Rows[j].Cells["cMaKPIBVKH"].Value))
                    {
                        dgrBVMucTieuKhachHang.Rows[j].Cells["cTrongSocpKH"].Value = row["TrongSocpKH"].ToString();
                    }
                }
            }
        }
        private void ReturnDataTableVH()
        {
            for (int i = 0; i < dgrNhapMucTieuVanHanh.Rows.Count; i++)
            {
                string value = dgrNhapMucTieuVanHanh.Rows[i].Cells["cTrongSoKPINVH"].Value.ToString().Trim();
                foreach (DataRow row in vh.Rows)
                {
                    String id = Convert.ToString(row["cMaKPIcpVH"]);
                    if (id == Convert.ToString(dgrNhapMucTieuVanHanh.Rows[i].Cells["cMaKPINVH"].Value))
                    {
                        row["TrongSocpVH"] = value;
                    }
                }
            }
            dgrNhapMucTieuVanHanh.DataSource = vh;
            for (int j = 0; j < dgrBVMucTieuVanHanh.Rows.Count; j++)
            {
                foreach (DataRow row in vh.Rows)
                {
                    String id = Convert.ToString(row["cMaKPIcpVH"]);
                    if (id == Convert.ToString(dgrBVMucTieuVanHanh.Rows[j].Cells["cMaKPIBVVH"].Value))
                    {
                        dgrBVMucTieuVanHanh.Rows[j].Cells["cTrongSocpVH"].Value = row["TrongSocpVH"].ToString();
                    }
                }
            }
        }
        private void ReturnDataTablePT()
        {
            for (int i = 0; i < dgrNhapMucTieuPhatTrien.Rows.Count; i++)
            {
                string value = dgrNhapMucTieuPhatTrien.Rows[i].Cells["cTrongSoKPINPT"].Value.ToString().Trim();
                foreach (DataRow row in pt.Rows)
                {
                    String id = Convert.ToString(row["cMaKPIcpPT"]);
                    if (id == Convert.ToString(dgrNhapMucTieuPhatTrien.Rows[i].Cells["cMaKPINPT"].Value))
                    {
                        row["TrongSocpPT"] = value;
                    }
                }
            }
            dgrNhapMucTieuPhatTrien.DataSource = pt;
            for (int j = 0; j < dgrBVMucTieuPhatTrien.Rows.Count; j++)
            {
                foreach (DataRow row in pt.Rows)
                {
                    String id = Convert.ToString(row["cMaKPIcpPT"]);
                    if (id == Convert.ToString(dgrBVMucTieuPhatTrien.Rows[j].Cells["cMaKPIBVPT"].Value))
                    {
                        dgrBVMucTieuPhatTrien.Rows[j].Cells["cTrongSocpPT"].Value = row["TrongSocpPT"].ToString();
                    }
                }
            }
        }
        private void TinhTrongSoKPITC()
        {
            int sc = dgrNhapMucTieuTaiChinh.Rows.Count;
            int sum = 0;
            for (int i = 0; i < sc; ++i)
                sum += int.Parse(dgrNhapMucTieuTaiChinh.Rows[i].Cells["cTrongSoKPINTC"].Value.ToString());
            if (sum > 100)
            {
                ev.QFrmThongBaoError("Trọng số đã vượt quá 100%. Vui lòng nhập lại trọng số");

                dgrNhapMucTieuTaiChinh.CurrentRow.Cells["cTrongSoKPINTC"].Value = 0;
            }
            else if (sum > 0 && sum <= 100)
            {
                txtTongTrongSoTC.Text = sum.ToString();
            }
            else if (sum == null)
                ev.QFrmThongBaoError("Trọng số chưa hợp lý!");
            else
            {

            }
        }
        private void TinhTrongSoKPIKH()
        {
            int sc = dgrNhapMucTieuKhachHang.Rows.Count;
            int sum = 0;
            for (int i = 0; i < sc; ++i)
                sum += int.Parse(dgrNhapMucTieuKhachHang.Rows[i].Cells["cTrongSoKPINKH"].Value.ToString());
            if (sum > 100)
            {
                ev.QFrmThongBaoError("Trọng số đã vượt quá 100%. Vui lòng nhập lại trọng số");

                dgrNhapMucTieuKhachHang.CurrentRow.Cells["cTrongSoKPINKH"].Value = 0;
            }
            else if (sum > 0 && sum <= 100)
            {
                txtTongTrongSoKH.Text = sum.ToString();
            }
            else if (sum == null)
                ev.QFrmThongBaoError("Trọng số chưa hợp lý!");
            else
            {

            }
        }
        private void TinhTrongSoKPIVH()
        {
            int sc = dgrNhapMucTieuVanHanh.Rows.Count;
            int sum = 0;
            for (int i = 0; i < sc; ++i)
                sum += int.Parse(dgrNhapMucTieuVanHanh.Rows[i].Cells["cTrongSoKPINVH"].Value.ToString());
            if (sum > 100)
            {
                ev.QFrmThongBaoError("Trọng số đã vượt quá 100%. Vui lòng nhập lại trọng số");

                dgrNhapMucTieuVanHanh.CurrentRow.Cells["cTrongSoKPINVH"].Value = 0;
            }
            else if (sum > 0 && sum <= 100)
            {
                txtTongTrongSoVH.Text = sum.ToString();
            }
            else if (sum == null)
                ev.QFrmThongBaoError("Trọng số chưa hợp lý!");
            else
            {

            }
        }
        private void TinhTrongSoKPIPT()
        {
            int sc = dgrNhapMucTieuPhatTrien.Rows.Count;
            int sum = 0;
            for (int i = 0; i < sc; ++i)
                sum += int.Parse(dgrNhapMucTieuPhatTrien.Rows[i].Cells["cTrongSoKPINPT"].Value.ToString());
            if (sum > 100)
            {
                ev.QFrmThongBaoError("Trọng số đã vượt quá 100%. Vui lòng nhập lại trọng số");

                dgrNhapMucTieuPhatTrien.CurrentRow.Cells["cTrongSoKPINPT"].Value = 0;
            }
            else if (sum > 0 && sum <= 100)
            {
                txtTongTrongSoPT.Text = sum.ToString();
            }
            else if (sum == null)
                ev.QFrmThongBaoError("Trọng số chưa hợp lý!");
            else
            {

            }
        }
        private void CopyTCtoHT()
        {
            if (dgrNhapMucTieuTaiChinh.Rows.Count > 0)
            {
                dgrHTMucTieuTaiChinh.ColumnCount = dgrNhapMucTieuTaiChinh.ColumnCount;
                foreach (DataGridViewColumn col in dgrNhapMucTieuTaiChinh.Columns)
                {
                    dgrHTMucTieuTaiChinh.Columns[col.Index].Name = col.Name;
                }
                foreach (DataGridViewRow row in dgrNhapMucTieuTaiChinh.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        DataGridViewRow newRow = (DataGridViewRow)row.Clone();

                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            newRow.Cells[i].Value = row.Cells[i].Value;
                        }
                        dgrHTMucTieuTaiChinh.Rows.Add(newRow);
                    }
                }
            }
            else
            {
                ev.QFrmThongBao("Chưa có dữ liệu. Vui lòng nhập dữ liệu");
            }
        }
        private void CopyKHtoHT()
        {
            if (dgrNhapMucTieuKhachHang.Rows.Count > 0)
            {
                dgrHTMucTieuKhachHang.ColumnCount = dgrNhapMucTieuKhachHang.ColumnCount;
                foreach (DataGridViewColumn col in dgrNhapMucTieuKhachHang.Columns)
                {
                    dgrHTMucTieuKhachHang.Columns[col.Index].Name = col.Name;
                }

                foreach (DataGridViewRow row in dgrNhapMucTieuKhachHang.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        DataGridViewRow newRow = (DataGridViewRow)row.Clone();

                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            newRow.Cells[i].Value = row.Cells[i].Value;
                        }
                        dgrHTMucTieuKhachHang.Rows.Add(newRow);
                    }
                }
            }
            else
            {
                ev.QFrmThongBao("Chưa có dữ liệu. Vui lòng nhập dữ liệu");
            }
        }
        private void CopyVHtoHT()
        {
            if (dgrNhapMucTieuVanHanh.Rows.Count > 0)
            {
                dgrHTMucTieuVanHanh.ColumnCount = dgrNhapMucTieuVanHanh.ColumnCount;
                foreach (DataGridViewColumn col in dgrNhapMucTieuVanHanh.Columns)
                {
                    dgrHTMucTieuVanHanh.Columns[col.Index].Name = col.Name;
                }

                foreach (DataGridViewRow row in dgrNhapMucTieuVanHanh.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        DataGridViewRow newRow = (DataGridViewRow)row.Clone();

                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            newRow.Cells[i].Value = row.Cells[i].Value;
                        }
                        dgrHTMucTieuVanHanh.Rows.Add(newRow);
                    }
                }
            }
            else
            {
                ev.QFrmThongBao("Chưa có dữ liệu. Vui lòng nhập dữ liệu");
            }
        }
        private void CopyPTtoHT()
        {
            if (dgrNhapMucTieuPhatTrien.Rows.Count > 0)
            {
                dgrHTMucTieuPhatTrien.ColumnCount = dgrNhapMucTieuPhatTrien.ColumnCount;
                foreach (DataGridViewColumn col in dgrNhapMucTieuPhatTrien.Columns)
                {
                    dgrHTMucTieuPhatTrien.Columns[col.Index].Name = col.Name;
                }

                foreach (DataGridViewRow row in dgrNhapMucTieuPhatTrien.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        DataGridViewRow newRow = (DataGridViewRow)row.Clone();

                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            newRow.Cells[i].Value = row.Cells[i].Value;
                        }
                        dgrHTMucTieuPhatTrien.Rows.Add(newRow);
                    }
                }
            }
            else
            {
                ev.QFrmThongBao("Chưa có dữ liệu. Vui lòng nhập dữ liệu");
            }
        }
        #endregion

        #region Event
        //Timer_Tick
        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            LoadDataTableTC();
            LoadDataTableKH();
            LoadDataTableVH();
            LoadDataTablePT();
        }
        //CellClick 
        private void dgrBVMucTieuTaiChinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgrBVMucTieuTaiChinh.Rows.Count && e.ColumnIndex >= 0 && e.ColumnIndex < dgrBVMucTieuTaiChinh.Columns.Count)
            {
                if (dgrBVMucTieuTaiChinh.Rows[e.RowIndex].Cells["cChonTatCaBVTC"].Value != null && (bool)dgrBVMucTieuTaiChinh.Rows[e.RowIndex].Cells["cChonTatCaBVTC"].Value == true)
                {
                    LoadDataTableTC();
                    dgrBVMucTieuTaiChinh.Rows[e.RowIndex].Cells["cChonTatCaBVTC"].Value = false;
                    return;
                }
                LoadDataTableTC();
                dgrBVMucTieuTaiChinh.Rows[e.RowIndex].Cells["cChonTatCaBVTC"].Value = true;
            }
        }
        private void dgrBVMucTieuKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgrBVMucTieuKhachHang.Rows.Count && e.ColumnIndex >= 0 && e.ColumnIndex < dgrBVMucTieuKhachHang.Columns.Count)
            {
                if (dgrBVMucTieuKhachHang.Rows[e.RowIndex].Cells["cChonTatCaBVKH"].Value != null && (bool)dgrBVMucTieuKhachHang.Rows[e.RowIndex].Cells["cChonTatCaBVKH"].Value == true)
                {
                    LoadDataTableKH();
                    dgrBVMucTieuKhachHang.Rows[e.RowIndex].Cells["cChonTatCaBVKH"].Value = false;
                    return;
                }
                LoadDataTableKH();
                dgrBVMucTieuKhachHang.Rows[e.RowIndex].Cells["cChonTatCaBVKH"].Value = true;
            }
        }

        private void dgrBVMucTieuVanHanh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgrBVMucTieuVanHanh.Rows.Count && e.ColumnIndex >= 0 && e.ColumnIndex < dgrBVMucTieuVanHanh.Columns.Count)
            {
                if (dgrBVMucTieuVanHanh.Rows[e.RowIndex].Cells["cChonTatCaBVVH"].Value != null && (bool)dgrBVMucTieuVanHanh.Rows[e.RowIndex].Cells["cChonTatCaBVVH"].Value == true)
                {
                    LoadDataTableVH();
                    dgrBVMucTieuVanHanh.Rows[e.RowIndex].Cells["cChonTatCaBVVH"].Value = false;
                    return;
                }
                LoadDataTableVH();
                dgrBVMucTieuVanHanh.Rows[e.RowIndex].Cells["cChonTatCaBVVH"].Value = true;
            }
        }
        private void dgrBVMucTieuPhatTrien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgrBVMucTieuPhatTrien.Rows.Count && e.ColumnIndex >= 0 && e.ColumnIndex < dgrBVMucTieuPhatTrien.Columns.Count)
            {
                if (dgrBVMucTieuPhatTrien.Rows[e.RowIndex].Cells["cChonTatCaBVPT"].Value != null && (bool)dgrBVMucTieuPhatTrien.Rows[e.RowIndex].Cells["cChonTatCaBVPT"].Value == true)
                {
                    LoadDataTablePT();
                    dgrBVMucTieuPhatTrien.Rows[e.RowIndex].Cells["cChonTatCaBVPT"].Value = false;
                    return;
                }
                LoadDataTablePT();
                dgrBVMucTieuPhatTrien.Rows[e.RowIndex].Cells["cChonTatCaBVPT"].Value = true;
            }
        }
        //
        private void dgrNhapMucTieuTaiChinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgrNhapMucTieuTaiChinh.Rows.Count && e.ColumnIndex == 0)
            {
                foreach (DataGridViewRow row in dgrBVMucTieuTaiChinh.Rows)
                {
                    if (dgrNhapMucTieuTaiChinh.Rows[e.RowIndex].Cells["cMaKPINTC"].Value.ToString() == row.Cells["cMaKPIBVTC"].Value.ToString())
                    {
                        row.Cells["cChonTatCaBVTC"].Value = false;
                        break;
                    }
                }
                LoadDataTableTC();
            }
        }
        private void dgrNhapMucTieuKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgrNhapMucTieuKhachHang.Rows.Count && e.ColumnIndex == 0)
            {
                foreach (DataGridViewRow row in dgrBVMucTieuKhachHang.Rows)
                {
                    if (dgrNhapMucTieuKhachHang.Rows[e.RowIndex].Cells["cMaKPINKH"].Value.ToString() == row.Cells["cMaKPIBVKH"].Value.ToString())
                    {
                        row.Cells["cChonTatCaBVKH"].Value = false;
                        break;
                    }
                }
                LoadDataTableKH();
            }
        }
        private void dgrNhapMucTieuVanHanh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgrNhapMucTieuVanHanh.Rows.Count && e.ColumnIndex == 0)
            {
                foreach (DataGridViewRow row in dgrBVMucTieuVanHanh.Rows)
                {
                    if (dgrNhapMucTieuVanHanh.Rows[e.RowIndex].Cells["cMaKPINVH"].Value.ToString() == row.Cells["cMaKPIBVVH"].Value.ToString())
                    {
                        row.Cells["cChonTatCaBVVH"].Value = false;
                        break;
                    }
                }
                LoadDataTableVH();
            }
        }
        private void dgrNhapMucTieuPhatTrien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgrNhapMucTieuPhatTrien.Rows.Count && e.ColumnIndex == 0)
            {
                foreach (DataGridViewRow row in dgrBVMucTieuPhatTrien.Rows)
                {
                    if (dgrNhapMucTieuPhatTrien.Rows[e.RowIndex].Cells["cMaKPINPT"].Value.ToString() == row.Cells["cMaKPIBVPT"].Value.ToString())
                    {
                        row.Cells["cChonTatCaBVPT"].Value = false;
                        break;
                    }
                }
                LoadDataTablePT();
            }
        }
        //CellValueChanged
        private void dgrNhapMucTieuTaiChinh_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            ReturnDataTableTC();
        }
        private void dgrNhapMucTieuKhachHang_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            ReturnDataTableKH();
        }

        private void dgrNhapMucTieuVanHanh_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            ReturnDataTableVH();
        }

        private void dgrNhapMucTieuPhatTrien_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            ReturnDataTablePT();
        }
        //CellValidating
        private void dgrNhapMucTieuTaiChinh_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == dgrNhapMucTieuTaiChinh.Columns["cTrongSoKPINTC"].Index)
            {
                string userInput = e.FormattedValue.ToString();
                int parsedValue;

                if (!int.TryParse(userInput, out parsedValue))
                {
                    ev.QFrmThongBaoError("Chỉ được nhập số không nhận chữ cái");
                    dgrNhapMucTieuTaiChinh.CancelEdit();
                }
                else
                {
                    if (parsedValue < 0 || parsedValue > 100)
                    {
                        ev.QFrmThongBaoError("Số nhập vào phải nằm trong khoảng từ 0 đến 100");
                        dgrNhapMucTieuTaiChinh.CancelEdit();
                    }
                }
            }
        }
        private void dgrNhapMucTieuKhachHang_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == dgrNhapMucTieuKhachHang.Columns["cTrongSoKPINKH"].Index)
            {
                string userInput = e.FormattedValue.ToString();
                int parsedValue;

                if (!int.TryParse(userInput, out parsedValue))
                {
                    ev.QFrmThongBaoError("Chỉ được nhập số không nhận chữ cái");
                    dgrNhapMucTieuKhachHang.CancelEdit();
                }
                else
                {
                    if (parsedValue < 0 || parsedValue > 100)
                    {
                        ev.QFrmThongBaoError("Số nhập vào phải nằm trong khoảng từ 0 đến 100");
                        dgrNhapMucTieuKhachHang.CancelEdit();
                    }
                }
            }
        }
        private void dgrNhapMucTieuVanHanh_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == dgrNhapMucTieuVanHanh.Columns["cTrongSoKPINVH"].Index)
            {
                string userInput = e.FormattedValue.ToString();
                int parsedValue;

                if (!int.TryParse(userInput, out parsedValue))
                {
                    ev.QFrmThongBaoError("Chỉ được nhập số không nhận chữ cái");
                    dgrNhapMucTieuVanHanh.CancelEdit();
                }
                else
                {
                    if (parsedValue < 0 || parsedValue > 100)
                    {
                        ev.QFrmThongBaoError("Số nhập vào phải nằm trong khoảng từ 0 đến 100");
                        dgrNhapMucTieuVanHanh.CancelEdit();
                    }
                }
            }
        }

        private void dgrNhapMucTieuPhatTrien_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == dgrNhapMucTieuPhatTrien.Columns["cTrongSoKPINPT"].Index)
            {
                string userInput = e.FormattedValue.ToString();
                int parsedValue;

                if (!int.TryParse(userInput, out parsedValue))
                {
                    ev.QFrmThongBaoError("Chỉ được nhập số không nhận chữ cái");
                    dgrNhapMucTieuPhatTrien.CancelEdit();
                }
                else
                {
                    if (parsedValue < 0 || parsedValue > 100)
                    {
                        ev.QFrmThongBaoError("Số nhập vào phải nằm trong khoảng từ 0 đến 100");
                        dgrNhapMucTieuPhatTrien.CancelEdit();
                    }
                }
            }
        }
            
        //CellEndEdit
        private void dgrNhapMucTieuTaiChinh_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgrNhapMucTieuTaiChinh.Rows[e.RowIndex].ErrorText = string.Empty;
        }
        private void dgrNhapMucTieuKhachHang_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgrNhapMucTieuKhachHang.Rows[e.RowIndex].ErrorText = string.Empty;
        }

        private void dgrNhapMucTieuVanHanh_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgrNhapMucTieuVanHanh.Rows[e.RowIndex].ErrorText = string.Empty;
        }

        private void dgrNhapMucTieuPhatTrien_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgrNhapMucTieuPhatTrien.Rows[e.RowIndex].ErrorText = string.Empty;
        }
        //MouseClick
        private void dgrBVMucTieuTaiChinh_MouseClick(object sender, MouseEventArgs e)
        {
            updateTimer.Start();
        }
        private void dgrBVMucTieuKhachHang_MouseClick(object sender, MouseEventArgs e)
        {
            updateTimer.Start();
        }
        private void dgrBVMucTieuVanHanh_MouseClick(object sender, MouseEventArgs e)
        {
            updateTimer.Start();
        }
        private void dgrBVMucTieuPhatTrien_MouseClick(object sender, MouseEventArgs e)
        {
            updateTimer.Start();
        }
        //MouseLeave
        private void dgrBVMucTieuTaiChinh_MouseLeave(object sender, EventArgs e)
        {
            updateTimer.Stop();
        }
        private void dgrBVMucTieuKhachHang_MouseLeave(object sender, EventArgs e)
        {
            updateTimer.Stop();
        }
        private void dgrBVMucTieuVanHanh_MouseLeave(object sender, EventArgs e)
        {
            updateTimer.Stop();
        }
        private void dgrBVMucTieuPhatTrien_MouseLeave(object sender, EventArgs e)
        {
            updateTimer.Stop();
        }
        //RowPostPaint
        private void dgrBVMucTieuTaiChinh_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            ev.Qdgr_RowPostPaint(sender, e, dgrBVMucTieuTaiChinh);
        }
        private void dgrBVMucTieuKhachHang_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            ev.Qdgr_RowPostPaint(sender, e, dgrBVMucTieuKhachHang);
        }
        private void dgrBVMucTieuVanHanh_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            ev.Qdgr_RowPostPaint(sender, e, dgrBVMucTieuVanHanh);
        }
        private void dgrBVMucTieuPhatTrien_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            ev.Qdgr_RowPostPaint(sender, e, dgrBVMucTieuPhatTrien);
        }
        private void dgrNhapMucTieuTaiChinh_RowPostPaint_1(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            ev.Qdgr_RowPostPaint(sender, e, dgrNhapMucTieuTaiChinh);
        }
        private void dgrNhapMucTieuKhachHang_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            ev.Qdgr_RowPostPaint(sender, e, dgrNhapMucTieuKhachHang);
        }
        private void dgrNhapMucTieuVanHanh_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            ev.Qdgr_RowPostPaint(sender, e, dgrNhapMucTieuVanHanh);
        }
        private void dgrNhapMucTieuPhatTrien_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            ev.Qdgr_RowPostPaint(sender, e, dgrNhapMucTieuPhatTrien);
        }
        private void dgrHTMucTieuTaiChinh_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            ev.Qdgr_RowPostPaint(sender, e, dgrHTMucTieuTaiChinh);
        }
        private void dgrHTMucTieuKhachHang_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            ev.Qdgr_RowPostPaint(sender, e, dgrHTMucTieuKhachHang);
        }
        private void dgrHTMucTieuVanHanh_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            ev.Qdgr_RowPostPaint(sender, e, dgrHTMucTieuVanHanh);
        }
        private void dgrHTMucTieuPhatTrien_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            ev.Qdgr_RowPostPaint(sender, e, dgrHTMucTieuPhatTrien);
        }
        //CellValidated
        private void dgrNhapMucTieuTaiChinh_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            TinhTrongSoKPITC();
            TinhTrongSoKPITC();
        }
        private void dgrNhapMucTieuKhachHang_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            TinhTrongSoKPIKH();
            TinhTrongSoKPIKH();
        }
        private void dgrNhapMucTieuVanHanh_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            TinhTrongSoKPIVH();
            TinhTrongSoKPIVH();
        }
        private void dgrNhapMucTieuPhatTrien_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            TinhTrongSoKPIPT();
            TinhTrongSoKPIPT();
        }
        //ColumnHeaderMouseClick
        private void dgrBVMucTieuTaiChinh_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.ColumnIndex == 0)
            {
                for (int i = 0; i < dgrBVMucTieuTaiChinh.Rows.Count; i++)
                {
                    dgrBVMucTieuTaiChinh.Rows[i].Cells["cChonTatCaBVTC"].Value = true;
                }
                LoadDataTableTC();
            }
        }
        private void dgrBVMucTieuKhachHang_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.ColumnIndex == 0)
            {
                for (int i = 0; i < dgrBVMucTieuKhachHang.Rows.Count; i++)
                {
                    dgrBVMucTieuKhachHang.Rows[i].Cells["cChonTatCaBVKH"].Value = true;
                }
                LoadDataTableKH();
            }
        }
        private void dgrBVMucTieuVanHanh_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.ColumnIndex == 0)
            {
                for (int i = 0; i < dgrBVMucTieuVanHanh.Rows.Count; i++)
                {
                    dgrBVMucTieuVanHanh.Rows[i].Cells["cChonTatCaBVVH"].Value = true;
                }
                LoadDataTableVH();
            }
        }

        private void dgrBVMucTieuPhatTrien_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.ColumnIndex == 0)
            {
                for (int i = 0; i < dgrBVMucTieuPhatTrien.Rows.Count; i++)
                {
                    dgrBVMucTieuPhatTrien.Rows[i].Cells["cChonTatCaBVPT"].Value = true;
                }
                LoadDataTablePT();
            }
        }

        private void dgrNhapMucTieuTaiChinh_ColumnHeaderMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.ColumnIndex == 0)
            {
                for (int i = 0; i < dgrBVMucTieuTaiChinh.Rows.Count; i++)
                {
                    dgrBVMucTieuTaiChinh.Rows[i].Cells["cChonTatCaBVTC"].Value = false;
                }
                LoadDataTableTC();
            }
        }
        private void dgrNhapMucTieuKhachHang_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.ColumnIndex == 0)
            {
                for (int i = 0; i < dgrNhapMucTieuKhachHang.Rows.Count; i++)
                {
                    dgrBVMucTieuKhachHang.Rows[i].Cells["cChonTatCaBVKH"].Value = false;
                }
                LoadDataTableKH();
            }
        }
        private void dgrNhapMucTieuVanHanh_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left && e.ColumnIndex == 0)
            //{
            //    for (int i = 0; i < dgrNhapMucTieuVanHanh.Rows.Count; i++)
            //    {
            //        dgrBVMucTieuVanHanh.Rows[i].Cells["cChonTatCaBVVH"].Value = false;
            //    }
            //    LoadDataTableVH();
            //}

            if (e.Button == MouseButtons.Left && e.ColumnIndex == 0)
            {
                for (int i = 0; i < dgrNhapMucTieuVanHanh.Rows.Count; i++)
                {
                    dgrBVMucTieuVanHanh.Rows[i].Cells["cChonTatCaBVVH"].Value = false;
                }

                // Clear rows from dgrNhapMucTieuVanHanh
                dgrNhapMucTieuVanHanh.Rows.Clear();

                for (int i = 0; i < dgrBVMucTieuVanHanh.Rows.Count; i++)
                {
                    if (dgrBVMucTieuVanHanh.Rows[i].Cells["cChonTatCaBVVH"].Value != null &&
                        (bool)dgrBVMucTieuVanHanh.Rows[i].Cells["cChonTatCaBVVH"].Value == true)
                    {
                        DataRow newRow = vh.NewRow();
                        newRow["cMaKPIcpVH"] = dgrBVMucTieuVanHanh.Rows[i].Cells["cMaKPIBVVH"].Value;
                        newRow["cNoiDungcpVH"] = dgrBVMucTieuVanHanh.Rows[i].Cells["cNoiDungBVVH"].Value.ToString();
                        newRow["cNamcpVH"] = dgrBVMucTieuVanHanh.Rows[i].Cells["cNamBVVH"].Value.ToString();

                        if (dgrBVMucTieuVanHanh.Rows[i].Cells["cTrongSocpVH"].Value == null)
                        {
                            dgrBVMucTieuVanHanh.Rows[i].Cells["cTrongSocpVH"].Value = "0";
                            newRow["TrongSocpVH"] = dgrBVMucTieuVanHanh.Rows[i].Cells["cTrongSocpVH"].Value.ToString();
                        }
                        else
                        {
                            newRow["TrongSocpVH"] = dgrBVMucTieuVanHanh.Rows[i].Cells["cTrongSocpVH"].Value.ToString();
                        }

                        vh.Rows.Add(newRow);
                    }
                }

                // Set the DataSource after processing the rows
                dgrNhapMucTieuVanHanh.DataSource = vh;
            }

        }
        private void dgrNhapMucTieuPhatTrien_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.ColumnIndex == 0)
            {
                for (int i = 0; i < dgrNhapMucTieuPhatTrien.Rows.Count; i++)
                {
                    dgrBVMucTieuPhatTrien.Rows[i].Cells["cChonTatCaBVPT"].Value = false;
                }
                LoadDataTablePT();
            }
        }
        //MouseHover
        private void dgrNhapMucTieuTaiChinh_MouseHover(object sender, EventArgs e)
        {
            updateTimer.Stop();
        }
        private void dgrNhapMucTieuKhachHang_MouseHover(object sender, EventArgs e)
        {
            updateTimer.Stop();
        }
        private void dgrNhapMucTieuVanHanh_MouseHover(object sender, EventArgs e)
        {
            updateTimer.Stop();
        }
        private void dgrNhapMucTieuPhatTrien_MouseHover(object sender, EventArgs e)
        {
            updateTimer.Stop();
        }
        #endregion

        #endregion
    }
}