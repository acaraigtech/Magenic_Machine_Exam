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
    public class TransactionService : ITransactionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(IUnitOfWork unitOfWork
            , ITransactionRepository transactionRepository)
        {
            _unitOfWork = unitOfWork;
            _transactionRepository = transactionRepository;
        }

        public async Task<TransactionResponse> SaveAsync(Transaction transaction)
        {
            try
            {
                _transactionRepository.Insert(transaction);
                await _unitOfWork.CompleteAsync();

                return new TransactionResponse(transaction);
            }
            catch (Exception ex)
            {
                return new TransactionResponse($"An error occurred when saving the transaction information: {ex.Message}");
            }
        }
    }
}
