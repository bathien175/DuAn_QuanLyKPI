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
    
    public partial class ChiTietTieuChiMucTieuBV
    {
        public string MaPhieuKPIBV { get; set; }
        public int MaKPI { get; set; }
        public Nullable<double> TrongSoTCBV { get; set; }
        public Nullable<double> TrongSoKPIBV { get; set; }
    
        public virtual KPI KPI { get; set; }
        public virtual KPI_BenhVien KPI_BenhVien { get; set; }
    }
}
