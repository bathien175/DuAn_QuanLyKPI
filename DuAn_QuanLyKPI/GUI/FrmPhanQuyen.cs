using BusinessCommon;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuAn_QuanLyKPI.GUI
{
    public partial class FrmPhanQuyen : DevExpress.XtraEditors.XtraForm
    {
        public static string mconnectstring = "server=192.168.50.108,1433;database=QuanLyKPI;uid=sa;pwd=123";
        private clsCommonMethod comm = new clsCommonMethod();
        private clsEventArgs ev = new clsEventArgs("");
        private string msql;

        private Dictionary<CheckBox, string> checkboxValues1 = new Dictionary<CheckBox, string>();
        private ContextMenuStrip contextMenuStrip;
        public FrmPhanQuyen()
        {
            InitializeComponent();
            Loadcbo();
            LoadThongTinNguoiDung();
            contextMenuStrip = new ContextMenuStrip();
            addBinding();
            // Thêm một menu item vào ContextMenuStrip
            ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem("Phân quyền");
            toolStripMenuItem.Click += ToolStripMenuItem_Click;
            contextMenuStrip.Items.Add(toolStripMenuItem);

            // Gán ContextMenuStrip cho DataGridView
            dgrDanhSachNguoiDung.ContextMenuStrip = contextMenuStrip;

            // Gắn sự kiện CellMouseClick cho DataGridView
            dgrDanhSachNguoiDung.CellMouseClick += dgrDanhSachNguoiDung_CellMouseClick;
            // Thêm bộ xử lý sự kiện cho ô đánh dấu "Chọn tất cả"
            cbChonTatCa.CheckedChanged += cbChonTatCa_CheckedChanged;

            // Thêm bộ xử lý sự kiện cho ô đánh dấu "Bỏ chọn tất cả"
            cbBoChonTatCa.CheckedChanged += cbBoChonTatCa_CheckedChanged;
        }
        void addBinding()
        {
            //cbCaiDatHethong.DataBindings.Clear();
            
            //cbCaiDatHethong.DataBindings.Add(new Binding("Checked", dgrDanhSachNguoiDung.DataSource, "QuyenTruyCap", true, DataSourceUpdateMode.OnPropertyChanged));

            //cbCaNhan.DataBindings.Clear();

            //cbCaNhan.DataBindings.Add(new Binding("Checked", dgrDanhSachNguoiDung.DataSource, "QuyenTruyCap", true, DataSourceUpdateMode.OnPropertyChanged));

            //cbDanhMucKPI.DataBindings.Clear();

            //cbDanhMucKPI.DataBindings.Add(new Binding("Checked", dgrDanhSachNguoiDung.DataSource, "QuyenTruyCap", true, DataSourceUpdateMode.OnPropertyChanged));

            //cbNganHangKPI.DataBindings.Clear();

            //cbNganHangKPI.DataBindings.Add(new Binding("Checked", dgrDanhSachNguoiDung.DataSource, "QuyenTruyCap", true, DataSourceUpdateMode.OnPropertyChanged));

            //cbBieuMauKPI.DataBindings.Clear();

            //cbBieuMauKPI.DataBindings.Add(new Binding("Checked", dgrDanhSachNguoiDung.DataSource, "QuyenTruyCap", true, DataSourceUpdateMode.OnPropertyChanged));

            //cbKiemDuyetBieuMau.DataBindings.Clear();

            //cbKiemDuyetBieuMau.DataBindings.Add(new Binding("Checked", dgrDanhSachNguoiDung.DataSource, "QuyenTruyCap", true, DataSourceUpdateMode.OnPropertyChanged));

            //cbQuanLyNguoiDung.DataBindings.Clear();

            //cbQuanLyNguoiDung.DataBindings.Add(new Binding("Checked", dgrDanhSachNguoiDung.DataSource, "QuyenTruyCap", true, DataSourceUpdateMode.OnPropertyChanged));



        }

        private void checkbox_CheckedChanged1(object sender, EventArgs e)
        {
            var selectedCheckbox1 = (CheckBox)sender;

            if (checkboxValues1.ContainsKey(selectedCheckbox1))
            {
                string newValue = selectedCheckbox1.Checked ? selectedCheckbox1.Text : "";
                checkboxValues1[selectedCheckbox1] = newValue;
                Console.WriteLine($"{selectedCheckbox1.Text}: {newValue}");
            }
        }




        private void LoadThongTinNguoiDung()
        {

            msql = "SELECT * FROM [dbo].[NguoiDung] as a, [dbo].[Quyen] as b ,[dbo].[PhongKhoa] as c,[dbo].[ChucDanh] as d where a.[MaQuyen] =b.[MaQuyen] and a.[MaChucDanh]=d.[MaChucDanh] and a.[MaPhongKhoa] =c.[MaPK]";
            DataTable tb = comm.GetDataTable(mconnectstring, msql, "NguoiDung");
            dgrDanhSachNguoiDung.AutoGenerateColumns = false;
            dgrDanhSachNguoiDung.DataSource = tb;




        }
        private void Loadcbo()
        {

            msql = "SELECT * FROM [dbo].[NguoiDung] as a, [dbo].[Quyen] as b ,[dbo].[PhongKhoa] as c,[dbo].[ChucDanh] as d where a.[MaQuyen] =b.[MaQuyen] and a.[MaChucDanh]=d.[MaChucDanh] and a.[MaPhongKhoa] =c.[MaPK]";
            DataTable tb2 = comm.GetDataTable(mconnectstring, msql, "ChucDanh");

            //cbo Kho
            cboChucDanh.DataSource = tb2.Copy();
            cboChucDanh.DisplayMember = "TenQuyen";
            cboChucDanh.ValueMember = "TenQuyen";
            cboChucDanh.CustomAlignment = new string[] { "l", "l" };
            cboChucDanh.CustomColumnStyle = new string[] { "t", "t" };

        }



        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }








        private void btnLuu_Click(object sender, EventArgs e)
        {
            checkboxValues1.Clear(); // Xóa tất cả các mục trong từ điển

            // Thêm giá trị mới cho từng checkbox
            checkboxValues1.Add(cbBieuMauKPI, "BMKPI");
            checkboxValues1.Add(cbCaiDatHethong, "CDHT");
            checkboxValues1.Add(cbCaNhan, "CN");
            checkboxValues1.Add(cbDanhMucKPI, "DMKPI");
            checkboxValues1.Add(cbKiemDuyetBieuMau, "KDBM");
            checkboxValues1.Add(cbNganHangKPI, "NHKPI");
            checkboxValues1.Add(cbQuanLyNguoiDung, "QLND");

            DataGridViewRow selectedRow = dgrDanhSachNguoiDung.SelectedRows[0];
            string maNV = selectedRow.Cells["MaNV"].Value.ToString();
            string tenDangNhap = selectedRow.Cells["TenTaiKhoan"].Value.ToString();
            string maQuyen = selectedRow.Cells["MaQuyen"].Value.ToString();

            // Lặp qua tất cả các CheckBox và lấy giá trị của những CheckBox được chọn
            foreach (var pair in checkboxValues1)
            {
                Console.WriteLine($"{pair.Key.Text}: {pair.Value}");

                // Nếu CheckBox được chọn, kiểm tra mã chức năng trước khi thêm vào database
                if (pair.Key.Checked)
                {
                    string checkExistSql = $"SELECT COUNT(*) FROM [dbo].[NguoiTruyCap] WHERE [MaNV] = '{maNV}' AND [MaChucNang] = N'{pair.Value}'";

                    // Thực hiện truy vấn và kiểm tra giá trị trả về
                    DataTable resultTable = comm.GetDataTable(mconnectstring, checkExistSql, "ExistCheck");


                    if (resultTable.Rows.Count > 0 && Convert.ToInt32(resultTable.Rows[0][0]) > 0)
                    {
                        // Dữ liệu đã tồn tại, bạn có thể thực hiện các xử lý khác tùy ý

                        ev.QFrmThongBaoError($"{pair.Value} đã tồn tại.");
                    }
                    else
                    {
                        // Nếu không tồn tại, thêm dữ liệu vào database
                        string insertSql = $"INSERT INTO [dbo].[NguoiTruyCap] ([MaNV], [TenNguoiTruyCap], [MaChucNang], [QuyenTruyCap], [MaQuyen]) VALUES ('{maNV}', N'{tenDangNhap}', N'{pair.Value}', 1, '{maQuyen}')";

                        comm.RunSQL(mconnectstring, insertSql);
                    }
                }
            }

            ev.QFrmThongBao("Bạn đã phân quyền thành công");
        }

        private void dgrDanhSachNguoiDung_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hti = dgrDanhSachNguoiDung.HitTest(e.X, e.Y);
                if (hti.RowIndex >= 0)
                {
                    // Chọn dòng được nhấp chuột phải
                    dgrDanhSachNguoiDung.Rows[hti.RowIndex].Selected = true;

                    // Hiển thị button hoặc menu tại vị trí chuột phải
                    Button btnContextMenu = new Button();
                    btnContextMenu.Text = "Phân quyền";
                    btnContextMenu.Click += (s, ev) => HandleButtonClick();
                    btnContextMenu.Size = new System.Drawing.Size(150, 30);
                    btnContextMenu.Location = new System.Drawing.Point(e.X, e.Y);

                    // Thêm button vào DataGridView hoặc thay thế ContextMenuStrip bằng button
                    dgrDanhSachNguoiDung.Controls.Add(btnContextMenu);

                    // Xử lý sự kiện LostFocus
                    btnContextMenu.LostFocus += (s, ev) =>
                    {
                        // Kiểm tra xem chuột có nằm ngoài button không
                        if (!btnContextMenu.ClientRectangle.Contains(btnContextMenu.PointToClient(Control.MousePosition)))
                        {
                            dgrDanhSachNguoiDung.Controls.Remove(btnContextMenu);
                        }
                    };

                    btnContextMenu.Focus();
                }
            }
        }

        private void HandleButtonClick()
        {
            panel2.Visible = true;
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            checkboxValues1.Clear(); // Xóa tất cả các mục trong từ điển

            // Thêm giá trị mới cho từng checkbox
            checkboxValues1.Add(cbBieuMauKPI, "BMKPI");
            checkboxValues1.Add(cbCaiDatHethong, "CDHT");
            checkboxValues1.Add(cbCaNhan, "CN");
            checkboxValues1.Add(cbDanhMucKPI, "DMKPI");
            checkboxValues1.Add(cbKiemDuyetBieuMau, "KDBM");
            checkboxValues1.Add(cbNganHangKPI, "NHKPI");
            checkboxValues1.Add(cbQuanLyNguoiDung, "QLND");

            DataGridViewRow selectedRow = dgrDanhSachNguoiDung.SelectedRows[0];
            string maNV = selectedRow.Cells["cMaNV"].Value.ToString();
            string tenDangNhap = selectedRow.Cells["cTenDanhNhap"].Value.ToString();
            string maQuyen = selectedRow.Cells["cMaQuyen"].Value.ToString();

                // Lặp qua tất cả các CheckBox và lấy giá trị của những CheckBox được chọn
                foreach (var pair in checkboxValues1)
                {
                    Console.WriteLine($"{pair.Key.Text}: {pair.Value}");

                    // Nếu CheckBox được chọn, kiểm tra mã chức năng trước khi thêm vào database
                    if (pair.Key.Checked)
                    {
                        string checkExistSql = $"SELECT COUNT(*) FROM [dbo].[NguoiTruyCap] WHERE [MaNV] = '{maNV}' AND [MaChucNang] = N'{pair.Value}'";

                        // Thực hiện truy vấn và kiểm tra giá trị trả về
                        DataTable resultTable = comm.GetDataTable(mconnectstring, checkExistSql, "ExistCheck");


                        if (resultTable.Rows.Count > 0 && Convert.ToInt32(resultTable.Rows[0][0]) > 0)
                        {
                            // Dữ liệu đã tồn tại, bạn có thể thực hiện các xử lý khác tùy ý

                            ev.QFrmThongBaoError($"{pair.Value} đã được phân quyền.");
                        }
                        else
                        {
                            // Nếu không tồn tại, thêm dữ liệu vào database
                            string insertSql = $"INSERT INTO [dbo].[NguoiTruyCap] ([MaNV], [TenNguoiTruyCap], [MaChucNang], [QuyenTruyCap], [MaQuyen]) VALUES ('{maNV}', N'{tenDangNhap}', N'{pair.Value}', 1, '{maQuyen}')";

                            comm.RunSQL(mconnectstring, insertSql);
                        }
                    }
                }
            
           
            ev.QFrmThongBao("Bạn đã phân quyền thành công");
            panel2.Visible = false;
        }

        private void dgrDanhSachNguoiDung_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Kiểm tra xem người dùng có nhấn chuột phải không
            if (e.Button == MouseButtons.Right)
            {
                // Xác định vị trí của ô được nhấn chuột phải
                int rowIndex = e.RowIndex;
                int colIndex = e.ColumnIndex;

                // Kiểm tra nếu ô được nhấn chuột phải là ô hợp lệ (không phải header)
                if (rowIndex >= 0 && colIndex >= 0)
                {
                    // Chuyển đổi tọa độ của ô trên DataGridView thành tọa độ màn hình
                    var cellRectangle = dgrDanhSachNguoiDung.GetCellDisplayRectangle(colIndex, rowIndex, false);
                    var screenPoint = dgrDanhSachNguoiDung.PointToScreen(new System.Drawing.Point(cellRectangle.X, cellRectangle.Y));

                    // Hiển thị ContextMenuStrip tại vị trí của ô được nhấn chuột phải
                    contextMenuStrip.Show(screenPoint);
                }
            }
            else if (dgrDanhSachNguoiDung["cChiTiet", e.RowIndex] == dgrDanhSachNguoiDung.CurrentCell)
            {
                //Đang bị fail mã phiếu 
                if (ev.QFrmThongBao_YesNo("Bạn có chắc muốn xem Thông tin của " + dgrDanhSachNguoiDung.CurrentRow.Cells["cTenDanhNhap"].Value.ToString() + " này không ?"))
                {
                    //maphieunhapkho = dgrCapNhatPhieu.CurrentRow.Cells["cMaPhieuCNP"].Value.ToString();
                    string TenTK = dgrDanhSachNguoiDung.CurrentRow.Cells["cTenDanhNhap"].Value.ToString();



                    ChiTietPhanQuyen f = new ChiTietPhanQuyen(TenTK);

                    f.ShowDialog();
                }
            }
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            msql = "SELECT * FROM [dbo].[NguoiDung] as a, [dbo].[Quyen] as b ,[dbo].[PhongKhoa] as c,[dbo].[ChucDanh] as d where a.[MaQuyen] =b.[MaQuyen] and a.[MaChucDanh]=d.[MaChucDanh] and a.[MaPhongKhoa] =c.[MaPK] and b.TenQuyen=N'"+cboChucDanh.SelectedValue+"'";
            DataTable tb = comm.GetDataTable(mconnectstring, msql, "");
            dgrDanhSachNguoiDung.AutoGenerateColumns = false;
            dgrDanhSachNguoiDung.DataSource = tb;
        }

        private void cbChonTatCa_CheckedChanged(object sender, EventArgs e)
        {
            bool trangThaiChon = cbChonTatCa.Checked;
            foreach (var pair in checkboxValues1)
            {
                pair.Key.CheckedChanged -= checkbox_CheckedChanged1;
                pair.Key.Checked = trangThaiChon;
                pair.Key.CheckedChanged += checkbox_CheckedChanged1;
            }
        }

        private void cbBoChonTatCa_CheckedChanged(object sender, EventArgs e)
        {
            bool trangThaiBoChon = cbBoChonTatCa.Checked;
            foreach (var pair in checkboxValues1)
            {
                pair.Key.CheckedChanged -= checkbox_CheckedChanged1;
                pair.Key.Checked = !trangThaiBoChon;
                pair.Key.CheckedChanged += checkbox_CheckedChanged1;
            }
        }


    }
}