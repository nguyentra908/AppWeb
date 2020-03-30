using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Data.Configuration
{
    public class AppConfigconfiguration : IEntityTypeConfiguration<AppConfig >
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<AppConfig> builder)
        {
            //builder.ToTable("AppConfig");
            builder.HasKey(x => x.Key);
            builder.Property(x => x.Value).IsRequired(true);
        }
    }
}
