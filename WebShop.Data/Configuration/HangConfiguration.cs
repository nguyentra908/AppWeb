using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Data.Entities;

namespace WebShop.Data.Configuration
{
  public  class HangConfiguration : IEntityTypeConfiguration<Hang>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Hang> builder)
        {
            builder.ToTable("Hang");
            builder.HasKey(x => x.MaHang);
            builder.Property(x => x.TenHang).IsRequired(true);


        }

    }
}
