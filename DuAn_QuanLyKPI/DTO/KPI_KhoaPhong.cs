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
    
    public partial class KPI_KhoaPhong
    {
        public string MaPhieuKPI { get; set; }
        public int IDChiTietKPIKP { get; set; }
        public int ChiTietKPIKP { get; set; }
        public int TrangThai { get; set; }
        public Nullable<System.DateTime> NgayTaoKPIKP { get; set; }
        public Nullable<int> Quy { get; set; }
        public int IDBieuMau { get; set; }
        public Nullable<int> Nam { get; set; }
    
        public virtual ChiTietTieuChiMucTieuKhoaPhong ChiTietTieuChiMucTieuKhoaPhong { get; set; }
        public virtual DanhsachBieuMau DanhsachBieuMau { get; set; }
        public virtual TongHopBieuMauPhieuKPI TongHopBieuMauPhieuKPI { get; set; }
    }
}
