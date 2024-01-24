using BusinessCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
//using DevExpress.XtraVerticalGrid;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;

namespace DuAn_QuanLyKPI.GUI
{
    public partial class Frm_ChiTieuVuaGiao : DevExpress.XtraEditors.XtraForm
    {
        //lấy dữ liệu từu frm login
        public static string MaNV = Frm_Login.MaNV;
        public static string MaPhongKhoa = Frm_Login.MaPhongKhoa;
        public static string MaChucDanh = Frm_Login.MaChucDanh;
        public static string TenNV = Frm_Login.TenNV;
        public static string TenChucDanh = Frm_Login.TenChucDanh;
        public static string TenPhongKhoa = Frm_Login.TenPhongKhoa;
        private List<int> receivedItems;
        //private string mconnectstring = "server=192.168.50.108,1433; database=QuanLyKPI;uid=sa;pwd=123";
        private static string mconnectstring = Frm_A78.mconnectstring;
        private clsCommonMethod comm = new clsCommonMethod();
        private clsEventArgs ev = new clsEventArgs("");
        private string msql;
        private BindingList<MyData> dataList = new BindingList<MyData>();
        private int NamPhieu { get; set; }
        public Frm_ChiTieuVuaGiao()
        {
            InitializeComponent();
            dtgv_ChiTietKPI.DataSource = dataList;

        }
        public class MyData
        {
            public string TieuChiID { get; set; }
            public float TrongSoTCBV { get; set; }

            // Các thuộc tính khác nếu cần
        }
        //public string ChucDanhData
        //{
        //    get { return txt_ChucDanh.Text; }
        //    set { txt_ChucDanh.Text = value; }
        //}

        //public string KhoaPhongData
        //{
        //    get { return txt_KhoaPhong.Text; }
        //    set { txt_KhoaPhong.Text = value; }
        //}



        public Frm_ChiTieuVuaGiao(List<int> selectedItems, int namphieu)
        {
            InitializeComponent();
            receivedItems = selectedItems;
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
            dtgv_ChiTietKPI.DataSource = dataTable;
            NamPhieu = namphieu;
            if (NamPhieu != 0)
            {
                txt_Nam.Text = NamPhieu.ToString();
                DateTime selected = new DateTime(NamPhieu, 1, 1);
                dt_NgayTaoMaPhieu.Value = selected;
            }
        }
        public Frm_ChiTieuVuaGiao(List<int> selectedItems)
        {
            InitializeComponent();
            receivedItems = selectedItems;
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
            dtgv_ChiTietKPI.DataSource = dataTable;

        }

