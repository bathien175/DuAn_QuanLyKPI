using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
using System.Data.SqlClient;

namespace DuAn_QuanLyKPI.GUI
{
    public partial class Frm_QuanLyNganHangKPI : DevExpress.XtraEditors.XtraForm, INotifyPropertyChanged
    {
        private string mconnectstring = Frm_A78.mconnectstring;
        private clsCommonMethod comm = new clsCommonMethod();
        private clsEventArgs ev = new clsEventArgs("");
        private string msql;
        private int _edit = 0;
        List<int> selectedItems = new List<int>();
        private int maKPI;
        private string message;
        private bool isCaNhanSelected = false;
        private bool isBenhVienSelected = false;
        private bool isTongHopSelected = false;
        

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public int Edit
        {
            get => _edit;
            set
            {
                _edit = value;
                OnPropertyChanged(nameof(Edit));
                switch (value)
                {
                    case 0:
                        splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel2;
                        break;
                    case 1:
                        splitContainerControl1.PanelVisibility = SplitPanelVisibility.Both;
                        break;
                    case 2:
                        splitContainerControl1.PanelVisibility = SplitPanelVisibility.Both;
                        break;
                }
            }
        }

        public Frm_QuanLyNganHangKPI()
        {
            InitializeComponent();
            ChoPhepNhap();
            LoadCbo();
            LoadDonViTinhComboBox();
            btnAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            txt_TenTieuChi.Visible = false;
        }
        private void LoadCbo()
        {
            DataTable dataTableTieuChi = new DataTable();
            using (SqlConnection connection = new SqlConnection(mconnectstring))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT TieuChiID, TenTieuChi FROM NhomTieuChi", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dataTableTieuChi.Load(reader);
                    }
                }

            } 
            dataTableTieuChi.DefaultView.Sort = "TieuChiID";
            dataTableTieuChi = dataTableTieuChi.DefaultView.ToTable();
            cbx_TieuChiID.DataSource = dataTableTieuChi;
            cbx_TieuChiID.ValueMember = "TieuChiID";
            cbx_TieuChiID.DisplayMember = "TenTieuChi";
            cbx_TieuChiID.SelectedIndexChanged += cbx_TieuChiID_SelectedIndexChanged;

        }
        private void LoadData()
        {
            msql = "SELECT * FROM [dbo].[KPI],[dbo].[NhomTieuChi] where KPI.TieuChiID = NhomTieuChi.TieuChiID";
            DataTable tb = comm.GetDataTable(mconnectstring, msql, "KPI");
            dtgv_QLNganHangKPI.AutoGenerateColumns = false;
            dtgv_QLNganHangKPI.DataSource = tb;
            
        }
        private void LoadData1()
        {
            msql = "SELECT * FROM [dbo].[KPI],[dbo].[NhomTieuChi] where KPI.TieuChiID = NhomTieuChi.TieuChiID and KPI.CongViecCaNhan = 1;";
            DataTable tb = comm.GetDataTable(mconnectstring, msql, "KPI");
            dtgv_QLNganHangKPI.AutoGenerateColumns = false;
            dtgv_QLNganHangKPI.DataSource = tb;

        }
        private void LoadData2()
        {
            msql = "SELECT * FROM [dbo].[KPI],[dbo].[NhomTieuChi] where KPI.TieuChiID = NhomTieuChi.TieuChiID and KPI.CongViecCaNhan = 0;";
            DataTable tb = comm.GetDataTable(mconnectstring, msql, "KPI");
            dtgv_QLNganHangKPI.AutoGenerateColumns = false;
            dtgv_QLNganHangKPI.DataSource = tb;

        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Edit = 0;
        }
        private void ShowGridPreview(GridControl grid)
        {
            // Check whether the GridControl can be previewed.
            if (!grid.IsPrintingAvailable)
            {
                MessageBox.Show("The 'DevExpress.XtraPrinting' library is not found", "Error");
                return;
            }

            // Open the Preview window.
            grid.ShowPrintPreview();
        }
        private void ChoPhepNhap()
        {
            txtNoiDung.Enabled = true;
            txtNoiDung.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            cbo_PhuongPhapDo.Enabled = true;
            cbo_ChiTieu.Enabled = true;
            cbo_DonViTinh.Enabled = true;
            cbx_TieuChiID.Enabled = true;

        }
        private void LamMoiThongTin()
        {
            txtNoiDung.Text = "";
            cbo_PhuongPhapDo.Text = "";
            cbo_DonViTinh.Text = "";
            cbo_ChiTieu.Text = "";
            cbo_PhuongPhapDo.Text = "";
            cbx_TieuChiID.Text = "";
        }
        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Edit = 1;
            ChoPhepNhap();
            LamMoiThongTin();

        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Edit = 2;
            LamMoiThongTin();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Edit == 1)
            //thì là trạng thái thêm
            {
                string noiDung = txtNoiDung.Text;
                string donViTinh = cbo_DonViTinh.Text;
                string phuongPhapDo = cbo_PhuongPhapDo.Text;
                bool congViecCaNhan = chkCongViecCaNhan.Checked;
                string chiTieu = cbo_ChiTieu.Text;
                //string tieuChiID = cbx_TieuChiID.SelectedValue;
                msql = $"INSERT INTO [dbo].[KPI] (NoiDung, DonViTinh, PhuongPhapDo, CongViecCaNhan, ChiTieu, TieuChiID) VALUES (N'{noiDung}', N'{donViTinh}', N'{phuongPhapDo}', {(congViecCaNhan ? 1 : 0)}, N'{chiTieu}', N'"+cbx_TieuChiID.SelectedValue+"')";
                comm.RunSQL(mconnectstring, msql);
                //LoadData();
                ev.QFrmThongBao("Đã lưu dữ liệu thành công !");
                if(isCaNhanSelected)
                {
                    LoadData1();
                }    
                else if (isBenhVienSelected)
                {
                    LoadData2();
                }
                else if (isTongHopSelected)
                {
                    LoadData();
                }


            }
            if (Edit == 2)
            //trạng thái sửa
            {
                bool result = ev.QFrmThongBao_YesNo("Bạn có chắc chắn muốn sửa ?");
                if (result == true)
                {
                    string noiDung = txtNoiDung.Text;
                    string donViTinh = cbo_DonViTinh.Text;
                    string phuongPhapDo = cbo_PhuongPhapDo.Text;
                    bool congViecCaNhan = chkCongViecCaNhan.Checked;
                    string chiTieu = cbo_ChiTieu.Text;
                    string tieuChiID = txt_TenTieuChi.Text; // Hoặc sử dụng SelectedValue tùy thuộc vào cách bạn set up ComboBox

                    // Thực hiện câu lệnh SQL UPDATE dựa trên giá trị của MaKPI
                    // Kiểm tra xem có hàng nào được chọn không             

                    string updateSql = $"UPDATE [dbo].[KPI] SET NoiDung = N'{noiDung}', DonViTinh = N'{donViTinh}', PhuongPhapDo = N'{phuongPhapDo}', CongViecCaNhan = '{congViecCaNhan}', ChiTieu = '{chiTieu}', TieuChiID = '{tieuChiID}' WHERE MaKPI = {maKPI}";

                    comm.RunSQL(mconnectstring, updateSql);

                    // Nạp lại dữ liệu vào DataGridView sau khi cập nhật
                    //LoadData();

                    // Optional: Hiển thị thông báo hoặc thực hiện các hành động khác sau khi cập nhật
                    ev.QFrmThongBao("Đã cập nhật dữ liệu thành công!");
                }
                if (isCaNhanSelected)
                {
                    LoadData1();
                }
                else if (isBenhVienSelected)
                {
                    LoadData2();
                }
                else if (isTongHopSelected)
                {
                    LoadData();
                }
            }
            Edit = 0;

        }

        private void btnCap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool result = ev.QFrmThongBao_YesNo("Bạn chắc chắn muốn qua nút cấp !!!");

            if (result == true)
            {
                // Người dùng đã chọn "Yes", thực hiện các hành động cần thiết, ví dụ: mở form mới
                Frm_CapDanhSachKPI form = new Frm_CapDanhSachKPI();
                form.ShowDialog();
            }
            else
            {
                // Người dùng đã chọn "No", có thể thực hiện các hành động khác tùy thuộc vào yêu cầu của bạn.
            }


        }
        
       
        //Xóa
        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bool result = ev.QFrmThongBao_YesNo("Bạn chắc chắn muốn xóa !!!");

                if (result)
                {
                    msql = "DELETE [dbo].[KPI] WHERE MaKPI ='" + maKPI + "'";
                    comm.RunSQL(mconnectstring, msql);
                    if (isCaNhanSelected)
                    {
                        LoadData1();
                    }
                    else if (isBenhVienSelected)
                    {
                        LoadData2();
                    }
                    else if (isTongHopSelected)
                    {
                        LoadData();
                    }
                    ev.QFrmThongBao("Bạn đã xóa thành công !");
                    
                    Edit = 0;
                }
            }
            catch (SqlException ex)
            {
                // Check if the exception is due to a foreign key constraint violation
                if (ex.Number == 547)
                {
                    ev.QFrmThongBao("Dữ liệu đang được sử dụng ở nơi khác, không thể xóa!");
                    Edit = 0;
                }
                else
                {
                    // Handle other SQL exceptions
                    ev.QFrmThongBao("Dữ liệu đang được sử dụng ở nơi khác, không thể xóa ");
                    Edit = 0;
                }
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                ev.QFrmThongBao("Dữ liệu đang được sử dụng ở nơi khác, không thể xóa ");
                Edit = 0;
            }
        }


        private void cbx_TieuChiID_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu giá trị được chọn là một DataRowView
            if (cbx_TieuChiID.SelectedItem is DataRowView selectedRow)
            {
                // Lấy giá trị từ DataRowView
                string tieuchiId = selectedRow["TieuChiID"].ToString();

                // Đặt giá trị vào TextBox
                txt_TenTieuChi.Text = tieuchiId;
            }
            else
            {
                // Nếu không phải là DataRowView, đặt TextBox thành chuỗi trống
                txt_TenTieuChi.Text = string.Empty;
            }
        }

        
        //Lấy dữ liệu từ gridview đổ lên các textbox
        private void dtgv_QLNganHangKPI_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            Edit = 2;
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Lấy thông tin từ ô được chọn
                DataGridViewRow selectedRow = dtgv_QLNganHangKPI.Rows[e.RowIndex];
                string noiDung = selectedRow.Cells["clNoiDung"].Value.ToString();
                string donViTinh = selectedRow.Cells["clDonViTinh"].Value.ToString();
                string phuongPhapDo = selectedRow.Cells["clPhuongPhapDo"].Value.ToString();
                string congViecCaNhanStr = selectedRow.Cells["clCongViecCaNhan"].Value.ToString();
                bool congViecCaNhan;
                if (bool.TryParse(congViecCaNhanStr, out congViecCaNhan))
                {
                    // Đặt giá trị bool vào CheckBox
                    chkCongViecCaNhan.Checked = congViecCaNhan;
                }
                string chiTieu = selectedRow.Cells["clChiTieu"].Value.ToString();
                string tieuChiID = selectedRow.Cells["cTieuChiID"].Value.ToString();
                string tenTieuChi = selectedRow.Cells["cTenTieuChi"].Value.ToString();

                // Lấy giá trị maKPI từ cell clMaKPI
                if (int.TryParse(selectedRow.Cells["clMaKPI"].Value.ToString(), out maKPI))
                {
                    // Lấy thông tin từ các ô cột khác nếu cần
                    txtNoiDung.Text = noiDung;
                    cbo_DonViTinh.Text = donViTinh;
                    cbo_PhuongPhapDo.Text = phuongPhapDo;
                    cbo_ChiTieu.Text = chiTieu;
                    //cbx_TieuChiID.Text = tieuChiID;
                    //txt_TenTieuChi.Text = tenTieuChi;
                    cbx_TieuChiID.Text = tenTieuChi;
                    txt_TenTieuChi.Text = tieuChiID;

                    // Hiển thị thông tin hoặc thực hiện hành động dựa trên dữ liệu của hàng được chọn

                }
                else
                {
                    // Xử lý trường hợp không thể chuyển đổi maKPI sang kiểu int
                    ev.QFrmThongBaoError("Lỗi khi lấy giá trị MaKPI từ cell clMaKPI");
                }
            }
        }
       
        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void cbo_DonViTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            //// Lấy giá trị được chọn từ ComboBox
            //string selectedUnit = cbo_DonViTinh.SelectedItem.ToString();

            //// Hiển thị nội dung tương ứng trong ComboBox khác
            //switch (selectedUnit)
            //{
            //    case "Ngày":
            //        cbo_ChiTieu.Items.Clear();
            //        cbo_PhuongPhapDo.Items.Clear();
            //        cbo_ChiTieu.Items.Add("X");
            //        cbo_ChiTieu.Items.Add("dd/mm/yyyy");
            //        cbo_PhuongPhapDo.Items.Add("KQ <= X : KPI = 100 % KQ > X : KPI = 0 % ");
            //        cbo_PhuongPhapDo.Items.Add("KQ < dd/mm/yyyy: KPI = 100% KQ >= dd/mm/yyyy: KPI = 0%");
            //        cbo_PhuongPhapDo.Items.Add("KQ <= ngày X: KPI = 100% KQ > ngày X: KPI = 0%");
            //        break;
            //    case "thời gian":
            //        cbo_ChiTieu.Items.Clear();
            //        cbo_PhuongPhapDo.Items.Clear();
            //        cbo_ChiTieu.Items.Add("DD/MM/YY");
            //        cbo_ChiTieu.Items.Add("X%");
            //        cbo_ChiTieu.Items.Add("X");
            //        cbo_ChiTieu.Items.Add("dd/mm/yyyy");
            //        cbo_ChiTieu.Items.Add("24");
            //        cbo_PhuongPhapDo.Items.Add("KQ < dd/mm/yyyy: KPI = 100% KQ >= dd/mm/yyyy: KPI = 0%");
            //        cbo_PhuongPhapDo.Items.Add("KQ <= 24: KPI = 100% KQ > 24: KPI = 0%");
            //        cbo_PhuongPhapDo.Items.Add("KQ <= X% : KPI = 100% KQ >X% : KPI = 0%");
            //        cbo_PhuongPhapDo.Items.Add("KQ< DD/MM/YY: 100% KPI  KQ>= DD/MM/YY: 0% KPI");
            //        cbo_PhuongPhapDo.Items.Add("KQ >= X : KPI = 100% KQ <X : KPI = 0%");
            //        cbo_PhuongPhapDo.Items.Add("KQ <= X : KPI = 100%  KQ > X : KPI = 0%");
            //        break;
            //    case "Số lần":
            //        cbo_ChiTieu.Items.Clear();
            //        cbo_PhuongPhapDo.Items.Clear();
            //        cbo_ChiTieu.Items.Add("0");
            //        cbo_ChiTieu.Items.Add("X");
            //        cbo_ChiTieu.Items.Add("1");
            //        cbo_ChiTieu.Items.Add("12");
            //        cbo_ChiTieu.Items.Add("4");
            //        cbo_ChiTieu.Items.Add("100%");
            //        cbo_ChiTieu.Items.Add("0%");
            //        cbo_PhuongPhapDo.Items.Add("KQ = 0: KPI = 100% KQ >= 1: KPI = 0%");
            //        cbo_PhuongPhapDo.Items.Add("KQ <= X: KPI = 100% KQ > X: KPI = 0%");
            //        cbo_PhuongPhapDo.Items.Add("KQ => 1: KPI = 100% KQ < 1: KPI = 0%");
            //        cbo_PhuongPhapDo.Items.Add("KQ >= 12: KPI = 100% KQ < 12: KPI = 0%");
            //        cbo_PhuongPhapDo.Items.Add("KQ >= 4: KPI = 100% KQ < 4: KPI = 0%");                 
            //        break;
            //     case "Số lượng":
            //        cbo_ChiTieu.Items.Clear();
            //        cbo_PhuongPhapDo.Items.Clear();
            //        cbo_ChiTieu.Items.Add("X");
            //        cbo_ChiTieu.Items.Add("3");
            //        cbo_PhuongPhapDo.Items.Add("KQ >= X: KPI = 100% KQ < X: KPI = 0%");
            //        cbo_PhuongPhapDo.Items.Add("KQ <= X : KPI = 100% KQ > X : KPI = 0%");
            //        cbo_PhuongPhapDo.Items.Add("KQ >= X: 100% KPI  KQ< X: 0% KPI");
            //        cbo_PhuongPhapDo.Items.Add("KQ > X: KPI = 100% KQ < = X: KPI = 0%");
            //        cbo_PhuongPhapDo.Items.Add("KQ >= 3: KPI = 100% KQ < 3: KPI = 0%");
            //        break;
            //    case "Buổi":
            //        cbo_ChiTieu.Items.Clear();
            //        cbo_PhuongPhapDo.Items.Clear();
            //        cbo_ChiTieu.Items.Add("X");
            //        cbo_PhuongPhapDo.Items.Add("KQ >= X: KPI = 100% KQ < X: KPI = 0%");
            //        break;
            //    case "%":
            //        cbo_ChiTieu.Items.Clear();
            //        cbo_PhuongPhapDo.Items.Clear();
            //        cbo_ChiTieu.Items.Add("100%");
            //        cbo_PhuongPhapDo.Items.Add("KQ = 100%: KPI = 100% KQ < 100%: KPI = 0%");
            //        break;
            //    case "Phút":
            //        cbo_ChiTieu.Items.Clear();
            //        cbo_PhuongPhapDo.Items.Clear();
            //        cbo_ChiTieu.Items.Add("X");
            //        cbo_PhuongPhapDo.Items.Add("KQ <= X: KPI = 100% KQ > X: KPI = 0%");
            //        cbo_PhuongPhapDo.Items.Add("KQ <= X phút: KPI = 100% KQ > X phút: KPI = 0%");
            //        break;
            //    case "Kỳ thi":
            //        //cbo_ChiTieu.Items.Clear();
            //        //cbo_PhuongPhapDo.Items.Clear();
            //        cbo_ChiTieu.Items.Add("X");
            //        cbo_PhuongPhapDo.Items.Add("KQ >= X: KPI = 100 % KQ < X: KPI = 0 %");
            //        break;
            //    case "Giờ":
            //        cbo_ChiTieu.Items.Clear();
            //        cbo_PhuongPhapDo.Items.Clear();
            //        cbo_ChiTieu.Items.Add("X");
            //        cbo_ChiTieu.Items.Add("24");
            //        cbo_PhuongPhapDo.Items.Add("KQ <= 24: KPI = 100% KQ > 24: KPI = 0%");
            //        cbo_PhuongPhapDo.Items.Add("KQ <= X giờ: KPI = 100% KQ > X giờ: KPI = 0%");
            //        cbo_PhuongPhapDo.Items.Add("KQ >= X: KPI = 100% KQ < X: KPI = 0%");
            //        cbo_PhuongPhapDo.Items.Add("KQ <  X: KPI = 100%  KQ >= X: KPI = 0%");
            //        break;
            //    case "Lần":
            //    // Thêm các trường hợp khác nếu cần
            //    default:
            //        cbo_ChiTieu.Items.Clear();
            //        cbo_PhuongPhapDo.Items.Clear();
            //        break;
            //}
        }
        private void LoadDonViTinhComboBox()
        {
            using (SqlConnection connection = new SqlConnection(mconnectstring))
            {
                connection.Open();
                string query = "SELECT DISTINCT DonViTinh FROM KPI";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<string> donViTinhs = new List<string>();
                        while (reader.Read())
                        {
                            donViTinhs.Add(reader["DonViTinh"].ToString());
                        }
                        cbo_DonViTinh.DataSource = donViTinhs;
                    }
                }
            }
        }
        private bool isPercentAdded = true;

        private void cboDonViTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadChitieuComboBox();
            
        }

        private void LoadChitieuComboBox()
        {
            string selectedDonViTinh = cbo_DonViTinh.Text;
            using (SqlConnection connection = new SqlConnection(mconnectstring))
            {
                connection.Open();
                string query = $"SELECT DISTINCT ChiTieu FROM KPI WHERE DonViTinh = N'{selectedDonViTinh}'";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<string> chitieus = new List<string>(); // Sử dụng List<string> thay vì List<DateTime>
                        while (reader.Read())
                        {
                            chitieus.Add(reader["ChiTieu"].ToString()); // Đọc dữ liệu kiểu string
                        }
                        cbo_ChiTieu.DataSource = chitieus;
                    }
                }
            }
        }

        private void cbo_ChiTieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPhuongPhapDoComboBox();
        }

        private void LoadPhuongPhapDoComboBox()
        {
            string selectedDonViTinh = cbo_DonViTinh.Text;
            string selectedChitieu = cbo_ChiTieu.Text;
            using (SqlConnection connection = new SqlConnection(mconnectstring))
            {
                connection.Open();
                string query = $"SELECT DISTINCT PhuongPhapDo FROM KPI WHERE DonViTinh = N'{selectedDonViTinh}' AND ChiTieu = N'{selectedChitieu}'";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<string> phuongPhapDos = new List<string>();
                        while (reader.Read())
                        {
                            phuongPhapDos.Add(reader["PhuongPhapDo"].ToString());
                        }
                        cbo_PhuongPhapDo.DataSource = phuongPhapDos;
                    }
                }
            }
        }

        //private void cbo_PhuongPhapDo_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    LoadDataGrid();
        //}

        //private void LoadDataGrid()
        //{
        //    string selectedDonViTinh = cbo_DonViTinh.Text;
        //    string selectedChitieu = cbo_ChiTieu.Text;
        //    string selectedPhuongPhapDo = cbo_PhuongPhapDo.Text;

        //    using (SqlConnection connection = new SqlConnection(mconnectstring))
        //    {
        //        connection.Open();
        //        string query = $"SELECT * FROM KPI WHERE DonViTinh = '{selectedDonViTinh}' AND ChiTieu = '{selectedChitieu}' AND PhuongPhapDo = '{selectedPhuongPhapDo}'";
        //        using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
        //        {
        //            DataTable dataTable = new DataTable();
        //            adapter.Fill(dataTable);
        //            dtgv_QLNganHangKPI.DataSource = dataTable;
        //        }
        //    }
        //}
    
    private void dtgv_QLNganHangKPI_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            ev.Qdgr_RowPostPaint(sender, e, dtgv_QLNganHangKPI);
        }


        private void btn_TongHop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            isCaNhanSelected = false;
            isBenhVienSelected = false;
            isTongHopSelected = true;
            Edit = 0;
            LoadData();
            SetButtonVisibility(DevExpress.XtraBars.BarItemVisibility.Never);
        }

        private void btn_CaNhan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            isCaNhanSelected = true;
            isBenhVienSelected = false;
            isTongHopSelected = false;
            Edit = 0;
            LoadData1();
           
            SetButtonVisibility(DevExpress.XtraBars.BarItemVisibility.Always);
            chkCongViecCaNhan.Checked = true;
        }

        private void btn_BenhVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            isCaNhanSelected = false;
            isBenhVienSelected = true;
            isTongHopSelected = false;
            Edit = 0;
            LoadData2();
            SetButtonVisibility(DevExpress.XtraBars.BarItemVisibility.Never);
            chkCongViecCaNhan.Checked = false;
        }

        // Hàm này để thiết lập sự hiển thị của các nút
        private void SetButtonVisibility(DevExpress.XtraBars.BarItemVisibility visibility)
        {
            btnAdd.Visibility = visibility;
            btnEdit.Visibility = visibility;
            btnCancel.Visibility = visibility;
            btnSave.Visibility = visibility;
        }

       
        private void UpdatePercentIfNeeded()
        {
            if (cbo_DonViTinh.SelectedItem != null && cbo_DonViTinh.SelectedItem.ToString() == " %")
            {
                if (!isPercentAdded)
                {
                    cbo_ChiTieu.Text += "%";
                    isPercentAdded = true;
                }
            }
            else
            {
                cbo_ChiTieu.Text = cbo_ChiTieu.Text.TrimEnd('%');
                isPercentAdded = false;
            }
        }

        private void cbo_ChiTieu_Leave(object sender, EventArgs e)
        {
            UpdatePercentIfNeeded();
        }
    }

}
