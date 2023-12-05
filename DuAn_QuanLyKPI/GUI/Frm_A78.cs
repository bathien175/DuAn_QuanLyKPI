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
        private string maphieukpi;

        public Frm_A78()
        {
            InitializeComponent();
            LoadThongTinNhanVien();
            LoadDB_MucTieu();
            GetQuy();
            txtQTUX.Enabled = false;
        }

        private void LoadThongTinNhanVien()
        {
            msql = "SELECT * FROM dbo.ChucDanh cd INNER JOIN dbo.NguoiDung nd ON cd.MaChucDanh = nd.MaChucDanh INNER JOIN dbo.PhongKhoa pk ON nd.MaPhongKhoa = pk.MaPK where nd.MaNV = '"+ Frm_Login.MaNV + "'";
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
        }

        private void LoadDB_MucTieu()
        {
            msql = "select MaPhieuKPI from [TongHopBieuMauPhieuKPI] where IDBieuMau = 78 and Nam = YEAR(GETDATE()) and Quy = DATEPART(QUARTER, GETDATE())";
            DataTable dtt = comm.GetDataTable(mconnectstring, msql, "KPI");
            maphieukpi = dtt.Rows[0]["MaPhieuKPI"].ToString();

            msql = "SELECT p.MaKPI, k.NoiDung ,p.TrongSoKPIBV FROM [QuanLyKPI].[dbo].[PhieuKPITongHop] p inner join KPI k on k.MaKPI = p.MaKPI where p.MaPK = '"+ Frm_Login.MaPK + "' and p.TruongPK = 'false' and p.CongViecCaNhan = 'true' and p.MaPhieuKPI = '" + maphieukpi +"'";
            DataTable dt = comm.GetDataTable(mconnectstring, msql, "KPI");
            dgvCN.DataSource = dt;
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

        public string GetQuy()
        {
            DateTime currentDate = DateTime.Now;
            int result = (currentDate.Month - 1) / 3 + 1;
            label3.Text = "QUÝ " + result + "";
            label5.Text = "QUÝ " + result + "";
            return result.ToString();
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
        private void btnClearTC_Click(object sender, EventArgs e)
        {
            if (ev.QFrmThongBao_YesNo("Bạn có thật sự muốn xóa Form Nhập này không?"))
            {
                dgvCN2.Rows.Clear();
            }
        }

        private void btnDeselectAllBVTC_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvCN.Rows.Count; i++)
            {
                dgvCN.Rows[i].Cells["Chon"].Value = false;
            }
        }

        private void btnSelectAllBVTC_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvCN.Rows.Count; i++)
            {
                dgvCN.Rows[i].Cells["Chon"].Value = true;
            }
        }

        private void btnCoppyAllBVtoTC_Click(object sender, EventArgs e)
        {
            dgvCN2.Rows.Clear();
            for (int i = 0; i < dgvCN.Rows.Count; i++)
            {
                dgvCN.Rows[i].Cells["Chon"].Value = "true";
            }
            copyDataCNtoCN2();
        }

        private void btncopyDataBVtoTC_Click(object sender, EventArgs e)
        {
            if (ev.QFrmThongBao_YesNo("Hãy kiểm tra thật kĩ trước khi chuyển dữ liệu đã chọn nhé!"))
            {
                copyDataCNtoCN2();
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
            tabMucTieuKhoaPhong.SelectTab(1);

            txtQTUXHT.Text = txtQTUX.Text;
            copyDataCNtoHT();
        }

        private void btnQuayLaiHoanThanh_Click(object sender, EventArgs e)
        {
            tabMucTieuKhoaPhong.SelectTab(0);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtQTUX.Enabled = cbQTUX.Checked;
        }

        private void btnHoanThanh_Click(object sender, EventArgs e)
        {
            msql = "insert into KPI_CaNhan ([MaPhieuKPI],[MaNhanVien],[NgayTaoCaNhan],[TrangThai],QuyTacUngXu) values ('" + maphieukpi + "','" + Frm_Login.MaNV + "', GETDATE(),0,N'"+ txtQTUXHT.Text + "')";
            comm.RunSQL(mconnectstring, msql);

            msql = "select MaKPICN from KPI_CaNhan where MaNhanVien = '"+ Frm_Login.MaNV + "' and CONVERT(VARCHAR, NgayTaoCaNhan, 112) = CONVERT(VARCHAR, GETDATE(), 112) and TrangThai = 0 and MaPhieuKPI = '" + maphieukpi +"'";
            DataTable dtt = comm.GetDataTable(mconnectstring, msql, "KPI");
            string makpicn = dtt.Rows[0]["MaKPICN"].ToString();


            for (int i = 0; i < dgvHT.Rows.Count; i++)
            {
                string makpi = dgvHT.Rows[i].Cells["MaKPIHT"].Value.ToString();
                string trongso = dgvHT.Rows[i].Cells["TrongSoHTHT"].Value.ToString();

                msql = "INSERT INTO [dbo].[ChiTietTieuChiMucTieuCaNhan] ([MaKPI],[ChiTieuHT],[TrongSoKPIHT],[MaKPICN]) VALUES ("+ makpi +", "+ dgvCN2.Rows[i].Cells["TrongSoBV"].Value.ToString() + ", "+ trongso + ", "+ makpicn + ")";
                comm.RunSQL(mconnectstring, msql);
            }
            ev.QFrmThongBao("Chúc mừng bạn đã hoàn thành KPI Cá nhân !");
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

        private void dgvCN_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DataGridViewColumn clickedColumn = dgvCN.Columns[e.ColumnIndex];
                if (clickedColumn != null)
                {
                    for (int i = 0; i < dgvCN.Rows.Count; i++)
                    {
                        dgvCN.Rows[i].Cells["Chon"].Value = true;
                    }
                }
            }
        }

        private void dgvCN2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}