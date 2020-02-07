using AllNotes.Domain.EF.Wrapper;
using AllNotes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AllNotes.Services.IServices
{
    public interface IScheduleServices : IBaseServices
    {
        IWrapperRepository WrapperRepository { get; }
        Task<IList<Schedule>> GetAllAsync();
        Task<Schedule> GetByIdAsync(int id);
        Task<Schedule> CreateAsync(string dateTime);
        Task<Schedule> DeleteAsync(Schedule schedule);
        Task<Schedule> GetIdByDate(DateTime date);
    }
}
