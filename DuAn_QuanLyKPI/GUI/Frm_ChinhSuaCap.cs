using BusinessCommon;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DuAn_QuanLyKPI.GUI.Frm_ChiTieuVuaGiao;

namespace DuAn_QuanLyKPI.GUI
{
    public partial class Frm_ChinhSuaCap : DevExpress.XtraEditors.XtraForm
    {
        private DataTable _dataTable;
        private List<int> receivedItems;
        private DataTable combinedDataTable;  // DataTable để kết hợp dữ liệu từ _dataTable và dataTable1
        //private string mconnectstring = "server=192.168.50.108,1433; database=QuanLyKPI;uid=sa;pwd=123";
        private static string mconnectstring = Frm_A78.mconnectstring;
        private clsCommonMethod comm = new clsCommonMethod();
        private clsEventArgs ev = new clsEventArgs("");
        private string msql;
        public int NamPhieu { get; set; }
        public string MaPhieu { get; set; }
        public string MaPhieuKPI1 { get; set; }

        // Thuộc tính để nhận giá trị int từ TextBox2 trên Form1
        public int NamPhieuKPI1 { get; set; }



        //public Frm_ChinhSuaCap(DataTable dataTable)
        //{
        //    InitializeComponent();
        //    _dataTable = dataTable;
        //    DisplayData();
        //}
        //public Frm_ChinhSuaCap(List<int> selectedItems)
        //{
        //    InitializeComponent();
        //    receivedItems = selectedItems;
        //    DataTable dataTable1 = new DataTable();
        //    using (SqlConnection connection = new SqlConnection(mconnectstring))
        //    {
        //        connection.Open();

        //        // Tạo một command để thực thi truy vấn
        //        using (SqlCommand command = new SqlCommand())
        //        {
        //            command.Connection = connection;
        //            string query = "SELECT dbo.KPI.MaKPI, dbo.KPI.NoiDung, dbo.KPI.DonViTinh, dbo.KPI.ChiTieu,dbo.KPI.TieuChiID, dbo.NhomTieuChi.TenTieuChi FROM dbo.KPI INNER JOIN dbo.NhomTieuChi ON dbo.KPI.TieuChiID = dbo.NhomTieuChi.TieuChiID AND MaKPI IN (" + string.Join(",", receivedItems) + ") ORDER BY dbo.NhomTieuChi.TenTieuChi";
        //            command.CommandText = query;
        //            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
        //            {
        //                adapter.Fill(dataTable1);
        //            }
        //        }
        //    }
        //    dtgv_ChinhSuaChiTieu.DataSource = dataTable1;

        //}



        //private void DisplayData()
        //{
        //    dtgv_ChinhSuaChiTieu.DataSource = _dataTable;
        //}

        //private void btn_Them_Click(object sender, EventArgs e)
        //{
        //    Frm_CapKPISau form = new Frm_CapKPISau();
        //    form.ShowDialog();            
        //}
        public Frm_ChinhSuaCap(DataTable dataTable, int namPhieu, string maPhieu)
        {
            InitializeComponent();
            _dataTable = dataTable;
            DisplayData();
            NamPhieu = namPhieu;
            MaPhieu = maPhieu;
            if (NamPhieu != 0)
            {
                // Directly assign the integer value to the TextBox
                txt_Nam.Text = NamPhieu.ToString();
            }
            if (!string.IsNullOrEmpty(MaPhieu))
            {
                // Gán giá trị năm phiếu vào TextBox
                txt_MaPhieu.Text = MaPhieu;
            }
        }
        public Frm_ChinhSuaCap(int namPhieu)
        {
            InitializeComponent();
            DisplayData();
            NamPhieu = namPhieu;

            if (NamPhieu != 0)
            {
                // Directly assign the integer value to the TextBox
                txt_Nam.Text = NamPhieu.ToString();
                txt_Nam1.Text = NamPhieu.ToString();
            }
            
        }
    
        public Frm_ChinhSuaCap()
        {
            InitializeComponent();

        }

