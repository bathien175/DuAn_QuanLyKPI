﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QuanLyKPIEntities : DbContext
    {
        public QuanLyKPIEntities()
            : base("name=QuanLyKPIEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ChiTietKPICaNhan> ChiTietKPICaNhan { get; set; }
        public virtual DbSet<ChiTietKPIKhoaPhong> ChiTietKPIKhoaPhong { get; set; }
        public virtual DbSet<ChiTietTieuChiPhieuCaNhan> ChiTietTieuChiPhieuCaNhan { get; set; }
        public virtual DbSet<ChiTietTieuChiPhieuPhongKhoa> ChiTietTieuChiPhieuPhongKhoa { get; set; }
        public virtual DbSet<ChucDanh> ChucDanh { get; set; }
        public virtual DbSet<KPI> KPI { get; set; }
        public virtual DbSet<KPI_CaNhan> KPI_CaNhan { get; set; }
        public virtual DbSet<KPI_KhoaPhong> KPI_KhoaPhong { get; set; }
        public virtual DbSet<NganHangKPI> NganHangKPI { get; set; }
        public virtual DbSet<NguoiDung> NguoiDung { get; set; }
        public virtual DbSet<NhomTieuChi> NhomTieuChi { get; set; }
        public virtual DbSet<PhongKhoa> PhongKhoa { get; set; }
        public virtual DbSet<Quyen> Quyen { get; set; }
        public virtual DbSet<ThongBao> ThongBao { get; set; }
    }
}
