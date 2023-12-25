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

            string TenNV = dt.Rows[0]["TenNV"].ToString();
            string TenChucDanh = dt.Rows[0]["TenChucDanh"].ToString();
            string TenPhongKhoa = dt.Rows[0]["TenPK"].ToString();

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

            msql = "SELECT A.MaKPI, B.NoiDung, A.TrongSoKPIKP FROM ChiTietTieuChiMucTieuKhoaPhong as A, KPI as B " +
                "where A.MaKPI = B.MaKPI " +
                "and A.MaPhieuKPIKP = '" + maphieukpikp + "' " +
                "and B.CongViecCaNhan = 'true'";
            DataTable dt = comm.GetDataTable(mconnectstring, msql, "KPI");
            dgvCN.DataSource = dt;

            dgvCN.CurrentCellDirtyStateChanged += Dgv1_CurrentCellDirtyStateChanged;
            dgvCN.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        private int SumTrongSotab1()
        {
            int sum = 0;
            for (int i = 0; i < dgvCN2.Rows.Count; i++)
            {
                if (dgvCN2.Rows[i].Cells["TrongSoHT"].Value != null)
                {
                    string value = dgvCN2.Rows[i].Cells["TrongSoHT"].Value.ToString();
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
            dgvCN2.Rows.Clear();
            for (int i = 0; i < dgvCN.Rows.Count; i++)
            {
                if (dgvCN.Rows[i].Cells["Chon"].Value != null && dgvCN.Rows[i].Cells["Chon"].Value.ToString() == "true")
                {
                    int n = dgvCN2.Rows.Add();
                    dgvCN2.Rows[n].Cells["NoiDung2"].Value = dgvCN.Rows[i].Cells["NoiDung"].Value.ToString();
                    dgvCN2.Rows[n].Cells["TrongSoBV"].Value = dgvCN.Rows[i].Cells["TrongSo"].Value.ToString();
                    dgvCN2.Rows[n].Cells["MaKPI2"].Value = dgvCN.Rows[i].Cells["MaKPI"].Value.ToString();
                }
            }
        }
        private void copyDataCN2toHT()
        {
            dgvKPICN_MTBB.Rows.Clear();

            for (int i = 0; i < dgvCN2.Rows.Count; i++)
            {
                int n = dgvKPICN_MTBB.Rows.Add();
                dgvKPICN_MTBB.Rows[n].Cells["NoiDungHT"].Value = dgvCN2.Rows[i].Cells["NoiDung2"].Value.ToString();
                dgvKPICN_MTBB.Rows[n].Cells["TrongSoHTHT"].Value = dgvCN2.Rows[i].Cells["TrongSoHT"].Value.ToString();
                dgvKPICN_MTBB.Rows[n].Cells["MaKPIHT"].Value = dgvCN2.Rows[i].Cells["MaKPI2"].Value.ToString();
            }
        }
        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            copyDataCNtoCN2();
        }
        private void Dgv1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dgvCN.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        private void dgvCN_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                dgvCN2.Rows.Clear();
                for (int i = 0; i < dgvCN.Rows.Count; i++)
                {
                    dgvCN.Rows[i].Cells["Chon"].Value = "true";
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
                dgvCN2.Rows.Clear();
                for (int i = 0; i < dgvCN.Rows.Count; i++)
                {
                    dgvCN.Rows[i].Cells["Chon"].Value = false;
                }
                copyDataCNtoCN2();
            }
        }
        private void dgvCN2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvCN2.Rows.Count && e.ColumnIndex == 0)
            {
                foreach (DataGridViewRow row in dgvCN.Rows)
                {
                    if (dgvCN2.Rows[e.RowIndex].Cells["MaKPI2"].Value.ToString() == row.Cells["MaKPI"].Value.ToString())
                    {
                        row.Cells["Chon"].Value = false;
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
            msql = "SELECT a.MaKPI_DKT, a.MaNV, a.QuyNam, b.NoiDung, a.TrongSoKPIDK, b.DonViTinh, b.PhuongPhapDo " +
                "FROM ChiTietDangKiThem_KPICaNhan a " +
                "inner join KPI b on a.MaKPI = b.MaKPI " +
                "WHERE a.MaKPI IS NOT NULL";
            DataTable dtA = comm.GetDataTable(mconnectstring, msql, "DangKiMuctieuThem1");

            msql = "SELECT MaKPI_DKT, MaNV, QuyNam, NoiDung, TrongSoKPIDK, DonViTinh, PhuongPhapDo " +
                "FROM ChiTietDangKiThem_KPICaNhan " +
                "WHERE MaKPI IS NULL";
            DataTable dtB = comm.GetDataTable(mconnectstring, msql, "DangKiMuctieuThem1");

            DataTable MTT = new DataTable();
            MTT = dtA.Copy();
            MTT.Merge(dtB);

            if(MTT.Rows.Count > 0 ) 
            {
                dgvDKMTT.DataSource = MTT;
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
            for (int i = 0; i < dgvDKMTT.Rows.Count; i++)
            {
                if (dgvDKMTT.Rows[i].Cells["cTrongSoHT_MTT"].Value != null && dgvDKMTT.Rows[i].Cells["cTrongSoHT_MTT"].Value.ToString() != "")
                {
                    string value = dgvDKMTT.Rows[i].Cells["cTrongSoHT_MTT"].Value.ToString();
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
            dgvKPICN_MTT.Rows.Clear();
            for (int i = 0; i < dgvDKMTT.Rows.Count; i++)
            {
                int n = dgvKPICN_MTT.Rows.Add();
                dgvKPICN_MTT.Rows[n].Cells["cMaKPI_MTT_HT"].Value = dgvDKMTT.Rows[i].Cells["cMaKPI_MTT"].Value.ToString();
                dgvKPICN_MTT.Rows[n].Cells["cNoiDung_MTT_HT"].Value = dgvDKMTT.Rows[i].Cells["cNoiDung_MTT"].Value.ToString();
                dgvKPICN_MTT.Rows[n].Cells["cTrongSoHT_MTT_HT"].Value = dgvDKMTT.Rows[i].Cells["cTrongSoHT_MTT"].Value.ToString();
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
            for (int i = 0; i < dgvKPICN_MTBB.Rows.Count; i++)
            {
                string makpi = dgvKPICN_MTBB.Rows[i].Cells["MaKPIHT"].Value.ToString();
                string trongsoHT = dgvKPICN_MTBB.Rows[i].Cells["TrongSoHTHT"].Value.ToString();

                msql = "INSERT INTO [dbo].[ChiTietKPICaNhan] " +
                    "([MaPhieuKPICN],[MaKPI],[TrongSoKPICN],[KPICaNhanDangKyThem],[NguonChungMinh]) " +
                    "VALUES " +
                    "('" + MaPhieuKPICN + "','" + makpi + "','" + trongsoHT + "','0','" + Frm_Login.MaPK + "')";
                comm.RunSQL(mconnectstring, msql);
            }

            //KPI cá nhân đăng kí thêm
            for (int i = 0; i < dgvKPICN_MTT.Rows.Count; i++)
            {
                string makpi = dgvKPICN_MTT.Rows[i].Cells["cMaKPI_MTT_HT"].Value.ToString();
                string trongsoHT = dgvKPICN_MTT.Rows[i].Cells["cTrongSoHT_MTT_HT"].Value.ToString();

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
            int sum = int.Parse(txtTongTrongSoMucTieuThem.Text);
            if (sum < 100 && sum > 100)
            {
                ev.QFrmThongBaoError("Trọng số chưa đạt đủ hoặc vượt quá 100%");
            }
            else if (sum == 100)
            {
                if (ev.QFrmThongBao_YesNo("Bạn có chắc muốn tiếp tục không? Hãy kiểm tra thật kĩ thông tin trước khi Hoàn thành nhé!"))
                {
                    string existingFilePath = Path.Combine("A73.xlsx");
                    // Pass the full path to the function
                    AddDataGridViewsToExistingExcelSheet(dgvKPICN_MTBB, dgvKPICN_MTT, existingFilePath);
                }
                else
                {

                }
            }
            else
            {

            }

        }

        private void AddDataGridViewsToExistingExcelSheet(DataGridView dgvKPICN_MTBB, DataGridView dgvKPICN_MTT, string existingFilePath)
        {
            // Mở một workbook Excel đã có sẵn
            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = true;
            Excel.Workbook workbook = excelApp.Workbooks.Open(existingFilePath);

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
            worksheet.Cells[3, 9] = txtQTUXHT.Text;  // TextBox1 vào F6
            worksheet.Cells[4, 4] = txtTenNV.Text; // TextBox2 vào F12
            worksheet.Cells[4, 5] = Frm_Login.MaNV; // TextBox3 vào F18
            worksheet.Cells[8, 4] = Frm_Login.MaCD; // TextBox4 vào F18
            worksheet.Cells[8, 5] = Frm_Login.MaPK; // TextBox4 vào F18
                                                    // Vị trí bắt đầu cho từng group
            int[] startRows = { 7, 13, 19, 25 };
            int startCol = 5;  // Bắt đầu từ cột E

            // Sao chép dữ liệu từ mỗi DataGridView sang worksheet
            //MỤC TIÊU BẮT BUỘC
            for (int groupIndex = 0; groupIndex < dgvKPICN_MTBB.RowCount; groupIndex++)
            {
                DataGridView dataGridView = dgvKPICN_MTBB[groupIndex];

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
                if (groupIndex != dgvKPICN_MTBB.RowCount - 1)
                {
                    startRow += 2;  // Dùng 2 dòng trống
                }
                else
                {
                    startRow++;  // Dùng 1 dòng trống cho nhóm cuối cùng
                }
            }

            ////MỤC TIÊU ĐĂNG KÍ THÊM
            //for (int groupIndex = 0; groupIndex < dgvKPICN_MTT.RowCount; groupIndex++)
            //{
            //    DataGridView dataGridView = dgvKPICN_MTT[groupIndex];

            //    int startRow = startRows[groupIndex];

            //    // Sao chép dữ liệu từ cột 2 và cột 4 của DataGridView sang worksheet
            //    for (int i = 0; i < dataGridView.Rows.Count; i++)
            //    {
            //        // Kiểm tra xem dữ liệu đã tồn tại trong sheet chưa
            //        bool dataExists = false;
            //        for (int row = 1; row <= worksheet.UsedRange.Rows.Count; row++)
            //        {
            //            if (worksheet.Cells[row, startCol].Value == dataGridView[2, i].Value &&
            //                worksheet.Cells[row, startCol + 1].Value == dataGridView[4, i].Value)
            //            {
            //                dataExists = true;
            //                break;
            //            }
            //        }
            //        // Nếu dữ liệu chưa tồn tại, thêm vào sheet
            //        if (!dataExists)
            //        {
            //            worksheet.Cells[startRow, startCol] = dataGridView[2, i].Value;  // Cột 2
            //            worksheet.Cells[startRow, startCol + 1] = dataGridView[4, i].Value;  // Cột 4
            //            startRow++;
            //        }
            //    }

            //    // Tạo khoảng trống giữa các nhóm (nếu không phải nhóm cuối cùng)
            //    if (groupIndex != dgvKPICN_MTT.RowCount - 1)
            //    {
            //        startRow += 2;  // Dùng 2 dòng trống
            //    }
            //    else
            //    {
            //        startRow++;  // Dùng 1 dòng trống cho nhóm cuối cùng
            //    }
            //}

            // Lưu workbook
            workbook.Save();
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