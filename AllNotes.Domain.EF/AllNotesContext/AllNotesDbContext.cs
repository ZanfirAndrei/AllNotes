using AllNotes.Domain.EF.AllNotesContextModelConfigurations;
using AllNotes.Domain.Models;
using AllNotes.Domain.Models.Memo;
using AllNotes.Domain.Models.Sport;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllNotes.Domain.EF.AllNotesContext
{
    public class AllNotesDbContext : DbContext
    {
        public AllNotesDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CheckBoxEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CheckListEntityConfiguration());
            modelBuilder.ApplyConfiguration(new NoteEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ExerciseEntityConfiguration());
            modelBuilder.ApplyConfiguration(new SeriesEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ScheduleEntityConfiguration());
        }

        public DbSet<CheckBox> CheckBoxes { get; set; }
        public DbSet<CheckList> CheckLists { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
    }
}
