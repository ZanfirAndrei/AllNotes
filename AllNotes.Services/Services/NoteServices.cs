using AllNotes.Domain.EF.AllNotesContext;
using AllNotes.Domain.EF.Wrapper;
using AllNotes.Domain.Models.Memo;
using AllNotes.Services.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AllNotes.Services.Services
{
    public class NoteServices : BaseServices, INoteServices
    {
        public IWrapperRepository WrapperRepository { get; }

        public NoteServices(AllNotesDbContext context, IWrapperRepository wrapperRepository) : base(context)
        {
            WrapperRepository = wrapperRepository;
        }

        public async Task<IList<Note>> GetAllAsync()
        {
            var result = await WrapperRepository.Note.GetAllAsync();
            
            return result;
        }

        public async Task<Note> GetByIdAsync(int id)
        {
            var result = await WrapperRepository.Note.GetByIdAsync(id);
            
            return result;
        }

        public async Task<Note> CreateAsync(Note note)
        {
            var result = await WrapperRepository.Note.CreateAsync(note);
            await base.CommitChanges();

            return result;
        }

        public async Task<Note> UpdateAsync(Note note)
        {
            var result = await WrapperRepository.Note.GetByIdAsync(note.Id);
            result.Name = note.Name;
            result.Description = note.Description;
            result.Timestamp = DateTime.Now;
            result.ScheduleId = note.ScheduleId;
            result.UserId = note.UserId;
            if (note.CheckBoxes != null)
                result.CheckBoxes = note.CheckBoxes; 
            await base.CommitChanges();

            return result;
    }

        public async Task<Note> DeleteAsync(Note note)
        {
            var result = WrapperRepository.Note.Delete(note);
            await base.CommitChanges();

            return result;
        }
    }
}
