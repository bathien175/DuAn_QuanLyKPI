
using BusinessCommon;
using DuAn_QuanLyKPI.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        private clsCommonMethod comm = new clsCommonMethod();
        private clsEventArgs ev = new clsEventArgs("");

        #region Tạo biến truyền dữ liệu
            public static string a;
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
        # endregion


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
            if (txtPassword.Text != "")
            {

            }
            else
            {
                txtPassword.Text = "";
            }

        }
        private void pbHien_Click_1(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '*')
            {
                pbAn.BringToFront();
                txtPassword.PasswordChar = '\0';

            }

        }

        private void pbAn_Click_1(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '\0')
            {
                pbHien.BringToFront();
                txtPassword.PasswordChar = '*';

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

        public Frm_Chinh_GUI MainForm { get; set; }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string tentk = txtdangnhap.Text;
            string mk = txtPassword.Text;
            var db = DataProvider.Ins.DB;
            var nguoidung = db.NguoiDung.Where(x => x.TenTaiKhoan == tentk && x.MatKhau == mk).FirstOrDefault();
            if (nguoidung != null)
            {
                // Truyền dữ liệu sau khi đăng nhập thành công
                DataUserCurrent.Instance.IDUserCurrent = nguoidung.MaNV;
                DataUserCurrent.Instance.Permission = nguoidung.MaQuyen;

                MaNV = DataUserCurrent.Instance.Permission = nguoidung.MaNV;
                MaPhongKhoa = DataUserCurrent.Instance.Permission = nguoidung.MaPhongKhoa;
                TenPhongKhoa = DataUserCurrent.Instance.Permission = nguoidung.PhongKhoa.TenPK;
                MaChucDanh = DataUserCurrent.Instance.Permission = nguoidung.MaChucDanh;
                TenChucDanh = DataUserCurrent.Instance.Permission = nguoidung.ChucDanh.TenChucDanh;
                TenNV = DataUserCurrent.Instance.Permission = nguoidung.TenNV;
                Email = DataUserCurrent.Instance.Permission = nguoidung.Gmail;
                SDT = DataUserCurrent.Instance.Permission = nguoidung.SDT;
                TK = DataUserCurrent.Instance.Permission = nguoidung.TenTaiKhoan;
                CapDoBieuMauKPI = (int)nguoidung.MaCapDoKPIBenhVien;
                DataUserCurrent.Instance.Permission = CapDoBieuMauKPI.ToString();
                byte[] hinhAnhBytes = nguoidung.HinhAnhNV;
                DataUserCurrent.Instance.Permission = hinhAnhBytes.ToString();
                HinhAnh = hinhAnhBytes;

                // Hiển thị thông báo
                ev.QFrmThongBao("Đăng nhập thành công");

                // Nếu MainForm chưa được khởi tạo, thì tạo mới
                if (Program.MainForm == null)
                {
                    Program.MainForm = new Frm_Chinh_GUI();
                }

                // Pass user data to the main form
                Program.MainForm.SetUserData(nguoidung);

                // Ẩn form đăng nhập
                this.Hide();

                // Hiển thị form chính
                Program.MainForm.ShowDialog();
            }
            else
            {
                ev.QFrmThongBaoError("Đăng nhập thất bại");
            }
        }

        public void Logout()
        {
            if (!this.IsDisposed)
            {
                // Đóng form đăng nhập
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
