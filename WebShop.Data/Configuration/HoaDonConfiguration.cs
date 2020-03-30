using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Data.Entities;

namespace WebShop.Data.Configuration
{
    class HoaDonConfiguration:IEntityTypeConfiguration<HoaDon>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<HoaDon> builder)
        {
            builder.ToTable("HoaDon");
            builder.HasKey(x => x.MaHD);
            builder.Property(x => x.NgayHD).IsRequired(true);
            builder.Property(x => x.TongTien).IsRequired(true);
            builder.Property(x => x.IDKH).IsRequired(true);
        }
    }
}
