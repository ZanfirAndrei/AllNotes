using AllNotes.Domain.EF.AllNotesContext;
using AllNotes.Domain.EF.IRepositories;
using AllNotes.Domain.Models.Sport;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllNotes.Domain.EF.Repositories
{
    public class ExerciseRepository : BaseRepository<Exercise>, IExerciseRepository
    {
        public ExerciseRepository(AllNotesDbContext context) : base(context)
        {
        }
    }
}
