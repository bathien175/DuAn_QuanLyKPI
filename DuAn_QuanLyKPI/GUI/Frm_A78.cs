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
        Timer Time2; 

        public Frm_A78()
        {
            InitializeComponent();
            LoadThongTinNhanVien();
            LoadDGVtab1();

            Time1 = new Timer { Interval = 100 };
            Time1.Tick += UpdateTimer_Tick;

            Time2 = new Timer { Interval = 100 };
            Time2.Tick += UpdateTimer_Tick2;
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
            tabMucTieuKhoaPhong.SelectTab(3);
            if(cbQTUX.Checked = true)
                txtQTUXHT.Text = txtQTUX.Text;
            copyDataCN2toHT();
        }
        private void btnDangKiThem_Click(object sender, EventArgs e)
        {
            tabMucTieuKhoaPhong.SelectTab(1);
            LoadDGVtab2();
        }
        private void btnTTpnDKTPK_Click(object sender, EventArgs e)
        {
            tabMucTieuKhoaPhong.SelectTab(3);
            copyDataCN2toHT();
            copyDataDKMTTKPI2toHT();
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
            dgvHTDGV1.Rows.Clear();

            for (int i = 0; i < dgvCN2.Rows.Count; i++)
            {
                int n = dgvHTDGV1.Rows.Add();
                dgvHTDGV1.Rows[n].Cells["NoiDungHT"].Value = dgvCN2.Rows[i].Cells["NoiDung2"].Value.ToString();
                dgvHTDGV1.Rows[n].Cells["TrongSoHTHT"].Value = dgvCN2.Rows[i].Cells["TrongSoHT"].Value.ToString();
                dgvHTDGV1.Rows[n].Cells["MaKPIHT"].Value = dgvCN2.Rows[i].Cells["MaKPI2"].Value.ToString();
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
            msql = "select A.MaKPI, A.NoiDung from KPI as A, KPITrongNganHang as B, NganHangKPI as C, NguoiDung as D " +
                "where A.MaKPI = B.MaKPI " +
                "and B.MaNganHangKPI = C.MaNganHangKPI " +
                "and C.MaChucDanh = D.MaChucDanh " +
                "and C.MaPK = D.MaPhongKhoa " +
                "and D.MaQuyen = 'NV' " +
                "and A.CongViecCaNhan = 'true' " +
                "and C.MaChucDanh = '" + Frm_Login.MaCD + "' " +
                "and D.MaNV = '" + Frm_Login.MaNV + "' " +
                "and C.MaPK = '" + Frm_Login.MaPK + "'";
            DataTable dt = comm.GetDataTable(mconnectstring, msql, "DangKiMuctieuKPI");
            dgvDKMTT_KPI1.DataSource = dt;
        }
        private int SumTrongSotab2()
        {
            int sum = 0;
            for (int i = 0; i < dgvDKMTT_KPI2.Rows.Count; i++)
            {
                if (dgvDKMTT_KPI2.Rows[i].Cells["cTrongSoHTMTTKPI2"].Value != null && dgvDKMTT_KPI2.Rows[i].Cells["cTrongSoHTMTTKPI2"].Value.ToString() != "")
                {
                    string value = dgvDKMTT_KPI2.Rows[i].Cells["cTrongSoHTMTTKPI2"].Value.ToString();
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
        private void btnQLtabDKMTTKPI_Click(object sender, EventArgs e)
        {
            tabMucTieuKhoaPhong.SelectTab(0);
        }
        private void copyDataDKMTTKPI1toDKMTTKPI2()
        {
            dgvDKMTT_KPI2.Rows.Clear();
            for (int i = 0; i < dgvDKMTT_KPI1.Rows.Count; i++)
            {
                dgvDKMTT_KPI1.Rows[i].Cells["cTrongSoMTKPI1"].Value = 0;

                if (dgvDKMTT_KPI1.Rows[i].Cells["cChonMTKPI1"].Value != null && dgvDKMTT_KPI1.Rows[i].Cells["cChonMTKPI1"].Value.ToString() == "true")
                {
                    int n = dgvDKMTT_KPI2.Rows.Add();
                    dgvDKMTT_KPI2.Rows[n].Cells["cNoiDungMTTKPI2"].Value = dgvDKMTT_KPI1.Rows[i].Cells["cNoiDungMTKPI1"].Value.ToString();
                    dgvDKMTT_KPI2.Rows[n].Cells["cMaKPIMTKPI2"].Value = dgvDKMTT_KPI1.Rows[i].Cells["cMaKPIMTKPI1"].Value.ToString();
                    dgvDKMTT_KPI2.Rows[n].Cells["cTrongSoMTTKPI2"].Value = dgvDKMTT_KPI1.Rows[i].Cells["cTrongSoMTKPI1"].Value.ToString();
                }
            }
        }
        private void copyDataDKMTTKPI2toHT()
        {
            dgvHTDGV2.Rows.Clear();
            for (int i = 0; i < dgvDKMTT_KPI2.Rows.Count; i++)
            {
                int n = dgvHTDGV2.Rows.Add();
                dgvHTDGV2.Rows[n].Cells["cNoiDung_KPI_HT"].Value = dgvDKMTT_KPI2.Rows[i].Cells["cNoiDungMTTKPI2"].Value.ToString();
                dgvHTDGV2.Rows[n].Cells["cTrongSoHT_KPI_HT"].Value = dgvDKMTT_KPI2.Rows[i].Cells["cTrongSoHTMTTKPI2"].Value.ToString();
            }
        }
        private void UpdateTimer_Tick2(object sender, EventArgs e)
        {
            copyDataDKMTTKPI1toDKMTTKPI2();
        }
        private void btnTiepTucDKMTTKPI_Click(object sender, EventArgs e)
        {
            tabMucTieuKhoaPhong.SelectTab(2);
        }
        private void dgvDKMTT_KPI1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Time2.Start();
        }
        private void dgvDKMTT_KPI1_MouseLeave(object sender, EventArgs e)
        {
            Time2.Stop();
        }
        private void dgvDKMTT_KPI2_MouseHover(object sender, EventArgs e)
        {
            Time2.Stop();
        }
        private void dgvDKMTT_KPI1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dgvDKMTT_KPI1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        private void dgvDKMTT_KPI2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            txtTongTrongSoMucTieuThem.Text = Convert.ToString(SumTrongSotab2());
        }
        #endregion
        #region Tab3
        private void btnQLtabMTTKP_Click(object sender, EventArgs e)
        {
            tabMucTieuKhoaPhong.SelectTab(1);
        }

        #endregion
        #region Tab4
        private void btnQuayLaiHoanThanh_Click(object sender, EventArgs e)
        {
            tabMucTieuKhoaPhong.SelectTab(0);
        }
        private void btnHoanThanh_Click(object sender, EventArgs e)
        {
            string MaPhieuKPICN = "";
            msql = "INSERT INTO [dbo].[KPI_CaNhan] " +
                "([MaPhieuKPICN],[MaPhieuKPIKP],[QuyTacUngXu],[TrongSoQuyTacUngXu],[IDBieuMau],[MaNV],[QuyNam],[NgayLapPhieuKPICN]) " +
                "VALUES " +
                "(,,,,,,,)";
            comm.RunSQL(mconnectstring, msql);

            msql = "SELECT * FROM [QuanLyKPI].[dbo].[KPI_KhoaPhong] " +
                "where MaPK = '"+ Frm_Login.MaPK +"' " +
                "and QuyNam = '"+ QuyNam +"' " +
                "and IDBieuMau = '78' " +
                "and TrangThai = '0'";
            DataTable dtt = comm.GetDataTable(mconnectstring, msql, "KPI");
            string makpicn = dtt.Rows[0]["MaKPICN"].ToString();


            for (int i = 0; i < dgvCN2.Rows.Count; i++)
            {
                string makpi = dgvCN2.Rows[i].Cells["MaKPI2"].Value.ToString();
                string trongsoHT = dgvCN2.Rows[i].Cells["TrongSoHT"].Value.ToString();

                msql = "INSERT INTO [dbo].[ChiTietKPICaNhan] " +
                    "([MaPhieuKPICN],[MaKPI],[TrongSoKPICN],[KPICaNhanDangKyThem],[NguonChungMinh],[KeHoach],[ThucHien],[TyLeHoanThanh],[ThoiDiemGhiNhan]) " +
                    "VALUES " +
                    "('"+ MaPhieuKPICN + "','"+ makpi +"','"+ trongsoHT +"','0','"+ Frm_Login.MaPK + "','kehoach','thuchien','tylehoanthanh','" + DateTime.Now + "')";
                comm.RunSQL(mconnectstring, msql);
            }
            for (int i = 0; i < dgvDKMTT_KPI2.Rows.Count; i++)
            {
                string makpi = dgvDKMTT_KPI2.Rows[i].Cells["cMaKPIMTKPI2"].Value.ToString();
                string trongsoHT = dgvDKMTT_KPI2.Rows[i].Cells["cTrongSoHTMTTKPI2"].Value.ToString();

                msql = "INSERT INTO [dbo].[ChiTietKPICaNhan] " +
                    "([MaPhieuKPICN],[MaKPI],[TrongSoKPICN],[KPICaNhanDangKyThem],[NguonChungMinh],[KeHoach],[ThucHien],[TyLeHoanThanh],[ThoiDiemGhiNhan]) " +
                    "VALUES " +
                    "('" + MaPhieuKPICN + "','" + makpi + "','" + trongsoHT + "','1','" + Frm_Login.MaPK + "','kehoach','thuchien','tylehoanthanh','" + DateTime.Now + "')";
                comm.RunSQL(mconnectstring, msql);
            }

            ev.QFrmThongBao("Chúc mừng bạn đã hoàn thành KPI Cá nhân !");
        }
        private void btnExel_Click(object sender, EventArgs e)
        {
            ExportToExcel(dgvCN2, @"D:\Test_" + DateTime.Now + ".csv");
            copyDataCNtoCN2();

        }


        #endregion


        // Hàm này được sử dụng để đổ dữ liệu từ DataGridView vào một bảng Excel
        private void ExportToExcel(DataGridView dataGridView, string filePath)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
            Excel.Worksheet worksheet = workbook.ActiveSheet;

            try
            {
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView.Columns.Count; j++)
                    {
                        string cellValue = dataGridView.Rows[i].Cells[j].Value?.ToString() ?? "";
                        worksheet.Cells[i + 1, j + 1] = cellValue;
                    }
                }

                workbook.SaveAs(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
            finally
            {
                workbook.Close();
                excelApp.Quit();
                releaseObject(worksheet);
                releaseObject(workbook);
                releaseObject(excelApp);
            }
        }

        // Hàm này được sử dụng để giải phóng tài nguyên
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Lỗi giải phóng tài nguyên: " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

    }
}

//create table DangKiThem_KPICaNhan
//(
//	MaKPI_DKT int identity(1,1) primary key,
//    MaKPI int references KPI(MaKPI),
//	MaNV varchar(20) references NguoiDung(MaNV),
//	QuyNam varchar(5),
//	NoiDung nvarchar(max),
//	TrongSoMucTieu int,
//    DonViTinh nvarchar(100),
//	PhuongPhapDo nvarchar(200)
//)

//alter table ChiTietKPICaNhan
//add MaKPI_DKT int references DangKiThem_KPICaNhan(MaKPI_DKT)

//alter table ChiTietKPICaNhan
//add TrongSoMucTieuDKT int references DangKiThem_KPICaNhan(TrongSoMucTieu)
