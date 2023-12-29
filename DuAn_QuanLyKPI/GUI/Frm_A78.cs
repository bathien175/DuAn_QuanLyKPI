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
using DevExpress.CodeParser;
using System.Reflection.Emit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using DevExpress.Data.Linq.Helpers;
using DevExpress.XtraPrinting.Native;
using static DevExpress.Xpo.Helpers.AssociatedCollectionCriteriaHelper;
using System.Globalization;
using System.Data.Entity;

namespace DuAn_QuanLyKPI.GUI
{
    public partial class Frm_A78 : DevExpress.XtraEditors.XtraForm
    {
        //private string mconnectstring = "Data Source=192.168.50.108,1433;Initial Catalog=QuanLyKPI;Persist Security Info=True;User ID=sa;Password=123";
        private string mconnectstring = "Data Source=LEDUONG\\LEDUONG;Initial Catalog=QuanLyKPI;Persist Security Info=True;User ID=sa;Password=123";

        private clsCommonMethod comm = new clsCommonMethod();
        private clsEventArgs ev = new clsEventArgs("");
        private string msql;
        private string MaPhieuKPIKP;
        private string QuyNam = $"{(DateTime.Now.Month - 1) / 3 + 1}{DateTime.Now.Year}";
        private int Quy = ((DateTime.Now.Month - 1) / 3 + 1);
        private int Nam = DateTime.Now.Year;
        private string yyyyMMddHHmmss = DateTime.Now.ToString("yyyyMMddHHmmss");
        private string MaNV = Frm_Login.MaNV;
        private string TenNV = Frm_Login.TenNV;
        private string TenChucDanh = Frm_Login.TenChucDanh;
        private string MaPhongKhoa = Frm_Login.MaPhongKhoa;
        private string MaChucDanh = Frm_Login.MaChucDanh;
        private string TenPhongKhoa = Frm_Login.TenPhongKhoa;
        private string Email = Frm_Login.Email;
        private string SDT = Frm_Login.SDT;
        private int CapDoBieuMauKPI = Frm_Login.CapDoBieuMauKPI;
        Timer Time1;

