using MediatR;
using Restaurant.Inventory.Domain.Model.Transactions;
using Restaurant.Inventory.Domain.Model.Transactions.Factories;
using Restaurant.Inventory.Domain.Repositories;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Inventory.Application.UseCases.Transaction.CreateTransaction
{
    internal class CreateTransactionHandler : IRequestHandler<CreateTransactionCommand, Guid>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITransactionFactory _transactionFactory;

        public CreateTransactionHandler(ITransactionRepository transactionRepository, 
            IUnitOfWork unitOfWork, 
            ITransactionFactory transactionFactory)
        {
            _transactionRepository = transactionRepository;
            _unitOfWork = unitOfWork;
            _transactionFactory = transactionFactory;
        }

        public async Task<Guid> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = request.Type == Dto.TransactionTypeEnum.Entry ?
                _transactionFactory.CreateEntry() :
                _transactionFactory.CreateRelease();

            foreach (var item in request.Items)
            {
                transaction.AddItem(item.ItemId, item.Quantity, item.Cost);
            }

            await _transactionRepository.CreateAsync(transaction);
            await _unitOfWork.Commit(cancellationToken);

            return transaction.Id;
        }
    }
}
