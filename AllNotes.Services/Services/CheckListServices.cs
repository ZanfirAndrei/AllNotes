using AllNotes.Domain.EF.Wrapper;
using AllNotes.Domain.Models;
using AllNotes.Domain.Models.Memo;
using AllNotes.Models;
using AllNotes.Services.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AllNotes.Services.Services
{
    public class CheckListServices : BaseServices, ICheckListServices
    {
        public IWrapperRepository WrapperRepository { get; }
        public ICheckBoxServices CheckBoxServices { get; }
        public IScheduleServices ScheduleServices { get; }

        public CheckListServices(Domain.EF.AllNotesContext.AllNotesDbContext context, 
                                    IWrapperRepository wrapperRepository, 
                                    ICheckBoxServices checkBoxServices,
                                    IScheduleServices scheduleServices
            ) : base(context)
        {
            WrapperRepository = wrapperRepository;
            CheckBoxServices = checkBoxServices;
            ScheduleServices = scheduleServices;
        }

        public async Task<IList<CheckList>> GetAllAsync()
        {
            var result = await WrapperRepository.CheckList.GetAllAsync();

            return result;
        }

        public async Task<CheckList> GetByIdAsync(int id)
        {
            var result = await WrapperRepository.CheckList.GetByIdAsync(id);

            return result;
        }

        public async Task<CheckList> CreateAsync(CheckListDto dto)
        {
            CheckList checkList = new CheckList();
            checkList.Name = dto.Name;
            checkList.TimeStamp = DateTime.Now;
            checkList.IsComplete = false;

            if (dto.Schedule.Date != null)
            {
                var resultS = await ScheduleServices.CreateAsync(dto.Schedule.Date.ToString());
                checkList.ScheduleId = resultS.Id;
            }
            else
            {
                checkList.ScheduleId = null;
            }

            var result = await WrapperRepository.CheckList.CreateAsync(checkList);
            await base.CommitChanges();

            if(dto.CheckBoxes.Count > 0)
            {
                foreach(CheckBoxDto i in dto.CheckBoxes)
                {
                    await CheckBoxServices.CreateAsync(i.Name, result.Id);
                }
            }

            return result;
        }

        public async Task<CheckList> UpdateAsync(CheckList checkList)
        {
            var result = await WrapperRepository.CheckList.GetByIdAsync(checkList.Id);
            result.Name = checkList.Name;
            result.TimeStamp = DateTime.Now;
            result.IsComplete = checkList.IsComplete;
            await base.CommitChanges();

            return result;
        }

        public async Task<CheckList> DeleteAsync(CheckList checkList)
        {
            var result = WrapperRepository.CheckList.Delete(checkList);
            await base.CommitChanges();

            return result;
        }
    }
}