        public Frm_ChinhSuaCap(List<int> selectedItems, string maPhieuKPI, int namPhieuKPI)
        {
            InitializeComponent();
            receivedItems = selectedItems;
            NamPhieuKPI1 = namPhieuKPI;
            MaPhieuKPI1 = maPhieuKPI;
            if (NamPhieuKPI1 != 0)
            {
                // Directly assign the integer value to the TextBox
                txt_Nam.Text = NamPhieuKPI1.ToString();
                
            }
            if (!string.IsNullOrEmpty(MaPhieuKPI1))
            {
                // Gán giá trị năm phiếu vào TextBox
                txt_MaPhieu.Text = MaPhieuKPI1;
            }
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(mconnectstring))
            {
                connection.Open();

                // Tạo một command để thực thi truy vấn
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string query = "SELECT dbo.KPI.MaKPI, dbo.KPI.NoiDung, dbo.KPI.DonViTinh, dbo.KPI.ChiTieu,dbo.KPI.TieuChiID, dbo.NhomTieuChi.TenTieuChi FROM dbo.KPI INNER JOIN dbo.NhomTieuChi ON dbo.KPI.TieuChiID = dbo.NhomTieuChi.TieuChiID AND MaKPI IN (" + string.Join(",", receivedItems) + ") ORDER BY dbo.NhomTieuChi.TenTieuChi";
                    command.CommandText = query;
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            dtgv_ChinhSuaChiTieu.DataSource = dataTable;

        }


        private void DisplayData()
        {
            // Hiển thị dữ liệu trên DataGridView
            dtgv_ChinhSuaChiTieu.DataSource = _dataTable;
        }

        //private DataTable CombineDataTables(DataTable table1, DataTable table2)
        //{
        //    DataTable combinedTable = table1.Copy();
        //    foreach (DataRow row in table2.Rows)
        //    {
        //        combinedTable.ImportRow(row);
        //    }
        //    return combinedTable;
        //}

        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (dtgv_ChinhSuaChiTieu.Rows.Count > 0)
            {
                string maPhieuKPI = txt_MaPhieu.Text;
                int namPhieuKPI;
                if (int.TryParse(txt_Nam.Text, out namPhieuKPI))
                {
                    List<int> maKPIList = LayMaKPITuDataGridView();
                    Frm_CapKPISau form = new Frm_CapKPISau(maKPIList, maPhieuKPI, namPhieuKPI);
                    form.MaPhieuKPI = maPhieuKPI;
                    form.NamPhieuKPI = namPhieuKPI;

                    form.ShowDialog();

                }

            }
            else
            {
                ev.QFrmThongBaoError("Chưa có dữ liệu để chỉnh sửa !");
            }


        }
        private List<int> LayMaKPITuDataGridView()
        {
            string tenCotMaKPI = "clMaKPI";
            List<int> maKPIList = new List<int>();

            foreach (DataGridViewRow row in dtgv_ChinhSuaChiTieu.Rows)
            {
                if (row.Cells[tenCotMaKPI].Value != null)
                {
                    int maKPIValue;
                    if (int.TryParse(row.Cells[tenCotMaKPI].Value.ToString(), out maKPIValue))
                    {
                        maKPIList.Add(maKPIValue);
                    }
                    // Xử lý nếu giá trị không phải là số nguyên
                }
            }

            return maKPIList;
        }

