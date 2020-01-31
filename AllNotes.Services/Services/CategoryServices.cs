using AllNotes.Domain.EF.AllNotesContext;
using AllNotes.Domain.EF.Wrapper;
using AllNotes.Services.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllNotes.Services.Services
{
    public class CategoryServices : BaseServices, ICategoryServices
    {
        public IWrapperRepository WrapperRepository { get; }

        public CategoryServices(AllNotesDbContext context, IWrapperRepository wrapperRepository) : base(context)
        {
            WrapperRepository = wrapperRepository;
        }
    }
}