using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllNotes.Domain.Models;
using AllNotes.Services.IServices;
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

        public ScheduleController(IScheduleServices scheduleServices)
        {
            _scheduleServices = scheduleServices;
        }
        
        [HttpGet("GetSchedules")]
        [AllowAnonymous]
        //[Authorize(Policy = "User")]
        //[Authorize]
        public async Task<ObjectResult> GetAllSchedulesAsync()
        {
            try
            {
                IList<Schedule> result = await _scheduleServices.GetAllAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }   
        }

        [HttpGet("GetSchedules/{id}")]
        [Authorize]
        public async Task<ObjectResult> GetScheduleAsync([FromRoute] int id)
        {
            Schedule result = await _scheduleServices.GetByIdAsync(id);

            return Ok(result);
        } 

        [HttpPost("AddSchedule")]
        [AllowAnonymous]
        public async Task<ObjectResult> AddScheduleAsync([FromBody] string date)
        {
            try 
            {
                Schedule result = await _scheduleServices.CreateAsync(date);
                return Ok(result);
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


        // GET: api/Schedule
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/Schedule/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Schedule
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT: api/Schedule/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
