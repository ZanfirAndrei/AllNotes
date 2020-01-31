using AllNotes.Domain.EF.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllNotes.Domain.EF.Wrapper
{
    public interface IWrapperRepository
    {
        ICheckListRepository CheckList { get; }
        ICheckBoxRepository CheckBox { get; }
        INoteRepository Note { get; }
        ICategoryRepository Category { get; }
        ISeriesRepository Series { get; }
        IExerciseRepository Exercise { get; }
        IScheduleRepository Schedule { get; }

        void CommitChanges();
    }
}
