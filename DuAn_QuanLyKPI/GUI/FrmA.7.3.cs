using DevExpress.XtraEditors;
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
    public partial class FrmA73 : DevExpress.XtraEditors.XtraForm
    {
        public FrmA73()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnTiepTucTaiChinh_Click(object sender, EventArgs e)
        {
            // Chuyển sang tab thứ hai
            tabMucTieuKhoaPhong.SelectTab(1);
        }

        private void btnQuayLaiKhachHang_Click(object sender, EventArgs e)
        {
            // Chuyển sang tab thứ hai
            tabMucTieuKhoaPhong.SelectTab(0);
        }

        private void btnTiepTucKhachHang_Click(object sender, EventArgs e)
        {
            // Chuyển sang tab thứ hai
            tabMucTieuKhoaPhong.SelectTab(2);
        }

        private void btnQuayLaiVanHanh_Click(object sender, EventArgs e)
        {
            // Chuyển sang tab thứ hai
            tabMucTieuKhoaPhong.SelectTab(1);
        }

        private void btnTiepTucVanHanh_Click(object sender, EventArgs e)
        {
            // Chuyển sang tab thứ hai
            tabMucTieuKhoaPhong.SelectTab(3);
        }

        private void btnQuayLaiPhatTrien_Click(object sender, EventArgs e)
        {
            // Chuyển sang tab thứ hai
            tabMucTieuKhoaPhong.SelectTab(2);
        }

        private void btnTiepTucPhatTrien_Click(object sender, EventArgs e)
        {

        }
    }
}