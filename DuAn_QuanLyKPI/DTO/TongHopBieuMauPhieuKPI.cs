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
    
    public partial class TongHopBieuMauPhieuKPI
    {
        public string MaPhieuKPI { get; set; }
        public Nullable<int> IDBieuMau { get; set; }
        public Nullable<int> QuyNam { get; set; }
        public Nullable<System.DateTime> NguoiLapPhieuKPI { get; set; }
        public Nullable<int> TrangThai { get; set; }
    
        public virtual DanhsachBieuMau DanhsachBieuMau { get; set; }
        public virtual DanhsachBieuMau DanhsachBieuMau1 { get; set; }
    }
}
