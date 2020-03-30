using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Data.Configuration;
using WebShop.Data.Entities;

namespace WebShop.Data.EF
{
    public class webshopDBContext : DbContext
    {
        public webshopDBContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppConfigconfiguration());
            modelBuilder.ApplyConfiguration(new SanPhamConfiguration());
            modelBuilder.ApplyConfiguration(new TaiKhoanConfiguration());
            modelBuilder.ApplyConfiguration(new KhachHangConfiguration());
            modelBuilder.ApplyConfiguration(new HoaDonConfiguration());
            modelBuilder.ApplyConfiguration(new HangConfiguration());
            modelBuilder.ApplyConfiguration(new AnhConfiguration());
            modelBuilder.ApplyConfiguration(new SanPham_HangConfiguration());
            
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<SanPham> SanPham { get; set; }
        public DbSet<TaiKhoan> TaiKhoan { get; set; }
        public DbSet<KhachHang> KhachHang { get; set; }
        public DbSet<HoaDon> HoaDon { get; set; }
        public DbSet<Hang> Hang { get; set; }
        public DbSet<Anh> Anh { get; set; }
        public DbSet<Users> Users { get; set; }





    }
}
