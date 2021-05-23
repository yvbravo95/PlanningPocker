using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanningPocker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanningPocker.Persistance.Configurations
{
    public class UserHistoryConfiguration : IEntityTypeConfiguration<UserHistory>
    {
        public void Configure(EntityTypeBuilder<UserHistory> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Description).IsRequired();
        }
    }
}
