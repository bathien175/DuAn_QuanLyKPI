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
            this.KPI_CaNhan = new HashSet<KPI_CaNhan>();
            this.ChiTietKPIKhoaPhong = new HashSet<ChiTietKPIKhoaPhong>();
            this.ChiTietTieuChiMucTieuKhoaPhong = new HashSet<ChiTietTieuChiMucTieuKhoaPhong>();
            this.KPI_TruongKhoaPhong = new HashSet<KPI_TruongKhoaPhong>();
        }
    
        public string MaPhieuKPIBV { get; set; }
        public string MaPhieuKPIKP { get; set; }
        public string MaPK { get; set; }
        public int QuyNam { get; set; }
        public Nullable<double> TongTrongSo { get; set; }
        public string NguoiLap { get; set; }
        public string NguoiPheDuyet { get; set; }
        public string NguoiXemXet { get; set; }
        public System.DateTime NgayLapPhieuKPIKP { get; set; }
        public Nullable<System.DateTime> NgayPheDuyet { get; set; }
        public Nullable<System.DateTime> NgayXemXet { get; set; }
        public int IDBieuMau { get; set; }
    
        public virtual DanhsachBieuMau DanhsachBieuMau { get; set; }
        public virtual KPI_BenhVien KPI_BenhVien { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KPI_CaNhan> KPI_CaNhan { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietKPIKhoaPhong> ChiTietKPIKhoaPhong { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietTieuChiMucTieuKhoaPhong> ChiTietTieuChiMucTieuKhoaPhong { get; set; }
        public virtual NguoiDung NguoiDung { get; set; }
        public virtual NguoiDung NguoiDung1 { get; set; }
        public virtual PhongKhoa PhongKhoa { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KPI_TruongKhoaPhong> KPI_TruongKhoaPhong { get; set; }
    }
}
