using AllNotes.Domain.EF.AllNotesContext;
using AllNotes.Domain.EF.IRepositories;
using AllNotes.Domain.Models.Memo;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllNotes.Domain.EF.Repositories
{
    public class CheckBoxRepository : BaseRepository<CheckBox>, ICheckBoxRepository
    {
        public CheckBoxRepository(AllNotesDbContext context) : base(context)
        {
        }
    }
}