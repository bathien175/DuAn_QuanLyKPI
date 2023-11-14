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
        private string mconnectstring = Database.mconnectstring;
        private clsCommonMethod comm = new clsCommonMethod();
        private clsEventArgs ev = new clsEventArgs("");
        private string msql;
        private SqlConnection conn;
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
                string MaNV = dt.Rows[0]["MaNV"].ToString();
                string MaPhongKhoa = dt.Rows[0]["MaPhongKhoa"].ToString();
                string MaChucDanh = dt.Rows[0]["MaChucDanh"].ToString();

                Frm_KPI_CaNhan f = new Frm_KPI_CaNhan(MaNV, MaPhongKhoa, MaChucDanh);
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
