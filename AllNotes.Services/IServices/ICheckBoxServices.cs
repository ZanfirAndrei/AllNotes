using AllNotes.Domain.EF.Wrapper;
using AllNotes.Domain.Models.Memo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AllNotes.Services.IServices
{
    public interface ICheckBoxServices : IBaseServices
    {
        IWrapperRepository WrapperRepository { get; }
        Task<IList<CheckBox>> GetAllAsync();
    }
}
