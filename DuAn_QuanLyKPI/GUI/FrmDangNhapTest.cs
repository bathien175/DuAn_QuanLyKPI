using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessCommon;

namespace DuAn_QuanLyKPI.GUI
{
    public partial class FrmDangNhapTest : Form
    {
        public FrmDangNhapTest()
        {
            InitializeComponent();
            LoadDB();
        }

        public static string MaNV;
        public static string MaPhongKhoa;
        public static string MaChucDanh;
        public static string mconnectstring = "server=192.168.50.108,1433;database= QuanLyKPI; uid=sa;pwd=123";
        private clsCommonMethod comm = new clsCommonMethod();
        private clsEventArgs ev = new clsEventArgs("");
        private string msql;
        private SqlConnection conn;
        

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
            System.Data.DataTable dt = comm.GetDataTable(mconnectstring, msql, "NguoiDung");

            if (dt.Rows.Count == 1)
            {
                MaNV = dt.Rows[0]["MaNV"].ToString();
                MaPhongKhoa = dt.Rows[0]["MaPhongKhoa"].ToString();
                MaChucDanh = dt.Rows[0]["MaChucDanh"].ToString();

                FrmA73 f = new FrmA73();
                f.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Vui Lòng thử lại !");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            CheckLogin();

        }
    }
}
