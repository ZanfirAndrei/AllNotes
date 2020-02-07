using AllNotes.Domain.Dtos;
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
        Task<IList<SeriesDto>> GetAllAsync();
        Task<SeriesDto> GetByIdAsync(int id);
        Task<Series> CreateAsync(SeriesDto dto);
        Task<SeriesDto> UpdateAsync(SeriesDto series);
        Task<SeriesDto> DeleteAsync(SeriesDto series);
    }
}
