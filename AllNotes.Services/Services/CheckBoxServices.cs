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
    public class CheckBoxServices : BaseServices, ICheckBoxServices
    {
        public IWrapperRepository WrapperRepository { get; }

        public CheckBoxServices(AllNotesDbContext context, IWrapperRepository wrapperRepository) : base(context)
        {
            WrapperRepository = wrapperRepository;
        }

        public async Task<IList<CheckBox>> GetAllAsync()
        {
            var result = await WrapperRepository.CheckBox.GetAllAsync();

            return result;
        }

        public async Task<CheckBox> GetByIdAsync(int id)
        {
            var result = await WrapperRepository.CheckBox.GetByIdAsync(id);

            return result;
        }

        public async Task<CheckBox> CreateAsync(string name, int checkListId, int noteId)
        {
            CheckBox checkBox = new CheckBox();
            checkBox.Name = name;
            checkBox.IsChecked = false;
            if (checkListId == -1){
                checkBox.CheckListId = null;
            }
            else{
                checkBox.CheckListId = checkListId;
            }
            if (checkListId == -1) { 
                checkBox.NoteId = null;
            }
            else { 
                checkBox.NoteId = noteId;
            }
            var result = await WrapperRepository.CheckBox.CreateAsync(checkBox);
            await base.CommitChanges();

            return result;
        }

        public async Task<CheckBox> UpdateAsync(CheckBox checkBox)
        {
            var result = await WrapperRepository.CheckBox.GetByIdAsync(checkBox.Id);
            result.Name = checkBox.Name;
            result.IsChecked = checkBox.IsChecked;
            result.CheckListId = checkBox.CheckListId;
            await base.CommitChanges();

            return result;
        }

        public async Task<CheckBox> DeleteAsync(CheckBox checkBox)
        {
            var result = WrapperRepository.CheckBox.Delete(checkBox);
            await base.CommitChanges();

            return result;
        }
    }
}