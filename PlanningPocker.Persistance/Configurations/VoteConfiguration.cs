using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanningPocker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanningPocker.Persistance.Configurations
{
    public class VoteConfiguration : IEntityTypeConfiguration<Vote>
    {
        public void Configure(EntityTypeBuilder<Vote> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.User);
            builder.HasOne(p => p.Letter);
            builder.HasOne(p => p.History);
            builder.Property(p => p.User).IsRequired();
            builder.Property(p => p.Letter).IsRequired();
            builder.Property(p => p.History).IsRequired();
        }
    }
}
