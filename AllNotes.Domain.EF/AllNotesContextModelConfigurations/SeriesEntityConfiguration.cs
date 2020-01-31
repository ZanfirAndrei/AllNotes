using AllNotes.Domain.Models.Sport;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllNotes.Domain.EF.AllNotesContextModelConfigurations
{
    public class SeriesEntityConfiguration : IEntityTypeConfiguration<Series>
    {
        public void Configure(EntityTypeBuilder<Series> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasOne(c => c.Exercise)
                .WithMany(c => c.Series)
                .HasForeignKey(c => c.ExerciseId);
        }
    }
}
