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
using DevExpress.DataAccess.Excel;
using BusinessCommon;

namespace DuAn_QuanLyKPI
{
    public partial class Frm_ImportExcel_GUI : DevExpress.XtraEditors.XtraForm
    {
        private clsCommonMethod comm = new clsCommonMethod();
        private clsEventArgs ev = new clsEventArgs("");
        public Frm_ImportExcel_GUI()
        {
            InitializeComponent();
        }

        private void Frm_ImportExcel_GUI_Load(object sender, EventArgs e)
        {

        }

        private void btnTaiFile_Click_1(object sender, EventArgs e)
        {
            //
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select File";
            openFileDialog.Filter = "Excel(*.xlsx)|*.xlsx";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //gán
                txtPath.Text = openFileDialog.FileName;
                //Tiến hàng đọc file Excel 
                ExcelDataSource excel = new ExcelDataSource();
                excel.FileName = txtPath.Text;
                ExcelWorksheetSettings excelWorksheetSettings = new ExcelWorksheetSettings("MyData", "A1:F99");
                excel.SourceOptions = new ExcelSourceOptions(excelWorksheetSettings);
                excel.SourceOptions = new CsvSourceOptions() { CellRange = "A1:F99" };
                //Không lấy cái vùng trống
                excel.SourceOptions.SkipEmptyRows = false;
                //lấy tiêu đề của cột để làm tiêu đề cho lưới
                excel.SourceOptions.UseFirstRowAsHeader = true;
                excel.Fill();
                gcData.DataSource = excel;
            }
        }

        private void btnExportWord_Click(object sender, EventArgs e)
        {
            //gcData.ExportToXlsx(Application.StartupPath + @"\DanhSach.xlsx");
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "Word 2007 of higher(.docx) | *.docx";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                gcData.ExportToDocx(sf.FileName);
            }
        }

        private void btnExxportPDF_Click(object sender, EventArgs e)
        {
            {
                //gcData.ExportToXlsx(Application.StartupPath + @"\DanhSach.xlsx");
                SaveFileDialog sf = new SaveFileDialog();
                sf.Filter = "PDF file (.pdf) | *.pdf";
                if (sf.ShowDialog() == DialogResult.OK)
                {
                    gcData.ExportToPdf(sf.FileName);
                }
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            //gcData.ExportToXlsx(Application.StartupPath + @"\DanhSach.xlsx");
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "Excel 2007 of higher(.xlsx) | *.xlsx";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                gcData.ExportToXlsx(sf.FileName);
            }
        }

        private void btnGuiDi_Click(object sender, EventArgs e)
        {
            if(ev.QFrmThongBao_YesNo("Bạn có muốn xác nhận gửi đi không?"))
            {

            }   
            else
            {
                //
            }    
        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            if (ev.QFrmThongBao_YesNo("Bạn có muốn xác nhận gửi đi không?"))
            {

            }
            else
            {
                //
            }
        }
    }
}