using MenuFacile.Manager.Domain.Contracts.Repositories;
using MenuFacile.Manager.Domain.Contracts.Services;
using MenuFacile.Manager.Domain.DTO.Request.MenuItem;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Application.Services
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IMenuItemRepository _repository;

        public MenuItemService(IMenuItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<T>> MenuItemAdd<T>(T response, MenuItemAddRequest request)
        {
            return await _repository.MenuItemAdd(response, request);
        }

        public async Task<IEnumerable<T>> MenuItemList<T>(T response)
        {
            return await _repository.MenuItemList(response);
        }

        public async Task<IEnumerable<T>> MenuItemEdit<T>(T response, MenuItemEditRequest request)
        {
            return await _repository.MenuItemEdit(response, request);
        }

        public async Task<IEnumerable<T>> MenuItemDelete<T>(T response, MenuItemBaseRequest request)
        {
            return await _repository.MenuItemDelete(response, request);
        }

        public async Task<T> GetMenuItemByIdAsync<T>(T response, MenuItemBaseRequest request)
        {
            return await _repository.GetMenuItemByIdAsync(response, request);
        }
    }
}
