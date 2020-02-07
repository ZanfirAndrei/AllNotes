using AllNotes.Domain.EF.Wrapper;
using AllNotes.Domain.Models.Memo;
using AllNotes.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AllNotes.Services.IServices
{
    public interface ICheckListServices : IBaseServices
    {
        IWrapperRepository WrapperRepository { get; }
        Task<IList<CheckList>> GetAllAsync(); 
        Task<CheckList> GetByIdAsync(int id);
        Task<CheckList> CreateAsync(CheckListDto dto);
        Task<CheckList> UpdateAsync(CheckList note);
        Task<CheckList> DeleteAsync(CheckList note);
    }
    
}
