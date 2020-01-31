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
    }
}
