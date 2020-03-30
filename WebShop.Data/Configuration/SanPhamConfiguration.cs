using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Data.Entities;

namespace WebShop.Data.Configuration
{
  public class SanPhamConfiguration:IEntityTypeConfiguration<SanPham>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<SanPham> builder)
        {
            builder.ToTable("SanPham");
            builder.HasKey(x => x.MaSP);
            builder.Property(x => x.TenSP).IsRequired();
            builder.Property(x => x.Hang).IsRequired();
        }
    }
}
