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

namespace DuAn_QuanLyKPI.GUI
{
    public partial class Frm_A78 : DevExpress.XtraEditors.XtraForm
    {
        private static string mconnectstring = Database.mconnectstring;
        private clsCommonMethod comm = new clsCommonMethod();
        private clsEventArgs ev = new clsEventArgs("");
        private string msql;
        private string maphieukpikp;
        private string MaQuyen;
        Timer Time1;
        Timer Time2;

        public Frm_A78()
        {
            InitializeComponent();
            LoadThongTinNhanVien();
            LoadDGV();

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
            MaQuyen = dt.Rows[0]["MaQuyen"].ToString();

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

        private void LoadDGV()
        {
            string QuyNam = $"{(DateTime.Now.Month - 1) / 3 + 1}{DateTime.Now.Year}";

            msql = "SELECT * FROM KPI_KhoaPhong " +
                "where MaPK = 'CNTT' " +
                "and IDBieuMau = '78' " +
                "and QuyNam = '"+ QuyNam + "'";
            DataTable dtt = comm.GetDataTable(mconnectstring, msql, "KPI");
            maphieukpikp = dtt.Rows[0]["MaPhieuKPIKP"].ToString();

            msql = "SELECT A.MaKPI, B.NoiDung, A.TrongSoKPIKP FROM ChiTietTieuChiMucTieuKhoaPhong as A, KPI as B " +
                "where A.MaKPI = B.MaKPI " +
                "and A.MaPhieuKPIKP = '"+ maphieukpikp +"' " +
                "and B.CongViecCaNhan = 'true'";
            DataTable dt = comm.GetDataTable(mconnectstring, msql, "KPI");
            dgvCN.DataSource = dt;

            dgvCN.CurrentCellDirtyStateChanged += Dgv1_CurrentCellDirtyStateChanged;
            dgvCN.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void LoadDGVDKMTTKPI()
        {
            msql = "select A.MaKPI, A.NoiDung from KPI as A, KPITrongNganHang as B, NganHangKPI as C, NguoiDung as D " +
                "where A.MaKPI = B.MaKPI " +
                "and B.MaNganHangKPI = C.MaNganHangKPI " +
                "and C.MaChucDanh = D.MaChucDanh " +
                "and C.MaPK = D.MaPhongKhoa " +
                "and D.MaQuyen = 'NV' " +
                "and A.CongViecCaNhan = 'true' " +
                "and C.MaChucDanh = '"+ Frm_Login.MaCD +"' " +
                "and D.MaNV = '" + Frm_Login.MaNV + "' " +
                "and C.MaPK = '" + Frm_Login.MaPK +"'";
            DataTable dt = comm.GetDataTable(mconnectstring,msql,"DangKiMuctieuKPI");
            dgvDKMTT_KPI1.DataSource = dt;
        }

        private void copyDataCNtoCN2()
        {
            txtTongTrongSo.Text = Convert.ToString(SumTrongSo());
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

        private void copyDataDKMTTKPItoHT()
        {
            dgvHTDGV2.Rows.Clear();
            for (int i = 0; i < dgvDKMTT_KPI2.Rows.Count; i++)
            {
                int n = dgvHTDGV2.Rows.Add();
                dgvHTDGV2.Rows[n].Cells["cNoiDungMTTHT"].Value = dgvDKMTT_KPI2.Rows[i].Cells["cNoiDungMTTKPI2"].Value.ToString();
                dgvHTDGV2.Rows[n].Cells["cTrongSoMTTHT"].Value = dgvDKMTT_KPI2.Rows[i].Cells["cTrongSoHTMTTKPI2"].Value.ToString();
            }
        }

        private void copyDataMTTKPI1toMTTKPI2()
        {
            dgvDKMTT_KPI2.Rows.Clear();
            for (int i = 0; i < dgvCN.Rows.Count; i++)
            {
                if (dgvDKMTT_KPI1.Rows[i].Cells["cChonMTKPI1"].Value != null && dgvDKMTT_KPI1.Rows[i].Cells["cChonMTKPI1"].Value.ToString() == "true")
                {
                    int n = dgvDKMTT_KPI2.Rows.Add();
                    dgvDKMTT_KPI2.Rows[n].Cells["cNoiDungMTKPI2"].Value = dgvDKMTT_KPI1.Rows[i].Cells["cNoiDungMTKPI1"].Value.ToString();
                    dgvDKMTT_KPI2.Rows[n].Cells["cMaKPIMTKPI2"].Value = dgvDKMTT_KPI1.Rows[i].Cells["cMaKPIMTKPI1"].Value.ToString();
                }
            }
        }

        private void copyDataCNtoHT()
        {
            dgvHT.Rows.Clear();

            for (int i = 0; i < dgvCN2.Rows.Count; i++)
            {
                int n = dgvHT.Rows.Add();
                dgvHT.Rows[n].Cells["NoiDungHT"].Value = dgvCN2.Rows[i].Cells["NoiDung2"].Value.ToString();
                dgvHT.Rows[n].Cells["TrongSoHTHT"].Value = dgvCN2.Rows[i].Cells["TrongSoHT"].Value.ToString();
                dgvHT.Rows[n].Cells["MaKPIHT"].Value = dgvCN2.Rows[i].Cells["MaKPI2"].Value.ToString();
            }
        }

        private int SumTrongSo()
        {
            int sum = 0;
            for (int i = 0; i < dgvCN2.Rows.Count; i++)
            {
                if (dgvCN2.Rows[i].Cells["TrongSoHT"].Value != null)
                    sum += Convert.ToInt32(dgvCN2.Rows[i].Cells["TrongSoHT"].Value);
                else
                    return 0;
            }
            return sum;
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

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            copyDataCNtoCN2();
        }

        private void UpdateTimer_Tick2(object sender, EventArgs e)
        {
            copyDataDKMTTKPItoHT();
        }

        private void dgvCN_MouseLeave(object sender, EventArgs e)
        {
            //Time1.Stop();
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
            //Time1.Stop();
        }

        private void Dgv1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dgvCN.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void btnClearTC_Click(object sender, EventArgs e)
        {
            if(dgvCN2.Rows.Count != 0)
            {
                if (ev.QFrmThongBao_YesNo("Bạn có thật sự muốn xóa Form Nhập này không?"))
                {
                    dgvCN2.Rows.Clear();
                }
            }
        }

        private void btnTiepTucTaiChinh_Click(object sender, EventArgs e)
        {

            if (SumTrongSo() == 0)
            {
                ev.QFrmThongBao("Vui lòng nhập đầy đủ !");
                return;
            }
            else if (SumTrongSo() < 100)
            {
                ev.QFrmThongBao("Trọng số bé hơn 100% !");
            }
            else if(SumTrongSo() > 100)
            {
                ev.QFrmThongBao("Trọng số lớn hơn 100% !");
            }
            tabMucTieuKhoaPhong.SelectTab(3);

            txtQTUXHT.Text = txtQTUX.Text;
            copyDataCNtoHT();
        }

        private void btnQuayLaiHoanThanh_Click(object sender, EventArgs e)
        {
            tabMucTieuKhoaPhong.SelectTab(0);
        }

        private void btnDangKiThem_Click(object sender, EventArgs e)
        {
            tabMucTieuKhoaPhong.SelectTab(1);
        }

        private void btnTTpnDKTPK_Click(object sender, EventArgs e)
        {
            tabMucTieuKhoaPhong.SelectTab(2);
            LoadDGVDKMTTKPI();
        }

        private void btnTiepTucDKMTTKPI_Click(object sender, EventArgs e)
        {
            copyDataCNtoHT();
            copyDataDKMTTKPItoHT();
            tabMucTieuKhoaPhong.SelectTab(3);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtQTUX.Enabled = cbQTUX.Checked;
        }

        private void btnHoanThanh_Click(object sender, EventArgs e)
        {
            //msql = "insert into KPI_CaNhan ([MaPhieuKPI],[MaNhanVien],[NgayTaoCaNhan],[TrangThai],QuyTacUngXu) values ('" + maphieukpi + "','" + Frm_Login.MaNV + "', GETDATE(),0,N'"+ txtQTUXHT.Text + "')";
            //comm.RunSQL(mconnectstring, msql);

            //msql = "select MaKPICN from KPI_CaNhan where MaNhanVien = '"+ Frm_Login.MaNV + "' and CONVERT(VARCHAR, NgayTaoCaNhan, 112) = CONVERT(VARCHAR, GETDATE(), 112) and TrangThai = 0 and MaPhieuKPI = '" + maphieukpi +"'";
            //DataTable dtt = comm.GetDataTable(mconnectstring, msql, "KPI");
            //string makpicn = dtt.Rows[0]["MaKPICN"].ToString();


            //for (int i = 0; i < dgvHT.Rows.Count; i++)
            //{
            //    string makpi = dgvHT.Rows[i].Cells["MaKPIHT"].Value.ToString();
            //    string trongso = dgvHT.Rows[i].Cells["TrongSoHTHT"].Value.ToString();

            //    msql = "INSERT INTO [dbo].[ChiTietTieuChiMucTieuCaNhan] ([MaKPI],[ChiTieuHT],[TrongSoKPIHT],[MaKPICN]) VALUES ("+ makpi +", "+ dgvCN2.Rows[i].Cells["TrongSoBV"].Value.ToString() + ", "+ trongso + ", "+ makpicn + ")";
            //    comm.RunSQL(mconnectstring, msql);
            //}
            //ev.QFrmThongBao("Chúc mừng bạn đã hoàn thành KPI Cá nhân !");
        }

        private void btnExel_Click(object sender, EventArgs e)
        {
            //if (dgvHT.Rows.Count > 0)
            //{

            //    Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
            //    xcelApp.Application.Workbooks.Add(Type.Missing);
            //    Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)xcelApp.ActiveSheet;

            //    //Microsoft.Office.Interop.Excel.Range headerRange = worksheet.Range[worksheet.Cells[dataGridView.Rows.Count, dataGridView.Columns.Count ],worksheet.Cells[dataGridView.Rows.Count + 1, dataGridView.Columns.Count+1]];
            //    //headerRange.Merge();

            //    for (int i = 1; i < dgvHT.Columns.Count + 1; i++)
            //    {
            //        xcelApp.Cells[2, i] = dgvHT.Columns[i - 1].HeaderText;
            //    }

            //    for (int i = 0; i < dgvHT.Rows.Count; i++)
            //    {
            //        for (int j = 0; j < dgvHT.Columns.Count; j++)
            //        {
            //            xcelApp.Cells[i + 2, j + 1] = dgvHT.Rows[i].Cells[j].Value.ToString();
            //        }
            //    }
            //    // Tạo dòng tổng
            //    int totalRow = dgvHT.Rows.Count + 2;
            //    Microsoft.Office.Interop.Excel.Range totalRange = worksheet.Range[worksheet.Cells[totalRow, 3], worksheet.Cells[totalRow, dgvHT.Columns.Count - 1]];
            //    totalRange.Merge();
            //    totalRange.Value = "Tổng";
            //    // Tạo dòng Quy tắc ứng sử
            //    totalRange = worksheet.Range[worksheet.Cells[1, 3], worksheet.Cells[1, 2]];
            //    totalRange.Merge();
            //    totalRange.Value = "Quy Tắc Ứng Xử";

            //    xcelApp.Columns.AutoFit();
            //    xcelApp.Visible = true;
            //}

            copyDataCNtoCN2();

        }

        private void dgvCN_MouseClick(object sender, MouseEventArgs e)
        {
            Time1.Start();
        }

        private void dgvCN_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Time1.Stop();

        }

        private void btnQLtabDKMTTKPI_Click(object sender, EventArgs e)
        {
            tabMucTieuKhoaPhong.SelectTab(1);
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
    }
}