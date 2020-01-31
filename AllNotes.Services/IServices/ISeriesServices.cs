﻿using AllNotes.Domain.EF.Wrapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllNotes.Services.IServices
{
    public interface ISeriesServices : IBaseServices
    {
        IWrapperRepository WrapperRepository { get; }
    }
}