        public string CreateKpiCode(DateTime ngay)
        {
            using (SqlConnection connection = new SqlConnection(mconnectstring))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT [dbo].[TaoMaPhieuKPIBV](@ngay)", connection))
                {
                    command.Parameters.AddWithValue("@ngay", ngay);
                    string result = command.ExecuteScalar().ToString();
                    return result;
                }
            }
        }
        public int GetYearFromNgayTaoPhieuKPI(DateTime ngay)
        {
            using (SqlConnection connection = new SqlConnection(mconnectstring))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT YEAR(@ngay)", connection))
                {
                    command.Parameters.AddWithValue("@ngay", ngay);
                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        return (int)result;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }
        private void TinhTongTrongSoTheoTieuChi(TextBox txtTongTrongSo)
        {
            Dictionary<string, float> tongByTieuChiId = new Dictionary<string, float>();
            float tongTatCaTrongSo = 0;

            foreach (DataGridViewRow row in dtgv_ChiTietKPI.Rows)
            {
                if (row.Index == dtgv_ChiTietKPI.Rows.Count)
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
                    int columnIndex = dtgv_ChiTietKPI.Columns["clTrongSoTCBV"].Index;

                    // Làm sạch tất cả các ô trong cột clTrongSoBV
                    foreach (DataGridViewRow row in dtgv_ChiTietKPI.Rows)
                    {
                        row.Cells[columnIndex].Value = string.Empty;
                    }

                    // Hiển thị thông báo nếu tổng trọng số lớn hơn 100
                    ev.QFrmThongBao("Tổng trọng số lớn hơn 100");
                }
                else if (tongTrongSo > 0 && tongTrongSo < 100)
                {
                    // Lấy chỉ số của cột clTrongSoBV trong DataGridView
                    int columnIndex = dtgv_ChiTietKPI.Columns["clTrongSoTCBV"].Index;

                    // Làm sạch tất cả các ô trong cột clTrongSoBV
                    foreach (DataGridViewRow row in dtgv_ChiTietKPI.Rows)
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
        public int GetQuarterFromNgayTaoPhieuKPI(DateTime ngay)
        {
            using (SqlConnection connection = new SqlConnection(mconnectstring))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT [dbo].[GetQuarterFromNgayTaoPhieuKPI](@ngay)", connection))
                {
                    command.Parameters.AddWithValue("@ngay", ngay);
                    object result = command.ExecuteScalar();
                    return (int)result;
                }
            }
        }

        private void btn_TaoMaPhieu_Click(object sender, EventArgs e)
        {
            DateTime ngayTao = dt_NgayTaoMaPhieu.Value; // Assume dtNgayTao is your DateTimePicker
            string maPhieuKPI = CreateKpiCode(ngayTao);
            txt_MaPhieu.Text = maPhieuKPI;
        }
        private void layNam()
        {
            DateTime ngayTao = dt_NgayTaoMaPhieu.Value;
            int nam = GetYearFromNgayTaoPhieuKPI(ngayTao);
            txt_Nam.Text = nam.ToString();
        }
        private void SaveToDatabase()
        {
            using (SqlConnection connection = new SqlConnection(mconnectstring))
            {
                connection.Open();
                if (dtgv_ChiTietKPI.SelectedCells.Count > 0)
                {
                    string maPhieu = txt_MaPhieu.Text;

                    DateTime ngayTaoMaPhieu = dt_NgayTaoMaPhieu.Value;
                    bool allRowsFilled = true;
                    foreach (DataGridViewRow row in dtgv_ChiTietKPI.Rows)
                    {
                        if (row.Index == dtgv_ChiTietKPI.Rows.Count)
                        {
                            continue;
                        }
                        //Kiểm tra giá trị của cột clTrongSoTieuChi
                        if (row.Cells["clTrongSoTCBV"].Value == null || string.IsNullOrWhiteSpace(row.Cells["clTrongSoTCBV"].Value.ToString()))
                        {
                            ev.QFrmThongBaoError("Vui lòng nhập giá trị cho trọng số tiêu chí bệnh viện.");
                            allRowsFilled = false;
                            break;
                        }
                        //Kiểm tra giá trị của cột clTrongSoKPIBV
                        if (row.Cells["cTrongSoKPIBV"].Value == null || string.IsNullOrWhiteSpace(row.Cells["cTrongSoKPIBV"].Value.ToString()))
                        {
                            ev.QFrmThongBaoError("Vui lòng nhập giá trị cho trọng số KPi bệnh viện. ");
                            allRowsFilled = false;
                            return;
                        }
                    }
                    if (allRowsFilled)
                    {
                        foreach (DataGridViewRow row in dtgv_ChiTietKPI.Rows)
                        {
                            if (row.Index == dtgv_ChiTietKPI.Rows.Count)
                            {
                                continue;
                            }
                            else
                            {
                                btn_Luu.Visible = false;
                            }
                            // Tạo một command để thực thi truy vấn
                            using (SqlCommand command = new SqlCommand())
                            {
                                command.Connection = connection;
                                string query = "INSERT INTO [dbo].[ChiTietTieuChiMucTieuBV]([MaPhieuKPIBV],[MaKPI],[TrongSoTCBV],[TrongSoKPIBV])" +
                                    " VALUES (@mpkpi, @mkpi, @tstcbv,@tskpibv)";
                                command.CommandText = query;

                                int maKPI = Convert.ToInt32(row.Cells["clMaKPI"].Value);
                                int trongSoTieuChiBV = Convert.ToInt32(row.Cells["clTrongSoTCBV"].Value);
                                int trongSoKPIBV = Convert.ToInt32(row.Cells["cTrongSoKPIBV"].Value);

                                // Thay thế các tham số bằng giá trị thực từ form của bạn
                                command.Parameters.AddWithValue("@mpkpi", maPhieu);
                                command.Parameters.AddWithValue("@mkpi", maKPI);
                                command.Parameters.AddWithValue("@tstcbv", trongSoTieuChiBV);
                                command.Parameters.AddWithValue("@tskpibv", trongSoKPIBV);

                                // Tiếp tục thêm các tham số khác tương ứng với cột trong bảng

                                // Thực thi truy vấn
                                command.ExecuteNonQuery();
                            }
                        }

                        ev.QFrmThongBao("Bạn đã lưu thành công");
                    }
                    else
                    {
                        ev.QFrmThongBaoError("Vui lòng nhập giá trị cho tất cả các hàng của trọng số tiêu chí bệnh viện");
                    }

                }
                else
                {
                    ev.QFrmThongBaoError("Bị lỗi");
                }
            }
        }

        private void SavetoDatabase2()
        {
            DateTime ngayTaoMaPhieu = dt_NgayTaoMaPhieu.Value;


            // Kiểm tra giá trị không null
            if (string.IsNullOrEmpty(txt_MaPhieu.Text) || string.IsNullOrEmpty(txt_Nam.Text) || string.IsNullOrEmpty(txtTongTrongSo.Text))
            {
                // Xử lý khi giá trị null hoặc rỗng
                // (Bạn có thể hiển thị thông báo hoặc thực hiện các xử lý phù hợp khác)
                return;
            }

            string msql = "INSERT INTO [dbo].[KPI_BenhVien] ([MaPhieuKPIBV],[NamPhieu],[TongTrongSo],[NguoiLap],[NguoiPheDuyet],[NgayLapPhieuKPIBV],[NgayPheDuyet],[IDBieuMau],[TrangThai])" +
                          " VALUES (@mpkpi, @np, @tongts, @nl, @nguoipheduyet, @ngaylpkpi, @npd, @idbm,@trangthai)";

            using (SqlConnection connection = new SqlConnection(mconnectstring))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(msql, connection))
                {
                    command.Parameters.AddWithValue("@mpkpi", txt_MaPhieu.Text);
                    command.Parameters.AddWithValue("@np", txt_Nam.Text);
                    command.Parameters.AddWithValue("@tongts", txtTongTrongSo.Text);
                    command.Parameters.AddWithValue("@nl", MaNV);
                    command.Parameters.AddWithValue("@nguoipheduyet", DBNull.Value); // Hoặc có thể sử dụng giá trị mặc định phù hợp
                    command.Parameters.AddWithValue("@ngaylpkpi", ngayTaoMaPhieu);
                    command.Parameters.AddWithValue("@npd", DBNull.Value); // Hoặc có thể sử dụng giá trị mặc định phù hợp
                    command.Parameters.AddWithValue("@idbm", 71);
                    command.Parameters.AddWithValue("@trangthai", 0);

                    command.ExecuteNonQuery();
                }
            }
        }
        private bool IsDataGridViewFilled(DataGridView dataGridView)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                // Lấy giá trị của cột clChiTieuKpi (hoặc chỉ số cột tương ứng)
                object chiTieuValue = row.Cells["clTrongSoTCBV"].Value;

