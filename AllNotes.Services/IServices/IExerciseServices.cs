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
        Task<IList<Exercise>> GetAllAsync();
        Task<Exercise> GetByIdAsync(int id);
        Task<Exercise> CreateAsync(string name,string description, int categoryId);
        Task<Exercise> UpdateAsync(Exercise exercise);
        Task<Exercise> DeleteAsync(Exercise exercise);
    }
}
