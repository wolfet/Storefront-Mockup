using StorefrontMockup.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorefrontMockup.Models
{
    public class StoreFrontDetailViewModel
    {
        public InventoryItem InventoryItem { get; set; }
        public IEnumerable<InventoryItem> RelatedItems { get; set; }
    }
}
