﻿using BusinessCommon;
using DevExpress.XtraEditors;
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
    public partial class Frm_MucTieuNhanVien : DevExpress.XtraEditors.XtraForm
    {
        public static string mconnectstring = "server=192.168.50.108,1433;database=QuanLyKPI;uid=sa;pwd=123";
        private clsCommonMethod comm = new clsCommonMethod();
        private clsEventArgs ev = new clsEventArgs("");
        private string msql;
        private Dictionary<string, bool> changes = new Dictionary<string, bool>();
        public Frm_MucTieuNhanVien()
        {
            InitializeComponent();
            
            AddColumnsToDataGridView(); // Add this line to initialize the DataGridView columns
            cbTruongKhoa.CheckedChanged += new EventHandler(cbTruongKhoa_CheckedChanged);
            cbPhoTruongKhoa.CheckedChanged += new EventHandler(cbPhoTruongKhoa_CheckedChanged);
            // Thêm sự kiện cho các checkbox khác
            dgrDanhSachMucTieuTaiChinhKPI.CellFormatting += dgrDanhSachMucTieuTaiChinhKPI_CellFormatting;

        }


        private void AddColumnsToDataGridView()
        {
            // Check if the column already exists
            if (dgrDanhSachMucTieuTaiChinhKPI.Columns["cMucTieu"] == null)
            {
                // Add a new column named "cMucTieu"
                DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                column.HeaderText = "cMucTieu";
                column.Name = "cMucTieu";
                dgrDanhSachMucTieuTaiChinhKPI.Columns.Add(column);
            }
        }
        private void SearchDistinctDataTC()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(mconnectstring))
                {
                    connection.Open();

                    StringBuilder queryBuilder = new StringBuilder("SELECT MaNhom,TT,NDMucTieu,TrongSo FROM NoiDungMucTieuNhanVien WHERE ");

                    // Modify conditions based on your checkboxes
                    // For example:
                    if (cbTruongKhoa.Checked)
                        queryBuilder.Append("TruongKhoa = 1 AND ");
                    if (cbPhoTruongKhoa.Checked)
                        queryBuilder.Append("PhoTruongKhoa = 1 AND ");
                    if (cbDDTruong.Checked)
                        queryBuilder.Append("DDTruong = 1 AND ");
                    if (cbBSNoiNhi.Checked)
                        queryBuilder.Append("BSNoiNhi = 1 AND ");
                    if (cbDDCS.Checked)
                        queryBuilder.Append("DDCS = 1 AND ");
                    if (cbTKYK.Checked)
                        queryBuilder.Append("TKYK = 1 AND ");
                    if (cbNVHD.Checked)
                        queryBuilder.Append("NVHD = 1 AND ");
                    if (cbHoLy.Checked)
                        queryBuilder.Append("HoLy = 1 AND ");
                    if (cbNVBaoTri.Checked)
                        queryBuilder.Append("NVBaoTri = 1 AND ");

                    // Add other conditions as needed

                    // Add the condition for MaNhom
                    // Replace "YourMaNhomValue" with the actual value you want to filter by
                    queryBuilder.Append($"MaNhom = 'TC' AND ");

                    // Remove the trailing " AND " from the query
                    if (queryBuilder.ToString().EndsWith(" AND "))
                        queryBuilder.Remove(queryBuilder.Length - 5, 5);

                    using (SqlCommand command = new SqlCommand(queryBuilder.ToString(), connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dgrDanhSachMucTieuTaiChinhKPI.Rows.Clear();

                            int mucTieuColumnIndex = dgrDanhSachMucTieuTaiChinhKPI.Columns["cMucTieu"].Index;
                            int ttColumnIndex = dgrDanhSachMucTieuTaiChinhKPI.Columns["cTT"].Index;
                            int MaNhomColumnIndex = dgrDanhSachMucTieuTaiChinhKPI.Columns["cMaNhom"].Index;
                            int TrongSoColumnIndex = dgrDanhSachMucTieuTaiChinhKPI.Columns["cTrongSo"].Index;




                            while (reader.Read())
                            {
                                string mucTieu = reader["NDMucTieu"].ToString();
                                string ttValue = reader["TT"].ToString();
                                string trongso = reader["TrongSo"].ToString();


                                dgrDanhSachMucTieuTaiChinhKPI.Rows.Add();
                                dgrDanhSachMucTieuTaiChinhKPI.Rows[dgrDanhSachMucTieuTaiChinhKPI.Rows.Count - 1].Cells[mucTieuColumnIndex].Value = mucTieu;
                                dgrDanhSachMucTieuTaiChinhKPI.Rows[dgrDanhSachMucTieuTaiChinhKPI.Rows.Count - 1].Cells[ttColumnIndex].Value = ttValue;
                                dgrDanhSachMucTieuTaiChinhKPI.Rows[dgrDanhSachMucTieuTaiChinhKPI.Rows.Count - 1].Cells[TrongSoColumnIndex].Value = trongso;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thực hiện truy vấn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SearchDistinctDataKH()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(mconnectstring))
                {
                    connection.Open();

                    StringBuilder queryBuilder = new StringBuilder("SELECT MaNhom,TT, NDMucTieu,TrongSo FROM NoiDungMucTieuNhanVien WHERE ");

                    // Modify conditions based on your checkboxes
                    // For example:
                    if (cbTruongKhoa.Checked)
                        queryBuilder.Append("TruongKhoa = 1 AND ");
                    if (cbPhoTruongKhoa.Checked)
                        queryBuilder.Append("PhoTruongKhoa = 1 AND ");
                    if (cbDDTruong.Checked)
                        queryBuilder.Append("DDTruong = 1 AND ");
                    if (cbBSNoiNhi.Checked)
                        queryBuilder.Append("BSNoiNhi = 1 AND ");
                    if (cbDDCS.Checked)
                        queryBuilder.Append("DDCS = 1 AND ");
                    if (cbTKYK.Checked)
                        queryBuilder.Append("TKYK = 1 AND ");
                    if (cbNVHD.Checked)
                        queryBuilder.Append("NVHD = 1 AND ");
                    if (cbHoLy.Checked)
                        queryBuilder.Append("HoLy = 1 AND ");
                    if (cbNVBaoTri.Checked)
                        queryBuilder.Append("NVBaoTri = 1 AND ");

                    // Add other conditions as needed

                    // Add the condition for MaNhom
                    // Replace "YourMaNhomValue" with the actual value you want to filter by
                    queryBuilder.Append($"MaNhom = 'KH' AND ");

                    // Remove the trailing " AND " from the query
                    if (queryBuilder.ToString().EndsWith(" AND "))
                        queryBuilder.Remove(queryBuilder.Length - 5, 5);

                    using (SqlCommand command = new SqlCommand(queryBuilder.ToString(), connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dgrDanhSachMucTieuKhachHangKPI.Rows.Clear();

                            int mucTieuColumnIndex = dgrDanhSachMucTieuKhachHangKPI.Columns["cMucTieuKH"].Index;
                            int ttColumnIndex = dgrDanhSachMucTieuKhachHangKPI.Columns["cTTKH"].Index;
                            int MaNhomColumnIndex = dgrDanhSachMucTieuKhachHangKPI.Columns["cMaNhomKH"].Index;
                            int TrongSoColumnIndex = dgrDanhSachMucTieuKhachHangKPI.Columns["cTrongSoKH"].Index;




                            while (reader.Read())
                            {
                                string mucTieu = reader["NDMucTieu"].ToString();
                                string ttValue = reader["TT"].ToString();
                                string trongso = reader["TrongSo"].ToString();

                                dgrDanhSachMucTieuKhachHangKPI.Rows.Add();
                                dgrDanhSachMucTieuKhachHangKPI.Rows[dgrDanhSachMucTieuKhachHangKPI.Rows.Count - 1].Cells[mucTieuColumnIndex].Value = mucTieu;
                                dgrDanhSachMucTieuKhachHangKPI.Rows[dgrDanhSachMucTieuKhachHangKPI.Rows.Count - 1].Cells[ttColumnIndex].Value = ttValue;
                                dgrDanhSachMucTieuKhachHangKPI.Rows[dgrDanhSachMucTieuKhachHangKPI.Rows.Count - 1].Cells[TrongSoColumnIndex].Value = trongso;

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thực hiện truy vấn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchDistinctDataVH()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(mconnectstring))
                {
                    connection.Open();

                    StringBuilder queryBuilder = new StringBuilder("SELECT MaNhom,TT, NDMucTieu,TrongSo FROM NoiDungMucTieuNhanVien WHERE ");

                    // Modify conditions based on your checkboxes
                    // For example:
                    if (cbTruongKhoa.Checked)
                        queryBuilder.Append("TruongKhoa = 1 AND ");
                    if (cbPhoTruongKhoa.Checked)
                        queryBuilder.Append("PhoTruongKhoa = 1 AND ");
                    if (cbDDTruong.Checked)
                        queryBuilder.Append("DDTruong = 1 AND ");
                    if (cbBSNoiNhi.Checked)
                        queryBuilder.Append("BSNoiNhi = 1 AND ");
                    if (cbDDCS.Checked)
                        queryBuilder.Append("DDCS = 1 AND ");
                    if (cbTKYK.Checked)
                        queryBuilder.Append("TKYK = 1 AND ");
                    if (cbNVHD.Checked)
                        queryBuilder.Append("NVHD = 1 AND ");
                    if (cbHoLy.Checked)
                        queryBuilder.Append("HoLy = 1 AND ");
                    if (cbNVBaoTri.Checked)
                        queryBuilder.Append("NVBaoTri = 1 AND ");

                    // Add other conditions as needed

                    // Add the condition for MaNhom
                    // Replace "YourMaNhomValue" with the actual value you want to filter by
                    queryBuilder.Append($"MaNhom = 'VH' AND ");

                    // Remove the trailing " AND " from the query
                    if (queryBuilder.ToString().EndsWith(" AND "))
                        queryBuilder.Remove(queryBuilder.Length - 5, 5);

                    using (SqlCommand command = new SqlCommand(queryBuilder.ToString(), connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dgrDanhSachMucTieuVanHanhKPI.Rows.Clear();

                            int mucTieuColumnIndex = dgrDanhSachMucTieuVanHanhKPI.Columns["cMucTieuVH"].Index;
                            int ttColumnIndex = dgrDanhSachMucTieuVanHanhKPI.Columns["cTTVH"].Index;
                            int MaNhomColumnIndex = dgrDanhSachMucTieuVanHanhKPI.Columns["cMaNhomVH"].Index;
                            int TrongSoColumnIndex = dgrDanhSachMucTieuVanHanhKPI.Columns["cTrongSoVH"].Index;




                            while (reader.Read())
                            {
                                string mucTieu = reader["NDMucTieu"].ToString();
                                string ttValue = reader["TT"].ToString();
                                string trongso = reader["TrongSo"].ToString();

                                dgrDanhSachMucTieuVanHanhKPI.Rows.Add();
                                dgrDanhSachMucTieuVanHanhKPI.Rows[dgrDanhSachMucTieuVanHanhKPI.Rows.Count - 1].Cells[mucTieuColumnIndex].Value = mucTieu;
                                dgrDanhSachMucTieuVanHanhKPI.Rows[dgrDanhSachMucTieuVanHanhKPI.Rows.Count - 1].Cells[ttColumnIndex].Value = ttValue;
                                dgrDanhSachMucTieuVanHanhKPI.Rows[dgrDanhSachMucTieuVanHanhKPI.Rows.Count - 1].Cells[TrongSoColumnIndex].Value = trongso;

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thực hiện truy vấn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SearchDistinctDataPT()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(mconnectstring))
                {
                    connection.Open();

                    StringBuilder queryBuilder = new StringBuilder("SELECT MaNhom,TT, NDMucTieu,TrongSo FROM NoiDungMucTieuNhanVien WHERE ");

                    // Modify conditions based on your checkboxes
                    // For example:
                    if (cbTruongKhoa.Checked)
                        queryBuilder.Append("TruongKhoa = 1 AND ");
                    if (cbPhoTruongKhoa.Checked)
                        queryBuilder.Append("PhoTruongKhoa = 1 AND ");
                    if (cbDDTruong.Checked)
                        queryBuilder.Append("DDTruong = 1 AND ");
                    if (cbBSNoiNhi.Checked)
                        queryBuilder.Append("BSNoiNhi = 1 AND ");
                    if (cbDDCS.Checked)
                        queryBuilder.Append("DDCS = 1 AND ");
                    if (cbTKYK.Checked)
                        queryBuilder.Append("TKYK = 1 AND ");
                    if (cbNVHD.Checked)
                        queryBuilder.Append("NVHD = 1 AND ");
                    if (cbHoLy.Checked)
                        queryBuilder.Append("HoLy = 1 AND ");
                    if (cbNVBaoTri.Checked)
                        queryBuilder.Append("NVBaoTri = 1 AND ");

                    // Add other conditions as needed

                    // Add the condition for MaNhom
                    // Replace "YourMaNhomValue" with the actual value you want to filter by
                    queryBuilder.Append($"MaNhom = 'PT' AND ");

                    // Remove the trailing " AND " from the query
                    if (queryBuilder.ToString().EndsWith(" AND "))
                        queryBuilder.Remove(queryBuilder.Length - 5, 5);

                    using (SqlCommand command = new SqlCommand(queryBuilder.ToString(), connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dgrDanhSachMucTieuPhatTrienKPI.Rows.Clear();

                            int mucTieuColumnIndex = dgrDanhSachMucTieuPhatTrienKPI.Columns["cMucTieuPT"].Index;
                            int ttColumnIndex = dgrDanhSachMucTieuPhatTrienKPI.Columns["cTTPT"].Index;
                            int MaNhomColumnIndex = dgrDanhSachMucTieuPhatTrienKPI.Columns["cMaNhomPT"].Index;
                            int TrongSoColumnIndex = dgrDanhSachMucTieuPhatTrienKPI.Columns["cTrongSoPT"].Index;




                            while (reader.Read())
                            {
                                string mucTieu = reader["NDMucTieu"].ToString();
                                string ttValue = reader["TT"].ToString();
                                string trongso = reader["TrongSo"].ToString();


                                dgrDanhSachMucTieuPhatTrienKPI.Rows.Add();
                                dgrDanhSachMucTieuPhatTrienKPI.Rows[dgrDanhSachMucTieuPhatTrienKPI.Rows.Count - 1].Cells[mucTieuColumnIndex].Value = mucTieu;
                                dgrDanhSachMucTieuPhatTrienKPI.Rows[dgrDanhSachMucTieuPhatTrienKPI.Rows.Count - 1].Cells[ttColumnIndex].Value = ttValue;
                                dgrDanhSachMucTieuPhatTrienKPI.Rows[dgrDanhSachMucTieuPhatTrienKPI.Rows.Count - 1].Cells[TrongSoColumnIndex].Value = trongso;

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thực hiện truy vấn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbTruongKhoa_CheckedChanged(object sender, EventArgs e)
        {



            if (cbTruongKhoa.Checked)
            {
                // Xử lý khi checkbox TruongKhoa được chọn
                SearchDistinctDataTC();
                SearchDistinctDataKH();
                SearchDistinctDataVH();
                SearchDistinctDataPT();

                // Bỏ chọn checkbox PhoTruongKhoa
                cbPhoTruongKhoa.Checked = false;
                cbDDTruong.Checked = false;
                cbBSNoiNhi.Checked = false;
                cbDDCS.Checked = false;
                cbTKYK.Checked = false;
                cbNVHD.Checked = false;
                cbHoLy.Checked = false;
                cbNVBaoTri.Checked = false;
            }
            else
            {
                // Xử lý khi checkbox TruongKhoa bị bỏ chọn
                dgrDanhSachMucTieuTaiChinhKPI.Rows.Clear();
                dgrDanhSachMucTieuKhachHangKPI.Rows.Clear();
                dgrDanhSachMucTieuVanHanhKPI.Rows.Clear();
                dgrDanhSachMucTieuPhatTrienKPI.Rows.Clear();
            }


        }

        private void cbPhoTruongKhoa_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPhoTruongKhoa.Checked == true)
            {
                SearchDistinctDataTC();
                SearchDistinctDataKH();
                SearchDistinctDataVH();
                SearchDistinctDataPT();

                cbTruongKhoa.Checked = false;
                cbDDTruong.Checked = false;
                cbBSNoiNhi.Checked = false;
                cbDDCS.Checked = false;
                cbTKYK.Checked = false;
                cbNVHD.Checked = false;
                cbHoLy.Checked = false;
                cbNVBaoTri.Checked = false;
            }

            else if (cbPhoTruongKhoa.Checked == false)
            {
                dgrDanhSachMucTieuTaiChinhKPI.Rows.Clear();
                dgrDanhSachMucTieuKhachHangKPI.Rows.Clear();
                dgrDanhSachMucTieuVanHanhKPI.Rows.Clear();
                dgrDanhSachMucTieuPhatTrienKPI.Rows.Clear();
            }
        }

       
        private void cbDDTruong_CheckedChanged(object sender, EventArgs e)
        {

            if (cbDDTruong.Checked == true)
            {
                SearchDistinctDataTC();
                SearchDistinctDataKH();
                SearchDistinctDataVH();
                SearchDistinctDataPT();

                cbTruongKhoa.Checked = false;
                cbPhoTruongKhoa.Checked = false;
                cbBSNoiNhi.Checked = false;
                cbDDCS.Checked = false;
                cbTKYK.Checked = false;
                cbNVHD.Checked = false;
                cbHoLy.Checked = false;
                cbNVBaoTri.Checked = false;
            }

            else if (cbDDTruong.Checked == false)
            {
                dgrDanhSachMucTieuTaiChinhKPI.Rows.Clear();
                dgrDanhSachMucTieuKhachHangKPI.Rows.Clear();
                dgrDanhSachMucTieuVanHanhKPI.Rows.Clear();
                dgrDanhSachMucTieuPhatTrienKPI.Rows.Clear();
            }
        }

        private void cbBSNoiNhi_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBSNoiNhi.Checked == true)
            {
                SearchDistinctDataTC();
                SearchDistinctDataKH();
                SearchDistinctDataVH();
                SearchDistinctDataPT();

                cbTruongKhoa.Checked = false;
                cbPhoTruongKhoa.Checked = false;
                cbDDTruong.Checked = false;
                cbDDCS.Checked = false;
                cbTKYK.Checked = false;
                cbNVHD.Checked = false;
                cbHoLy.Checked = false;
                cbNVBaoTri.Checked = false;
            }

            else if (cbBSNoiNhi.Checked == false)
            {
                dgrDanhSachMucTieuTaiChinhKPI.Rows.Clear();
                dgrDanhSachMucTieuKhachHangKPI.Rows.Clear();
                dgrDanhSachMucTieuVanHanhKPI.Rows.Clear();
                dgrDanhSachMucTieuPhatTrienKPI.Rows.Clear();
            }
        }

        private void cbDDCS_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDDCS.Checked == true)
            {
                SearchDistinctDataTC();
                SearchDistinctDataKH();
                SearchDistinctDataVH();
                SearchDistinctDataPT();

                cbTruongKhoa.Checked = false;
                cbPhoTruongKhoa.Checked = false;
                cbDDTruong.Checked = false;
                cbBSNoiNhi.Checked = false;
                cbTKYK.Checked = false;
                cbNVHD.Checked = false;
                cbHoLy.Checked = false;
                cbNVBaoTri.Checked = false;
            }

            else if (cbDDCS.Checked == false)
            {
                dgrDanhSachMucTieuTaiChinhKPI.Rows.Clear();
                dgrDanhSachMucTieuKhachHangKPI.Rows.Clear();
                dgrDanhSachMucTieuVanHanhKPI.Rows.Clear();
                dgrDanhSachMucTieuPhatTrienKPI.Rows.Clear();
            }
        }

        private void cbTKYK_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTKYK.Checked == true)
            {
                SearchDistinctDataTC();
                SearchDistinctDataKH();
                SearchDistinctDataVH();
                SearchDistinctDataPT();

                cbTruongKhoa.Checked = false;
                cbPhoTruongKhoa.Checked = false;
                cbDDTruong.Checked = false;
                cbBSNoiNhi.Checked = false;
                cbDDCS.Checked = false;
                cbNVHD.Checked = false;
                cbHoLy.Checked = false;
                cbNVBaoTri.Checked = false;

            }

            else if (cbTKYK.Checked == false)
            {
                dgrDanhSachMucTieuTaiChinhKPI.Rows.Clear();
                dgrDanhSachMucTieuKhachHangKPI.Rows.Clear();
                dgrDanhSachMucTieuVanHanhKPI.Rows.Clear();
                dgrDanhSachMucTieuPhatTrienKPI.Rows.Clear();
            }
        }

        private void cbNVHD_CheckedChanged(object sender, EventArgs e)
        {
            if (cbNVHD.Checked == true)
            {
                SearchDistinctDataTC();
                SearchDistinctDataKH();
                SearchDistinctDataVH();
                SearchDistinctDataPT();

                cbTruongKhoa.Checked = false;
                cbPhoTruongKhoa.Checked = false;
                cbDDTruong.Checked = false;
                cbBSNoiNhi.Checked = false;
                cbTKYK.Checked = false;
                cbDDCS.Checked = false;
                cbHoLy.Checked = false;
                cbNVBaoTri.Checked = false;

            }

            else if (cbNVHD.Checked == false)
            {

                dgrDanhSachMucTieuTaiChinhKPI.Rows.Clear();
                dgrDanhSachMucTieuKhachHangKPI.Rows.Clear();
                dgrDanhSachMucTieuVanHanhKPI.Rows.Clear();
                dgrDanhSachMucTieuPhatTrienKPI.Rows.Clear();
            }
        }

        private void cbHoLy_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHoLy.Checked == true)
            {
                SearchDistinctDataTC();
                SearchDistinctDataKH();
                SearchDistinctDataVH();
                SearchDistinctDataPT();

                cbTruongKhoa.Checked = false;
                cbPhoTruongKhoa.Checked = false;
                cbDDTruong.Checked = false;
                cbBSNoiNhi.Checked = false;
                cbTKYK.Checked = false;
                cbDDCS.Checked = false;
                cbNVHD.Checked = false;
                cbNVBaoTri.Checked = false;

            }

            else if (cbHoLy.Checked == false)
            {

                dgrDanhSachMucTieuTaiChinhKPI.Rows.Clear();
                dgrDanhSachMucTieuKhachHangKPI.Rows.Clear();
                dgrDanhSachMucTieuVanHanhKPI.Rows.Clear();
                dgrDanhSachMucTieuPhatTrienKPI.Rows.Clear();
            }
        }

        private void cbNVBaoTri_CheckedChanged(object sender, EventArgs e)
        {
            if (cbNVBaoTri.Checked == true)
            {
                SearchDistinctDataTC();
                SearchDistinctDataKH();
                SearchDistinctDataVH();
                SearchDistinctDataPT();

                cbTruongKhoa.Checked = false;
                cbPhoTruongKhoa.Checked = false;
                cbDDTruong.Checked = false;
                cbBSNoiNhi.Checked = false;
                cbTKYK.Checked = false;
                cbDDCS.Checked = false;
                cbNVHD.Checked = false;
                cbHoLy.Checked = false;


            }

            else if (cbNVBaoTri.Checked == false)
            {
                dgrDanhSachMucTieuTaiChinhKPI.Rows.Clear();
                dgrDanhSachMucTieuKhachHangKPI.Rows.Clear();
                dgrDanhSachMucTieuVanHanhKPI.Rows.Clear();
                dgrDanhSachMucTieuPhatTrienKPI.Rows.Clear();
            }
        }

        private void dgrDanhSachMucTieuTaiChinhKPI_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgrDanhSachMucTieuTaiChinhKPI.Columns[e.ColumnIndex].Name == "cTrongSoTC" && e.Value != null)
            {
                e.Value = $"{e.Value} %"; // Thêm đơn vị vào giá trị
                e.FormattingApplied = true;
            }
        }

        private void dgrDanhSachMucTieuKhachHangKPI_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgrDanhSachMucTieuKhachHangKPI.Columns[e.ColumnIndex].Name == "cTrongSoKH" && e.Value != null)
            {
                e.Value = $"{e.Value} %"; // Thêm đơn vị vào giá trị
                e.FormattingApplied = true;
            }
        }

        private void dgrDanhSachMucTieuVanHanhKPI_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgrDanhSachMucTieuVanHanhKPI.Columns[e.ColumnIndex].Name == "cTrongSoVH" && e.Value != null)
            {
                e.Value = $"{e.Value} %"; // Thêm đơn vị vào giá trị
                e.FormattingApplied = true;
            }
        }

        private void dgrDanhSachMucTieuPhatTrienKPI_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgrDanhSachMucTieuPhatTrienKPI.Columns[e.ColumnIndex].Name == "cTrongSoPT" && e.Value != null)
            {
                e.Value = $"{e.Value} %"; // Thêm đơn vị vào giá trị
                e.FormattingApplied = true;
            }
        }
    }
}