using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllNotes.Domain.Dtos;
using AllNotes.Domain.Models;
using AllNotes.Services.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AllNotes.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleServices _scheduleServices;
        private readonly IMapper _mapper;

        public ScheduleController(IScheduleServices scheduleServices, IMapper mapper)
        {
            _scheduleServices = scheduleServices;
            _mapper = mapper;
        }
        
        [HttpGet("GetSchedules")]
        [AllowAnonymous]
        //[Authorize(Policy = "User")]
        //[Authorize]
        public async Task<ObjectResult> GetAllSchedulesAsync()
        {
            try
            {
                var result = await _scheduleServices.GetAllAsync();
                return Ok(_mapper.Map<IList<Schedule>, IList<ScheduleDto>>(result));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }   
        }

        [HttpGet("GetSchedules/{id}")]
        [AllowAnonymous]
        //[Authorize]
        public async Task<ObjectResult> GetScheduleAsync([FromRoute] int id)
        {
            Schedule result = await _scheduleServices.GetByIdAsync(id);

            return Ok(_mapper.Map<Schedule, ScheduleDto>(result));
        } 

        [HttpPost("AddSchedule")]
        [AllowAnonymous]
        public async Task<ObjectResult> AddScheduleAsync([FromBody] ScheduleDto dto)
        {
            try 
            {
                Schedule result = await _scheduleServices.CreateAsync(dto.Date.ToString());
                return Ok(_mapper.Map<Schedule,ScheduleDto>(result));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("DeleteSchedule/{id}")]
        [AllowAnonymous]
        public async Task<ObjectResult> DeleteSchedule([FromRoute] int id)
        {
            try
            {
                Schedule result = await _scheduleServices.GetByIdAsync(id);
                await _scheduleServices.DeleteAsync(result);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        
    }
}
