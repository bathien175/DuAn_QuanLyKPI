using BusinessCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuAn_QuanLyKPI.GUI
{
    public partial class FrmPhanToMucTieuNhanVien : Form
    {
        public static string mconnectstring = "server=192.168.50.108,1433;database=QuanLyKPI;uid=sa;pwd=123";
        private clsCommonMethod comm = new clsCommonMethod();
        private clsEventArgs ev = new clsEventArgs("");
        private string msql;
        private Dictionary<string, bool> changes = new Dictionary<string, bool>();



        public FrmPhanToMucTieuNhanVien()
        {
            InitializeComponent();
      
            msql = "SELECT * FROM MucTieuKPI WHERE MaNhom = 'TC' ORDER BY TT";
            DataTable mt = comm.GetDataTable(mconnectstring, msql, "");

            dgrDanhSachMucTieuTCKPI.CellContentClick += dgrDanhSachMucTieuKPI_CellContentClick;

            dgrDanhSachMucTieuTCKPI.AutoGenerateColumns = false;
            dgrDanhSachMucTieuTCKPI.DataSource = mt;




            msql = "SELECT * FROM MucTieuKPI WHERE MaNhom = 'KH' ORDER BY TT";
            DataTable mt1 = comm.GetDataTable(mconnectstring, msql, "");

            dgrDanhSachMucTieuKHKPI.CellContentClick += dgrDanhSachMucTieuKPI_CellContentClick;

            dgrDanhSachMucTieuKHKPI.AutoGenerateColumns = false;
            dgrDanhSachMucTieuKHKPI.DataSource = mt1;


            msql = "SELECT * FROM MucTieuKPI WHERE MaNhom = 'VH' ORDER BY TT";
            DataTable mt3 = comm.GetDataTable(mconnectstring, msql, "");

            dgrDanhSachMucTieuVHKPI.CellContentClick += dgrDanhSachMucTieuKPI_CellContentClick;

            dgrDanhSachMucTieuVHKPI.AutoGenerateColumns = false;
            dgrDanhSachMucTieuVHKPI.DataSource = mt3;




            msql = "SELECT * FROM MucTieuKPI WHERE MaNhom = 'PT' ORDER BY TT";
            DataTable mt4= comm.GetDataTable(mconnectstring, msql, "");

            dgrDanhSachMucTieuPTKPI.CellContentClick += dgrDanhSachMucTieuKPI_CellContentClick;

            dgrDanhSachMucTieuPTKPI.AutoGenerateColumns = false;
            dgrDanhSachMucTieuPTKPI.DataSource = mt4;



            dgrDanhSachMucTieuTCKPI.CellContentClick += dgrDanhSachMucTieuTCKPI_CellContentClick;




            //DataGridViewTextBoxColumn columnTC = (DataGridViewTextBoxColumn)dgrDanhSachMucTieuTCKPI.Columns["cTrongSoTC"];
            //columnTC.DefaultCellStyle.NullValue = "%"; // Đơn vị mặc định
            //columnTC.DefaultCellStyle.Format = "N2 %"; // Định dạng số với 2 chữ số sau dấu thập phân và đơn vị


            //DataGridViewTextBoxColumn columnKH = (DataGridViewTextBoxColumn)dgrDanhSachMucTieuKHKPI.Columns["cTrongSoKH"];
            //columnKH.DefaultCellStyle.NullValue = "%"; // Đơn vị mặc định
            //columnKH.DefaultCellStyle.Format = "N2 %"; // Định dạng số với 2 chữ số sau dấu thập phân và đơn vị

            //DataGridViewTextBoxColumn columnVH = (DataGridViewTextBoxColumn)dgrDanhSachMucTieuVHKPI.Columns["cTrongSoVH"];
            //columnVH.DefaultCellStyle.NullValue = "%"; // Đơn vị mặc định
            //columnVH.DefaultCellStyle.Format = "N2 %"; // Định dạng số với 2 chữ số sau dấu thập phân và đơn vị


            //DataGridViewTextBoxColumn columnPT = (DataGridViewTextBoxColumn)dgrDanhSachMucTieuPTKPI.Columns["cTrongSoPT"];
            //columnPT.DefaultCellStyle.NullValue = "%"; // Đơn vị mặc định
            //columnPT.DefaultCellStyle.Format = "N2 %"; // Định dạng số với 2 chữ số sau dấu thập phân và đơn vị

            // Sự kiện CellFormatting để định dạng lại hiển thị của ô cụ thể trong cột "TrongSo"
            dgrDanhSachMucTieuTCKPI.CellFormatting += dgrDanhSachMucTieuTCKPI_CellFormatting;
            //dgrDanhSachMucTieuKHKPI.CellFormatting += dgrDanhSachMucTieuKHKPI_CellFormatting;
            //dgrDanhSachMucTieuVHKPI.CellFormatting += dgrDanhSachMucTieuVHKPI_CellFormatting;
            //dgrDanhSachMucTieuTCKPI.CellFormatting += dgrDanhSachMucTieuTCKPI_CellFormatting;
        }







        private void cboMaNhom_TextChanged(object sender, EventArgs e)
        {
           

        }

        private string Checked(string muctieu, string manhom)
        {
            string msql = "SELECT id FROM NoiDungMucTieuNhanVien WHERE NDMucTieu = N'"+ muctieu + "' AND MaNhom = N'" + manhom + "'";
            DataTable tb= comm.GetDataTable(mconnectstring, msql, "");
            string id_noidungmuctieu = tb.Rows[0]["id"].ToString();
            return id_noidungmuctieu;
        }



        private void DeleteDataFromTblNoiDungTC(string mucTieuValue, string columnName, bool isChecked)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(mconnectstring))
                {
                    connection.Open();

                    string deleteSqlNoiDung = $"DELETE FROM NoiDungMucTieuNhanVien WHERE NDMucTieu = @MucTieuValue";
                    using (SqlCommand deleteCmdNoiDung = new SqlCommand(deleteSqlNoiDung, connection))
                    {
                        deleteCmdNoiDung.Parameters.AddWithValue("@MucTieuValue", mucTieuValue);
                        deleteCmdNoiDung.ExecuteNonQuery();
                    }

                    // Thực hiện UPDATE cho từng cột cần cập nhật trong bảng MucTieuKPI
                    if (columnName == "cTruongKhoaTC")
                    {
                        UpdateColumnInMucTieuKPI(connection, "TruongKhoa", isChecked, mucTieuValue);
                    }
                    else if (columnName == "cPhoTruongKhoaTC")
                    {
                        UpdateColumnInMucTieuKPI(connection, "PhoTruongKhoa", isChecked, mucTieuValue);
                    }
                    else if (columnName == "cDDTruongTC")
                    {
                        UpdateColumnInMucTieuKPI(connection, "DDTruong", isChecked, mucTieuValue);
                    }
                    else if (columnName == "cBSNoiNhiTC")
                    {
                        UpdateColumnInMucTieuKPI(connection, "BSNoiNhi", isChecked, mucTieuValue);
                    }
                    else if (columnName == "cDDCSTC")
                    {
                        UpdateColumnInMucTieuKPI(connection, "DDCS", isChecked, mucTieuValue);
                    }
                    else if (columnName == "cTKYKTC")
                    {
                        UpdateColumnInMucTieuKPI(connection, "TKYK", isChecked, mucTieuValue);
                    }
                    else if (columnName == "cNVHDTC")
                    {
                        UpdateColumnInMucTieuKPI(connection, "NVHD", isChecked, mucTieuValue);
                    }
                    else if (columnName == "cHoLyTC")
                    {
                        UpdateColumnInMucTieuKPI(connection, "HoLy", isChecked, mucTieuValue);
                    }
                    else if (columnName == "cNVBaoTriTC")
                    {
                        UpdateColumnInMucTieuKPI(connection, "NVBaoTri  ", isChecked, mucTieuValue);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thực hiện xoá dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DeleteDataFromTblNoiDungKH(string mucTieuValue, string columnName, bool isChecked)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(mconnectstring))
                {
                    connection.Open();

                    string deleteSqlNoiDung = $"DELETE FROM NoiDungMucTieuNhanVien WHERE NDMucTieu = @MucTieuValue";
                    using (SqlCommand deleteCmdNoiDung = new SqlCommand(deleteSqlNoiDung, connection))
                    {
                        deleteCmdNoiDung.Parameters.AddWithValue("@MucTieuValue", mucTieuValue);
                        deleteCmdNoiDung.ExecuteNonQuery();
                    }

                    // Thực hiện UPDATE cho từng cột cần cập nhật trong bảng MucTieuKPI
                    if (columnName == "cTruongKhoaKH")
                    {
                        UpdateColumnInMucTieuKPI(connection, "TruongKhoa", isChecked, mucTieuValue);
                    }
                    else if (columnName == "cPhoTruongKhoaKH")
                    {
                        UpdateColumnInMucTieuKPI(connection, "PhoTruongKhoa", isChecked, mucTieuValue);
                    }
                    else if (columnName == "cDDTruongKH")
                    {
                        UpdateColumnInMucTieuKPI(connection, "DDTruong", isChecked, mucTieuValue);
                    }
                    else if (columnName == "cBSNoiNhiKH")
                    {
                        UpdateColumnInMucTieuKPI(connection, "BSNoiNhi", isChecked, mucTieuValue);
                    }
                    else if (columnName == "cDDCSKH")
                    {
                        UpdateColumnInMucTieuKPI(connection, "DDCS", isChecked, mucTieuValue);
                    }
                    else if (columnName == "cTKYKKH")
                    {
                        UpdateColumnInMucTieuKPI(connection, "TKYK", isChecked, mucTieuValue);
                    }
                    else if (columnName == "cNVHDKH")
                    {
                        UpdateColumnInMucTieuKPI(connection, "NVHD", isChecked, mucTieuValue);
                    }
                    else if (columnName == "cHoLyKH")
                    {
                        UpdateColumnInMucTieuKPI(connection, "HoLy", isChecked, mucTieuValue);
                    }
                    else if (columnName == "cNVBaoTriKH")
                    {
                        UpdateColumnInMucTieuKPI(connection, "NVBaoTri  ", isChecked, mucTieuValue);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thực hiện xoá dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateColumnInMucTieuKPI(SqlConnection connection, string columnName, bool isChecked, string mucTieuValue)
        {
            string updateSql = $"UPDATE MucTieuKPI SET {columnName} = @IsChecked WHERE MucTieu = @MucTieu";

            using (SqlCommand updateCmd = new SqlCommand(updateSql, connection))
            {
                updateCmd.Parameters.AddWithValue("@IsChecked", isChecked ? 0 : 0);
                updateCmd.Parameters.AddWithValue("@MucTieu", mucTieuValue);
                updateCmd.ExecuteNonQuery();
            }
        }

        private void DeleteDataFromTblNoiDungVH(string mucTieuValue, string columnName, bool isChecked)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(mconnectstring))
                {
                    connection.Open();

                    string deleteSqlNoiDung = $"DELETE FROM NoiDungMucTieuNhanVien WHERE NDMucTieu = @MucTieuValue";
                    using (SqlCommand deleteCmdNoiDung = new SqlCommand(deleteSqlNoiDung, connection))
                    {
                        deleteCmdNoiDung.Parameters.AddWithValue("@MucTieuValue", mucTieuValue);
                        deleteCmdNoiDung.ExecuteNonQuery();
                    }

                    // Thực hiện UPDATE cho từng cột cần cập nhật trong bảng MucTieuKPI
                    if (columnName == "cTruongKhoaVH")
                    {
                        UpdateColumnInMucTieuKPI(connection, "TruongKhoa", isChecked, mucTieuValue);
                    }
                    else if (columnName == "cPhoTruongKhoaVH")
                    {
                        UpdateColumnInMucTieuKPI(connection, "PhoTruongKhoa", isChecked, mucTieuValue);
                    }
                    else if (columnName == "cDDTruongVH")
                    {
                        UpdateColumnInMucTieuKPI(connection, "DDTruong", isChecked, mucTieuValue);
                    }
                    else if (columnName == "cBSNoiNhiVH")
                    {
                        UpdateColumnInMucTieuKPI(connection, "BSNoiNhi", isChecked, mucTieuValue);
                    }
                    else if (columnName == "cDDCSVH")
                    {
                        UpdateColumnInMucTieuKPI(connection, "DDCS", isChecked, mucTieuValue);
                    }
                    else if (columnName == "cTKYKVH")
                    {
                        UpdateColumnInMucTieuKPI(connection, "TKYK", isChecked, mucTieuValue);
                    }
                    else if (columnName == "cNVHDVH")
                    {
                        UpdateColumnInMucTieuKPI(connection, "NVHD", isChecked, mucTieuValue);
                    }
                    else if (columnName == "cHoLyVH")
                    {
                        UpdateColumnInMucTieuKPI(connection, "HoLy", isChecked, mucTieuValue);
                    }
                    else if (columnName == "cNVBaoTriVH")
                    {
                        UpdateColumnInMucTieuKPI(connection, "NVBaoTri  ", isChecked, mucTieuValue);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thực hiện xoá dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DeleteDataFromTblNoiDungPT(string mucTieuValue, string columnName, bool isChecked)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(mconnectstring))
                {
                    connection.Open();

                    string deleteSqlNoiDung = $"DELETE FROM NoiDungMucTieuNhanVien WHERE NDMucTieu = @MucTieuValue";
                    using (SqlCommand deleteCmdNoiDung = new SqlCommand(deleteSqlNoiDung, connection))
                    {
                        deleteCmdNoiDung.Parameters.AddWithValue("@MucTieuValue", mucTieuValue);
                        deleteCmdNoiDung.ExecuteNonQuery();
                    }

                    // Thực hiện UPDATE cho từng cột cần cập nhật trong bảng MucTieuKPI
                    if (columnName == "cTruongKhoaPT")
                    {
                        UpdateColumnInMucTieuKPI(connection, "TruongKhoa", isChecked, mucTieuValue);
                    }
                    else if (columnName == "cPhoTruongKhoaPT")
                    {
                        UpdateColumnInMucTieuKPI(connection, "PhoTruongKhoa", isChecked, mucTieuValue);
                    }
                    else if (columnName == "cDDTruongPT")
                    {
                        UpdateColumnInMucTieuKPI(connection, "DDTruong", isChecked, mucTieuValue);
                    }
                    else if (columnName == "cBSNoiNhiPT")
                    {
                        UpdateColumnInMucTieuKPI(connection, "BSNoiNhi", isChecked, mucTieuValue);
                    }
                    else if (columnName == "cDDCSPT")
                    {
                        UpdateColumnInMucTieuKPI(connection, "DDCS", isChecked, mucTieuValue);
                    }
                    else if (columnName == "cTKYKPT")
                    {
                        UpdateColumnInMucTieuKPI(connection, "TKYK", isChecked, mucTieuValue);
                    }
                    else if (columnName == "cNVHDPT")
                    {
                        UpdateColumnInMucTieuKPI(connection, "NVHD", isChecked, mucTieuValue);
                    }
                    else if (columnName == "cHoLyPT")
                    {
                        UpdateColumnInMucTieuKPI(connection, "HoLy", isChecked, mucTieuValue);
                    }
                    else if (columnName == "cNVBaoTriPT")
                    {
                        UpdateColumnInMucTieuKPI(connection, "NVBaoTri  ", isChecked, mucTieuValue);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thực hiện xoá dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateDataInMucTieuTCKPI(string mucTieuValue, string columnName, bool isChecked, string ttValue, string maNhomValue, int trongSoValue)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(mconnectstring))
                {
                    connection.Open();

                    // Thực hiện INSERT dữ liệu
                    string insertSql = "INSERT INTO NoiDungMucTieuNhanVien (NDMucTieu, TT, MaNhom, TrongSo) VALUES (@MucTieuValue, @TT, @MaNhom, @TrongSo)";
                    using (SqlCommand insertCmd = new SqlCommand(insertSql, connection))
                    {
                        insertCmd.Parameters.AddWithValue("@TT", ttValue);
                        insertCmd.Parameters.AddWithValue("@MucTieuValue", mucTieuValue);
                        insertCmd.Parameters.AddWithValue("@MaNhom", maNhomValue);
                        insertCmd.Parameters.AddWithValue("@TrongSo", trongSoValue);
                        insertCmd.ExecuteNonQuery();
                    }

                    string updateSql1 = $"UPDATE NoiDungMucTieuNhanVien SET ";

                    switch (columnName)
                    {
                        case "cTruongKhoaTC":
                            updateSql1 += "TruongKhoa = @IsChecked";
                            break;
                        case "cPhoTruongKhoaTC":
                            updateSql1 += "PhoTruongKhoa = @IsChecked";
                            break;
                        case "cDDTruongTC":
                            updateSql1 += "DDTruong = @IsChecked";
                            break;
                        case "cBSNoiNhiTC":
                            updateSql1 += "BSNoiNhi = @IsChecked";
                            break;
                        case "cDDCSTC":
                            updateSql1 += "DDCS = @IsChecked";
                            break;
                        case "cTKYKTC":
                            updateSql1 += "TKYK = @IsChecked";
                            break;
                        case "cNVHDTC":
                            updateSql1 += "NVHD = @IsChecked";
                            break;
                        case "cHoLyTC":
                            updateSql1 += "HoLy = @IsChecked";
                            break;
                        case "cNVBaoTriTC":
                            updateSql1 += "NVBaoTri = @IsChecked";
                            break;
                        default:
                            // Trường hợp mặc định nếu không phải là một cột bạn quan tâm
                            return;
                    }

                   
                      //updateSql1 += " WHERE NDMucTieu = @MucTieu AND MaNhom = @MaNhom"; // Add MaNhom for specificity
                    updateSql1 += " WHERE id = '"+ Checked(mucTieuValue, maNhomValue) + "'"; // Add MaNhom for specificity

                    using (SqlCommand updateCmd1 = new SqlCommand(updateSql1, connection))
                    {
                        updateCmd1.Parameters.AddWithValue("@IsChecked", isChecked ? 1 : 0);
                        //    updateCmd1.Parameters.AddWithValue("@MucTieu", mucTieuValue);
                        //    updateCmd1.Parameters.AddWithValue("@MaNhom", maNhomValue); // Add MaNhom parameter
                        updateCmd1.ExecuteNonQuery();
                    }



                    // Thực hiện UPDATE cho cột trong bảng MucTieuKPI
                    string updateSql2 = $"UPDATE MucTieuKPI SET ";

                    switch (columnName)
                    {
                        case "cTruongKhoaTC":
                            updateSql2 += "TruongKhoa = @IsChecked";
                            break;
                        case "cPhoTruongKhoaTC":
                            updateSql2 += "PhoTruongKhoa = @IsChecked";
                            break;
                        case "cDDTruongTC":
                            updateSql2 += "DDTruong = @IsChecked";
                            break;
                        case "cBSNoiNhiTC":
                            updateSql2 += "BSNoiNhi = @IsChecked";
                            break;
                        case "cDDCSTC":
                            updateSql2 += "DDCS = @IsChecked";
                            break;
                        case "cTKYKTC":
                            updateSql2 += "TKYK = @IsChecked";
                            break;
                        case "cNVHDTC":
                            updateSql2 += "NVHD = @IsChecked";
                            break;
                        case "cHoLyTC":
                            updateSql2 += "HoLy = @IsChecked";
                            break;
                        case "cNVBaoTriTC":
                            updateSql2 += "NVBaoTri = @IsChecked";
                            break;
                        default:
                            // Trường hợp mặc định nếu không phải là một cột bạn quan tâm
                            return;
                    }

                    updateSql2 += " WHERE MucTieu = @MucTieu AND MaNhom = @MaNhom" ; // Add MaNhom for specificity

                    using (SqlCommand updateCmd2 = new SqlCommand(updateSql2, connection))
                    {
                        updateCmd2.Parameters.AddWithValue("@IsChecked", isChecked ? 1 : 0);
                        updateCmd2.Parameters.AddWithValue("@MucTieu", mucTieuValue);
                        updateCmd2.Parameters.AddWithValue("@MaNhom", maNhomValue); // Add MaNhom parameter
                        updateCmd2.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thực hiện thay đổi dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateDataInMucTieuKHKPI(string mucTieuValue, string columnName, bool isChecked, string ttValue, string maNhomValue, int trongSoValue)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(mconnectstring))
                {
                    connection.Open();

                    // Thực hiện INSERT dữ liệu
                    string insertSql = "INSERT INTO NoiDungMucTieuNhanVien (NDMucTieu, TT, MaNhom, TrongSo) VALUES (@MucTieuValue, @TT, @MaNhom, @TrongSo)";
                    using (SqlCommand insertCmd = new SqlCommand(insertSql, connection))
                    {
                        insertCmd.Parameters.AddWithValue("@TT", ttValue);
                        insertCmd.Parameters.AddWithValue("@MucTieuValue", mucTieuValue);
                        insertCmd.Parameters.AddWithValue("@MaNhom", maNhomValue);
                        insertCmd.Parameters.AddWithValue("@TrongSo", trongSoValue);
                        insertCmd.ExecuteNonQuery();
                    }

                    string updateSql1 = $"UPDATE NoiDungMucTieuNhanVien SET ";

                    switch (columnName)
                    {
                        case "cTruongKhoaKH":
                            updateSql1 += "TruongKhoa = @IsChecked";
                            break;
                        case "cPhoTruongKhoaKH":
                            updateSql1 += "PhoTruongKhoa = @IsChecked";
                            break;
                        case "cDDTruongKH":
                            updateSql1 += "DDTruong = @IsChecked";
                            break;
                        case "cBSNoiNhiKH":
                            updateSql1 += "BSNoiNhi = @IsChecked";
                            break;
                        case "cDDCSKH":
                            updateSql1 += "DDCS = @IsChecked";
                            break;
                        case "cTKYKKH":
                            updateSql1 += "TKYK = @IsChecked";
                            break;
                        case "cNVHDKH":
                            updateSql1 += "NVHD = @IsChecked";
                            break;
                        case "cHoLyKH":
                            updateSql1 += "HoLy = @IsChecked";
                            break;
                        case "cNVBaoTriKH":
                            updateSql1 += "NVBaoTri = @IsChecked";
                            break;
                        default:
                            // Trường hợp mặc định nếu không phải là một cột bạn quan tâm
                            return;
                    }


                    //updateSql1 += " WHERE NDMucTieu = @MucTieu AND MaNhom = @MaNhom"; // Add MaNhom for specificity
                    updateSql1 += " WHERE id = '" + Checked(mucTieuValue, maNhomValue) + "'"; // Add MaNhom for specificity

                    using (SqlCommand updateCmd1 = new SqlCommand(updateSql1, connection))
                    {
                        updateCmd1.Parameters.AddWithValue("@IsChecked", isChecked ? 1 : 0);
                        //    updateCmd1.Parameters.AddWithValue("@MucTieu", mucTieuValue);
                        //    updateCmd1.Parameters.AddWithValue("@MaNhom", maNhomValue); // Add MaNhom parameter
                        updateCmd1.ExecuteNonQuery();
                    }



                    // Thực hiện UPDATE cho cột trong bảng MucTieuKPI
                    string updateSql2 = $"UPDATE MucTieuKPI SET ";

                    switch (columnName)
                    {
                        case "cTruongKhoaKH":
                            updateSql2 += "TruongKhoa = @IsChecked";
                            break;
                        case "cPhoTruongKhoaKH":
                            updateSql2 += "PhoTruongKhoa = @IsChecked";
                            break;
                        case "cDDTruongKH":
                            updateSql2 += "DDTruong = @IsChecked";
                            break;
                        case "cBSNoiNhiKH":
                            updateSql2 += "BSNoiNhi = @IsChecked";
                            break;
                        case "cDDCSKH":
                            updateSql2 += "DDCS = @IsChecked";
                            break;
                        case "cTKYKKH":
                            updateSql2 += "TKYK = @IsChecked";
                            break;
                        case "cNVHDKH":
                            updateSql2 += "NVHD = @IsChecked";
                            break;
                        case "cHoLyKH":
                            updateSql2 += "HoLy = @IsChecked";
                            break;
                        case "cNVBaoTriKH":
                            updateSql2 += "NVBaoTri = @IsChecked";
                            break;
                        default:
                            // Trường hợp mặc định nếu không phải là một cột bạn quan tâm
                            return;
                    }

                    updateSql2 += " WHERE MucTieu = @MucTieu AND MaNhom = @MaNhom"; // Add MaNhom for specificity

                    using (SqlCommand updateCmd2 = new SqlCommand(updateSql2, connection))
                    {
                        updateCmd2.Parameters.AddWithValue("@IsChecked", isChecked ? 1 : 0);
                        updateCmd2.Parameters.AddWithValue("@MucTieu", mucTieuValue);
                        updateCmd2.Parameters.AddWithValue("@MaNhom", maNhomValue); // Add MaNhom parameter
                        updateCmd2.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thực hiện thay đổi dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateDataInMucTieuVHKPI(string mucTieuValue, string columnName, bool isChecked, string ttValue, string maNhomValue, int trongSoValue)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(mconnectstring))
                {
                    connection.Open();

                    // Thực hiện INSERT dữ liệu
                    string insertSql = "INSERT INTO NoiDungMucTieuNhanVien (NDMucTieu, TT, MaNhom, TrongSo) VALUES (@MucTieuValue, @TT, @MaNhom, @TrongSo)";
                    using (SqlCommand insertCmd = new SqlCommand(insertSql, connection))
                    {
                        insertCmd.Parameters.AddWithValue("@TT", ttValue);
                        insertCmd.Parameters.AddWithValue("@MucTieuValue", mucTieuValue);
                        insertCmd.Parameters.AddWithValue("@MaNhom", maNhomValue);
                        insertCmd.Parameters.AddWithValue("@TrongSo", trongSoValue);
                        insertCmd.ExecuteNonQuery();
                    }

                    string updateSql1 = $"UPDATE NoiDungMucTieuNhanVien SET ";

                    switch (columnName)
                    {
                        case "cTruongKhoaVH":
                            updateSql1 += "TruongKhoa = @IsChecked";
                            break;
                        case "cPhoTruongKhoaVH":
                            updateSql1 += "PhoTruongKhoa = @IsChecked";
                            break;
                        case "cDDTruongVH":
                            updateSql1 += "DDTruong = @IsChecked";
                            break;
                        case "cBSNoiNhiVH":
                            updateSql1 += "BSNoiNhi = @IsChecked";
                            break;
                        case "cDDCSVH":
                            updateSql1 += "DDCS = @IsChecked";
                            break;
                        case "cTKYKVH":
                            updateSql1 += "TKYK = @IsChecked";
                            break;
                        case "cNVHDVH":
                            updateSql1 += "NVHD = @IsChecked";
                            break;
                        case "cHoLyVH":
                            updateSql1 += "HoLy = @IsChecked";
                            break;
                        case "cNVBaoTriVH":
                            updateSql1 += "NVBaoTri = @IsChecked";
                            break;
                        default:
                            // Trường hợp mặc định nếu không phải là một cột bạn quan tâm
                            return;
                    }


                    //updateSql1 += " WHERE NDMucTieu = @MucTieu AND MaNhom = @MaNhom"; // Add MaNhom for specificity
                    updateSql1 += " WHERE id = '" + Checked(mucTieuValue, maNhomValue) + "'"; // Add MaNhom for specificity

                    using (SqlCommand updateCmd1 = new SqlCommand(updateSql1, connection))
                    {
                        updateCmd1.Parameters.AddWithValue("@IsChecked", isChecked ? 1 : 0);
                        //    updateCmd1.Parameters.AddWithValue("@MucTieu", mucTieuValue);
                        //    updateCmd1.Parameters.AddWithValue("@MaNhom", maNhomValue); // Add MaNhom parameter
                        updateCmd1.ExecuteNonQuery();
                    }



                    // Thực hiện UPDATE cho cột trong bảng MucTieuKPI
                    string updateSql2 = $"UPDATE MucTieuKPI SET ";

                    switch (columnName)
                    {
                        case "cTruongKhoaVH":
                            updateSql2 += "TruongKhoa = @IsChecked";
                            break;
                        case "cPhoTruongKhoaVH":
                            updateSql2 += "PhoTruongKhoa = @IsChecked";
                            break;
                        case "cDDTruongVH":
                            updateSql2 += "DDTruong = @IsChecked";
                            break;
                        case "cBSNoiNhiVH":
                            updateSql2 += "BSNoiNhi = @IsChecked";
                            break;
                        case "cDDCSVH":
                            updateSql2 += "DDCS = @IsChecked";
                            break;
                        case "cTKYKVH":
                            updateSql2 += "TKYK = @IsChecked";
                            break;
                        case "cNVHDVH":
                            updateSql2 += "NVHD = @IsChecked";
                            break;
                        case "cHoLyVH":
                            updateSql2 += "HoLy = @IsChecked";
                            break;
                        case "cNVBaoTriVH":
                            updateSql2 += "NVBaoTri = @IsChecked";
                            break;
                        default:
                            // Trường hợp mặc định nếu không phải là một cột bạn quan tâm
                            return;
                    }

                    updateSql2 += " WHERE MucTieu = @MucTieu AND MaNhom = @MaNhom"; // Add MaNhom for specificity

                    using (SqlCommand updateCmd2 = new SqlCommand(updateSql2, connection))
                    {
                        updateCmd2.Parameters.AddWithValue("@IsChecked", isChecked ? 1 : 0);
                        updateCmd2.Parameters.AddWithValue("@MucTieu", mucTieuValue);
                        updateCmd2.Parameters.AddWithValue("@MaNhom", maNhomValue); // Add MaNhom parameter
                        updateCmd2.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thực hiện thay đổi dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateDataInMucTieuPTKPI(string mucTieuValue, string columnName, bool isChecked, string ttValue, string maNhomValue, int trongSoValue)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(mconnectstring))
                {
                    connection.Open();

                    // Thực hiện INSERT dữ liệu
                    string insertSql = "INSERT INTO NoiDungMucTieuNhanVien (NDMucTieu, TT, MaNhom, TrongSo) VALUES (@MucTieuValue, @TT, @MaNhom, @TrongSo)";
                    using (SqlCommand insertCmd = new SqlCommand(insertSql, connection))
                    {
                        insertCmd.Parameters.AddWithValue("@TT", ttValue);
                        insertCmd.Parameters.AddWithValue("@MucTieuValue", mucTieuValue);
                        insertCmd.Parameters.AddWithValue("@MaNhom", maNhomValue);
                        insertCmd.Parameters.AddWithValue("@TrongSo", trongSoValue);
                        insertCmd.ExecuteNonQuery();
                    }

                    string updateSql1 = $"UPDATE NoiDungMucTieuNhanVien SET ";

                    switch (columnName)
                    {
                        case "cTruongKhoaPT":
                            updateSql1 += "TruongKhoa = @IsChecked";
                            break;
                        case "cPhoTruongKhoaPT":
                            updateSql1 += "PhoTruongKhoa = @IsChecked";
                            break;
                        case "cDDTruongPT":
                            updateSql1 += "DDTruong = @IsChecked";
                            break;
                        case "cBSNoiNhiPT":
                            updateSql1 += "BSNoiNhi = @IsChecked";
                            break;
                        case "cDDCSPT":
                            updateSql1 += "DDCS = @IsChecked";
                            break;
                        case "cTKYKPT":
                            updateSql1 += "TKYK = @IsChecked";
                            break;
                        case "cNVHDPT":
                            updateSql1 += "NVHD = @IsChecked";
                            break;
                        case "cHoLyPT":
                            updateSql1 += "HoLy = @IsChecked";
                            break;
                        case "cNVBaoTriPT":
                            updateSql1 += "NVBaoTri = @IsChecked";
                            break;
                        default:
                            // Trường hợp mặc định nếu không phải là một cột bạn quan tâm
                            return;
                    }


                    //updateSql1 += " WHERE NDMucTieu = @MucTieu AND MaNhom = @MaNhom"; // Add MaNhom for specificity
                    updateSql1 += " WHERE id = '" + Checked(mucTieuValue, maNhomValue) + "'"; // Add MaNhom for specificity

                    using (SqlCommand updateCmd1 = new SqlCommand(updateSql1, connection))
                    {
                        updateCmd1.Parameters.AddWithValue("@IsChecked", isChecked ? 1 : 0);
                        //    updateCmd1.Parameters.AddWithValue("@MucTieu", mucTieuValue);
                        //    updateCmd1.Parameters.AddWithValue("@MaNhom", maNhomValue); // Add MaNhom parameter
                        updateCmd1.ExecuteNonQuery();
                    }



                    // Thực hiện UPDATE cho cột trong bảng MucTieuKPI
                    string updateSql2 = $"UPDATE MucTieuKPI SET ";

                    switch (columnName)
                    {
                        case "cTruongKhoaPT":
                            updateSql2 += "TruongKhoa = @IsChecked";
                            break;
                        case "cPhoTruongKhoaVH":
                            updateSql2 += "PhoTruongKhoa = @IsChecked";
                            break;
                        case "cDDTruongPT":
                            updateSql2 += "DDTruong = @IsChecked";
                            break;
                        case "cBSNoiNhiPT":
                            updateSql2 += "BSNoiNhi = @IsChecked";
                            break;
                        case "cDDCSPT":
                            updateSql2 += "DDCS = @IsChecked";
                            break;
                        case "cTKYKPT":
                            updateSql2 += "TKYK = @IsChecked";
                            break;
                        case "cNVHDPT":
                            updateSql2 += "NVHD = @IsChecked";
                            break;
                        case "cHoLyPT":
                            updateSql2 += "HoLy = @IsChecked";
                            break;
                        case "cNVBaoTriPT":
                            updateSql2 += "NVBaoTri = @IsChecked";
                            break;
                        default:
                            // Trường hợp mặc định nếu không phải là một cột bạn quan tâm
                            return;
                    }

                    updateSql2 += " WHERE MucTieu = @MucTieu AND MaNhom = @MaNhom"; // Add MaNhom for specificity

                    using (SqlCommand updateCmd2 = new SqlCommand(updateSql2, connection))
                    {
                        updateCmd2.Parameters.AddWithValue("@IsChecked", isChecked ? 1 : 0);
                        updateCmd2.Parameters.AddWithValue("@MucTieu", mucTieuValue);
                        updateCmd2.Parameters.AddWithValue("@MaNhom", maNhomValue); // Add MaNhom parameter
                        updateCmd2.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thực hiện thay đổi dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgrDanhSachMucTieuKPI_CellValueChanged_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm_MucTieuNhanVien f = new Frm_MucTieuNhanVien();
            f.ShowDialog();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            Frm_MucTieuNhanVien f = new Frm_MucTieuNhanVien();
            f.ShowDialog();
        }

       

        private void cboMaNhom_TextChanged_1(object sender, EventArgs e)
        {
            
        }

        private void dgrDanhSachMucTieuKPI_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell cell = dgrDanhSachMucTieuTCKPI.Rows[e.RowIndex].Cells[e.ColumnIndex];

                // Kiểm tra xem cell được click có phải là cell chứa checkbox hay không
                if (cell is DataGridViewCheckBoxCell)
                {
                    bool isChecked = (bool)cell.EditedFormattedValue; // Lấy giá trị sau khi được edit
                    string mucTieuValue = dgrDanhSachMucTieuTCKPI.Rows[e.RowIndex].Cells["cMucTieuTC"].Value.ToString();
                    string columnName = dgrDanhSachMucTieuTCKPI.Columns[e.ColumnIndex].Name;

                    // Lấy giá trị của cột "cTT" tương ứng với dòng hiện tại
                    string ttValue = dgrDanhSachMucTieuTCKPI.Rows[e.RowIndex].Cells["cTTTC"].Value.ToString();
                    string maNhomValue = dgrDanhSachMucTieuTCKPI.Rows[e.RowIndex].Cells["cMaNhomTC"].Value.ToString();
                    int trongSoValue = Convert.ToInt32(dgrDanhSachMucTieuTCKPI.Rows[e.RowIndex].Cells["cTrongSoTC"].Value);

                    if (isChecked)
                    {
                        // Gọi hàm UpdateDataInMucTieuKPI với tên cột, giá trị tương ứng, giá trị TT, MaNhom và TrongSo
                        UpdateDataInMucTieuTCKPI(mucTieuValue, columnName, isChecked, ttValue, maNhomValue, trongSoValue);
                    }
                    else
                    {
                        // Nếu checkbox bị bỏ chọn, gọi hàm DeleteDataFromTblNoiDung
                        DeleteDataFromTblNoiDungTC(mucTieuValue, columnName, isChecked);
                    }
                }
            }
        }

        private void dgrDanhSachMucTieuTCKPI_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgrDanhSachMucTieuTCKPI.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn && e.RowIndex >= 0)
            {
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)dgrDanhSachMucTieuTCKPI.Rows[e.RowIndex].Cells[e.ColumnIndex];

                // Đảo ngược trạng thái của checkbox khi được click
                cell.Value = !(bool)cell.Value;
            }
        }

        private void dgrDanhSachMucTieuTCKPI_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell cell = dgrDanhSachMucTieuTCKPI.Rows[e.RowIndex].Cells[e.ColumnIndex];

                if (cell is DataGridViewCheckBoxCell)
                {
                    bool isChecked = (bool)cell.Value;
                    string mucTieuValue = dgrDanhSachMucTieuTCKPI.Rows[e.RowIndex].Cells["cMucTieuTC"].Value.ToString();
                    string columnName = dgrDanhSachMucTieuTCKPI.Columns[e.ColumnIndex].Name;

                    // Lấy giá trị của cột "cTT" tương ứng với dòng hiện tại
                    string ttValue = dgrDanhSachMucTieuTCKPI.Rows[e.RowIndex].Cells["cTTTC"].Value.ToString();
                    string maNhomValue = dgrDanhSachMucTieuTCKPI.Rows[e.RowIndex].Cells["cMaNhomTC"].Value.ToString();
                    int trongSoValue = Convert.ToInt32(dgrDanhSachMucTieuTCKPI.Rows[e.RowIndex].Cells["cTrongSoTC"].Value);

                    if (isChecked)
                    {
                        // Gọi hàm UpdateDataInMucTieuKPI với tên cột, giá trị tương ứng, giá trị TT, MaNhom và TrongSo
                        UpdateDataInMucTieuTCKPI(mucTieuValue, columnName, isChecked, ttValue, maNhomValue, trongSoValue);
                    }
                    else
                    {
                        // Nếu checkbox bị bỏ chọn, gọi hàm DeleteDataFromTblNoiDung
                        DeleteDataFromTblNoiDungTC(mucTieuValue, columnName, isChecked);
                    }
                }
            }
        }

        private void dgrDanhSachMucTieuKHKPI_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell cell = dgrDanhSachMucTieuKHKPI.Rows[e.RowIndex].Cells[e.ColumnIndex];

                if (cell is DataGridViewCheckBoxCell)
                {
                    bool isChecked = (bool)cell.Value;
                    string mucTieuValue = dgrDanhSachMucTieuKHKPI.Rows[e.RowIndex].Cells["cMucTieuKH"].Value.ToString();
                    string columnName = dgrDanhSachMucTieuKHKPI.Columns[e.ColumnIndex].Name;

                    // Lấy giá trị của cột "cTT" tương ứng với dòng hiện tại
                    string ttValue = dgrDanhSachMucTieuKHKPI.Rows[e.RowIndex].Cells["cTTKH"].Value.ToString();
                    string maNhomValue = dgrDanhSachMucTieuKHKPI.Rows[e.RowIndex].Cells["cMaNhomKH"].Value.ToString();
                    int trongSoValue = Convert.ToInt32(dgrDanhSachMucTieuKHKPI.Rows[e.RowIndex].Cells["cTrongSoKH"].Value);

                    if (isChecked)
                    {
                        // Gọi hàm UpdateDataInMucTieuKPI với tên cột, giá trị tương ứng, giá trị TT, MaNhom và TrongSo
                        UpdateDataInMucTieuKHKPI(mucTieuValue, columnName, isChecked, ttValue, maNhomValue, trongSoValue);
                    }
                    else
                    {
                        // Nếu checkbox bị bỏ chọn, gọi hàm DeleteDataFromTblNoiDung
                        DeleteDataFromTblNoiDungKH(mucTieuValue, columnName, isChecked);
                    }
                }
            }
        }

        private void dgrDanhSachMucTieuVHKPI_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell cell = dgrDanhSachMucTieuVHKPI.Rows[e.RowIndex].Cells[e.ColumnIndex];

                if (cell is DataGridViewCheckBoxCell)
                {
                    bool isChecked = (bool)cell.Value;
                    string mucTieuValue = dgrDanhSachMucTieuVHKPI.Rows[e.RowIndex].Cells["cMucTieuVH"].Value.ToString();
                    string columnName = dgrDanhSachMucTieuVHKPI.Columns[e.ColumnIndex].Name;

                    // Lấy giá trị của cột "cTT" tương ứng với dòng hiện tại
                    string ttValue = dgrDanhSachMucTieuVHKPI.Rows[e.RowIndex].Cells["cTTVH"].Value.ToString();
                    string maNhomValue = dgrDanhSachMucTieuVHKPI.Rows[e.RowIndex].Cells["cMaNhomVH"].Value.ToString();
                    int trongSoValue = Convert.ToInt32(dgrDanhSachMucTieuVHKPI.Rows[e.RowIndex].Cells["cTrongSoVH"].Value);

                    if (isChecked)
                    {
                        // Gọi hàm UpdateDataInMucTieuKPI với tên cột, giá trị tương ứng, giá trị TT, MaNhom và TrongSo
                        UpdateDataInMucTieuVHKPI(mucTieuValue, columnName, isChecked, ttValue, maNhomValue, trongSoValue);
                    }
                    else
                    {
                        // Nếu checkbox bị bỏ chọn, gọi hàm DeleteDataFromTblNoiDung
                        DeleteDataFromTblNoiDungVH(mucTieuValue, columnName, isChecked);
                    }
                }
            }
        }

        private void dgrDanhSachMucTieuPTKPI_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell cell = dgrDanhSachMucTieuPTKPI.Rows[e.RowIndex].Cells[e.ColumnIndex];

                if (cell is DataGridViewCheckBoxCell)
                {
                    bool isChecked = (bool)cell.Value;
                    string mucTieuValue = dgrDanhSachMucTieuPTKPI.Rows[e.RowIndex].Cells["cMucTieuPT"].Value.ToString();
                    string columnName = dgrDanhSachMucTieuPTKPI.Columns[e.ColumnIndex].Name;

                    // Lấy giá trị của cột "cTT" tương ứng với dòng hiện tại
                    string ttValue = dgrDanhSachMucTieuPTKPI.Rows[e.RowIndex].Cells["cTTPT"].Value.ToString();
                    string maNhomValue = dgrDanhSachMucTieuPTKPI.Rows[e.RowIndex].Cells["cMaNhomPT"].Value.ToString();
                    int trongSoValue = Convert.ToInt32(dgrDanhSachMucTieuPTKPI.Rows[e.RowIndex].Cells["cTrongSoPT"].Value);

                    if (isChecked)
                    {
                        // Gọi hàm UpdateDataInMucTieuKPI với tên cột, giá trị tương ứng, giá trị TT, MaNhom và TrongSo
                        UpdateDataInMucTieuPTKPI(mucTieuValue, columnName, isChecked, ttValue, maNhomValue, trongSoValue);
                    }
                    else
                    {
                        // Nếu checkbox bị bỏ chọn, gọi hàm DeleteDataFromTblNoiDung
                        DeleteDataFromTblNoiDungPT(mucTieuValue, columnName, isChecked);
                    }
                }
            }
        }

        private void dgrDanhSachMucTieuTCKPI_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgrDanhSachMucTieuTCKPI.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn && e.RowIndex >= 0)
            {
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)dgrDanhSachMucTieuTCKPI.Rows[e.RowIndex].Cells[e.ColumnIndex];

                // Đảo ngược trạng thái của checkbox khi được click
                cell.Value = !(bool)cell.Value;
            }
        }

        private void dgrDanhSachMucTieuKHKPI_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgrDanhSachMucTieuKHKPI.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn && e.RowIndex >= 0)
            {
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)dgrDanhSachMucTieuKHKPI.Rows[e.RowIndex].Cells[e.ColumnIndex];

                // Đảo ngược trạng thái của checkbox khi được click
                cell.Value = !(bool)cell.Value;
            }
        }

        private void dgrDanhSachMucTieuVHKPI_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgrDanhSachMucTieuVHKPI.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn && e.RowIndex >= 0)
            {
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)dgrDanhSachMucTieuVHKPI.Rows[e.RowIndex].Cells[e.ColumnIndex];

                // Đảo ngược trạng thái của checkbox khi được click
                cell.Value = !(bool)cell.Value;
            }
        }

        private void dgrDanhSachMucTieuPTKPI_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgrDanhSachMucTieuPTKPI.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn && e.RowIndex >= 0)
            {
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)dgrDanhSachMucTieuPTKPI.Rows[e.RowIndex].Cells[e.ColumnIndex];

                // Đảo ngược trạng thái của checkbox khi được click
                cell.Value = !(bool)cell.Value;
            }
        }

        private void dgrDanhSachMucTieuTCKPI_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgrDanhSachMucTieuTCKPI.Columns[e.ColumnIndex].Name == "cTrongSoTC" && e.Value != null)
            {
                e.Value = $"{e.Value} %"; // Thêm đơn vị vào giá trị
                e.FormattingApplied = true;
            }
        }

        private void dgrDanhSachMucTieuKHKPI_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgrDanhSachMucTieuKHKPI.Columns[e.ColumnIndex].Name == "cTrongSoKH" && e.Value != null)
            {
                e.Value = $"{e.Value} %"; // Thêm đơn vị vào giá trị
                e.FormattingApplied = true;
            }
        }

        private void dgrDanhSachMucTieuVHKPI_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgrDanhSachMucTieuVHKPI.Columns[e.ColumnIndex].Name == "cTrongSoVH" && e.Value != null)
            {
                e.Value = $"{e.Value} %"; // Thêm đơn vị vào giá trị
                e.FormattingApplied = true;
            }
        }

        private void dgrDanhSachMucTieuPTKPI_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgrDanhSachMucTieuPTKPI.Columns[e.ColumnIndex].Name == "cTrongSoPT" && e.Value != null)
            {
                e.Value = $"{e.Value} %"; // Thêm đơn vị vào giá trị
                e.FormattingApplied = true;
            }
        }
    }
}