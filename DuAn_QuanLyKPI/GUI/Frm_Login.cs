using BusinessCommon;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DuAn_QuanLyKPI.GUI
{
    public partial class Frm_Login : DevExpress.XtraEditors.XtraForm
    {
        private string mconnectstring = Database.mconnectstring;
        private clsCommonMethod comm = new clsCommonMethod();
        private clsEventArgs ev = new clsEventArgs("");
        private string msql;
        private SqlConnection conn;

        public static string MaNV;
        public static string MaPK;

        public Frm_Login()
        {
            InitializeComponent();
        }

        private void CheckLogin()
        {
            msql = "SELECT * FROM NguoiDung where TenTaiKhoan = '" + txtUsername.Text + "' and MatKhau = '" + txtPassword.Text + "'";
            DataTable dt = comm.GetDataTable(mconnectstring, msql, "NguoiDung");
            if (dt.Rows.Count == 1)
            {
                MaNV = dt.Rows[0]["MaNV"].ToString();
                MaPK = dt.Rows[0]["MaPhongKhoa"].ToString();

                Frm_A78 f = new Frm_A78();
                f.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Vui Lòng thử lại !");

            //msql = "SELECT * FROM dbo.ChucDanh INNER JOIN dbo.NguoiDung ON dbo.ChucDanh.MaChucDanh = dbo.NguoiDung.MaChucDanh INNER JOIN dbo.PhongKhoa ON dbo.NguoiDung.MaPhongKhoa = dbo.PhongKhoa.MaPK where TenTaiKhoan = '" + txtUsername.Text + "' and MatKhau = '" + txtPassword.Text + "'";
            //DataTable dtt = comm.GetDataTable(mconnectstring, msql, "NguoiDung");
            //if (dt.Rows.Count == 1)
            //{
            //    string MaNV = dt.Rows[0]["MaNV"].ToString();
            //    TenNV = dtt.Rows[0]["TenNV"].ToString();
            //    TenChucDanh = dtt.Rows[0]["TenChucDanh"].ToString();
            //    TenPhongKhoa = dtt.Rows[0]["TenPK"].ToString();
            //    string MaPhongKhoa = dt.Rows[0]["MaPhongKhoa"].ToString();
            //    string MaChucDanh = dt.Rows[0]["MaChucDanh"].ToString();

            //    Frm_A78 f = new Frm_A78();

            //    //Frm_KPI_CaNhan f = new Frm_KPI_CaNhan(MaNV, MaPhongKhoa, MaChucDanh);
            //    f.Show();
            //    this.Hide();
            //}
          
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            CheckLogin();
        }
    }
}
