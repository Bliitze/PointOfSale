using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Services
{
    public partial class PosPrinter
    {
       public partial Task Print(string contract, string product, string partnumber);
       public partial Task PrintPlacedOrder();
    }
}
