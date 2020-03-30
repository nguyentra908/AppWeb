using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Data.Entities;

namespace WebShop.Data.Configuration
{
   public class SanPham_HangConfiguration : IEntityTypeConfiguration<SanPham_Hang>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<SanPham_Hang> builder)
        {
          builder. HasKey(t => new { t.MaSP, t.MaHang });
            builder.ToTable("SanPham_Hang");
            builder.HasOne(pt => pt.Hang)
                .WithMany(p => p.SanPham_Hang)
                .HasForeignKey(p=>p.MaHang);

            builder.HasOne(pt => pt.SanPham)
              .WithMany(p => p.SanPham_Hang)
              .HasForeignKey(p => p.MaSP);
        }

    }
}
