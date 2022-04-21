﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories.General
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();

    }
}
