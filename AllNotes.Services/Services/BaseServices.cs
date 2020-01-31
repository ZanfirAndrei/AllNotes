using AllNotes.Domain.EF.AllNotesContext;
using AllNotes.Services.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AllNotes.Services.Services
{
    public class BaseServices : IBaseServices
    {
        private readonly AllNotesDbContext _context;

        public BaseServices(AllNotesDbContext context)
        {
            _context = context;
        }

        public async Task CommitChanges()
        {
            await _context.SaveChangesAsync(true);
        }
    }
}