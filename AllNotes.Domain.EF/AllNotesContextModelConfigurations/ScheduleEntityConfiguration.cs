using AllNotes.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllNotes.Domain.EF.AllNotesContextModelConfigurations
{
    public class ScheduleEntityConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasMany(c => c.Exercises)
                .WithOne(c => c.Schedule)
                .HasForeignKey(b => b.ScheduleId);
            builder.HasMany(c => c.CheckLists)
                .WithOne(c => c.Schedule)
                .HasForeignKey(b => b.ScheduleId);
            builder.HasMany(c => c.CheckBoxes)
                .WithOne(c => c.Schedule)
                .HasForeignKey(b => b.ScheduleId);
            builder.HasMany(c => c.Notes)
                .WithOne(c => c.Schedule)
                .HasForeignKey(b => b.ScheduleId);
        }
    }
}
