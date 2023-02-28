using MenuFacile.Manager.Domain.DTO.Request.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Domain.Contracts.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<T>> ProductAdd<T>(T response, ProductAddRequest request);

        Task<IEnumerable<T>> ProductList<T>(T response);

        Task<IEnumerable<T>> ProductEdit<T>(T response, ProductEditRequest request);

        Task<IEnumerable<T>> ProductDelete<T>(T response, ProductBaseRequest request);

        Task<T> GetProductByIdAsync<T>(T response, ProductBaseRequest request);

    }
}
