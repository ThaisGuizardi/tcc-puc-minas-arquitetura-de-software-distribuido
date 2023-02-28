using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Domain.Contracts.Services
{
    public interface IStateService
    {
        Task<IEnumerable<T>> GetStatesAsync<T>(T response);
    }
}
