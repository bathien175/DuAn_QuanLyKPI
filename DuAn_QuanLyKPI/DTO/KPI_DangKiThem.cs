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
    
    public partial class KPI_DangKiThem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KPI_DangKiThem()
        {
            this.ChiTietKPICaNhan = new HashSet<ChiTietKPICaNhan>();
        }
    
        public int MaKPI_DKT { get; set; }
        public Nullable<int> MaKPI { get; set; }
        public string MaNV { get; set; }
        public string QuyNam { get; set; }
        public string NoiDung { get; set; }
        public Nullable<int> TrongSoKPIDK { get; set; }
        public string DonViTinh { get; set; }
        public string PhuongPhapDo { get; set; }
        public string KeHoach { get; set; }
        public Nullable<bool> CongViecCaNhan { get; set; }
        public string TieuChiID { get; set; }
        public string ChiTieu { get; set; }
    
        public virtual KPI KPI { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietKPICaNhan> ChiTietKPICaNhan { get; set; }
        public virtual NhomTieuChi NhomTieuChi { get; set; }
        public virtual NguoiDung NguoiDung { get; set; }
    }
}
