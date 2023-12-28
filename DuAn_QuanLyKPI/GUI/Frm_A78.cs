using BusinessCommon;
using DevExpress.Utils.Html.Internal;
using DevExpress.XtraEditors;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using static DevExpress.XtraPrinting.Native.ExportOptionsPropertiesNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using DevExpress.XtraExport.Helpers;
using DocumentFormat.OpenXml.Spreadsheet;
using DevExpress.CodeParser;
using System.Reflection.Emit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using DevExpress.Data.Linq.Helpers;
using DevExpress.XtraPrinting.Native;
using static DevExpress.Xpo.Helpers.AssociatedCollectionCriteriaHelper;


namespace DuAn_QuanLyKPI.GUI
{
    public partial class Frm_A78 : DevExpress.XtraEditors.XtraForm
    {
        private static string mconnectstring = Database.mconnectstring;
        private clsCommonMethod comm = new clsCommonMethod();
        private clsEventArgs ev = new clsEventArgs("");
        private string msql;
        private string maphieukpikp;
        private string QuyNam;
        string TenNV;
        string TenChucDanh;
        string TenPhongKhoa;
        string MaNV = Frm_Login.MaNV;
        string MaChucDanh;
        string MaPhongKhoa;

        Timer Time1;

        public Frm_A78()
        {
            InitializeComponent();
            LoadThongTinNhanVien();
            LoadDGVtab1();

            Time1 = new Timer { Interval = 100 };
            Time1.Tick += UpdateTimer_Tick;
        }
        private void LoadThongTinNhanVien()
        {
            msql = "SELECT * FROM dbo.ChucDanh cd " +
                "INNER JOIN dbo.NguoiDung nd ON cd.MaChucDanh = nd.MaChucDanh " +
                "INNER JOIN dbo.PhongKhoa pk ON nd.MaPhongKhoa = pk.MaPK " +
                "where nd.MaNV = '"+ Frm_Login.MaNV + "'";
            DataTable dt = comm.GetDataTable(mconnectstring, msql, "NguoiDung");

            TenNV = dt.Rows[0]["TenNV"].ToString();
            TenChucDanh = dt.Rows[0]["TenChucDanh"].ToString();
            TenPhongKhoa = dt.Rows[0]["TenPK"].ToString();
            MaChucDanh = dt.Rows[0]["MaChucDanh"].ToString();
            MaPhongKhoa = dt.Rows[0]["MaPhongKhoa"].ToString();

            txtTenNV.Text = TenNV;
            txtTenNV4.Text = TenNV;

            txtViTriCV.Text = TenChucDanh;
            txtViTriCV4.Text = TenChucDanh;

            txtKhoaPhong.Text = TenPhongKhoa;
            txtKhoaPhong4.Text = TenPhongKhoa;

            DateTime currentDate = DateTime.Now;
            int result = (currentDate.Month - 1) / 3 + 1;
            label3.Text = "QUÝ " + result + "";
            label5.Text = "QUÝ " + result + "";
        }
        #region Tab1
        private void LoadDGVtab1()
        {
            QuyNam = $"{(DateTime.Now.Month - 1) / 3 + 1}{DateTime.Now.Year}";

            msql = "SELECT * FROM KPI_KhoaPhong " +
                "where MaPK = '"+ Frm_Login.MaPK +"' " +
                "and IDBieuMau = '78' " +
                "and QuyNam = '" + QuyNam + "'";
            DataTable dtt = comm.GetDataTable(mconnectstring, msql, "KPI");
            maphieukpikp = dtt.Rows[0]["MaPhieuKPIKP"].ToString();

            msql = "SELECT A.MaKPI, B.NoiDung, B.PhuongPhapDo, B.DonViTinh, A.TrongSoKPIKP, E.TenPK " +
                "FROM ChiTietTieuChiMucTieuKhoaPhong as A, KPI as B, KPITrongNganHang as C, NganHangKPI as D, PhongKhoa as E " +
                "where A.MaKPI = B.MaKPI " +
                "and C.MaKPI = B.MaKPI " +
                "and D.MaNganHangKPI = C.MaNganHangKPI " +
                "and E.MaPK = D.MaPK " +
                "and A.MaPhieuKPIKP = '" + maphieukpikp + "' " +
                "and B.CongViecCaNhan = 'true' " +
                "and D.MaPK = '"+ MaPhongKhoa +"' " +
                "and (D.MaChucDanh like 'PTP%' or D.MaChucDanh like 'PTK%') " +
                "order by A.MaKPI";
            DataTable dt = comm.GetDataTable(mconnectstring, msql, "KPI");
            dgvKPICN_MTBB.DataSource = dt;

            dgvKPICN_MTBB.CurrentCellDirtyStateChanged += Dgv1_CurrentCellDirtyStateChanged;
            dgvKPICN_MTBB.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        private int SumTrongSotab1()
        {
            int sum = 0;
            for (int i = 0; i < dgvKPICN_MTBB2.Rows.Count; i++)
            {
                if (dgvKPICN_MTBB2.Rows[i].Cells["TSHT2_MTBB"].Value != null)
                {
                    string value = dgvKPICN_MTBB2.Rows[i].Cells["TSHT2_MTBB"].Value.ToString();
                    int number;
                    if (int.TryParse(value, out number))
                    {
                        sum += number;
                    }
                    else
                    {
                        ev.QFrmThongBao("Lỗi trọng số ở dòng thứ " + (i + 1));
                    }
                }
            }
            return sum;
        }
        private void btnTiepTucTaiChinh_Click(object sender, EventArgs e)
        {

            if (SumTrongSotab1() == 0)
            {
                ev.QFrmThongBao("Vui lòng nhập đầy đủ !");
                return;
            }
            else if (SumTrongSotab1() < 100)
            {
                ev.QFrmThongBao("Trọng số bé hơn 100% !");
            }
            else if (SumTrongSotab1() > 100)
            {
                ev.QFrmThongBao("Trọng số lớn hơn 100% !");
            }
            tabMucTieuKhoaPhong.SelectTab(2);

            if(cbQTUX.Checked == true)
                txtQTUXHT.Text = txtQTUX.Text;
            copyDataCN2toHT();
        }
        private void btnDangKiThem_Click(object sender, EventArgs e)
        {
            tabMucTieuKhoaPhong.SelectTab(1);
            LoadDGVtab2();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtQTUX.Enabled = cbQTUX.Checked;
        }
        private void copyDataCNtoCN2()
        {
            dgvKPICN_MTBB2.Rows.Clear();
            for (int i = 0; i < dgvKPICN_MTBB.Rows.Count; i++)
            {
                if (dgvKPICN_MTBB.Rows[i].Cells["Chon_MTBB"].Value != null && dgvKPICN_MTBB.Rows[i].Cells["Chon_MTBB"].Value.ToString() == "true")
                {
                    int n = dgvKPICN_MTBB2.Rows.Add();
                    dgvKPICN_MTBB2.Rows[n].Cells["ND2_MTBB"].Value = dgvKPICN_MTBB.Rows[i].Cells["ND_MTBB"].Value.ToString();
                    dgvKPICN_MTBB2.Rows[n].Cells["TSMT2_MTBB"].Value = dgvKPICN_MTBB.Rows[i].Cells["TSMT_MTBB"].Value.ToString();
                    dgvKPICN_MTBB2.Rows[n].Cells["MaKPI2_MTBB"].Value = dgvKPICN_MTBB.Rows[i].Cells["MaKPI_MTBB"].Value.ToString();
                    dgvKPICN_MTBB2.Rows[n].Cells["PPD2_MTBB"].Value = dgvKPICN_MTBB.Rows[i].Cells["PPD_MTBB"].Value.ToString();
                    dgvKPICN_MTBB2.Rows[n].Cells["DVT2_MTBB"].Value = dgvKPICN_MTBB.Rows[i].Cells["DVT_MTBB"].Value.ToString();
                    dgvKPICN_MTBB2.Rows[n].Cells["NCM2_MTBB"].Value = dgvKPICN_MTBB.Rows[i].Cells["NCM_MTBB"].Value.ToString();
                    //dgvKPICN_MTBB2.Rows[n].Cells["KH2_MTBB"].Value = dgvKPICN_MTBB.Rows[i].Cells["KH_MTBB"].Value.ToString();
                    //dgvKPICN_MTBB2.Rows[n].Cells["TH2_MTBB"].Value = dgvKPICN_MTBB.Rows[i].Cells["TH_MTBB"].Value.ToString();
                }
            }
        }
        private void copyDataCN2toHT()
        {
            dgvKPICN_HTMTBB.Rows.Clear();

            for (int i = 0; i < dgvKPICN_MTBB2.Rows.Count; i++)
            {
                int n = dgvKPICN_HTMTBB.Rows.Add();
                dgvKPICN_HTMTBB.Rows[n].Cells["MaKPI_HTMTBB"].Value = dgvKPICN_MTBB2.Rows[i].Cells["MaKPI2_MTBB"].Value.ToString();
                dgvKPICN_HTMTBB.Rows[n].Cells["ND_HTMTBB"].Value = dgvKPICN_MTBB2.Rows[i].Cells["ND2_MTBB"].Value.ToString();
                dgvKPICN_HTMTBB.Rows[n].Cells["TSHT_HTMTBB"].Value = dgvKPICN_MTBB2.Rows[i].Cells["TSHT2_MTBB"].Value.ToString();
                dgvKPICN_HTMTBB.Rows[n].Cells["PPD_HTMTBB"].Value = dgvKPICN_MTBB2.Rows[i].Cells["PPD2_MTBB"].Value.ToString();
                dgvKPICN_HTMTBB.Rows[n].Cells["DVT_HTMTBB"].Value = dgvKPICN_MTBB2.Rows[i].Cells["DVT2_MTBB"].Value.ToString();
                dgvKPICN_HTMTBB.Rows[n].Cells["NCM_HTMTBB"].Value = dgvKPICN_MTBB2.Rows[i].Cells["NCM2_MTBB"].Value.ToString();
                dgvKPICN_HTMTBB.Rows[n].Cells["KH_HTMTBB"].Value = "100%";
                dgvKPICN_HTMTBB.Rows[n].Cells["TH_HTMTBB"].Value = (Math.Round((float.Parse(dgvKPICN_MTBB2.Rows[i].Cells["TSHT2_MTBB"].Value.ToString())/ float.Parse(dgvKPICN_MTBB2.Rows[i].Cells["TSMT2_MTBB"].Value.ToString()) * 100),0) + "%").ToString();
            }
        }
        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            copyDataCNtoCN2();
        }
        private void Dgv1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dgvKPICN_MTBB.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        private void dgvCN_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                dgvKPICN_MTBB2.Rows.Clear();
                for (int i = 0; i < dgvKPICN_MTBB.Rows.Count; i++)
                {
                    dgvKPICN_MTBB.Rows[i].Cells["Chon_MTBB"].Value = "true";
                }
                copyDataCNtoCN2();
            }
        }
        private void dgvCN_MouseLeave(object sender, EventArgs e)
        {
            Time1.Stop();
        }
        private void dgvCN_MouseClick(object sender, MouseEventArgs e)
        {
            Time1.Start();
        }
        private void dgvCN_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Time1.Stop();
        }
        private void dgvCN2_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                dgvKPICN_MTBB2.Rows.Clear();
                for (int i = 0; i < dgvKPICN_MTBB.Rows.Count; i++)
                {
                    dgvKPICN_MTBB.Rows[i].Cells["Chon_MTBB"].Value = false;
                }
                copyDataCNtoCN2();
            }
        }
        private void dgvCN2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvKPICN_MTBB2.Rows.Count && e.ColumnIndex == 0)
            {
                foreach (DataGridViewRow row in dgvKPICN_MTBB.Rows)
                {
                    if (dgvKPICN_MTBB2.Rows[e.RowIndex].Cells["MaKPI2_MTBB"].Value.ToString() == row.Cells["MaKPI_MTBB"].Value.ToString())
                    {
                        row.Cells["Chon_MTBB"].Value = false;
                        break;
                    }
                }
                copyDataCNtoCN2();
            }
        }
        private void dgvCN2_MouseHover(object sender, EventArgs e)
        {
            Time1.Stop();
        }
        private void dgvCN2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            txtTongTrongSoCaNhan.Text = Convert.ToString(SumTrongSotab1());
        }
        #endregion
        #region Tab2
        private void LoadDGVtab2()
        {
            msql = "SELECT a.MaKPI_DKT, b.NoiDung, a.TrongSoKPIDK, b.DonViTinh, b.PhuongPhapDo, e.TenPK " +
                "FROM ChiTietDangKiThem_KPICaNhan a " +
                "inner join KPI b on a.MaKPI = b.MaKPI " +
                "inner join KPITrongNganHang c on c.MaKPI = b.MaKPI " +
                "inner join NganHangKPI d on d.MaNganHangKPI = c.MaNganHangKPI " +
                "inner join PhongKhoa e on d.MaPK = e.MaPK " +
                "WHERE a.MaKPI IS NOT NULL " +
                "and e.MaPK = '" + MaPhongKhoa + "' " +
                "and a.MaNV = '"+ MaNV +"' " +
                "and a.QuyNam = '"+ QuyNam +"'" +
                "and (d.MaChucDanh like 'PTP%' or d.MaChucDanh like 'PTK%')";
            DataTable dtA = comm.GetDataTable(mconnectstring, msql, "DangKiMuctieuThem1");

            msql = "SELECT MaKPI_DKT, NoiDung, TrongSoKPIDK, DonViTinh, PhuongPhapDo, c.TenPK " +
                "FROM ChiTietDangKiThem_KPICaNhan a " +
                "inner join NguoiDung b on a.MaNV = b.MaNV " +
                "inner join PhongKhoa c on b.MaPhongKhoa = c.MaPK " +
                "WHERE MaKPI IS NULL " +
                "and a.MaNV = '"+ MaNV +"' " +
                "and a.QuyNam = '" + QuyNam + "'";
            DataTable dtB = comm.GetDataTable(mconnectstring, msql, "DangKiMuctieuThem2");

            DataTable MTT = new DataTable();
            MTT = dtA.Copy();
            MTT.Merge(dtB);

            if(MTT.Rows.Count > 0 ) 
            {
                dgvKPICN_MTT.DataSource = MTT;
            }
            else
            {
                ev.QFrmThongBao("Không có mục tiêu thêm !");
                tabMucTieuKhoaPhong.SelectTab(2);
            }

        }
        private int SumTrongSotab2()
        {
            int sum = 0;
            for (int i = 0; i < dgvKPICN_MTT.Rows.Count; i++)
            {
                if (dgvKPICN_MTT.Rows[i].Cells["TSHT_MTT"].Value != null && dgvKPICN_MTT.Rows[i].Cells["TSHT_MTT"].Value.ToString() != "")
                {
                    string value = dgvKPICN_MTT.Rows[i].Cells["TSHT_MTT"].Value.ToString();
                    int number;
                    if (int.TryParse(value, out number))
                    {
                        sum += number;
                    }
                    else
                        ev.QFrmThongBao("Lỗi trọng số ở dòng thứ  " + (i + 1) + "");
                }
            }
            return sum;
        }
        private void copyDataDKMTTtoHT()
        {
            dgvKPICN_HTMTT.Rows.Clear();
            for (int i = 0; i < dgvKPICN_MTT.Rows.Count; i++)
            {
                int n = dgvKPICN_HTMTT.Rows.Add();
                dgvKPICN_HTMTT.Rows[n].Cells["MaKPI_HTMTT"].Value = dgvKPICN_MTT.Rows[i].Cells["MaKPI_MTT"].Value.ToString();
                dgvKPICN_HTMTT.Rows[n].Cells["ND_HTMTT"].Value = dgvKPICN_MTT.Rows[i].Cells["ND_MTT"].Value.ToString();
                dgvKPICN_HTMTT.Rows[n].Cells["TSHT_HTMTT"].Value = dgvKPICN_MTT.Rows[i].Cells["TSHT_MTT"].Value.ToString();
                dgvKPICN_HTMTT.Rows[n].Cells["PPD_HTMTT"].Value = dgvKPICN_MTT.Rows[i].Cells["PPD_MTT"].Value.ToString();
                dgvKPICN_HTMTT.Rows[n].Cells["DVT_HTMTT"].Value = dgvKPICN_MTT.Rows[i].Cells["DVT_MTT"].Value.ToString();
                dgvKPICN_HTMTT.Rows[n].Cells["NCM_HTMTT"].Value = dgvKPICN_MTT.Rows[i].Cells["NCM_MTT"].Value.ToString();
                dgvKPICN_HTMTT.Rows[n].Cells["KH_HTMTT"].Value = "100%";
                dgvKPICN_HTMTT.Rows[n].Cells["TH_HTMTT"].Value = (Math.Round((float.Parse(dgvKPICN_MTT.Rows[i].Cells["TSHT_MTT"].Value.ToString()) / float.Parse(dgvKPICN_MTT.Rows[i].Cells["TSMT_MTT"].Value.ToString()) * 100 ),0) + "%").ToString();
            }
        }
        private void btnTTpnDKTPK_Click(object sender, EventArgs e)
        {
            if (SumTrongSotab2() == 0)
            {
                ev.QFrmThongBao("Vui lòng nhập đầy đủ !");
                return;
            }
            else if (SumTrongSotab2() < 100)
            {
                ev.QFrmThongBao("Trọng số bé hơn 100% !");
            }
            else if (SumTrongSotab2() > 100)
            {
                ev.QFrmThongBao("Trọng số lớn hơn 100% !");
            }
            tabMucTieuKhoaPhong.SelectTab(2);
            if (cbQTUX.Checked == true)
                txtQTUXHT.Text = txtQTUX.Text;
            copyDataCN2toHT();
            copyDataDKMTTtoHT();
        }
        private void dgvDKMTT_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            txtTongTrongSoMucTieuThem.Text = SumTrongSotab2().ToString();
        }
        private void btnQLtabDKMTT_Click(object sender, EventArgs e)
        {
            tabMucTieuKhoaPhong.SelectTab(0);
        }
        #endregion
        #region Tab3
        private void btnQuayLaiHoanThanh_Click(object sender, EventArgs e)
        {
            tabMucTieuKhoaPhong.SelectTab(0);
        }
        private void btnHoanThanh_Click(object sender, EventArgs e)
        {
            string MaPhieuKPICN = "KPICN"+ DateTime.Now.ToString("yyyyMMddHHmmss") +"";
            msql = "INSERT INTO [dbo].[KPI_CaNhan] " +
                "([MaPhieuKPICN],[MaPhieuKPIKP],[QuyTacUngXu],[TrongSoQuyTacUngXu],[IDBieuMau],[MaNV],[QuyNam],[NgayLapPhieuKPICN]) " +
                "VALUES " +
                "('"+ MaPhieuKPICN + "','" + maphieukpikp + "','"+ txtQTUXHT.Text +"','10','78','"+ Frm_Login.MaNV +"','"+ QuyNam +"', GETDATE())";
            comm.RunSQL(mconnectstring, msql);

            //KPI cá nhân bắt buộc
            for (int i = 0; i < dgvKPICN_HTMTBB.Rows.Count; i++)
            {
                string makpi = dgvKPICN_HTMTBB.Rows[i].Cells["MaKPI_HTMTBB"].Value.ToString();
                string trongsoHT = dgvKPICN_HTMTBB.Rows[i].Cells["TSHT_HTMTBB"].Value.ToString();

                msql = "INSERT INTO [dbo].[ChiTietKPICaNhan] " +
                    "([MaPhieuKPICN],[MaKPI],[TrongSoKPICN],[KPICaNhanDangKyThem],[NguonChungMinh]) " +
                    "VALUES " +
                    "('" + MaPhieuKPICN + "','" + makpi + "','" + trongsoHT + "','0','" + Frm_Login.MaPK + "')";
                comm.RunSQL(mconnectstring, msql);
            }

            //KPI cá nhân đăng kí thêm
            for (int i = 0; i < dgvKPICN_HTMTT.Rows.Count; i++)
            {
                string makpi = dgvKPICN_HTMTT.Rows[i].Cells["MaKPI_HTMTT"].Value.ToString();
                string trongsoHT = dgvKPICN_HTMTT.Rows[i].Cells["TSHT_HTMTT"].Value.ToString();

                msql = "INSERT INTO [dbo].[ChiTietKPICaNhan] " +
                    "([MaPhieuKPICN],[MaKPI_DKT],[TrongSoKPICN],[KPICaNhanDangKyThem],[NguonChungMinh]) " +
                    "VALUES " +
                    "('" + MaPhieuKPICN + "','" + makpi + "','" + trongsoHT + "','1','" + Frm_Login.MaPK + "')";
                comm.RunSQL(mconnectstring, msql);
            }

            ev.QFrmThongBao("Chúc mừng bạn đã hoàn thành KPI Cá nhân !");
        }
        private void btnExel_Click(object sender, EventArgs e)
        {

            if (ev.QFrmThongBao_YesNo("Bạn có chắc muốn tiếp tục không? Hãy kiểm tra thật kĩ thông tin trước khi Hoàn thành nhé!"))
            {
                //đường dẫn đến file excel sẵn có
                string existingFilePath = Path.Combine("D:\\ThucTap\\Projects\\DuAn_QuanLyKPI\\DuAn_QuanLyKPI\\DuAn_QuanLyKPI\\DuAn_QuanLyKPI\\bin\\Debug", "A78.xlsx");
                AddDataGridViewsToExistingExcelSheet(dgvKPICN_HTMTBB, dgvKPICN_HTMTT, existingFilePath);
            }
        }

        private void AddDataGridViewsToExistingExcelSheet(DataGridView dgvKPICN_MTBB, DataGridView dgvKPICN_MTT, string existingFilePath)
        {
            DateTime currentDate = DateTime.Now;
            // Mở một file Excel đã có sẵn
            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = true;
            Excel.Workbook workbook = excelApp.Workbooks.Open(existingFilePath);
            //mở sheets
            Excel.Worksheet worksheet = workbook.Sheets["A7.8"];

            if (worksheet == null)
            {
                ev.QFrmThongBaoError("Không tìm thấy worksheet có tên A7.8 trong file Excel.");
                workbook.Close();
                excelApp.Quit();
                return;
            }

            //đổ dữ liệu vào file excel
            worksheet.Cells[2, 3] = "KPI CÁ NHÂN - QUÝ "+ ((currentDate.Month - 1) / 3 + 1) + " /  "+ DateTime.Now.ToString("yyyy") +"";  // Ngày tháng C2
            worksheet.Cells[4, 4] = TenNV; // Tên nhân viên vào D4
            worksheet.Cells[5, 4] = Frm_Login.MaNV.ToString(); // Mã nhân viên vào D5
            worksheet.Cells[4, 8] = TenChucDanh; // Tên chức danh vào G4
            worksheet.Cells[5, 8] = TenPhongKhoa; // Tên khoa phòng vào G5
            worksheet.Cells[9, 3] = txtQTUXHT.Text;  // Quy tắc ứng xử vào C9
            if (txtQTUXHT.Text.Length > 0)
                worksheet.Cells[9, 4] = "10";
            else
                worksheet.Cells[9, 4] = "0";

            // Sao chép dữ liệu từ mỗi DataGridView sang worksheet
            //MỤC TIÊU BẮT BUỘC (bắt đầu từ dòng 12)
            int stt = 0;
            for (int i = 0; i < dgvKPICN_MTBB.RowCount; i++)
            {
                stt++;
                worksheet.Cells[i + 12, 2] = stt;//số thứ tự đầu dòng
                worksheet.Cells[i + 12, 3] = dgvKPICN_MTBB.Rows[i].Cells["ND_HTMTBB"].Value.ToString();//nội dung mục tiêu đánh giá
                worksheet.Cells[i + 12, 4] = float.Parse(dgvKPICN_MTBB.Rows[i].Cells["TSHT_HTMTBB"].Value.ToString()) / 100;//trọng số hoàn thành
                worksheet.Cells[i + 12, 5] = dgvKPICN_MTBB.Rows[i].Cells["PPD_HTMTBB"].Value.ToString();//phương pháp đo
                worksheet.Cells[i + 12, 6] = dgvKPICN_MTBB.Rows[i].Cells["NCM_HTMTBB"].Value.ToString();//nguồn chứng minh
                worksheet.Cells[i + 12, 7] = dgvKPICN_MTBB.Rows[i].Cells["DVT_HTMTBB"].Value.ToString();//đơn vị tính
                worksheet.Cells[i + 12, 8] = dgvKPICN_MTBB.Rows[i].Cells["KH_HTMTBB"].Value.ToString();//kế hoạch
                worksheet.Cells[i + 12, 9] = dgvKPICN_MTBB.Rows[i].Cells["TH_HTMTBB"].Value.ToString();//thực hiện
                worksheet.Cells[i + 12, 10] = "=IF(AND(I" + (i + 12) + "<>\"\",I" + (i + 12) + "<=H" + (i + 12) + "),I" + (i + 12) + "/H" + (i + 12) + "*100%,0%)";//công thức tính Tỷ lệ (%) hoàn thành
                worksheet.Cells[i + 12, 11] = "=D" + (i + 12) + "*J" + (i + 12) + "";//công thức tính kết quả KPI

                if (i < dgvKPICN_MTBB.RowCount - 1)
                    worksheet.Rows[i + 13].Insert();
            }

            //MỤC TIÊU ĐĂNG KÍ THÊM (dòng 14 + số dòng mục tiêu bắt buộc)
            for (int i = 0; i < dgvKPICN_MTT.RowCount; i++)
            {
                stt++;
                worksheet.Cells[i + 13 + dgvKPICN_MTBB.RowCount, 2] = stt;//số thứ tự đầu dòng
                worksheet.Cells[i + 13 + dgvKPICN_MTBB.RowCount, 3] = dgvKPICN_MTT.Rows[i].Cells["ND_HTMTT"].Value.ToString();//nội dung mục tiêu đánh giá
                worksheet.Cells[i + 13 + dgvKPICN_MTBB.RowCount, 4] = float.Parse(dgvKPICN_MTT.Rows[i].Cells["TSHT_HTMTT"].Value.ToString()) / 100;//trọng số hoàn thành
                worksheet.Cells[i + 13 + dgvKPICN_MTBB.RowCount, 5] = dgvKPICN_MTT.Rows[i].Cells["PPD_HTMTT"].Value.ToString();//phương pháp đo
                worksheet.Cells[i + 13 + dgvKPICN_MTBB.RowCount, 6] = dgvKPICN_MTT.Rows[i].Cells["NCM_HTMTT"].Value.ToString();//nguồn chứng minh
                worksheet.Cells[i + 13 + dgvKPICN_MTBB.RowCount, 7] = dgvKPICN_MTT.Rows[i].Cells["DVT_HTMTT"].Value.ToString();//đơn vị tính
                worksheet.Cells[i + 13 + dgvKPICN_MTBB.RowCount, 8] = dgvKPICN_MTT.Rows[i].Cells["KH_HTMTT"].Value.ToString();//kế hoạch
                worksheet.Cells[i + 13 + dgvKPICN_MTBB.RowCount, 9] = dgvKPICN_MTT.Rows[i].Cells["TH_HTMTT"].Value.ToString();//thực hiện
                worksheet.Cells[i + 13 + dgvKPICN_MTBB.RowCount, 10] = "=IF(AND(I" + (i + 13 + dgvKPICN_MTBB.RowCount) + "<>\"\",I" + (i + 13 + dgvKPICN_MTBB.RowCount) + "<=H" + (i + 13 + dgvKPICN_MTBB.RowCount) + "),I" + (i + 13 + dgvKPICN_MTBB.RowCount) + "/H" + (i + 13 + dgvKPICN_MTBB.RowCount) + "*100%,0%)";//công thức tính Tỷ lệ (%) hoàn thành
                worksheet.Cells[i + 13 + dgvKPICN_MTBB.RowCount, 11] = "=D" + (i + 13 + dgvKPICN_MTBB.RowCount) + "*J" + (i + 13 + dgvKPICN_MTBB.RowCount) + "";//công thức tính kết quả KPI

                if (i < dgvKPICN_MTT.RowCount - 1)
                    worksheet.Rows[i + 14 + dgvKPICN_MTBB.RowCount].Insert();
            }
            worksheet.Cells[(dgvKPICN_MTBB.RowCount + dgvKPICN_MTT.RowCount + 13), 4] = "=SUM(D12:D" + (dgvKPICN_MTBB.RowCount + dgvKPICN_MTT.RowCount + 12) + ")";//công thức tính tổng trọng số mục tiêu
            worksheet.Cells[10, 11] = "=SUM(K12:K" + (dgvKPICN_MTBB.RowCount + dgvKPICN_MTT.RowCount + 12) + ")*D10";//công thức tính tổng trọng số mục tiêu công việc

            // Lưu file
            string tenfile = ""+Frm_Login.MaNV+"_"+DateTime.Now.ToString("yyyyMMddHHmmss") +"";
            workbook.SaveAs(""+ tenfile +".xlsx");
        }

        #endregion
    }
}

