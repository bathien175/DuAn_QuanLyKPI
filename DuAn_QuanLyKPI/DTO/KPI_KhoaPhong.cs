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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KPI_KhoaPhong()
        {
            this.ChiTietTieuChiPhieuPhongKhoa = new HashSet<ChiTietTieuChiPhieuPhongKhoa>();
        }
    
        public string MaPhieuKPI { get; set; }
        public string MaPhongKhoa { get; set; }
        public string TieuDe { get; set; }
        public string NoiDung { get; set; }
        public Nullable<System.DateTime> NgayTao { get; set; }
        public Nullable<int> Quy { get; set; }
        public Nullable<int> Nam { get; set; }
        public Nullable<bool> LanhDao { get; set; }
        public string MauPhieu { get; set; }
        public Nullable<int> TrangThai { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietTieuChiPhieuPhongKhoa> ChiTietTieuChiPhieuPhongKhoa { get; set; }
        public virtual PhongKhoa PhongKhoa { get; set; }
    }
}