using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuarterApp.Core.Entiteis;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuarterApp.Data.Configurations
{
    public class PropertyConfiguration : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.Property(x => x.Address).HasMaxLength(250).IsRequired();
            builder.Property(x => x.PosterImage).HasMaxLength(100).IsRequired();

            builder.Property(x => x.Price).HasColumnType("decimal(18,2)");
            builder.Property(x => x.DaylyPrice).HasColumnType("decimal(18,2)");
            builder.Property(x => x.WeeklyPrice).HasColumnType("decimal(18,2)");
            builder.Property(x => x.MonthlyPrice).HasColumnType("decimal(18,2)");

            builder.HasOne(x => x.Category).WithMany(x => x.Properties).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
