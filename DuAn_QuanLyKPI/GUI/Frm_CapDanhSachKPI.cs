using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessCommon;
using ControlProject1510;
using DevExpress.Charts.Native;
using DevExpress.CodeParser;
using DevExpress.Data.Linq.Helpers;
using DevExpress.Data.ODataLinq.Helpers;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting.Native;
//using DevExpress.XtraVerticalGrid;
using DuAn_QuanLyKPI.Constants;
using DuAn_QuanLyKPI.DTO;
using System.Globalization;

namespace DuAn_QuanLyKPI.GUI
{

    public partial class Frm_CapDanhSachKPI : DevExpress.XtraEditors.XtraForm
    {
        //lấy dữ liệu từu frm login
        public static string MaNV = Frm_Login.MaNV;
        public static string MaPhongKhoa = Frm_Login.MaPhongKhoa;
        public static string MaChucDanh = Frm_Login.MaChucDanh;
        public static string TenNV = Frm_Login.TenNV;
        public static string TenChucDanh = Frm_Login.TenChucDanh;
        public static string TenPhongKhoa = Frm_Login.TenPhongKhoa;
        private static string mconnectstring = Frm_A78.mconnectstring;
        //private string mconnectstring = "server=192.168.50.108,1433; database=QuanLyKPI;uid=sa;pwd=123";
        private clsCommonMethod comm = new clsCommonMethod();
        private clsEventArgs ev = new clsEventArgs("");
        private string msql;
        List<int> selectedItems = new List<int>();
        public Form ReturnForm { get; set; }
        public int NamPhieu { get; set; }


        public Frm_CapDanhSachKPI()
        {
            InitializeComponent();           
            LoadData();
            txt_Nam.Visible = false;
            lb_Nam.Visible = false;

        }
        public Frm_CapDanhSachKPI(int nam)
        {
            InitializeComponent();
            LoadData();
            NamPhieu = nam;
            if(NamPhieu != 0)
            {
                txt_Nam.Visible = true;
                lb_Nam.Visible = true;
                txt_Nam.Text = NamPhieu.ToString();
    
            }
        }
        private void LoadData()
        {
            msql = "SELECT dbo.KPI.*, dbo.NhomTieuChi.TenTieuChi FROM dbo.KPI INNER JOIN dbo.NhomTieuChi ON dbo.KPI.TieuChiID = dbo.NhomTieuChi.TieuChiID ORDER BY KPI.TieuChiID; ";
            DataTable tb = comm.GetDataTable(mconnectstring, msql, "KPI");
            dtgv_CapKPI.AutoGenerateColumns = false;
            dtgv_CapKPI.DataSource = tb;      
        }
        
        //private void SelectAllCheckboxes()
        //{
        //    foreach (DataGridViewRow row in dtgv_CapKPI.Rows)
        //    {
        //        // Đảm bảo rằng hàng không phải là hàng header
        //        if (!row.IsNewRow)
        //        {
        //            // Lấy ô kiểm từ cột có tên "cChon"
        //            DataGridViewCheckBoxCell checkboxCell = row.Cells["cChon"] as DataGridViewCheckBoxCell;

        //            // Kiểm tra xem ô kiểm có tồn tại và chưa được chọn
        //            if (checkboxCell != null )
        //            {
        //                // Chọn ô kiểm
        //                checkboxCell.Value = true;
        //            }
        //            else if(checkboxCell != null && Convert.ToBoolean(checkboxCell.Value) == true)
        //            {
        //                checkboxCell.Value = false;
        //            }
        //        }
        //    }
        //}
        private void ToggleAllCheckboxes(bool isChecked)
        {
            foreach (DataGridViewRow row in dtgv_CapKPI.Rows)
            {
                // Đảm bảo rằng hàng không phải là hàng header
                if (!row.IsNewRow)
                {
                    // Lấy ô kiểm từ cột có tên "cChon"
                    DataGridViewCheckBoxCell checkboxCell = row.Cells["cChon"] as DataGridViewCheckBoxCell;

                    // Kiểm tra xem ô kiểm có tồn tại
                    if (checkboxCell != null)
                    {
                        // Đặt giá trị của ô kiểm theo giá trị isChecked
                        checkboxCell.Value = isChecked;
                    }
                }
            }
        }

