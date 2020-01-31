using AllNotes.Domain.Models.Memo;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllNotes.Domain.EF.IRepositories
{
    public interface INoteRepository : IBaseRepository<Note>
    {
    }
}
