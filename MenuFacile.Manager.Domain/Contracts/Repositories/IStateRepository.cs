﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Domain.Contracts.Repositories
{
    public interface IStateRepository
    {
        Task<IEnumerable<T>> GetStatesAsync<T>(T response);
    }
}
