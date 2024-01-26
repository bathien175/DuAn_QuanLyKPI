using BusinessCommon;
using DevExpress.XtraEditors;
using DuAn_QuanLyKPI.Constants;
using DuAn_QuanLyKPI.DTO;
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
    public partial class Frm_Change_Password : DevExpress.XtraEditors.XtraForm
    {
        private clsEventArgs ev = new clsEventArgs("");
        public Frm_Change_Password()
        {
            InitializeComponent();
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {


        }

        private void btnDoiMatKhau_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (txtMatKhauMoi.Text == txtNhapLaiMatKhau.Text && txtTenDangNhap.Text.Trim() != "" && txtMatKhauMoi.Text.Trim() != "")
                {
                    var db = DataProvider.Ins.DB;
                    var nguoidung = db.NguoiDung.Where(x => x.TenTaiKhoan == txtTenDangNhap.Text && x.MatKhau == txtMatKhauHienTai.Text).FirstOrDefault();
                    nguoidung.TenTaiKhoan = txtTenDangNhap.Text;
                    nguoidung.MatKhau = txtMatKhauMoi.Text;
                    db.Entry(nguoidung).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    ev.QFrmThongBao("Đổi mật khẩu thành công");


                }
                else if (txtTenDangNhap.Text == "" && txtMatKhauMoi.Text == "")
                {
                    ev.QFrmThongBaoError("Vui lòng điền đủ thông tin");
                }

                else if (txtMatKhauMoi.Text != txtNhapLaiMatKhau.Text)
                {
                    ev.QFrmThongBaoError("Mật khẩu cũ và mật khẩu mới không trùng khớp");

                }

            }
            catch (NullReferenceException ex)
            {

                ev.QFrmThongBaoError("Vui lòng điền đủ thông tin");


            }





        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDoiMatKhau_Click_2(object sender, EventArgs e)
        {

        }

        private void btnHuy_Click_1(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}