        // Chọn tất cả
        private void SelectAllCheckboxes()
        {
            ToggleAllCheckboxes(true);
        }

        // Bỏ chọn tất cả
        private void DeselectAllCheckboxes()
        {
            ToggleAllCheckboxes(false);
        }
       
        //private void LoadCbo()
        //{
        //    //string maChucDanh = cboChucDanh.SelectedValue.ToString();
        //    //string maPhongKhoa = cboKhoaPhong.SelectedValue.ToString();
        //    string msql = @"SELECT dbo.KPI.*, dbo.NhomTieuChi.* FROM dbo.KPI
        //    INNER JOIN dbo.KPITrongNganHang ON dbo.KPI.MaKPI = dbo.KPITrongNganHang.MaKPI
        //    INNER JOIN dbo.NganHangKPI ON dbo.KPITrongNganHang.MaNganHangKPI = dbo.NganHangKPI.MaNganHangKPI
        //    LEFT JOIN dbo.NhomTieuChi ON dbo.KPI.TieuChiID = dbo.NhomTieuChi.TieuChiID
        //    WHERE dbo.NganHangKPI.MaChucDanh = @maChucDanh
        //    AND dbo.NganHangKPI.MaPK = @maPK;";
        //    DataTable dt = new DataTable();
        //    using (SqlConnection connection = new SqlConnection(mconnectstring))
        //    {
        //        SqlCommand command = new SqlCommand(msql, connection);
        //        command.Parameters.AddWithValue("@maChucDanh", MaChucDanh);
        //        command.Parameters.AddWithValue("@maPK", MaPhongKhoa);
        //        SqlDataAdapter adapter = new SqlDataAdapter(command);
        //        adapter.Fill(dt);
        //    }
        //    dtgv_CapKPI.AutoGenerateColumns = false;
        //    dtgv_CapKPI.DataSource = dt;
        //}

        //Ấn nút cấp danh sách 

        //Ấn nút cấp danh sách
        private void btnCap_Click(object sender, EventArgs e)
        {

            //if (selectedItems.Count > 0)
            //{
            //    // Kiểm tra xem có đủ tiêu chí không
            //    if (AreAllCriteriaMet())
            //    {
            //        // Nếu đủ, thực hiện các công việc cấp
            //        bool result = ev.QFrmThongBao_YesNo("Bạn có chắc chắn ???");
            //        if(result == true )
            //        {
            //            int namphieu;
            //            if(int.TryParse(txt_Nam.Text, out namphieu))
            //            {
            //                Frm_ChiTieuVuaGiao newForm = new Frm_ChiTieuVuaGiao(selectedItems, namphieu);
            //                newForm.ShowDialog();
            //            }

            //        }
            //        //else if(result == true && txt_Nam.Visible == true)
            //        //{
            //        //    Frm_ChiTieuVuaGiao newForm = new Frm_ChiTieuVuaGiao(selectedItems);
            //        //    newForm.ShowDialog();
            //        //}
            //    }
            //    else
            //    {
            //        // Nếu không đủ, hiển thị thông báo
            //        ev.QFrmThongBao("Dữ liệu không đủ tiêu chí. Vui lòng kiểm tra lại.");
            //    }
            //}
            //else
            //{
            //    ev.QFrmThongBao("Vui lòng chọn ít nhất một mục để cấp.");
            //}
            if (selectedItems.Count > 0)
            {
                // Kiểm tra xem có đủ tiêu chí không
                if (AreAllCriteriaMet())
                {
                    bool result = ev.QFrmThongBao_YesNo("Bạn có chắc chắn ???");
                    if (result == true)
                    {
                        if (txt_Nam.Visible)
                        {
                            // Form 2
                            int namphieu;
                            if (int.TryParse(txt_Nam.Text, out namphieu))
                            {
                                Frm_ChiTieuVuaGiao newForm = new Frm_ChiTieuVuaGiao(selectedItems, namphieu);
                                newForm.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Vui lòng nhập một giá trị số nguyên cho năm.");
                            }
                        }
                        else
                        {
                            // Form 3
                            Frm_ChiTieuVuaGiao newForm = new Frm_ChiTieuVuaGiao(selectedItems);
                            newForm.ShowDialog();
                        }
                    }
                    
                }
                else
                {
                    // Nếu không đủ, hiển thị thông báo
                    ev.QFrmThongBao("Dữ liệu không đủ tiêu chí. Vui lòng kiểm tra lại.");
                }
            }
            else
            {
                ev.QFrmThongBao("Vui lòng chọn ít nhất một mục để cấp.");
            }
        }

