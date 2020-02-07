using AllNotes.Domain.Dtos;
using AllNotes.Domain.EF.Wrapper;
using AllNotes.Domain.Models.Sport;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AllNotes.Services.IServices
{
    public interface IExerciseServices : IBaseServices
    {
        IWrapperRepository WrapperRepository { get; }
        Task<IList<ExerciseDto>> GetAllAsync();
        Task<ExerciseDto> GetByIdAsync(int id);
        Task<ExerciseDto> CreateAsync(ExerciseDto exercise);
        Task<ExerciseDto> UpdateAsync(ExerciseDto exercise);
        Task<ExerciseDto> DeleteAsync(ExerciseDto exercise);
    }
}
