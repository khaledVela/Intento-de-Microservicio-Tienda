using MediatR;
using Restaurant.Inventory.Domain.Repositories;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Inventory.Application.UseCases.Transaction.CompleteTransaction
{
    internal class CompleteTransactionHandler : IRequestHandler<CompleteTransactionCommand>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CompleteTransactionHandler(ITransactionRepository transactionRepository, IUnitOfWork unitOfWork)
        {
            _transactionRepository = transactionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CompleteTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = await  _transactionRepository.FindByIdAsync(request.TransactionId);

            if(transaction is null)
            {
                throw new Exception("Transaction not found");
            }
            transaction.Complete();

            //Actualizar el stock
            //Notificar al administrador
            //......
            
            await _transactionRepository.UpdateAsync(transaction);
            await _unitOfWork.Commit(cancellationToken);
            
        }
    }
}
