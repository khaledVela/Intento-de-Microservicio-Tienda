using MediatR;
using Restaurant.Inventory.Domain.Model.Transactions.Events;
using Restaurant.Inventory.Domain.Repositories;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Inventory.Application.UseCases.Item.EventHandlers
{
    internal class UpdateStockWhenTransactionCompleted : INotificationHandler<TransactionCompleted>
    {
        private IItemRepository _itemRepository;
        private IUnitOfWork _unitOfWork;



        public UpdateStockWhenTransactionCompleted(IItemRepository itemRepository, IUnitOfWork unitOfWork)
        {
            _itemRepository = itemRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(TransactionCompleted notification, CancellationToken cancellationToken)
        {
            var items = notification.Details;
            var factor = notification.IsEntry ? 1 : -1;
            foreach (var item in items)
            {
                var itemToUpdate = await _itemRepository.FindByIdAsync(item.ItemId);
                itemToUpdate.AddStock(factor * (int)item.Quantity, item.UnitaryCost);
                
                await _itemRepository.UpdateAsync(itemToUpdate);
            }
            await _unitOfWork.Commit(cancellationToken);
        }
    }
}
