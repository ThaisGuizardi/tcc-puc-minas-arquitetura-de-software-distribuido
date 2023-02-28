using MenuFacile.Manager.Domain.Contracts.Repositories;
using MenuFacile.Manager.Domain.Contracts.Services;
using MenuFacile.Manager.Domain.DTO.Request.PaymentMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Application.Services
{
    public class PaymentMethodService : IPaymentMethodService
    {
        private readonly IPaymentMethodRepository _repository;

        public PaymentMethodService(IPaymentMethodRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<T>> PaymentMethodAdd<T>(T response, PaymentMethodAddRequest request)
        {
            return await _repository.PaymentMethodAdd(response, request);
        }

        public async Task<IEnumerable<T>> PaymentMethodList<T>(T response)
        {
            return await _repository.PaymentMethodList(response);
        }

        public async Task<IEnumerable<T>> PaymentMethodEdit<T>(T response, PaymentMethodEditRequest request)
        {
            return await _repository.PaymentMethodEdit(response, request);
        }

        public async Task<IEnumerable<T>> PaymentMethodDelete<T>(T response, PaymentMethodBaseRequest request)
        {
            return await _repository.PaymentMethodDelete(response, request);
        }

        public async Task<T> GetPaymentMethodByIdAsync<T>(T response, PaymentMethodBaseRequest request)
        {
            return await _repository.GetPaymentMethodByIdAsync(response, request);
        }
    }
}
