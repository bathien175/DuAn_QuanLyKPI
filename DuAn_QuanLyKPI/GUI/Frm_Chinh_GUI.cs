﻿using DevExpress.XtraBars;
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

namespace DuAn_QuanLyKPI
{
    public partial class Frm_Chinh_GUI : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public static string mconnectstring = "server=192.168.50.108,1433;database=QuanLyKPI;uid=sa;pwd=123";
        private clsCommonMethod comm = new clsCommonMethod();
        private clsEventArgs ev = new clsEventArgs("");
        private string msql;
        public Frm_Chinh_GUI()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        public static int chucdanh;
        //Khai báo hàm không cho mở nhiều form giống nhau, khi mở form trùng thì sẽ tự động chuyển về form cũ
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
            OpenForm(typeof(Frm_TongHopKPI));
        }

        private void btnExcel_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(typeof(Frm_HoanThanhKhoaPhong));
        }

        private void btnChiTieuKPI_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(typeof(FrmChonBieuMau));
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
            if(ev.QFrmThongBao_YesNo("Bạn có thật sự muốn đăng xuất không?"))
            {
                this.Hide();
                Frm_Login home = new Frm_Login();
                home.ShowDialog();
                this.Show();
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
    }
}