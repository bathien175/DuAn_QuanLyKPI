using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessCommon;
using DuAn_QuanLyKPI.GUI;
using DuAn_QuanLyKPI.Constants;
using DuAn_QuanLyKPI.DTO;

namespace DuAn_QuanLyKPI
{
    public partial class Frm_Chinh_GUI : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private static string username = Frm_Login.TenNV;
        private static string kp = Frm_Login.TenPhongKhoa;
        public static int chucdanh;

        public static string mconnectstring = "server=192.168.50.108,1433;database=QuanLyKPI;uid=sa;pwd=123";
        private clsCommonMethod comm = new clsCommonMethod();
        private clsEventArgs ev = new clsEventArgs("");
        private string msql;
        Timer timer = new Timer();



        private static string role = Frm_Login.PhanQuyen;  // Retrieve the role from the login form

       


        public Frm_Chinh_GUI()
        {
            InitializeComponent();
            IsMdiContainer = true;
            lbUsername.Text = username;
            lbkhoaphong.Text = kp;
            timer1.Enabled = true;
        }
        public void SetUserData(NguoiDung nguoidung)
        {

            username = nguoidung.TenNV;
            lbUsername.Text = username;

            if (nguoidung.PhongKhoa != null)
            {
                kp = nguoidung.PhongKhoa.TenPK;
                lbkhoaphong.Text = kp;
            }
            else
            {
                // Xử lý trường hợp không có PhongKhoa
                kp = "Phòng không xác định";
                lbkhoaphong.Text = kp;
            }
        }

        public void OpenForm(Type typeForm)
        {
            foreach (Form frm in MdiChildren)
            {
                if (frm.GetType()==typeForm)
                {
                    frm.Activate();
                    return;
                }    
            }
            Form f = (Form)Activator.CreateInstance(typeForm);
            f.MdiParent = this;
            f.Show();
        }
        private void btnThongTinCaNhan_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Gọi hàm mở form ra

            Frm_InfoUser InfoUser = new Frm_InfoUser();
            InfoUser.Show();

            //OpenForm(typeof(Frm_InfoUser));
        }
        private void btnThoat_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ev.QFrmThongBao_YesNo("Bạn có chắc muốn thoát chương trình không?"))
                Application.Exit();
        }

        private void btnThongTinHeThong_ItemClick(object sender, ItemClickEventArgs e)
        {
            ev.QFrmThongBao("Đây là phần mềm do team IT của Bệnh viện Nhi Đồng 2 thực hiện  phát triển và xây dựng! Nếu có lỗi hay vấn đề gì, vui lòng liện hệ team IT để được hỗ trợ nhé! Cảm ơn bạn ^-^");
        }

        private void btnKiemDuyet_ItemClick(object sender, ItemClickEventArgs e)
        {
            //OpenForm(typeof(Frm_TongHopKPI));
        }

        private void btnExcel_ItemClick(object sender, ItemClickEventArgs e)
        {
        }
        private void btnQuanLyNguoiDung_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnUser_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(typeof(Frm_User));
        }

        private void btnDoiMatKhau_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(typeof(Frm_Change_Password));
        }
        private void btnDangXuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ev.QFrmThongBao_YesNo("Bạn có thật sự muốn đăng xuất không?"))
            {
                // Reset các biến thông tin người dùng
                Frm_Login.MaNV = null;
                Frm_Login.TenNV = null;
                Frm_Login.TenChucDanh = null;
                Frm_Login.MaPhongKhoa = null;
                Frm_Login.MaChucDanh = null;
                Frm_Login.TenPhongKhoa = null;
                Frm_Login.Email = null;
                Frm_Login.SDT = null;
                Frm_Login.PhanQuyen = null;
                Frm_Login.TK = null;
                Frm_Login.HinhAnh = null;
                Frm_Login.TPK = false;
                Frm_Login.CapDoBieuMauKPI = 0;

                // Cập nhật lại phân quyền trước khi đóng form
                // ...

                // Hiển thị lại form đăng nhập
                //Frm_Login loginForm = new Frm_Login();
                //loginForm.Show();

                // Đóng form chính
                this.Close();
            }
        }



        private void btnMucTieuKPI_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(typeof(Frm_XemMucTieuKPI));
        }

        private void btnNganHangKPI_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(typeof(Frm_QuanLyNganHangKPI));
        }

        private void btnDangKyMucTieuKPI_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnThemNguoiDung_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            Frm_AddUser adduser = new Frm_AddUser();
            adduser.Show();
        }

        private void btnBieuMauKPI_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(typeof(FrmChonBieuMau));
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            lbTime.Text = DateTime.Now.ToLongTimeString();
            lbDate.Text = DateTime.Now.ToLongDateString();
        }

        private void Frm_Chinh_GUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            Frm_Login loginForm = new Frm_Login();
            loginForm.Show();
            //loginForm.Logout();
        }

        private void Frm_Chinh_GUI_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void Frm_Chinh_GUI_Activated(object sender, EventArgs e)
        {
          
        }

        private void btnPhanQuyen_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(typeof(FrmPhanQuyen));
        }

        private void lbUsername_Click(object sender, EventArgs e)
        {

        }
    }
}