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

            msql = "SELECT A.MaKPI, B.NoiDung, B.PhuongPhapDo, B.DonViTinh, A.TrongSoKPIKP " +
                "FROM ChiTietTieuChiMucTieuKhoaPhong as A, KPI as B " +
                "where A.MaKPI = B.MaKPI " +
                "and A.MaPhieuKPIKP = '" + maphieukpikp + "' " +
                "and B.CongViecCaNhan = 'true'";
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
            msql = "SELECT a.MaKPI_DKT, a.MaNV, a.QuyNam, b.NoiDung, a.TrongSoKPIDK, b.DonViTinh, b.PhuongPhapDo " +
                "FROM ChiTietDangKiThem_KPICaNhan a " +
                "inner join KPI b on a.MaKPI = b.MaKPI " +
                "WHERE a.MaKPI IS NOT NULL";
            DataTable dtA = comm.GetDataTable(mconnectstring, msql, "DangKiMuctieuThem1");

            msql = "SELECT MaKPI_DKT, MaNV, QuyNam, NoiDung, TrongSoKPIDK, DonViTinh, PhuongPhapDo " +
                "FROM ChiTietDangKiThem_KPICaNhan " +
                "WHERE MaKPI IS NULL";
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
                string existingFilePath = Path.Combine("D:\\ThucTap\\Projects\\DuAn_QuanLyKPI\\DuAn_QuanLyKPI\\DuAn_QuanLyKPI\\DuAn_QuanLyKPI\\bin\\Debug", "A78.xlsx");
                // Pass the full path to the function
                AddDataGridViewsToExistingExcelSheet(dgvKPICN_HTMTBB, dgvKPICN_HTMTT, existingFilePath);
            }
        }

        private void AddDataGridViewsToExistingExcelSheet(DataGridView dgvKPICN_MTBB, DataGridView dgvKPICN_MTT, string existingFilePath)
        {
            // Mở một workbook Excel đã có sẵn
            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = true;
            Excel.Workbook workbook = excelApp.Workbooks.Open(existingFilePath);

            Excel.Worksheet worksheet = workbook.Sheets["A7.8"];

            if (worksheet == null)
            {
                ev.QFrmThongBaoError("Không tìm thấy worksheet có tên A7.8 trong file Excel.");
                workbook.Close();
                excelApp.Quit();
                return;
            }
            worksheet.Cells[10, 3] = txtQTUXHT.Text;  // TextBox1 vào C9
            worksheet.Cells[4, 4] = txtTenNV.Text; // TextBox2 vào D4
            worksheet.Cells[5, 4] = Frm_Login.MaNV.ToString(); // TextBox3 vào D5
            worksheet.Cells[4, 8] = Frm_Login.MaCD; // TextBox4 vào G4
            worksheet.Cells[5, 8] = Frm_Login.MaPK; // TextBox4 vào G5


            // Sao chép dữ liệu từ mỗi DataGridView sang worksheet
            //MỤC TIÊU BẮT BUỘC
            int stt = 0;
            for (int i = 0; i < dgvKPICN_MTBB.RowCount; i++)
            {
                stt++;
                worksheet.Cells[i + 12, 2] = stt;//số thứ tự đầu dòng
                worksheet.Cells[i + 12, 3] = dgvKPICN_MTBB.Rows[i].Cells[1].Value.ToString();//nội dung mục tiêu đánh giá
                worksheet.Cells[i + 12, 4] = int.Parse(dgvKPICN_MTBB.Rows[i].Cells[2].Value.ToString()) / 100;//trọng số
                worksheet.Cells[i + 12, 11] = "=D"+(i+12)+"*J"+(i+12)+"";

                if(i < dgvKPICN_MTBB.RowCount - 1)
                    worksheet.Rows[i + 13].Insert();
            }

            // Lưu workbook
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