        public Frm_A78()
        {
            InitializeComponent();
            LoadThongTinNhanVien();
            Load_DGV_MTBB();

            Time1 = new Timer { Interval = 100 };
            Time1.Tick += UpdateTimer_Tick;
        }
        #region Method
        private void LoadThongTinNhanVien()
        {
            txtTenNV1.Text = TenNV;
            txtTenNV2.Text = TenNV;
            txtTenNV3.Text = TenNV;

            txtViTriCV1.Text = TenChucDanh;
            txtViTriCV2.Text = TenChucDanh;
            txtViTriCV3.Text = TenChucDanh;

            txtKhoaPhong1.Text = TenPhongKhoa;
            txtKhoaPhong2.Text = TenPhongKhoa;
            txtKhoaPhong3.Text = TenPhongKhoa;

            label10.Text = "MỤC TIÊU CÁ NHÂN - QUÝ " + Quy + " NĂM " + Nam + "";
            label6.Text = "MỤC TIÊU CÁ NHÂN - QUÝ " + Quy + " NĂM " + Nam + "";
            label7.Text = "MỤC TIÊU CÁ NHÂN - QUÝ " + Quy + " NĂM " + Nam + "";
        }
        private void Load_DGV_MTBB()
        {
            msql = "SELECT * FROM KPI_KhoaPhong " +
                "where MaPK = '" + MaPhongKhoa + "' " +
                "and IDBieuMau = '78' " +
                "and QuyNam = '" + QuyNam + "'";
            DataTable dtt = comm.GetDataTable(mconnectstring, msql, "KPI");
            MaPhieuKPIKP = dtt.Rows[0]["MaPhieuKPIKP"].ToString();

            msql = "SELECT A.MaKPI, B.NoiDung, B.PhuongPhapDo, B.DonViTinh, A.TrongSoKPIKP, E.TenPK, A.ChiTieu " +
                "FROM ChiTietTieuChiMucTieuKhoaPhong as A, KPI as B, KPITrongNganHang as C, NganHangKPI as D, PhongKhoa as E " +
                "where A.MaKPI = B.MaKPI " +
                "and C.MaKPI = B.MaKPI " +
                "and D.MaNganHangKPI = C.MaNganHangKPI " +
                "and E.MaPK = D.MaPK " +
                "and A.MaPhieuKPIKP = '" + MaPhieuKPIKP + "' " +
                "and B.CongViecCaNhan = 'true' " +
                "and D.MaPK = '" + MaPhongKhoa + "' " +
                "and (D.MaChucDanh like 'PTP%' or D.MaChucDanh like 'PTK%') " +
                "order by A.MaKPI";
            DataTable dt = comm.GetDataTable(mconnectstring, msql, "KPI");
            dgvKPICN_MTBB.DataSource = dt;

            // Đổi kế hoạch của cột phương pháp đo và cột nội dung
            foreach (DataGridViewRow row in dgvKPICN_MTBB.Rows)
            {
                string phuongPhapDo = row.Cells["PPD_MTBB"].Value.ToString();
                string noiDung = row.Cells["ND_MTBB"].Value.ToString();

                if (noiDung.Contains(" X ") || noiDung.Contains(" X%") || noiDung.Contains(" X.") || noiDung.Contains(" Xlần"))
                {
                    phuongPhapDo = phuongPhapDo.Replace("X", row.Cells["KH_MTBB"].Value.ToString().Trim());
                    noiDung = noiDung.Replace("X", row.Cells["KH_MTBB"].Value.ToString().Trim());
                }
                else if (noiDung.Contains("dd/mm/yyyy"))
                {
                    phuongPhapDo = phuongPhapDo.Replace("dd/mm/yyyy", row.Cells["KH_MTBB"].Value.ToString().Trim());
                    noiDung = noiDung.Replace("dd/mm/yyyy", row.Cells["KH_MTBB"].Value.ToString().Trim());
                }
                row.Cells["PPD_MTBB"].Value = phuongPhapDo;
                row.Cells["ND_MTBB"].Value = noiDung;
            }

            dgvKPICN_MTBB.CurrentCellDirtyStateChanged += Dgv1_CurrentCellDirtyStateChanged;
            dgvKPICN_MTBB.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        private int SumTrongSo_MTBB()
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
                    dgvKPICN_MTBB2.Rows[n].Cells["KH2_MTBB"].Value = dgvKPICN_MTBB.Rows[i].Cells["KH_MTBB"].Value.ToString();
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
                dgvKPICN_HTMTBB.Rows[n].Cells["KH_HTMTBB"].Value = dgvKPICN_MTBB2.Rows[i].Cells["KH2_MTBB"].Value.ToString();
                dgvKPICN_HTMTBB.Rows[n].Cells["TH_HTMTBB"].Value = dgvKPICN_MTBB2.Rows[i].Cells["TH2_MTBB"].Value.ToString();
            }
        }
        private void Load_DGV_MTT()
        {
            msql = "SELECT a.MaKPI_DKT, b.NoiDung, a.TrongSoKPIDK, b.DonViTinh, b.PhuongPhapDo, e.TenPK, a.ChiTieu " +
                "FROM ChiTietDangKiThem_KPICaNhan a " +
                "inner join KPI b on a.MaKPI = b.MaKPI " +
                "inner join KPITrongNganHang c on c.MaKPI = b.MaKPI " +
                "inner join NganHangKPI d on d.MaNganHangKPI = c.MaNganHangKPI " +
                "inner join PhongKhoa e on d.MaPK = e.MaPK " +
                "WHERE a.MaKPI IS NOT NULL " +
                "and e.MaPK = '" + MaPhongKhoa + "' " +
                "and a.MaNV = '" + MaNV + "' " +
                "and a.QuyNam = '" + QuyNam + "'" +
                "and (d.MaChucDanh like 'PTP%' or d.MaChucDanh like 'PTK%')";
            DataTable dtA = comm.GetDataTable(mconnectstring, msql, "DangKiMuctieuThem1");

            msql = "SELECT MaKPI_DKT, NoiDung, TrongSoKPIDK, DonViTinh, PhuongPhapDo, c.TenPK, a.ChiTieu " +
                "FROM ChiTietDangKiThem_KPICaNhan a " +
                "inner join NguoiDung b on a.MaNV = b.MaNV " +
                "inner join PhongKhoa c on b.MaPhongKhoa = c.MaPK " +
                "WHERE MaKPI IS NULL " +
                "and a.MaNV = '" + MaNV + "' " +
                "and a.QuyNam = '" + QuyNam + "'";
            DataTable dtB = comm.GetDataTable(mconnectstring, msql, "DangKiMuctieuThem2");

            DataTable MTT = new DataTable();
            MTT = dtA.Copy();
            MTT.Merge(dtB);

            if (MTT.Rows.Count > 0)
            {
                dgvKPICN_MTT.DataSource = MTT;

                // Đổi giá trị của cột phương pháp đo và  nội dung
                foreach (DataGridViewRow row in dgvKPICN_MTT.Rows)
                {
                    string phuongPhapDo = row.Cells["PPD_MTT"].Value.ToString();
                    string noiDung = row.Cells["ND_MTT"].Value.ToString();

                    if (noiDung.Contains(" X ") || noiDung.Contains(" X%"))
                    {
                        //thay thế giá trị X của cột PPD và ND bằng giá trị của cột Kế hoạch(Chỉ tiêu)
                        phuongPhapDo = phuongPhapDo.Replace("X", row.Cells["KH_MTT"].Value.ToString().Trim());
                        noiDung = noiDung.Replace("X", row.Cells["KH_MTT"].Value.ToString().Trim());
                    }
                    else if (noiDung.Contains("dd/mm/yyyy"))
                    {
                        //thay thế giá trị dd/mm/yyyy của cột PPD và ND bằng giá trị của cột Kế hoạch(Chỉ tiêu)
                        phuongPhapDo = phuongPhapDo.Replace("dd/mm/yyyy", row.Cells["KH_MTT"].Value.ToString().Trim());
                        noiDung = noiDung.Replace("dd/mm/yyyy", row.Cells["KH_MTT"].Value.ToString().Trim());
                    }
                    row.Cells["PPD_MTT"].Value = phuongPhapDo;
                    row.Cells["ND_MTT"].Value = noiDung;
                }
            }
            else
            {
                ev.QFrmThongBao("Không có mục tiêu thêm !");
                tabMucTieuKhoaPhong.SelectTab(2);
            }

        }
        private int SumTrongSo_MTT()
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
                dgvKPICN_HTMTT.Rows[n].Cells["KH_HTMTT"].Value = dgvKPICN_MTT.Rows[i].Cells["KH_MTT"].Value.ToString();
                dgvKPICN_HTMTT.Rows[n].Cells["TH_HTMTT"].Value = dgvKPICN_MTT.Rows[i].Cells["TH_MTT"].Value.ToString();
            }
        }

        #endregion
        #region Event
        private void btnTiepTucTaiChinh_Click(object sender, EventArgs e)
        {
            if (SumTrongSo_MTBB() == 0)
            {
                ev.QFrmThongBao("Vui lòng nhập đầy đủ !");
                return;
            }
            else if (SumTrongSo_MTBB() < 100)
            {
                ev.QFrmThongBao("Trọng số bé hơn 100% !");
            }
            else if (SumTrongSo_MTBB() > 100)
            {
                ev.QFrmThongBao("Trọng số lớn hơn 100% !");
            }
            tabMucTieuKhoaPhong.SelectTab(2);

            if (cbQTUX.Checked == true)
                txtQTUXHT.Text = txtQTUX.Text;
            copyDataCN2toHT();
        }
        private void btnDangKiThem_Click(object sender, EventArgs e)
        {
            if (cbQTUX.Checked == true)
                txtQTUXMTT.Text = txtQTUX.Text;
            tabMucTieuKhoaPhong.SelectTab(1);
            Load_DGV_MTT();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtQTUX.Enabled = cbQTUX.Checked;
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
            txtTongTrongSoCaNhan.Text = Convert.ToString(SumTrongSo_MTBB());
        }

        private void btnTTpnDKTPK_Click(object sender, EventArgs e)
        {
            if (SumTrongSo_MTT() == 0)
            {
                ev.QFrmThongBao("Vui lòng nhập đầy đủ !");
                return;
            }
            else if (SumTrongSo_MTT() < 100)
            {
                ev.QFrmThongBao("Trọng số bé hơn 100% !");
            }
            else if (SumTrongSo_MTT() > 100)
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
            txtTongTrongSoMucTieuThem.Text = SumTrongSo_MTT().ToString();
        }
        private void btnQLtabDKMTT_Click(object sender, EventArgs e)
        {
            tabMucTieuKhoaPhong.SelectTab(0);
        }
        private void btnQuayLaiHoanThanh_Click(object sender, EventArgs e)
        {
            tabMucTieuKhoaPhong.SelectTab(0);
        }
        private void btnHoanThanh_Click(object sender, EventArgs e)
        {
            string MaPhieuKPICN = "KPICN" + yyyyMMddHHmmss + "";
            msql = "INSERT INTO [dbo].[KPI_CaNhan] " +
                "([MaPhieuKPICN],[MaPhieuKPIKP],[QuyTacUngXu],[TrongSoQuyTacUngXu],[IDBieuMau],[MaNV],[QuyNam],[NgayLapPhieuKPICN],TrangThai) " +
                "VALUES " +
                "('" + MaPhieuKPICN + "','" + MaPhieuKPIKP + "','" + txtQTUXHT.Text + "','10','78','" + Frm_Login.MaNV + "','" + QuyNam + "', GETDATE(),0)";
            comm.RunSQL(mconnectstring, msql);

            //KPI cá nhân bắt buộc
            for (int i = 0; i < dgvKPICN_HTMTBB.Rows.Count; i++)
            {
                string makpi = dgvKPICN_HTMTBB.Rows[i].Cells["MaKPI_HTMTBB"].Value.ToString();
                string trongsoHT = dgvKPICN_HTMTBB.Rows[i].Cells["TSHT_HTMTBB"].Value.ToString();
                string kehoach = dgvKPICN_HTMTBB.Rows[i].Cells["KH_HTMTBB"].Value.ToString() ?? "";
                string thuchien = dgvKPICN_HTMTBB.Rows[i].Cells["TH_HTMTBB"].Value.ToString() ?? "";

                msql = "INSERT INTO [dbo].[ChiTietKPICaNhan] " +
                    "([MaPhieuKPICN],[MaKPI],[TrongSoKPICN],[NguonChungMinh],KeHoach, ThucHien) " +
                    "VALUES " +
                    "('" + MaPhieuKPICN + "','" + makpi + "','" + trongsoHT + "','" + MaPhongKhoa + "',N'" + kehoach + "',N'" + thuchien + "')";
                comm.RunSQL(mconnectstring, msql);
            }

            //KPI cá nhân đăng kí thêm
            for (int i = 0; i < dgvKPICN_HTMTT.Rows.Count; i++)
            {
                string makpi = dgvKPICN_HTMTT.Rows[i].Cells["MaKPI_HTMTT"].Value.ToString();
                string trongsoHT = dgvKPICN_HTMTT.Rows[i].Cells["TSHT_HTMTT"].Value.ToString();
                string kehoach = dgvKPICN_HTMTT.Rows[i].Cells["KH_HTMTT"].Value.ToString() ?? "";
                string thuchien = dgvKPICN_HTMTT.Rows[i].Cells["TH_HTMTT"].Value.ToString() ?? "";

                msql = "INSERT INTO [dbo].[ChiTietKPICaNhan] " +
                    "([MaPhieuKPICN],[MaKPI_DKT],[TrongSoKPICN],[NguonChungMinh],KeHoach, ThucHien) " +
                    "VALUES " +
                    "('" + MaPhieuKPICN + "','" + makpi + "','" + trongsoHT + "','" + MaPhongKhoa + "',N'" + kehoach + "',N'" + thuchien + "')";
                comm.RunSQL(mconnectstring, msql);
            }

            ev.QFrmThongBao("Chúc mừng bạn đã hoàn thành KPI Cá nhân !");
        }
        private void btnExel_Click(object sender, EventArgs e)
        {

            if (ev.QFrmThongBao_YesNo("Bạn có chắc muốn tiếp tục không? Hãy kiểm tra thật kĩ thông tin trước khi Hoàn thành nhé!"))
            {
                //đường dẫn đến file excel sẵn có
                string existingFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "A78.xlsx");
                AddDataGridViewsToExistingExcelSheet(dgvKPICN_HTMTBB, dgvKPICN_HTMTT, existingFilePath);
            }
        }

        private void AddDataGridViewsToExistingExcelSheet(DataGridView dgvKPICN_MTBB, DataGridView dgvKPICN_MTT, string existingFilePath)
        {
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
            worksheet.Cells[2, 3] = "KPI CÁ NHÂN - QUÝ " + Quy + " /  " + Nam + "";  // Ngày tháng C2
            worksheet.Cells[4, 4] = TenNV.Trim(); // Tên nhân viên vào D4
            worksheet.Cells[5, 4] = MaNV.Trim(); // Mã nhân viên vào D5
            worksheet.Cells[4, 8] = TenChucDanh.Trim(); // Tên chức danh vào G4
            worksheet.Cells[5, 8] = TenPhongKhoa.Trim(); // Tên khoa phòng vào G5
            worksheet.Cells[9, 3] = txtQTUXHT.Text.Trim();  // Quy tắc ứng xử vào C9
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
                worksheet.Cells[i + 12, 3] = dgvKPICN_MTBB.Rows[i].Cells["ND_HTMTBB"].Value.ToString().Trim();//nội dung mục tiêu đánh giá
                worksheet.Cells[i + 12, 4] = float.Parse(dgvKPICN_MTBB.Rows[i].Cells["TSHT_HTMTBB"].Value.ToString().Trim()) / 100;//trọng số hoàn thành
                worksheet.Cells[i + 12, 5] = dgvKPICN_MTBB.Rows[i].Cells["PPD_HTMTBB"].Value.ToString().Trim();//phương pháp đo
                worksheet.Cells[i + 12, 6] = dgvKPICN_MTBB.Rows[i].Cells["NCM_HTMTBB"].Value.ToString().Trim();//nguồn chứng minh
                worksheet.Cells[i + 12, 7] = dgvKPICN_MTBB.Rows[i].Cells["DVT_HTMTBB"].Value.ToString().Trim();//đơn vị tính
                worksheet.Cells[i + 12, 8] = dgvKPICN_MTBB.Rows[i].Cells["KH_HTMTBB"].Value.ToString().Trim();//kế hoạch
                worksheet.Cells[i + 12, 9] = dgvKPICN_MTBB.Rows[i].Cells["TH_HTMTBB"].Value.ToString().Trim();//thực hiện
                worksheet.Cells[i + 12, 10] = "=IF(AND(I" + (i + 12) + "<>\"\",I" + (i + 12) + "<=H" + (i + 12) + "),I" + (i + 12) + "/H" + (i + 12) + "*100%,0%)";//công thức tính Tỷ lệ (%) hoàn thành
                worksheet.Cells[i + 12, 11] = "=D" + (i + 12) + "*J" + (i + 12) + "";//công thức tính kết quả KPI

                if (i < dgvKPICN_MTBB.RowCount - 1)
                {
                    worksheet.Rows[i + 12].Insert();
                    worksheet.Rows[i + 12 + 1].Copy(worksheet.Rows[i + 12]);
                }
            }

            //MỤC TIÊU ĐĂNG KÍ THÊM (dòng 14 + số dòng mục tiêu bắt buộc)
            for (int i = 0; i < dgvKPICN_MTT.RowCount; i++)
            {
                stt++;
                worksheet.Cells[i + 13 + dgvKPICN_MTBB.RowCount, 2] = stt;//số thứ tự đầu dòng
                worksheet.Cells[i + 13 + dgvKPICN_MTBB.RowCount, 3] = dgvKPICN_MTT.Rows[i].Cells["ND_HTMTT"].Value.ToString().Trim();//nội dung mục tiêu đánh giá
                worksheet.Cells[i + 13 + dgvKPICN_MTBB.RowCount, 4] = float.Parse(dgvKPICN_MTT.Rows[i].Cells["TSHT_HTMTT"].Value.ToString().Trim()) / 100;//trọng số hoàn thành
                worksheet.Cells[i + 13 + dgvKPICN_MTBB.RowCount, 5] = dgvKPICN_MTT.Rows[i].Cells["PPD_HTMTT"].Value.ToString().Trim();//phương pháp đo
                worksheet.Cells[i + 13 + dgvKPICN_MTBB.RowCount, 6] = dgvKPICN_MTT.Rows[i].Cells["NCM_HTMTT"].Value.ToString().Trim();//nguồn chứng minh
                worksheet.Cells[i + 13 + dgvKPICN_MTBB.RowCount, 7] = dgvKPICN_MTT.Rows[i].Cells["DVT_HTMTT"].Value.ToString().Trim();//đơn vị tính
                worksheet.Cells[i + 13 + dgvKPICN_MTBB.RowCount, 8] = dgvKPICN_MTT.Rows[i].Cells["KH_HTMTT"].Value.ToString().Trim();//kế hoạch
                worksheet.Cells[i + 13 + dgvKPICN_MTBB.RowCount, 9] = dgvKPICN_MTT.Rows[i].Cells["TH_HTMTT"].Value.ToString().Trim();//thực hiện
                worksheet.Cells[i + 13 + dgvKPICN_MTBB.RowCount, 10] = "=IF(AND(I" + (i + 13 + dgvKPICN_MTBB.RowCount) + "<>\"\",I" + (i + 13 + dgvKPICN_MTBB.RowCount) + "<=H" + (i + 13 + dgvKPICN_MTBB.RowCount) + "),I" + (i + 13 + dgvKPICN_MTBB.RowCount) + "/H" + (i + 13 + dgvKPICN_MTBB.RowCount) + "*100%,0%)";//công thức tính Tỷ lệ (%) hoàn thành
                worksheet.Cells[i + 13 + dgvKPICN_MTBB.RowCount, 11] = "=D" + (i + 13 + dgvKPICN_MTBB.RowCount) + "*J" + (i + 13 + dgvKPICN_MTBB.RowCount) + "";//công thức tính kết quả KPI

                if (i < dgvKPICN_MTT.RowCount - 1)
                {
                    worksheet.Rows[i + 14 + dgvKPICN_MTBB.RowCount].Insert();
                    worksheet.Rows[i + 14 + dgvKPICN_MTBB.RowCount - 1].Copy(worksheet.Rows[i + 14 + dgvKPICN_MTBB.RowCount]);
                }
            }
            worksheet.Cells[(dgvKPICN_MTBB.RowCount + dgvKPICN_MTT.RowCount + 13), 4] = "=SUM(D12:D" + (dgvKPICN_MTBB.RowCount + dgvKPICN_MTT.RowCount + 12) + ")";//công thức tính tổng trọng số mục tiêu
            worksheet.Cells[10, 11] = "=SUM(K12:K" + (dgvKPICN_MTBB.RowCount + dgvKPICN_MTT.RowCount + 12) + ")*D10";//công thức tính tổng trọng số mục tiêu công việc

            // Tự động điều chỉnh kích thước của hàng
            worksheet.Rows.AutoFit();

            // Lưu file
            string tenfile = "" + Frm_Login.MaNV + "_" + yyyyMMddHHmmss + "";
            workbook.SaveAs("" + tenfile + ".xlsx");
        }
        #endregion
    }
}
//viết hàm check nếu chưa nhập đủ trọng số bắt buộc
//thêm trường ChiTieu trong bảng ChiTietTieuChiMucTieuKhoaPhong