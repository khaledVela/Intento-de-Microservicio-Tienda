using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Inventory.Application.UseCases.Transaction.CompleteTransaction
{
    public class CompleteTransactionCommand : IRequest
    {
        public Guid TransactionId { get; set; }
    }
}
