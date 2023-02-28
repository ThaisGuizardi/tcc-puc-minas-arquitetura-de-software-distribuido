using MenuFacile.Manager.Domain.Contracts.Repositories;
using MenuFacile.Manager.Domain.Contracts.Services;
using MenuFacile.Manager.Domain.DTO.Request.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<T>> ProductAdd<T>(T response, ProductAddRequest request)
        {
            return await _repository.ProductAdd(response, request);
        }

        public async Task<IEnumerable<T>> ProductList<T>(T response)
        {
            return await _repository.ProductList(response);
        }

        public async Task<IEnumerable<T>> ProductEdit<T>(T response, ProductEditRequest request)
        {
            return await _repository.ProductEdit(response, request);
        }

        public async Task<IEnumerable<T>> ProductDelete<T>(T response, ProductBaseRequest request)
        {
            return await _repository.ProductDelete(response, request);
        }

        public async Task<T> GetProductByIdAsync<T>(T response, ProductBaseRequest request)
        {
            return await _repository.GetProductByIdAsync(response, request);
        }
    }
}
