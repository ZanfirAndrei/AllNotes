using AllNotes.Domain.Dtos;
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
        Task<IList<NoteDto>> GetAllAsync();
        Task<NoteDto> GetByIdAsync(int id);
        Task<NoteDto> CreateAsync(NoteDto note);
        Task<NoteDto> UpdateAsync(NoteDto note);
        Task<NoteDto> DeleteAsync(NoteDto note);
    }
}
