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
using AllNotes.Domain.Dtos;

namespace AllNotes.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteServices _noteServices;

        public NoteController(INoteServices noteServices)
        {
            _noteServices = noteServices;
        }

        #region Notes
        [HttpGet("GetNotes")]
        [AllowAnonymous]
        public async Task<ObjectResult> GetAllNotesAsync()
        {
            IList<NoteDto> result = await _noteServices.GetAllAsync();

            return Ok(result);
        }

        
        [HttpGet("GetNotes/{id}")]
        [AllowAnonymous]
        public async Task<ObjectResult> GetNoteAsync([FromRoute] int id)
        {
            NoteDto result = await _noteServices.GetByIdAsync(id);

            return Ok(result);
        }

        [HttpPost("CreateNote")]
        [AllowAnonymous]
        public async Task<ObjectResult> AddNotesAsync([FromBody] NoteDto dto)
        {

            NoteDto result = await _noteServices.CreateAsync(dto);

            return Ok(result);
        }

        [HttpPut("UpdateNote/{id}")]
        [AllowAnonymous]
        public async Task<ObjectResult> UpdateNotesAsync([FromRoute] int id, [FromBody] NoteDto dto )
        {
            NoteDto result = await _noteServices.GetByIdAsync(id);
            if (result == null)
            {
                return BadRequest(new { message = "Note not available" });
            }

            //var note = new Note { Id = result.Id, Name = name, Description = description };
            var res = await _noteServices.UpdateAsync(dto);

            return Ok(res);
        }

        [HttpDelete("DeleteNote/{id}")]
        [AllowAnonymous]
        public async Task<ObjectResult> DeleteCategory([FromRoute] int id)
        {
            NoteDto result = await _noteServices.GetByIdAsync(id);
            await _noteServices.DeleteAsync(result);

            return Ok(result);
        }

        #endregion
    }
}
