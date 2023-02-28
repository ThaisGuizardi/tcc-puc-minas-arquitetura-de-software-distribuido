using MenuFacile.Manager.Domain.DTO.Request.PaymentMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Domain.Contracts.Services
{
    public interface IPaymentMethodService
    {
        Task<IEnumerable<T>> PaymentMethodAdd<T>(T response, PaymentMethodAddRequest request);

        Task<IEnumerable<T>> PaymentMethodList<T>(T response);

        Task<IEnumerable<T>> PaymentMethodEdit<T>(T response, PaymentMethodEditRequest request);

        Task<IEnumerable<T>> PaymentMethodDelete<T>(T response, PaymentMethodBaseRequest request);

        Task<T> GetPaymentMethodByIdAsync<T>(T response, PaymentMethodBaseRequest request);
    }
}
