using BusinessCommon;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuAn_QuanLyKPI.GUI
{
    public partial class Frm_KPI_CaNhan : DevExpress.XtraEditors.XtraForm
    {
        private string mconnectstring = Database.mconnectstring;
        private clsCommonMethod comm = new clsCommonMethod();
        private clsEventArgs ev = new clsEventArgs("");
        private string msql;
        private List<int> listMaKPI = new List<int> { 4, 5, 6, 7, 8 };

        private string MaNV;
        private string MaPhongKhoa;
        private string MaChucDanh;
        private static DateTime now = DateTime.Now;
        public Frm_KPI_CaNhan(string manv, string maphongkhoa, string machucdanh)
        {
            InitializeComponent();
            this.MaNV = manv;
            this.MaChucDanh = machucdanh;
            this.MaPhongKhoa = maphongkhoa;
        }


        private void Frm_KPI_CaNhan_Load(object sender, EventArgs e)
        {
            Loadtxt();
            txtQTUX.Visible = false;
            btnHoanThanh.Enabled = false;
            tableLayoutPanel2.Enabled = false;
        }

        private void LoadDB_MucTieu()
        {
            List<string> listNoiDung = new List<string>();
            dgvMucTieu.Columns.Add("", "");
            foreach (int i in listMaKPI)
            {
                msql = "SELECT NoiDung FROM KPI WHERE MaKPI = '" + i + "'";
                DataTable noidung = comm.GetDataTable(mconnectstring, msql, "KPI");

                if (noidung.Rows.Count > 0)
                {
                    dgvMucTieu.Rows.Add(noidung.Rows[0]["NoiDung"].ToString(),"");
                }
               
            }
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
        private void cbQTUX_CheckedChanged(object sender, EventArgs e)
        {
            txtQTUX.Visible = cbQTUX.Checked;

        }

        private void btnTiepTucMTCV_Click(object sender, EventArgs e)
        {
            int checkcb = 0;

            for (int i = 0; i < dgvMucTieu.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell cell = dgvMucTieu.Rows[i].Cells[0] as DataGridViewCheckBoxCell;
                //cell.Value = true;

                if (cell != null && cell.Value != null && (bool)cell.Value)
                {
                    checkcb++;
                }
            }
            if (checkcb < dgvMucTieu.Rows.Count)
            {
                MessageBox.Show("Chưa đủ chỉ tiêu !");
            }
            else
            {
                btnHoanThanh.Enabled = true;
            }
        }

        private void btnTiepTucQTUX_Click_1(object sender, EventArgs e)
        {
            LoadDB_MucTieu();
            dgvMucTieu.Visible = true;
            tableLayoutPanel2.Enabled = true;
        }

        private void btnQuayLaiMTCV_Click(object sender, EventArgs e)
        {
            txtHoTen.ReadOnly = false;
            txtChucDanh.ReadOnly = false;
            txtKhoaPhong.ReadOnly = false;
            dgvMucTieu.Visible = false;
        }
    }
}