//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DuAn_QuanLyKPI.DTO
{
    using System;
    using System.Collections.Generic;
    
    public partial class ChiTietKPITruongKhoaPhong
    {
        public string MaPhieuKPITKP { get; set; }
        public int MaKPI { get; set; }
        public Nullable<double> TrongSoTCTKP { get; set; }
        public Nullable<double> TrongSoKPITKP { get; set; }
        public string TieuChiDanhGiaKQ { get; set; }
        public string NguonChungMinh { get; set; }
        public string KeHoach { get; set; }
        public Nullable<double> ThucHien { get; set; }
        public Nullable<double> HoanThanh { get; set; }
        public Nullable<double> KetQuaTCTKP { get; set; }
        public Nullable<double> KetQuaKPITKP { get; set; }
        public Nullable<double> KetQuaKPIBV { get; set; }
        public Nullable<double> KetQuaKPIKP { get; set; }
        public string GhiChu { get; set; }
    
        public virtual KPI KPI { get; set; }
        public virtual KPI_TruongKhoaPhong KPI_TruongKhoaPhong { get; set; }
    }
}