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
    
    public partial class ThongBao
    {
        public int MaThongBao { get; set; }
        public string MaNhanVien { get; set; }
        public string TieuDe { get; set; }
        public string NoiDung { get; set; }
        public System.DateTime ThoiGian { get; set; }
        public bool TrangThai { get; set; }
    
        public virtual NguoiDung NguoiDung { get; set; }
    }
}
