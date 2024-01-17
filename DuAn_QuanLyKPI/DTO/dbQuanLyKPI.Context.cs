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
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
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
    
        public virtual DbSet<ChucDanh> ChucDanh { get; set; }
        public virtual DbSet<DanhsachBieuMau> DanhsachBieuMau { get; set; }
        public virtual DbSet<KPI> KPI { get; set; }
        public virtual DbSet<KPI_BenhVien> KPI_BenhVien { get; set; }
        public virtual DbSet<KPI_CaNhan> KPI_CaNhan { get; set; }
        public virtual DbSet<KPI_DangKiThem> KPI_DangKiThem { get; set; }
        public virtual DbSet<KPI_KhoaPhong> KPI_KhoaPhong { get; set; }
        public virtual DbSet<KPI_TruongKhoaPhong> KPI_TruongKhoaPhong { get; set; }
        public virtual DbSet<NganHangKPI> NganHangKPI { get; set; }
        public virtual DbSet<NguoiTruyCap> NguoiTruyCap { get; set; }
        public virtual DbSet<NhomTieuChi> NhomTieuChi { get; set; }
        public virtual DbSet<PhongKhoa> PhongKhoa { get; set; }
        public virtual DbSet<Quyen> Quyen { get; set; }
        public virtual DbSet<QuyenTruyCap> QuyenTruyCap { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<ThongBao> ThongBao { get; set; }
        public virtual DbSet<TongHopBieuMauPhieuKPI> TongHopBieuMauPhieuKPI { get; set; }
        public virtual DbSet<ChiTietKPIBenhVien> ChiTietKPIBenhVien { get; set; }
        public virtual DbSet<ChiTietKPICaNhan> ChiTietKPICaNhan { get; set; }
        public virtual DbSet<ChiTietKPIKhoaPhong> ChiTietKPIKhoaPhong { get; set; }
        public virtual DbSet<ChiTietKPITruongKhoaPhong> ChiTietKPITruongKhoaPhong { get; set; }
        public virtual DbSet<ChiTietTieuChiMucTieuBV> ChiTietTieuChiMucTieuBV { get; set; }
        public virtual DbSet<ChiTietTieuChiMucTieuKhoaPhong> ChiTietTieuChiMucTieuKhoaPhong { get; set; }
        public virtual DbSet<NguoiDung> NguoiDung { get; set; }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual ObjectResult<TongHopTrangThaiBieuMauKPI_Result> TongHopTrangThaiBieuMauKPI(Nullable<int> iDBieuMau, Nullable<int> nam)
        {
            var iDBieuMauParameter = iDBieuMau.HasValue ?
                new ObjectParameter("IDBieuMau", iDBieuMau) :
                new ObjectParameter("IDBieuMau", typeof(int));
    
            var namParameter = nam.HasValue ?
                new ObjectParameter("Nam", nam) :
                new ObjectParameter("Nam", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TongHopTrangThaiBieuMauKPI_Result>("TongHopTrangThaiBieuMauKPI", iDBieuMauParameter, namParameter);
        }
    }
}
