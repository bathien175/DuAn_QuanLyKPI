using BusinessCommon;
using ControlProject1510;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DuAn_QuanLyKPI.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace DuAn_QuanLyKPI.GUI
{
    public partial class FrmChonBieuMau : DevExpress.XtraEditors.XtraForm
    {
        //Lấy dữ liệu 
        private static int CapDoBieuMauKPI = Frm_Login.CapDoBieuMauKPI;
        public static string QuyNam;
        //Conenect
        private static string mconnectstring = Frm_A78.mconnectstring;
        private clsCommonMethod comm = new clsCommonMethod();
        private clsEventArgs ev = new clsEventArgs("");
        private string msql;
        public FrmChonBieuMau()
        {
            InitializeComponent();
            LoadData();
        }
        #region LoadDataGrid
        //Lãnh đạo
        private void LoadData()
        {
            switch (CapDoBieuMauKPI)
            {   
                //GiamDocvaPhoGiamDoc
                case 1: 
                    msql = "SELECT * FROM [dbo].[DanhsachBieuMau] WHERE [MaCapDoKPIBenhVien] = 1";
                    DataTable gd = comm.GetDataTable(mconnectstring, msql, "GiamDocvaPhoGiamDoc");
                    dgrChonBieuMau.AutoGenerateColumns = false;
                    dgrChonBieuMau.DataSource = gd;
                break;
                //Khoa Phòng
                case 2:
                    msql = "SELECT * FROM [QuanLyKPI].[dbo].[DanhsachBieuMau] WHERE [MaCapDoKPIBenhVien] = 2";
                    DataTable kp = comm.GetDataTable(mconnectstring, msql, "KhoaPhong");
                    dgrChonBieuMau.AutoGenerateColumns = false;
                    dgrChonBieuMau.DataSource = kp;
                    break;
                //Cá nhân
                case 3:
                    msql = "SELECT * FROM [dbo].[DanhsachBieuMau] WHERE [MaCapDoKPIBenhVien] = 3";
                    DataTable cn = comm.GetDataTable(mconnectstring, msql, "CaNhan");
                    dgrChonBieuMau.AutoGenerateColumns = false;
                    dgrChonBieuMau.DataSource = cn;
                    break;
            }
        }
        #endregion
        //stt grid
        private void dgrChonBieuMau_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            if (dgrChonBieuMau["cQuy1", e.RowIndex] == dgrChonBieuMau.CurrentCell)
            {
                if (ev.QFrmThongBao_YesNo("Bạn có muốn mở Biểu mẫu " + dgrChonBieuMau.CurrentRow.Cells["cTenBieuMau"].Value.ToString() + "Quý 1 này không ?"))
                {
                    int caseValue = int.Parse(dgrChonBieuMau.CurrentRow.Cells["cIDBieuMau"].Value.ToString());
                    QuyNam = "1" + txtYear.Text;
                    switch (caseValue)
                    {
                        //case 71:
                        //    Frm_A710 A711 = new Frm_A710();
                        //    A711.Show(); break;
                        //case 72:
                        //    Frm_A710 A72 = new Frm_A710();
                        //    A72.Show(); break;
                        case 73:
                            try
                            {
                                FrmA73 A73 = new FrmA73();
                                A73.Show();
                            }
                            catch (Exception)
                            {
                                ev.QFrmThongBaoError("Không có dữ liệu tương ứng");
                            }
                            break;
                        //case 74:
                        //    Frm_A710 A74 = new Frm_A710();
                        //    A74.Show(); break;
                        //case 75:
                        //    frm_a710 a75 = new frm_a710();
                        //    a75.show(); break;
                        case 76:
                            Frm_A76 A76 = new Frm_A76();
                            A76.Show(); break;
                        //case 77:
                        //    Frm_A710 A77 = new Frm_A710();
                        //    A77.Show(); break;
                        //case 78:
                        //    Frm_A710 A78 = new Frm_A710();
                        //    A78.Show(); break;
                        //case 79:
                        //    Frm_A710 A79 = new Frm_A710();
                        //    A79.Show(); break;
                        //case 710: frm_a710 a710 = new frm_a710();
                        //a710.show();break;
                        case 78:
                            try
                            {
                                Frm_A78 Frm_A78 = new Frm_A78();
                                Frm_A78.Show();
                            }
                            catch (Exception)
                            {
                                ev.QFrmThongBaoError("Không có dữ liệu tương ứng");
                            }
                            break;
                    }
                }
            }
            if (dgrChonBieuMau["cQuy2", e.RowIndex] == dgrChonBieuMau.CurrentCell)
            {
                if (ev.QFrmThongBao_YesNo("Bạn có muốn mở Biểu mẫu " + dgrChonBieuMau.CurrentRow.Cells["cTenBieuMau"].Value.ToString() + "Quý 2 này không ?"))
                {
                    int caseValue = int.Parse(dgrChonBieuMau.CurrentRow.Cells["cIDBieuMau"].Value.ToString());
                    QuyNam = "2" + txtYear.Text;
                    switch (caseValue)
                    {
                        //case 71:
                        //    try
                        //    {
                        //        FrmA71 A71 = new FrmA71();
                        //        A71.Show();
                        //    }
                        //    catch (Exception)
                        //    {
                        //        ev.QFrmThongBaoError("Không có dữ liệu tương ứng");
                        //    }
                        //    break;
                        //case 72:
                        //    try
                        //    {
                        //        FrmA72 A72 = new FrmA72();
                        //        A72.Show();
                        //    }
                        //    catch (Exception)
                        //    {
                        //        ev.QFrmThongBaoError("Không có dữ liệu tương ứng");
                        //    }
                        //    break;
                        case 73:
                            try
                            {
                                FrmA73 A73 = new FrmA73();
                                A73.Show();
                            }
                            catch (Exception)
                            {
                                ev.QFrmThongBaoError("Không có dữ liệu tương ứng");
                            }
                            break;
                            //case 74:
                            //    try
                            //    {
                            //        FrmA74 A74 = new FrmA74();
                            //        A74.Show();
                            //    }
                            //    catch (Exception)
                            //    {
                            //        ev.QFrmThongBaoError("Không có dữ liệu tương ứng");
                            //    }
                            //    break;
                            //case 75:
                            //    try
                            //    {
                            //        FrmA75 A75 = new FrmA75();
                            //        A75.Show();
                            //    }
                            //    catch (Exception)
                            //    {
                            //        ev.QFrmThongBaoError("Không có dữ liệu tương ứng");
                            //    }
                            //    break;
                            //case 76:
                            //    try
                            //    {
                            //        FrmA76 A76 = new FrmA76();
                            //        A76.Show();
                            //    }
                            //    catch (Exception)
                            //    {
                            //        ev.QFrmThongBaoError("Không có dữ liệu tương ứng");
                            //    }
                            //    break;
                            //case 77:
                            //    try
                            //    {
                            //        FrmA77 A77 = new FrmA77();
                            //        A77.Show();
                            //    }
                            //    catch (Exception)
                            //    {
                            //        ev.QFrmThongBaoError("Không có dữ liệu tương ứng");
                            //    }
                            //    break;
                            //case 78:
                            //    try
                            //    {
                            //        FrmA78 A78 = new FrmA78();
                            //        A78.Show();
                            //    }
                            //    catch (Exception)
                            //    {
                            //        ev.QFrmThongBaoError("Không có dữ liệu tương ứng");
                            //    }
                            //    break;
                            //case 79:
                            //    try
                            //    {
                            //        FrmA79 A79 = new FrmA79();
                            //        A79.Show();
                            //    }
                            //    catch (Exception)
                            //    {
                            //        ev.QFrmThongBaoError("Không có dữ liệu tương ứng");
                            //    }
                            //    break;
                            //case 710:
                            //    try
                            //    {
                            //        FrmA710 A710 = new FrmA710();
                            //        A710.Show();
                            //    }
                            //    catch (Exception)
                            //    {
                            //        ev.QFrmThongBaoError("Không có dữ liệu tương ứng");
                            //    }
                            //    break;
                    }
                }
            }
            if (dgrChonBieuMau["cQuy3", e.RowIndex] == dgrChonBieuMau.CurrentCell)
            {
                if (ev.QFrmThongBao_YesNo("Bạn có muốn mở Biểu mẫu " + dgrChonBieuMau.CurrentRow.Cells["cTenBieuMau"].Value.ToString() + "Quý 3 này không ?"))
                {
                    int caseValue = int.Parse(dgrChonBieuMau.CurrentRow.Cells["cIDBieuMau"].Value.ToString());
                    QuyNam = "3" + txtYear.Text;
                    switch (caseValue)
                    {
                        //case 71:
                        //    try
                        //    {
                        //        FrmA71 A71 = new FrmA71();
                        //        A71.Show();
                        //    }
                        //    catch (Exception)
                        //    {
                        //        ev.QFrmThongBaoError("Không có dữ liệu tương ứng");
                        //    }
                        //    break;
                        //case 72:
                        //    try
                        //    {
                        //        FrmA72 A72 = new FrmA72();
                        //        A72.Show();
                        //    }
                        //    catch (Exception)
                        //    {
                        //        ev.QFrmThongBaoError("Không có dữ liệu tương ứng");
                        //    }
                        //    break;
                        case 73:
                            try
                            {
                                FrmA73 A73 = new FrmA73();
                                A73.Show();
                            }
                            catch (Exception)
                            {
                                ev.QFrmThongBaoError("Không có dữ liệu tương ứng");
                            }
                            break;
                            //case 74:
                            //    try
                            //    {
                            //        FrmA74 A74 = new FrmA74();
                            //        A74.Show();
                            //    }
                            //    catch (Exception)
                            //    {
                            //        ev.QFrmThongBaoError("Không có dữ liệu tương ứng");
                            //    }
                            //    break;
                            //case 75:
                            //    try
                            //    {
                            //        FrmA75 A75 = new FrmA75();
                            //        A75.Show();
                            //    }
                            //    catch (Exception)
                            //    {
                            //        ev.QFrmThongBaoError("Không có dữ liệu tương ứng");
                            //    }
                            //    break;
                            //case 76:
                            //    try
                            //    {
                            //        FrmA76 A76 = new FrmA76();
                            //        A76.Show();
                            //    }
                            //    catch (Exception)
                            //    {
                            //        ev.QFrmThongBaoError("Không có dữ liệu tương ứng");
                            //    }
                            //    break;
                            //case 77:
                            //    try
                            //    {
                            //        FrmA77 A77 = new FrmA77();
                            //        A77.Show();
                            //    }
                            //    catch (Exception)
                            //    {
                            //        ev.QFrmThongBaoError("Không có dữ liệu tương ứng");
                            //    }
                            //    break;
                            //case 78:
                            //    try
                            //    {
                            //        FrmA78 A78 = new FrmA78();
                            //        A78.Show();
                            //    }
                            //    catch (Exception)
                            //    {
                            //        ev.QFrmThongBaoError("Không có dữ liệu tương ứng");
                            //    }
                            //    break;
                            //case 79:
                            //    try
                            //    {
                            //        FrmA79 A79 = new FrmA79();
                            //        A79.Show();
                            //    }
                            //    catch (Exception)
                            //    {
                            //        ev.QFrmThongBaoError("Không có dữ liệu tương ứng");
                            //    }
                            //    break;
                            //case 710:
                            //    try
                            //    {
                            //        FrmA710 A710 = new FrmA710();
                            //        A710.Show();
                            //    }
                            //    catch (Exception)
                            //    {
                            //        ev.QFrmThongBaoError("Không có dữ liệu tương ứng");
                            //    }
                            //    break;
                    }
                }
            }
            if (dgrChonBieuMau["cQuy4", e.RowIndex] == dgrChonBieuMau.CurrentCell)
            {
                if (ev.QFrmThongBao_YesNo("Bạn có muốn mở Biểu mẫu " + dgrChonBieuMau.CurrentRow.Cells["cTenBieuMau"].Value.ToString() + "Quý 4 này không ?"))
                {
                    int caseValue = int.Parse(dgrChonBieuMau.CurrentRow.Cells["cIDBieuMau"].Value.ToString());
                    QuyNam = "4" + txtYear.Text;
                    switch (caseValue)
                    {
                        //case 71:
                        //    try
                        //    {
                        //        FrmA71 A71 = new FrmA71();
                        //        A71.Show();
                        //    }
                        //    catch (Exception)
                        //    {
                        //        ev.QFrmThongBaoError("Không có dữ liệu tương ứng");
                        //    }
                        //    break;
                        //case 72:
                        //    try
                        //    {
                        //        FrmA72 A72 = new FrmA72();
                        //        A72.Show();
                        //    }
                        //    catch (Exception)
                        //    {
                        //        ev.QFrmThongBaoError("Không có dữ liệu tương ứng");
                        //    }
                        //    break;
                        case 73:
                            try
                            {
                                FrmA73 A73 = new FrmA73();
                                A73.Show();
                            }
                            catch (Exception)
                            {
                                ev.QFrmThongBaoError("Không có dữ liệu tương ứng");
                            }
                            break;
                        //case 74:
                        //    try
                        //    {
                        //        FrmA74 A74 = new FrmA74();
                        //        A74.Show();
                        //    }
                        //    catch (Exception)
                        //    {
                        //        ev.QFrmThongBaoError("Không có dữ liệu tương ứng");
                        //    }
                        //    break;
                        //case 75:
                        //    try
                        //    {
                        //        FrmA75 A75 = new FrmA75();
                        //        A75.Show();
                        //    }
                        //    catch (Exception)
                        //    {
                        //        ev.QFrmThongBaoError("Không có dữ liệu tương ứng");
                        //    }
                        //    break;
                        //case 76:
                        //    try
                        //    {
                        //        FrmA76 A76 = new FrmA76();
                        //        A76.Show();
                        //    }
                        //    catch (Exception)
                        //    {
                        //        ev.QFrmThongBaoError("Không có dữ liệu tương ứng");
                        //    }
                        //    break;
                        //case 77:
                        //    try
                        //    {
                        //        FrmA77 A77 = new FrmA77();
                        //        A77.Show();
                        //    }
                        //    catch (Exception)
                        //    {
                        //        ev.QFrmThongBaoError("Không có dữ liệu tương ứng");
                        //    }
                        //    break;
                        //case 78:
                        //    try
                        //    {
                        //        FrmA78 A78 = new FrmA78();
                        //        A78.Show();
                        //    }
                        //    catch (Exception)
                        //    {
                        //        ev.QFrmThongBaoError("Không có dữ liệu tương ứng");
                        //    }
                        //    break;
                        //case 79:
                        //    try
                        //    {
                        //        FrmA79 A79 = new FrmA79();
                        //        A79.Show();
                        //    }
                        //    catch (Exception)
                        //    {
                        //        ev.QFrmThongBaoError("Không có dữ liệu tương ứng");
                        //    }
                        //    break;
                        //case 710:
                        //    try
                        //    {
                        //        FrmA710 A710 = new FrmA710();
                        //        A710.Show();
                        //    }
                        //    catch (Exception)
                        //    {
                        //        ev.QFrmThongBaoError("Không có dữ liệu tương ứng");
                        //    }
                        //    break;
                    }
                }
            }
            if (dgrChonBieuMau["cNam", e.RowIndex] == dgrChonBieuMau.CurrentCell)
            {
                if (ev.QFrmThongBao_YesNo("Bạn có muốn mở Biểu mẫu " + dgrChonBieuMau.CurrentRow.Cells["cTenBieuMau"].Value.ToString() + "Năm này không ?"))
                {
                    int caseValue = int.Parse(dgrChonBieuMau.CurrentRow.Cells["cIDBieuMau"].Value.ToString());
                    QuyNam = txtYear.Text;
                    txtTest.Text = QuyNam;
                    switch (caseValue)
                    {
                        //case 71:
                        //    try
                        //    {
                        //        FrmA71 A71 = new FrmA71();
                        //        A71.Show();
                        //    }
                        //    catch (Exception)
                        //    {
                        //        ev.QFrmThongBaoError("Không có dữ liệu tương ứng");
                        //    }
                        //    break;
                        //case 72:
                        //    try
                        //    {
                        //        FrmA72 A72 = new FrmA72();
                        //        A72.Show();
                        //    }
                        //    catch (Exception)
                        //    {
                        //        ev.QFrmThongBaoError("Không có dữ liệu tương ứng");
                        //    }
                        //    break;
                        case 73:
                            try
                            {
                                FrmA73 A73 = new FrmA73();
                                A73.Show();
                            }
                            catch (Exception)
                            {
                                ev.QFrmThongBaoError("Không có dữ liệu tương ứng");
                            }
                            break;
                            //case 74:
                            //    try
                            //    {
                            //        FrmA74 A74 = new FrmA74();
                            //        A74.Show();
                            //    }
                            //    catch (Exception)
                            //    {
                            //        ev.QFrmThongBaoError("Không có dữ liệu tương ứng");
                            //    }
                            //    break;
                            //case 75:
                            //    try
                            //    {
                            //        FrmA75 A75 = new FrmA75();
                            //        A75.Show();
                            //    }
                            //    catch (Exception)
                            //    {
                            //        ev.QFrmThongBaoError("Không có dữ liệu tương ứng");
                            //    }
                            //    break;
                            //case 76:
                            //    try
                            //    {
                            //        FrmA76 A76 = new FrmA76();
                            //        A76.Show();
                            //    }
                            //    catch (Exception)
                            //    {
                            //        ev.QFrmThongBaoError("Không có dữ liệu tương ứng");
                            //    }
                            //    break;
                            //case 77:
                            //    try
                            //    {
                            //        FrmA77 A77 = new FrmA77();
                            //        A77.Show();
                            //    }
                            //    catch (Exception)
                            //    {
                            //        ev.QFrmThongBaoError("Không có dữ liệu tương ứng");
                            //    }
                            //    break;
                            //case 78:
                            //    try
                            //    {
                            //        FrmA78 A78 = new FrmA78();
                            //        A78.Show();
                            //    }
                            //    catch (Exception)
                            //    {
                            //        ev.QFrmThongBaoError("Không có dữ liệu tương ứng");
                            //    }
                            //    break;
                            //case 79:
                            //    try
                            //    {
                            //        FrmA79 A79 = new FrmA79();
                            //        A79.Show();
                            //    }
                            //    catch (Exception)
                            //    {
                            //        ev.QFrmThongBaoError("Không có dữ liệu tương ứng");
                            //    }
                            //    break;
                            //case 710:
                            //    try
                            //    {
                            //        FrmA710 A710 = new FrmA710();
                            //        A710.Show();
                            //    }
                            //    catch (Exception)
                            //    {
                            //        ev.QFrmThongBaoError("Không có dữ liệu tương ứng");
                            //    }
                            //    break;
                    }
                }
            }
        }

        private void dgrChonBieuMau_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            ev.Qdgr_RowPostPaint(sender, e, dgrChonBieuMau);
        }
    }
}

