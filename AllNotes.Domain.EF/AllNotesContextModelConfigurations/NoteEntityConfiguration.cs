using AllNotes.Domain.Models.Memo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllNotes.Domain.EF.AllNotesContextModelConfigurations
{
    public class NoteEntityConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasOne(c => c.Schedule)
                .WithMany(c => c.Notes)
                .HasForeignKey(c => c.ScheduleId);
            builder.HasMany(c => c.CheckBoxes)
                .WithOne(c => c.Note)
                .HasForeignKey(b => b.NoteId);
        }
    }
}