        // Kiểm tra tiêu chí
        private bool AreAllCriteriaMet()
        {
            int columnIndex = dtgv_CapKPI.Columns["clTieuChiID"].Index;

            // Khởi tạo danh sách các tiêu chí đã xuất hiện
            List<string> requiredCriteria = new List<string> { "B", "C", "F", "L" };

            // Duyệt qua từng dòng để kiểm tra tiêu chí
            foreach (DataGridViewRow row in dtgv_CapKPI.Rows)
            {
                // Kiểm tra xem hàng có được chọn không (qua checkbox chẳng hạn)
                bool isSelected = Convert.ToBoolean(row.Cells["cChon"].Value);

                if (isSelected)
                {
                    string criteria = row.Cells[columnIndex].Value?.ToString();

                    // Kiểm tra xem giá trị có thuộc danh sách các mã tiêu chí không
                    if (!string.IsNullOrEmpty(criteria) && requiredCriteria.Contains(criteria))
                    {
                        requiredCriteria.Remove(criteria);
                    }
                }
            }

            // Kiểm tra xem danh sách tiêu chí cần xuất hiện có bị rỗng không
            return requiredCriteria.Count == 0;
        }


        //Lấy danh sách mã KPI các mục cần cấp
        private void dtgv_CapKPI_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dtgv_CapKPI.Columns[0].Index && e.RowIndex >= 0) // Thay 0 bằng index của cột chứa checkbox
            {
                DataGridViewCheckBoxCell checkBox = (DataGridViewCheckBoxCell)dtgv_CapKPI.Rows[e.RowIndex].Cells["cChon"];
                if (Convert.ToBoolean(checkBox.Value)) // Kiểm tra trạng thái của checkbox
                {
                    int maKPI = Convert.ToInt32(dtgv_CapKPI.Rows[e.RowIndex].Cells["clMaKPI"].Value);
                    if (!selectedItems.Contains(maKPI))
                    {
                        selectedItems.Add(maKPI);
                    }
                }
                else
                {
                    int maKPI = Convert.ToInt32(dtgv_CapKPI.Rows[e.RowIndex].Cells["clMaKPI"].Value);
                    if (selectedItems.Contains(maKPI))
                    {
                        selectedItems.Remove(maKPI);
                    }
                }

            }
        }

        //kiểm tra tình trạng checkbox ấn chọn hoặc bỏ chọn cho tất cả
        private void ck_ChonAll_CheckedChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem CheckBox có được chọn hay không
            if (ck_ChonAll.Checked)
            {
                // Nếu được chọn, thì chọn tất cả
                SelectAllCheckboxes();
            }
            else
            {
                // Nếu không được chọn, thì bỏ chọn tất cả
                DeselectAllCheckboxes();
            }
        }

        //Sử dụng sự kiện lấy mã ở những ô checkbox được chọn.
        private void dtgv_CapKPI_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu sự kiện được kích hoạt trên ô kiểm header "cChon"
            if (e.ColumnIndex == dtgv_CapKPI.Columns["cChon"].Index && e.RowIndex == -1)
            {
                // Lấy giá trị của ô kiểm header
                bool headerCheckboxValue = (bool)dtgv_CapKPI.Rows[e.RowIndex].Cells["cChon"].Value;

                // Bật/Tắt tất cả các ô kiểm trong cột "cChon" tùy thuộc vào giá trị của ô kiểm header
                foreach (DataGridViewRow row in dtgv_CapKPI.Rows)
                {
                    // Đảm bảo rằng hàng không phải là hàng header
                    if (!row.IsNewRow)
                    {
                        DataGridViewCheckBoxCell checkboxCell = row.Cells["cChon"] as DataGridViewCheckBoxCell;
                        if (checkboxCell != null)
                        {
                            checkboxCell.Value = headerCheckboxValue;
                        }
                    }
                }
            }
        }
        private void txt_TimKiem_TextChanged_1(object sender, EventArgs e)
        {
            string searchText = txt_TimKiem.Text.Trim().ToLower();

            // Tạo câu truy vấn SQL tìm kiếm
            string searchQuery = $"SELECT dbo.KPI.*, dbo.NhomTieuChi.TenTieuChi FROM dbo.KPI INNER JOIN dbo.NhomTieuChi ON dbo.KPI.TieuChiID = dbo.NhomTieuChi.TieuChiID WHERE LOWER(NoiDung) LIKE N'%{searchText}%' ORDER BY KPI.TieuChiID";

            // Lấy dữ liệu từ cơ sở dữ liệu cho kết quả tìm kiếm
            DataTable searchResult = comm.GetDataTable(mconnectstring, searchQuery, "KPI");

            // Tạo DataTable mới chứa kết quả tìm kiếm và các KPI đã chọn trước đó
            DataTable combinedDataTable = new DataTable();
            combinedDataTable.Columns.Add("MaKPI", typeof(int)); // Thêm các cột khác nếu cần thiết

            // Lưu trữ các KPI đã chọn trước đó vào bảng tạm thời
            DataTable selectedItemsTable = new DataTable();
            selectedItemsTable.Columns.Add("MaKPI", typeof(int));

            foreach (var i in selectedItems)
            {
                string queryID = $"SELECT dbo.KPI.*, dbo.NhomTieuChi.TenTieuChi FROM dbo.KPI INNER JOIN dbo.NhomTieuChi ON dbo.KPI.TieuChiID = dbo.NhomTieuChi.TieuChiID WHERE dbo.KPI.MaKPI = '{i}'";
                DataTable idt = comm.GetDataTable(mconnectstring, queryID, "KPI");
                selectedItemsTable.Merge(idt);
            }

            // Hiển thị lại các KPI đã chọn trước đó
            combinedDataTable.Merge(selectedItemsTable);

            // Loại bỏ các KPI đã chọn trước đó khỏi kết quả tìm kiếm
            foreach (DataRow row in selectedItemsTable.Rows)
            {
                DataRow[] rowsToRemove = searchResult.Select($"MaKPI = {row["MaKPI"]}");
                foreach (DataRow rowToRemove in rowsToRemove)
                {
                    searchResult.Rows.Remove(rowToRemove);
                }
            }

            // Thêm kết quả tìm kiếm vào DataTable
            combinedDataTable.Merge(searchResult);

            // Hiển thị dữ liệu trên DataGridView
            dtgv_CapKPI.AutoGenerateColumns = false;
            dtgv_CapKPI.DataSource = combinedDataTable;
            foreach (var i in selectedItems)
            {
                foreach (DataGridViewRow row in dtgv_CapKPI.Rows)
                {
                    if (row.Cells["clMaKPI"].Value != null && int.Parse(row.Cells["clMaKPI"].Value.ToString()) == i)
                    {
                        row.Cells["cChon"].Value = true;
                    }
                }
            }
        }


        private void dtgv_CapKPI_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            ev.Qdgr_RowPostPaint(sender, e, dtgv_CapKPI);
        }

        private void Frm_CapDanhSachKPI_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Kiểm tra xem form trở lại đã được đặt hay chưa
            if (ReturnForm != null)
            {
                // Nếu có, hiển thị lại form trở lại
                ReturnForm.Show();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Frm_ChinhSuaCap form = new Frm_ChinhSuaCap();
            form.ShowDialog();
        }
    }
}
