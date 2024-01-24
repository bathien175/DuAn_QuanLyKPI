using BusinessCommon;
using DevExpress.XtraEditors;
using DuAn_QuanLyKPI.Constants;
using DuAn_QuanLyKPI.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuAn_QuanLyKPI.GUI
{
    public partial class Frm_AddUser : DevExpress.XtraEditors.XtraForm
    {


        private string mconnectstring = Frm_A78.mconnectstring;
        private clsCommonMethod comm = new clsCommonMethod();
        private clsEventArgs ev = new clsEventArgs("");
        private string msql;

        public Frm_AddUser()
        {
            InitializeComponent();
        }
        public byte[] ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format)
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

        private void LoadData()
        {
            var db = DataProvider.Ins.DB;

          

            msql = "SELECT * FROM [QuanLyKPI].[dbo].[PhongKhoa]";
            DataTable tb1 = comm.GetDataTable(mconnectstring, msql, "PhongKhoa");
            //cbo Trạng thái 
            cboPhongKhoa.DataSource = tb1.Copy();
            cboPhongKhoa.DisplayMember = "TenPK";
            cboPhongKhoa.ValueMember = "MaPK";
            cboPhongKhoa.CustomAlignment = new string[] { "l", "l" };
            cboPhongKhoa.CustomColumnStyle = new string[] { "t", "t" };


            msql = "SELECT * FROM [QuanLyKPI].[dbo].[ChucDanh]";
            DataTable tb2 = comm.GetDataTable(mconnectstring, msql, "ChucDanh");

            //cbo Kho
            cboChucDanh.DataSource = tb2.Copy();
            cboChucDanh.DisplayMember = "TenChucDanh";
            cboChucDanh.ValueMember = "MaChucDanh";
            cboChucDanh.CustomAlignment = new string[] { "l", "l" };
            cboChucDanh.CustomColumnStyle = new string[] { "t", "t" };
            //cboChucDanh.sf = setfocusTenKhoduoc;

            msql = "SELECT * FROM [QuanLyKPI].[dbo].[Quyen]";
            DataTable tb3 = comm.GetDataTable(mconnectstring, msql, "PhanQuyen");

            //cbo Kho
            cboPhanQuyen.DataSource = tb3.Copy();
            cboPhanQuyen.DisplayMember = "TenQuyen";
            cboPhanQuyen.ValueMember = "MaQuyen";
            cboPhanQuyen.CustomAlignment = new string[] { "l", "l" };
            cboPhanQuyen.CustomColumnStyle = new string[] { "t", "t" };
            //cboChucDanh.sf = setfocusTenKhoduoc;
        }


        void AddPhanQuyen()
        {
            msql = "INSERT INTO[dbo].[PhanQuyen]" +
            "([MaQuyen]" +
          ",[MaNhanVien])" +
          "VALUES (N'" + cboPhanQuyen.SelectedValue + "','" + txtMaNV.Text + "')";
            comm.RunSQL(mconnectstring, msql);
        }
        #region MyRegion
        void AddNguoiDung()
        {

            var db = DataProvider.Ins.DB;
            if (pbUser.Image != null)
            {
                NguoiDung nguoidung = new NguoiDung();
                nguoidung.MaNV = txtMaNV.Text;
                nguoidung.TenNV = txtHoten.Text;
                nguoidung.Gmail = txtEmail.Text;
                nguoidung.SDT = txtSDT.Text;
                nguoidung.TenTaiKhoan = txtTenTaiKhoan.Text.ToString();
                nguoidung.HinhAnhNV = ImageToBase64(pbUser.Image, ImageFormat.Jpeg);
                nguoidung.MatKhau = txtMatKhau.Text;
                nguoidung.MaPhongKhoa = cboPhongKhoa.SelectedValue.ToString();
                nguoidung.MaChucDanh = cboChucDanh.SelectedValue.ToString();
                db.NguoiDung.Add(nguoidung);
                db.SaveChanges();
                ev.QFrmThongBao("Thêm người dùng thành công");
                LoadData();
            }
            else
            {
                ev.QFrmThongBaoError("Vui lòng nhập đủ thông tin!");
            }
        }




            #endregion}
        private void btnLuuThem_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text.Trim() != "")
            {
                AddNguoiDung();
                AddPhanQuyen();
            }
            else
            {
                ev.QFrmThongBaoError("Vui lòng nhập đủ thông tin");
            }
        }
    }}