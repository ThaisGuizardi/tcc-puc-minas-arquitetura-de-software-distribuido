using MenuFacile.Manager.Domain.DTO.Request.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Domain.Contracts.Services
{
    public interface IMenuService
    {
        Task<IEnumerable<T>> MenuAdd<T>(T response, MenuAddRequest request);

        Task<IEnumerable<T>> MenuList<T>(T response);

        Task<IEnumerable<T>> MenuEdit<T>(T response, MenuEditRequest request);

        Task<IEnumerable<T>> MenuDelete<T>(T response, MenuBaseRequest request);

        Task<T> GetMenuByIdAsync<T>(T response, MenuBaseRequest request);
    }
}
