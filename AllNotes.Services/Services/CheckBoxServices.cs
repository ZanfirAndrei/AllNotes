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
    }
}