using MenuFacile.Manager.Domain.Contracts.Repositories;
using MenuFacile.Manager.Domain.Contracts.Services;
using MenuFacile.Manager.Domain.DTO.Request.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<T>> CategoryAdd<T>(T response, CategoryAddRequest request)
        {
            return await _repository.CategoryAdd(response, request);
        }

        public async Task<IEnumerable<T>> CategoryList<T>(T response)
        {
            return await _repository.CategoryList(response);
        }

        public async Task<IEnumerable<T>> CategoryEdit<T>(T response, CategoryEditRequest request)
        {
            return await _repository.CategoryEdit(response, request);
        }

        public async Task<IEnumerable<T>> CategoryDelete<T>(T response, CategoryBaseRequest request)
        {
            return await _repository.CategoryDelete(response, request);
        }

        public async Task<T> GetCategoryByIdAsync<T>(T response, CategoryBaseRequest request)
        {
            return await _repository.GetCategoryByIdAsync(response, request);
        }

    }
}
