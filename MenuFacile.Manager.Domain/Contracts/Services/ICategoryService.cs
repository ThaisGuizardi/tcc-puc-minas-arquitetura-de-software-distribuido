using MenuFacile.Manager.Domain.DTO.Request.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Domain.Contracts.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<T>> CategoryAdd<T>(T response, CategoryAddRequest request);

        Task<IEnumerable<T>> CategoryList<T>(T response);

        Task<IEnumerable<T>> CategoryEdit<T>(T response, CategoryEditRequest request);

        Task<IEnumerable<T>> CategoryDelete<T>(T response, CategoryBaseRequest request);

        Task<T> GetCategoryByIdAsync<T>(T response, CategoryBaseRequest request);
    }
}
