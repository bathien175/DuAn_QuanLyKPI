using BusinessCommon;
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
    public partial class Frm_Login : DevExpress.XtraEditors.XtraForm
    {
        public static string MaNV;
        public static string MaPhongKhoa;
        public static string MaChucDanh;
        private string mconnectstring = Database.mconnectstring;
        private clsCommonMethod comm = new clsCommonMethod();
        private clsEventArgs ev = new clsEventArgs("");
        private string msql;
        private SqlConnection conn;
        public Frm_Login()
        {
            InitializeComponent();
            LoadDB();
        }

        private void LoadDB()
        {
            conn = new SqlConnection(mconnectstring);
            try
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    MessageBox.Show("Kết nối thành công !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kết nối thất bại. Lỗi: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void CheckLogin()
        {
            msql = "SELECT * FROM NguoiDung where TenTaiKhoan = '" + txtUsername.Text + "' and MatKhau = '" + txtPassword.Text + "'";
            DataTable dt = comm.GetDataTable(mconnectstring, msql, "NguoiDung");

            if (dt.Rows.Count == 1)
            {
                MaNV = dt.Rows[0]["MaNV"].ToString();
                MaPhongKhoa = dt.Rows[0]["MaPhongKhoa"].ToString();
                MaChucDanh = dt.Rows[0]["MaChucDanh"].ToString();

                KPI_CaNhan f = new KPI_CaNhan();
                f.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Vui Lòng thử lại !");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            CheckLogin();
        }
    }
}
