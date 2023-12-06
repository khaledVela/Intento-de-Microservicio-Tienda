using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Inventory.Application.Dto
{
    public class ItemDto
    {
        public Guid Id { get; set; }
        public string ItemName { get; set; }

        public int Stock { get; set; }
    }
}
