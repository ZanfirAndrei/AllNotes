using AllNotes.Domain.EF.AllNotesContext;
using AllNotes.Domain.EF.Wrapper;
using AllNotes.Domain.Models.Sport;
using AllNotes.Services.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AllNotes.Services.Services
{
    public class ExerciseServices : BaseServices, IExerciseServices
    {
        public IWrapperRepository WrapperRepository { get; }

        public ExerciseServices(AllNotesDbContext context, IWrapperRepository wrapperRepository) : base(context)
        {
            WrapperRepository = wrapperRepository;
        }

        public async Task<IList<Exercise>> GetAllAsync()
        {
            var result = await WrapperRepository.Exercise.GetAllAsync();

            return result;
        }

        public async Task<Exercise> GetByIdAsync(int id)
        {
            var result = await WrapperRepository.Exercise.GetByIdAsync(id);

            return result;
        }

        public async Task<Exercise> CreateAsync(string name, string description, int categoryId)
        {
            Exercise exercise = new Exercise();
            exercise.Name = name;
            exercise.Description = description;
            exercise.CategoryId = categoryId;
            var result = await WrapperRepository.Exercise.CreateAsync(exercise);
            await base.CommitChanges();

            return result;
        }

        public async Task<Exercise> UpdateAsync(Exercise exercise)
        {
            var result = await WrapperRepository.Exercise.GetByIdAsync(exercise.Id);
            result.Name = exercise.Name;
            result.Description = exercise.Description;
            result.CategoryId = exercise.CategoryId;
            await base.CommitChanges();

            return result;
        }

        public async Task<Exercise> DeleteAsync(Exercise exercise)
        {
            var result = WrapperRepository.Exercise.Delete(exercise);
            await base.CommitChanges();

            return result;
        }
    }
}
