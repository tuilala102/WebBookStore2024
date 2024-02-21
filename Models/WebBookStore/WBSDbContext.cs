using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebBookStore.Models.WebBookStore
{
    public partial class WBSDbContext : DbContext
    {
        public WBSDbContext()
            : base("name=WBSDbContext")
        {
        }

        public virtual DbSet<CHITIETDONHANG> CHITIETDONHANGs { get; set; }
        public virtual DbSet<DANHGIA> DANHGIAs { get; set; }
        public virtual DbSet<DANHMUCSACH> DANHMUCSACHes { get; set; }
        public virtual DbSet<DONHANG> DONHANGs { get; set; }
        public virtual DbSet<NGUOIDUNG> NGUOIDUNGs { get; set; }
        public virtual DbSet<NHAXUATBAN> NHAXUATBANs { get; set; }
        public virtual DbSet<NHOMND> NHOMNDs { get; set; }
        public virtual DbSet<PHANQUYEN> PHANQUYENs { get; set; }
        public virtual DbSet<QUYEN> QUYENs { get; set; }
        public virtual DbSet<SANPHAM> SANPHAMs { get; set; }
        public virtual DbSet<TACGIA> TACGIAs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DANHMUCSACH>()
                .HasMany(e => e.SANPHAMs)
                .WithOptional(e => e.DANHMUCSACH)
                .HasForeignKey(e => e.MaDMSach);

            modelBuilder.Entity<DONHANG>()
                .Property(e => e.EmailNguoiNhan)
                .IsUnicode(false);

            modelBuilder.Entity<DONHANG>()
                .Property(e => e.MaVanDon)
                .IsUnicode(false);

            modelBuilder.Entity<DONHANG>()
                .HasMany(e => e.CHITIETDONHANGs)
                .WithOptional(e => e.DONHANG)
                .HasForeignKey(e => e.MaDonHang);

            modelBuilder.Entity<NGUOIDUNG>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<NGUOIDUNG>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<NGUOIDUNG>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<NGUOIDUNG>()
                .Property(e => e.MaNhom)
                .IsUnicode(false);

            modelBuilder.Entity<NGUOIDUNG>()
                .HasMany(e => e.DANHGIAs)
                .WithOptional(e => e.NGUOIDUNG)
                .HasForeignKey(e => e.MaKhachHang);

            modelBuilder.Entity<NGUOIDUNG>()
                .HasMany(e => e.DONHANGs)
                .WithOptional(e => e.NGUOIDUNG)
                .HasForeignKey(e => e.MaKhachHang);

            modelBuilder.Entity<NHAXUATBAN>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<NHAXUATBAN>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<NHAXUATBAN>()
                .HasMany(e => e.SANPHAMs)
                .WithOptional(e => e.NHAXUATBAN)
                .HasForeignKey(e => e.MaNXB);

            modelBuilder.Entity<NHOMND>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<NHOMND>()
                .HasMany(e => e.NGUOIDUNGs)
                .WithOptional(e => e.NHOMND)
                .HasForeignKey(e => e.MaNhom);

            modelBuilder.Entity<NHOMND>()
                .HasMany(e => e.PHANQUYENs)
                .WithRequired(e => e.NHOMND)
                .HasForeignKey(e => e.MaNhomND)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHANQUYEN>()
                .Property(e => e.MaNhomND)
                .IsUnicode(false);

            modelBuilder.Entity<PHANQUYEN>()
                .Property(e => e.MaQuyen)
                .IsUnicode(false);

            modelBuilder.Entity<QUYEN>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<QUYEN>()
                .HasMany(e => e.PHANQUYENs)
                .WithRequired(e => e.QUYEN)
                .HasForeignKey(e => e.MaQuyen)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.Anh)
                .IsUnicode(false);

            modelBuilder.Entity<SANPHAM>()
                .HasMany(e => e.CHITIETDONHANGs)
                .WithOptional(e => e.SANPHAM)
                .HasForeignKey(e => e.MaSanPham);

            modelBuilder.Entity<SANPHAM>()
                .HasMany(e => e.DANHGIAs)
                .WithOptional(e => e.SANPHAM)
                .HasForeignKey(e => e.MaSanPham);

            modelBuilder.Entity<TACGIA>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<TACGIA>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<TACGIA>()
                .HasMany(e => e.SANPHAMs)
                .WithOptional(e => e.TACGIA)
                .HasForeignKey(e => e.MaTacGia);
        }
    }
}
