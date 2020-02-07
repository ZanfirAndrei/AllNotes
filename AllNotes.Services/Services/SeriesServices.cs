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
    public class SeriesServices : BaseServices, ISeriesServices
    {
        public IWrapperRepository WrapperRepository { get; }

        public SeriesServices(AllNotesDbContext context, IWrapperRepository wrapperRepository) : base(context)
        {
            WrapperRepository = wrapperRepository;
        }

        public async Task<IList<Series>> GetAllAsync()
        {
            var result = await WrapperRepository.Series.GetAllAsync();

            return result;
        }

        public async Task<Series> GetByIdAsync(int id)
        {
            var result = await WrapperRepository.Series.GetByIdAsync(id);

            return result;
        }

        public async Task<Series> CreateAsync(int repeats, float weights, int exerciseId)
        {
            Series series = new Series();
            series.Repeats = repeats;
            series.Weights = weights;
            series.ExerciseId = exerciseId;
            var result = await WrapperRepository.Series.CreateAsync(series);
            await base.CommitChanges();

            return result;
        }

        public async Task<Series> UpdateAsync(Series series)
        {
            var result = await WrapperRepository.Series.GetByIdAsync(series.Id);
            result.Repeats = series.Repeats;
            result.Weights = series.Weights;
            result.ExerciseId = series.ExerciseId;
            await base.CommitChanges();

            return result;
        }

        public async Task<Series> DeleteAsync(Series series)
        {
            var result = WrapperRepository.Series.Delete(series);
            await base.CommitChanges();

            return result;
        }
    }
}
