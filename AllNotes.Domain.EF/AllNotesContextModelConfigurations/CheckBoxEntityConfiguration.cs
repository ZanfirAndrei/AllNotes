using AllNotes.Domain.Models.Memo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllNotes.Domain.EF.AllNotesContextModelConfigurations
{
    public class CheckBoxEntityConfiguration : IEntityTypeConfiguration<CheckBox>
    {
        public void Configure(EntityTypeBuilder<CheckBox> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasOne(c => c.Schedule)
                .WithMany(c => c.CheckBoxes)
                .HasForeignKey(c => c.ScheduleId);
            builder.HasOne(c => c.Note)
                .WithMany(c => c.CheckBoxes)
                .HasForeignKey(c => c.NoteId);
            builder.HasOne(c => c.CheckList)
                .WithMany(c => c.CheckBoxes)
                .HasForeignKey(c => c.CheckListId);
            

        }
    }
}
