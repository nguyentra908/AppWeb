using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Data.Entities;

namespace WebShop.Data.Configuration
{
   public class KhachHangConfiguration : IEntityTypeConfiguration<KhachHang>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<KhachHang> builder)
        {
            builder.ToTable("KhachHang");
            builder.HasKey(x => x.maKH);
            builder.Property(x => x.Ten).IsRequired(true);
            builder.Property(x => x.Email).IsRequired(true);
            builder.Property(x => x.DiaChi).IsRequired(true);
        }
    }
}
