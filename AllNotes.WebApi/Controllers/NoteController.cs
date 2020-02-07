﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AllNotes.Domain.EF.AllNotesContext;
using AllNotes.Domain.Models.Memo;
using AllNotes.Services.IServices;

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

        // GET: api/Notes
        [HttpGet]
        public async Task<ObjectResult> GetAllNotesAsync()
        {
            IList<Note> result = await _noteServices.GetAllAsync();

            return Ok(result);
        }

        // GET: api/Notes/5
        [HttpGet("{id}")]
        public async Task<ObjectResult> GetNoteAsync([FromRoute] int id)
        {
            Note result = await _noteServices.GetByIdAsync(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ObjectResult> AddCategoryAsync([FromBody] string name, string description)
        {

            Note result = await _noteServices.CreateAsync(name, description);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ObjectResult> UpdateCategoryAsync([FromRoute] int id, [FromBody] string name, string description)
        {
            Note result = await _noteServices.GetByIdAsync(id);
            if (result == null)
            {
                return BadRequest(new { message = "Note not available" });
            }

            var note = new Note { Id = result.Id, Name = name, Description = description };
            await _noteServices.UpdateAsync(note);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ObjectResult> DeleteCategory([FromRoute] int id)
        {
            Note result = await _noteServices.GetByIdAsync(id);
            await _noteServices.DeleteAsync(result);

            return Ok(result);
        }

        //private bool NoteExists(int id)
        //{
        //    return _context.Notes.Any(e => e.Id == id);
        //}
    }
}