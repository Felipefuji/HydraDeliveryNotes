using data.Data.APIContext.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.Data.APIContext.Configurations
{
    public class BillConfiguration : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.HasKey(e => e.Id);

            builder.ToTable("Bill", "dbo");

            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(250);

        }
    }
}
