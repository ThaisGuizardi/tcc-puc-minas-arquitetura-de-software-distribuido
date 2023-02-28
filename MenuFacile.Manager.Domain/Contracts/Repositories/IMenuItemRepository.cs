using MenuFacile.Manager.Domain.DTO.Request.MenuItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Domain.Contracts.Repositories
{
    public interface IMenuItemRepository
    {
        Task<IEnumerable<T>> MenuItemAdd<T>(T response, MenuItemAddRequest request);

        Task<IEnumerable<T>> MenuItemList<T>(T response);

        Task<IEnumerable<T>> MenuItemEdit<T>(T response, MenuItemEditRequest request);

        Task<IEnumerable<T>> MenuItemDelete<T>(T response, MenuItemBaseRequest request);

        Task<T> GetMenuItemByIdAsync<T>(T response, MenuItemBaseRequest request);
    }
}
