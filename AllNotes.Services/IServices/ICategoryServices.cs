using AllNotes.Domain.EF.Wrapper;
using AllNotes.Domain.Models.Sport;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AllNotes.Services.IServices
{
    public interface ICategoryServices : IBaseServices
    {
        IWrapperRepository WrapperRepository { get; }
        Task<IList<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(int id);
        Task<Category> CreateAsync(string name);
        Task<Category> UpdateAsync(Category category);
        Task<Category> DeleteAsync(Category category);
    }
}
