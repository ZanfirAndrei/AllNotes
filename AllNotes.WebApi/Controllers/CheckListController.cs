using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllNotes.Domain.Dtos;
using AllNotes.Domain.Models;
using AllNotes.Domain.Models.Memo;
using AllNotes.Services.IServices;
using AllNotes.Services.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AllNotes.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckListController : ControllerBase
    {
        private readonly ICheckListServices _checkListServices;
        private readonly ICheckBoxServices _checkBoxServices;
        private readonly IScheduleServices _scheduleServices;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;


        public CheckListController(ICheckListServices checkListServices,
                                   ICheckBoxServices checkBoxServices,
                                   IScheduleServices scheduleServices,
                                   UserManager<User> userManager,
                                   IMapper mapper)
        {
            _checkListServices = checkListServices;
            _checkBoxServices = checkBoxServices;
            _scheduleServices = scheduleServices;
            _userManager = userManager;
            _mapper = mapper;
        }


        #region CheckList
        [HttpGet("GetCheckLists")]
        [AllowAnonymous]
        public async Task<ObjectResult> GetAllCheckListsAsync()
        {
            try
            {
                var result = await _checkListServices.GetAllAsync();
                return Ok(_mapper.Map<IList<CheckList>, IList<CheckList>>(result));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("GetCheckLists/{id}")]
        [AllowAnonymous]
        public async Task<ObjectResult> GetCheckListAsync([FromRoute] int id)
        {
            CheckList result = await _checkListServices.GetByIdAsync(id);

            return Ok(_mapper.Map<CheckList, CheckListDto>(result));
        }

        [HttpPost("AddCheckList")]
        [AllowAnonymous]
        public async Task<ObjectResult> AddCheckListAsync([FromBody] CheckListDto dto)
        {
            //try
            //{
                CheckList checkList = _mapper.Map<CheckListDto, CheckList>(dto);

                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                checkList.UserId = user.Id;
            

                if (checkList.Schedule != null)
                {
                    var schedule = _scheduleServices.GetByDate(checkList.Schedule.Date);
                    if (schedule != null)
                    {
                        checkList.ScheduleId = schedule.Id;
                    }
                    else
                    {
                        var resultS = await _scheduleServices.CreateAsync(checkList.Schedule.Date.ToString());
                        checkList.ScheduleId = resultS.Id;
                    }
                }
                else
                {
                    checkList.ScheduleId = null;
                }
                
                CheckList result = await _checkListServices.CreateAsync(checkList);
                
                if(result.CheckBoxes.Count > 0)
                {
                    foreach (CheckBoxDto i in dto.CheckBoxes)
                    {
                        await _checkBoxServices.CreateAsync(i.Name, result.Id, -1);
                    }
                }

                return Ok(_mapper.Map<CheckList, CheckListDto>(result));
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(new { message = ex.Message });
            //}

        }

        [HttpPut("UpdateCheckList/{id}")]
        [AllowAnonymous]
        public async Task<ObjectResult> UpdateCheckListAsync([FromRoute] int id, [FromBody] CheckListDto dto)
        {
            try
            {
                var checkList = _mapper.Map<CheckListDto, CheckList>(dto);

                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                checkList.UserId = user.Id;

                if (checkList.Schedule != null)
                {
                    var schedule = _scheduleServices.GetByDate(checkList.Schedule.Date);
                    if (schedule != null)
                    {
                        checkList.ScheduleId = schedule.Id;
                    }
                    else
                    {
                        var resultS = await _scheduleServices.CreateAsync(checkList.Schedule.Date.ToString());
                        checkList.ScheduleId = resultS.Id;
                    }
                }
                else
                {
                    checkList.ScheduleId = null;
                }

                CheckList result = await _checkListServices.UpdateAsync(checkList);

                IList<CheckBox> checkBoxes = await _checkBoxServices.GetAllAsync();
                foreach (CheckBox i in checkBoxes)
                {
                    if (i.CheckListId == result.Id)
                    {
                        await _checkBoxServices.DeleteAsync(i);
                    }
                }

                if (result.CheckBoxes.Count > 0)
                {
                    foreach (CheckBoxDto i in dto.CheckBoxes)
                    {
                        await _checkBoxServices.CreateAsync(i.Name, result.Id, -1);
                    }
                }

                return Ok(_mapper.Map<CheckList, CheckListDto>(result));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("DeleteCheckList/{id}")]
        [AllowAnonymous]
        public async Task<ObjectResult> DeleteCheckList([FromRoute] int id)
        {
            CheckList result = await _checkListServices.GetByIdAsync(id);
            await _checkListServices.DeleteAsync(result);

            return Ok(result);
        }
        #endregion


        #region CheckBox
        //[HttpGet("GetCheckBoxes")]
        //[AllowAnonymous]
        //public async Task<ObjectResult> GetAllBoxesAsync()
        //{
        //    IList<CheckBox> result = await _checkBoxServices.GetAllAsync();

        //    return Ok(result);
        //}

        //[HttpGet("GetCheckBoxes/{id}")]
        //[AllowAnonymous]
        //public async Task<ObjectResult> GetCheckBoxAsync([FromRoute] int id)
        //{
        //    CheckBox result = await _checkBoxServices.GetByIdAsync(id);

        //    return Ok(result);
        //}

        //[HttpPost("AddCheckBox")]
        //public async Task<ObjectResult> AddCheckBoxAsync([FromBody] string name, int checkListId)
        //{

        //    CheckBox result = await _checkBoxServices.CreateAsync(name,checkListId);

        //    return Ok(result);
        //}

        //[HttpPut("UpdateCheckBox/{id}")]
        //public async Task<ObjectResult> UpdateCheckBoxAsync([FromRoute] int id, [FromBody] string name, bool isChecked)
        //{
        //    CheckBox result = await _checkBoxServices.GetByIdAsync(id);
        //    if (result == null)
        //    {
        //        return BadRequest(new { message = "CheckBox not available" });
        //    }

        //    var checkBox = new CheckBox { Id = result.Id, Name = name, IsChecked = isChecked};
        //    await _checkBoxServices.UpdateAsync(checkBox);

        //    return Ok(result);
        //}

        //[HttpDelete("DeleteCheckBox/{id}")]
        //[AllowAnonymous]
        //public async Task<ObjectResult> DeleteCheckBox([FromRoute] int id)
        //{
        //    CheckBox result = await _checkBoxServices.GetByIdAsync(id);
        //    await _checkBoxServices.DeleteAsync(result);

        //    return Ok(result);
        //}
        #endregion
    }
}
