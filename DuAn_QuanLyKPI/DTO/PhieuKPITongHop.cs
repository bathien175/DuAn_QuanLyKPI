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
    
    public partial class PhieuKPITongHop
    {
        public int ID { get; set; }
        public string MaPhieuKPI { get; set; }
        public Nullable<int> MaKPI { get; set; }
        public string MaPK { get; set; }
        public Nullable<bool> TruongPK { get; set; }
        public Nullable<bool> CongViecCaNhan { get; set; }
        public string TieuChiID { get; set; }
        public Nullable<int> ChiTieuBV { get; set; }
        public Nullable<int> TrongSoTieuChiBV { get; set; }
        public Nullable<int> TrongSoKPIBV { get; set; }
        public Nullable<System.DateTime> NgayTaoPhieuKPI { get; set; }
    
        public virtual KPI KPI { get; set; }
        public virtual PhongKhoa PhongKhoa { get; set; }
        public virtual TongHopBieuMauPhieuKPI TongHopBieuMauPhieuKPI { get; set; }
    }
}