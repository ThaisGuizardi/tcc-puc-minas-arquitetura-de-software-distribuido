using MenuFacile.Manager.Domain.DTO.Request.ProductPrice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Domain.Contracts.Services
{
    public interface IProductPriceService
    {
        Task<IEnumerable<T>> ProductPriceAdd<T>(T response, ProductPriceAddRequest request);

        Task<IEnumerable<T>> ProductPriceList<T>(T response);

        Task<IEnumerable<T>> ProductPriceEdit<T>(T response, ProductPriceEditRequest request);

        Task<IEnumerable<T>> ProductPriceDelete<T>(T response, ProductPriceBaseRequest request);

        Task<T> GetProductPriceByIdAsync<T>(T response, ProductPriceBaseRequest request);
    }
}
