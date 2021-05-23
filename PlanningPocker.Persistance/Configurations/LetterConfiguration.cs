using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanningPocker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanningPocker.Persistance.Configurations
{
    public class LetterConfiguration : IEntityTypeConfiguration<Letter>
    {
        public void Configure(EntityTypeBuilder<Letter> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Value).IsRequired();
        }
    }
}
