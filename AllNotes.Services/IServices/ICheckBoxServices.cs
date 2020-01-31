using AllNotes.Domain.EF.Wrapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllNotes.Services.IServices
{
    public interface ICheckBoxServices : IBaseServices
    {
        IWrapperRepository WrapperRepository { get; }
    }
}
