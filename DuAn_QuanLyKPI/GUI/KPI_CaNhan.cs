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

namespace DuAn_QuanLyKPI.GUI
{
    public partial class KPI_CaNhan : DevExpress.XtraEditors.XtraForm
    {
        public static string mconnectstring = "Data Source=192.168.50.108,1433;Initial Catalog=QuanLyKPI;Persist Security Info=True;User ID=sa;Password=123";
        //public static string mconnectstring = "Data Source=LEDUONG\\SQLEXPRESS;Initial Catalog=frmCaNhan;Integrated Security=True";

        DataGridViewCheckBoxColumn dgvcCheckBox = new DataGridViewCheckBoxColumn();


        private clsCommonMethod comm = new clsCommonMethod();
        private clsEventArgs ev = new clsEventArgs("");
        private string msql;

        public static string MaPhieuKPI;
        private static string MaNV = Frm_Login.MaNV;
        private static string MaPhongKhoa = Frm_Login.MaPhongKhoa;
        private static string MaChucDanh = Frm_Login.MaChucDanh;
        private static DateTime now = DateTime.Now;

        public KPI_CaNhan()
        {
            InitializeComponent();
            Loadtxt();
            LoadDB_MucTieu();
            this.Size = new Size(1183, 600);
            txtQTUX.Visible = false;
            btnHoanThanh.Enabled = false;
            panel1.Visible = false;
            panel2.Visible = false;
            tablePanel6.Visible = false;
        }

        private void LoadDB_MucTieu()
        {
            dgvcCheckBox.Name = "cbMT";
            dgvMucTieu.Columns.Add(dgvcCheckBox);
            msql = "select kpi.NoiDung from KPI kpi inner join KPITrongNganHang kpitnh on kpi.MaKPI = kpitnh.MaKPI inner join NganHangKPI nhkpi on kpitnh.MaNganHangKPI = nhkpi.MaNganHangKPI where nhkpi.MaChucDanh = '" + MaChucDanh + "' and nhkpi.MaPK = '" + MaPhongKhoa + "'";
            DataTable dtPKI = comm.GetDataTable(mconnectstring, msql, "KPI");
            dgvMucTieu.ReadOnly = false;
            dgvMucTieu.DataSource = dtPKI;


        }

        private void Loadtxt()
        {
            txtHoTen.ReadOnly = true;
            txtChucDanh.ReadOnly = true;
            txtKhoaPhong.ReadOnly = true;


            //txt lấy Tên Khoa Phòng
            msql = "SELECT TenPK FROM PhongKhoa where MaPK = '" + MaPhongKhoa + "'";
            DataTable dtPK = comm.GetDataTable(mconnectstring, msql, "PhongKhoa");
            txtKhoaPhong.Text = dtPK.Rows[0][0].ToString();


            //txt lấy Tên Chức Danh
            msql = "SELECT TenChucDanh FROM ChucDanh where MaChucDanh = '" + MaChucDanh + "'";
            DataTable dtCD = comm.GetDataTable(mconnectstring, msql, "ChucDanh");
            txtChucDanh.Text = dtCD.Rows[0][0].ToString();


            //txt lấy Tên Người Dùng
            msql = "SELECT TenNV FROM NguoiDung where MaNV = '" + MaNV + "'";
            DataTable dtND = comm.GetDataTable(mconnectstring, msql, "NguoiDung");
            txtHoTen.Text = dtND.Rows[0][0].ToString();
        }


        private void Add_KPI_CaNhan()
        {
            msql = "SELECT * FROM KPI_CaNhan";
            DataTable dtKPICN = comm.GetDataTable(mconnectstring, msql, "KPI_CaNhan");

            string MaPhieuKPI = "KPICN" + (dtKPICN.Rows.Count + 1);
            //string MaNV;
            string TieuDe = "KPI Cá Nhân";
            string NoiDung = "Tỷ lệ hoàn thành công việc của " + txtHoTen.Text;
            string NgayTao = DateTime.Now.ToString("yyyy-MM-dd");
            int Quy = (now.Month - 1) / 3 + 1;
            int Nam = now.Year;
            string MauPhieu = "KPICN";


            //Thêm cá nhân
            try
            {
                msql = "INSERT INTO KPI_CaNhan (MaPhieuKPI, MaNhanVien, TieuDe, NoiDung, NgayTao, Quy, Nam, MauPhieu, TrangThai) VALUES ('" + MaPhieuKPI + "','" + MaNV + "',N'" + TieuDe + "',N'" + NoiDung + "','" + NgayTao + "','" + Quy + "','" + Nam + "','" + MauPhieu + ", 0');";
                DataTable tbKPICN = comm.GetDataTable(mconnectstring, msql, "KPI_CaNhan");
                MessageBox.Show("Thêm thành công");
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra. Vui lòng thử lại");
            }
        }

        private void btnTiepTucQTUX_Click(object sender, EventArgs e)
        {
            tablePanel2.Visible = false;
            panel1.Location = new System.Drawing.Point(82, 167);
            panel2.Location = new System.Drawing.Point(82, 205);
            tablePanel6.Location = new System.Drawing.Point(644, 388);
            panel2.Visible = true;
            tablePanel6.Visible = true;
            panel1.Visible = true;
        }

        private void btnQuayLaiMTCV_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            tablePanel6.Visible = false;
            tablePanel2.Visible = true;

        }


        private void btnTiepTucMTCV_Click(object sender, EventArgs e)
        {
            int checkcb = 0;
            for (int i = 0; i < dgvMucTieu.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell cell = dgvMucTieu.Rows[i].Cells[0] as DataGridViewCheckBoxCell;
                if (cell != null && cell.Value != null && (bool)cell.Value)
                {
                    checkcb++;
                }
            }

            if (checkcb <= dgvMucTieu.Rows.Count / 2)
            {
                MessageBox.Show("Chưa đủ chỉ tiêu !");
            }
            else
            {
                btnHoanThanh.Enabled = true;
            }
        }

        private void btnHoanThanh_Click_1(object sender, EventArgs e)
        {
            Add_KPI_CaNhan();
        }

        private void cbQTUX_CheckedChanged(object sender, EventArgs e)
        {
            txtQTUX.Visible = cbQTUX.Checked;
        }
    }
}