//create table ChiTietDangKiThem_KPICaNhan
//(
//	MaKPI_DKT int identity(1,1) primary key,
//    MaKPI int references KPI(MaKPI),
//	MaNV varchar(20) references NguoiDung(MaNV),
//	QuyNam varchar(5),
//	NoiDung nvarchar(max),
//	TrongSoKPIDK int,
//    DonViTinh nvarchar(100),
//	PhuongPhapDo nvarchar(200)
//)

//alter table ChiTietKPICaNhan
//add MaKPI_DKT int references ChiTietDangKiThem_KPICaNhan(MaKPI_DKT)

//xoá cột TrongSoKPICaNhanDangKyThem, ThoiDiemGhiNhan trong bảng ChiTietKPICaNhan
//Cột tieuchidanhgiaQK, MaKPI trong bảng ChiTietKPICaNhan chuyển thành allow null
//Cột chưa đụng đến : ChiTieuKPICN, TrongSoTCCN, KeHoach, ThucHien, TyLeHoanThanh, TieuChiDanhGiaKQ, KetQua, KetQuaKPIBV, KetQuaKPIKP, KetQuaKPIKPGiaTriCotLoiBV

//kế hoạch, hoàn thành là từ trên giao xuống
//mỗi đơn vị tính khác nhau là 1 công thức tính khác nhau (xem file excel điều dưỡng)
//lỗi quý ô C2

//viết hàm check nếu chưa nhập đủ trọng số bắt buộc
//tìm hiểu cách định dạng excel c# (auto size column)