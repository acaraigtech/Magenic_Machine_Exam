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
    public class CardTypeDetailsService : ICardTypeDetailsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICardTypeDetailsRepository _cardTypeDetailsRepository;

        public CardTypeDetailsService(IUnitOfWork unitOfWork
            , ICardTypeDetailsRepository cardTypeDetailsRepository)
        {
            _unitOfWork = unitOfWork;
            _cardTypeDetailsRepository = cardTypeDetailsRepository;
        }

        public async Task<IEnumerable<CardTypeDetails>> ListAsync()
        {
            var cardList = await _cardTypeDetailsRepository.SelectAllAsync();
            return cardList;
        }

        public async Task<CardTypeResponse> SaveAsync(CardTypeDetails cardType)
        {
            try
            {
                _cardTypeDetailsRepository.Insert(cardType);
                await _unitOfWork.CompleteAsync();

                return new CardTypeResponse(cardType);
            }
            catch (Exception ex)
            {
                return new CardTypeResponse($"An error occurred when saving the card type information: {ex.Message}");
            }
        }
    }
}
