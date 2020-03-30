using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Data.Entities;

namespace WebShop.Data.Configuration
{
   public class TaiKhoanConfiguration : IEntityTypeConfiguration<TaiKhoan>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TaiKhoan> builder)
        {
            builder.ToTable("SanPham");
            builder.HasKey(x => x.TenTK);
            builder.Property(x => x.Pass).IsRequired(true);
            builder.Property(x => x.Quyen).IsRequired(true);

        }

    }
}