                // Lấy giá trị của cột clTieuChiKPi (hoặc chỉ số cột tương ứng)
                object tieuChiValue = row.Cells["cTrongSoKPIBV"].Value;

                // Kiểm tra giá trị của cả hai cột
                if (chiTieuValue == null || string.IsNullOrWhiteSpace(chiTieuValue.ToString()) ||
                    tieuChiValue == null || string.IsNullOrWhiteSpace(tieuChiValue.ToString()))
                {
                    // Nếu một ô trong hai cột không có giá trị hoặc có giá trị trắng, trả về false
                    return false;
                }
            }

            // Nếu tất cả các ô trong hai cột đều có giá trị, trả về true
            return true;
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            //SavetoDatabase2();
            //SaveToDatabase();
            //ev.QFrmThongBao("Bạn đã lưu thành công !");
            //bool result = ev.QFrmThongBao_YesNo("Bạn có muốn tiếp tục cấp thêm thông tin không ???");
            //if(result == true)
            //{
            //    Frm_CapDanhSachKPI form = new Frm_CapDanhSachKPI();
            //    form.ShowDialog();
            //}
            //else
            //{
            //    Frm_Chinh_GUI form1 = new Frm_Chinh_GUI();
            //    form1.ShowDialog();
            //}
            //this.Hide();
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
                        //Nam chưa có 
                        if (ketQua == 1)
                        {
                            bool isDataGridViewFilled = IsDataGridViewFilled(dtgv_ChiTietKPI);

                            if (isDataGridViewFilled)
                            {
                                SavetoDatabase2();
                                SaveToDatabase();
                            }
                            else
                            { ev.QFrmThongBaoError("Có ô chưa được nhập"); }    

                        }
                        else if (ketQua == 3)
                        {
                            ev.QFrmThongBao("Dữ liệu đã được cấp trên duyệt, không thể chỉnh sửa.");
                        }
                        else if (ketQua == 4)
                        {
                            bool result = ev.QFrmThongBao_YesNo("Phiếu năm này đã được tạo bạn có muốn chỉnh sửa phiếu lại không ???");
                            if (result == true)
                            {
                                SqlCommand getMaPhieuCmd = new SqlCommand("SELECT dbo.GetMaPhieuByNamPhieu(@NamPhieu)", connection);
                                getMaPhieuCmd.Parameters.AddWithValue("@NamPhieu", namPhieu);

                                string maPhieu = getMaPhieuCmd.ExecuteScalar()?.ToString();

                                if (!string.IsNullOrEmpty(maPhieu))
                                {
                                    SqlDataAdapter adapter = new SqlDataAdapter($"SELECT ChiTiet.*, KPI.NoiDung, KPI.DonViTinh, NhomTieuChi.TenTieuChi, KPI.ChiTieu " +
                                        $"FROM dbo.ChiTietTieuChiMucTieuBV ChiTiet INNER JOIN dbo.KPI ON ChiTiet.MaKPI = KPI.MaKPI " +
                                        $"INNER JOIN dbo.NhomTieuChi ON KPI.TieuChiID = NhomTieuChi.TieuChiID WHERE ChiTiet.MaPhieuKPIBV = '{maPhieu}'", connection);
                                    DataTable dataTable = new DataTable();
                                    adapter.Fill(dataTable);

                                    // Tạo một form mới và truyền DataTable tới constructor
                                    Frm_ChinhSuaCap newForm = new Frm_ChinhSuaCap(dataTable, namPhieu, maPhieu);


                                    // Hiển thị form mới
                                    newForm.ShowDialog();
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
                MessageBox.Show("Vui lòng nhập số nguyên vào ô NamPhieu.");
            }
        }

        private void dt_NgayTaoMaPhieu_ValueChanged(object sender, EventArgs e)
        {
            layNam();
        }

        private void Frm_ChiTieuVuaGiao_Load(object sender, EventArgs e)
        {

        }

        private void txt_MaPhieu_TextChanged(object sender, EventArgs e)
        {
            layNam();
        }

        private void dtgv_ChiTietKPI_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dtgv_ChiTietKPI.Columns["btnDelete"].Index)
            {
                // Xác nhận xóa

                bool result = ev.QFrmThongBao_YesNo("Bạn chắc chắn muốn xóa?");

                if (result == true)
                {
                    // Lấy hàng chứa nút
                    DataGridViewRow row = dtgv_ChiTietKPI.Rows[e.RowIndex];

                    // Xóa dữ liệu tương ứng với hàng này từ nguồn dữ liệu của bạn

                    // Xóa hàng từ DataGridView
                    dtgv_ChiTietKPI.Rows.Remove(row);

                    // Thông báo xóa thành công (hoặc thực hiện các thao tác khác sau khi xóa)
                    ev.QFrmThongBao("Hàng được xóa thành công.");
                }
            }
        }

        private void CapNhatTrongSoTheoTenTieuChi()
        {
            for (int i = 0; i < dtgv_ChiTietKPI.RowCount; i++)
            {
                float trongSo;

                // Thử chuyển đổi giá trị từ ô cột clTrongSoTCBV sang kiểu float
                if (float.TryParse(dtgv_ChiTietKPI.Rows[i].Cells["clTrongSoTCBV"].Value?.ToString(), out trongSo))
                {
                    string tenTieuChi = dtgv_ChiTietKPI.Rows[i].Cells["clTieuChiID"].Value?.ToString().Trim();

                    if (!string.IsNullOrEmpty(tenTieuChi))
                    {
                        for (int j = 0; j < dtgv_ChiTietKPI.RowCount; j++)
                        {
                            if (tenTieuChi == dtgv_ChiTietKPI.Rows[j].Cells["clTieuChiID"].Value?.ToString().Trim())
                            {
                                dtgv_ChiTietKPI.Rows[j].Cells["clTrongSoTCBV"].Value = trongSo;
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
        private void dtgv_ChiTietKPI_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CapNhatTrongSoTheoTenTieuChi();

            // Kiểm tra xem sự kiện có xảy ra trong cột clTrongSoTCBV không
            if (e.ColumnIndex == dtgv_ChiTietKPI.Columns["clTrongSoTCBV"].Index)
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
            foreach (DataGridViewRow row in dtgv_ChiTietKPI.Rows)
            {
                if (row.Index != dtgv_ChiTietKPI.NewRowIndex && string.IsNullOrEmpty(row.Cells["clTrongSoTCBV"].Value?.ToString()))
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

        private void dtgv_ChiTietKPI_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            ev.Qdgr_RowPostPaint(sender, e, dtgv_ChiTietKPI);
        }

        private void dtgv_ChiTietKPI_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // Kiểm tra nếu cột đang được chỉnh sửa là cột "clTrongSoTCBV"
            if (dtgv_ChiTietKPI.Columns[e.ColumnIndex].Name == "clTrongSoTCBV")
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

        private void txt_Nam_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_Nam.Text))
            {
                if (int.TryParse(txt_Nam.Text, out int nam))
                {
                    int namhientai = DateTime.Now.Year;
                    if (nam < namhientai)
                    {
                        ev.QFrmThongBao("Không thể tạo cho năm nhỏ hơn năm hiện tại.");
                        btn_Luu.Visible = false;
                    }
                }
            }
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
                        //Nam chưa có 
                        if (ketQua == 1)
                        {

                        }
                        else if (ketQua == 3)
                        {
                            bool result = ev.QFrmThongBao_YesNo("Phiếu đã được cấp trên duyệt. bạn có muốn xem lại?");
                            if (result == true)
                            {
                                if (int.TryParse(txt_Nam.Text, out int namphieu))
                                {
                                    Frm_ChinhSuaCap form = new Frm_ChinhSuaCap(namphieu);
                                    form.ShowDialog();
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

                                string maPhieu = getMaPhieuCmd.ExecuteScalar()?.ToString();

                                if (!string.IsNullOrEmpty(maPhieu))
                                {
                                    SqlDataAdapter adapter = new SqlDataAdapter($"SELECT ChiTiet.*, KPI.NoiDung, KPI.DonViTinh, NhomTieuChi.TenTieuChi, KPI.ChiTieu " +
                                        $"FROM dbo.ChiTietTieuChiMucTieuBV ChiTiet INNER JOIN dbo.KPI ON ChiTiet.MaKPI = KPI.MaKPI " +
                                        $"INNER JOIN dbo.NhomTieuChi ON KPI.TieuChiID = NhomTieuChi.TieuChiID WHERE ChiTiet.MaPhieuKPIBV = '{maPhieu}'", connection);
                                    DataTable dataTable = new DataTable();
                                    adapter.Fill(dataTable);

                                    // Tạo một form mới và truyền DataTable tới constructor
                                    Frm_ChinhSuaCap newForm = new Frm_ChinhSuaCap(dataTable, namPhieu, maPhieu);


                                    // Hiển thị form mới
                                    newForm.ShowDialog();
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
                ev.QFrmThongBaoError("Vui lòng nhập số nguyên vào ô NamPhieu.");
            }
        }
        private void dtgv_ChiTietKPI_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell cell = dtgv_ChiTietKPI.Rows[e.RowIndex].Cells[e.ColumnIndex];
                string currentCellValue = cell.Value?.ToString();

                if (!string.IsNullOrEmpty(currentCellValue))
                {
                    DialogResult result = MessageBox.Show("Bạn muốn sửa giá trị này?", "Sửa giá trị", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        string newValue = GetNewDateValue(); // Hàm này để lấy giá trị mới từ người dùng, có thể làm qua một Form hoặc MessageBox để nhập giá trị

                        // Kiểm tra xem giá trị mới có đúng định dạng không
                        DateTime newDateValue;
                        if (DateTime.TryParseExact(newValue, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out newDateValue))
                        {
                            // Thay thế chỉ đoạn "dd/mm/yy" trong giá trị cụ thể
                            string updatedValue = ReplaceDatePlaceholder(currentCellValue, newDateValue);

                            // Cập nhật giá trị chỉ cho ô cụ thể mà người dùng đã double-click
                            cell.Value = updatedValue;
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng nhập định dạng ngày tháng dd/MM/yyyy.");
                        }
                    }
                }
            }
        }

        private string ReplaceDatePlaceholder(string originalValue, DateTime newDateValue)
        {
            string datePlaceholder = "dd/mm/yyyy";
            string formattedNewDate = newDateValue.ToString("dd/MM/yyyy");

            // Thay thế chỉ đoạn "dd/mm/yy" trong giá trị cụ thể
            int index = originalValue.IndexOf(datePlaceholder);
            if (index != -1)
            {
                string updatedValue = originalValue.Substring(0, index) + formattedNewDate + originalValue.Substring(index + datePlaceholder.Length);
                return updatedValue;
            }
            else
            {
                return originalValue;
            }
        }

        private string GetNewDateValue()
        {
            // Đây là nơi bạn có thể hiển thị một MessageBox hoặc một Form để nhập giá trị mới từ người dùng
            // Ví dụ đơn giản cho mục đích minh họa:
            return Microsoft.VisualBasic.Interaction.InputBox("Nhập giá trị mới:", "Sửa giá trị", "");
        }

    }

}