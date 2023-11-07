﻿using BusinessCommon;
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
    public partial class FrmChonBieuMau : DevExpress.XtraEditors.XtraForm
    {
        private string mconnectstring = Frm_Chinh_GUI.mconnectstring;
        private clsCommonMethod comm = new clsCommonMethod();
        private clsEventArgs ev = new clsEventArgs("");
        private string msql;
        public FrmChonBieuMau()
        {
            InitializeComponent();
        }
        #region LoadDataGrid
        //Lãnh đạo 
            public void LoadBieuMauGiamDocvaPhoGiamDoc()
            {
                msql = "SELECT * FROM [dbo].[tabBieuMau] WHERE [MaCapDoKPIBenhVien] = 1";
                DataTable bieumau = comm.GetDataTable(mconnectstring, msql, "GiamDocvaPhoGiamDoc");
                dgrChonBieuMau.AutoGenerateColumns = false;
                dgrChonBieuMau.DataSource = bieumau;
            }
        //Khoa/ Phòng
            public void LoadBieuMauKhoaPhong()
            {
                msql = "SELECT * FROM [dbo].[tabBieuMau] WHERE [MaCapDoKPIBenhVien] = 2";
                DataTable bieumau = comm.GetDataTable(mconnectstring, msql, "KhoaPhong");
                dgrChonBieuMau.AutoGenerateColumns = false;
                dgrChonBieuMau.DataSource = bieumau;
            }
        //Cá nhân
            public void LoadBieuMauCaNhan()
            {
                msql = "SELECT * FROM [dbo].[tabBieuMau] WHERE [MaCapDoKPIBenhVien] = 3";
                DataTable bieumau = comm.GetDataTable(mconnectstring, msql, "CaNhan");
                dgrChonBieuMau.AutoGenerateColumns = false;
                dgrChonBieuMau.DataSource = bieumau;
            }
        #endregion
        //stt grid
        private void dgrChonBieuMau_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            ev.Qdgr_RowPostPaint(sender, e, dgrChonBieuMau);
        }

        private void dgrChonBieuMau_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            if (dgrChonBieuMau["cChon", e.RowIndex] == dgrChonBieuMau.CurrentCell)
            {
                if (ev.QFrmThongBao_YesNo("Bạn có muốn mở Biểu mẫu " + dgrChonBieuMau.CurrentRow.Cells["cTenBieuMau"].Value.ToString() + " này không ?"))
                {
                    int caseValue = int.Parse(dgrChonBieuMau.CurrentRow.Cells["cIDBieuMau"].Value.ToString());
                    switch (caseValue)
                    {
                        //case 71:
                        //    Frm_A710 A711 = new Frm_A710();
                        //    A711.Show(); break;
                        //case 72:
                        //    Frm_A710 A72 = new Frm_A710();
                        //    A72.Show(); break;
                        //case 73:
                        //    Frm_A710 A73 = new Frm_A710();
                        //    A73.Show(); break;
                        //case 74:
                        //    Frm_A710 A74 = new Frm_A710();
                        //    A74.Show(); break;
                        //case 75:
                        //    Frm_A710 A75 = new Frm_A710();
                        //    A75.Show(); break;
                        //case 76:
                        //    Frm_A710 A76 = new Frm_A710();
                        //    A76.Show(); break;
                        //case 77:
                        //    Frm_A710 A77 = new Frm_A710();
                        //    A77.Show(); break;
                        //case 78:
                        //    Frm_A710 A78 = new Frm_A710();
                        //    A78.Show(); break;
                        //case 79:
                        //    Frm_A710 A79 = new Frm_A710();
                        //    A79.Show(); break;
                        case 710: Frm_A710 A710 = new Frm_A710();
                            A710.Show();break;
                    }

                }
            }
        }
    }
}
