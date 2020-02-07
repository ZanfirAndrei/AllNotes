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
        Task<IList<CheckList>> GetAllAsync(); 
        Task<CheckList> GetByIdAsync(int id);
        Task<CheckList> CreateAsync(CheckList checkList);
        Task<CheckList> UpdateAsync(CheckList checkList);
        Task<CheckList> DeleteAsync(CheckList checkList);
    }
    
}
