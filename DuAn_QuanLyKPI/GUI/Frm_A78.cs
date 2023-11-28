using BusinessCommon;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DevExpress.XtraPrinting.Native.ExportOptionsPropertiesNames;

namespace DuAn_QuanLyKPI.GUI
{
    public partial class Frm_A78 : DevExpress.XtraEditors.XtraForm
    {
        private static string mconnectstring = Database.mconnectstring;
        private clsCommonMethod comm = new clsCommonMethod();
        private clsEventArgs ev = new clsEventArgs("");
        private string msql;

        private List<int> listMaKPI = new List<int> { 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 55, 6, 63, 2, 4, 6, 4, 52,55 };


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
            List<string> listNoiDung = new List<string>();
            foreach (int i in listMaKPI)
            {
                msql = "SELECT kpi.NoiDung " +
                    "FROM dbo.KPI kpi " +
                    "WHERE kpi.MaKPI = '" + i + "'";
                DataTable dt = comm.GetDataTable(mconnectstring, msql, "KPI");
                if (dt.Rows.Count > 0)
                {
                    dgvCN.Rows.Add(dt.Rows[0]["NoiDung"].ToString());

                    int rowIndex = dgvCN.Rows.Count - 1;
                    dgvCN.Rows[rowIndex].Cells[1].Value = i.ToString();
                }
            }
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
               
            }
        }

        public void GetQuy()
        {
            DateTime currentDate = DateTime.Now;
            int result = (currentDate.Month - 1) / 3 + 1;
            label3.Text = "QUÝ " + result + "";
            label5.Text = "QUÝ " + result + "";
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
            msql = "INSERT INTO [dbo].[KPI_CaNhan]
           ([MaPhieuKPI]
           ,[MaNhanVien]
           ,[NgayTaoCaNhan]
           ,[Quy]
           ,[Nam]
           ,[TrangThai]
           ,[TrongSo]
           ,[MaKPI])
     VALUES
           ('"+  +"'
           ,'"+  +"'
           ,'"+  +"'
           ,'"+  +"'
           ,'"+  +"'
           ,'"+  +"'
           ,'"+  +"'
           ,'"+  +"'";
            comm.RunSQL(mconnectstring, msql);
        }
    }
}