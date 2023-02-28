using MenuFacile.Manager.Domain.Contracts.Repositories;
using MenuFacile.Manager.Domain.Contracts.Services;
using MenuFacile.Manager.Domain.DTO.Request.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Application.Services
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _repository;

        public MenuService(IMenuRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<T>> MenuAdd<T>(T response, MenuAddRequest request)
        {
            return await _repository.MenuAdd(response, request);
        }

        public async Task<IEnumerable<T>> MenuList<T>(T response)
        {
            return await _repository.MenuList(response);
        }

        public async Task<IEnumerable<T>> MenuEdit<T>(T response, MenuEditRequest request)
        {
            return await _repository.MenuEdit(response, request);
        }

        public async Task<IEnumerable<T>> MenuDelete<T>(T response, MenuBaseRequest request)
        {
            return await _repository.MenuDelete(response, request);
        }

        public async Task<T> GetMenuByIdAsync<T>(T response, MenuBaseRequest request)
        {
            return await _repository.GetMenuByIdAsync(response, request);
        }
    }
}
