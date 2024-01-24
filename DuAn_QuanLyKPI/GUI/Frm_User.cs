using BusinessCommon;
using DevExpress.XtraEditors;
using DuAn_QuanLyKPI.Constants;
using DuAn_QuanLyKPI.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuAn_QuanLyKPI.GUI
{
    public partial class Frm_User : DevExpress.XtraEditors.XtraForm
    {
        private string mconnectstring = Frm_A78.mconnectstring;
        private clsCommonMethod comm = new clsCommonMethod();
        private clsEventArgs ev = new clsEventArgs("");
        private string msql;
        public Frm_User()
        {
            InitializeComponent();
            LoadData();
            addBiding();
            CLEAR();
            try
            {
                pbUser.Image = Base64ToImage((byte[])dgrDanhSach.SelectedRows[0].Cells[5].Value);
            }
            catch (ArgumentNullException)
            {
                ev.QFrmThongBaoError("Lỗi không load được hình ảnh");
            }
            pbUser.Image = DuAn_QuanLyKPI.Properties.Resources.noimage;
        }
        public void MoThemNguoiDung()
        {
            pnThongTinNhanVien.Visible = true;
        }
        private void LoadData()
        {
            var db = DataProvider.Ins.DB;

            msql = "SELECT * FROM [QuanLyKPI].[dbo].[NguoiDung] AS A, [dbo].[PhongKhoa] AS B,[dbo].[ChucDanh] AS C where A.MaPhongKhoa=B.MaPK and A.MaChucDanh=c.MaChucDanh";
            DataTable tb = comm.GetDataTable(mconnectstring, msql, "NguoiDung");
            dgrDanhSach.AutoGenerateColumns = false;
            dgrDanhSach.DataSource = tb;

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
        void addBiding()
        {
            txtMaNV.DataBindings.Clear();
            txtMaNV.DataBindings.Add(new Binding("Text", dgrDanhSach.DataSource, "MANV"));
            txtHoten.DataBindings.Clear();
            txtHoten.DataBindings.Add(new Binding("Text", dgrDanhSach.DataSource, "TenNV"));
            txtEmail.DataBindings.Clear();
            txtEmail.DataBindings.Add(new Binding("Text", dgrDanhSach.DataSource, "Gmail"));
            txtSDT.DataBindings.Clear();
            txtSDT.DataBindings.Add(new Binding("Text", dgrDanhSach.DataSource, "SDT"));
            txtTenTaiKhoan.DataBindings.Clear();
            txtTenTaiKhoan.DataBindings.Add(new Binding("Text", dgrDanhSach.DataSource, "TenTaiKhoan"));
            cboChucDanh.DataBindings.Clear();
            cboChucDanh.DataBindings.Add(new Binding("Text", dgrDanhSach.DataSource, "TenChucDanh"));
            cboPhongKhoa.DataBindings.Clear();
            cboPhongKhoa.DataBindings.Add(new Binding("Text", dgrDanhSach.DataSource, "TenPK"));
            txtMatKhau.DataBindings.Clear();
            txtMatKhau.DataBindings.Add(new Binding("Text", dgrDanhSach.DataSource, "MatKhau"));
            //txtHoten.DataBindings.Add(new Binding("Text", dgrDanhSach.DataSource, "TenNV"));
            //txtEmail.DataBindings.Add(new Binding("Text", dgrDanhSach.DataSource, "Gmail"));
            //txtSDT.DataBindings.Add(new Binding("Text", dgrDanhSach.DataSource, "SDT"));
            //lab.DataBindings.Add(new Binding("Text", dgrDanhSach.DataSource, "TenTaiKhoan"));
        }

        void update()
        {
        }

        private void Frm_User_Load(object sender, EventArgs e)
        {
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
        //void AddPhanQuyen()
        //{
        //    var db = DataProvider.Ins.DB;
        //    Quyen q = new Quyen();
        //    q.MaQuyen = cboPhanQuyen.SelectedValue.ToString();
        //    ev.QFrmThongBao("Thêm người dùng thành công");
        //    LoadData();
        //}
        //void AddNguoiDung()
        //{
        //    var db = DataProvider.Ins.DB;
        //    if (pbUser.Image != null)
        //    {
        //        NguoiDung nguoidung = new NguoiDung();
        //        nguoidung.MaNV = txtMaNV.Text;
        //        nguoidung.TenNV = txtHoten.Text;
        //        nguoidung.Gmail = txtEmail.Text;
        //        nguoidung.SDT = txtSDT.Text;
        //        nguoidung.TenTaiKhoan = txtTenTaiKhoan.Text.ToString();
        //        nguoidung.HinhAnhNV = ImageToBase64(pbUser.Image, ImageFormat.Jpeg);
        //        nguoidung.MatKhau = txtMatKhau.Text;
        //        nguoidung.MaPhongKhoa = cboPhongKhoa.SelectedValue.ToString();
        //        nguoidung.MaChucDanh = cboChucDanh.SelectedValue.ToString();
        //        db.NguoiDung.Add(nguoidung);
        //        db.SaveChanges();
        //        ev.QFrmThongBao("Thêm người dùng thành công");
        //        LoadData();
        //    }
        //    else
        //    {
        //        ev.QFrmThongBaoError("Vui lòng nhập đủ thông tin!");
        //    }
        //}
        private void btnLuu_Click(object sender, EventArgs e)
        {
        }
        void CLEAR()
        {
            txtHoten.Clear();
            txtMaNV.Clear();
            txtEmail.Clear();
            txtSDT.Clear();
            txtTenTaiKhoan.Clear();
            txtMatKhau.Clear();
        }
        private void dgrDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgrDanhSach_Click(object sender, EventArgs e)
        {
            //Byte[] img = Encoding.ASCII.GetBytes(dgrDanhSach.SelectedRows[0].Cells[5].Value.ToString());
            //if(img ==null)
            //    pbUser.Image = null;
            //{

            //    var DATA = (Byte[])(dgrDanhSach.SelectedRows[0].Cells[5].Value);
            //    var stream = new MemoryStream(DATA);
            //    pbUser.Image = Image.FromStream(stream);
            //}    

            try
            {
                pbUser.Image = Base64ToImage((byte[])dgrDanhSach.SelectedRows[0].Cells[5].Value);
            }
            catch (Exception)
            {
                pbUser.Image = DuAn_QuanLyKPI.Properties.Resources.noimage;
            }
        }
        public Image Base64ToImage(byte[] imageBytes)
        {
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }

        private void txtMaNV_Enter(object sender, EventArgs e)
        {
            txtMaNV.xActive = true;
            ev.Qtxt_Enter(sender, e);
        }

        private void txtMaNV_Leave(object sender, EventArgs e)
        {
            txtMaNV.xActive = false;
            ev.Qtxt_Leave(sender, e);
        }

        private void txtMaNV_KeyPress(object sender, KeyPressEventArgs e)
        {
            ev.Qtxt_KeyPress_To_TextBox_Focus(sender, e, txtHoten);

        }

        private void txtHoten_Enter(object sender, EventArgs e)
        {
            txtHoten.xActive = true;
            ev.Qtxt_Enter(sender, e);
        }

        private void txtHoten_Leave(object sender, EventArgs e)
        {
            txtHoten.xActive = false;
            ev.Qtxt_Leave(sender, e);
        }

        private void txtHoten_KeyPress(object sender, KeyPressEventArgs e)
        {
            ev.Qtxt_KeyPress_To_TextBox_Focus(sender, e, txtEmail);

        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            txtEmail.xActive = true;
            ev.Qtxt_Enter(sender, e);
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            txtEmail.xActive = false;
            ev.Qtxt_Leave(sender, e);
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            ev.Qtxt_KeyPress_To_TextBox_Focus(sender, e, txtSDT);
        }

        private void txtSDT_Enter(object sender, EventArgs e)
        {
            txtSDT.xActive = true;
            ev.Qtxt_Enter(sender, e);
        }

        private void txtSDT_Leave(object sender, EventArgs e)
        {
            txtSDT.xActive = false;
            ev.Qtxt_Leave(sender, e);
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            ev.Qtxt_KeyPress_To_TextBox_Focus(sender, e, txtTenTaiKhoan);
        }

        private void txtTenTK_Enter(object sender, EventArgs e)
        {
            txtTenTaiKhoan.xActive = true;
            ev.Qtxt_Enter(sender, e);
        }

        private void txtTenTK_Leave(object sender, EventArgs e)
        {
            txtTenTaiKhoan.xActive = false;
            ev.Qtxt_Leave(sender, e);
        }

        private void txtTenTK_KeyPress(object sender, KeyPressEventArgs e)
        {
            ev.Qtxt_KeyPress_To_TextBox_Focus(sender, e, txtMatKhau);

        }

        private void txtMatKhau_Enter(object sender, EventArgs e)
        {
            txtMatKhau.xActive = true;
            ev.Qtxt_Enter(sender, e);
        }

        private void txtMatKhau_Leave(object sender, EventArgs e)
        {
            txtMatKhau.xActive = false;
            ev.Qtxt_Leave(sender, e);
        }

        private void txtMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void btnThem_Enter(object sender, EventArgs e)
        {
            ev.Qtxt_Enter(sender, e);
        }

        private void btnThem_Leave(object sender, EventArgs e)
        {
            ev.Qtxt_Leave(sender, e);
        }

        private void btnThem_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
        private void btnclear_Click_1(object sender, EventArgs e)
        {
            txtHoten.Clear();
            txtMaNV.Clear();
            txtEmail.Clear();
            txtSDT.Clear();
            txtTenTaiKhoan.Clear();
            txtMatKhau.Clear();

            pbUser.Image = null;
        }

            //try
            //{

            //    byte[] image = null;
            //    string sqlquery = "insert into NguoiDung(MaNV,TenNV,HinhAnhNV,SDT,Gmail,TenTaiKhoan,MatKhau,MaPhongKhoa,MaChucDanh) values ('" + txtMaNV.Text + "',N'" + txtHoten.Text + "',@img,'" + txtSDT.Text + "','" + txtEmail.Text + "',N'" + txtTenTaiKhoan.Text + "','" + txtMatKhau.Text + "',N'" + cboPhongKhoa.SelectedValue + "',N'" + cboChucDanh.SelectedValue + "')";
            //    cmd = new SqlCommand(sqlquery, connection);
            //    cmd.Parameters.Add(new SqlParameter("@img", image));
            //    int n = cmd.ExecuteNonQuery();
            //    connection.Close();
            //    MessageBox.Show(n.ToString() + "Thêm người dùng thành công");
            //    txtMaNV.Clear();
            //    txtHoten.Clear();
            //    txtMaNV.Focus();


            //}
            //catch (Exception ee)
            //{
            //    MessageBox.Show(ee.Message);

            //}

            //MemoryStream s = new MemoryStream();
            //pbUser.Image.Save(s, System.Drawing.Imaging.ImageFormat.Jpeg);
            //byte[] pic = s.ToArray();

            //msql = "insert into NguoiDung(MaNV,TenNV,HinhAnhNV,SDT,Gmail,TenTaiKhoan,MatKhau,MaPhongKhoa,MaChucDanh) values ('" + txtMaNV.Text + "',N'" + txtHoten.Text + "',@img,'" + txtSDT.Text + "','" + txtEmail.Text + "',N'" + txtTenTaiKhoan.Text + "','" + txtMatKhau.Text + "',N'" + cboPhongKhoa.SelectedValue + "',N'" + cboChucDanh.SelectedValue + "')";
            //comm.RunSQL(mconnectstring, msql);
            //ev.QFrmThongBao("Thêm người dùng thành công");



            //LoadData();



            //if(pbUser.Image!=null)

            //   {

            //       SqlConnection con = new SqlConnection(@"Data Source=192.168.50.108,1433;Initial Catalog=QuanLyKPI;User ID=sa;Password=123");
            //       SqlCommand cmd = new SqlCommand("insert into NguoiDung(MaNV,TenNV,HinhAnhNV,SDT,Gmail,TenTaiKhoan,MatKhau,MaPhongKhoa,MaChucDanh) values ('" + txtMaNV.Text + "',N'" + txtHoten.Text + "',@img,'" + txtSDT.Text + "','" + txtEmail.Text + "',N'" + txtTenTaiKhoan.Text + "','" + txtMatKhau.Text + "',N'" + cboPhongKhoa.SelectedValue + "',N'" + cboChucDanh.SelectedValue + "')", con);
            //       MemoryStream s = new MemoryStream();
            //       pbUser.Image.Save(s, System.Drawing.Imaging.ImageFormat.Jpeg);
            //       byte[] pic = s.ToArray();
            //       cmd.Parameters.AddWithValue("@img", pic);
            //       con.Open();
            //       cmd.ExecuteNonQuery();
            //       con.Close();
            //       ev.QFrmThongBao("Thêm người dùng thành công");
            //       LoadData();
            //   }


            //   else
            //   {

            //       ev.QFrmThongBaoError("loi");

            //   }




        
        //    else
        //        ev.QFrmThongBaoError("Vui lòng nhập thông tin ");

        //}
        void AddPhanQuyen()
        {
            msql = "INSERT INTO[dbo].[PhanQuyen]" +
            "([MaQuyen]" +
          ",[MaNhanVien])" +
          "VALUES (N'" + cboPhanQuyen.SelectedValue + "','" + txtMaNV.Text + "')";
            comm.RunSQL(mconnectstring, msql);
        }
        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            try
            {
                var db = DataProvider.Ins.DB;
                if (db != null)
                {
                    string id = txtMaNV.Text;
                    NguoiDung sv = db.NguoiDung.Where(p => p.MaNV == id).SingleOrDefault();
                    db.NguoiDung.Remove(sv);
                    db.SaveChanges();
                    LoadData();
                }
            }
            catch (Exception)
            {
                ev.QFrmThongBaoError("Không tìm thấy tên người dùng cần xóa");
            }
            //NguoiDung nguoidung = db.NguoiDung.Where(x => x.MaNV == txtMaNV.Text).FirstOrDefault();
            //db.NguoiDung.Remove(nguoidung);
            //db.SaveChanges();
        }
        private void btnThem_Click_1(object sender, EventArgs e)
        {
            LoadData();

            pbUser.Image = null;

            //btnclear.Visible = false;


            txtHoten.Clear();
            txtMaNV.Clear();
            txtEmail.Clear();
            txtSDT.Clear();
            txtTenTaiKhoan.Clear();
            txtMatKhau.Clear();
        }

        private void btnUpImage_Click_1(object sender, EventArgs e)
        {
            Upload.Filter = "select image(*.JpG;*.png;*.Gif|*.JpG;*.png;*.Gif)";
            if (Upload.ShowDialog() == DialogResult.OK)
            {
                pbUser.Image = Image.FromFile(Upload.FileName);
            }
        }
        private void btnView_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void dgrDanhSach_Click_1(object sender, EventArgs e)
        {
            try
            {
                pbUser.Image = Base64ToImage((byte[])dgrDanhSach.SelectedRows[0].Cells[5].Value);
            }
            catch (Exception)
            {
                pbUser.Image = DuAn_QuanLyKPI.Properties.Resources.noimage;
            }
        }
        private void SuaNhanVien()
        {
            var db = DataProvider.Ins.DB;
            NguoiDung nguoidung = db.NguoiDung.Where(x => x.MaNV == txtMaNV.Text).FirstOrDefault();
            nguoidung.TenNV = txtHoten.Text;
            nguoidung.Gmail = txtEmail.Text;
            nguoidung.SDT = txtSDT.Text;
            nguoidung.TenTaiKhoan = txtTenTaiKhoan.Text;
            nguoidung.HinhAnhNV = ImageToBase64(pbUser.Image, ImageFormat.Jpeg);
            nguoidung.MatKhau = txtMatKhau.Text;
            nguoidung.MaPhongKhoa = cboPhongKhoa.SelectedValue.ToString();
            nguoidung.MaChucDanh = cboChucDanh.SelectedValue.ToString();
            db.NguoiDung.Attach(nguoidung);
            db.Entry(nguoidung).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            ev.QFrmThongBao("Sửa người dùng thành công");
            LoadData();
        }
        private void dgrDanhSach_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            if (dgrDanhSach["cSua", e.RowIndex] == dgrDanhSach.CurrentCell)
            {
                if (ev.QFrmThongBao_YesNo("Bạn có muốn sửa thông tin người dùng " + dgrDanhSach.CurrentRow.Cells["cHoTen"].Value.ToString() + " này không ?"))
                {
                    btnLuuSua.Visible = true;

                    pnThongTinNhanVien.Visible = true;
                    addBiding();
                }
            }    
        }

        private void dgrDanhSach_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            ev.Qdgr_RowPostPaint(sender, e, dgrDanhSach);
        }

        private void btnLuuSua_Click(object sender, EventArgs e)
        {
            SuaNhanVien();
        }
    }
}
