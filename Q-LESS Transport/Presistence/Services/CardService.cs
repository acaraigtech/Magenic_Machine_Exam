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
    public class CardService : ICardService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICardRepository _cardRepository;

        public CardService(IUnitOfWork unitOfWork
            , ICardRepository cardRepository)
        {
            _unitOfWork = unitOfWork;
            _cardRepository = cardRepository;
        }
        public async Task<IEnumerable<Card>> ListAsync()
        {
            var cardList = await _cardRepository.SelectAllAsync();
            return cardList;
        }
        public async Task<IEnumerable<Card>> ListByIdAsync(Guid id)
        {
            var cardList = await _cardRepository.SelectAllByIdAsync(id);
            return cardList;
        }
        public async Task<Card> GetByIdAsync(Guid id)
        {
            var card = await _cardRepository.SelectByIdAsync(id);
            return card;
        }
        public async Task<CardResponse> SaveAsync(Card card)
        {
            try
            {
                _cardRepository.Insert(card);
                await _unitOfWork.CompleteAsync();

                return new CardResponse(card);
            }
            catch (Exception ex)
            {
                return new CardResponse($"An error occurred when saving the card information: {ex.Message}");
            }
        }
        public async Task<CardResponse> EditAsync(Guid id, Card card)
        {
            var existingCard = await _cardRepository.SelectByIdAsync(id);

            if (existingCard == null)
            {
                return new CardResponse("account not found.");
            }

            existingCard.Balance = card.Balance;
            try
            {
                _cardRepository.Update(existingCard);
                await _unitOfWork.CompleteAsync();

                return new CardResponse(existingCard);
            }
            catch (Exception ex)
            {
                return new CardResponse($"An error occurred when updating the card information: {ex.Message}");
            }
        }

    }
}
