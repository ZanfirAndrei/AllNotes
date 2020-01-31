using AllNotes.Domain.EF.AllNotesContext;
using AllNotes.Domain.EF.IRepositories;
using AllNotes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllNotes.Domain.EF.Repositories
{
    public class ScheduleRepository : BaseRepository<Schedule>, IScheduleRepository
    {
        public ScheduleRepository(AllNotesDbContext context) : base(context)
        {
        }
    }
}