        private void dtgv_ChinhSuaChiTieu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.ColumnIndex == dtgv_ChinhSuaChiTieu.Columns["cXoa"].Index)
            {
                // Xác nhận xóa

                bool result = ev.QFrmThongBao_YesNo("Bạn chắc chắn muốn xóa?");

                if (result == true)
                {
                    // Lấy hàng chứa nút
                    DataGridViewRow row = dtgv_ChinhSuaChiTieu.Rows[e.RowIndex];

                    // Xóa dữ liệu tương ứng với hàng này từ nguồn dữ liệu của bạn

                    // Xóa hàng từ DataGridView
                    dtgv_ChinhSuaChiTieu.Rows.Remove(row);

                    // Thông báo xóa thành công (hoặc thực hiện các thao tác khác sau khi xóa)
                    ev.QFrmThongBao("Hàng được xóa thành công.");
                }

            }
        }



        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            int namPhieu;

            if (int.TryParse(txt_Nam.Text, out namPhieu))
            {
                using (SqlConnection connection = new SqlConnection(mconnectstring))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("dbo.KiemTraNamPhieuTrangThai", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@NamPhieu", SqlDbType.Int).Value = namPhieu;
                        SqlParameter ketQuaParam = new SqlParameter("@KetQua", SqlDbType.Int);
                        ketQuaParam.Direction = ParameterDirection.ReturnValue; // Thay đổi từ Output thành ReturnValue
                        cmd.Parameters.Add(ketQuaParam);
                        cmd.ExecuteNonQuery();
                        int ketQua = (int)cmd.Parameters["@KetQua"].Value;
                        if (ketQua == 1)
                        {
                            if (!string.IsNullOrEmpty(txt_Nam.Text))
                            {
                                if (int.TryParse(txt_Nam.Text, out int nam))
                                {
                                    int namhientai = DateTime.Today.Year;
                                    if (nam < namhientai)
                                    {
                                        ev.QFrmThongBao("Không thể cấp cho những năm trước đấy");
                                        txt_Nam.Text = namhientai.ToString();
                                    }
                                    else
                                    {
                                        bool result = ev.QFrmThongBao_YesNo("Phiếu năm này chưa được cấp. Bạn có muốn cấp cho nó không?");
                                        if (result == true)
                                        {                                       
                                            Frm_CapDanhSachKPI form = new Frm_CapDanhSachKPI(nam);
                                            form.ShowDialog();
                                            this.Close();
                                        }
                                    }
                                }
                            }
                           

                        }
                        else if (ketQua == 3)
                        {
                            bool result = ev.QFrmThongBao_YesNo("Phiếu đã được cấp trên duyệt. bạn có muốn xem lại?");
                            if(result == true)
                            {
                                SqlCommand getMaPhieuCmd = new SqlCommand("SELECT dbo.GetMaPhieuByNamPhieu(@NamPhieu)", connection);
                                getMaPhieuCmd.Parameters.AddWithValue("@NamPhieu", namPhieu);
                                txt_Nam.Text = namPhieu.ToString();

                                string maPhieu = getMaPhieuCmd.ExecuteScalar()?.ToString();

                                if (!string.IsNullOrEmpty(maPhieu))
                                {
                                    SqlDataAdapter adapter = new SqlDataAdapter($"SELECT ChiTiet.*, KPI.NoiDung, KPI.DonViTinh, NhomTieuChi.TenTieuChi, KPI.ChiTieu " +
                                        $"FROM dbo.ChiTietTieuChiMucTieuBV ChiTiet INNER JOIN dbo.KPI ON ChiTiet.MaKPI = KPI.MaKPI " +
                                        $"INNER JOIN dbo.NhomTieuChi ON KPI.TieuChiID = NhomTieuChi.TieuChiID WHERE ChiTiet.MaPhieuKPIBV = '{maPhieu}'", connection);
                                    DataTable dataTable = new DataTable();
                                    adapter.Fill(dataTable);
                                    dtgv_ChinhSuaChiTieu.DataSource = dataTable;
                                    txt_MaPhieu.Text = maPhieu.ToString();
                                    btn_Them.Visible = false;
                                    btn_Luu.Visible = false;
                                    dtgv_ChinhSuaChiTieu.Columns["cXoa"].Visible = false;
                                }
                                else
                                {
                                    ev.QFrmThongBao("Lỗi khi lấy mã phiếu.");
                                }
                            }
                            
                            

                        }
                        else if (ketQua == 4)
                        {
                            bool result = ev.QFrmThongBao_YesNo("Phiếu năm này đã được tạo bạn có muốn chỉnh sửa phiếu lại không ???");
                            if (result == true)
                            {
                                SqlCommand getMaPhieuCmd = new SqlCommand("SELECT dbo.GetMaPhieuByNamPhieu(@NamPhieu)", connection);
                                getMaPhieuCmd.Parameters.AddWithValue("@NamPhieu", namPhieu);
                                txt_Nam.Text = namPhieu.ToString();

                                string maPhieu = getMaPhieuCmd.ExecuteScalar()?.ToString();

                                if (!string.IsNullOrEmpty(maPhieu))
                                {
                                    SqlDataAdapter adapter = new SqlDataAdapter($"SELECT ChiTiet.*, KPI.NoiDung, KPI.DonViTinh, NhomTieuChi.TenTieuChi, KPI.ChiTieu " +
                                        $"FROM dbo.ChiTietTieuChiMucTieuBV ChiTiet INNER JOIN dbo.KPI ON ChiTiet.MaKPI = KPI.MaKPI " +
                                        $"INNER JOIN dbo.NhomTieuChi ON KPI.TieuChiID = NhomTieuChi.TieuChiID WHERE ChiTiet.MaPhieuKPIBV = '{maPhieu}'", connection);
                                    DataTable dataTable = new DataTable();
                                    adapter.Fill(dataTable);
                                    dtgv_ChinhSuaChiTieu.DataSource = dataTable;
                                    txt_MaPhieu.Text = maPhieu.ToString();
                                    btn_Them.Visible = true;
                                    btn_Luu.Visible = true;
                                    dtgv_ChinhSuaChiTieu.Columns["cXoa"].Visible = false;

                                }
                                else
                                {
                                    ev.QFrmThongBao("Lỗi khi lấy mã phiếu.");
                                }
                            }
                            else
                            {
                                ev.QFrmThongBao("Không có chỉnh sửa cần thay đổi!");
                            }
                        }
                    }
                }
            }
            else
            {
                ev.QFrmThongBaoError("Vui lòng nhập dữ liệu vào ô năm.");
            }
        }

        private void btn_TroLai_Click(object sender, EventArgs e)
        {
            bool result = ev.QFrmThongBao_YesNo("Bạn có chắc chắn muốn quay lại?");
            if (result == true)
            {
                Frm_Chinh_GUI form1 = new Frm_Chinh_GUI();
                form1.ShowDialog();
                this.Hide();
            }
            else
            {

            }

        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (dtgv_ChinhSuaChiTieu.Rows.Count > 0)
            {
                DeleteEditTableChiTiet();
                SaveEditTableChiTiet();
                dtgv_ChinhSuaChiTieu.Columns.Clear();
                ev.QFrmThongBao("Bạn đã cập nhật mã phiếu thành công !");
                bool result = ev.QFrmThongBao_YesNo("Bạn có muốn quay lại trang chủ?");
                if (result == true)
                {
                    Frm_Chinh_GUI form1 = new Frm_Chinh_GUI();
                    form1.ShowDialog();
                    this.Hide();
                }
            }
            else
            {
                ev.QFrmThongBao("Không có dữ liệu để lưu! ");
            }

        }
        private void TinhTongTrongSoTheoTieuChi(TextBox txtTongTrongSo)
        {
            Dictionary<string, float> tongByTieuChiId = new Dictionary<string, float>();
            float tongTatCaTrongSo = 0;

            foreach (DataGridViewRow row in dtgv_ChinhSuaChiTieu.Rows)
            {
                if (row.Index == dtgv_ChinhSuaChiTieu.Rows.Count)
                {
                    continue;
                }

                string tieuChiIDStr = row.Cells["clTieuChiID"].Value.ToString();

                // Kiểm tra xem giá trị có thể chuyển đổi thành float không
                if (float.TryParse(row.Cells["clTrongSoTCBV"].Value.ToString(), out float trongSoTCBV))
                {
                    // Kiểm tra xem đã có tổng cho TieuChiId này chưa
                    if (tongByTieuChiId.ContainsKey(tieuChiIDStr))
                    {
                        // Nếu có rồi, thì không cộng dồn vào tổng hiện tại
                    }
                    else
                    {
                        // Nếu chưa có, thì thêm vào Dictionary và cộng vào tổng
                        tongByTieuChiId.Add(tieuChiIDStr, trongSoTCBV);
                        tongTatCaTrongSo += trongSoTCBV;
                    }
                }
                else
                {
                    // Xử lý trường hợp giá trị không thể chuyển đổi thành float
                    ev.QFrmThongBaoError($"Giá trị không hợp lệ cho clTrongSoTCBV tại TiêuChiID: {tieuChiIDStr}");
                }
            }
            txtTongTrongSo.Text = tongTatCaTrongSo.ToString();
            if (tongTatCaTrongSo != 100)
            {
                txtTongTrongSo.Text = "0"; // hoặc bất kỳ giá trị mặc định khác

            }
        }
        private void KiemTraVaHienThiThongBao()
        {
            // Lấy giá trị từ TextBox txtTongTrongSo
            if (float.TryParse(txtTongTrongSo.Text, out float tongTrongSo))
            {
                // Kiểm tra giá trị của tongTrongSo
                if (tongTrongSo > 100)
                {
                    // Lấy chỉ số của cột clTrongSoBV trong DataGridView
                    int columnIndex = dtgv_ChinhSuaChiTieu.Columns["clTrongSoTCBV"].Index;

                    // Làm sạch tất cả các ô trong cột clTrongSoBV
                    foreach (DataGridViewRow row in dtgv_ChinhSuaChiTieu.Rows)
                    {
                        row.Cells[columnIndex].Value = string.Empty;
                    }

                    // Hiển thị thông báo nếu tổng trọng số lớn hơn 100
                    ev.QFrmThongBao("Tổng trọng số lớn hơn 100");
                }
                else if (tongTrongSo > 0 && tongTrongSo < 100)
                {
                    // Lấy chỉ số của cột clTrongSoBV trong DataGridView
                    int columnIndex = dtgv_ChinhSuaChiTieu.Columns["clTrongSoTCBV"].Index;

                    // Làm sạch tất cả các ô trong cột clTrongSoBV
                    foreach (DataGridViewRow row in dtgv_ChinhSuaChiTieu.Rows)
                    {
                        row.Cells[columnIndex].Value = string.Empty;
                    }

                    // Hiển thị thông báo nếu tổng trọng số bé hơn 100 nhưng lớn hơn 0
                    ev.QFrmThongBao("Chưa đủ tỷ trọng");
                }
                else
                {
                    // Thực hiện công việc khác nếu cần
                }
            }
            else
            {
                // Xử lý trường hợp giá trị không hợp lệ
                ev.QFrmThongBao("Giá trị không hợp lệ");
            }
        }
        private void CapNhatTrongSoTheoTenTieuChi()
        {
            for (int i = 0; i < dtgv_ChinhSuaChiTieu.RowCount; i++)
            {
                float trongSo;

                // Thử chuyển đổi giá trị từ ô cột clTrongSoTCBV sang kiểu float
                if (float.TryParse(dtgv_ChinhSuaChiTieu.Rows[i].Cells["clTrongSoTCBV"].Value?.ToString(), out trongSo))
                {
                    string tenTieuChi = dtgv_ChinhSuaChiTieu.Rows[i].Cells["clTieuChiID"].Value?.ToString().Trim();

                    if (!string.IsNullOrEmpty(tenTieuChi))
                    {
                        for (int j = 0; j < dtgv_ChinhSuaChiTieu.RowCount; j++)
                        {
                            if (tenTieuChi == dtgv_ChinhSuaChiTieu.Rows[j].Cells["clTieuChiID"].Value?.ToString().Trim())
                            {
                                dtgv_ChinhSuaChiTieu.Rows[j].Cells["clTrongSoTCBV"].Value = trongSo;
                            }
                        }
                    }
                }
                else
                {
                    //// Xử lý trường hợp giá trị không hợp lệ
                    //ev.QFrmThongBaoError($"Giá trị không hợp lệ cho clTrongSoTCBV tại dòng {i + 1}");
                }

            }

        }
        private int editedCellCount = 0;
        private void dtgv_ChinhSuaChiTieu_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CapNhatTrongSoTheoTenTieuChi();

            // Kiểm tra xem sự kiện có xảy ra trong cột clTrongSoTCBV không
            if (e.ColumnIndex == dtgv_ChinhSuaChiTieu.Columns["clTrongSoTCBV"].Index)
            {
                // Ghi nhận việc chỉnh sửa ô
                editedCellCount++;

                // Kiểm tra xem đã chỉnh sửa hết tất cả các ô trong cột clTrongSoTCBV của tất cả các dòng chưa
                if (AllTrongSoCellsEdited())
                {
                    // Gọi lại hàm để tính tổng trọng số và cập nhật TextBox
                    TinhTongTrongSoTheoTieuChi(txtTongTrongSo);

                    // Reset biến đếm
                    editedCellCount = 0;
                }
            }
        }
        private bool AllTrongSoCellsEdited()
        {
            foreach (DataGridViewRow row in dtgv_ChinhSuaChiTieu.Rows)
            {
                if (row.Index != dtgv_ChinhSuaChiTieu.NewRowIndex && string.IsNullOrEmpty(row.Cells["clTrongSoTCBV"].Value?.ToString()))
                {
                    return false;
                }
            }
            return true;
        }
        private void txtTongTrongSo_TextChanged(object sender, EventArgs e)
        {
            KiemTraVaHienThiThongBao();
        }

        private void dtgv_ChinhSuaChiTieu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            ev.Qdgr_RowPostPaint(sender, e, dtgv_ChinhSuaChiTieu);
        }

        private void dtgv_ChinhSuaChiTieu_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // Kiểm tra nếu cột đang được chỉnh sửa là cột "clTrongSoTCBV"
            if (dtgv_ChinhSuaChiTieu.Columns[e.ColumnIndex].Name == "clTrongSoTCBV")
            {
                // Kiểm tra xem giá trị có được nhập hay không
                if (string.IsNullOrWhiteSpace(e.FormattedValue?.ToString()))
                {
                    // Cho phép ô trống
                    return;
                }

                float trongSo;

                // Kiểm tra xem giá trị có phải là số thực hay không
                if (!float.TryParse(e.FormattedValue.ToString(), out trongSo))
                {
                    // Nếu không phải là số thực, hiển thị thông báo lỗi
                    e.Cancel = true;
                    ev.QFrmThongBaoError("Vui lòng nhập một giá trị số thực.");
                }
            }
        }
        private void DeleteEditTableChiTiet()
        {
            using (SqlConnection connection = new SqlConnection(mconnectstring))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = connection;
                    string query = "Delete from [dbo].[ChiTietTieuChiMucTieuBV] where MaPhieuKPIBV = '" + txt_MaPhieu.Text + "'";
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                }
            }
        }
        private void SaveEditTableChiTiet()
        {
            using (SqlConnection conn = new SqlConnection(mconnectstring))
            {
                conn.Open();
                if (dtgv_ChinhSuaChiTieu.SelectedCells.Count > 0)
                {
                    string maPhieu = txt_MaPhieu.Text;
                    foreach (DataGridViewRow row in dtgv_ChinhSuaChiTieu.Rows)
                    {
                        if (row.Index == dtgv_ChinhSuaChiTieu.Rows.Count)
                        {
                            continue;
                        }
                        if(row.Cells["clTrongSoTCBV"].Value == null || string.IsNullOrWhiteSpace(row.Cells["clTrongSoTCBV"].Value.ToString()))
                        {
                            ev.QFrmThongBaoError("Vui lòng nhập giá trị vào ô trọng số tiêu chí bệnh viện");
                            return;
                        }
                        if(row.Cells["cTrongSoKPIBV"].Value == null || string.IsNullOrWhiteSpace(row.Cells["cTrongSoKPIBV"].Value.ToString()))
                        {
                            ev.QFrmThongBaoError("Vui lòng nhập giá trị cho cột trọng số KPI bệnh viện");
                            return;
                        }
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.Connection = conn;
                            string query = "Insert into [dbo].[ChiTietTieuChiMucTieuBV]([MaPhieuKPIBV],[MaKPI],[TrongSoTCBV],[TrongSoKPIBV])" +
                                "VALUES(@mpkpi,@makpi,@tstcbv,@tskpibv)";
                            cmd.CommandText = query;

                            int maKPI = Convert.ToInt32(row.Cells["clMaKPI"].Value);
                            int trongSoTieuChiBV = Convert.ToInt32(row.Cells["clTrongSoTCBV"].Value);
                            int trongSoKPIBV = Convert.ToInt32(row.Cells["cTrongSoKPIBV"].Value);

                            cmd.Parameters.AddWithValue("@mpkpi", maPhieu);
                            cmd.Parameters.AddWithValue("@makpi", maKPI);
                            cmd.Parameters.AddWithValue("@tstcbv", trongSoTieuChiBV);
                            cmd.Parameters.AddWithValue("@tskpibv", trongSoKPIBV);
                            cmd.ExecuteNonQuery();
                        }
                    }

                }
                else
                {
                    ev.QFrmThongBao("hệ thống gặp sự cố. Xin lỗi vì sự bất tiện này !");
                }
            }

        }

        private void txt_Nam1_TextChanged(object sender, EventArgs e)
        {
            int namPhieu;

            if (int.TryParse(txt_Nam1.Text, out namPhieu))
            {
                using (SqlConnection connection = new SqlConnection(mconnectstring))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("dbo.KiemTraNamPhieuTrangThai", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@NamPhieu", SqlDbType.Int).Value = namPhieu;
                        SqlParameter ketQuaParam = new SqlParameter("@KetQua", SqlDbType.Int);
                        ketQuaParam.Direction = ParameterDirection.ReturnValue; // Thay đổi từ Output thành ReturnValue
                        cmd.Parameters.Add(ketQuaParam);
                        cmd.ExecuteNonQuery();
                        int ketQua = (int)cmd.Parameters["@KetQua"].Value;
                        if (ketQua == 3)
                        {
                              SqlCommand getMaPhieuCmd = new SqlCommand("SELECT dbo.GetMaPhieuByNamPhieu(@NamPhieu)", connection);
                                getMaPhieuCmd.Parameters.AddWithValue("@NamPhieu", namPhieu);
                                txt_Nam.Text = namPhieu.ToString();

                                string maPhieu = getMaPhieuCmd.ExecuteScalar()?.ToString();

                                if (!string.IsNullOrEmpty(maPhieu))
                                {
                                    SqlDataAdapter adapter = new SqlDataAdapter($"SELECT ChiTiet.*, KPI.NoiDung, KPI.DonViTinh, NhomTieuChi.TenTieuChi, KPI.ChiTieu " +
                                        $"FROM dbo.ChiTietTieuChiMucTieuBV ChiTiet INNER JOIN dbo.KPI ON ChiTiet.MaKPI = KPI.MaKPI " +
                                        $"INNER JOIN dbo.NhomTieuChi ON KPI.TieuChiID = NhomTieuChi.TieuChiID WHERE ChiTiet.MaPhieuKPIBV = '{maPhieu}'", connection);
                                    DataTable dataTable = new DataTable();
                                    adapter.Fill(dataTable);
                                    dtgv_ChinhSuaChiTieu.DataSource = dataTable;
                                    txt_MaPhieu.Text = maPhieu.ToString();
                                    btn_Them.Visible = false;
                                    btn_Luu.Visible = false;
                                    dtgv_ChinhSuaChiTieu.Columns["cXoa"].Visible = false;
                                }
                                else
                                {
                                    ev.QFrmThongBao("Lỗi khi lấy mã phiếu.");
                                }                          
                        }

                    }
                }
            }
        }
    }

}