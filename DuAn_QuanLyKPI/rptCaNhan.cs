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
using System.Data.SqlClient;
using System.Reflection;
using DevExpress.Utils.Extensions;
using Point = System.Drawing.Point;
using DevExpress.XtraPrinting.Native;
using DevExpress.XtraExport.Helpers;

namespace rptCaNhan
{
    public partial class rptCaNhan : DevExpress.XtraEditors.XtraForm
    {
        public static string mconnectstring = "Data Source=192.168.50.108,1433;Initial Catalog=QuanLyKPI;User ID=sa;Password=123";
        //public static string mconnectstring = "Data Source=LEDUONG\\SQLEXPRESS;Initial Catalog=frmCaNhan;Integrated Security=True";

        DataGridViewCheckBoxColumn dgvcCheckBox = new DataGridViewCheckBoxColumn();


        private clsCommonMethod comm = new clsCommonMethod();
        private clsEventArgs ev = new clsEventArgs("");
        private string msql;

        public static string MaPhieuKPI;
        private static string MaNV = frmLogin.MaNV;
        private static string MaPhongKhoa = frmLogin.MaPhongKhoa;
        private static string MaChucDanh = frmLogin.MaChucDanh;
        private static DateTime now = DateTime.Now;

        public rptCaNhan()
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
            msql = "select kpi.NoiDung from KPI kpi inner join KPITrongNganHang kpitnh on kpi.MaKPI = kpitnh.MaKPI inner join NganHangKPI nhkpi on kpitnh.MaNganHangKPI = nhkpi.MaNganHangKPI where nhkpi.MaChucDanh = '"+ MaChucDanh + "' and nhkpi.MaPK = '"+ MaPhongKhoa + "'";
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
            msql = "SELECT TenPK FROM PhongKhoa where MaPK = '"+ MaPhongKhoa +"'";
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
                msql = "INSERT INTO KPI_CaNhan (MaPhieuKPI, MaNhanVien, TieuDe, NoiDung, NgayTao, Quy, Nam, MauPhieu) VALUES ('" + MaPhieuKPI + "','" + MaNV + "',N'" + TieuDe + "',N'" + NoiDung + "','" + NgayTao + "','" + Quy + "','" + Nam + "','" + MauPhieu + "');";
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
            //bật tắt txt Quy tắc ứng xử
            txtQTUX.Visible = cbQTUX.Checked;
        }

        private void btnTiepTucQTUX_Click(object sender, EventArgs e)
        {
            tablePanel2.Visible = false;
            panel1.Location = new Point(82, 167);
            panel2.Location = new Point(82, 205);
            tablePanel6.Location = new Point(644,388);
            panel2.Visible = true;
            tablePanel6.Visible = true;
            panel1.Visible = true;
        }

        private void rptCaNhan_Load(object sender, EventArgs e)
        {

        }

        private void txtMucTieu1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtMucTieu2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnHoanThanh_Click(object sender, EventArgs e)
        {
            Add_KPI_CaNhan();
        }

        private void btnTiepTucMTCV_Click(object sender, EventArgs e)
        {

            ////kiểm tra đủ mục tiêu công việc
            //int cbCheck = 0;
            //cbCheck += checkBox1.Checked == true ? 1 : 0;
            //cbCheck += checkBox2.Checked == true ? 1 : 0;
            //cbCheck += checkBox3.Checked == true ? 1 : 0;
            //cbCheck += checkBox4.Checked == true ? 1 : 0;
            //cbCheck += checkBox5.Checked == true ? 1 : 0;
            //cbCheck += checkBox6.Checked == true ? 1 : 0;

            //if (cbCheck >= 4 && cbCheck <= 6)
            //{
            //    btnHoanThanh.Enabled = true;
            //}
            //else
            //{
            //    MessageBox.Show("Vui lòng chọn đủ các mục tiêu công việc !");
            //}
        }

        private void btnQuayLaiMTCV_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            tablePanel6.Visible = false;
            tablePanel2.Visible = true;

        }

        private void dgvMucTieu_MouseDoubleClick(object sender, MouseEventArgs e)
        {
        
        }

        private void btnTiepTucMTCV_Click_1(object sender, EventArgs e)
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
    }
}