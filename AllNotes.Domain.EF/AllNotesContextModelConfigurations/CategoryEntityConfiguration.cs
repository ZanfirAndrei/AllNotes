using AllNotes.Domain.Models.Sport;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllNotes.Domain.EF.AllNotesContextModelConfigurations
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasMany(c => c.Exercises)
                .WithOne(c => c.Category)
                .HasForeignKey(b => b.CategoryId);
        }
    }
}
