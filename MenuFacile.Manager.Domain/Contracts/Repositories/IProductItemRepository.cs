using MenuFacile.Manager.Domain.DTO.Request.ProductItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Domain.Contracts.Repositories
{
    public interface IProductItemRepository
    {
        Task<IEnumerable<T>> ProductItemAdd<T>(T response, ProductItemAddRequest request);

        Task<IEnumerable<T>> ProductItemList<T>(T response);

        Task<IEnumerable<T>> ProductItemEdit<T>(T response, ProductItemEditRequest request);

        Task<IEnumerable<T>> ProductItemDelete<T>(T response, ProductItemBaseRequest request);

        Task<T> GetProductItemByIdAsync<T>(T response, ProductItemBaseRequest request);
    }
}
