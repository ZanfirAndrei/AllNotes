using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AllNotes.Services.IServices
{
    public interface IBaseServices
    {
        Task CommitChanges();
    }
}
