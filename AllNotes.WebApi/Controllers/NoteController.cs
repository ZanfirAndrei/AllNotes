using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AllNotes.Domain.EF.AllNotesContext;
using AllNotes.Domain.Models.Memo;
using AllNotes.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using AllNotes.Domain.Dtos;
using Microsoft.AspNetCore.Identity;
using AllNotes.Domain.Models;

namespace AllNotes.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteServices _noteServices;
        private readonly ICheckBoxServices _checkBoxServices;
        private readonly IScheduleServices _scheduleServices;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public NoteController(INoteServices noteServices, 
                              ICheckBoxServices checkBoxServices,
                              IScheduleServices scheduleServices,
                              IMapper mapper)
        {
            _noteServices = noteServices;
            _checkBoxServices = checkBoxServices;
            _scheduleServices = scheduleServices;
            _mapper = mapper;
        }


        #region Notes
        [HttpGet("GetNotes")]
        [AllowAnonymous]
        public async Task<ObjectResult> GetAllNotesAsync()
        {
            try
            {
                var result = await _noteServices.GetAllAsync();
                return Ok(_mapper.Map<IList<Note>, IList<NoteDto>>(result));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        [HttpGet("GetNotes/{id}")]
        [AllowAnonymous]
        public async Task<ObjectResult> GetNoteAsync([FromRoute] int id)
        {
            NoteDto result = await _noteServices.GetByIdAsync(id);

            return Ok(_mapper.Map<Note, Note>(result));
        }


        [HttpPost("AddNote")]
        [AllowAnonymous]
        public async Task<ObjectResult> AddNoteAsync([FromBody] NoteDto dto)
        {
            //Note result = await _noteServices.CreateAsync(name, description);
            try
            {
                var note = _mapper.Map<NoteDto, Note>(dto);

                var userId = _userManager.GetUserId(User);
                note.UserId = userId;
                //string a = User.Identity.Name;

                if (note.Schedule != null)
                {
                    var schedule = _scheduleServices.GetByDate(note.Schedule.Date);
                    if (schedule != null)
                    {
                        note.ScheduleId = schedule.Id;
                    }
                    else
                    {
                        var resultS = await _scheduleServices.CreateAsync(note.Schedule.Date.ToString());
                        note.ScheduleId = resultS.Id;
                    }
                }
                else
                {
                    note.ScheduleId = null;
                }

                Note result = await _noteServices.CreateAsync(note);

                if (result.CheckBoxes.Count > 0)
                {
                    foreach (CheckBoxDto i in dto.CheckBoxes)
                    {
                        await _checkBoxServices.CreateAsync(i.Name, result.Id);
                    }
                }

                return Ok(_mapper.Map<Note, NoteDto>(result));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("UpdateNote/{id}")]
        [AllowAnonymous]

        public async Task<ObjectResult> UpdateNoteAsync([FromRoute] int id, [FromBody] NoteDto dto)
        {
            try
            {
                var note = _mapper.Map<NoteDto, Note>(dto);
                var userId = _userManager.GetUserId(User);
                note.UserId = userId;
                //string a = User.Identity.Name;

                if (note.Schedule != null)
                {
                    var schedule = _scheduleServices.GetByDate(note.Schedule.Date);
                    if (schedule != null)
                    {
                        note.ScheduleId = schedule.Id;
                    }
                    else
                    {
                        var resultS = await _scheduleServices.CreateAsync(note.Schedule.Date.ToString());
                        note.ScheduleId = resultS.Id;
                    }
                }
                else
                {
                    note.ScheduleId = null;
                }

                Note result = await _noteServices.UpdateAsync(note);

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
                        await _checkBoxServices.CreateAsync(i.Name, result.Id);
                    }
                }

                return Ok(_mapper.Map<Note, NoteDto>(result));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("DeleteNote/{id}")]
        [AllowAnonymous]
        public async Task<ObjectResult> DeleteNote([FromRoute] int id)
        {
            NoteDto result = await _noteServices.GetByIdAsync(id);
            await _noteServices.DeleteAsync(result);

            return Ok(result);
        }

        #endregion

    }
}
