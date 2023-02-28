using MenuFacile.Manager.Domain.Contracts.Repositories;
using MenuFacile.Manager.Domain.Contracts.Services;
using MenuFacile.Manager.Domain.DTO.Request.ProductItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Application.Services
{
    public class ProductItemService : IProductItemService
    {
        private readonly IProductItemRepository _repository;

        public ProductItemService(IProductItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<T>> ProductItemAdd<T>(T response, ProductItemAddRequest request)
        {
            return await _repository.ProductItemAdd(response, request);
        }

        public async Task<IEnumerable<T>> ProductItemList<T>(T response)
        {
            return await _repository.ProductItemList(response);
        }

        public async Task<IEnumerable<T>> ProductItemEdit<T>(T response, ProductItemEditRequest request)
        {
            return await _repository.ProductItemEdit(response, request);
        }

        public async Task<IEnumerable<T>> ProductItemDelete<T>(T response, ProductItemBaseRequest request)
        {
            return await _repository.ProductItemDelete(response, request);
        }

        public async Task<T> GetProductItemByIdAsync<T>(T response, ProductItemBaseRequest request)
        {
            return await _repository.GetProductItemByIdAsync(response, request);
        }
    }
}
