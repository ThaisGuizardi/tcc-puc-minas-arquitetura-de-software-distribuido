using MenuFacile.Manager.Domain.Contracts.Repositories;
using MenuFacile.Manager.Domain.Contracts.Services;
using MenuFacile.Manager.Domain.DTO.Request.ProductPrice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Application.Services
{
    public class ProductPriceService : IProductPriceService
    {
        private readonly IProductPriceRepository _repository;

        public ProductPriceService(IProductPriceRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<T>> ProductPriceAdd<T>(T response, ProductPriceAddRequest request)
        {
            return await _repository.ProductPriceAdd(response, request);
        }

        public async Task<IEnumerable<T>> ProductPriceList<T>(T response)
        {
            return await _repository.ProductPriceList(response);
        }

        public async Task<IEnumerable<T>> ProductPriceEdit<T>(T response, ProductPriceEditRequest request)
        {
            return await _repository.ProductPriceEdit(response, request);
        }

        public async Task<IEnumerable<T>> ProductPriceDelete<T>(T response, ProductPriceBaseRequest request)
        {
            return await _repository.ProductPriceDelete(response, request);
        }

        public async Task<T> GetProductPriceByIdAsync<T>(T response, ProductPriceBaseRequest request)
        {
            return await _repository.GetProductPriceByIdAsync(response, request);
        }
    }
}
