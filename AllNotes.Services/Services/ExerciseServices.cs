using AllNotes.Domain.EF.AllNotesContext;
using AllNotes.Domain.EF.Wrapper;
using AllNotes.Services.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllNotes.Services.Services
{
    public class ExerciseServices : BaseServices, IExerciseServices
    {
        public IWrapperRepository WrapperRepository { get; }

        public ExerciseServices(AllNotesDbContext context, IWrapperRepository wrapperRepository) : base(context)
        {
            WrapperRepository = wrapperRepository;
        }
    }
}
