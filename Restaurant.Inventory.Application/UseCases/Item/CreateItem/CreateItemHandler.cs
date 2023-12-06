using MediatR;
using Restaurant.Inventory.Domain.Repositories;
using Restaurant.SharedKernel.Core;
using Restaurant.Inventory.Domain.Model.Items;

namespace Restaurant.Inventory.Application.UseCases.Item.CreateItem
{
    internal class CreateItemHandler : IRequestHandler<CreateItemCommand, Guid>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateItemHandler(IItemRepository itemRepository, IUnitOfWork unitOfWork)
        {
            _itemRepository = itemRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            Domain.Model.Items.Item item = Domain.Model.Items.Item.CreateItem(request.ItemName);

            await _itemRepository.CreateAsync(item);


            await _unitOfWork.Commit(cancellationToken);


            return item.Id;
        }
    }
}
