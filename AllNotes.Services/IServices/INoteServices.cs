using AllNotes.Domain.EF.Wrapper;
using AllNotes.Domain.Models.Memo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AllNotes.Services.IServices
{
    public interface INoteServices : IBaseServices
    {
        IWrapperRepository WrapperRepository { get; }
        Task<IList<Note>> GetAllAsync();
        Task<Note> GetByIdAsync(int id);
        Task<Note> CreateAsync(Note note);
        Task<Note> UpdateAsync(Note note);
        Task<Note> DeleteAsync(Note note);
    }
}
