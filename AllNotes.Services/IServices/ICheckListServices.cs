using AllNotes.Domain.Dtos;
using AllNotes.Domain.EF.Wrapper;
using AllNotes.Domain.Models.Memo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AllNotes.Services.IServices
{
    public interface ICheckListServices : IBaseServices
    {
        IWrapperRepository WrapperRepository { get; }
        Task<IList<CheckListDto>> GetAllAsync(); 
        Task<CheckListDto> GetByIdAsync(int id);
        Task<CheckListDto> CreateAsync(CheckListDto dto);
        Task<CheckListDto> UpdateAsync(CheckListDto note);
        Task<CheckListDto> DeleteAsync(CheckListDto note);
    }
    
}
