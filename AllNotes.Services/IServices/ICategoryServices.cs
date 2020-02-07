using AllNotes.Domain.Dtos;
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
        Task<IList<CategoryDto>> GetAllAsync();
        Task<CategoryDto> GetByIdAsync(int id);
        Task<CategoryDto> CreateAsync(CategoryDto dto);
        Task<CategoryDto> UpdateAsync(CategoryDto category);
        Task<CategoryDto> DeleteAsync(CategoryDto category);
    }
}
