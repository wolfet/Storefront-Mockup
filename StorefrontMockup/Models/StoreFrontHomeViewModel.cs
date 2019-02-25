using StorefrontMockup.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorefrontMockup.Models
{
    public class StoreFrontHomeViewModel
    {
        public StoreFrontHomeViewModel()
        {
            InventoryItems = new List<InventoryItem>();
        }

        public IEnumerable<InventoryItem> InventoryItems { get; set; }
    }
}
