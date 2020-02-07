using AllNotes.Domain.EF.Wrapper;
using AllNotes.Domain.Models.Sport;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AllNotes.Services.IServices
{
    public interface ISeriesServices : IBaseServices
    {
        IWrapperRepository WrapperRepository { get; }
        Task<IList<Series>> GetAllAsync();
        Task<Series> GetByIdAsync(int id);
        Task<Series> CreateAsync(int repeats, float weights, int exerciseId);
        Task<Series> UpdateAsync(Series series);
        Task<Series> DeleteAsync(Series series);
    }
}
