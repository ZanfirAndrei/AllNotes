using AllNotes.Domain.EF.AllNotesContext;
using AllNotes.Domain.EF.Wrapper;
using AllNotes.Domain.Models;
using AllNotes.Services.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AllNotes.Services.Services
{
    public class ScheduleServices : BaseServices, IScheduleServices
    {
        public IWrapperRepository WrapperRepository { get; }

        public ScheduleServices(AllNotesDbContext context, IWrapperRepository wrapperRepository) : base(context)
        {
            WrapperRepository = wrapperRepository;
        }

        public async Task<IList<Schedule>> GetAllAsync()
        {
            var result = await WrapperRepository.Schedule.GetAllAsync();

            return result;
        }

        public async Task<Schedule> GetByIdAsync(int id)
        {
            var result = await WrapperRepository.Schedule.GetByIdAsync(id);

            return result;
        }
        
        public async Task<Schedule> GetByDate(DateTime date)
        {
            var result = await WrapperRepository.Schedule.GetAllAsync();
            foreach(var r in result)
            {
                if (System.DateTime.Equals(r.Date, date))
                {
                    return r;
                }
            }
            return null;
        }

        public async Task<Schedule> CreateAsync(string date)
        {
            Schedule schedule = new Schedule();
            schedule.Date = DateTime.Parse(date);
            var result = await WrapperRepository.Schedule.CreateAsync(schedule);
            await base.CommitChanges();

            return result;   
        }

        public async Task<Schedule> DeleteAsync(Schedule schedule)
        {
            //Schedule schedule = await GetByIdAsync(id);
            var result = WrapperRepository.Schedule.Delete(schedule);
            await base.CommitChanges();

            return result;
        }
    }
}
