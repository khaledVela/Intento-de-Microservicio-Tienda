using MediatR;
using Restaurant.Inventory.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Inventory.Application.UseCases.Transaction.CreateTransaction
{
    public class CreateTransactionCommand : IRequest<Guid>
    {
        public List<TransactionItemDto> Items { get; set; }
        public TransactionTypeEnum Type { get; set; }

        
    }
}
