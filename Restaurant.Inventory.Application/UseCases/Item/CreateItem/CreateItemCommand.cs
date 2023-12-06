using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Inventory.Application.UseCases.Item.CreateItem
{
    public class CreateItemCommand : IRequest<Guid>
    {
        public string ItemName { get; set; }
    }
}
