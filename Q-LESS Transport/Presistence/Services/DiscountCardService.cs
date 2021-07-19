using Q_LESS_Transport.Domain.Models;
using Q_LESS_Transport.Domain.Repositories;
using Q_LESS_Transport.Domain.Services;
using Q_LESS_Transport.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q_LESS_Transport.Presistence.Services
{
    public class DiscountCardService : IDiscountCardService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDiscountCardRepository _discountCardRepository;

        public DiscountCardService(IUnitOfWork unitOfWork
            , IDiscountCardRepository discountCardRepository)
        {
            _unitOfWork = unitOfWork;
            _discountCardRepository = discountCardRepository;
        }
        public async Task<DiscountCardResponse> SaveAsync(DiscountCard discountCard)
        {
            try
            {
                _discountCardRepository.Insert(discountCard);
                await _unitOfWork.CompleteAsync();

                return new DiscountCardResponse(discountCard);
            }
            catch (Exception ex)
            {
                return new DiscountCardResponse($"An error occurred when saving the discount card information: {ex.Message}");
            }
        }
    }
}
