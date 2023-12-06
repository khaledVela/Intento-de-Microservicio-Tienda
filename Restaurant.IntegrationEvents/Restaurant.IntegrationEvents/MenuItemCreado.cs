using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.IntegrationEvents;

public class MenuItemCreado
{
    public Guid MenuItemId { get; set; }
    public string Nombre { get; set; }
    public bool EsReceta { get; set; }
    public bool EsInventariable { get; set; }
}
