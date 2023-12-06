using MediatR;
using Restaurant.Inventory.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Inventory.Application.UseCases.Item.GetItemList
{
    public class GetItemListQuery : IRequest<ICollection<ItemDto>>
    {
        
    }
}
