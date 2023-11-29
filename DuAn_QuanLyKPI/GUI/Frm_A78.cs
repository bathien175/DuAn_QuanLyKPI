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

namespace DuAn_QuanLyKPI.GUI
{
    public partial class Frm_A78 : DevExpress.XtraEditors.XtraForm
    {
        private static string mconnectstring = Database.mconnectstring;
        private clsCommonMethod comm = new clsCommonMethod();
        private clsEventArgs ev = new clsEventArgs("");
        private string msql;

        //private List<int> listMaKPI = new List<int> { 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 55, 6, 63, 2, 4, 6, 4, 52,55 };


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
            //List<string> listNoiDung = new List<string>();
            //foreach (int i in listMaKPI)
            //{
            //    msql = "SELECT kpi.NoiDung " +
            //        "FROM dbo.KPI kpi " +
            //        "WHERE kpi.MaKPI = '" + i + "'";
            //    DataTable dt = comm.GetDataTable(mconnectstring, msql, "KPI");
            //    if (dt.Rows.Count > 0)
            //    {
            //        dgvCN.Rows.Add(dt.Rows[0]["NoiDung"].ToString());

            //        int rowIndex = dgvCN.Rows.Count - 1;
            //        dgvCN.Rows[rowIndex].Cells[1].Value = i.ToString();
            //    }
            //}


            msql = "SELECT p.MaPhieuKPI,p.MaKPI, k.NoiDung ,p.TrongSoKPIBV FROM [QuanLyKPI].[dbo].[PhieuKPITongHop] p inner join KPI k on k.MaKPI = p.MaKPI where p.MaPK = 'CNTT' and p.TruongPK = 'false' and p.CongViecCaNhan = 'true'";
            DataTable dt = comm.GetDataTable(mconnectstring, msql, "KPI");
            dgvCN.DataSource = dt;
        }

        private void copyDataCNtoCN2()
        {
            dgvCN2.Rows.Clear();

            for (int i = 0; i < dgvCN.Rows.Count; i++)
            {
                if (dgvCN.Rows[i].Cells["Chon"].Value != null && (bool)dgvCN.Rows[i].Cells["Chon"].Value)
                {
                    int n = dgvCN2.Rows.Add();
                    dgvCN2.Rows[n].Cells["NoiDung2"].Value = dgvCN.Rows[i].Cells["NoiDung"].Value.ToString();
                    dgvCN2.Rows[n].Cells["TrongSoBV"].Value = dgvCN.Rows[i].Cells["TrongSo"].Value.ToString();
                    dgvCN2.Rows[n].Cells["MaPhieuKPI2"].Value = dgvCN.Rows[i].Cells["MaPhieuKPI"].Value.ToString();
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
                dgvHT.Rows[n].Cells["MaPhieuKPIHT"].Value = dgvCN2.Rows[i].Cells["MaPhieuKPI2"].Value.ToString();
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
                dgvCN.Rows[i].Cells["Chon"].Value = true;
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
            for (int i = 0; i < dgvHT.Rows.Count; i++)
            {
                string makpi = dgvHT.Rows[i].Cells["MaKPIHT"].Value.ToString();
                string trongso = dgvHT.Rows[i].Cells["TrongSoHTHT"].Value.ToString();
                string maphieukpi = dgvHT.Rows[i].Cells["MaPhieuKPIHT"].Value.ToString();

                msql = "insert into KPI_CaNhan values ('"+ maphieukpi + "','" + Frm_Login.MaNV + "', " + makpi + ",GETDATE()," + GetQuy() + "," + DateTime.Now.Year + ",0, " + trongso + ")";
                comm.RunSQL(mconnectstring, msql);
            }
            ev.QFrmThongBao("Chúc mừng bạn đã hoàn thành KPI Cá nhân !");
        }

        private void btnExel_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            app.Visible = true;
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            for (int i = 1; i < dgvHT.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dgvHT.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < dgvHT.Rows.Count; i++)
            {
                for (int j = 0; j < dgvHT.Columns.Count; j++)
                {
                    if (dgvHT.Rows[i].Cells[j].Value != null)
                    {
                        worksheet.Cells[i + 2, j + 1] = dgvHT.Rows[i].Cells[j].Value.ToString();
                    }
                    else
                    {
                        worksheet.Cells[i + 2, j + 1] = "";
                    }
                }
            }


            //// Thiết lập tiêu đề cho bảng
            //worksheet.Cells[1, 1].Value = "Họ và tên";
            //worksheet.Cells[1, 2].Value = "Chức danh";
            //worksheet.Cells[1, 3].Value = "Mã nhân viên";
            //worksheet.Cells[1, 4].Value = "Khoa Phòng Bộ phận";
        }
    }
}