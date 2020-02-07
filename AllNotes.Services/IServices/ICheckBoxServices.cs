using AllNotes.Domain.Dtos;
using AllNotes.Domain.EF.Wrapper;
using AllNotes.Domain.Models.Memo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AllNotes.Services.IServices
{
    public interface ICheckBoxServices : IBaseServices
    {
        IWrapperRepository WrapperRepository { get; }
        Task<IList<CheckBoxDto>> GetAllAsync();
        Task<CheckBoxDto> GetByIdAsync(int id);
        Task<CheckBoxDto> CreateAsync(string name, int checkListId);
        Task<CheckBoxDto> UpdateAsync(CheckBoxDto note);
        Task<CheckBoxDto> DeleteAsync(CheckBoxDto note);
    }
}
