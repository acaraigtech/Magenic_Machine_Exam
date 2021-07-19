using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Q_LESS_Transport.Domain.Models;
using Q_LESS_Transport.Domain.Repositories;
using Q_LESS_Transport.Domain.Services;
using Q_LESS_Transport.Dtos;
using Q_LESS_Transport.Dtos.Transaction;
using Q_LESS_Transport.Fv;
using Q_LESS_Transport.Presistence.Services.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q_LESS_Transport.Controllers
{
    [Route("/api/transactions")]
    [Produces("application/json")]
    [ApiController]
    public class TransactionsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITransactionService _transactionService;
        private readonly ICardService _cardService;
        private readonly IDiscountCardRepository _discountCardRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly ICardTypeDetailsRepository _cardTypeDetailsRepository;
        private readonly ICardRepository _cardRepository;

        public TransactionsController(IMapper mapper
            , ITransactionService transactionService
            , ICardService cardService
            , IDiscountCardRepository discountCardRepository
            , ITransactionRepository transactionRepository
            , ICardTypeDetailsRepository cardTypeDetailsRepository
            , ICardRepository cardRepository)
        {
            _mapper = mapper;
            _transactionService = transactionService;
            _cardService = cardService;
            _discountCardRepository = discountCardRepository;
            _transactionRepository = transactionRepository;
            _cardTypeDetailsRepository = cardTypeDetailsRepository;
            _cardRepository = cardRepository;
        }

        /// <summary>
        /// Saves a new transaction information.
        /// </summary>
        /// <param name="request">transaction request information.</param>
        /// <returns>Response for the request.</returns>
        [HttpPost("save")]
        [ProducesResponseType(typeof(TransactionResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> SaveAsync([FromBody] TransactionRequestResource request)
        {
            if (request.TransactionCode == null)
            {
                throw new ArgumentNullException("Transaction code is null");
            }
            TransactionResource transactionResource = new TransactionResource();
            if (request.TransactionCode == Common.TRANSACTION_CODE_FR)
            {
                transactionResource = await doTransactionFR(request);
            }
            if (request.TransactionCode == Common.TRANSACTION_CODE_RL)
            {
                transactionResource = await doTransactionRL(request);
            }

            return Ok(transactionResource);
        }

        public async Task<TransactionResource> doTransactionFR(TransactionRequestResource request)
        {
            if (request.CardId == null)
            {
                throw new ArgumentNullException("CardId is null");
            }
            var card = await _cardRepository.SelectByIdAsync(request.CardId);
            double balance = card.Balance;

            if (request.CardTypeDetailsId == null)
            {
                throw new ArgumentNullException("Card Type Details Id is null");
            }
            var cardTypeDetails = await _cardTypeDetailsRepository.SelectByIdAsync(request.CardTypeDetailsId);
            double amount = cardTypeDetails.FareAmount;
            if ((balance - amount) < 1)
            {
                throw new InvalidOperationException("Your balance are insufficient, Please reload");
            }

            var discountCard = await _discountCardRepository.SelectByCardIdAsync(request.CardId);
            if (discountCard != null)
            {
                amount = await doDiscountComputation(request, amount);
            }
            SaveTransactionResource saveTransaction = new SaveTransactionResource();
            saveTransaction.Amount = amount;
            saveTransaction.CardId = request.CardId;
            saveTransaction.TransactionCode = request.TransactionCode;
            saveTransaction.Date = Date.StrToDateTime(DateTime.Now);

            var resource = _mapper.Map<SaveTransactionResource, TransactionResource>(saveTransaction);
            var transactionResource = await SaveTransaction(resource);

            
            card.Balance = balance - transactionResource.Amount;
            bool isUpdated = await UpdateCardBalance(request.CardId, card);

            return transactionResource;
        }

        public async Task<TransactionResource> doTransactionRL(TransactionRequestResource request)
        {
            if (request.CardId == null)
            {
                throw new ArgumentNullException("CardId is null");
            }
            var card = await _cardRepository.SelectByIdAsync(request.CardId);

            if (card.Id == null)
            {
                throw new ArgumentNullException("Card data not found");
            }

            if (card.Balance == Common.MAXIMUM_BALANCE_AMOUNT)
            {
                throw new InvalidOperationException("You have a maximum load balance");
            }

            var resource = doTransactionComputation(request, card.Id, card.Balance);
            card.Balance = resource.NewBalance;

            bool isUpdated = await UpdateCardBalance(card.Id, card);

            var transactionResult = await SaveTransaction(resource);
            resource.Id = transactionResult.Id;
            return resource;
        }

        public async Task<TransactionResource> SaveTransaction(TransactionResource resource)
        {
            SaveTransactionResource saveTransactionResource = new SaveTransactionResource();
            saveTransactionResource.Amount = resource.Amount;
            saveTransactionResource.Date = resource.Date;
            saveTransactionResource.CardId = resource.CardId;
            saveTransactionResource.TransactionCode = resource.TransactionCode;

            var transaction = _mapper.Map<SaveTransactionResource, Transaction>(saveTransactionResource);
            var transactionResult = await _transactionService.SaveAsync(transaction);

            if (!transactionResult.Success)
            {
                var errMsg = new ErrorResource(transactionResult.Message);
                throw new InvalidOperationException(errMsg.ToString());
            }

            var transactionResource = _mapper.Map<Transaction, TransactionResource>(transactionResult.Resource);
            return transactionResource;
        }
        public async Task<double> doDiscountComputation(TransactionRequestResource request, double fareAmount)
        {
            var dateTime = Date.StrToDateTime(DateTime.Now);
            var numOfTransaction = await _transactionRepository.SelectByCardIdAndDateAsync(request.CardId, dateTime);
            double amount = 0.00;
            if (numOfTransaction.Count() > 0 && numOfTransaction.Count() < 5)
            {
                amount = fareAmount - (fareAmount * Common.POINT_TWENTY_THREE);
            }
            else
            {
                amount = fareAmount - (fareAmount * Common.POINT_TWENTY);
            }

            return amount;
        }

        public async Task<bool> UpdateCardBalance(Guid cardId, Card card)
        {
            var cardResult = await _cardService.EditAsync(cardId, card);

            if (!cardResult.Success)
            {
                var errMsg = new ErrorResource(cardResult.Message);
                return false;
                throw new InvalidOperationException(errMsg.ToString());
                
            }
            return true;
        }

        public TransactionResource doTransactionComputation(TransactionRequestResource request, Guid cardId, double cardBalance)
        {
            TransactionResource resource = new TransactionResource();
            double loadable = Common.MAXIMUM_BALANCE_AMOUNT - cardBalance;
            double loaded = 0.00;
            if (request.Amount <= loadable)
            {
                loaded = request.Amount;
            } else
            {
                loaded = loadable;
            }
            double change = request.CustomerMoney - loaded;
            double newBalance = cardBalance + loaded;

            resource.NewBalance = newBalance;
            resource.CardId = cardId;
            resource.TransactionCode = request.TransactionCode;

            resource.Date = Date.StrToDateTime(DateTime.Now);
            resource.CustomerMoney = request.CustomerMoney;
            resource.Change = change;
            resource.Amount = loaded;
            return resource;
        }
    }
}
