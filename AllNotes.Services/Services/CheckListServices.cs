using AllNotes.Domain.EF.Wrapper;
using AllNotes.Services.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllNotes.Services.Services
{
    public class CheckListServices : BaseServices, ICheckListServices
    {
        public IWrapperRepository WrapperRepository { get; }

        public CheckListServices(Domain.EF.AllNotesContext.AllNotesDbContext context, IWrapperRepository wrapperRepository) : base(context)
        {
            WrapperRepository = wrapperRepository;
        }
    }
}
