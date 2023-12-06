using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Inventory.Application.Dto
{
    public class TransactionItemDto
    {
        public Guid ItemId { get; set; }
        public int Quantity { get; set; }
        public decimal Cost { get; set; }
    }
}
