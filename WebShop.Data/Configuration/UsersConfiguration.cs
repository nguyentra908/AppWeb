using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Data.Entities;

namespace WebShop.Data.Configuration
{
   public class UsersConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Users> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Role).IsRequired(true);
            builder.Property(x => x.Password).IsRequired(true);


        }

    }
}
