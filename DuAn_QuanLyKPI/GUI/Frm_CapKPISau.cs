using BusinessCommon;
using DevExpress.XtraEditors;
using DuAn_QuanLyKPI.Constants;
using System;
using System.Collections;
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
    public partial class Frm_CapKPISau : DevExpress.XtraEditors.XtraForm
    {
        private static string mconnectstring = Frm_A78.mconnectstring;
        public List<int> SelectedKPIs { get; private set; }
        public List<string> Items { get; set; }
        private clsCommonMethod comm = new clsCommonMethod();
        private clsEventArgs ev = new clsEventArgs("");
        private string msql;
        List<int> selectedItems = new List<int>();
        private List<int> maKPIList;
        private object isChecked;
        // Thuộc tính để nhận giá trị string từ TextBox1 trên Form1
        public string MaPhieuKPI { get; set; }

        // Thuộc tính để nhận giá trị int từ TextBox2 trên Form1
        public int NamPhieuKPI { get; set; }

        public Frm_CapKPISau(List<int> maKPIList, string maPhieuKPI, int namPhieuKPI)
        {
            InitializeComponent();
            this.maKPIList = maKPIList;
            MaPhieuKPI = maPhieuKPI;
            NamPhieuKPI = namPhieuKPI;
            if (NamPhieuKPI != 0)
            {
                // Directly assign the integer value to the TextBox
                txt_Nam.Text = NamPhieuKPI.ToString();
            }
            if (!string.IsNullOrEmpty(MaPhieuKPI))
            {
                // Gán giá trị năm phiếu vào TextBox
                txt_maPhieu.Text = MaPhieuKPI;
            }
            LoadData();

        }
        public Frm_CapKPISau()
        {
            InitializeComponent();

        }
        private void LoadData()
        {
            msql = "SELECT dbo.KPI.*, dbo.NhomTieuChi.TenTieuChi FROM dbo.KPI INNER JOIN dbo.NhomTieuChi ON dbo.KPI.TieuChiID = dbo.NhomTieuChi.TieuChiID ORDER BY KPI.TieuChiID; ";
            DataTable tb = comm.GetDataTable(mconnectstring, msql, "KPI");

            // Thêm cột cChon vào DataTable nếu chưa tồn tại
            if (!tb.Columns.Contains("cChon"))
            {
                tb.Columns.Add("cChon", typeof(bool));
            }

            // Hiển thị DataTable trong DataGridView
            dtgv_CapKPI.AutoGenerateColumns = false;
            dtgv_CapKPI.DataSource = tb;

        }
        //private void CheckMaKPI()
        //{
        //    foreach (DataGridViewRow row in dtgv_CapKPI.Rows)
        //    {
        //        if (row.Cells["clMaKPI"].Value != null)
        //        {
        //            int maKPIValue = Convert.ToInt32(row.Cells["clMaKPI"].Value);

        //            // Kiểm tra xem maKPIValue có trong maKPIList hay không
        //            if (maKPIList.Contains(maKPIValue))
        //            {
        //                row.Cells["cChon"].Value = true;
        //            }
        //            else
        //            {
        //                row.Cells["cChon"].Value = false;
        //            }
        //        }
        //    }

        //    // Cập nhật lại dữ liệu trong DataGridView
        //    dtgv_CapKPI.Refresh();
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
        private void btnCap_Click(object sender, EventArgs e)
        {
            if (selectedItems.Count > 0)
            {
                // Kiểm tra xem có đủ tiêu chí không
                if (AreAllCriteriaMet())
                {
                    // Nếu đủ, thực hiện các công việc cấp
                    bool result = ev.QFrmThongBao_YesNo("Bạn có chắc chắn ???");
                    if (result == true)
                    {
                        ////int namPhieuFromForm1 = NamPhieuFromForm1;
                        //Frm_ChinhSuaCap newForm = new Frm_ChinhSuaCap(selectedItems);                   
                        //newForm.ShowDialog();
                        string maPhieuKPI = txt_maPhieu.Text;
                        int namPhieuKPI;
                        //int namPhieuFromForm1 = NamPhieuFromForm1;
                        if (int.TryParse(txt_Nam.Text, out namPhieuKPI))
                        {
                            Frm_ChinhSuaCap newForm = new Frm_ChinhSuaCap(selectedItems, maPhieuKPI, namPhieuKPI);
                            newForm.MaPhieuKPI1 = maPhieuKPI;
                            newForm.NamPhieuKPI1 = namPhieuKPI;
                            newForm.ShowDialog();

                        }
                        else
                        {

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

        private void Frm_CapKPISau_Load(object sender, EventArgs e)
        {
            CheckAndSortMaKPI();
        }

        private void CheckAndSortMaKPI()
        {
            msql = "SELECT dbo.KPI.*, dbo.NhomTieuChi.TenTieuChi FROM dbo.KPI INNER JOIN dbo.NhomTieuChi ON dbo.KPI.TieuChiID = dbo.NhomTieuChi.TieuChiID ORDER BY KPI.TieuChiID; ";
            // Lấy dữ liệu từ cơ sở dữ liệu cho kết quả tìm kiếm
            DataTable searchResult = comm.GetDataTable(mconnectstring, msql, "KPI");

            // Tạo DataTable mới chứa kết quả tìm kiếm và các KPI đã chọn trước đó
            DataTable combinedDataTable = new DataTable();
            combinedDataTable.Columns.Add("MaKPI", typeof(int)); // Thêm các cột khác nếu cần thiết

            // Lưu trữ các KPI đã chọn trước đó vào bảng tạm thời
            DataTable selectedItemsTable = new DataTable();
            selectedItemsTable.Columns.Add("MaKPI", typeof(int));

            foreach (var i in maKPIList)
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
            foreach (var i in maKPIList)
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

        private void ck_ChonAll_CheckedChanged_1(object sender, EventArgs e)
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

        private void btn_Cap_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_Cap1_Click(object sender, EventArgs e)
        {
            if (selectedItems.Count > 0)
            {
                // Kiểm tra xem có đủ tiêu chí không
                if (AreAllCriteriaMet())
                {
                    // Nếu đủ, thực hiện các công việc cấp
                    bool result = ev.QFrmThongBao_YesNo("Bạn có chắc chắn ???");
                    if (result == true)
                    {
                        ////int namPhieuFromForm1 = NamPhieuFromForm1;
                        //Frm_ChinhSuaCap newForm = new Frm_ChinhSuaCap(selectedItems);                   
                        //newForm.ShowDialog();
                        string maPhieuKPI = txt_maPhieu.Text;
                        int namPhieuKPI;
                        //int namPhieuFromForm1 = NamPhieuFromForm1;
                        if (int.TryParse(txt_Nam.Text, out namPhieuKPI))
                        {
                            Frm_ChinhSuaCap newForm = new Frm_ChinhSuaCap(selectedItems, maPhieuKPI, namPhieuKPI);
                            newForm.MaPhieuKPI1 = maPhieuKPI;
                            newForm.NamPhieuKPI1 = namPhieuKPI;
                            newForm.ShowDialog();

                        }
                        else
                        {

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
    }
}