
using BusinessCommon;
using DuAn_QuanLyKPI.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuAn_QuanLyKPI.GUI
{
    public partial class Frm_Login : DevExpress.XtraEditors.XtraForm
    {
        //private string mconnectstring = "Data Source=192.168.50.108,1433;Initial Catalog=QuanLyKPI;Persist Security Info=True;User ID=sa;Password=123";
        private string mconnectstring = "Data Source=LEDUONG\\LEDUONG;Initial Catalog=QuanLyKPI;Persist Security Info=True;User ID=sa;Password=123";

        private clsCommonMethod comm = new clsCommonMethod();
        private clsEventArgs ev = new clsEventArgs("");
        private string msql;
        public static string MaNV;
        public static string TenNV;
        public static string TenChucDanh;
        public static string MaPhongKhoa;
        public static string MaChucDanh;
        public static string TenPhongKhoa;
        public static string Email;
        public static string SDT;
        public static string PhanQuyen;
        public static string TK;
        public static byte[] HinhAnh;
        public static bool TPK;
        public static int CapDoBieuMauKPI;


        Timer timer = new Timer();

        List<Image> images = new List<Image>();
        string[] location = new string[25];
        public Frm_Login()
        {
            InitializeComponent();
            timer1.Enabled = true;
        }
        #region DateTime
        private void timer1_Tick(object sender, EventArgs e)
        {
            lbTime.Text = DateTime.Now.ToLongTimeString();
            lbDate.Text = DateTime.Now.ToLongDateString();
        }
        #endregion
        private byte[] ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            if (image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    image.Save(ms, format);
                    byte[] imageBytes = ms.ToArray();
                    return imageBytes;
                }
            }
            else
            {
                // Handle the case where 'image' is null, for example:
                ev.QFrmThongBaoError("Vui lòng tải hình ảnh lên");
                return null; // Or return an appropriate default value
            }
        }

        private void txtdangnhap_Enter(object sender, EventArgs e)
        {
            if (txtdangnhap.Text != "")
            {

            }
            else
            {
                txtdangnhap.Text = "";
            }
        }

        private void txtPassword_Enter_1(object sender, EventArgs e)
        {
            //if (txtPassword.Text != "")
            //{

            //}
            //else
            //{
            //    txtPassword.Text = "";
            //}
            //Bitmap bmpass = new Bitmap(@"D:\Thanh Phuc\Dự án quản lý KPI\Du An KPI\animation\textbox_password.png");
            //pictureBox1.Image = bmpass;
        }
        private void pbHien_Click_1(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '*')
            {
                pbAn.BringToFront();
                txtPassword.PasswordChar = '\0';
                if (txtdangnhap.Text.Length > 0)
                    pictureBox1.Image = images[txtdangnhap.Text.Length - 1];
                else
                    pictureBox1.Image = Properties.Resources.debut;
            }
        }

        private void pbAn_Click_1(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '\0')
            {
                pbHien.BringToFront();
                txtPassword.PasswordChar = '*';
                //Bitmap bmpass = new Bitmap(@"D:\Thanh Phuc\Dự án quản lý KPI\Du An KPI\animation\textbox_password.png");
                //pictureBox1.Image = bmpass;
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Trigger the button click event
                btnLogin.PerformClick();

                // Mark the key press as handled to prevent it from being processed further
                e.Handled = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            msql = "SELECT * FROM NguoiDung a " +
                "inner join PhongKhoa b on a.MaPhongKhoa = b.MaPK " +
                "inner join ChucDanh c on a.MaChucDanh = c.MaChucDanh " +
                "where a.TenTaiKhoan = '" + txtdangnhap.Text + "' and a.MatKhau = '" + txtPassword.Text + "'";
            DataTable dt = comm.GetDataTable(mconnectstring, msql, "NguoiDung");
            if (dt.Rows.Count == 1)
            {
                MaNV = dt.Rows[0]["MaNV"].ToString();
                MaPhongKhoa = dt.Rows[0]["MaPhongKhoa"].ToString();
                MaChucDanh = dt.Rows[0]["MaChucDanh"].ToString();
                TenPhongKhoa = dt.Rows[0]["TenPK"].ToString();
                TenChucDanh = dt.Rows[0]["TenChucDanh"].ToString();
                TenNV = dt.Rows[0]["TenNV"].ToString();
                Email = dt.Rows[0]["Gmail"].ToString();
                SDT = dt.Rows[0]["SDT"].ToString();
                CapDoBieuMauKPI = int.Parse(dt.Rows[0]["MaCapDoKPIBenhVien"].ToString());
                //byte[] hinhAnhBytes = Convert.FromBase64String(dt.Rows[0]["HinhAnhNV"].ToString()); HinhAnh = hinhAnhBytes;

                ev.QFrmThongBao("Đăng nhập thành công");
                Frm_Chinh_GUI f = new Frm_Chinh_GUI();
                this.Hide();
                f.ShowDialog();
            }
            else
            {
                ev.QFrmThongBaoError("Đăng nhập thất bại");
            }
            Frm_Login fl = new Frm_Login();
            fl.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
