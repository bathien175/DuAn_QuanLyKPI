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
    public partial class FrmKPI_KhoaPhong : DevExpress.XtraEditors.XtraForm
    {
        public FrmKPI_KhoaPhong()
        {
            InitializeComponent();
        }


        private void btnDongY_Click(object sender, EventArgs e)
        {
            string selectedValue = cbbChonBieuMau.SelectedItem.ToString();

            if (selectedValue == "A.7.3: Bảng mục tiêu khoa phòng")
            {
                this.Hide();
                FrmA73 f = new FrmA73();
                f.ShowDialog();
                
            }
            if (selectedValue == "A.7.6: Bảng KPI khoa/phòng")
            {
                this.Hide();
                FrmA76 f = new FrmA76();
                f.ShowDialog();
                
            }
        }
    }
}




// kiệt mụp địch
// kiệt mụp địch
// kiệt mụp địch
// kiệt mụp địch
// kiệt mụp địch
// kiệt mụp địch
