using AllNotes.Domain.Models.Sport;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllNotes.Domain.EF.AllNotesContextModelConfigurations
{
    public class ExerciseEntityConfiguration : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasOne(c => c.Category)
                .WithMany(c => c.Exercises)
                .HasForeignKey(c => c.CategoryId);
            builder.HasOne(c => c.Schedule)
                .WithMany(c => c.Exercises)
                .HasForeignKey(c => c.ScheduleId);
            builder.HasMany(c => c.Series)
                .WithOne(c => c.Exercise)
                .HasForeignKey(b => b.ExerciseId);
        }
    }
}
